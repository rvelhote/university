import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.game.Sprite;

public class BlocoSprite extends Sprite {
    
    public boolean colidiu;
    
    public BlocoSprite(Image img, int w, int h) {
        super(img, w, h);
        
        colidiu = false;
    }
    
}
