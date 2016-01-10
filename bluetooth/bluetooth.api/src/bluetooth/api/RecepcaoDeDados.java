package bluetooth.api;

/**
 * tem que ser implementada para se receber dados. e executar accoes de protocolo.
 * @author Ricardo
 */
public interface RecepcaoDeDados {
    
    /**
     * neste metodo e realizada a leitura do stream de dados proveniente do servidor
     */
    public void receberDados();
    
    /**
     * executar uma accao especifica determinada pelo paramentro cmd.
     * as constantes de protocolo estao de definidas na classe Protocolo
     * @param accao a accao a realizar
     * @param msg o resto da mensagem de protocolo. dependendo da accao ela contem diferentes dados
     * @see bluetooth.api.Protocolo.java
     */
    public void executarAccaoProtocolo(int accao, String msg);
    
    /**
     * monitoriza o estado da ligacao de 10 em 10 segundos. quando o estado for 
     * Comunicacoes.ESTADO_DESLIGADO, pesquisa novos servidores bluetooth. se encontrar
     * um, tenta-se nova ligacao.
     */
    public void monitorLigacao();
    
}
