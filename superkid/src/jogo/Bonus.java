package jogo;

import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.game.Sprite;

public class Bonus extends Sprite {
    
    public static int BONUS_PONTOS = 1;
    public static int BONUS_HEALTH = 2;
    
    public int tipoBonus;
    
    public Bonus(Image i, int x, int y, int tipo) {
        super(i, i.getWidth() / 2, i.getHeight());
        
        tipoBonus = tipo;
        
        setFrame(tipo - 1);        
        setPosition(x, y);
    }
    
    public void move(int x) {
        setPosition(getX() + x, getY());
    }
}
