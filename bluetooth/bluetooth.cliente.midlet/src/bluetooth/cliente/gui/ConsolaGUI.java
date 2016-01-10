/*
 * ConsolaGUI.java
 *
 * Created on 30 de Junho de 2006, 17:52
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package bluetooth.cliente.gui;

import javax.microedition.lcdui.Command;
import javax.microedition.lcdui.Form;
import javax.microedition.lcdui.StringItem;

/**
 * a consola e onde aparecem mensagens de debug e detalhe das operacoes
 * @author Ricardo
 */
public class ConsolaGUI extends Form {
    /**
     * as mensagens
     */
    private StringItem mensagens; 
    
    /**
     * o construtor.
     * so deve ser inicializado uma vez.
     */
    public ConsolaGUI() {
        super("Consola");
        
        addCommand(new Command("Voltar", Command.BACK, 1));
        mensagens = new StringItem("", "");
                
        append(mensagens);
    }
    
    /**
     * escreve qualquer coisa na consola
     * @param msg a mensagem a escrever na consola
     */
    public void escrever(String msg) {
        mensagens.setText(mensagens.getText() + "\n" + msg);
    }
}
