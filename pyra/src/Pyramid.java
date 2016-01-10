import java.io.IOException;
import java.util.Random;
import java.util.Vector;
import javax.microedition.lcdui.Graphics;
import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.game.GameCanvas;
import javax.microedition.lcdui.game.TiledLayer;


public class Pyramid extends GameCanvas implements Runnable {
    public Pyramid() {
        super(true);
        
        try {
            imgObjectos = Image.createImage("/drops.png");
        } catch (IOException e) { }
    }
    
    public void iniciarJogo() {
        criarBlocos();
        
        thJogo = new Thread(this);
        thJogo.start();
    }
    
    // RENDERIZAR AS IMAGENS NO ECRÃ
    private void render(Graphics g) {
        
        BlocoSprite s = null;
        
        g.setColor(255, 255, 255);
        g.fillRect(0, 0, getWidth(), getHeight());
        
        for (int i = 0; i < vSprites.size(); i++) {
            s = (BlocoSprite)vSprites.elementAt(i);
            s.paint(g);
        }
        
        bloco.paint(g);
        
        flushGraphics();
    }
    
    // MOVIMENTAR TODOS OS BLOCOS EXISTENTES NO VECTOR
    private void moveObjecto() {
        BlocoSprite s = null;
        
        try {
            for (int i = 0; i < vSprites.size(); i++) {
                s = (BlocoSprite)vSprites.elementAt(i);
                s.setPosition(s.getX() + 20,  s.getY());
                
                // VERIFICAR SE A PIMEIRA PEÇA JÁ ATINGIU O LIMITE DO LADO
                if (s.getX() == 200) {
                    aSubir = true;
                    
                    // SE SIM, MOVIMENTAR TODAS AS PEÇAS LÁ PARA CIMA
                    for (int y = 0; y < vSprites.size(); y++) {
                        s = (BlocoSprite)vSprites.elementAt(y);
                        s.setPosition(s.getX(), s.getY() - 60);
                    }
                    
                    verificaColisao();
                    
                    break;
                }
            }
        } catch (ArrayIndexOutOfBoundsException e) {
            System.out.println("erro a mover o objecto");
        }
        
    }
    
    // ADICIONAR UM NOVO BLOCO AO VECTOR
    private void adicionarNovoBloco() {
        
        if (vSprites.size() >= 10 || aSubir) {
            return;
        }
        
        BlocoSprite s = new BlocoSprite(imgObjectos, 20, 20);
        //System.out.println("l: " + String.valueOf(vSprites.size()));
        if (vSprites.size() == 0) {
            s.setPosition(-20, getHeight() - 29);
        } else {
            s.setPosition(((BlocoSprite)vSprites.firstElement()).getX() - 20, ((BlocoSprite)vSprites.firstElement()).getY() );
        }
        
        s.setFrame(ra.nextInt(6));
        
        vSprites.insertElementAt(s, 0);
    }
    
    // CICLO PRINCIPAL DO PROGRAMA
    public void run() {
        
        while(!acabou && !perdeu) {
            verTeclas();
            
            adicionarNovoBloco();
            
            if (!aSubir) {
                moveObjecto();
            }
            
            render(getGraphics());
            
            verificarEstadoJogo();
            
            try{
                Thread.sleep(500);
            }catch(InterruptedException ie) {
                System.err.println(ie.getMessage());
            }
        }
    }
    
    //  VERIFICAR SE JA CHEGOU AO TOPO DO ECRA OU SE JÁ NÃO EXISTEM MAIS PEÇAS!
    private void verificarEstadoJogo() {
        Graphics g = getGraphics();
        
        for(int col = 0; col < 10; col++) {
            if (bloco.getCell(col, 0) != 0) {
                perdeu = true;
                g.drawString("perdeste!!!", 20, 220,  0);
                flushGraphics();
                return;
            }
        }
        
        for(int li = 0; li < 10; li++) {
            for(int col = 0; col < 10; col++) {
                if (bloco.getCell(col, li) != 0) {
                    return;
                }
            }
        }

        g.drawString("PASSASTE PARA O PRÓXIMO NÍVEL!!!", 20, 220,  0);
        try{
            Thread.sleep(2000);
            criarBlocos();
        }catch(InterruptedException ie) {
            System.err.println(ie.getMessage());
        }
        
        flushGraphics();
    }
    
    
    private void verTeclas() {
        int key = getKeyStates();
        BlocoSprite s = null;
        
        if (key == 256) {
            aSubir = true;
            for (int i = 0; i < vSprites.size(); i++) {
                s = (BlocoSprite)vSprites.elementAt(i);
                s.setPosition(s.getX(), s.getY() - 60);
            }
            
            verificaColisao();
        }
    }
    
    //  VERIFICAR AS COLISÕES ENTRE AS PEÇAS DE MESMA COR
    public void verificaColisao() {
        BlocoSprite s = null;
        int cor = 0, coluna = 0, linha = 0;
        
        for (int i = 0; i < vSprites.size(); i++) {
            s = (BlocoSprite)vSprites.elementAt(i);
            cor = s.getFrame();
            
            //  CALCULAR A LINHA E COLUNA EM QUE ESTÁ A PEÇA QUE QUEREMOS VERIFICAR
            coluna = i;
            linha = (s.getY() / 20) - 1;
            
            
            if (cor == ( bloco.getCell(coluna, linha) - 1)) {
                s.setFrame(6);
                
                bloco.setCell(coluna, linha, 0);
                
                //  SE FOR DA MESMA COR, VAMOS PUXAR TUDO O QUE ESTIVER EM CIMA CÁ PARA BAIXO
                //  PARA NÃO FICAREM ESPAÇOS EM BRANCO NA COLUNA
                verPecas(linha - 1, coluna, cor);
            }
        }
        
        trocarLinhas();
        mandarTudoAbaixo();
        
        //
        aSubir = false;
        vSprites.removeAllElements();
    }
    
    //  EVITAR ESPAÇOS EM BRANCO NO MEIO DOS BLOCOS
    private void mandarTudoAbaixo() {
        for (int i = 9; i > 0; i--) {
            for (int c = 0; c < 10; c++) {
                if (bloco.getCell(c, i) == 0) {
                    bloco.setCell(c, i, bloco.getCell( c, i - 1));
                    bloco.setCell(c, i - 1, 0);
                }
            }
        }
    }
    
    //  TROCAR AS LINHAS
    private void trocarLinhas(){
        BlocoSprite s = null;
        
        //  TROCAR TODAS AS LINHAS
        for(int i = 0; i < 9; i++) {
            for (int j = 0; j < 10; j++) {
                bloco.setCell(j, i, bloco.getCell( j, i + 1 ));
            }
        }
        
        //  INCLUIR OS BLOCOS DA LINHA QUE SE MEXE NA TILEDLAYER
        for (int j = 0; j < vSprites.size(); j++) {
            s = (BlocoSprite)vSprites.elementAt(j);
            if (s.getFrame() != 6) {
                bloco.setCell(j, 9, s.getFrame() + 1);
            } else {
                bloco.setCell(j, 9, 0);
            }
        }
        
        for (int j = vSprites.size(); j < 10; j++) {
            bloco.setCell(j, 9, 0);
        }
    }
    
    
    //  ELIMINAR AS PEÇAS E BAIXAR AS QUE ESTÃO NA MESMA COLUNA
    private void verPecas(int l, int c, int cor) {
        int bsub = 0;
        
        // eliminar as peças que estao para cima
        for (int r = l; r > 0; r--) {
            if (cor == (bloco.getCell(c, r) - 1) ) {
                bloco.setCell(c, r, 0);
            } else {
                for (int t = l + 1; t > 0; t--) {
                    
                    bsub = bloco.getCell(c, t - 1);
                    
                    if (bsub == 0) {
                        for (int k = t-1; k > 0; k--) {
                            if (bloco.getCell(c, k) != 0) {
                                bsub = bloco.getCell(c, k );
                                break;
                            }
                        }
                    }
                    
                    bloco.setCell(c, t, bsub);
                }
                
                break;
            }
        }
    }
    
    //  CRIAR O ECRÃ DE JOGO
    private void criarBlocos() {
        bloco = new TiledLayer(10, 10,  imgObjectos, 20, 20);
        int blocoSeleccionado = 0;
        
        for (int r = 0; r < 9; r++) {
            for (int c = 0; c < 10; c++) {
                bloco.setCell(c,r,0);
            }
        }
        
        for (int r = 8; r < 10; r++) {
            for (int c = 0; c < 10; c++) {
                
                blocoSeleccionado = ra.nextInt(6);
                if (blocoSeleccionado == 0){
                    blocoSeleccionado++;
                }
                
                bloco.setCell(c,r,blocoSeleccionado);
            }
        }
    }
    
    
    Image imgObjectos = null;
    
    Thread thJogo = null;
    
    TiledLayer bloco = null;
    
    boolean aSubir = false;
    boolean acabou = false;
    boolean perdeu = false;
    
    Vector vSprites = new Vector();
    
    Random ra = new Random();
}
