/*
 * MidletGUI.java
 *
 * Created on 30 de Junho de 2006, 14:36
 */

package bluetooth.cliente;

import bluetooth.cliente.gui.AutenticacaoGUI;
import bluetooth.cliente.gui.ComporGUI;
import bluetooth.cliente.gui.ConsolaGUI;
import bluetooth.cliente.gui.MailsGUI;
import javax.microedition.lcdui.Displayable;
import javax.microedition.lcdui.Form;
import javax.microedition.lcdui.List;



/**
 * contem metodos que retornam o GUI seleccionado pelo utilizador
 * @author Ricardo
 */
public class MidletGUI {    
    /**
     * nenhum ecra seleccionado
     */
    public final int ECRA_NENHUM = -1;
    /**
     * constante que representa o menu principal
     */
    public final int ECRA_MENU_PRINCIPAL = 0;
    /**
     * constante que representa a List onde sao listados os email recebidos e tambem
     * os guardados no RMS
     */
    public final int ECRA_LISTAGEM_MAILS = 1;
    /**
     * constante que representa o Form onde e visualizado cada mail em detalhe
     */
    public final int ECRA_VER_MAIL = 2;
    /**
     * constante que representa o ecra onde o utilizador coloca os seus detalhes para
     * autenticacao
     */
    public final int ECRA_AUTENTICACAO = 3;
    /**
     * constante que indica o Form onde e composto um mail
     */
    public final int ECRA_COMPOR_MAIL = 4;
    /**
     * constante que indica o Form onde o utilizador escreve para quem que enviar o mail
     */
    public final int ECRA_ENVIAR_PARA = 5;
    /**
     * constante que indica o ecra da consola
     */
    public final int ECRA_CONSOLA = 6;    
    /**
     * constante que representa a List onde estao representadas as opcoes que podemos
     * executar sobre esse email
     */
    public final int ECRA_OPCOES_MAIL = 7;
    /**
     * constante que representa o Form de informacao adicional de um certo mail previamente
     * seleccinado
     */
    public final int ECRA_INFO_ADICIONAL = 8;
    
    /**
     * Contem os elementos que constituem o menu principal
     */
    public List menuPrincipal;
    /**
     * contem os GUIs de listagem de mails, e todo o tipo de detalhes associado (info
     * adicional, conteudo dos emails)
     */
    public MailsGUI mails;
    /**
     * GUI de autenticacao
     */
    public AutenticacaoGUI auth;
    /**
     * GUI de composicao de e-mails
     */
    public ComporGUI compor;
    /**
     * o GUI da consola
     */
    public ConsolaGUI consola;
    
    /**
     * a ID (ver constantes em cima) do ecra que esta seleccionado
     */
    public int actualID = ECRA_NENHUM;
    
    /**
     * controi o menu principal
     * @return retorna um objecto do tipo List com as opcoes seleccionaveis
     */
    private List menuPrincipal() {
        if(menuPrincipal == null) {
            String[] opcoesMenuPrincipal = {"Ver e-mails",
            "Compor e-mail",            
            "Autenticar",
            "Consola",
            "Sair"};
            
            menuPrincipal = new List("Menu Principal (desligado)", List.IMPLICIT, opcoesMenuPrincipal, null);
        }
        
        compor = null;
        
        return menuPrincipal;
    }
    
    /**
     * mostra o GUI listagem de emails (quem enviou e o assunto).
     * e mostrada uma List onde o utilizador pode seleccionar o email de que quer ver
     * mais detalhes.
     * 
     * o preenchimento nao e feito aqui!
     * @return retorna a List onde vao ser colocados os dados referentes aos mails recebidos.
     * @see MailsGUI.java
     */
    private List listagemMails() {
        if(mails == null) {
            mails = new MailsGUI();
        }
        
        return mails.listar();
    }
    
    /**
     * quando o utilizador selecciona um mail especifico da lista de mails.
     * 
     * o preenchimento nao e feito aqui.
     * @return um Form onde, mais tarde, serao preenchidos os detalhes
     * @see MailsGUI.java
     */
    private Form verMail() {        
        return mails.ver();
    }
    
    /**
     * o GUI onde os utilizadores colocam o nome e a password
     * @return retorna o GUI de autenticacao
     */
    private Form autenticacao() {
        if(auth == null) {
            auth = new AutenticacaoGUI();
        }
        
        return auth;
    }
    
    /**
     * GUI onde o utilizador escreve os mails para que quer enviar
     * @return uma Form onde os utilizadores escrevem os emails para que querem enviar
     */
    private Form enviarPara() {
        return compor.ecraPara();
    }
    
    /**
     * GUI onde os utilizadores compoe o mail. assunto e texto.
     * @return a form de composicao de mails
     */
    private Form comporMail() {                        
        if(compor == null) {
            compor = new ComporGUI();
        }
        
        return compor.compor();
    }
    
    /**
     * a consola e utilizada para mensagens de erro e debug
     * @return o form da consola
     */
    public Form consola() {
        if(consola == null) {
            consola = new ConsolaGUI();
        }
        
        return consola;
    }
    
    /**
     * as opcoes que um utilizador pode realizar sobre o mail seleccionado
     * @return o form de opcoes
     */
    private List opcoesMail() {
        return mails.opcoes();
    }
    
    /**
     * informacoes adicionais sobre o mail seleccionado
     * @return a form onde sao mostradas as informacoes adicionais
     */
    private Form infoAdicional() {
        return mails.infoAdicional();
    }
    
    /**
     * mostra o menu seleccionado como parametro. ver constantes...
     * @param id a constante do tipo ECRA_*
     * @return o Displayable do menu seleccionado (um Form ou List)
     */
    public Displayable mostrarMenu(int id) {
        Displayable novoEcra;
        
        if(id == ECRA_MENU_PRINCIPAL) {
            novoEcra = menuPrincipal();
        } else if(id == ECRA_LISTAGEM_MAILS) {
            novoEcra = listagemMails();
        } else if(id == ECRA_VER_MAIL) {
            novoEcra = verMail();
        } else if(id == ECRA_AUTENTICACAO) {
            novoEcra = autenticacao();
        } else if(id == ECRA_COMPOR_MAIL) {
            novoEcra = comporMail();
        } else if(id == ECRA_ENVIAR_PARA) {
            novoEcra = enviarPara();
        } else if(id == ECRA_CONSOLA) {
            novoEcra = consola();
        } else if(id == ECRA_OPCOES_MAIL) {
            novoEcra = opcoesMail();
        } else if(id == this.ECRA_INFO_ADICIONAL) {
            novoEcra = infoAdicional();
        } else {        
            novoEcra = null;
        }
        
        actualID = id;
        
        return novoEcra;
    }
}
