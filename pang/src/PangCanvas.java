import java.io.IOException;
import java.util.Random;
import java.util.Vector;
import javax.microedition.lcdui.Font;
import javax.microedition.lcdui.Graphics;
import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.game.GameCanvas;
import javax.microedition.lcdui.game.LayerManager;
import javax.microedition.lcdui.game.TiledLayer;
import javax.microedition.rms.RecordStore;

//
//
//
public class PangCanvas extends GameCanvas implements Runnable{
    
    //
    //  Construtor
    //
    //  m = referência à midlet
    //  pm = referência ao menu
    //  tn = o tipo de níveis a utilizar (RMS a utilizar). Este valor depende da
    //      opção escolhida pelo utilizador no menu "Jogar"
    //
    public PangCanvas(PangMidlet m, PangMenu pm, String tn) {
        super(true);
        
        midlet = m;
        menu = pm;
        tipoNiveis = tn;
        
        lmgr = new LayerManager();
        
        try {
            imgVitoria = Image.createImage("/graficos/vitoria.png");
            imgDerrota = Image.createImage("/graficos/grrr.png");
            imgHihi = Image.createImage("/graficos/hihi.png");
            
            imgSeta = Image.createImage("/graficos/seta.png");
            
            mesq = Image.createImage("/graficos/personagem_move_esquerda.png");
            mdir = Image.createImage("/graficos/personagem_move_direita.png");
            parado = Image.createImage("/graficos/personagem_parado.png");
            
            imgBonus = Image.createImage("/graficos/bonus.png");
            
            imgBolaGrande = Image.createImage("/graficos/bola_grande.png");
            imgBolaMedia = Image.createImage("/graficos/bola_media.png");
            imgBolaPequena = Image.createImage("/graficos/bola_pequena.png");
        } catch(IOException e) {
            System.out.println("Erro ao carregar imagens!");
            return;
        }
        
        personagem = new PersonagemSprite(parado, 22, 32);
        personagem.setPosition(getWidth() / 2, getHeight() - 49);
        
        bonus = new BonusSprite(imgBonus, 16, 16);
        bonus.setFrame(5);
        
        //
        //  Escrever os níveis oficiais no RMS
        //
        escreverNiveisMemoria();
        
        criarFundo();
        carregarNivel(nivelActual, tipoNiveis, false);
        
        lmgr.append(personagem);
        lmgr.append(bonus);
    }
    
    //
    //  Iniciar as bolas do jogo.
    //
    //  nb = número de bolas a iniciar (depende do nível)
    //
    private void iniciarBolas(int nb) {
        BolaSprite bola = null;
        int rHeight = 0, rDireccaoX = 0, rDireccaoY = 0, rWidth = 0;
        
        for (int i = 0; i < nb; i++) {
            rHeight = rnd.nextInt(15);
            rHeight = (rHeight < 15) ? rHeight += 15 : rHeight;
            
            rDireccaoX = (rnd.nextInt(10) < 5) ? -1 : 1;
            rDireccaoY = (rnd.nextInt(10) > 5) ? 1 : -1;
            
            rWidth = rnd.nextInt(getWidth() - 40);
            
            bola = new BolaSprite(imgBolaGrande, rWidth, rHeight, 7 * rDireccaoX, 7 * rDireccaoY, 24, 24, BolaSprite.ESTADO_GRANDE);
            
            //
            //  As bolas são sempre adicionadas no fim do vector
            //
            lmgr.append(bola);
            vecControlo.insertElementAt(bola, vecControlo.size());
        }
        
        numBolas = nb;
    }
    
    //
    //  Refrescar a bonecada no ecrã
    //
    //  g = o objecto gráfico para renderizar o GameCanvas
    //
    private void renderizar(Graphics g) {
        background.paint(g);
        objectos.paint(g);
        lmgr.paint(g, 0, 0);
        
        g.setFont(Font.getFont(Font.FACE_PROPORTIONAL, Font.STYLE_BOLD, Font.SIZE_MEDIUM));
        g.drawString("Pontos: " + String.valueOf(personagem.pontuacao), 1, -1, 20);
        g.drawString("Nível: " + String.valueOf(nivelActual), 197, -1, 20);
        
        g.drawString("Bónus: " + bonus.getNomeBonus(personagem.bonusActivo), 1, 270, 20);
        g.drawString("Vidas: " + String.valueOf(personagem.numVidas), 190, 270, 20);
        
        flushGraphics();
    }
    
    //
    //  Mostar uma mensagem no ecrã do jogo.
    //
    //  g = o objecto gráfico para renderizar o GameCanvas
    //  s = a mensagem a mostrar
    //  timeout = a tempo que vai aparecer a mensagem
    //  px = posição x
    //  py = posição y
    //  i = mostrar uma imagem com a mensagem
    //
    private void mostrarMensagem(/*Graphics g, */String s, int timeout, int px, int py, Image i) {
        Graphics g = getGraphics();
        
        try {            
            if (i != null) {
                g.drawImage(i, 85, 65, 0);
            }
            
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
    //  Ciclo principal do jogo
    //
    public void run() {
        while(!perdeu && personagem.numVidas != 0 && !baza) {
            //
            //  ver que teclas foram pressionadas
            //
            verificarTeclas();
            
            //
            //  movimentar quaisquer setas existentes
            //
            moveSetas();
            
            //
            //  Verificar se há algum bónus para movimentar
            //
            if (bonus.getFrame() != 5) {
                moveBonusSprite();
            }
            
            //
            //  Para fazer o bonus aplicado à personagem desaparecer após
            //  um certo tempo
            //
            if (personagem.bonusActivo != bonus.BONUS_NENHUM) {
                if (++bonusTickTack == 100) {
                    bonusTickTack = 0;
                    personagem.bonusActivo = bonus.BONUS_NENHUM;
                }
            }
            
            //
            //  Se o bónus activo for o de paragem no tempo, impedir as bolas
            //  de pinchar
            //
            if (personagem.bonusActivo != bonus.BONUS_PARAGEM_NO_TEMPO) {
                pinchaBolas();
            }
            
            renderizar(getGraphics());
            
            try {
                Thread.sleep(100);
            } catch (InterruptedException ie) {
                System.out.println("A Thread partiu-se toda!");
                break;
            }
        }
        
        //
        //  mensagem final
        //
        if (personagem.numVidas <= 0) {
            mostrarMensagem(/*getGraphics(),*/ "Acabaram as vidas!", 3000, 60, 150, imgDerrota);
        } else if (perdeu) {
            mostrarMensagem(/*getGraphics(),*/ "Fim do jogo!", 3000, 80, 150, imgDerrota);
        } else {
            mostrarMensagem(/*getGraphics(),*/ "Cápsula de CIANETO!", 3000, 55, 150, imgHihi);
        }
        renderizar(getGraphics());
        mostrarEstatisticas();
        midlet.display.setCurrent(menu);
    }
    
    //
    //  Fazer todas as bolas existentes em vecControlo pinchar
    //
    private void pinchaBolas() {
        BolaSprite b = null;
        
        try {
            for (int i = numSetas; i < vecControlo.size(); i++) {
                b = (BolaSprite)vecControlo.elementAt(i);
                
                b.atingeLimites(getWidth(), getHeight());
                b.colideCom(objectos);
                b.moveBola();
                
                if (b.colideCom(personagem)) {
                    if (--personagem.numVidas == 0) {
                        perdeu = true;
                        break;
                    } else {
                        carregarNivel(nivelActual, tipoNiveis, false);
                        mostrarMensagem(/*getGraphics(),*/ "Perdeste uma vida!", 2000, 70, 150, imgDerrota);
                    }
                }
            }
        }catch(IndexOutOfBoundsException e) {
            System.out.println(e.toString());
            return;
        }
    }
    
    //
    //  Movimentar o bónus pelo ecrã de jogo
    //
    private void moveBonusSprite() {
        if (!bonus.atingeLimites()) {
            bonus.moveBonus();
            
            if ( bonus.colideCom(personagem) ) {
                personagem.atribuirBonus( bonus.getFrame() );
                
                bonus.setFrame(5);
                tickTack = 0;
            }
            
        } else if (++tickTack == 50) {
            bonus.setFrame(5);
            tickTack = 0;
        }
    }
    
    //
    //  movimentar quaisquer setas existentes
    //
    private void moveSetas() {
        SetaSprite aSeta = null;
        
        for (int i = 0; i < numSetas; i++) {
            
            aSeta = (SetaSprite)vecControlo.elementAt(i);
            
            //
            //  verificar se atingiu um objeto da TileLayer ou o limite superior
            //  do ecrã
            //
            //  se for verdadeiro remover do Vector e do LayerManager
            //
            if (aSeta.atingiuTopoOuObstaculo(objectos)) {
                vecControlo.removeElement(aSeta);
                lmgr.remove(aSeta);
                
                i--;
                numSetas--;
            } else {
                BolaSprite bs = null;
                
                for (int y = numSetas; y < vecControlo.size(); y++) {
                    bs = (BolaSprite)vecControlo.elementAt(y);
                    
                    if (bs.colideCom(aSeta) || aSeta.colideCom(bs) ) {
                        
                        //
                        //  determinar se vai cair bónus. existem três condições
                        //  # não pode estar nenhum bónus a cair
                        //  # a personagem não pode ter nenhum bónus aplicado
                        //  # tem que sair zero :P
                        //
                        if (bonus.getFrame() == 5 && personagem.bonusActivo == BonusSprite.BONUS_NENHUM && rnd.nextInt(10) == 0) {
                            bonus.seleccionarBonus(bs.getX(), bs.getY());
                        }
                        
                        //
                        //  Destruir apenas se não tivermos o bónus da seta poderosa
                        //
                        if (personagem.bonusActivo != bonus.BONUS_SETA_PODEROSA) {
                            vecControlo.removeElement(aSeta);
                            lmgr.remove(aSeta);
                            
                            i--;
                            numSetas--;
                        }
                        
                        dividirBola(bs, 2, true);
                        
                        personagem.pontuacao+=100;
                        personagem.tirosCerteiros++;
                        
                        //
                        //  Se foi a última bola, carregar o próximo nível
                        //
                        if (numBolas <= 0) {
                            carregarNivel(++nivelActual, tipoNiveis, true);
                        }
                        
                        break;
                    }
                }
            }
            
            aSeta.mexeSeta();
        }
    }
    
    //
    //  Dividir uma bola num certo número de bolas. A divisão pode não ocorrer
    //  dependendo do estado da bola (Se esta já estiver no mais pequenos possivel)
    //
    //  b = a bola que vamos dividir
    //  numDiv = o número de bolas em que queremos dividir
    //  destruirAposDivisao = se queremos destruir a bola após dividir
    //
    private void dividirBola(BolaSprite b, int numDiv, boolean destruirAposDivisao) {
        if (--b.estadoBola != BolaSprite.ESTADO_NENHUM) {
            BolaSprite novaBola = null;
            Image img = null;
            int dimSprite = 0, dirX = 0, dirY = 0;
            
            //
            //  Definir a bola a criar como sendo a bola média
            //
            if (b.estadoBola == BolaSprite.ESTADO_MEDIA) {
                img = imgBolaMedia;
                dimSprite = 17;
                
                //
                //  Definir a bola a criar como sendo a bola média
                //
            } else {
                img = imgBolaPequena;
                dimSprite = 10;
            }
            
            for (int i = 0; i < numDiv; i++) {
                dirX = ((i % 2) == 0) ? 1 : -1;
                dirY = (b.velY < 0) ? -1 : 1;
                
                novaBola = new BolaSprite(img, b.getX(), b.getY(), 7 * dirX, 7 * dirY, dimSprite, dimSprite, b.estadoBola);
                
                lmgr.append(novaBola);
                vecControlo.insertElementAt(novaBola, vecControlo.size());
            }
            
            numBolas += numDiv;
        }
        
        //
        //  destruir
        //
        if (destruirAposDivisao) {
            vecControlo.removeElement(b);
            lmgr.remove(b);
            
            numBolas--;
        }
    }
    
    //
    //  Verificar as teclas pressionadas pelo utilizador durante o jogo
    //
    private void verificarTeclas() {
        int estadoTecla = getKeyStates();
        
        //
        //  Não existe nenhuma tecla pressionada
        //
        if ( estadoTecla == 0 ) {
            personagem.setImage(parado, 22, 32);
            return;
        }
        
        //
        //  Tecla ESQUERDA
        //
        if ( estadoTecla == LEFT_PRESSED ) {
            personagem.passoEsquerda();
            
            personagem.setImage(mesq, 22, 32);
            personagem.nextFrame();
            
            if (bonus.getFrame() != 5) {
                if (personagem.colideCom(bonus)) {
                    personagem.atribuirBonus(bonus.getFrame());
                    
                    bonus.setFrame(5);
                    tickTack = 0;
                }
            }
            
            //
            //  Tecla DIREITA
            //
        } else if ( estadoTecla == RIGHT_PRESSED ) {
            personagem.passoDireita();
            
            personagem.setImage(mdir, 22, 32);
            personagem.nextFrame();
            
            if (bonus.getFrame() != 5) {
                if (personagem.colideCom(bonus)) {
                    personagem.atribuirBonus(bonus.getFrame());
                    
                    bonus.setFrame(5);
                    tickTack = 0;
                }
            }
            
            //
            //  Botão SELECT ou ENTER no teclado ou então TECLA ESQUERDA ou DIREITA
            //  + SELECT
            //
            //  256 -> SELECT
            //  288 -> TECLA DIREITA + SELECT
            //  260 -> TECLA ESQUERDA + SELECT
            //
        } else if ( (estadoTecla == 256 || estadoTecla == 288 || estadoTecla == 260)  ) {
            
            SetaSprite novaSeta = null;
            
            for (int i = 0; i < numSetas; i++) {
                novaSeta = (SetaSprite)vecControlo.elementAt(i);
                
                if (novaSeta.getX() == personagem.getX()) {
                    return;
                }
            }
            
            novaSeta = personagem.disparaSeta(imgSeta);
            
            vecControlo.insertElementAt(novaSeta, 0);
            lmgr.append(novaSeta);
            
            numSetas++;
            
            //
            //  Suicídio
            //
        } else if (estadoTecla == 512) {
            baza = true;
            
            //
            //  Activar a bomba
            //
        } else if ( (estadoTecla == 2048 || estadoTecla == 2052 || estadoTecla == 2080) && personagem.bonusActivo == BonusSprite.BONUS_BOMBA )  {
            activarBomba();
            personagem.bonusActivo = BonusSprite.BONUS_NENHUM;
            
            if (numBolas <= 0) {
                carregarNivel(++nivelActual, tipoNiveis, true);
            }
        }
    }
    
    //
    //  Activar a bomba significa dividir todas as bolas existentes
    //
    private void activarBomba() {
        BolaSprite b = null;
        int tam = vecControlo.size();
        
        for (int i = numSetas; i < tam; i++) {
            b = (BolaSprite)vecControlo.elementAt(i);
            
            dividirBola(b, 2, true);
            tam--; i--;
        }
    }
    
    //
    //  Iniciar a thread
    //
    public void initJogo() {
        threadMain = new Thread(this);
        threadMain.start();
    }
    
    //
    //  Criar o fundo do jogo
    //
    private void criarFundo() {
        Image imagemBackground = null, imgObstaculos = null;
        int l = 0, c = 0;
        
        try {
            imagemBackground = Image.createImage("/graficos/background_jogo.png");
            imgObstaculos = Image.createImage("/graficos/obstaculos.png");
        } catch(IOException e) {
            System.out.println("Erro ao carregar a imagem background!");
            return;
        }
        
        //  col, row
        background = new TiledLayer(13, 13, imagemBackground, 22, 22);
        objectos = new TiledLayer(13, 13, imgObstaculos, 22, 22);
        
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
    
    private void mostrarEstatisticas() {
        mostrarMensagem("Estatísticas Finais--", 0, 45, 100, null);
        mostrarMensagem("Setas Disparadas: " + String.valueOf(personagem.numSetasDisparadas), 0, 45, 130, null);
        mostrarMensagem("Setas Certeiras: " + String.valueOf(personagem.tirosCerteiros), 0, 45, 150, null);
        mostrarMensagem("Pontuação: " + String.valueOf(personagem.pontuacao), 4000, 45, 170, null);
    }
    
    //
    //  Carregar um certo nível
    //
    //  ni = o nível a carregar
    //  loc = o RMS a utilizar
    //  mostrarMensagem = mostrar a mensagem de passagem de nível?
    //
    private void carregarNivel(int ni, String loc, boolean mostrarMensagem) {
        try {
            niveis = RecordStore.openRecordStore(loc, true );
            
            int c = 0, l = 0;
            byte[] dadosNivel = new byte[niveis.getRecordSize(ni)];
            int len = niveis.getRecord(ni, dadosNivel, 0);
            String n =  new String(dadosNivel, 0, len);
            
            for (int i = 0; i < len - 2; i++) {
                c = i % 13;
                l = (i - c)/13;
                
                objectos.setCell(c, l, (int)n.charAt(i) - 48);
            }
            
            //personagem.numTentativas++;
            reset();
            iniciarBolas((int)n.charAt(len - 1) - 48);
            
            niveis.closeRecordStore();
            
            if (mostrarMensagem) {
                mostrarMensagem(/*getGraphics(),*/ "Nível " + String.valueOf(ni) + "!", 2000, 100, 150, imgVitoria);
            }
        } catch (Exception e) {
            perdeu = true;
        }
    }
    
    //
    //  Se o RMS que contém os níveis originais não exitir, criar
    //
    private void escreverNiveisMemoria() {
        String n = null;
        byte[] rec = null;
        
        try {
            //niveis.deleteRecordStore("niveis.pang");
            niveis = RecordStore.openRecordStore("niveis.pang", true);
            
            if (niveis.getNumRecords() <= 0) {
                n = "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001";
                rec = n.getBytes();
                niveis.addRecord(rec, 0, rec.length);
                n = "00000000000000000000000000000000000000000011111000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002";
                rec = n.getBytes();
                niveis.addRecord(rec, 0, rec.length);
                n = "00000000000000000000000000000000000000000100000100000010000010000001000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002";
                rec = n.getBytes();
                niveis.addRecord(rec, 0, rec.length);
                n = "00000000000000000000000000000000000000000000000000000000111000000000000000000000000000000000000000000000001100011000000000000000000000000000000000000000000000000000000001";
                rec = n.getBytes();
                niveis.addRecord(rec, 0, rec.length);
                n = "00000000000000000000000000001000010000000100001000000010000100000001110011000000000000100000000000010000000000000000000000000000000000000000000000000000000000000000000001";
                rec = n.getBytes();
                niveis.addRecord(rec, 0, rec.length);
                n = "00000000000000000010000000000001000000000000100000000001111100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002";
                rec = n.getBytes();
                niveis.addRecord(rec, 0, rec.length);
            }
                                    
            niveis.closeRecordStore();
        } catch (Exception e) {
            System.err.println("Houve um problema a escrever dados!");
        }
    }
    
    //
    //  Apagar todo o conteudo do LayerManager e do Vector
    //  retornar o bónus e bonús activos pela personagem ao seu estado inicial
    //
    private void reset() {
        for (int i = 0; i < numSetas; i++) {
            lmgr.remove((SetaSprite)vecControlo.elementAt(i));
        }
        
        for (int y = numSetas; y < vecControlo.size(); y++) {
            lmgr.remove((BolaSprite)vecControlo.elementAt(y));
        }
        
        numBolas = numSetas = tickTack = 0;
        vecControlo.removeAllElements();
        bonus.setFrame(5);
        personagem.bonusActivo = BonusSprite.BONUS_NENHUM;
    }
    
    private Random rnd = new Random();
    
    private LayerManager lmgr = null;
    private TiledLayer background = null;
    private TiledLayer objectos = null;
    
    public PersonagemSprite personagem = null;
    public BonusSprite bonus = null;
    public Vector vecControlo = new Vector();
    
    private Image imgSeta = null;
    private Image imgBolaGrande = null;
    private Image imgBolaMedia = null;
    private Image imgBolaPequena = null;
    private Image imgBonus = null;
    private Image imgVitoria = null;
    private Image imgDerrota = null;
    private Image imgHihi = null;
    
    private Image mdir = null;
    private Image mesq = null;
    private Image parado = null;
    
    private Thread threadMain = null;
    
    private int numSetas = 0;
    private int numBolas = 0;
    private int tickTack = 0;
    private int nivelActual = 1;
    
    private boolean perdeu = false;
    private boolean baza = false;
    
    private int bonusTickTack = 0;
    private String tipoNiveis = "";
    
    private PangMidlet midlet = null;
    private PangMenu menu = null;
    
    private RecordStore niveis = null;
}
