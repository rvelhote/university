import java.util.Random;
import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.game.Sprite;


public class BonusSprite extends Sprite {
        
    public BonusSprite(Image img, int w, int h) {
        super(img, w, h);
    }
    
    //
    //  Retorna o nome do b�nus
    //
    //  tb = n�mero do b�nus
    //
    public String getNomeBonus(int tb) {        
        if (tb == BONUS_OURO) {
            return "Ouro";
        } else if (tb == BONUS_BOMBA) {
            return "Bomba!";
        } else if (tb == BONUS_SETA_PODEROSA) {
            return "Seta Valente";
        } else if (tb == BONUS_PARAGEM_NO_TEMPO) {
            return "Paragem no tempo!";
        } else if (tb == BONUS_VIDA) {
            return "Vida!";
        }
        
        return "Nenhum";
    }
    
    //
    //  Movimenta o b�nus
    //
    public void moveBonus() {
        setPosition(getX(), getY() + VELOCIDADE_BONUS);
    }
    
    //
    //  Verificar se o b�nus colide com uma sprite (normalmente ser� o jogador)
    //
    //  s = a sprite com a qual queremos verificar colis�o
    //
    public boolean colideCom(Sprite s) {        
        return ( collidesWith(s, false) && collidesWith(s, true) ) ? true : false;
    }

    //
    //  Verificar se o b�nus j� atingiu o limite inferir no ecr�
    //  � a deixa para parar de mexer
    //
    public boolean atingeLimites() {
        return ( (getY() + getHeight() ) <= LIMITE) ? false : true;
    }
    
    //
    //  Seleccionar um b�nus aleatoriamente e coloc�-lo na posi��o xy
    //
    //  x = posi��o x no GC
    //  y = posi��o y no GC
    //
    public void seleccionarBonus(int x, int y) {
        Random rnd = new Random();
                
        setFrame(rnd.nextInt(5));
        setPosition(x, y);        
    }
            
    int VELOCIDADE_BONUS = 9;
    int LIMITE = 262;    
    
    //
    //  Os b�nus poss�veis
    //  Cada n�mero representa o frame da imagem
    //
    public final static int BONUS_NENHUM = -1;
    public final static int BONUS_OURO = 0;
    public final static int BONUS_BOMBA = 1;
    public final static int BONUS_SETA_PODEROSA = 2;
    public final static int BONUS_PARAGEM_NO_TEMPO = 3;
    public final static int BONUS_VIDA = 4;
}
