package bluetooth.servidor;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import javax.bluetooth.RemoteDevice;
import javax.microedition.io.StreamConnection;

/**
 * contem informacao sobre cada cliente ligado ao servidor
 */
public class Cliente {
    /**
     * o nome do dispositivo bluetooth
     */
    private String nomeBluetooth;
    /**
     * o endereco fisico do dispositivo
     */
    private String enderecoBluetooth;
    
    /**
     * o nome de utilizador que esta a ser utilizado.
     * ex: ric hfpsoares
     * 
     * utilizado para sacar os mails do servidor (POP3)
     */
    private String nomeUtilizador;
    /**
     * o email a ser utilizado.
     * ex: ric@ispgaya.pt hfpsoares.ispgaya.pt
     * 
     * utilizado para enviar mails (SMTP)
     */
    private String nomeMail;
    /**
     * a password de autenticacao
     */
    private String password;
    
    /**
     * o dispositivo remoto
     */
    private RemoteDevice dispRemoto;
    /**
     * o stream de entrada de dados
     */
    private DataInputStream inputStream;
    /**
     * o stream de saida de dados
     */
    private DataOutputStream outputStream;
    /**
     * o stream de ligacao
     */
    private StreamConnection stream;
    
    /**
     * indica se o cliente esta ligado ou nao
     */
    private boolean ligado = true;
    private int classeDispositivo;
    
    /**
     * a chave de encriptacao utilizada por este utilizador
     */
    private byte[] key = "892urhuiefwb00234390jr3rj2390rrj".getBytes();
    
    public void setNomeBluetooth(String nomeBluetooth) {
        this.nomeBluetooth = nomeBluetooth;
    }
    
    public String getNomeBluetooth() {
        return nomeBluetooth;
    }
    
    public void setEnderecoBluetooth(String enderecoBluetooth) {
        this.enderecoBluetooth = enderecoBluetooth;
    }
    
    public String getEnderecoBluetooth() {
        return enderecoBluetooth;
    }
    
    public void setDispRemoto(RemoteDevice dispRemoto) {
        this.dispRemoto = dispRemoto;
    }
    
    public RemoteDevice getDispRemoto() {
        return dispRemoto;
        
    }
    
    public void setInputStream(DataInputStream inputStream) {
        this.inputStream = inputStream;
    }
    
    public DataInputStream getInputStream() {
        return inputStream;
    }
    
    public void setOutputStream(DataOutputStream outputStream) {
        this.outputStream = outputStream;
    }
    
    public DataOutputStream getOutputStream() {
        return outputStream;
    }
    
    public String getNomeUtilizador() {
        return nomeUtilizador;
    }
    
    public String getPassword() {
        return password;
    }
    
    public String getNomeMail() {
        return nomeMail;
    }
    
    public void setNomeMail(String nomeMail) {
        this.nomeMail = nomeMail;
    }
    
    public void setPassword(String password) {
        this.password = password;
    }
    
    public void setNomeUtilizador(String nomeUtilizador) {
        this.nomeUtilizador = nomeUtilizador;
    }
    
    public StreamConnection getStream() {
        return stream;
    }
    
    public void setStream(StreamConnection stream) {
        this.stream = stream;
    }
    
    /**
     * indica se o cliente esta ligado ao servidor
     * @return true -> esta ligado
     * false -> nao esta ligado
     */
    public boolean isLigado() {
        return ligado;
    }
    
    /**
     * coloca o novo estado de ligacao
     * @param ligado o novo estado
     */
    public void setLigado(boolean ligado) {
        this.ligado = ligado;
    }
    
    /**
     * enviar dados para o dispositivo deste cliente atraves do stream de saida de dados
     * @param msg a mensagem a enviar
     */
    public void enviarDados(String msg) {
        try {
            getOutputStream().writeUTF(Seguranca.encriptar(msg, getKey()));
        } catch(IOException e) {
            e.printStackTrace();
        }
    }
    
    /**
     * desliga o cliente do servidor, fechando os streams de comunicacao
     */
    public void desligar() {
        try {
            getOutputStream().close();
            getInputStream().close();
            getStream().close();
        } catch (IOException ex) {
            //ex.printStackTrace();
        }
    }
    
    /**
     * retorna a chave de encriptacao utilizada por este utilizador
     * @return byte[]
     */
    public byte[] getKey() {
        return key;
    }
    
    /**
     * atribui uma chave de encriptacao a este utilizador
     * @param key a nova chave
     */
    public void setKey(byte[] key) {
        this.key = key;
    }
        
    public int getClasseDispositivo() {
        return classeDispositivo;
    }

    public void setClasseDispositivo(int classeDispositivo) {
        this.classeDispositivo = classeDispositivo;
    }
    
    public String getNomeClasseDispositivo(int tipo) {
        String designacao;
        
        if(tipo == 256) {
            designacao = "Computador";
        } else if(tipo == 512) {
            designacao = "Telefone";
        } else if(tipo == 768) {
            designacao = "LAN/Network Access Point";
        } else {
            designacao = "Outro";
        }

        return designacao;
    }
}