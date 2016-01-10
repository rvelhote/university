import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.game.Sprite;
import javax.microedition.lcdui.game.TiledLayer;



public class PersonagemSprite extends Sprite {
    
    public PersonagemSprite(Image img, int w, int h) {
        super(img, w, h);
    }
    
    //
    //  Movimentar a personagem para a direita. Ter em conta o limite lateral
    //
    public void passoDireita() {
        if ( (getX() + getWidth()) < (LARGURA_ECRA) ) {
            setPosition( getX() + TAMANHO_PASSO, getY() );
        }
    }
    
    //
    //  Movimentar a personagem para a esquerda. Ter em conta o limite lateral
    //
    public void passoEsquerda() {
        if ( getX() > 0 ) {
            setPosition( getX() - TAMANHO_PASSO, getY() );
        }
    }
    
    //
    //  A personagem disparou uma seta
    //
    //  imgSeta = a imagem da seta a disparar
    //
    public SetaSprite disparaSeta(Image imgSeta) {
        SetaSprite novaSeta = new SetaSprite(imgSeta, 10, 265); ;
        
        novaSeta.setFrame(0);
        novaSeta.setPosition(getX(), getY() + 10);
        
        numSetasDisparadas++;
        
        return novaSeta;
    }
    
    //
    //  Verificar se o jogador colide com uma sprite
    //
    //  s = a sprite com a qual queremos verificar colisão
    //
    public boolean colideCom(Sprite s) {
        return ( collidesWith(s, false) && collidesWith(s, true) ) ? true : false;
    }
    
    //
    //  Verificar se o jogador colide com qualquer objecto da TiledLayer
    //
    //  t = a TiledLayer
    //
    public boolean colideCom(TiledLayer t) {
        return ( collidesWith(t, false) && collidesWith(t, true) ) ? true : false;
    }
    
    //
    //  Atribuir o bonus ao jogador
    //
    //  tb = o tipo de bónus
    //
    public void atribuirBonus(int tb) {
        if (tb == BonusSprite.BONUS_OURO) {
            pontuacao += 300;
        } else if (tb == BonusSprite.BONUS_PARAGEM_NO_TEMPO) {
            bonusActivo = tb;
        } else if (tb == BonusSprite.BONUS_SETA_PODEROSA) {
            bonusActivo = tb;
        } else if (tb == BonusSprite.BONUS_VIDA) {
            numVidas++;
        } else if (tb == BonusSprite.BONUS_BOMBA) {
            bonusActivo = tb;
        }
    }
    
    final int TAMANHO_PASSO = 10;
    final int LARGURA_ECRA = 240;
    final int ALTURA_ECRA = 289;
    
    public int numVidas = 3;
    public int pontuacao = 0;
    public int numSetasDisparadas = 0;
    public int tirosCerteiros = 0;
    //public int numTentativas = 0;
    public int bonusActivo = BonusSprite.BONUS_NENHUM;
}
