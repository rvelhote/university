import java.io.IOException;
import java.util.Random;
import javax.microedition.lcdui.Font;
import javax.microedition.lcdui.Graphics;
import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.game.GameCanvas;
import javax.microedition.lcdui.game.Layer;
import javax.microedition.lcdui.game.LayerManager;
import javax.microedition.lcdui.game.Sprite;
import javax.microedition.lcdui.game.TiledLayer;
import javax.microedition.rms.RecordStore;


public class EditorMapasCanvas extends GameCanvas implements Runnable {
    
    //
    //  O construtor
    //
    //  m = referência à midlet
    //  pm = referência ao menu
    //
    public EditorMapasCanvas(PangMidlet m, PangMenu pm) {
        super(true);
        
        midlet = m;
        menu = pm;
        
        lmgr = new LayerManager();
        
        try {
            objecto = Image.createImage("/graficos/obstaculos.png");
            seleccionador = Image.createImage("/graficos/seleccionador.png");
        } catch(IOException e) {
            System.out.println("Erro ao carregar a imagem background!");
            return;
        }
        
        selector = new Sprite(seleccionador);
        selector.setPosition(0, 22);
        
        criarFundo();
    }
    
    //
    //  O ciclo principal do editor
    //
    public void run() {        
        while(!fecharEditor) {
            
            //
            //  Verificar as teclas pressionadas pelo utilizado
            //
            verificarTeclas();

            renderizar(getGraphics());
            
            try {
                Thread.sleep(25);
            } catch (InterruptedException ie) {
                System.out.println("A Thread partiu-se toda!");
                break;
            }
        }        
        
        midlet.display.setCurrent(menu);        
    }

    //
    //  Mostar uma mensagem no ecrã do jogo.
    //
    //  g = o objecto gráfico para renderizar o GameCanvas
    //  s = a mensagem a mostrar
    //  timeout = a tempo que vai aparecer a mensagem
    //  px = posição x
    //  py = posição y
    //
    private void mostrarMensagem(Graphics g, String s, int timeout, int px, int py) {
        try {
            g.setColor(0, 0, 0);
            g.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_LARGE));
            g.drawString(s, px, py, 20);
            flushGraphics();
            
            Thread.sleep(timeout);
        } catch (InterruptedException ie) {
            System.out.println("A Thread partiu-se toda!");
        }
    }
    
    //
    //  Verificar as teclas
    //
    private void verificarTeclas() {
        int estadoTecla = getKeyStates();
        
        if ( estadoTecla == 0 ) {
            return;
        }
                                        
        if ( estadoTecla == LEFT_PRESSED  && (selector.getX()) > 0 ) {
            selector.setPosition(selector.getX() - 22, selector.getY());

        } else if ( estadoTecla == RIGHT_PRESSED && (selector.getX() + 22) < 240 ) {
            selector.setPosition(selector.getX() + 22, selector.getY());

        } else if (estadoTecla == UP_PRESSED && (selector.getY() - 22) > 0) {
            selector.setPosition(selector.getX(), selector.getY() - 22);

        } else if (estadoTecla == DOWN_PRESSED  && (selector.getY() + 22) < 260) {
            selector.setPosition(selector.getX(), selector.getY() + 22);

        } else if (estadoTecla == 256 ) {
            if (!jaExisteTileNaPosicao(selector.getX(), selector.getY())) {
                criarNovaTile(selector.getX(), selector.getY());
            }
            
        } else if (estadoTecla == 512) {
            gravarNivel();                        
            mostrarMensagem(getGraphics(), "A gravar nível!", 2000, 60, 150);
            fecharEditor = true;
            
        } else if (estadoTecla == 1024) {
            mostrarMensagem(getGraphics(), "A sair sem gravar!", 2000, 60, 150);
            fecharEditor = true;
            
        } else if (estadoTecla == 2048) {
            removerLayerEditor(selector.getX(), selector.getY());
        }
    }
    
    //
    //  Colocar um novo objecto na posição x, y indicada
    //
    //  px = x
    //  py = y
    //
    private void criarNovaTile(int px, int py) {
        Sprite obj = new Sprite(objecto);
        obj.setPosition(px, py);
        lmgr.append(obj);
    }
    
    //
    //  Verificar se já existe algum objecto na posição xy definida
    //
    //  px = x
    //  py = y
    //
    private boolean jaExisteTileNaPosicao(int px, int py) {        
        Layer l = null;
        for (int i = 0; i < lmgr.getSize(); i++) {
            l = lmgr.getLayerAt(i);
            
            if (px == l.getX() && py == l.getY()) {
                return true;
            }
        }
        
        return false;
    }
    
    //
    //  Remover uma layer da posição xy definida
    //
    //  px = x
    //  py = y
    //
    private void removerLayerEditor(int px, int py) {
        Layer l = null;
        for (int i = 0; i < lmgr.getSize(); i++) {
            l = lmgr.getLayerAt(i);
            
            if (px == l.getX() && py == l.getY()) {
                lmgr.remove(l);
                break;
            }
        }
    }
    
    //
    //  inicar a thread
    //
    public void initEditor() {
        threadEditor = new Thread(this);
        threadEditor.start();
    }
    
    //
    //  desenhar a bonecada
    //
    private void renderizar(Graphics g) {
        background.paint(g);
        lmgr.paint(g, 0, 0);        
        selector.paint(g);
        
        flushGraphics();
    }
    
    //
    //  Gravar o nível à saída
    //
    private void gravarNivel() {
        Layer l = null;
        int[][] map = new int[13][13];
        
        for (int i = 0; i < lmgr.getSize(); i++) {
            l = lmgr.getLayerAt(i);
            map[l.getY() / 22][l.getX() / 22] = 1;
        }
        
        try {
            String n = "";
            byte[] rec = null;
            Random rnd = new Random();
            
            //niveisUtilizador.deleteRecordStore("niveis_u.pang");
            niveisUtilizador = RecordStore.openRecordStore("niveis_u.pang", true );
            
            for (int i = 0; i < 13; i++) {
                for (int j = 0; j < 13; j++) {
                    n+=(int)map[i][j];
                }
            }
            
            // 
            //  randomizar o númro de bolas
            //
            n+=String.valueOf(rnd.nextInt(1) + 1);
            
            rec = n.getBytes();
            niveisUtilizador.addRecord(rec, 0, rec.length);                        
            
            niveisUtilizador.closeRecordStore();
        } catch (Exception e) {
            System.out.println(e.toString());
        }
    }
    
    //
    //  Criar o fundo do editor
    //
    private void criarFundo() {
        Image imagemBackground = null;
        int l = 0, c = 0;
        
        try {
            imagemBackground = Image.createImage("/graficos/background_jogo.png");
        } catch(IOException e) {
            System.out.println("Erro ao carregar a imagem background!");
            return;
        }
        
        //  col, row
        background = new TiledLayer(13, 13, imagemBackground, 22, 22);
        
        int[] celulas = {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2
        };
        
        for (int i = 0; i < celulas.length; i++) {
            c = i % 13;
            l = (i - c)/13;
            
            background.setCell(c, l, celulas[i]);
        }
    }
        
    private PangMidlet midlet = null;
    private PangMenu menu = null;
    
    private Thread threadEditor = null;
    private Image objecto = null;
    private Image seleccionador = null;
    private TiledLayer background = null;
    private LayerManager lmgr = null;
    
    private boolean fecharEditor = false;
    
    private Sprite selector = null;
    
    private RecordStore niveisUtilizador = null;
}
