package jogo;

import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.game.Sprite;

public class Mauzao extends Sprite implements Runnable {
    
    public static int MAUZAO_ESTATICO = 0;
    public static int MAUZAO_NORMAL = 1;
    
    public boolean desapareceu = false;
    public boolean morto = false;
    public int health = 100;
    public int tipoMauzao;
    
    public Bala bala;
    private Thread t;
    public static Image imagemBala;
    
    
    private int contadorDisparo = 0;

    public boolean disparou = false;
    
    public Mauzao(Image i, int tipo) {
        super(i, i.getWidth() / 2, i.getHeight());
        
        tipoMauzao = tipo;
        
        System.out.println(tipoMauzao);
        
        setPosition(Constantes.LARGURA_ECRA + 20, 150);
        
        t = new Thread(this);
        t.start();
    }
    
    public void run() {
        while(!morto || !desapareceu) {
            
            if(tipoMauzao == MAUZAO_NORMAL) {
                move();
            } else {
                
                if(contadorDisparo == 3000 && !disparou) {
                    dispara();
                    contadorDisparo = 0;
                    disparou = true;
                } else {
                    contadorDisparo += 30;
                }
                
                if(disparou) {
                    moveBala();
                }
            }
            
            if(health == 0) {
                morto = true;
            }
            
            if(getX() <= 0) {
                desapareceu = true;
            }                        
            
            try {
                t.sleep(50);
            } catch (InterruptedException ex) {
                ex.printStackTrace();
            }
        }
    }
    
    public void move() {
        setPosition(getX() - 10, getY());
    }
    
    private void dispara() {                
        bala = new Bala(imagemBala, getX(), getY());
    }
    
    private void moveBala() {
        if(bala.getX() > 0) {
            bala.setPosition(bala.getX() - 10, bala.getY());
        } else {
            disparou = false;
        }        
    }
}