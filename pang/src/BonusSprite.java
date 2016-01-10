import java.util.Random;
import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.game.Sprite;


public class BonusSprite extends Sprite {
        
    public BonusSprite(Image img, int w, int h) {
        super(img, w, h);
    }
    
    //
    //  Retorna o nome do bónus
    //
    //  tb = número do bónus
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
    //  Movimenta o bónus
    //
    public void moveBonus() {
        setPosition(getX(), getY() + VELOCIDADE_BONUS);
    }
    
    //
    //  Verificar se o bónus colide com uma sprite (normalmente será o jogador)
    //
    //  s = a sprite com a qual queremos verificar colisão
    //
    public boolean colideCom(Sprite s) {        
        return ( collidesWith(s, false) && collidesWith(s, true) ) ? true : false;
    }

    //
    //  Verificar se o bónus já atingiu o limite inferir no ecrã
    //  é a deixa para parar de mexer
    //
    public boolean atingeLimites() {
        return ( (getY() + getHeight() ) <= LIMITE) ? false : true;
    }
    
    //
    //  Seleccionar um bónus aleatoriamente e colocá-lo na posição xy
    //
    //  x = posição x no GC
    //  y = posição y no GC
    //
    public void seleccionarBonus(int x, int y) {
        Random rnd = new Random();
                
        setFrame(rnd.nextInt(5));
        setPosition(x, y);        
    }
            
    int VELOCIDADE_BONUS = 9;
    int LIMITE = 262;    
    
    //
    //  Os bónus possíveis
    //  Cada número representa o frame da imagem
    //
    public final static int BONUS_NENHUM = -1;
    public final static int BONUS_OURO = 0;
    public final static int BONUS_BOMBA = 1;
    public final static int BONUS_SETA_PODEROSA = 2;
    public final static int BONUS_PARAGEM_NO_TEMPO = 3;
    public final static int BONUS_VIDA = 4;
}
