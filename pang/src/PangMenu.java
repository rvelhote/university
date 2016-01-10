import java.io.IOException;
import javax.microedition.lcdui.Canvas;
import javax.microedition.lcdui.Font;
import javax.microedition.lcdui.Graphics;
import javax.microedition.lcdui.Image;


public class PangMenu extends Canvas {
    private PangCanvas jogo = null;
    private EditorMapasCanvas editor = null;
    private PangMidlet midlet = null;
    
    private String[] opcoesMenu = { "Jogar", "Editor", "Ajuda" ,"Acerca", "Sair" };
    private String[] tipoNiveis = { "Oficial", "Utilizador", "Voltar" };
    
    private int opcaoActual = 0;
    private int ecraActual = 0;
    private int opSub = 0;
    
    private Image splash = null;    
    
    public PangMenu(PangMidlet m) {
        midlet = m;
        
        try {
            splash = Image.createImage("/graficos/splash.png");
        } catch(IOException e) {
            return;
        }
    }
    
    public void paint(Graphics g) {
        g.setColor(149, 149, 255);
        g.fillRect(0, 0, getWidth(), getHeight());
        
        if (ecraActual == 0) {
            mostrarSplash(g);
        } else if (ecraActual == 1) {
            mostrarTipoNiveis(g);
        } /*else if (ecraActual == 2) {
             mostrarTop(g);
        }*/ else if (ecraActual == 2) {
             mostrarAjuda(g);
        } else if (ecraActual == 3) {
            mostrarAcerca(g);
        } else if (ecraActual == 5){
            mostrarMenuPrincipal(g);
        }
    }
    
    private void mostrarSplash(Graphics g) {
        g.drawImage(splash, 8, 50, 0);
        g.setColor(0, 0, 0);
        g.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_MEDIUM));
        g.drawString("Carrega num botão para continuar", 25, 200, 0);
    }
    
    private void mostrarAcerca(Graphics g) {
        g.drawImage(splash, 8, 10, 0);
        g.setColor(0, 0, 0);
        g.setFont(Font.getFont(Font.FACE_PROPORTIONAL, Font.STYLE_BOLD, Font.SIZE_MEDIUM));
        g.drawString("Pang!", 5, 160, 0);
        g.drawString("Versão 1.0 (compilação 5324)", 5, 180, 0);
        g.drawString("Realizado por Ricardo Velhote", 5, 200, 0);
        g.drawString("CG 2006", 5, 240, 0);
    }
    
    private void mostrarAjuda(Graphics g) {
        g.drawImage(splash, 8, 10, 0);
        g.setColor(0, 0, 0);
        g.setFont(Font.getFont(Font.FACE_PROPORTIONAL, Font.STYLE_BOLD, Font.SIZE_MEDIUM));
        g.drawString("O objectivo é destruir todas as bolas antes", 1, 130, 0);
        g.drawString("de perder todas as vidas.", 1, 140, 0);
        g.drawString("Setas direccionais para mover o boneco.", 1, 160, 0);
        g.drawString("Enter para disparar a seta.", 1, 170, 0);
        g.drawString("Tecla 7 para activar a bomba.", 1, 180, 0);
        g.drawString("Durante o jogo poderão cair bónus que", 1, 200, 0);
        g.drawString("ajudarão a progredir no jogo ou a aumentar", 1, 210, 0);
        g.drawString("a pontuação.", 1, 220, 0);
        g.drawString("Para utilizar o editor basta utilizar as setas", 1, 240, 0);
        g.drawString("e carregar no Enter para colocar o objecto.", 1, 250, 0);
        g.drawString("Para sair e gravar: tecla 1; Apagar objecto: ", 1, 260, 0);
        g.drawString("tecla 7; Sair sem gravar: tecla 3.", 1, 270, 0);        
    }
    
    private void mostrarTipoNiveis(Graphics g) {
        g.drawImage(splash, 8, 10, 0);
        
        for(int i = 0; i < tipoNiveis.length; i++) {
            if (i == opSub) {
                g.setColor(0, 0, 0);
                g.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_LARGE));
                g.drawString(tipoNiveis[i], 100, 140 + (i * 25), 0);
            } else {
                g.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_MEDIUM));
                g.setColor(120, 120, 120);
                g.drawString(tipoNiveis[i], 100, 140 + (i * 25), 0);
            }
        }
    }
    
    private void mostrarTop(Graphics g) {
        g.drawImage(splash, 8, 10, 0);
        g.setColor(0, 0, 0);
        g.setFont(Font.getFont(Font.FACE_PROPORTIONAL, Font.STYLE_BOLD, Font.SIZE_MEDIUM));
    }
    
    private void mostrarMenuPrincipal(Graphics g) {
        g.drawImage(splash, 8, 10, 0);
        
        for(int i = 0; i < opcoesMenu.length; i++) {
            if (i == opcaoActual) {
                g.setColor(0, 0, 0);
                g.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_LARGE));
                g.drawString(opcoesMenu[i], 100, 140 + (i * 25), 0);
            } else {
                g.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_MEDIUM));
                g.setColor(120, 120, 120);
                g.drawString(opcoesMenu[i], 100, 140 + (i * 25), 0);
            }
        }
    }
    
    protected void keyPressed(int k) {
        if (getGameAction(k) == Canvas.UP) {
            if (ecraActual == 5 && --opcaoActual < 0) {
                opcaoActual = (opcoesMenu.length - 1);
            } else if (ecraActual == 1 && --opSub < 0) {
                opSub = (tipoNiveis.length - 1);
            }
                                    
            repaint();
        } else if (getGameAction(k) == Canvas.DOWN) {
            if (ecraActual == 5 && ++opcaoActual == opcoesMenu.length) {
                opcaoActual = 0;
            } else if (ecraActual == 1 && ++opSub == tipoNiveis.length) {
                opSub = 0;
            }
            
            repaint();
        } else if (getGameAction(k) == Canvas.FIRE) {
            
            //System.out.println(String.valueOf(ecraActual) + " " + String.valueOf(opSub));
            
            if (ecraActual != 5 && ecraActual != 1) {
                ecraActual = 5;
                repaint();
                
            } else if (opcaoActual == 0) {
                ecraActual = 1;
                opcaoActual = -1;
                opSub = 0;
                repaint();
                /*jogo = new PangCanvas(midlet, this);
                jogo.initJogo();
                midlet.display.setCurrent(jogo);*/
                
            } else if (opcaoActual == 1) {
                editor = new EditorMapasCanvas(midlet, this);
                editor.initEditor();
                midlet.display.setCurrent(editor);                                
                
            } /*else if (opcaoActual == 2) {
                ecraActual = opcaoActual;
                repaint();
                
            }*/ else if (opcaoActual == 2) {
                ecraActual = opcaoActual;
                repaint();
                
            } else if (opcaoActual == 3) {
                ecraActual = opcaoActual;
                repaint();
                
            } else if (opcaoActual == 4) {
                midlet.notifyDestroyed();
                
            } else if (ecraActual == 1 && opSub == 0) {
                jogo = new PangCanvas(midlet, this, "niveis.pang");
                jogo.initJogo();
                midlet.display.setCurrent(jogo);
            } else if (ecraActual == 1 && opSub == 1) {
                jogo = new PangCanvas(midlet, this, "niveis_u.pang");
                jogo.initJogo();
                midlet.display.setCurrent(jogo);
            } else if (ecraActual == 1 && opSub == 2) {
                ecraActual = 5;
                opcaoActual = 0;
                repaint();
            }
        }
    }
}
