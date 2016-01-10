package bluetooth.servidor;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Properties;
import javax.mail.AuthenticationFailedException;
import javax.mail.Folder;
import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.NoSuchProviderException;
import javax.mail.Session;
import javax.mail.Store;
import javax.mail.Transport;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;
import javax.mail.search.ComparisonTerm;
import javax.mail.search.SearchTerm;
import javax.mail.search.SentDateTerm;

/**
 * contem metodos de envio e recepcao de email
 */
public class Mail {
    
    /**
     * o endereco do servidor de SMTP
     */
    public static final String MAIL_HOST_SMTP = "mail.ispgaya.pt";
    /**
     * o endereco do servidor de POP3
     */
    public static final String MAIL_HOST_POP3 = "mail.ispgaya.pt";
    /**
     * o dominio de endereco de email
     */
    public static final String MAIL_DOMINIO = "@ispgaya.pt";
    
    /**
     * enviar um e-mail
     * @param de de quem e o email.
     * isto deve ser colocado automaticamente atraves do metodo Cliente.getNomeMail()
     * @param para para quem e.
     * podem ser multiplos enderecos separados por uma virgula (,)
     * @param assunto o assunto do email
     * @param texto o texto do email
     * @return Protocolo.ERRO_ENDERECO_MAIL_INVALIDO_OU_REJEITADO -> problema ao enviar
     * Protocolo.OK_MAIL_ENVIADO_SUCESSO -> mail enviado correctamente
     */
    public static int enviarMail(String de, String para, String assunto, String texto) {
        int estado = Protocolo.ERRO_ENDERECO_MAIL_INVALIDO_OU_REJEITADO;
        
        try {
            Properties props = System.getProperties();
            props.put("mail.smtp.host", MAIL_HOST_SMTP);
            
            Session session = Session.getInstance(props);
            Message msg = new MimeMessage(session);
            
            String[] listaEnderecos = para.split(",");
            
            InternetAddress enderecoDe = new InternetAddress(de);
            msg.setFrom(enderecoDe);
            
            InternetAddress[] enderecoPara = new InternetAddress[listaEnderecos.length];
            
            for(int i = 0; i < enderecoPara.length; i++) {
                enderecoPara[i] = new InternetAddress(listaEnderecos[i].trim());
            }
            
            msg.addRecipients(Message.RecipientType.TO, enderecoPara);
            
            msg.setSubject(assunto);
            msg.setText(texto);
            
            Transport.send(msg);
            
            estado = Protocolo.OK_MAIL_ENVIADO_SUCESSO;
        } catch (MessagingException ex) {
            ex.printStackTrace();
        }
        
        return estado;
    }
    
    /**
     * enviar um mail ja composto
     * @param msg o email
     * @return Protocolo.ERRO_ENDERECO_MAIL_INVALIDO_OU_REJEITADO -> problema ao enviar
     * Protocolo.OK_MAIL_ENVIADO_SUCESSO -> mail enviado correctamente
     */
    public static int enviarMail(Message msg) {
        int estado = Protocolo.ERRO_ENDERECO_MAIL_INVALIDO_OU_REJEITADO;
        
        try {
            Transport.send(msg);
            estado = Protocolo.OK_MAIL_ENVIADO_SUCESSO;
        } catch (MessagingException ex) {
            ex.printStackTrace();
        }
        
        return estado;
    }
    
    /**
     * ligar a um servidor pop3
     * @param nomeUtilizador nome de utilizador
     * @param password password
     * @return um objecto store para se poder aceder a inbox deste cliente
     */
    public static Store ligarPop3(String nomeUtilizador, String password) {
        Properties propriedades = System.getProperties();
        
        Session sessao = Session.getInstance(propriedades);
        Store store;
        
        try {
            store = sessao.getStore("pop3");
            store.connect(MAIL_HOST_POP3, nomeUtilizador, password);
        } catch (NoSuchProviderException ex) {
            store = null;
        } catch (MessagingException ex) {
            store = null;
        }
        
        return store;
    }
    
    /**
     * buscar o email a um servidor pop3
     * @param nomeUtilizador o nome de utilizador
     * @param password a password de acesso
     * @param data a data da ultima tentativa de acesso ao email
     * @return String com os email.
     * se nao houver mails novos, vai vazia
     */
    public static String buscarMail(String nomeUtilizador, String password, String data) {
        boolean soRecentes = false;
        
        System.out.println("data: " + data);
        
        SimpleDateFormat sdf = new SimpleDateFormat("EEEE, MMMM d yyyy - H:m:s");
        Date dataUltimoAcesso = null;
        
        Message mensagens[] = null;
        StringBuffer sbMail = new StringBuffer();
        
        if(data != null) {
            try {
                dataUltimoAcesso = sdf.parse(data);
            } catch (ParseException ex) {   }
            
            soRecentes = true;
        }
        
        Store store = ligarPop3(nomeUtilizador, password);
        
        if(store != null) {
            try {
                Folder inbox = store.getFolder("INBOX");
                inbox.open(Folder.READ_ONLY);
                
                if(soRecentes) {
                    SearchTerm st = new SentDateTerm(ComparisonTerm.GE, dataUltimoAcesso);
                    mensagens = inbox.search(st);
                } else {
                    mensagens = inbox.getMessages();
                }
                
                if(mensagens.length > 0) {
                    for(int i = 0; i < mensagens.length; i++) {                        
                        String str = Protocolo.setMail(mensagens[i]);
                        sbMail = sbMail.append(str);
                    }
                }
                
                inbox.close(false);
                store.close();
            } catch (MessagingException ex) {
                ex.printStackTrace();
            }
        }

        return sbMail.toString();
    }
}
