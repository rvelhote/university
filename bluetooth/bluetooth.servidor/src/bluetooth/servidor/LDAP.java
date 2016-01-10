package bluetooth.servidor;

import java.io.Serializable;
import java.util.Properties;
import javax.naming.Context;
import javax.naming.NamingException;
import javax.naming.directory.DirContext;
import javax.naming.directory.InitialDirContext;

/**
 * contem o metodo que autentica um utilizador num servidor LDAP
 */
public class LDAP {
    
    private final String ldapServerName = "localhost";
    private final String rootdn = "cn=admin,dc=bluetooth,dc=ispgaya,dc=pt";
    private final String rootpass = "secret";
    private final String rootContext = "dc=bluetooth,dc=ispgaya,dc=pt";
    
    private DirContext ctx = null;
    
    /**
     * faz a autenticacao
     * @param username o nome de utilizador a ser autenticado
     * @param password a password de acesso
     * @return Protocolo.OK_AUTENTICACAO_OK -> foi autenticado com sucesso
     * Protocolo.ERRO_AUTENTICACAO_FALHOU -> falhou a autenticacao
     */
    public int autenticar(String username, String password) {
        int loginOk = Protocolo.ERRO_AUTENTICACAO_FALHOU;
        
        if(ctx != null) {            
            try {
                Utilizador u = (Utilizador) ctx.lookup("cn=" + username);
                
                if(u.password.compareTo(password) == 0 && u.username.compareTo(username) == 0 ) {
                    loginOk = Protocolo.OK_AUTENTICACAO_OK;
                }
            } catch (NamingException ex) {
                ex.printStackTrace();
            }
        }
        
        return loginOk;
    }        
    
    public void adicionarUtilizador(String username, String password) {
        if(ctx != null) {            
            Utilizador utilizador = new Utilizador();
            
            utilizador.username = username;
            utilizador.password = password;
            
            try {
                ctx.bind("cn=" + username, utilizador);
            } catch (NamingException ex) {
                ex.printStackTrace();
            }
        }
        
    }
    
    public void ligar() {
        if(ctx == null) {
            Properties env = new Properties();
            
            env.put(Context.INITIAL_CONTEXT_FACTORY, "com.sun.jndi.ldap.LdapCtxFactory");
            env.put(Context.PROVIDER_URL, "ldap://" + ldapServerName + "/" + rootContext);
            env.put(Context.SECURITY_PRINCIPAL, rootdn);
            env.put(Context.SECURITY_CREDENTIALS, rootpass);
            
            try {
                ctx = new InitialDirContext(env);
            } catch (NamingException ex) {
                ex.printStackTrace();
            }
        }
    }
    
    public void removerUtilizador(String username) {
        if(ctx != null) {
            
        }
    }
}

class Utilizador implements Serializable {
    String password;
    String username;
}

