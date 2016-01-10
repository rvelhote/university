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
    //  s = a sprite com a qual queremos verificar colis�o
    //
    public boolean colideCom(Sprite s) {
        return ( collidesWith(s, false) && collidesWith(s, true) ) ? true : false;
    }
    
    //
    //  Verificar se a bola colide com um qualquer obst�culo
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
            //  A TiledLayer � constituida por x elementos de um certo tamanho (no caso do jogo 22x22).
            //  Se um objecto da TileLayer estiver na posi��o xy (66, 44), dividindo estes
            //  valores por 22, obtemos (3, 2). Logo, a tile que quremos verificar anda por a�.
            //
            
            //
            //  No c�digo em baixo vamos verificar a posi��o da bola relativamente � tile
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
            //  Se a tile onde estiver a bola for 1 que dizer que est� dentro de uma tile
            //  portanto, vamos recuar um pouco a bola e fazer denovo os c�lculos
            if (t.getCell(mColuna, mLinha) == 1) {
                x-=velX;
                y-=velY;
                
                mLinha = y / t.getCellHeight();
                mColuna = x / t.getCellWidth();
                
                posYLinha = mLinha * t.getCellHeight();
                posXColuna = mColuna * t.getCellWidth();
            }
            
            //
            //  velX < 0 -> a bola est� a andar da direita para a esquerda            
            //
            if ( velX < 0 && x >= posXColuna && t.getCell(mColuna - 1, mLinha) == 1 ) { // a andar para a esquerda
                velX *= -1;
                
                //
                //  velX > 0 -> a bola est� a andar da esquerda para a direita
                //
            } else if ( velX > 0 && x <= posXColuna + t.getCellWidth() && t.getCell(mColuna + 1, mLinha) == 1 ) { // a andar para a direita
                velX *= -1;
                
                //
                //  velY > 0 -> a bola est� a andar de cima para baixo
                //
            } else if ( velY > 0 && y <= posYLinha + t.getCellHeight() && t.getCell(mColuna, mLinha + 1) == 1   ) { // a andar para baixo
                velY *= -1;
                
                //
                //  velY < 0 -> a bola est� a andar de baixo para cima
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
    //  w = width do ecr�
    //  h = height do ecr�
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
    //  Os estados poss�veis da bola
    //
    public final static int ESTADO_NENHUM = 0;
    public final static int ESTADO_PEQUENA = 1;
    public final static int ESTADO_MEDIA = 2;
    public final static int ESTADO_GRANDE = 3;
}
