package tetris;

import javax.microedition.lcdui.Display;
import javax.microedition.midlet.MIDlet;

public class TetrisMidlet extends MIDlet {
    public Display display = Display.getDisplay(this);
    
    public void startApp() {
        display.setCurrent(new Menu(this));
    }
    
    public void pauseApp() {
    }
    
    public void destroyApp(boolean unconditional) {
    }
}