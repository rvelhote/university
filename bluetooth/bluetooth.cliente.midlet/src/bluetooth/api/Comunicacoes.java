package bluetooth.api;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import javax.bluetooth.BluetoothStateException;
import javax.bluetooth.DiscoveryAgent;
import javax.bluetooth.LocalDevice;
import javax.bluetooth.RemoteDevice;
import javax.bluetooth.ServiceRecord;
import javax.bluetooth.UUID;
import javax.microedition.io.Connector;
import javax.microedition.io.StreamConnection;

/**
 * lida com as comunicacoes efectuadas com o servidor.
 *
 * - ligar/desigar
 * - enviar mensagens de protocolo
 * @author Ricardo
 */
public class Comunicacoes {
    
    /**
     * nao existe nenhuma ligacao a um servidor
     */
    public final int ESTADO_DESLIGADO = 0;
    /**
     * esta a ser feita uma tentativa de ligacao
     */
    public final int ESTADO_A_LIGAR = 1;
    /**
     * esta ligado a um servidor de bluetooth
     */
    public final int ESTADO_LIGADO = 2;
    /**
     * durante o estado ESTADO_A_LIGAR se nao for feita nenhuma ligacao, este e o estado
     * seguinte.
     */
    public final int ESTADO_IMPOSSIVEL_LIGAR = 3;
    public final int ESTADO_LOGGED_OUT = 4;
    /**
     * armazena o estado actual da ligacao
     */
    private int estadoLigacao = ESTADO_DESLIGADO;        
    /**
     * stream de envio de dados
     */
    public DataOutputStream output;
    /**
     * stream de recepcao de dados
     */
    public DataInputStream input;    
    /**
     * sc
     */
    private StreamConnection connection;    
    /**
     * o RemoteDevice correspondente ao servidor a que estamos ligados
     */
    private RemoteDevice servidor;
    /**
     * UUID do servico a pesquisar
     */
    private UUID uuid = new UUID("9856", true);
    private int tipoDispositivo;
    
    /**
     * actualiza o estado da ligacao
     * @param novoEstado o novo estado
     */
    public void setEstadoLigacao(int novoEstado) {
        estadoLigacao = novoEstado;
    }
    
    /**
     * qual o estado actual da ligacao?
     * @return o estado actual
     */
    public int getEstadoLigacao() {
        return estadoLigacao;
    }    
    
    /**
     * ligar a um servidor bluetooth
     */
    public void ligar() {
        new Thread() {
            public void run() {
                try {
                    setEstadoLigacao(ESTADO_A_LIGAR);
                    
                    LocalDevice dispLocal = LocalDevice.getLocalDevice();
                    tipoDispositivo = dispLocal.getDeviceClass().getMajorDeviceClass();                    
                    DiscoveryAgent discAgent  = dispLocal.getDiscoveryAgent();
                    
                    String enderecoServidor = discAgent.selectService(uuid, ServiceRecord.NOAUTHENTICATE_NOENCRYPT, false);
                    
                    if(enderecoServidor != null) {
                        finalizarLigacao(enderecoServidor);
                    } else {
                        setEstadoLigacao(ESTADO_IMPOSSIVEL_LIGAR);
                    }
                } catch (BluetoothStateException ex) {
                    ex.printStackTrace();
                }
            }
        }.start();
    }
    
    /**
     * enviar um email
     * @param para para quem e?
     * @param assunto qual o assunto?
     * @param texto o que e que esta la escrito?
     */
    public void enviarMail(String para, String assunto, String texto) {
        enviarDados(Protocolo.enviarMail(para, assunto, texto));
    }
    
    /**
     * envia para o servidor uma mensagem de autenticacao
     * @param nomeUtilizador o nome de utilizador com o qual nos vamos autenticar
     * @param password a password de acesso
     */
    public void autenticar(String nomeUtilizador, String password) {
        enviarDados(Protocolo.autenticar(nomeUtilizador, password) + String.valueOf(tipoDispositivo));
    }
    
    /**
     * depois de encontrado um servidor bluetooth com a UUID correcta, aqui sao realizados
     * os ultimos detalhes da ligacao: abrir os streams de input e output de informacao
     * @param enderecoServidor o endereco do servidor.
     * btspp://blbalbalbalba
     */
    private void finalizarLigacao(String enderecoServidor) {
        try {
            connection = (StreamConnection)Connector.open(enderecoServidor);
            output = connection.openDataOutputStream();
            input = connection.openDataInputStream();
            
            setEstadoLigacao(ESTADO_LIGADO);
        } catch(IOException e) {
            //e.printStackTrace();
            setEstadoLigacao(ESTADO_IMPOSSIVEL_LIGAR);
        }
    }
    
    /**
     * dizer ao servidor para nos enviar o conteudo da nossa inbox
     * @param dataUltimoMail a data do mail mais recente que temos na nossa lista.
     *
     * se for null, serao retornados todos os email da inbox
     * se for uma data valida, serao apenas retornados os email a partir dessa data.
     */
    public void buscarMail(String dataUltimoMail) {
        enviarDados(Protocolo.buscarMail(dataUltimoMail));
    }    
    
    /**
     * enviar dados para o servidor
     * @param msg a mensagem a enviar para o servidor
     */
    private void enviarDados(String msg) {
        try {
            output.writeUTF(Seguranca.encriptar(msg, Seguranca.getKey()));
        } catch (IOException ex) {
            //ex.printStackTrace();
        }
    }
    
    /**
     * termina uma ligacao com o servidor
     *
     * !! NAO FUNCIONA (BEM...) !!
     */
    public void terminarLigacao() {
        try {                       
            output.close();
            input.close();
            connection.close();
            
            setEstadoLigacao(ESTADO_DESLIGADO);
        } catch (IOException ex) {
            //ex.printStackTrace();
        }
    }
    
    public void logout() {
        enviarDados(String.valueOf(Protocolo.OP_LOGOUT));
        setEstadoLigacao(ESTADO_LOGGED_OUT);
        
        try {                       
            output.close();
            input.close();
            connection.close();            
        } catch (IOException ex) {            
        }
    }
}
