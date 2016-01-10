package tetris;

import java.io.IOException;
import java.util.Random;
import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.game.TiledLayer;

public class Peca {
    public static final int MOVIMENTO_PECA = 9;
    public static final int NUMERO_QUADRADOS = 4;
    
    public static final int TIPO_PECA_LINHA = 0;
    public static final int NUM_ROT_TIPO_PECA_LINHA = 1;
    
    public static final int TIPO_PECA_PISTOLA = 1;
    public static final int NUM_ROT_TIPO_PECA_PISTOLA = 3;
    
    public static final int TIPO_PECA_CORNINHO = 2;
    public static final int NUM_ROT_TIPO_PECA_CORNINHO = 3;
    
    public static final int TIPO_PECA_QUADRADO = 3;
    public static final int NUM_ROT_TIPO_PECA_QUADRADO = 0;
    
    public Quadrado quadrados[];
    public int tipoPeca;
    
    int numRotacao = 0;
    private Image imgQuadrado;
    
    public static int getNumRotacoes(int tipo) {
        int n;
        
        switch(tipo) {
            case 0:
                n = NUM_ROT_TIPO_PECA_LINHA;
                break;
                
            case 1:
                n = NUM_ROT_TIPO_PECA_PISTOLA;
                break;
                
            case 2:
                n = NUM_ROT_TIPO_PECA_CORNINHO;
                break;
                
            case 3:
                n = NUM_ROT_TIPO_PECA_QUADRADO;
                break;
                
            default:
                n = 0;
        }
        
        return n;
    }
    
    public Peca(Image i) {
        imgQuadrado = i;
    }
    
    public void criarPeca(int tipo, int cor) {
        quadrados = new Quadrado[Peca.NUMERO_QUADRADOS];
        tipoPeca = tipo;
        numRotacao = 0;
        
        switch(tipoPeca) {
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
    
    public void desce() {
        for(int i = 0; i < Peca.NUMERO_QUADRADOS; i++) {
            quadrados[i].setPosition(quadrados[i].getX(), quadrados[i].getY() + Peca.MOVIMENTO_PECA);
        }
    }
    
    public void desceDepressa() {
        for(int i = 0; i < Peca.NUMERO_QUADRADOS; i++) {
            quadrados[i].setPosition(quadrados[i].getX(), quadrados[i].getY() + Peca.MOVIMENTO_PECA);
        }
    }
    
    public void moveEsquerda() {
        for(int i = 0; i < Peca.NUMERO_QUADRADOS; i++) {
            if(quadrados[i].getX() <= 9) {
                return;
            }
        }
        
        if(quadrados[0].getX() > 9) {
            for(int i = 0; i < Peca.NUMERO_QUADRADOS; i++) {
                quadrados[i].setPosition(quadrados[i].getX() - Peca.MOVIMENTO_PECA, quadrados[i].getY());
            }
        }
    }
    
    public void moveDireita() {
        for(int i = 0; i < Peca.NUMERO_QUADRADOS; i++) {
            if(quadrados[i].getX() + quadrados[i].getWidth() >= 151) {
                return;
            }
        }
        
        for(int i = 0; i < Peca.NUMERO_QUADRADOS; i++) {
            quadrados[i].setPosition(quadrados[i].getX() + Peca.MOVIMENTO_PECA, quadrados[i].getY());
        }
    }
    
    public boolean podeRodar(int xFuturo) {
        if(xFuturo < 9 || xFuturo > 151) {
            numRotacao--;
            return false;
        }
        
        return true;
    }
    
    public void rodar() {
        if(numRotacao == getNumRotacoes(tipoPeca)) {
            numRotacao = 0;
        } else {
            numRotacao++;
        }
        
        switch(tipoPeca) {
            //  a linha
            case Peca.TIPO_PECA_LINHA:
                
                switch(numRotacao) {
                    case 0:
                        if(podeRodar(quadrados[0].getX() - 18) && podeRodar(quadrados[0].getX() + (9)) && podeRodar(quadrados[0].getX() + (9 * 2)) && podeRodar(quadrados[0].getX() + (9 * 3)))  {
                            quadrados[0].setPosition(quadrados[0].getX() - 18, quadrados[0].getY() + 18);
                            
                            for(int i = 1; i < Peca.NUMERO_QUADRADOS; i++) {
                                quadrados[i].setPosition(quadrados[0].getX() + (9 * i), quadrados[0].getY());
                            }
                        }
                        
                        break;
                        
                    case 1:
                        quadrados[0].setPosition(quadrados[0].getX() + 18, quadrados[0].getY() - 18);
                        
                        for(int i = 1; i < Peca.NUMERO_QUADRADOS; i++) {
                            quadrados[i].setPosition(quadrados[0].getX(), quadrados[0].getY() + (9 * i));
                        }
                        
                        break;
                }
                
                break;
                
                //  a linha que tem uma peça por cima
            case Peca.TIPO_PECA_CORNINHO:
                
                switch(numRotacao) {
                    case 0:
                        
                        if(podeRodar(quadrados[0].getX() - 9) && podeRodar(quadrados[2].getX() + 9) && podeRodar(quadrados[3].getX() + 9)) {
                            
                            quadrados[0].setPosition(quadrados[0].getX() - 9, quadrados[0].getY() - 9);
                            quadrados[2].setPosition(quadrados[2].getX() + 9, quadrados[2].getY() + 9);
                            quadrados[3].setPosition(quadrados[3].getX() + 9, quadrados[3].getY() - 9);
                        }
                        
                        break;
                        
                    case 1:
                        
                        if(podeRodar(quadrados[0].getX() + 9) && podeRodar(quadrados[2].getX() - 9) && podeRodar(quadrados[3].getX() + 9)) {
                            
                            quadrados[0].setPosition(quadrados[0].getX() + 9, quadrados[0].getY() - 9);
                            quadrados[2].setPosition(quadrados[2].getX() - 9, quadrados[2].getY() + 9);
                            quadrados[3].setPosition(quadrados[3].getX() + 9, quadrados[3].getY() + 9);
                        }
                        
                        break;
                        
                    case 2:
                        
                        if(podeRodar(quadrados[0].getX() + 9) && podeRodar(quadrados[2].getX() - 9) && podeRodar(quadrados[3].getX() - 9)) {
                            
                            quadrados[0].setPosition(quadrados[0].getX() + 9, quadrados[0].getY() + 9);
                            quadrados[2].setPosition(quadrados[2].getX() - 9, quadrados[2].getY() - 9);
                            quadrados[3].setPosition(quadrados[3].getX() - 9, quadrados[3].getY() + 9);
                        }
                        
                        break;
                        
                    case 3:
                        
                        if(podeRodar(quadrados[0].getX() - 9) && podeRodar(quadrados[2].getX() + 9) && podeRodar(quadrados[3].getX() - 9)) {
                            
                            quadrados[0].setPosition(quadrados[0].getX() - 9, quadrados[0].getY() + 9);
                            quadrados[2].setPosition(quadrados[2].getX() + 9, quadrados[2].getY() - 9);
                            quadrados[3].setPosition(quadrados[3].getX() - 9, quadrados[3].getY() - 9);
                        }
                        break;
                }
                
                break;
                
                
                //  a peça que parece uma postola
            case Peca.TIPO_PECA_PISTOLA: {
                switch(numRotacao) {
                    case 0:
                        
                        if(podeRodar(quadrados[0].getX() - 9) && podeRodar(quadrados[1].getX()) && podeRodar(quadrados[2].getX() + 9) && podeRodar(quadrados[2].getX() + 9)) {
                            
                            quadrados[0].setPosition(quadrados[0].getX() - 9, quadrados[0].getY() - 18);
                            quadrados[1].setPosition(quadrados[1].getX(), quadrados[1].getY() - 9);
                            quadrados[2].setPosition(quadrados[2].getX() + 9, quadrados[2].getY());
                            quadrados[3].setPosition(quadrados[3].getX(), quadrados[3].getY() + 9);
                        }
                        
                        break;
                        
                    case 1:
                        if(podeRodar(quadrados[0].getX() + 18) && podeRodar(quadrados[1].getX() + 9) && podeRodar(quadrados[3].getX() - 9)) {
                            
                            quadrados[0].setPosition(quadrados[0].getX() + 18, quadrados[0].getY() - 18);
                            quadrados[1].setPosition(quadrados[1].getX() + 9, quadrados[1].getY() - 9);
                            quadrados[3].setPosition(quadrados[3].getX() - 9, quadrados[3].getY() - 9);
                        }
                        
                        break;
                        
                    case 2:
                        
                        if(podeRodar(quadrados[0].getX() + 9) && podeRodar(quadrados[1].getX()) && podeRodar(quadrados[2].getX() - 9) && podeRodar(quadrados[3].getX())) {
                            
                            quadrados[0].setPosition(quadrados[0].getX() + 9, quadrados[0].getY() + 18);
                            quadrados[1].setPosition(quadrados[1].getX(), quadrados[1].getY() + 9);
                            quadrados[2].setPosition(quadrados[2].getX() - 9, quadrados[2].getY());
                            quadrados[3].setPosition(quadrados[3].getX(), quadrados[3].getY() - 9);
                        }
                        
                        break;
                        
                    case 3:
                        if(podeRodar(quadrados[0].getX() - 18) && podeRodar(quadrados[1].getX() - 9) && podeRodar(quadrados[2].getX()) && podeRodar(quadrados[3].getX() + 9)) {
                            
                            quadrados[0].setPosition(quadrados[0].getX() - 18, quadrados[0].getY() + 9);
                            quadrados[1].setPosition(quadrados[1].getX() - 9, quadrados[1].getY());
                            quadrados[2].setPosition(quadrados[2].getX(), quadrados[2].getY() - 9);
                            quadrados[3].setPosition(quadrados[3].getX() + 9, quadrados[3].getY());
                        }
                        
                        break;
                }
                
                break;
            }
        }
    }
    
    public boolean colidiu(TiledLayer tile) {
        boolean colide = false;
        
        //  verificar para cada peça
        for(int i = 0; i < Peca.NUMERO_QUADRADOS; i++) {
            
            //      outras peças                                fundo
            if(quadrados[i].collidesWith(tile, true) || (quadrados[i].getY() + quadrados[i].getHeight()) >= (289 - 9)) {
                colide = true;
                break;
            }
        }
        
        return colide;
    }
    
    //  quando uma peça atinge o fundo do ecrã ou outra peça temos que adicionar
    //  à TILE
    public void adicionarATelha(TiledLayer tile) {
        for(int i = 0; i < Peca.NUMERO_QUADRADOS; i++) {
            
            //  calcular a posição XY da peça em relação à matriz da TILE
            //
            //  a peça tem 9 de largura e 9 de altura e move-se de 9 em 9 pixels
            //
            //  se a peça tiver x = 19 e y = 90 a sua posição correspondente na matriz da tile é
            //  (19 / 9 = 2) e (90 / 9 = 10)
            //
            //  portanto, fazemos um set cell na posição 2-10 na TILE para indicar que existe lá algo
            //
            int x = (quadrados[i].getX() / 9);
            int y = (quadrados[i].getY() / 9) - 1;
            
            tile.setCell(x, y, quadrados[i].getFrame() + 1);
        }
    }
    
    public boolean atingiuTopo(TiledLayer tile) {
        boolean colide = false;
        
        //  verificar para cada peça
        for(int i = 0; i < Peca.NUMERO_QUADRADOS; i++) {
            if(quadrados[i].collidesWith(tile, true) && quadrados[i].getY() <= 9) {
                colide = true;
                break;
            }
        }
        
        return colide;
    }
}