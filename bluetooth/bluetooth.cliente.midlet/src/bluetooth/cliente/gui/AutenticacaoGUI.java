/*
 * AutenticacaoGUI.java
 *
 * Created on 30 de Junho de 2006, 17:01
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package bluetooth.cliente.gui;

import javax.microedition.lcdui.Choice;
import javax.microedition.lcdui.ChoiceGroup;
import javax.microedition.lcdui.Command;
import javax.microedition.lcdui.Form;
import javax.microedition.lcdui.TextField;

/**
 * classe do GUI de autenticacao.
 * 
 * e aqui que sao criados os objectos que permitem a insercao dos dados do utilizador,
 * nome de utilizador e password.
 * @author Ricardo
 */
public class AutenticacaoGUI extends Form {
    
    /**
     * textfield com o nome de utilizador
     */
    private TextField nomeUtilizador;
    /**
     * textfield com a password
     */
    private TextField password;
    /**
     * a checkbox que permite ao utilizador guardar ou nao a password no RMS
     */
    private ChoiceGroup guardarPassword;
    
    /**
     * retorna o ecra de autenticacao de utilizador.
     * se ele ja estiver criado, nao vale a pena voltar a criar.
     */
    public AutenticacaoGUI() {
        super("Autenticacao");
        
        nomeUtilizador = new TextField("Utilizador: ", "", 20, TextField.ANY);
        password = new TextField("Password: ", "", 20, TextField.PASSWORD);
        
        nomeUtilizador.setString("ric");
        password.setString("19_ciganet_2003");
        
        guardarPassword = new ChoiceGroup(null, Choice.MULTIPLE);
        guardarPassword.append("gravar", null);
        
        addCommand(new Command("Voltar", Command.BACK, 1));
        addCommand(new Command("Autenticar", Command.OK, 1));
        
        append(nomeUtilizador);
        append(password);
        append(guardarPassword);
    }
    
    /**
     * retorna o nome de utilizador escrito na TextField
     * @return uma string que contem o nome de utilizador
     */
    public String getNomeUtilizador() {
        return nomeUtilizador.getString();
    }
    
    /**
     * retorna a password escrita na TextField
     * @return uma string que contem a password
     */
    public String getPassword() {
        return password.getString();
    }
    
    /**
     * obter a opcao seleccionad no menu de guardarPassword
     * 
     * @return a opcao actualmente seleccionada
     */
    public int getOpcaoSeleccionada() {
        return guardarPassword.getSelectedIndex();
    }        
    
    /**
     * verificar se a opcao de guardar password do GUI de autenticacao esta seleccionada
     * @return true -> esta seleccionada
     * false -> nao esta seleccionada
     */
    public boolean estaSeleccionadoGuardarPassword() {
        return (guardarPassword.isSelected(0)) ? true : false;
    }
}
