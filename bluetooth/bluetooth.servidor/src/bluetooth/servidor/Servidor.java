package bluetooth.servidor;

import java.io.DataInputStream;
import java.io.IOException;
import java.util.Vector;
import javax.bluetooth.RemoteDevice;
import javax.microedition.io.Connector;
import javax.microedition.io.StreamConnection;
import javax.microedition.io.StreamConnectionNotifier;
import org.bouncycastle.util.encoders.Base64;

/**
 * contem metodos de recepcao de dados, execucao de mensagens de protocolo
 * escuta e tratamento de ligacoes.
 */
public class Servidor {
    /**
     * UUID do servido oferecido
     */
    private String UUID_SERVICO = "9856";
    /**
     * o nome do servidor
     */
    private String NOME_SERVIDOR = "bluetooth_at_ispgaya";
    /**
     * para aceitar ligacoes ao servidor e ao servido oferecido
     */
    private StreamConnectionNotifier service;
    /**
     * Vector que contem objectos do tipo Cliente.
     * cada entrada corresponde a um cliente ligado...
     */
    private Vector<Cliente> listaClientes = new Vector<Cliente>();
    private LDAP ldap = new LDAP();
    
    /**
     * inicia o servidor
     * @throws java.io.IOException se ocorrer algum erro na criacao do servidor.
     * talvez nao haja nenhum dispositivo bluetooth ligado...
     */
    public void iniciar() throws IOException {
        ldap.ligar();
        service = (StreamConnectionNotifier)Connector.open("btspp://localhost:" + UUID_SERVICO + ";name=" + NOME_SERVIDOR);
        
        new Thread() {
            public void run() {
                escutarLigacoes();
            }
        }.start();
    }
    
    /**
     * desliga o servidor
     */
    public void terminar() {
        try {
            service.close();
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }
    
    /**
     * fica a espera de ligacoes ao servidor
     */
    private void escutarLigacoes() {
        StreamConnection conn;
        
        while(true) {
            try {
                System.out.println("# a escutar...");
                conn = service.acceptAndOpen();
                
                ligacaoRecebida(conn);
            }catch(IOException ex) {
                ex.printStackTrace();
                break;
            }
        }
    }
    
    /**
     * quando e recebida uma ligacao temos que adicionar o cliente que se ligou
     * ao Vector e abrir os streams de comunicacao
     * @param sc o stream onde foi recebida a ligacao
     */
    private void ligacaoRecebida(StreamConnection sc) {
        try {
            RemoteDevice rd = RemoteDevice.getRemoteDevice(sc);
            
            Cliente cliente = new Cliente();
            
            //  o meu dispositivo
            cliente.setDispRemoto(rd);
            
            //  stream para recepcao de dados do dispositivo
            cliente.setInputStream(sc.openDataInputStream());
            
            //  stream para envio de dados para o dispositivo
            cliente.setOutputStream(sc.openDataOutputStream());
            
            //  o endereco bluetooth do dispositivo
            cliente.setEnderecoBluetooth(rd.getBluetoothAddress());
            
            //  o nome do dispositivo
            cliente.setNomeBluetooth(rd.getFriendlyName(false));
            
            //  stream
            cliente.setStream(sc);
            
            listaClientes.add(cliente);
            System.out.println("# " + cliente.getNomeBluetooth() + "[" + cliente.getEnderecoBluetooth() + "], ligou-se ao servidor...");
            
            //  iniciar a recepcao de dados para o cliente que acabou de entrar
            new Thread() {
                public void run() {
                    receberDados(listaClientes.elementAt(listaClientes.size() - 1));
                }
            }.start();
            
        } catch(IOException ex) {
            ex.printStackTrace();
        }
    }
    
    /**
     * receber dados de um cliente no seu DataInputStream
     * @param cliente o cliente do qual recebemos os dados
     */
    private void receberDados(Cliente cliente){
        DataInputStream inputStream = cliente.getInputStream();
        String msg;
        
        try  {
            while((msg = inputStream.readUTF()) != null) {
                msg = Seguranca.desencriptar(msg, cliente.getKey());
                
                if(msg.length() == 2 && Integer.parseInt(msg) == Protocolo.OP_LOGOUT) {
                    break;
                } else {
                    executarAccao(Protocolo.getAccao(msg), msg, cliente);
                }
            }
        } catch(IOException ex) {
            //ex.printStackTrace();
        }
        
        desligarCliente(cliente);
    }
    
    /**
     * desliga um cliente do servidor e remove-o do Vector de Clientes
     * @param cliente o cliente a desligar
     */
    private void desligarCliente(Cliente cliente) {
        System.out.println("# " + cliente.getNomeBluetooth() + ", terminou a ligacao ao servidor...");
        
        cliente.desligar();
        listaClientes.removeElement(cliente);
    }
    
    /**
     * executa uma determinada accao de protocolo.
     *
     * as unicas mensagens que o cliente pode enviar para o servidor sao:
     * # Protocolo.OP_AUTENTICACAO - autenticar
     * # Protocolo.OP_BUSCAR_MAIL - buscar o mail da inbox
     * # Protocolo.OP_ENVIAR_MAIL - enviar um email
     * # Protocolo.OP_LOGOUT - terminar a ligacao com o servidor
     * @param accao a accao a realizar
     * @param msg a mensagem de protocolo recebida
     * @param cliente o cliente que executou a accao
     */
    private void executarAccao(int accao, String msg, Cliente cliente) {
        System.out.println("$ " + cliente.getNomeBluetooth() + ", quer: " + Protocolo.getNomeAccao(accao));
        
        if(accao == Protocolo.OP_AUTENTICACAO) {
            String username = Protocolo.getNomeUtilizador(msg);
            String password = Protocolo.getPassword(msg);
            
            int ret = ldap.autenticar(username, password);
            
            if(ret == Protocolo.OK_AUTENTICACAO_OK) {
                cliente.setPassword(password);
                cliente.setNomeUtilizador(username);
                cliente.setNomeMail(username + Mail.MAIL_DOMINIO);                                
            }
            
            //  na mensagem de autenticacao tambem vai incluido a classe do 
            //  dispositivo que e filtrada aqui
            try {
                int len = msg.length();
                int tipo = Integer.parseInt(msg.substring(len - 3));
                
                cliente.setClasseDispositivo(tipo);                
            } catch(NumberFormatException ex) {
                
            }
            
            cliente.enviarDados(String.valueOf(ret));
            
        } else if(accao == Protocolo.OP_BUSCAR_MAIL) {
            String mails = Mail.buscarMail(cliente.getNomeUtilizador(), cliente.getPassword(), Protocolo.getData(msg));
            
            System.out.println();
            
            if(mails.length() == 0) {
                cliente.enviarDados(String.valueOf(Protocolo.ERRO_NAO_TEM_MAILS_NOVOS));
            } else {
                cliente.enviarDados(String.valueOf(Protocolo.OK_RECEBER_MAIL) + mails);
            }
            
        } else if(accao == Protocolo.OP_ENVIAR_MAIL) {
            String por = cliente.getNomeMail();
            String para = Protocolo.getMailPara(msg);
            String assunto = Protocolo.getAssunto(msg);
            String texto = Protocolo.getTexto(msg);
            
            int ret = Mail.enviarMail(por, para, assunto, texto);
            cliente.enviarDados(String.valueOf(ret));
        }
    }
}