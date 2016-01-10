package jogo;
/*
 * Midlet.java
 *
 * Created on 14 de Maio de 2007, 17:10
 */

import javax.microedition.midlet.*;
import javax.microedition.lcdui.*;

/**
 *
 * @author  Ricardo
 * @version
 */
public class Midlet extends MIDlet {
    public Display display = Display.getDisplay(this);
    
    public void startApp() {
        //display.setCurrent(new Menu(this));
        display.setCurrent(new Jogo());
    }
    
    public void pauseApp() {
    }
    
    public void destroyApp(boolean unconditional) {
    }
}
