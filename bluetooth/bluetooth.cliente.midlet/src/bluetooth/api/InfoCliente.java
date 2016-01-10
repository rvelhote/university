package bluetooth.api;

/**
 * contem metodos de retorno de informacao acerca do cliente actual
 * @author ric
 */
public class InfoCliente {
        
    /**
     * nome de utilizador
     */
    private String nomeUtilizador;
    /**
     * a password
     */
    private String password;    
    
    /**
     * indica que o cliente nao esta autenticado no servidor.
     * isto impossibilita-o de enviar ou receber mails mesmo que exista uma ligacao
     * activa ao servidor
     */
    public int NAO_AUTENTICADO = 0;
    /**
     * o cliente ja foi autenticado no servidor e pode enviar e receber mails
     */
    public int AUTENTICADO = 1;
    
    /**
     * indica o estado de autenticacao do utilizador (sim ou nao :P)
     */
    private int estado = NAO_AUTENTICADO;
    
    /**
     * coloca o estado actua
     * @param novoEstado o novo estado
     */
    public void setEstado(int novoEstado) {
        estado = novoEstado;
    }
    
    /**
     * retorna o estado actual
     * @return o estado do utilizador (AUTENTICADO || NAO_AUTENTICADO)
     */
    public int getEstado() {
        return estado;
    }
    
    /**
     * indica se o utilizador esta autenticado no servidor
     * @return o estado de autenticacao
     */
    public boolean estaAutenticado() {
        return (estado == AUTENTICADO) ? true : false;
    }
    
    /**
     * seta o nome de utilizador.
     * @param nu o nome de utilizador
     */
    public void setNomeUtilizador(String nu) {
        nomeUtilizador = nu;
    }
    
    /**
     * seta o nome de utilizador.
     * @param pass a nova password
     */
    public void setPassword(String pass) {
        password = pass;
    }
    
    /**
     * saca a password
     * @return a password
     */
    public String getPassword() {
        return password;
    }
    
    /**
     * saca o nome de utilizador.
     * @return no nome de utilizador
     */
    public String getNomeUtilizador() {
        return nomeUtilizador;
    }
}
