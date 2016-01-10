package jogo;

import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.game.Sprite;

public class Plataforma extends Sprite {        
    public Plataforma(Image i, int x, int y) {
        super(i, i.getWidth(), i.getHeight());
        
        setPosition(x, 100);
    }
    
}
