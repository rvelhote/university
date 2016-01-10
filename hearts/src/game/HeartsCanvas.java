package game;

import java.io.IOException;
import java.util.Random;
import javax.microedition.lcdui.Font;
import javax.microedition.lcdui.Graphics;
import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.game.GameCanvas;
import javax.microedition.lcdui.game.Sprite;
import javax.microedition.lcdui.game.TiledLayer;

public class HeartsCanvas extends GameCanvas implements Runnable {
    
    private Thread t;
    
    private TiledLayer tileHearts;
    private Sprite selector;
    
    private boolean terminou;
    
    private int pontuacao;
    

    
    public HeartsCanvas() {                
        super(true);
        

        carregarSprite();
        quadroJogo();
        
        render();
        
        t = new Thread(this);
        t.start();
    }
    
    private void carregarSprite() {
        Image sel = null;
        
        try {
            sel = Image.createImage("/game/selector.png");
        } catch (IOException ex) {
            ex.printStackTrace();
        }
        
        selector = new Sprite(sel, 20, 20);
        selector.setPosition(0, 0);
    }
    
    private void quadroJogo() {
        Image coracoes = null;
        Random rnd = new Random();
        
        try {
            coracoes = Image.createImage("/game/coracoes.png");
        } catch (IOException ex) {
            ex.printStackTrace();
        }
        
        //  UMA TILEDLAYER, NO FUNDO, � UMA MATRIZ. NESTE CASO DE 12x14
        //
        //  12 -> N�MERO DE COLUNAS
        //  14 -> N�MERO DE LINHAS
        //  coracoes -> A IMAGEM QUE VAI COMPOR CADA UM DOS QUADRADINHOS DA TILEDLAYER
        //  20 -> WIDTH DA IMAGEM coracoes
        //  20 -> HEIGHT DA IMAGEM coracoes
        //
        //  NA VERDADE A IMAGEM TEM 120 DE WIDTH E 20 DE ALTURA MAS AO DIZER 20,20 AO CHAMAR
        //  O CONSTRUTOR, EST�S A DIVIDIR A IMAGEM EM 6.
        //
        //  120 / 20 = 6
        //
        tileHearts = new TiledLayer(12, 14, coracoes, 20, 20);
        
        //  PREENCHER A TILEDLAYER COM N�MEROS ALEAT�RIOS
        //  DE 1 A 6.
        //
        //  LER A EXPLICACAO EM CIMA
        //
        for (int r = 0; r < 14; r++) {
            for (int c = 0; c < 12; c++) {
                tileHearts.setCell(c, r, rnd.nextInt(6) + 1);
            }
        }
    }
    
    private void render() {
        Graphics g = getGraphics();
        
        //  LIMPAR O ECR� COM DETERMINADA COR
        g.setColor(249, 225, 214);
        g.fillRect(0, 0, getWidth(), getHeight());
        
        //  PINTAR TUDO DE NOVO
        tileHearts.paint(g);
        selector.paint(g);
        
        g.setColor(0, 0, 0);
        g.setFont(Font.getFont(Font.FACE_PROPORTIONAL, Font.STYLE_BOLD, Font.SIZE_MEDIUM));        
        g.drawString(pontuacao + "pts", 2, 273, 0);
        
        flushGraphics();
    }
    
    public void run() {
        
        //  CICLO "INFINITO" AT� A VARI�VEL SER VERDADEIRA
        while(!terminou) {
            
            if(moverSelector()) {
                
                
                if(terminouJogo()) {
                    terminou = true;
                }
                
                //  S� � PRECISO FAZER O RENDER SE CARREGARMOS EM ALGUMA TECLA
                render();
            }
                        
            try {
                t.sleep(100);
            } catch (InterruptedException ex) {
                ex.printStackTrace();
            }
        }
        
        mensagem("Acabou o Jogo!!", 65, 100);
        mensagem("�s o Verdadeiro!!", 50, 130);        
        mensagem("UAU!! " + pontuacao + " pontos", 50, 160);
    }
    
    private void comerPecas() {
        
        //  VERIFICAR A POSICAO DO SELECTOR
        //
        //  O SELECTOR COME�A NA POSI��O (0,0). SE CARREGARES PARA A DIREITA
        //  O SELECTOR PASSA A ESTAR NA POSICAO (20,0)
        //
        //  COMO EU J� DISSE ANTES UMA TILEDLAYER � UMA MATRIZ DE 12x14 E CADA IMAGEM � DE 20x20. PORTANTO
        //  SE QUISERES SABER EM QUE POSICAO DA MATRIZ CORRESPONDE A POSICAO EM
        //  QUE O SELECTOR ACTUALMENTE EST�, DIVIDES A POSI��O X E Y DO SELECTOR POR 20.
        //
        //  POR EXEMPLO. SE O SELECTOR ESTIVER NA POSICAO (40,20) EM RELA��O � MATRIZ ESTAR� NA POSI��O
        //  (2,1)        
        //
        int linha = selector.getY() / 20;
        int coluna = selector.getX() / 20;
        
        //  PORTANTO SACAS A COR CORRESPONDENTE A ESSA POSI��O (EX: (2,1)) E VAIS
        //  VERIFICAR QUAIS S�O AS PE�AS QUE S�O IGUAIS QUE ESTEJAM NAS IMEDIA��ES
        int cor = tileHearts.getCell(coluna, linha);
        
        //  AO FAZERES O SETCELL COM O VALOR NAQUELA POSICAO EST�S A REMOVER
        //
        //  0 (ZERO) � EQUIVALENTE A N�O TER NADA NAQUELA POSI��O.
        tileHearts.setCell(coluna, linha, 0);
        
        if(cor != 0) {
            verificarMatch(coluna, linha, cor);            
            pontuacao += 1;
        }
        
        baixarPecas();
    }
    
    private void baixarPecas() {        
        int p = 0;
        
        for(int coluna = 0; coluna < 12; coluna++) {                        
            for(int linha = 0; linha < 14; linha++) {
    
                //  SE ENCONTRARES ALGUMA LINHA QUE ESTAJA VAZIA
                if(tileHearts.getCell(coluna, linha) == 0) {

                    //  PESQUISAS A PARTIR DA� POR UMA LINHA QUE TENHA L� ALGUMA COISA
                    for(p = linha; p < 14; p++) {                                                
                        if(tileHearts.getCell(coluna, p) != 0) {
                            
                            //  SE ENCONTRARES, TROCAS A LINHA QUE ESTAVA VAZIA POR AQUELA QUE ENCONTRASTE
                            //  QUE N�O ESTAVA VAZIA
                            tileHearts.setCell(coluna, linha, tileHearts.getCell(coluna, p) );
                            
                            //  E COLOCAS A OUTRA A ZERO PORQUE EFECTIVAMENTE DESAPARECEU (MUDOU DE POSI��O)
                            tileHearts.setCell(coluna, p, 0);
                            
                            break;
                        }                        
                    }                    
                }                
            }
        }
    }
    
    //  ESTA FUN��O � RECURSIVA
    private void verificarMatch(int coluna, int linha, int cor) {
        int corNorte = 0;
        int corSul = 0;
        int corOeste = 0;
        int corEste = 0;
        
        //  AS PE�AS TEM OUTRAS PE�AS AO LADO. PARTINDO DA POSI��O ONDE ACTUALMENTE
        //  EST� O SELECTOR VAIS VERIFICAR TODAS AS OUTRAS
        
        //  VAIS VERIFICAR A COR DA PE�A QUE EST� NO NORTE,
        if(linha != 0) {
            corNorte = tileHearts.getCell(coluna, linha - 1);
        }
        
        //  SUL ETC...
        if(linha != 13) {
            corSul = tileHearts.getCell(coluna, linha + 1);
        }
        
        if(coluna != 0) {
            corOeste = tileHearts.getCell(coluna -1, linha);
        }
        
        if(coluna != 11) {
            corEste = tileHearts.getCell(coluna + 1, linha);
        }
                
        //  CONDI��O DE PARAGEM DA FUN��O RECURSIVA.
        if(corEste == 0 && corOeste == 0 && corNorte == 0 && corSul == 0) {
            return;
        }
        
        //  DEPOIS TENS QUE VERIFICAR SE A COR DA PE�A QUE EST� NO NORTE CORRESPONDE
        //  � COR DA PE�A ONDE ESTAVA O SELECTOR.
        //
        //  SE FOR, PARA ESSA PECA VAIS VERIFICAR TAMB�M O NORTE, SUL, OESTE E ESTE
        //  E ASSIM SUCESSIVAMENTE
        if(corNorte == cor) {
            tileHearts.setCell(coluna, linha - 1, 0);            
            verificarMatch(coluna, linha - 1, cor);
            
            pontuacao += 10;
        }
        
        if(corSul == cor) {
            tileHearts.setCell(coluna, linha + 1, 0);
            verificarMatch(coluna, linha + 1, cor);
            
            pontuacao += 10;
        }
        
        if(corOeste == cor) {
            tileHearts.setCell(coluna -1, linha, 0);
            verificarMatch(coluna -1, linha, cor);
            
            pontuacao += 10;
        }
        
        if(corEste == cor) {
            tileHearts.setCell(coluna + 1, linha, 0);
            verificarMatch(coluna + 1, linha, cor);
            
            pontuacao += 10;
        }
    }
    
    //  PESQUISAR TODAS AS C�LULAS DA TILEDLAYER
    //  SE ALGUMA DELAS FOR DIFERENTE DE 0 QUE DIZER QUE O JOGO AINDA N�O ACABOU
    private boolean terminouJogo() {
        for (int r = 0; r < 14; r++) {
            for (int c = 0; c < 12; c++) {
                
                //  PORTANTO RETORNAS LOGO FALSE PARA DIZER QUE AINDA N�O TERMINOU
                if(tileHearts.getCell(c, r) != 0) {
                    return false;
                }
            }
        }
        
        //  SE AINDA N�O SAIU DO M�TODO � PORQUE O JOGO FICOU CMOPLETO
        return true;
    }
    
    private boolean moverSelector() {
        int key = getKeyStates();
        boolean moveu = (key == 0) ? false : true;
        
        int x = selector.getX();
        int y = selector.getY();
        
        if(key == GameCanvas.LEFT_PRESSED) {
            if(x != 0) {
                
                //  PARA ANDARES PARA A ESQUEDA DIMINUI O X
                selector.setPosition(x - 20, y);
            }
        } else if(key == GameCanvas.RIGHT_PRESSED) {
            if(x / 20 != 11) {
                
                //  PARA ANDARES PARA A DIREITA AUMENTA O X
                selector.setPosition(x + 20, y);
            }
            
        } else if(key == GameCanvas.UP_PRESSED) {
            if(y != 0) {
                
                //  PARA ANDARES PARA CIMA DIMINUI O Y
                selector.setPosition(x, y - 20);
            }
            
        } else if(key == GameCanvas.DOWN_PRESSED) {
            if(y / 20 != 13) {
                
                //  PARA ANDARES PARA BAIXO AUMENTA O Y
                selector.setPosition(x, y + 20);
            }
            
            //  AO CARREGAR NA TECLA ENTER, COMER AS PE�AS
        } else if(key == 256) {
            
            comerPecas();
            
        }
        
        return moveu;
    }
    
    private void mensagem(String texto, int x, int y) {
        Graphics g = getGraphics();
        
        g.setColor(0, 0, 0);
        g.setFont(Font.getFont(Font.FACE_MONOSPACE, Font.STYLE_BOLD, Font.SIZE_LARGE));
        
        g.drawString(texto, x, y, 0);
        
        flushGraphics();
    }
}
