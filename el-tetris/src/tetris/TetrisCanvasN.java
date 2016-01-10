package tetris;

import java.io.IOException;
import java.util.Random;
import javax.microedition.lcdui.Font;
import javax.microedition.lcdui.Graphics;
import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.game.GameCanvas;
import javax.microedition.lcdui.game.TiledLayer;

public class TetrisCanvasN extends GameCanvas implements Runnable {
    
    private int LINHAS = 32;
    private int COLUNAS = 17;
    private Image imgBackgroundJogo;
    private TiledLayer tile;
    
    private Image imgStats;
    private Image imgPecas;
    private Thread thread;
    private boolean jogoTerminou = false;
    
    private TetrisMidlet midlet;
    private Peca peca;
    private PecaSeguinte pecaSeguinte;
    
    private int pontuacao = 0;
    private int numLinhas = 0;
    private int nivel = 1;
    
    private final int PONTUACAO_NIVEL_1 = 500;
    private final int PONTUACAO_NIVEL_2 = 5000;
    private final int PONTUACAO_NIVEL_3 = 10000;
    
    private void carregarImagens() {
        try {
            //imgPecas = Image.createImage("/tetris/imagens/les.quadrados.png");
            imgPecas = Image.createImage("/tetris/imagens/ALTERNATIVO.les.quadrados.png");
            imgBackgroundJogo = Image.createImage("/tetris/imagens/background_jogo.png");
            imgStats = Image.createImage("/tetris/imagens/background_stats.png");
        } catch (IOException ex) {
            System.out.println("erro load imgaeg");
        }
    }
    
    public TetrisCanvasN(TetrisMidlet m) {
        super(true);
        
        midlet = m;
        
        carregarImagens();
        
        //  criar a TILE com 26 COLUNAS e 32 LINHAS
        //  imgPecas indica o tipo de imagem que vai fazer parte da tile
        //  9-9 indica a largura e a altura da imagem
        tile = new TiledLayer(COLUNAS, LINHAS, imgPecas, 9, 9);
        
        Random r = new Random();
        peca = new Peca(imgPecas);
        peca.criarPeca(r.nextInt(4), r.nextInt(5));
        
        pecaSeguinte = new PecaSeguinte(imgPecas);
        pecaSeguinte.sortear();
        
        
        thread = new Thread(this);
        thread.start();
    }
    
    public void run() {
        while(!jogoTerminou) {
            
            //  move os quadradinhos que constituem a peça
            //movePeca();
            peca.desce();
            
            //  verifica colisões com o fundo ou com outras peças (a tile)
            //colideCom();
            if(peca.colidiu(tile)) {
                
                if(peca.atingiuTopo(tile)) {                    
                    jogoTerminou = true;
                } else {
                    peca.adicionarATelha(tile);
                    peca.criarPeca(pecaSeguinte.tipo, pecaSeguinte.cor);
                    pecaSeguinte.sortear();
                    
                    pontuacao += 20;
                    
                    //  verifica se foi feita uma linha completa
                    fezLinha();
                }
            }
            
            //  verifica quais as teclas que estão a ser pressionadas
            teclas();
            
            if(passouNivel()) {
                nivel++;                
            }
            
            //  pinta tudo
            renderizar();
            
            try {
                thread.sleep(300 / nivel);
            } catch (InterruptedException ex) {
                ex.printStackTrace();
            }
        }
        
        fimJogo();
    }
    
    private void fimJogo() {
        Graphics g = getGraphics();
        Image imgFim = null;
        
        try {
            imgFim = Image.createImage("/tetris/imagens/game.over.png");
        } catch (IOException ex) {
            ex.printStackTrace();
        }
        
        g.drawImage(imgFim, 15, getHeight() /2, 0);
        
        flushGraphics();
        
        try {
            thread.sleep(5000);
        } catch (InterruptedException ex) {
            ex.printStackTrace();
        }
        
        midlet.display.setCurrent(new Menu(midlet));
    }
    
    private boolean passouNivel() {
        boolean passou = false;
        
        if(nivel > 3) {
            jogoTerminou = true;            
        } else {            
            switch(nivel) {
                case 1:
                    if(pontuacao >= PONTUACAO_NIVEL_1) {
                        passou = true;
                    }
                    
                    break;
                    
                case 2:
                    if(pontuacao >= PONTUACAO_NIVEL_2) {
                        passou = true;
                    }
                    
                    break;
                    
                case 3:
                    if(pontuacao >= PONTUACAO_NIVEL_3) {
                        passou = true;
                    }
                    
                    break;
            }
        }
        
        return passou;
    }
    
    private void renderizar() {
        Graphics g = getGraphics();
        
        //  pintar o ecrã todo de branco para redesenhar os objectos nas suas
        //  novas posições
        g.setColor(255, 255, 255);
        g.fillRect(0, 0, getWidth(), getHeight());
        
        g.drawImage(imgBackgroundJogo, 0, 0, 0);
        g.drawImage(imgStats, 161, 0, 0);
        
        g.setColor(0, 0, 0);
        g.setFont(Font.getFont(Font.FACE_PROPORTIONAL, Font.STYLE_BOLD, Font.SIZE_LARGE));
        
        g.drawString("" + nivel, 220, 95, 0);
        g.drawString("" + numLinhas, 220, 145, 0);
        g.drawString("" + pontuacao, 180, 220, 0);
        
        //  pintar cada um dos quadradinhos das peças
        for(int i = 0; i < Peca.NUMERO_QUADRADOS; i++) {
            peca.quadrados[i].paint(g);
            pecaSeguinte.quadrados[i].paint(g);
        }
        
        //  pintar a tile
        tile.paint(g);
        
        flushGraphics();
    }
    
    private void teclas() {
        int key = getKeyStates();
        
        //  mover as peças para a esquerda
        if(key == GameCanvas.LEFT_PRESSED) {
            
            //  verificar se a primeira peça (do lado esquerdo) está no limite do ecrã
            //  se não estiver (a sua posição é > 0), mover todas as peças para a esquerda
            //
            //  se já estiver na posição 0 não se faz nada
            peca.moveEsquerda();
            
            //  verificar se a última peça (a contar do lado esquerdo) está no limite do ecrã
            //
            //  o processo é igual ao do lado esquerdo mas em ver de verificarmos se está na posição
            //  0, verificamos se atingiu a WIDTH do ecrã.
            //
        } else if(key == GameCanvas.RIGHT_PRESSED) {
            peca.moveDireita();
            
            //  se carregarmos para cima, rodar a peça
        } else if(key == GameCanvas.UP_PRESSED) {
            peca.rodar();
        } else if(key == GameCanvas.DOWN_PRESSED) {
            peca.desceDepressa();
            
            if(peca.colidiu(tile)) {                
                if(peca.atingiuTopo(tile)) {                    
                    jogoTerminou = true;
                } else {
                    
                    peca.adicionarATelha(tile);
                    peca.criarPeca(pecaSeguinte.tipo, pecaSeguinte.cor);
                    pecaSeguinte.sortear();
                    
                    pontuacao += 20;
                    
                    //  verifica se foi feita uma linha completa
                    fezLinha();
                }
            }
        } else if(key == 256) {
            jogoTerminou = true;
        }
    }
    
//  percorre todas as linhas e colunas da tile à procura de uma linha complete
    private void fezLinha() {
        int c;
        
        for(int i = (LINHAS - 1); i >= 0; i--) {
            for(int j = 1; j < COLUNAS; j++) {
                
                //  se alguma das celulas da linha-coluna for igual a zero (vazia)
                //  que dizer automaticamente que já não temos uma linha portanto
                //  saimos do FOR e começamos a analisar a próxima linha
                c = tile.getCell(j, i);
                
                if(tile.getCell(j, i) == 0) {
                    break;
                }
                
                //System.out.println(tile.getCell(1, 29));
                
                //  se chegou ao fim de todas as colunas e ainda não saiu do ciclo (ver em cima)
                //  é porque existe uma linha completa
                if(j == (COLUNAS - 1)) {
                    eliminarLinha(i);
                    amandarTudoParaBaixo(i);
                    
                    numLinhas++;
                    pontuacao += 100;
                }
            }
        }
    }
    
    private void amandarTudoParaBaixo(int linha) {
        try {
            for(int i = linha; i >= 0; i--) {
                for(int j = 1; j < COLUNAS; j++) {
                    tile.setCell(j, i, tile.getCell(j, i - 1));
                }
            }
        } catch(IndexOutOfBoundsException e) {
        }
    }
    
    //  elimina a linha que foi feita
    private void eliminarLinha(int linha) {
        
        //  percorrer todas as colunas da linha
        for(int j = 0; j < COLUNAS; j++) {
            
            //  e colocar a célula a 0 (vazia)
            tile.setCell(j, linha, 0);
        }
    }
}