package bluetooth.cliente;

import bluetooth.api.BaseDeDados;
import bluetooth.api.Comunicacoes;
import bluetooth.api.InfoCliente;
import bluetooth.api.Protocolo;
import bluetooth.api.RecepcaoDeDados;
import bluetooth.api.Seguranca;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.Date;
import javax.microedition.lcdui.Alert;
import javax.microedition.lcdui.AlertType;
import javax.microedition.lcdui.Command;
import javax.microedition.lcdui.CommandListener;
import javax.microedition.lcdui.Display;
import javax.microedition.lcdui.Displayable;
import javax.microedition.midlet.MIDlet;

/**
 * a midlet do cliente j2me
 * @author Ricardo
 * @version 0.1
 */
public class ClienteBluetoothMidlet extends MIDlet implements RecepcaoDeDados, CommandListener {
    
    /**
     * instancia da classe Comunicacoes.
     */
    private Comunicacoes comunicacoes;
    
    /**
     * instancia da classe InfoCliente
     */
    private InfoCliente cliente;
    
    /**
     * instancia da classe GUI
     */
    private MidletGUI gui;
    
    /**
     * o display
     */
    private Display display;
    
    /**
     * apontador para o primeiro elemento da lista que vai guardar os emails recebidos
     * e tambem os que ja estavam armazenados no RMS (se existirem).
     */
    private BaseDeDados lista;
    
    /**
     * instancia da classe RMS
     */
    private RMS rms;
    
    /**
     * id do menu ao qual vamos retornar. normalmente, quando se mostra um alerta, ele
     * volta ao Displayable que estava a mostrar anteriormente. no entanto, as vezes
     * podemos querer que ele va para outro sitio. e para isso que isto serve.
     */
    private int menuRetorno;
    
    /**
     * o construtor da classe.
     * inicializa algumas instancias de classes...
     */
    public ClienteBluetoothMidlet() {
        cliente = new InfoCliente();
        comunicacoes = new Comunicacoes();
        gui = new MidletGUI();
        rms = new RMS();
        
        lista = null;
    }
    
    /**
     * startApp()
     */
    public void startApp() {
        getChave();
        
        rms.abrirBD();
        lista = rms.carregar(lista);
        
        display = Display.getDisplay(this);
        
        /**
         * inicializar a consola. tem que ser o primeiro ehe...
         */
        gui.consola();
        setEcra(gui.ECRA_MENU_PRINCIPAL);
    }
    
    /**
     * pauseApp()
     */
    public void pauseApp() {
    }
    
    /**
     * coloca o ecra seleccionado como parametro como o actualmente visivel
     * @param id constante presente em MidletGUI.java -> ECRA_*
     */
    private void setEcra(int id) {
        Displayable actual = gui.mostrarMenu(id);
        
        /**
         * verificar se a id era invalida
         */
        if(actual != null) {
            
            /**
             * adicionar um listener ao ecra actual para podermos despoletar eventos
             */
            actual.setCommandListener(this);
            display.setCurrent(actual);
            
            /**
             * se estivermos ligado a um servidor, colocar uma opcao adicional no menu principal
             */
            if(id == gui.ECRA_MENU_PRINCIPAL && comunicacoes.getEstadoLigacao() == comunicacoes.ESTADO_LIGADO && gui.menuPrincipal.size() != 6) {
                gui.menuPrincipal.append("Terminar ligacao", null);
                
                /**
                 * se ja estivemos ligados mas agora estamos desligado, remover a opcao
                 */
            } else if(id == gui.ECRA_MENU_PRINCIPAL && comunicacoes.getEstadoLigacao() == comunicacoes.ESTADO_DESLIGADO && gui.menuPrincipal.size() == 6) {
                gui.menuPrincipal.delete(5);
            }
        }
    }
    
    /**
     * indica qual o menu de retorno.
     * @param id a id do menu que queremos que seja de retorno.
     */
    private void setMenuRetorno(int id) {
        menuRetorno = id;
    }
    
    /**
     * destroyApp()
     * @param unconditional ?
     */
    public void destroyApp(boolean unconditional) {
    }
    
    /**
     * gere as accoes provocadas pelo utilizador quando este activa um comando qualquer
     * @param command o comando que despoletou o evento
     * @param displayable List ou Form (ou outra coisa qualquer) onde foi realizado o evento.
     */
    public void commandAction(Command command, Displayable displayable) {
        if(gui.actualID == gui.ECRA_MENU_PRINCIPAL) {
            int opcao = gui.menuPrincipal.getSelectedIndex();
            
            if(opcao == 0) {
                setEcra(gui.ECRA_LISTAGEM_MAILS);
                
                if(lista != null) {
                    preencherListaDeMails();
                }
                
            } else if(opcao == 1) {
                setEcra(gui.ECRA_COMPOR_MAIL);
            } else if(opcao == 2) {
                setEcra(gui.ECRA_AUTENTICACAO);
            } else if(opcao == 3) {
                setEcra(gui.ECRA_CONSOLA);
            } else if(opcao == 4) {                
                if(comunicacoes.getEstadoLigacao() == comunicacoes.ESTADO_LIGADO) {
                    comunicacoes.logout();
                }

                sairAplicacao();
            } else if(opcao == 5) {
                comunicacoes.logout();
                gui.menuPrincipal.delete(5);
            }
            
            
        } else if(gui.actualID == gui.ECRA_LISTAGEM_MAILS) {
            if(command.getCommandType() == command.BACK) {
                setEcra(gui.ECRA_MENU_PRINCIPAL);
            } else if(command.getCommandType() == command.OK) {
                if(cliente.estaAutenticado()) {
                    mostrarAlerta("Tranferindo...", "A transferir email's...", AlertType.INFO, 0);
                    comunicacoes.buscarMail(rms.getUltimoAcesso());
                } else if(comunicacoes.getEstadoLigacao() != comunicacoes.ESTADO_LIGADO) {
                    mostrarAlerta("Aviso!", "Não está ligado a nenhum servidor...", AlertType.ERROR, 0);
                } else {
                    mostrarAlerta("Aviso!", "Tem de se autenticar!", AlertType.ERROR, 0);
                }
            } else {
                setEcra(gui.ECRA_VER_MAIL);
                preencherDetalhesMail(gui.mails.getMailSeleccionado());
            }
            
            
        } else if(gui.actualID == gui.ECRA_VER_MAIL) {
            if(command.getCommandType() == command.BACK) {
                setEcra(gui.ECRA_LISTAGEM_MAILS);
                preencherListaDeMails();
            } else if(command.getCommandType() == command.OK) {
                setEcra(gui.ECRA_OPCOES_MAIL);
            }
            
            
        } else if(gui.actualID == gui.ECRA_AUTENTICACAO) {
            if(command.getCommandType() == command.BACK) {
                setEcra(gui.ECRA_MENU_PRINCIPAL);
            } else if(command.getCommandType() == command.OK) {
                
                if(comunicacoes.getEstadoLigacao() == comunicacoes.ESTADO_DESLIGADO || comunicacoes.getEstadoLigacao() == comunicacoes.ESTADO_LOGGED_OUT) {
                    comunicacoes.ligar();
                    mostrarAlerta("A ligar...", "A tentar ligar a um servidor.\nAguarde...", AlertType.INFO, 0);
                    
                    new Thread() {
                        public void run() {
                            while(comunicacoes.getEstadoLigacao() != comunicacoes.ESTADO_LIGADO
                                    && comunicacoes.getEstadoLigacao() != comunicacoes.ESTADO_IMPOSSIVEL_LIGAR) {
                            }
                            
                            if(comunicacoes.getEstadoLigacao() == comunicacoes.ESTADO_LIGADO) {
                                receberDados();
                                comunicacoes.autenticar(gui.auth.getNomeUtilizador(), gui.auth.getPassword());
                                
                                mostrarAlerta("Concluido", "Está ligado a um servidor\n\na fazer autenticação.", AlertType.INFO, 0);
                                
                                setMenuRetorno(gui.ECRA_MENU_PRINCIPAL);
                            } else {
                                setEcra(gui.ECRA_AUTENTICACAO);
                                try {
                                    Thread.sleep(1);
                                } catch (InterruptedException ex) {
                                    ex.printStackTrace();
                                }
                                mostrarAlerta("Erro...", "Não foi possivel estabelecer uma ligação ao servidor.", AlertType.INFO, 0);
                                comunicacoes.setEstadoLigacao(comunicacoes.ESTADO_DESLIGADO);
                            }
                            
                            monitorLigacao();
                        }
                    }.start();
                    
                } else if(!cliente.estaAutenticado() && comunicacoes.getEstadoLigacao() == comunicacoes.ESTADO_LIGADO) {
                    comunicacoes.autenticar(gui.auth.getNomeUtilizador(), gui.auth.getPassword());
                } else if(cliente.estaAutenticado()) {
                    mostrarAlerta("Erro...", "Já tem uma ligação estabelecida. Tem que fazer logout primeiro.", AlertType.INFO, 0);
                }
            }
            
            
        } else if(gui.actualID == gui.ECRA_COMPOR_MAIL) {
            if(command.getCommandType() == command.BACK) {
                setEcra(gui.ECRA_MENU_PRINCIPAL);
            } else if(command.getCommandType() == command.OK) {
                setEcra(gui.ECRA_ENVIAR_PARA);
            }
            
            
        } else if(gui.actualID == gui.ECRA_ENVIAR_PARA) {
            if(command.getCommandType() == command.BACK) {
                setEcra(gui.ECRA_COMPOR_MAIL);
            } else if(command.getCommandType() == command.OK) {
                
                if (comunicacoes.getEstadoLigacao() != comunicacoes.ESTADO_LIGADO) {
                    mostrarAlerta("Aviso!", "Não se encontra ligado ao servidor", AlertType.ERROR, 0);
                } else if (!cliente.estaAutenticado()) {
                    mostrarAlerta("Aviso!", "Tem que se autenticar", AlertType.ERROR, 0);
                } else {
                    mostrarAlerta("A enviar...", "A enviar o mail.\naguarde...", AlertType.INFO, 0);
                    comunicacoes.enviarMail(gui.compor.getListaPara(), gui.compor.getAssunto(), gui.compor.getTexto());
                }
            }
            
            
        } else if(gui.actualID == gui.ECRA_CONSOLA) {
            if(command.getCommandType() == command.BACK) {
                setEcra(gui.ECRA_MENU_PRINCIPAL);
            }
            
            
        } else if(gui.actualID == gui.ECRA_OPCOES_MAIL) {
            if(command.getCommandType() == command.BACK) {
                setEcra(gui.ECRA_VER_MAIL);
            } else {
                int opcaoSeleccionada = gui.mails.getOpcaoSeleccionada();
                int mailSeleccionado = gui.mails.getMailSeleccionado();
                
                /**
                 * apagar um e-mail da lista de e-mails
                 */
                if(opcaoSeleccionada == 0) {
                    apagarMail(mailSeleccionado);
                    
                    /**
                     * responder a um email
                     */
                } else if(opcaoSeleccionada == 1) {
                    setEcra(gui.ECRA_COMPOR_MAIL);
                    //gui.compor.resposta(bd[mailSeleccionado], lista);
                    gui.compor.resposta(BaseDeDados.getElementoNaPosicao(mailSeleccionado, lista));
                    
                    /**
                     * mostrar informacao adicional
                     */
                } else if(opcaoSeleccionada == 2) {
                    setEcra(gui.ECRA_INFO_ADICIONAL);
                    infoAdicional(mailSeleccionado);
                    
                    /**
                     * guardar email
                     */
                } else if(opcaoSeleccionada == 3) {
                    guardarMail(mailSeleccionado);
                }
            }
        } else if(gui.actualID == gui.ECRA_INFO_ADICIONAL) {
            if(command.getCommandType() == command.BACK) {
                setEcra(gui.ECRA_OPCOES_MAIL);
            }
        }
    }
    
    /**
     * apaga um mail da lista de visualizacao com determinada id. a ID e o elemento que
     * esta actualmente seleccionado
     * na List
     * @param id a ID do mail a eliminar. esta ID e relativa a posicao do elemento na List
     * @see MailsGUI.java
     */
    public void apagarMail(int id) {
        //
        //  eliminar da List
        //
        gui.mails.removerMail(id);
        
        //
        //  verificar se existe no RMS. se existir, eliminar
        //
        rms.eliminar(BaseDeDados.getElementoNaPosicao(id, lista));
        
        //
        //  eliminar da lista ligada
        //
        lista = BaseDeDados.eliminarRegisto(lista, BaseDeDados.getElementoNaPosicao(id, lista));
        
        setEcra(gui.ECRA_LISTAGEM_MAILS);
        preencherListaDeMails();
    }
    
    /**
     * preencher a informacao adicional de um email seleccionado com determinada ID. a
     * ID e o elemento que esta actualmente seleccionado
     * na List
     * @param id a ID do mail a mostrar
     * @see MailsGUI.java
     */
    public void infoAdicional(int id) {
        gui.mails.setInfoAdicional(BaseDeDados.getElementoNaPosicao(id, lista));
    }
    
    /**
     * guarda um mail no RMS
     * @param id a ID do mail a armazenar. a ID e o elemento que esta actualmente seleccionado
     * na List
     */
    public void guardarMail(int id) {
        BaseDeDados mail = BaseDeDados.getElementoNaPosicao(id, lista);
        
        if(rms.inserir(mail)) {
            mostrarAlerta("ok!", "Mail gravado com sucesso", AlertType.CONFIRMATION, 0);
            rms.verRms();
        } else {
            mostrarAlerta("Erro!", "Erro ao gravar o email", AlertType.ERROR, 0);
        }
    }
    
    /**
     * preencher os detalhes de um email seleccionado com determinada ID. a ID e o
     * elemento que esta actualmente seleccionado na List e a informacao a mostrar e
     * relativa ao assunto, texto do email e quem enviou.
     * @param id a ID do mail a mostrar.
     * @see MailsGUI.java
     * @see BaseDeDados.java
     */
    public void preencherDetalhesMail(int id) {
        gui.mails.setDados(BaseDeDados.getElementoNaPosicao(id, lista));
    }
    
    /**
     * quando activamos a opcao de 'ver email' do menu principal da midlet, temos que
     * preencher a List.
     * @see MailsGUI.java
     * @see BaseDeDados.java
     */
    public void preencherListaDeMails() {
        gui.mails.limparListaMails();
        
        BaseDeDados percorre = lista;
        while(percorre != null) {
            gui.mails.adicionarMail(percorre);
            percorre = percorre.prox;
        }
    }
    
    /**
     * sair da aplicacao
     */
    private void sairAplicacao() {
        destroyApp(true);
        notifyDestroyed();
    }
    
    /**
     * implementacao do metodo da Interface 'RecepcaoDeDados'.
     * executa comandos de protocolo.
     * @param accao o comando a executar.
     * @param msg a restante string de protocolo de onde podemos extrair outra informacao.
     */
    public void executarAccaoProtocolo(int accao, String msg) {
        
        System.out.println(msg);
        
        if(accao == Protocolo.INVALIDO) {
            System.out.println("o protocolo esta mal!!");
            
            
        } else if(accao == Protocolo.OK_AUTENTICACAO_OK) {
            cliente.setEstado(cliente.AUTENTICADO);
            cliente.setNomeUtilizador(gui.auth.getNomeUtilizador());
            cliente.setPassword(gui.auth.getPassword());
            
            gui.menuPrincipal.setTitle("Menu Principal (ligado)");
            
            setEcra(menuRetorno);
            try {
                Thread.sleep(1);
            } catch (InterruptedException ex) {
                ex.printStackTrace();
            }
            mostrarAlerta("Autenticação", "Foi autenticado com sucesso!", AlertType.INFO, 0);
            
            
        } else if(accao == Protocolo.ERRO_AUTENTICACAO_FALHOU) {
            gui.menuPrincipal.setTitle("Menu Principal (nao autenticado)");
            
            cliente.setEstado(cliente.NAO_AUTENTICADO);
            setEcra(menuRetorno);
            try {
                Thread.sleep(1);
            } catch (InterruptedException ex) {
                ex.printStackTrace();
            }
            mostrarAlerta("Aviso!", "Nome de utilizador ou password incorrecto!", AlertType.INFO, 0);
            
            
        } else if(accao == Protocolo.OK_RECEBER_MAIL) {
            int numMailsAntes = BaseDeDados.getTamanhoLista(lista);
            
            lista = Protocolo.extrairMails(msg, lista);
            rms.setUltimoAcesso(new Date());
            setEcra(gui.ECRA_LISTAGEM_MAILS);
            try {
                Thread.sleep(1);
            } catch (InterruptedException ex) {
                ex.printStackTrace();
            }
            mostrarAlerta("E-Mails", "Tem " + (BaseDeDados.getTamanhoLista(lista) - numMailsAntes) + " mails novos.", AlertType.INFO, 0);
            preencherListaDeMails();
            
            
        } else if(accao == Protocolo.OK_MAIL_ENVIADO_SUCESSO) {
            setEcra(gui.ECRA_MENU_PRINCIPAL);
            try {
                Thread.sleep(1);
            } catch (InterruptedException ex) {
                ex.printStackTrace();
            }
            mostrarAlerta("info", "O seu email foi enviado com sucesso!", AlertType.INFO, 0);
            
            
        } else if(accao == Protocolo.ERRO_AO_ENVIAR_MAIL) {
            setEcra(gui.ECRA_MENU_PRINCIPAL);
            try {
                Thread.sleep(1);
            } catch (InterruptedException ex) {
                ex.printStackTrace();
            }
            mostrarAlerta("info", "Ocorreu um erro ao enviar o email!", AlertType.INFO, 0);
            
            
        } else if(accao == Protocolo.ERRO_SERVIDOR) {
            setEcra(gui.ECRA_MENU_PRINCIPAL);
            try {
                Thread.sleep(1);
            } catch (InterruptedException ex) {
                ex.printStackTrace();
            }
            mostrarAlerta("Erro!", "Existe um problema com o servidor!", AlertType.INFO, 0);
            
            
        } else if(accao == Protocolo.ERRO_ENDERECO_MAIL_INVALIDO_OU_REJEITADO) {
            setEcra(gui.ECRA_ENVIAR_PARA);
            try {
                Thread.sleep(1);
            } catch (InterruptedException ex) {
                ex.printStackTrace();
            }
            mostrarAlerta("Erro!", "O envio de mail falhou porque um ou mais endereços de envio sao invalidos!", AlertType.INFO, 0);
            
            
        } else if(accao == Protocolo.ERRO_NAO_TEM_MAILS_NOVOS) {
            rms.setUltimoAcesso(new Date());
            
            setEcra(gui.ECRA_LISTAGEM_MAILS);
            try {
                Thread.sleep(1);
            } catch (InterruptedException ex) {
                ex.printStackTrace();
            }
            mostrarAlerta("info", "Não tem mails novos", AlertType.ERROR, 0);
            preencherListaDeMails();
        }
    }
    
    /**
     * Implementacao do metodo receberDados da interface RecepcaoDeDados
     * @see RecepcaoDeDados.java
     */
    public void receberDados() {
        new Thread() {
            public void run() {
                while(comunicacoes.getEstadoLigacao() == comunicacoes.ESTADO_LIGADO) {
                    try {
                        String msg = comunicacoes.input.readUTF();
                        msg = Seguranca.desencriptar(msg, Seguranca.getKey());
                        executarAccaoProtocolo(Protocolo.getAccao(msg), msg);
                    } catch (IOException ex) {
                        break;
                    }
                }
                
                if(comunicacoes.getEstadoLigacao() != comunicacoes.ESTADO_LOGGED_OUT) {
                    mostrarAlerta("!!!", "A ligação ao servidor foi perdida.\nEstabelecer nova ligação.", AlertType.ERROR, 0);
                    comunicacoes.terminarLigacao();
                }
                cliente.setEstado(cliente.NAO_AUTENTICADO);
                gui.menuPrincipal.setTitle("Menu Principal (desligado)");
            }
        }.start();
    }
    
    /**
     * mostra um alerta ao utilizador
     * @param titulo o titulo do alerta
     * @param msg a mensagem a mostrar
     * @param tipo o tipo de alerta (Info, Error, Warning etc.)
     * @param timeout o tempo que o alerta ficara visivel (em ms)
     */
    private void mostrarAlerta(String titulo, String msg, AlertType tipo, int timeout) {
        Alert alerta = new Alert(titulo, msg, null, tipo);
        alerta.setTimeout( ((timeout == 0) ? Alert.FOREVER : timeout));
        display.setCurrent(alerta);
    }
    
    /**
     * vai ao ficheiro 'key' buscar a chave de encriptacao deste utilizador!
     */
    public void getChave() {
        char[] buffer = new char[32];
        byte[] key = null;
        
        try {
            InputStream is = getClass().getResourceAsStream("key");
            
            if(is != null) {
                InputStreamReader isr = new InputStreamReader(is);
                isr.read(buffer);
                key = new String(buffer).getBytes();
                
                Seguranca.setKey(key);
            }
        } catch(Exception ex) {
            ex.printStackTrace();
        }
    }
    
    /**
     * implementacao do metodo da interface RecepcaoDeDados.
     * monitoriza o estado da ligacao de 10 em 10 segundos. quando o estado for
     * Comunicacoes.ESTADO_DESLIGADO, pesquisa novos servidores bluetooth. se encontrar
     * um, tenta-se nova ligacao com o nome de utilizador e password do menu de autenticacao
     */
    public void monitorLigacao() {
        new Thread() {
            public void run() {
                while(true) {
                    System.out.println("estado: " + comunicacoes.getEstadoLigacao());
                    if(comunicacoes.getEstadoLigacao() == comunicacoes.ESTADO_DESLIGADO) {
                        comunicacoes.ligar();
                        
                        while(comunicacoes.getEstadoLigacao() != comunicacoes.ESTADO_LIGADO
                                && comunicacoes.getEstadoLigacao() != comunicacoes.ESTADO_IMPOSSIVEL_LIGAR) {
                        }
                        
                        if(comunicacoes.getEstadoLigacao() == comunicacoes.ESTADO_LIGADO) {
                            receberDados();
                            comunicacoes.autenticar(cliente.getNomeUtilizador(), cliente.getPassword());
                            setMenuRetorno(gui.actualID);
                        } else {
                            comunicacoes.setEstadoLigacao(comunicacoes.ESTADO_DESLIGADO);
                        }
                    }
                    
                    try {
                        Thread.sleep(10000);
                    } catch (InterruptedException ex) {
                        ex.printStackTrace();
                    }
                }
            }
        }.start();
    }
}
