import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.game.Sprite;
import javax.microedition.lcdui.game.TiledLayer;


public class SetaSprite extends Sprite {
    
    public SetaSprite(Image img, int w, int h) {
        super(img, w, h);
    }
    
    //
    //  Move a seta x pixeis e passa para o próximo frame da imagem
    //  (crescer)
    //
    public void mexeSeta() {
        setPosition(getX(), getY() - VELOCIDADE_SETA);
        nextFrame();
    }
    
    //
    //  Verificar se a seta colidiu com alguma sprite
    //
    //  s = a sprite com a qual queremos verificar colisão
    //
    public boolean colideCom(Sprite s) {
        return ( collidesWith(s, false) && collidesWith(s, true) ) ? true : false;
    }
    
    //
    //  Verificar a seta atingiu o limite superior ou um qualquer objecto da
    //  TiledLayer
    //
    //  s = a sprite com a qual queremos verificar colisão
    //
    public boolean atingiuTopoOuObstaculo(TiledLayer objs) {
        return ( getY() <= 18 || collidesWith(objs, false) ) ? true : false;
    }
    
    private final int VELOCIDADE_SETA = 7;
}
