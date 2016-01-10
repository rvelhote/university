package bluetooth.servidor;

import java.io.UnsupportedEncodingException;
import java.security.SecureRandom;
import org.bouncycastle.crypto.CryptoException;
import org.bouncycastle.crypto.engines.AESFastEngine;
import org.bouncycastle.crypto.modes.CBCBlockCipher;
import org.bouncycastle.crypto.paddings.PaddedBufferedBlockCipher;
import org.bouncycastle.crypto.params.KeyParameter;
import org.bouncycastle.util.encoders.Base64;

/**
 * Contem os metodos de Encriptacao, Desencriptacao e Geracao de chavee...
 * @author ric, hfpsoares
 * @version 0.1
 * @since 29 de Junho 2006
 */
public class Seguranca {
    /**
     * a chave de encriptacao do utilizador
     */
    private static byte[] key = null;
    /**
     * indica que a operacao a realizar e uma encriptacao
     */
    private static int OP_ENCRIPTAR = 0;
    /**
     * indica que a operacao a realizar e uma desencriptacao
     */
    private static int OP_DESENCRIPTAR = 1;    
    
    /**
     * nova chave.
     *
     * so podemos colocar uma vez.
     * @param k a chave de encriptacao a colocar
     */
    public static void setKey(byte[] k) {
        if(key == null) {
            key = k;
        }
    }
    
    /**
     * retorna a chave de encriptacao do utilizador
     * @return byte[] com a chave
     */
    public static byte[] getKey() {
        return key;
    }
    
    /**
     * Gera uma chave aleatoria baseada no tipo passado como parametro
     * @param tipo o numero de bits a utilizar. valores possiveis: 128, 192, 256
     * @return retorna a chave criada...
     */
    public static byte[] gerarChave(int tipo) {
        byte[] chave = new byte[tipo >> 4];
        
        SecureRandom sr = new SecureRandom();
        sr.nextBytes(chave);
        
        return chave;
    }
    
    /**
     * como a diferenca entre os metodos encriptar a desencriptar e apenas um true ou 
     * false, fica tudo aqui metido...
     * @param paraTratar os bytes a tratar
     * @param chave a chave a utilizar nas operacoes
     * @param tipo o tipo de operacao a realizar
     * 
     * Seguranca.OP_ENCRIPTAR - encripta informacao    
     * Seguranca.OP_DESENCRIPTAR - desencripta a informacao
     * @return retorna os bytes de informacao tradados (encriptados ou desencriptados)
     */
    private static byte[] tratar(byte[] paraTratar, byte[] chave, int tipo) {
        byte[] dadosTratados = null;
        boolean op = (tipo == OP_ENCRIPTAR) ? true : false;
        
        if(chave == null) {
            System.out.println("nao ha uma chave");
            return null;
        }
        
        PaddedBufferedBlockCipher cipher = new PaddedBufferedBlockCipher(new CBCBlockCipher(new AESFastEngine()));
        cipher.init(op, new KeyParameter(chave));
        
        dadosTratados = new byte[cipher.getOutputSize(paraTratar.length)];
        int tamanhoDados = cipher.processBytes(paraTratar, 0, paraTratar.length, dadosTratados, 0);
        
        try {
            cipher.doFinal(dadosTratados, tamanhoDados);
        } catch (CryptoException ce) {
        }
        
        return dadosTratados;
    }
    
    /**
     * Encripta a informacao passada como parametro.
     * @param paraEncriptar o texto a encriptar
     * @param chave a chave a utilizar na encriptacao
     * @return a texto encriptado
     */
    public static String encriptar(String paraEncriptar, byte[] chave) {
        String stringEncriptada = null;
        
        try {
            byte[] encriptado = tratar(paraEncriptar.getBytes("UTF-8"), chave, OP_ENCRIPTAR);
            stringEncriptada =  new String(Base64.encode(encriptado), "UTF-8").trim();
        } catch (UnsupportedEncodingException ex) {
            ex.printStackTrace();
        }
        
        return stringEncriptada;
    }
    
    /**
     * desencripta a informacao passada como parametro!
     * @param paraDesencriptar a informacao a desencriptar
     * @param chave a chave a utilizar na desencritacao
     * @return a informacao desencriptada
     */
    public static String desencriptar(String paraDesencriptar, byte[] chave) {
        String stringDesencriptada = null;
        byte[] desencriptar = Base64.decode(paraDesencriptar);
        
        try {                    
            stringDesencriptada = new String(tratar(desencriptar, chave, OP_DESENCRIPTAR), "UTF-8").trim();
        } catch (UnsupportedEncodingException ex) {
            ex.printStackTrace();
        }
        
        return stringDesencriptada;
    }
}
