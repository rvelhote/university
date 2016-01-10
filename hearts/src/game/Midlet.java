package game;

import javax.microedition.lcdui.Command;
import javax.microedition.lcdui.CommandListener;
import javax.microedition.lcdui.Display;
import javax.microedition.lcdui.Displayable;
import javax.microedition.lcdui.Form;
import javax.microedition.lcdui.List;
import javax.microedition.midlet.MIDlet;

public class Midlet extends MIDlet implements CommandListener {

    List menu;
    Form f;
    Command ok = new Command("Voltar", Command.SCREEN, 0);
    public Display d;
    
    
    public void startApp() {  
        Display.getDisplay(this);
        
        splash();        
        
    }
    
    private void splash() {
        Display.getDisplay(this).setCurrent(new Splash(this));
    }

    public void pauseApp() {
    }
        
    public void destroyApp(boolean unconditional) { 
    }

    public void commandAction(Command c, Displayable s) {
        if(c == ok) {
            menu();
        } else {        
            if(menu.getSelectedIndex() == 0) {
                Display.getDisplay(this).setCurrent(new HeartsCanvas());
            } else if(menu.getSelectedIndex() == 1) {
                ajuda();
            } else if(menu.getSelectedIndex() == 2) {
                acerca();
            } else if(menu.getSelectedIndex() == 3) {
                notifyDestroyed();
            }
        }
    }
    
    public void menu() {
        menu = new List("Menu", List.IMPLICIT);
        menu.append("Jogar", null);
        menu.append("Ajuda", null);
        menu.append("Acerca", null);
        menu.append("Sair", null);
        
        menu.setCommandListener(this);
        
        Display.getDisplay(this).setCurrent(menu);
    }
    
    private void ajuda() {
        f = new Form("Ajuda");   
        
        f.append("para jogar tens que fazer isto e aqui e tal feiofhnweiofhnweio fnf");
        f.addCommand(ok);
        f.setCommandListener(this);
        
        Display.getDisplay(this).setCurrent(f);
    }
    
    private void acerca() {
        f = new Form("Acerca");
        
        f.append("acerca acerca acercaacerca v  v  acerca acerca acercaacerca  acerca");        
        f.addCommand(ok);
        f.setCommandListener(this);
        
        Display.getDisplay(this).setCurrent(f);    
    }
}
