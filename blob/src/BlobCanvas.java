import java.io.IOException;
import java.util.Random;
import javax.microedition.lcdui.Graphics;
import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.game.GameCanvas;
import javax.microedition.lcdui.game.Sprite;
import javax.microedition.lcdui.game.TiledLayer;
/*
 * BlobCanvas.java
 *
 */

/**
 *
 * @author Ricardo
 */
public class BlobCanvas extends GameCanvas implements Runnable {
    
    Thread th;
    Image imgPecas;
    TiledLayer tile;    
    Sprite blob;
    Sprite blob2;
    
    Random ra = new Random();
    
    boolean blob1Colidiu = false;
    boolean blob2Colidiu = false;
    
    int HORIZONTAL_UM = 0;
    int VERTICAL_UM = 1;
    int HORIZONTAL_DOIS = 2;
    int VERTICAL_DOIS = 3;
        
    int rotacao = 0;
    
    public BlobCanvas() {
        super(true);
        
        inicializar();
        
        th = new Thread(this);
        th.start();
    }
    
    private void inicializar() {
        try {
            imgPecas = Image.createImage("/blobs.png");
        } catch (IOException ex) {
            ex.printStackTrace();
        }
        
        blob = new Sprite(imgPecas, 16, 16);
        blob.setFrame(seleccionarCor());
        blob.setPosition(96, 16);
        
        blob2 = new Sprite(imgPecas, 16, 16);
        blob2.setFrame(seleccionarCor());
        blob2.setPosition(112, 16);
        
        fundo();
    }
    
    private void fundo() {
        tile = new TiledLayer(15, 18, imgPecas, 16, 16);
        
//        tile.setCell(0, 1, 1);
//
//        tile.setCell(0, 17, 2);
//
//        tile.setCell(14, 17, 3);
//
//        tile.setCell(14, 1, 4);
    }
    
    public void run() {
        while(true) {
            
            teclas();
            
            moveBlobParaBaixo();
            
            if(blob1Colidiu && blob2Colidiu) {
                novaBlob();
                blob1Colidiu = false;
                blob2Colidiu = false;
            }
            
            pintar();
            
            try {
                th.sleep(100);                
            } catch (InterruptedException ex) {
                ex.printStackTrace();
            }
        }
    }
    
    private void moveBlobParaBaixo() {
        if(!blob1Colidiu) {
            blob.setPosition(blob.getX(), blob.getY() + 16);
        }
        
        if(!blob2Colidiu) {
            blob2.setPosition(blob2.getX(), blob2.getY() + 16);
        }
        
        if(blob.getY() >= getHeight() - 25 || blob.collidesWith(tile, false)) {
            blob1Colidiu = true;
            adicionarBlobATile(blob);
            
            //verCores(blob.getX() / 15, (blob.getY() / 18) + 1);
            
            //  mover para fora do ecrã porque senão continua visível enquanto a outra blob não colidir
            blob.setPosition(-16, 0);
            
            if(rotacao == VERTICAL_UM || rotacao == VERTICAL_DOIS) {
                blob2Colidiu = true;
            }
        }
        
        if(blob2.getY() >= getHeight() - 25 || blob2.collidesWith(tile, false)) {
            blob2Colidiu = true;
            adicionarBlobATile(blob2);
            
            //verCores(blob2.getX() / 15, (blob2.getY() / 18) + 1);
            
            //  mover para fora do ecrã porque senão continua visível enquanto a outra blob não colidir
            blob2.setPosition(-16, 0);
            
            if(rotacao == VERTICAL_UM || rotacao == VERTICAL_DOIS) {
                blob1Colidiu = true;                
            }
        }
    }
    
    private void verCores() {
//        boolean h = false;
//        
//        
//        try {
//            if(tile.getCell(coluna, linha + 1) - 1 == blob.getFrame()) {
//                tile.setCell(coluna, linha + 1, 0);
//                h = true;
//                
//            } else if(tile.getCell(coluna, linha - 1) - 1 == blob.getFrame()) {
//                tile.setCell(coluna, linha - 1, 0);
//                h = true;
//                
//            } else if(tile.getCell(coluna - 1, linha) - 1 == blob.getFrame()) {
//                tile.setCell(coluna - 1, linha, 0);
//                h = true;
//                
//            } else if(tile.getCell(coluna + 1, linha) - 1 == blob.getFrame()) {
//                tile.setCell(coluna + 1, linha, 0);
//                h = true;
//            }
//        } catch(IndexOutOfBoundsException e) {
//        }
//        
//        return h;
    }
    
    private void adicionarBlobATile(Sprite b) {
        int x = (b.getX() / 15);
        int y = (b.getY() / 18) + ((b.getY() > 144) ? 1 : 0);
        
        tile.setCell(x, y, b.getFrame() + 1);
    }
    
    private void verCores(int coluna, int linha) {
    }
    
    private void limparEspacosBrancos() {
        try {
            for(int i = tile.getRows() - 1; i >= 0; i--) {
                for(int j = tile.getColumns() - 1; j >= 0; j--) {
                    if(tile.getCell(j, i) == 0) {
                        tile.setCell(j, i, tile.getCell(j, i - 1));
                        tile.setCell(j, i - 1, 0);
                    }
                }
            }
        } catch(IndexOutOfBoundsException e) {
        }
    }
    
    private void novaBlob() {
        blob = new Sprite(imgPecas, 16, 16);
        blob.setFrame(seleccionarCor());
        blob.setPosition(96, 16);
        
        blob2 = new Sprite(imgPecas, 16, 16);
        blob2.setFrame(seleccionarCor());
        blob2.setPosition(112, 16);
        
        rotacao = HORIZONTAL_UM;
        //lmgr.append(blob);
    }
    
    private int seleccionarCor() {
        return ra.nextInt(5);
    }
    
    private void teclas() {
        int key = getKeyStates();
        
        if(key == GameCanvas.LEFT_PRESSED) {
            if(blob.getX() > 0 && blob2.getX() > 0) {
                blob.setPosition(blob.getX() - 16, blob.getY());
                blob2.setPosition(blob2.getX() - 16, blob2.getY());
            }
        } else if(key == GameCanvas.RIGHT_PRESSED) {
            if(blob.getX() < getWidth() - 32 && blob2.getX() < getWidth() - 32) {
                blob.setPosition(blob.getX() + 16, blob.getY());
                blob2.setPosition(blob2.getX() + 16, blob2.getY());
            }
        } else if(key == GameCanvas.DOWN_PRESSED) {
            if(blob.getY() <= getHeight() - 16 && blob2.getY() <= getHeight() - 16){
                blob.setPosition(blob.getX(), blob.getY() + 32);
                blob2.setPosition(blob2.getX(), blob2.getY() + 32);
            }
        } else if(key == 256) {
            rodar();
        }
    }
    
    private void rodar() {
        if(rotacao == HORIZONTAL_UM) {
            blob.setPosition(blob2.getX(), blob2.getY() - 16);
            rotacao = VERTICAL_UM;
            
        } else if(rotacao == VERTICAL_UM) {
            blob.setPosition(blob2.getX() + 16, blob2.getY());
            rotacao = HORIZONTAL_DOIS;
            
        } else if(rotacao == HORIZONTAL_DOIS) {
            blob.setPosition(blob2.getX(), blob2.getY() + 16);
            rotacao = VERTICAL_DOIS;            
            
        } else if(rotacao == VERTICAL_DOIS) {
            blob.setPosition(blob2.getX() - 16, blob2.getY());
            rotacao = HORIZONTAL_UM;
        }        
    }
    
    private void pintar() {
        Graphics g = getGraphics();
        
        g.setColor(255, 255, 255);
        g.fillRect(0, 0, getWidth(), getHeight());
        
        g.setColor(120, 100, 200);
        g.fillRect(0, 0, 240, 20);
        
        g.setColor(0, 0, 0);
        g.drawString("Pontuação", 100, 5, 0);
        
        tile.paint(g);
        blob.paint(g);
        blob2.paint(g);
        
        flushGraphics();
    }
    
}
