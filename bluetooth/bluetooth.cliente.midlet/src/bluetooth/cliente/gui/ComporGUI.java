/*
 * ComporGUI.java
 *
 * Created on 30 de Junho de 2006, 17:27
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package bluetooth.cliente.gui;

import bluetooth.api.BaseDeDados;
import javax.microedition.lcdui.Command;
import javax.microedition.lcdui.Form;
import javax.microedition.lcdui.TextField;

/**
 * GUI de:
 * - composicao de email
 * - ecra de enviar para
 * @author Ricardo
 */
public class ComporGUI {
    
    /**
     * textfield onde se escreve o assunto do email
     */
    private TextField assunto;
    /**
     * textfield onde se escreve o texto do email
     */
    private TextField texto;    
    /**
     * textfield onde indicamos os emails para que queremos enviar.
     * cada mail e separado por uma virgula (,)
     * 
     * a informacao deste textfield e tratada no servidor. quando se enviar esta lista
     * deve-se enviar sem modificacoes de qualquer tipo
     */
    private TextField listaPara;
    
    /**
     * Form onde vai aparecer a textfield 'listaPara'
     */
    private Form para;
    /**
     * Form de composicao de emails.
     * contem as textfields assunto e texto
     */
    private Form composicao;

    /**
     * ecra de composicao de email.
     * contem uma area para escrever o assunto e outra para o texto do email
     * @return retorna a form onde e escrito o email
     */
    public Form compor() {
        if(composicao == null) {
            composicao = new Form("Compor e-mail");
            
            composicao.addCommand(new Command("Voltar", Command.BACK, 1));
            composicao.addCommand(new Command("Seguinte", Command.OK, 1));
        
            assunto = new TextField("ASSUNTO: ", "", 100, TextField.ANY);
            texto = new TextField("MENSAGEM: ", "", 200, TextField.ANY);
        
            composicao.append(assunto);
            composicao.append(texto);
            
            ecraPara();
        }
        
        return composicao;
    }
    
    /**
     * o ecra de envio para contem um TextField onde o utilizador pode escrever os
     * emails para que quer enviar.
     * @return a form onde sao escritos os emails de envio
     */
    public Form ecraPara() {
        if(para == null) {
            para = new Form("Enviar para...");            
            listaPara = new TextField("", "", 100, TextField.EMAILADDR);
            
            para.addCommand(new Command("Voltar", Command.BACK, 1));
            para.addCommand(new Command("Enviar", Command.OK, 1));
            
            para.append(listaPara);
        }
        
        return para;
    }
    
    /**
     * quando o utilizador selecciona a opcao de resposta no menu de opcoes de um mail
     * especifico, este metodo e chamado para preencher os campos de assunto e da lista
     * de mails de envio.
     * @param mail um objecto do tipo BaseDeDados que contem informacao sobre o mail seleccionado
     */
    public void resposta(BaseDeDados mail) {
        listaPara.setString(mail.getDe());      
        assunto.setString("RE: " + mail.getAssunto());
    }
    
    /**
     * o texto inserido no TextoField assunto
     * @return o assunto do email
     */
    public String getAssunto() {
        return assunto.getString();
    }
    
    /**
     * o texto inserido no TextoField texto
     * @return o sumo do mail
     */
    public String getTexto() {
        return texto.getString();
    }
    
    /**
     * saca os mails inseridos no TextField 'listaPara'
     * @return os emails de utilizadores para quem vai ser enviado o email
     */
    public String getListaPara() {
        return listaPara.getString();
    }
    
}
