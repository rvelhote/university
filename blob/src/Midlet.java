import javax.microedition.lcdui.Display;
import javax.microedition.midlet.MIDlet;
/*
 * Midlet.java
 *
 * Created on 13 de Setembro de 2006, 15:19
 */



/**
 *
 * @author  Ricardo
 * @version
 */
public class Midlet extends MIDlet {
    public void startApp() {
        Display.getDisplay(this).setCurrent(new BlobCanvas());
    }
    
    public void pauseApp() {
    }
    
    public void destroyApp(boolean unconditional) {
    }
}
