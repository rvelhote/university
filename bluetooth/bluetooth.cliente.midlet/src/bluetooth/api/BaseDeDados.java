/*
 * BaseDeDados.java
 *
 * Created on 30 de Junho de 2006, 14:27
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package bluetooth.api;

/**
 * classe onde e armazenado a informacao individual de cada e-mail recebido
 *
 * contem metodos estaticos que retornam apontadores para um elemento qualquer
 * @author Ricardo
 */
public class BaseDeDados {
    
    /**
     * o email de quem enviou
     * 
     * Tag:
     * <de></de>
     */
    private String de;    
    /**
     * o assunto do e-mail
     * 
     * Tag:
     * <assunto></assunto>
     */
    private String assunto;
    /**
     * a data de envio do email
     * 
     * Tag:
     * <data></data>
     */
    private String data;
    /**
     * conteudo do mail
     * 
     * Tag:
     * <conteudo></conteudo>
     */
    private String conteudo;
    /**
     * id do e-mail de acordo com o RMS
     * 
     * <id></id>
     */
    private int id = -1;
            
    /**
     * um apontador para o elemento seguinte da lista
     */
    public BaseDeDados prox;
    
    /**
     * indica se o mail e novo ou nao. se for novo, esse email devera ser salientado
     * em relacao aos que nao sao novos
     */
    private boolean novo;    
    public Anexo[] anexos;
    
    
    
    
    
    /**
     * Construtor
     */
    public BaseDeDados() {
        prox = null;
    }

    /**
     * retorna o valor do atributo 'de'.
     * de = quem enviou o mail
     * @return retorna o atributo 'De'
     */
    public String getDe() {
        return de;
    }
    
    /**
     * retorna o valor do atributo 'assunto'.
     * assunto = assunto do email
     * @return o assunto do email
     */
    public String getAssunto() {
        return assunto;
    }
    
    /**
     * retorna o valor do atributo 'data'.
     * data = data do envio do e-mail
     * @return a data em que o email foi enviado
     */
    public String getData() {
        return data;
    }
    
    /**
     * retorna o valor do atributo 'conteudo'.
     * conteudo = a mensagem do email
     * @return retorna o conteudo do email
     */
    public String getConteudo() {
        return conteudo;
    }
    
    /**
     * coloca a string passada como parametro no atributo 'de'
     * @param de o novo valor
     */
    public void setDe(String de) {
        this.de = de;
    }
    
    /**
     * coloca a string passada como parametro no atributo 'assunto'
     * @param assunto o novo valor
     */
    public void setAssunto(String assunto) {
        this.assunto = assunto;
    }
    
    /**
     * coloca a string passada como parametro no atributo 'data'
     * @param data o novo valor
     */
    public void setData(String data) {
        this.data = data;
    }
    
    /**
     * coloca a string passada como parametro no atributo 'conteudo'
     * @param conteudo o novo valor
     */
    public void setConteudo(String conteudo) {
        this.conteudo = conteudo;
    }
    
    /**
     * retorna o valor do atributo 'id'.
     * id = a id do email no RMS
     * @return a id do email.
     */
    public int getId() {
        return id;
    }
    
    /**
     * coloca uma nova id
     * @param id o novo valor
     */
    public void setId(int id) {
        this.id = id;
    }
        
    /**
     * indica se o mail seleccionado e novo ou nao
     * @return true -> novo
     * false -> nao e novo
     */
    public boolean isNovo() {
        return novo;
    }

    /**
     * modifica a flag 'novo'
     * @param novo o novo estado do email
     */
    public void setNovo(boolean novo) {
        this.novo = novo;
    }
    
    /**
     * pesquisa na lista o elemento que esta numa determinada posicao.
     * a posicao diz respeito a ordem da lista. o primeiro elemento e a posicao 0,
     * o segundo a posicao 1 e assim sucessivamente
     * @param pos a posicao do elemento da lista que queremos pesquisar.
     * @param lista a lista onde vai ser efectuada a pesquisa
     * @return retorna um apontador para o elemento que esta na posicao escolhida
     */
    public static BaseDeDados getElementoNaPosicao(int pos, BaseDeDados lista) {
        int contaPosicao = 0;
        
        while(lista != null) {
            if(pos == contaPosicao) {
                break;
            }
            
            lista = lista.prox;
            contaPosicao++;
        }
        
        return lista;
    }

    
    /**
     * saber o tamanho da lista
     * @param lista a lista que queremos avaliar
     * @return o numero de nos presentes na lista
     */
    public static int getTamanhoLista(BaseDeDados lista) {
        int contador = 0;
        
        while(lista != null) {
            lista = lista.prox;
            contador++;
        }
        
        return contador;
    }
    
    /**
     * saber a data do email que esta na primeira posicao da lista.
     * utilizado para informar o servidor a partir de que data pode retornar emails
     * @param lista a lista onde vai ser feita a pesquisa
     * @return a data do email
     */
    public static String getDataMaisRecente(BaseDeDados lista) {
        String data = null;
        
        if(lista != null) {
            data = lista.getData();
        }
        
        return data;
    }
    
    /**
     * elmina um no da lista
     * @param lista a lista onde vai ser feita a eliminacao
     * @param paraEliminar um apontador para o elemento a eliminar
     * @return um apontador para o primeiro elemento da lista. pode ocorrer a situacao de o
     * no que queremos eliminar ser o primeiro da lista!
     */
    public static BaseDeDados eliminarRegisto(BaseDeDados lista, BaseDeDados paraEliminar) {
        if(lista == paraEliminar) {
            lista = lista.prox;
        } else {
            BaseDeDados percorre = lista;
            
            while(percorre != null) {
                if(percorre.prox == paraEliminar) {
                    if(paraEliminar.prox == null) {
                        percorre.prox = null;
                    } else {
                        percorre.prox = paraEliminar.prox;
                    }
                    
                    break;
                }
                
                percorre = percorre.prox;
            }
        }
        
        return lista;
    }        
}

