package bluetooth.api;

/**
 * contem as constantes de protocolo e metodos de construcao de mensagens de protocolo
 * e de extraccao de dados de uma mensagem de protocolo.
 *
 * estrutura do protocolo.
 *
 * - o primeiros 2 bytes correspondem a accao a realizar
 * - o resto e um 'XML' que depende da accao a realizar
 *
 * se estivermos a fazer uma autenticacao a mensagem de protocolo seria a seguinte:
 * 5<username>x</username><password>y</password>
 *
 * 5 corresponde a Protocolo.OP_AUTENTICACAO.
 *
 * o inicio do nome das constante indica o tipo de mensagem de protocolo:
 * - ERRO_* >> um erro qualquer ocorreu
 * - OK_* >> a accao foi bem sucedida
 * - OP_* >> indica que esta a ser realizada uma operacao e nao algo que ja esta a ser retornado
 * como acontece com as constantes OK_* e OP_*
 *
 * as unicas mensagens que o cliente deve enviar sao as de OP_*
 * ERRO_* e OK_* sao apenas mensagens de retorno do servidor
 * @author Ricardo
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
     * pega na string de protocolo e saca os dados dos mails que o servidor enviou.
     *
     * os dados sao enviados pelo servidor num formato do tipo XML. por exemplo:
     * <assunto></assunto> indica que aqui dentro esta o assunto do mail
     *
     * os dados sao depois colocados num array do tipo BaseDeDados e retornados a midlet
     * onde se procede a listagem de mails.
     * @param strProtocolo a string de protocolo que contem os dados
     * @param primeiro apontador para o primeiro elemento da lista.
     * @return um apontador para o primeiro elemento da lista ligada que contem os emails
     */
    public static BaseDeDados extrairMails(String strProtocolo, BaseDeDados primeiro) {
        String tmp;
        BaseDeDados bd;

        while(true) {
            int inicioMail = strProtocolo.indexOf("<mail>");
            int fimMail = strProtocolo.indexOf("</mail>") + 7;
                        
            //  nao ha mais mails.            
            if(inicioMail == -1) {
                break;
            }
            
            tmp = strProtocolo.substring(inicioMail, fimMail);
            
            bd = new BaseDeDados();
            
            bd.setAssunto(tmp.substring(tmp.indexOf("<assunto>") + 9, tmp.indexOf("</assunto>")));
            bd.setData(tmp.substring(tmp.indexOf("<data>") + 6, tmp.indexOf("</data>")));
            bd.setDe(tmp.substring(tmp.indexOf("<enviado>") + 9, tmp.indexOf("</enviado>")));
            bd.setConteudo(tmp.substring(tmp.indexOf("<conteudo>") + 10, tmp.indexOf("</conteudo>")));
            bd.setNovo(true);
            
            //  lidar com os anexos, se houver
            int inicioAnexo = tmp.indexOf("<anexos>");
            int fimAnexo = tmp.indexOf("</anexos>") + 9;
            
            if(inicioAnexo != -1) {
                String tmpAnexo = tmp.substring(inicioAnexo, fimAnexo);
                int qtAnexos = Integer.parseInt(tmpAnexo.substring(tmpAnexo.indexOf("<qt>") + 4, tmpAnexo.indexOf("</qt>")));                
                
                bd.anexos = new Anexo[qtAnexos];
                
                for(int i = 0; i < bd.anexos.length; i++) {
                    bd.anexos[i] = new Anexo();
                    
                    bd.anexos[i].setNomeAnexo(tmpAnexo.substring(tmpAnexo.indexOf("<nome>") + 6, tmpAnexo.indexOf("</nome>")));                                                            
                    bd.anexos[i].setTamanhoAnexo(Integer.parseInt(tmpAnexo.substring(tmpAnexo.indexOf("<tam>") + 5, tmpAnexo.indexOf("</tam>"))));
                    
                    tmpAnexo = tmpAnexo.substring(tmpAnexo.indexOf("</tam>") + 5, tmpAnexo.length());
                }
                
            }
            
            bd.prox = primeiro;
            primeiro = bd;
            
            strProtocolo = strProtocolo.substring(fimMail, strProtocolo.length());
        }
        
        return primeiro;
    }
    
    /**
     * a accao de protocolo a realizar.
     * @return retorna um inteiro correspondente a uma das constates em cima
     * @param strProtocolo a string de protocolo de onde sera retirada a accao
     */
    public static int getAccao(String strProtocolo) {
        int cod = INVALIDO;
        
        try {
            cod =Integer.parseInt(strProtocolo.substring(0, 2));
        } catch(NumberFormatException ex) {            
            cod = INVALIDO;
        } finally {
            return cod;
        }
    }
    
    /**
     * controi a mensagem de protocolo correspondente a autenticacao
     * @param nomeUtilizador nome de utilizador a incluir na msg de protocolo
     * @param password a password a incluir na msg de protocolo
     * @return a string de protocolo formada
     */
    public static String autenticar(String nomeUtilizador, String password) {
        return String.valueOf(OP_AUTENTICACAO) + "<username>" + nomeUtilizador + "</username><password>" + password + "</password>";
    }
    
    /**
     * controi a mensagem de protocolo correspondente a buscar o mail
     * @param dataUltimoMail a data da ultima vez que verificamos o mail.
     * pode ser null ou uma String com a data num formato especifico.
     *
     * null quer dizer para retornar todos os email
     * uma data, significa que o servidor so vai retornar os email que foram recebidos
     * a partir dessa data.
     * @return a string de protocolo formada
     */
    public static String buscarMail(String dataUltimoMail) {
        String restoProtocolo = "";
        
        if(dataUltimoMail != null) {
            restoProtocolo = "<data>" + dataUltimoMail + "</data>";
        }
        
        return String.valueOf(OP_BUSCAR_MAIL) + restoProtocolo;
    }
    
    /**
     * controi a mensagem de protocolo correspondente enviar o mail
     * @param para para que vai ser enviado o email
     * @param assunto o assunto do email
     * @param texto o texto do email
     * @return a string de protocolo formada
     */
    public static String enviarMail(String para, String assunto, String texto) {
        return String.valueOf(OP_ENVIAR_MAIL) + "<assunto>" + assunto + "</assunto><para>" + para + "</para><conteudo>" + texto + "</conteudo>";
    }
    
    /**
     * controi a mensagem de protocolo correspondente a terminar de sessao
     * @return a string de protocolo formada
     */
    public static String logout() {
        return String.valueOf(OP_LOGOUT);
    }
}