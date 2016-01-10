/*
 * MailsGUI.java
 *
 * Created on 30 de Junho de 2006, 16:30
 */

package bluetooth.cliente.gui;

import bluetooth.api.BaseDeDados;
import javax.microedition.lcdui.Command;
import javax.microedition.lcdui.Form;
import javax.microedition.lcdui.List;
import javax.microedition.lcdui.StringItem;

/**
 * contem os GUI de:
 * - listagem de mails
 * - visualizacao de um mail especifico
 * - opcoes que podem ser realizadas sobre um determinado mail
 * - informacao adicional sobre um mail seleccionado
 * @author Ricardo
 */
public class MailsGUI {
    private StringItem dados;
    private StringItem infoAdicional;
    private StringItem infoAnexos;
    
    private List listaMails;
    private Form verMail;
    private List opcoes;
    private Form info;
    
    /**
     * a List que contem o assunto e quem enviou
     * @return a List onde esta a info
     */
    public List listar() {        
        listaMails = new List("e-mails", List.IMPLICIT, new String[] {"nao tens mails"}, null);
        
        listaMails.addCommand(new Command("Voltar", Command.BACK, 1));
        listaMails.addCommand(new Command("Buscar", Command.OK, 1));

        return listaMails;
    }
    
    /**
     * o formulario onde e visualizado os detalhes de um e-mail
     * @return o form
     */
    public Form ver() {
        if(verMail == null) {
            verMail = new Form("");
            
            verMail.addCommand(new Command("Voltar", Command.BACK, 1));
            verMail.addCommand(new Command("Opcoes", Command.OK, 1));
            
            dados = new StringItem("", "");
            
            verMail.append(dados);
        }
        return verMail;
    }
    
    /**
     * o formulario onde sao mostradas as opcoes que se podem realizar sobre um determinado
     * mail
     * @return o form
     */
    public List opcoes() {
        if(opcoes == null) {
            String[] listaOpcoes = {"apagar",
            "responder",
            "info adicional",
            "guardar"};
            
            opcoes = new List("Opcoes", List.IMPLICIT, listaOpcoes, null);
            
            opcoes.addCommand(new Command("Voltar", Command.BACK, 1));
        }
        
        return opcoes;
    }
    
    /**
     * o formulario onde e mostrada a informacao adicional de um mail
     * @return o form
     */
    public Form infoAdicional() {
        if(info == null) {
            info = new Form("Info Adicional");
            
            info.addCommand(new Command("Voltar", Command.BACK, 1));
            infoAdicional = new StringItem("", "");
            infoAnexos = new StringItem("", "");
                       
            info.append(infoAdicional);
            info.append(infoAnexos);
        }
        
        return info;
    }
    
    /**
     * preenche os dados do email seleccionado:
     * - quem enviou
     * - assunto
     * - texto
     * @param mail objecto que contem os dados a preencher
     */
    public void setDados(BaseDeDados mail) {
        verMail.setTitle(mail.getDe());
        
        dados.setLabel(mail.getAssunto());
        dados.setText(mail.getConteudo());
        
        mail.setNovo(false);
    }
    
    /**
     * saca o email que esta seleccionado neste momento
     * @return a posicao na List do email seleccionado
     */
    public int getMailSeleccionado() {
        return listaMails.getSelectedIndex();
    }
    
    /**
     * retorna a opcao seleccionada no menu 'opcoes'
     * @return opcao seleccionada
     */
    public int getOpcaoSeleccionada() {
        return opcoes.getSelectedIndex();
    }
    
    /**
     * limpa a lista de mails
     */
    public void limparListaMails() {
        while(listaMails.size() != 0) {
            listaMails.delete(0);
        }
    }
    
    /**
     * remove um mail da List
     * @param id a ID (posicao na List) do elemento que queremos remover
     */
    public void removerMail(int id) {
        listaMails.delete(id);
    }
    
    /**
     * adicionar um email a List correspondente
     * @param mail objecto que contem os dados do mail que queremos adicionar
     */
    public void adicionarMail(BaseDeDados mail) {
        listaMails.append((listaMails.size() + 1) + ((mail.isNovo()) ? "*" : "") + ")" + mail.getDe() + "\n" + mail.getAssunto(), null);
    }
    
    /**
     * preenche o TextField correspondente com informacao adicional de um email
     * @param mail objecto que contem informacao sobre um mail qualquer
     */
    public void setInfoAdicional(BaseDeDados mail) {
        infoAdicional.setLabel("enviado por:\n* " + mail.getDe());
        infoAdicional.setText("\ndata:\n* " + mail.getData() + "\n\nassunto:\n* " + mail.getAssunto());
        
        infoAnexos.setLabel("\n\nanexos: " + mail.anexos.length);
        infoAnexos.setText("\n");
        for(int i = 0; i < mail.anexos.length; i++) {
            infoAnexos.setText(infoAnexos.getText().concat((i + 1) + ")" + mail.anexos[i].getNomeAnexo() + "\n" + mail.anexos[i].getTamanhoAnexo() + "Kb\n\n"));
        }
    }
}
