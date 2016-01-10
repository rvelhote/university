import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.game.Sprite;
import javax.microedition.lcdui.game.TiledLayer;


public class BolaSprite extends Sprite {
    
    public BolaSprite(Image img, int x, int y, int vx, int vy, int w, int h, int eb) {
        super(img, w, h);
        
        velX = vx;
        velY = vy;
        
        estadoBola = eb;
        
        setPosition(x, y);
    }
    
    //
    //  Verificar se a bola colide com uma sprite (normalmente a personagem)
    //
    //  s = a sprite com a qual queremos verificar colisão
    //
    public boolean colideCom(Sprite s) {
        return ( collidesWith(s, false) && collidesWith(s, true) ) ? true : false;
    }
    
    //
    //  Verificar se a bola colide com um qualquer obstáculo
    //
    //  t = a TiledLayer
    //
    public boolean colideCom(TiledLayer t) {
        if (collidesWith(t, false)) {
            //int x1 = getX(), y1 = getY();
            // centro
            int x = getX() + (getWidth() / 2);
            int y = getY() + (getHeight() / 2);
            
            //
            //  A TiledLayer é constituida por x elementos de um certo tamanho (no caso do jogo 22x22).
            //  Se um objecto da TileLayer estiver na posição xy (66, 44), dividindo estes
            //  valores por 22, obtemos (3, 2). Logo, a tile que quremos verificar anda por aí.
            //
            
            //
            //  No código em baixo vamos verificar a posição da bola relativamente à tile
            //
            int mLinha = y / t.getCellHeight();
            int mColuna = x / t.getCellWidth();
            
            //
            //  Calcular as coordenadas
            //
            int posYLinha = mLinha * t.getCellHeight();
            int posXColuna = mColuna * t.getCellWidth();
            
            //
            //
            //  Se a tile onde estiver a bola for 1 que dizer que está dentro de uma tile
            //  portanto, vamos recuar um pouco a bola e fazer denovo os cálculos
            if (t.getCell(mColuna, mLinha) == 1) {
                x-=velX;
                y-=velY;
                
                mLinha = y / t.getCellHeight();
                mColuna = x / t.getCellWidth();
                
                posYLinha = mLinha * t.getCellHeight();
                posXColuna = mColuna * t.getCellWidth();
            }
            
            //
            //  velX < 0 -> a bola está a andar da direita para a esquerda            
            //
            if ( velX < 0 && x >= posXColuna && t.getCell(mColuna - 1, mLinha) == 1 ) { // a andar para a esquerda
                velX *= -1;
                
                //
                //  velX > 0 -> a bola está a andar da esquerda para a direita
                //
            } else if ( velX > 0 && x <= posXColuna + t.getCellWidth() && t.getCell(mColuna + 1, mLinha) == 1 ) { // a andar para a direita
                velX *= -1;
                
                //
                //  velY > 0 -> a bola está a andar de cima para baixo
                //
            } else if ( velY > 0 && y <= posYLinha + t.getCellHeight() && t.getCell(mColuna, mLinha + 1) == 1   ) { // a andar para baixo
                velY *= -1;
                
                //
                //  velY < 0 -> a bola está a andar de baixo para cima
                //
            } else if (velY < 0 && y >= posYLinha && t.getCell(mColuna, mLinha - 1) == 1 ) { // a andar para cima
                velY *= -1;
            }
            
            return true;
        }
        
        return false;
    }
    
    //
    //  Movimentar a bola
    //
    public void moveBola() {
        setPosition(getX() + velX, getY() + velY);
    }
    
    //
    //  Verificar se a bola atingiu os limites laterais ou superiores
    //
    //  w = width do ecrã
    //  h = height do ecrã
    //
    public void atingeLimites(int w, int h) {
        int bx = getX(), by = getY();
        
        if ( ( ( bx + getWidth() ) > w ) || ( bx + velX < 0  ) )  {
            velX *= -1;
        } else if ( ( ( by + velY ) > (h - 17 ) ) || ( by + velY < 13 ) || ( by + getHeight() + velY > (h - 17 ) ) ) {
            velY *= -1;
        }
    }
    
    
    public int velX;
    public int velY;
    
    //  O estado actual
    public int estadoBola;
    
    //
    //  Os estados possíveis da bola
    //
    public final static int ESTADO_NENHUM = 0;
    public final static int ESTADO_PEQUENA = 1;
    public final static int ESTADO_MEDIA = 2;
    public final static int ESTADO_GRANDE = 3;
}
