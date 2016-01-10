/*
 * Splash.java
 *
 * Created on 12 de Junho de 2007, 21:43
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package game;

import java.io.IOException;
import javax.microedition.lcdui.Canvas;
import javax.microedition.lcdui.Graphics;
import javax.microedition.lcdui.Image;

/**
 *
 * @author Ricardo
 */
public class Splash extends Canvas {
    
    Image splashLogo;
    Midlet m;
    
    /** Creates a new instance of Splash */
    public Splash(Midlet m) {        
        this.m = m;
        
        try {
            splashLogo = Image.createImage("/game/splash.PNG");
        } catch (IOException ex) {
            ex.printStackTrace();
        }        
    }

    protected void paint(Graphics g) {
       g.setColor(230, 211, 187);
       g.fillRect(0, 0, getWidth(), getHeight());
       
       g.setColor(0, 0, 0);
       
       g.drawImage(splashLogo, 0, 0, 0);
       g.drawString("carrega no enter para continuar!", 0, 170, 0);
    }
    
    protected void keyPressed(int k) {
        if (getGameAction(k) == Canvas.FIRE) {
            m.menu();
        }
    }
    
}
