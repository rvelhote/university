package bluetooth.api;

import java.util.Date;

/**
 * Interface para ser implementada em todos os programas que utilizem algum modo
 * de armazenamento de dados.
 * @author ric
 */
public interface Armazenamento {
    /**
     * o nome da base de dados em que sao guardados os dados
     */
    public final String NOME_BD_MAILS = "bmail";    
    /**
     * nome da base de dados onde sera guardada a informacao do utilizador.
     * - ultima data de acesso
     * - nome de utilizador
     * - password
     */
    public final String NOME_BD_INFO = "bmail.info";     
    /**
     * erro a guardar um email na base de dados
     */
    public final int ERRO_A_GUARDAR = 0;
    /**
     * o maximo numero de emails que e permitido guardar pela base de dados foi atingido
     */
    public final int ERRO_MAX_MAILS = 1;        
    
    /**
     * insere um registo numa base de dados
     * @param mail o objecto do tipo BaseDeDados de onde vai ser extraida a informacao necessaria
     * ao armazenamento de e-mails
     * @return 'true' se o armazenamento foi bem sucedido
     * 'false' se o armazenamento falhou
     */
    public boolean inserir(BaseDeDados mail);
    
    /**
     * eliminar um registo da base de dados
     * @param mail objecto de onde vai ser retirada a informacao necessaria para eliminar o mail
     * da base de dados
     * @return 'true' se a eliminacao foi bem sucedida
     * 'false' se a eliminacao falhou
     */
    public boolean eliminar(BaseDeDados mail);
    
    /**
     * carregar uma lista ligada com os armazenados numa qualquer base de dados
     * @param lista onde vao ser carregados os dados.
     * @return o primeiro elemento da lista onde os dados foram carregados
     */
    public BaseDeDados carregar(BaseDeDados lista);
    
    /**
     * verifica se a base de dados esta aberta para utilizacao ou nao
     * @return true -> a(s) base de dados esta aberta
     * false -> nao esta aberta
     */
    public boolean bdAberta();
    
    /**
     * retorna uma string com a data da tentativa do ultimo acesso ao mail no servidor
     * @return um string com a data formatada de uma forma especifica
     */
    public String getUltimoAcesso();
    
    /**
     * guarda na base de dados a ultima data de acesso ao email
     * @param data a nova data
     */
    public void setUltimoAcesso(Date data);
    
    /**
     * fechar as ligacoes a base de dados
     */
    public void fechar();
    
    
}
