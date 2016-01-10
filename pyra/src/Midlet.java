import javax.microedition.lcdui.Display;
import javax.microedition.midlet.MIDlet;
/*
 * Midlet.java
 *
 * Created on February 13, 2006, 3:38 PM
 */



/**
 *
 * @author  Paulo Matos
 * @version
 */
public class Midlet extends MIDlet {
    
    Pyramid py = null;
    
    public void startApp() {
        py = new Pyramid();        
        Display.getDisplay(this).setCurrent(py);
        
        py.iniciarJogo();
    }
    
    public void pauseApp() {
    }
    
    public void destroyApp(boolean unconditional) {
    }
}
