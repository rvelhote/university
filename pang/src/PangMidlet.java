import javax.microedition.lcdui.Display;
import javax.microedition.midlet.MIDlet;

//
//
//
public class PangMidlet extends MIDlet {
    public Display display = null;
    private PangMenu menu = null;      
    
    //
    //
    //
    public void startApp() {
        display = display = Display.getDisplay(this);
        menu = new PangMenu(this);
        display.setCurrent(menu);
    }
    
    //
    //
    //
    public void pauseApp() {
        
    }
    
    //
    //
    //
    public void destroyApp(boolean unconditional) {
    }
}
