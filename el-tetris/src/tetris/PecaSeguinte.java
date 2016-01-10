package tetris;

import java.util.Random;
import javax.microedition.lcdui.Image;

public class PecaSeguinte {
    
    public int tipo;
    public int cor;
    
    private Image imgQuadrado;
    public Quadrado quadrados[];
    
    public PecaSeguinte(Image i) {
        imgQuadrado = i;
    }
    
    public void sortear() {
        Random r = new Random();
        
        tipo = r.nextInt(4);
        cor = r.nextInt(5);
        
        criar();
        moverParaCaixa();
    }
    
    private void moverParaCaixa() {
        for(int i = 0; i < Peca.NUMERO_QUADRADOS; i++) {
            quadrados[i].setPosition(quadrados[i].getX() + 95, quadrados[i].getY() + 20);
        }
    }
    
    private void criar() {        
        quadrados = new Quadrado[Peca.NUMERO_QUADRADOS];
        
        switch(tipo) {
            //  a linha
            case Peca.TIPO_PECA_LINHA:
                for(int i = 0; i < Peca.NUMERO_QUADRADOS; i++) {
                    quadrados[i] = new Quadrado(imgQuadrado);
                    quadrados[i].setFrame(cor);
                    
                    quadrados[i].setPosition((9 * i) + 90, 0);
                }
                
                break;
                
                //  a linha que tem uma peça por cima
            case Peca.TIPO_PECA_CORNINHO:
                for(int i = 0; i < Peca.NUMERO_QUADRADOS; i++) {
                    quadrados[i] = new Quadrado(imgQuadrado);
                    quadrados[i].setFrame(cor);
                    
                    if(i == 3) {
                        quadrados[i].setPosition(9 + 90, 0);
                    } else {
                        quadrados[i].setPosition((9 * i) + 90, 9);
                    }
                }
                
                break;
                
                //  a peça que parece uma postola
            case Peca.TIPO_PECA_PISTOLA: {
                for(int i = 0; i < Peca.NUMERO_QUADRADOS; i++) {
                    quadrados[i] = new Quadrado(imgQuadrado);
                    quadrados[i].setFrame(cor);
                    
                    if(i == 3) {
                        quadrados[i].setPosition((9 * (i - 1)) + 90, 9);
                    } else {
                        quadrados[i].setPosition((9 * i) + 90, 0);
                    }
                }
                
                break;
            }
            
            // o quadrado
            case Peca.TIPO_PECA_QUADRADO: {
                for(int i = 0; i < Peca.NUMERO_QUADRADOS; i++) {
                    quadrados[i] = new Quadrado(imgQuadrado);
                    quadrados[i].setFrame(cor);
                    
                    if(i == 0 || i == 1) {
                        quadrados[i].setPosition((9 * i) + 90, 0);
                    } else {
                        quadrados[i].setPosition((9 * (i - 2)) + 90, 9);
                    }
                }
                
                break;
            }
        }
    }
}