package bluetooth.servidor;

import java.io.IOException;
import java.text.SimpleDateFormat;
import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.Multipart;
import javax.mail.Part;
import javax.mail.internet.MimeMultipart;

/**
 * lida com as mensagens de protocolo que podem ser recebidas ou enviadas a partir
 * do servidor
 */
public class Protocolo {
    
    /**
     * accao de protocolo invalida
     */
    public static int INVALIDO = -1;
    /**
     * o servidor indicou ao cliente que houve um erro durante o envio de um e-mail
     */
    public static int ERRO_AO_ENVIAR_MAIL = 10;
    /**
     * erro de autenticacao de um utilizador.
     * - nome de utilizador ou password incorrecto
     */
    public static int ERRO_AUTENTICACAO_FALHOU = 11;
    /**
     * autenticacao bem sucedida
     */
    public static int OK_AUTENTICACAO_OK = 12;
    /**
     * o cliente pediu os seus mails e o servidor retornou com a mensagem OK_RECEBER_MAIL
     * que indica que o email foi retornado do mailserver com sucesso e vai no stream
     * actual de dados.
     */
    public static int OK_RECEBER_MAIL = 13;
    /**
     * o mail que o utilizador quis enviar chegou com sucesso
     */
    public static int OK_MAIL_ENVIADO_SUCESSO = 14;
    
    /**
     * executar uma operacao de autenticacao
     */
    public static int OP_AUTENTICACAO = 15;
    /**
     * buscar o mail
     */
    public static int OP_BUSCAR_MAIL = 16;
    /**
     * enviar um mail
     */
    public static int OP_ENVIAR_MAIL = 17;
    /**
     * um problema qualquer com o servidor.
     * pode ser por o servidor estar em baixo, nao existir uma ligacao, falha de rede etc.
     */
    public static int ERRO_SERVIDOR = 18;
    /**
     * o endereco de email que o utilizador nao e valido e portanto nao e possivel
     * enviar o mail
     */
    public static int ERRO_ENDERECO_MAIL_INVALIDO_OU_REJEITADO = 19;
    /**
     * terminar a sessao
     */
    public static int OP_LOGOUT = 20;
    /**
     * nao existem mails novos no servidor
     */
    public static int ERRO_NAO_TEM_MAILS_NOVOS = 21;
    
    
    /**
     * o que e que a mensagem de protocolo quer fazer
     * @param strProtocolo a mensagem de protocolo de onde vai ser extraida a accao
     * @return a accao de protocolo.
     * -1 se for invalida
     * um numero qualquer (ver constantes em cima)
     */
    public static int getAccao(String strProtocolo) {
        int cod = -1;
        
        try {            
            cod = Integer.parseInt(strProtocolo.substring(0, 2));
        } catch(NumberFormatException ex) {
            cod = -1;
        } finally {                        
            return cod;
        }
    }
    
    /**
     * saca a tag <username> de uma mensagem de protocolo
     * @param strProtocolo a mensagem de protocolo de onde vai ser extraido o nome de utilizador
     * @return String, username
     */
    public static String getNomeUtilizador(String strProtocolo) {
        return strProtocolo.substring(strProtocolo.indexOf("<username>") + 10, strProtocolo.indexOf("</username>"));
    }
    
    /**
     * saca a tag <password> de uma mensagem de protocolo
     * @param strProtocolo a mensagem de protocolo de onde vai ser extraida a password
     * @return String, password
     */
    public static String getPassword(String strProtocolo) {
        return strProtocolo.substring(strProtocolo.indexOf("<password>") + 10, strProtocolo.indexOf("</password>"));
    }
    
    /**
     * saca a tag <para> de uma mensagem de protocolo
     * @param strProtocolo a mensagem de protocolo de onde vao ser extraidos os emails para que se quer
     * enviar
     * @return String para quem e
     */
    public static String getMailPara(String strProtocolo) {
        return strProtocolo.substring(strProtocolo.indexOf("<para>") + 6, strProtocolo.indexOf("</para>"));
    }
    
    /**
     * saca a tag <assunto> de uma mensagem de protocolo
     * @param strProtocolo a mensagem de protocolo de onde vai ser extraido o assunto do email
     * @return String, assunto
     */
    public static String getAssunto(String strProtocolo) {
        return strProtocolo.substring(strProtocolo.indexOf("<assunto>") + 9, strProtocolo.indexOf("</assunto>"));
    }
    
    /**
     * saca a tag <conteudo> de uma mensagem de protocolo
     * @param strProtocolo a mensagem de protocolo de onde vai ser extraido o texto do email
     * @return String, texto
     */
    public static String getTexto(String strProtocolo) {
        return strProtocolo.substring(strProtocolo.indexOf("<conteudo>") + 10, strProtocolo.indexOf("</conteudo>"));
    }
    
    /**
     * saca a tag <data> de uma mensagem de protocolo
     * @param strProtocolo a mensagem de protocolo de onde vai ser extraida uma data
     * @return String, data
     */
    public static String getData(String strProtocolo) {
        String valRetorno = null;
        
        if(strProtocolo.indexOf("<data>") != -1) {
            valRetorno = strProtocolo.substring(strProtocolo.indexOf("<data>") + 6, strProtocolo.indexOf("</data>"));
        }
        
        return valRetorno;
    }
    
    /**
     * controi a mensagem de protocolo para um email
     * @param msg a mensagem de onde vai ser extraida a informacao
     * @return retorna uma String com a mensagem de protocolo constituida
     */
    public static String setMail(Message msg) {
        Multipart mp = null;
        StringBuffer sb = new StringBuffer();
        SimpleDateFormat sdf = new SimpleDateFormat("EEEE, MMMM d yyyy - H:m:s");
        int numAnexos = 0;
        
        try {
            //  dizer que o mail comeca aqui
            //sb = sb.append("<mail" + ((nMail < 10) ? "0" : "") + nMail +">");
            sb = sb.append("<mail>");
            
            //  assunto
            sb = sb.append("<assunto>" + msg.getSubject() +"</assunto>");
            
            //  data do email
            sb = sb.append("<data>" + sdf.format(msg.getSentDate()) +"</data>");
            
            System.out.println("x: " + sdf.format(msg.getSentDate()));
            
            //  quem enviou
            String de = msg.getFrom()[0].toString();
            int index = de.indexOf('<');
            
            //  deixar so o endereco de email
            if(index != -1) {
                de = de.substring(index + 1, de.indexOf('>'));
            }
            
            sb = sb.append("<enviado>" + de +"</enviado>");
            
            //  o conteudo do email propriamente dito
            sb = sb.append("<conteudo>");
            
            if(msg.getContentType().startsWith("text/plain")) {
                sb = sb.append((String)msg.getContent());
            } else {                
                mp = (MimeMultipart)msg.getContent();
                Part p = mp.getBodyPart(0);
                Object obj = p.getContent();
                
                if(obj instanceof String) {
                    sb = sb.append((String)obj);
                } else if(obj instanceof Multipart) {
                    Multipart mp2 = (Multipart)obj;
                    Part p2 = mp2.getBodyPart(0);
                    sb = sb.append((String)p2.getContent());
                }
                
                //  -1 porque um dos numAnexos e o texto correspondente
                numAnexos = mp.getCount() - 1;
            }
            
            sb = sb.append("</conteudo>");
                        
            //  se a numero de partes for mais do que um, quer dizer que existem
            //  mais numAnexos (ficheiros)
            if(numAnexos > 0 && mp != null) {
                sb = sb.append("<anexos>");
                sb = sb.append("<qt>" + numAnexos + "</qt>");
                
                for(int i = 1; i <= numAnexos; i++) {
                    Part p = mp.getBodyPart(i);
                    sb = sb.append("<nome>" + p.getFileName() + "</nome>");
                    sb = sb.append("<tam>" + (p.getSize() / 1024) + "</tam>");                    
                }
                
                sb = sb.append("</anexos>");
            }
            
            //  terminar a info do mail
            sb.append("</mail>\n");
            
        } catch (MessagingException ex) {
            ex.printStackTrace();
        } catch(IOException ex) {
            ex.printStackTrace();
        }
        
        return sb.toString();
    }
    
    /**
     * construir a tag <tam> que indica o numero de emails que vao na mensagem
     * @param numMails o numero de emails
     * @return a tag constituida <tam>
     */
    public static String setNumeroMails(int numMails) {
        return "<tam>" + String.valueOf(numMails) + "</tam>";
    }
    
    /**
     * indica o nome da accao de protocolo a realizar
     * @param id a id (ver constantes em cima)
     * @return String com o nome da accao
     */
    public static String getNomeAccao(int id) {
        String msg;
        
        if(id == Protocolo.OP_AUTENTICACAO) {
            msg = "Autenticacao";
        } else if(id == Protocolo.OP_BUSCAR_MAIL) {
            msg = "Buscar Mail";
        } else if(id == Protocolo.OP_ENVIAR_MAIL) {
            msg = "Enviar Mail";
        }  else if(id == Protocolo.OP_LOGOUT) {
            msg = "Logout";
        }  else {
            msg = "Invalida";
        }
        
        return msg;
    }
}