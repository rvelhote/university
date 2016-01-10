package jogo;

import java.util.Vector;
import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.game.Sprite;

public class Personagem extends Sprite {
    public int health = 100;
    public int vidas = 3;
    
    public Vector balas = new Vector();
    public boolean saltou = false;
    public boolean podeSaltar = true;
        
    public Personagem(Image i) {
        super(i, i.getWidth(), i.getHeight());
        setPosition(0, 138);
    }
        
    public void moveEsquerda() {
        if(getX() > 0) {
            setPosition(getX() - Constantes.MOVIMENTO_PERSONAGEM, getY());
        }        
    }
        
    public void moveDireita() {
        setPosition(getX() + Constantes.MOVIMENTO_PERSONAGEM, getY());
    }
        
    public void salta() {
        if(getY() > 0) {
            setPosition(getX(), getY() - Constantes.MOVIMENTO_PERSONAGEM);
            saltou = true;
        } else {
            podeSaltar = false;
        }
    }
        
    public void dispara(Image bala) {
        if(balas.size() < 4) {
            balas.addElement(new Bala(bala, getX() + getWidth(), getY() + 28));
        }
    }
    
    public void desce(int ate) {
        if(getY() != ate) {
            setPosition(getX(), getY() + Constantes.MOVIMENTO_PERSONAGEM);        
        } else {
            saltou = false;
            podeSaltar = true;
        }
    }
}
