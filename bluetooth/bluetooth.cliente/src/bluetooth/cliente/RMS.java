package bluetooth.cliente;

import bluetooth.api.Armazenamento;
import bluetooth.api.BaseDeDados;
import java.text.SimpleDateFormat;
import java.util.Date;
import javax.microedition.rms.InvalidRecordIDException;
import javax.microedition.rms.RecordEnumeration;
import javax.microedition.rms.RecordStore;
import javax.microedition.rms.RecordStoreException;
import javax.microedition.rms.RecordStoreNotOpenException;

/**
 * contem metodos de acesso ao RMS do dispositivo movel
 * @author ric
 */
public class RMS implements Armazenamento {
    
    /**
     * instancia do RecordStore onde vao ser buscados/armazenados os mails
     */
    private RecordStore recMails;
    /**
     * instancia de RecordStore utilizada para aceder ao RMS de informacao do utilizador.
     * guarda password, nome de utilizador, e ultima data de acesso ao email.
     */
    private RecordStore recInfo;    
    /**
     * indica o maximo de emails que se podem guardar no RMS devido as limitacoes de
     * espaco
     */
    public int MAX_EMAILS = 10; 
    
    /**
     * guarda os dados do e-mail passado como parametro no RMS.
     * quando armazenamos um mail, tambem armazenamos a ID com que ele foi guardado
     * no RMS. assim torna-se mais facil elimina-lo do RMS.
     * @param email objecto da classe BaseDeDados de onde vao ser extraidos os dados
     * @return o metodo retorna 'true' se a insercao foi bem sucedida e 'false' se houve um erro
     * qualquer (recordset nao foi aberto ou outra coisa qualquer)
     */
    public boolean inserir(BaseDeDados email) {
        boolean ok = false;
        byte[] mailString = null;
        
        if(bdAberta() && getNumeroRegistos() < MAX_EMAILS) {
            mailString = ("").getBytes();
            
            try {
                int recID = recMails.addRecord(mailString, 0, mailString.length);
                
                mailString = ("<id>" + recID + "</id><de>" + email.getDe() + "</de><assunto>" + email.getAssunto() + "</assunto><data>"
                        + email.getData() + "</data><conteudo>" + email.getConteudo() + "</conteudo>").getBytes();
                recMails.setRecord(recID, mailString, 0, mailString.length);
                
                System.out.println("id: " + recID);
                
                ok = true;
            } catch (RecordStoreException ex) {
                ok = false;
            }
        }
        
        return ok;
    }
    
    /**
     * elimina o registo do mail passado como parametro do RMS.
     *
     * PARA MELHORAR:
     * - utilizar constantes de retorno de erros e sucesso!
     * @param mail objecto da classe BaseDeDados de onde vao ser extraida id do record a eliminar
     * @return 'true' se foi bem sucedido.
     * 'false' se houve um erro
     */
    public boolean eliminar(BaseDeDados mail) {
        boolean ok = false;
        
        try {
            recMails.deleteRecord(mail.getId());
            ok = true;
        } catch (RecordStoreNotOpenException ex) {
            ex.printStackTrace();
        } catch (InvalidRecordIDException ex) {
            ex.printStackTrace();
        } catch (RecordStoreException ex) {
            ex.printStackTrace();
        }
        
        return ok;
    }
    
    /**
     * carrega a lista ligada com o conteudo do RMS
     * @param lista um apontador para os emails a serem armazenados.
     * @return um apontador para o primeiro elemento da lista que contem os emails
     */
    public BaseDeDados carregar(BaseDeDados lista) {
        BaseDeDados bd;
        RecordEnumeration re;
        
        try {
            re = recMails.enumerateRecords(null, null, false);
            
            while (re.hasNextElement()) {
                String tmp = new String(re.nextRecord());
                
                bd = new BaseDeDados();
                
                bd.setId(Integer.parseInt(tmp.substring(tmp.indexOf("<id>") + 4, tmp.indexOf("</id>"))));
                bd.setAssunto(tmp.substring(tmp.indexOf("<assunto>") + 9, tmp.indexOf("</assunto>")));
                bd.setData(tmp.substring(tmp.indexOf("<data>") + 6, tmp.indexOf("</data>")));
                bd.setDe(tmp.substring(tmp.indexOf("<de>") + 4, tmp.indexOf("</de>")));
                bd.setConteudo(tmp.substring(tmp.indexOf("<conteudo>") + 10, tmp.indexOf("</conteudo>")));
                bd.setNovo(false);
                
                bd.prox = lista;
                lista = bd;
            }
        } catch (RecordStoreNotOpenException ex) {
            ex.printStackTrace();
        } catch (RecordStoreException ex) {
            ex.printStackTrace();
        }
        
        return lista;
    }
    
    /**
     * abre o RMS
     */
    public void abrirBD() {
        try {            
            //
            //  tirar esta linha!!!!
            //
            RecordStore.deleteRecordStore(NOME_BD_INFO);
            RecordStore.deleteRecordStore(NOME_BD_MAILS);
            
            recMails = RecordStore.openRecordStore(NOME_BD_MAILS, true);
            recInfo = RecordStore.openRecordStore(NOME_BD_INFO, true);                                    
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    
    /**
     * indica se a BD esta aberta ou nao
     * @return 'true' se o recordset estiver aberto
     * 'false' se nao estiver aberto
     */
    public boolean bdAberta() {
        return (recMails != null && recInfo != null) ? true :false;
    }
    
    /**
     * mostrar o conteudo do RMS
     *
     * SO PARA DEBUG!
     */
    public void verRms() {
        try {
            System.out.println("num registos: " + recMails.getNumRecords());
            
            BaseDeDados bd;
            RecordEnumeration re;
            
            try {
                re = recMails.enumerateRecords(null, null, false);
                
                while (re.hasNextElement()) {
                    String tmp = new String(re.nextRecord());
                    System.out.println(tmp);
                }
            } catch (RecordStoreNotOpenException ex) {
                ex.printStackTrace();
            } catch (RecordStoreException ex) {
                ex.printStackTrace();
            }
        } catch (RecordStoreNotOpenException ex) {
            ex.printStackTrace();
        } catch (RecordStoreException ex) {
            ex.printStackTrace();
        }
    }
    
    /**
     * saca o numero de registos existentes no RMS
     *
     * SO PARA DEBUG
     * @return o numero de records existentes
     */
    public int getNumeroRegistos() {
        int num = -1;
        
        try {
            num = recMails.getNumRecords();
        } catch (RecordStoreNotOpenException ex) {
            ex.printStackTrace();
        }
        
        return num;
    }
    
    /**
     * retorna a data da ultima tentativa de acesso ao email
     * @return String com a data
     */
    public String getUltimoAcesso() {
        String data = null;
        
        try {
            data = new String(recInfo.getRecord(1));
        } catch (RecordStoreNotOpenException ex) {
        } catch (RecordStoreException ex) {
        }
        
        return data;
    }
    
    /**
     * actualiza o registo da utlima data de acesso ao email
     * se nao existir, e criado um novo registo.
     * @param data a nova data
     */
    public void setUltimoAcesso(Date data) {
        SimpleDateFormat sdf = new SimpleDateFormat("EEEE, MMMM d yyyy - H:m:s");
        byte[] str = sdf.format(data).getBytes();
        
        try {
            recInfo.setRecord(1, str, 0, str.length);
        } catch (InvalidRecordIDException ex) {
            try {
                recInfo.addRecord(str, 0, str.length);
            } catch (RecordStoreNotOpenException ex2) {
            } catch (RecordStoreException ex2) {
            }
        } catch (RecordStoreNotOpenException ex) {
        } catch (RecordStoreException ex) {
        }
    }
    
    /**
     * fechar as ligacoes ao RMS
     */
    public void fechar() {
        try {
            recMails.closeRecordStore();
            recInfo.closeRecordStore();
        } catch (RecordStoreNotOpenException ex) {
            ex.printStackTrace();
        } catch (RecordStoreException ex) {
            ex.printStackTrace();
        }
    }

    void apagarDadosUtilizador() {
        throw new UnsupportedOperationException("Not yet implemented");
    }

    void guardarDadosUtilizador(String nu, String pass) {
        throw new UnsupportedOperationException("Not yet implemented");
    }
}
