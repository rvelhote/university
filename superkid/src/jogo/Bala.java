package jogo;

import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.game.Sprite;

public class Bala extends Sprite implements Runnable {
    Thread t;
    public boolean acabou = false;
    
    public Bala(Image i, int x, int y) {
        super(i, i.getWidth(), i.getHeight());
        
        setPosition(x, y);
        
        t = new Thread(this);
        t.start();
    }    

    public void run() {
        while(getX() < 540) {
            setPosition(getX() + 10, getY());
            
            try {                
                t.sleep(30);
            } catch (InterruptedException ex) {
                ex.printStackTrace();
            }
        }
        
        acabou = true;
    }
    
    public boolean colide(Mauzao m) {
        if(this.collidesWith(m, false)) {
            return true;
        }
        
        return false;
    }
}
