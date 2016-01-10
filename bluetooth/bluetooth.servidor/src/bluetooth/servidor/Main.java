package bluetooth.servidor;

import java.io.IOException;

/**
 * main...
 */
public class Main {
    
    /**
     * o ponto de entrada para o programa
     * @param args argumentos da linha de comandos
     */
    public static void main(String[] args) {        
        try {
            new Servidor().iniciar();
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }
}