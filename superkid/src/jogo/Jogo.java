package jogo;

import java.io.IOException;
import java.util.Random;
import java.util.Vector;
import javax.microedition.lcdui.Font;
import javax.microedition.lcdui.Graphics;
import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.game.GameCanvas;

public class Jogo extends GameCanvas implements Runnable {
    
    private boolean acabouJogo = false;
    private Thread threadJogo;
    
    private Image fundoJogo;
    private Image iPersonagem;
    private Image iBala;
    private Image iMauzao;
    private Image iPlataforma;
    private Image iBonus;
    
    private Personagem personagem;
    private Vector vrutos = new Vector();
    private Vector bonus = new Vector();
    
    private int ecraX = 0;
    
    private int pontuacao = 0;
    private int nivel = 1;
    
    private Random r = new Random();
    
    public Jogo() {
        super(true);
        
        System.out.println(getHeight() + " - " + getWidth());
        
        carregarImagens();
        
        personagem = new Personagem(iPersonagem);
        carregarNivel();
        
        threadJogo = new Thread(this);
        threadJogo.start();
    }
    
    private void carregarNivel() {
        ecraX = 0;
        personagem.setPosition(0, 138);
        
        bonus.removeAllElements();
        vrutos.removeAllElements();
        
        try {
            fundoJogo = Image.createImage("/jogo/img/fundo.nivel." + nivel + ".png");
        } catch (IOException ex) {
            ex.printStackTrace();
        }
        
        disporBonus();
    }
    
    public void disporBonus() {
        int x = 0;
        int y = 0;
        int tipo;
        
        for(int i = 0; i < 10; i++) {
            x = r.nextInt(fundoJogo.getWidth());
            y = r.nextInt(100) + 28;
            
            tipo = (r.nextInt(100) == 0 && r.nextInt(1) == 0) ? Bonus.BONUS_HEALTH : Bonus.BONUS_PONTOS;
            
            bonus.addElement(new Bonus(iBonus, x, y, tipo));
        }
    }
    
    public void run() {
        while(!acabouJogo) {
            
            if(fimDoNivel()) {
                if(nivel++ != 3) {
                    carregarNivel();
                } else {
                    acabouJogo = true;
                }
            }
            
            teclas();
            desenharGraficos();
            
            if(apareceMauzao() && vrutos.size() < 2) {                                
                vrutos.addElement(new Mauzao(iMauzao, 1));
            }
            
            verificarObjectos();
            
            try {
                threadJogo.sleep(70);
            } catch (InterruptedException ex) {
                ex.printStackTrace();
            }
            
        }
    }
    
    private boolean fimDoNivel() {
        if(personagem.getX() >= 500) {
            return true;
        }
        
        return false;
    }
    
    private boolean apareceMauzao() {
        boolean aparece = false;
        
        if(r.nextInt(30) == 0) {
            aparece = true;
        }
        
        return aparece;
    }
    
    private void carregarImagens() {
        try {
            iPersonagem = Image.createImage("/jogo/img/personagem.png");
            iBala = Image.createImage("/jogo/img/bala.png");
            iMauzao = Image.createImage("/jogo/img/mauzao.png");
            iPlataforma = Image.createImage("/jogo/img/plataforma.png");
            iBonus = Image.createImage("/jogo/img/bonus.png");
            
            Mauzao.imagemBala = iBala;
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }
    
    private void colisoesBalas() {
        for(int i = 0; i < personagem.balas.size(); i++) {
            Bala b = (Bala)personagem.balas.elementAt(i);
            
            for(int j = 0; j < vrutos.size(); j++) {
                Mauzao m = (Mauzao)vrutos.elementAt(j);
                
                if(m.collidesWith(b, false)) {
                    m.health -= 50;
                    b.acabou = true;
                    pontuacao += 1;
                }
            }
        }
    }
    
    private void colisoesMauzoes() {
        for(int j = 0; j < vrutos.size(); j++) {
            Mauzao m = (Mauzao)vrutos.elementAt(j);
            
            if(m.collidesWith(personagem, false)) {
                personagem.health -= 1;
            }
        }
    }
    
    private void removerBalas() {
        for(int i = 0; i < personagem.balas.size(); i++) {
            Bala b = (Bala)personagem.balas.elementAt(i);
            
            if(b.acabou) {
                personagem.balas.removeElementAt(i);
                i--;
            }
        }
    }
    
    private void removerMauzoes() {
        for(int j = 0; j < vrutos.size(); j++) {
            Mauzao m = (Mauzao)vrutos.elementAt(j);
            
            if(m.morto || m.desapareceu) {
                
                if(m.morto) {
                    pontuacao += 75;
                }
                
                vrutos.removeElementAt(j);
                j--;
            }
        }
    }
    
    private void colisoesBonus() {
        for(int i = 0; i < bonus.size(); i++) {
            Bonus b = (Bonus)bonus.elementAt(i);
            
            if(personagem.collidesWith(b, true)) {
                
                if(b.tipoBonus == Bonus.BONUS_PONTOS) {
                    pontuacao += 100;
                } else {
                    personagem.health += 50;
                    
                    if(personagem.health > 100) {
                        personagem.health = 100;
                    }
                }
                
                bonus.removeElementAt(i);
                i--;
            }
        }
    }
    
    private void verificarObjectos() {
        colisoesMauzoes();
        colisoesBonus();
        colisoesBalas();
        removerBalas();
        removerMauzoes();
    }
    
    private void teclas() {
        int key = getKeyStates();
        
        if(key == GameCanvas.LEFT_PRESSED) {
            personagem.moveEsquerda();
            personagem.podeSaltar = false;
            
        } else if(key == GameCanvas.RIGHT_PRESSED) {
            
            if((personagem.getX() + personagem.getWidth()) >= (getWidth() / 2) && ecraX > -1640) {
                ecraX -= 10;
                moverBonus(-10);
                moveMauzoesEstaticos();
            } else if((personagem.getX() + personagem.getWidth()) < Constantes.LARGURA_ECRA) {
                personagem.moveDireita();
            }
            
            personagem.podeSaltar = false;
            
        } else if(key == GameCanvas.UP_PRESSED) {
            if(personagem.podeSaltar) {
                personagem.salta();
            }
            
        } else if(key == 288) { // disparar e andar
            
            if((personagem.getX() + personagem.getWidth()) >= (getWidth() / 2) && ecraX > -1640) {
                ecraX -= 10;
                moverBonus(-10);
                moveMauzoesEstaticos();
            } else if((personagem.getX() + personagem.getWidth()) < Constantes.LARGURA_ECRA) {
                personagem.moveDireita();
            }
            
            personagem.dispara(iBala);
            
        } else if(key == 0 && personagem.saltou) {
            personagem.podeSaltar = false;
            
        } else if(key == 34) {
            
            if((personagem.getX() + personagem.getWidth()) >= (getWidth() / 2) && ecraX > -1640) {
                ecraX -= 10;
                moverBonus(-10);
                moveMauzoesEstaticos();
            } else if((personagem.getX() + personagem.getWidth()) < Constantes.LARGURA_ECRA) {
                personagem.moveDireita();
            }
            
            if(personagem.podeSaltar) {
                personagem.salta();
            }
            
        } else if(key == 260) {
            personagem.moveEsquerda();
            personagem.dispara(iBala);
            
        } else if(key == 256) {
            personagem.dispara(iBala);
        }
        
        if(!personagem.podeSaltar) {
            personagem.desce(Constantes.CHAO);
        }
    }
        
    private void moveMauzoesEstaticos() {
        for(int j = 0; j < vrutos.size(); j++) {
            Mauzao m = (Mauzao)vrutos.elementAt(j);
            
            if(m.tipoMauzao == Mauzao.MAUZAO_ESTATICO) {
                m.move();
            }                        
        }
    }
    
    private void moverBonus(int q) {
        for(int i = 0; i < bonus.size(); i++) {
            Bonus b = (Bonus)bonus.elementAt(i);
            b.move(q);
        }
    }
    
    private void desenharGraficos() {
        Graphics g = getGraphics();
        
        g.drawImage(fundoJogo, ecraX, 0, 0);
        
        for(int i = 0; i < bonus.size(); i++) {
            Bonus b = (Bonus)bonus.elementAt(i);
            b.paint(g);
        }
        
        personagem.paint(g);
        
        for(int i = 0; i < personagem.balas.size(); i++) {
            Bala b = (Bala)personagem.balas.elementAt(i);
            b.paint(g);
        }
        
        for(int i = 0; i < vrutos.size(); i++) {
            Mauzao m = (Mauzao)vrutos.elementAt(i);
            
            if(m.disparou) {
                m.bala.paint(g);
            }
            
            m.paint(g);
        }
        
        g.setColor(255, 255, 255);
        g.setFont(Font.getFont(Font.FACE_PROPORTIONAL, Font.STYLE_BOLD, Font.SIZE_LARGE));
        
        g.drawString("Nível: " + nivel, 10, 5, 0);
        g.drawString("Health: " + personagem.health, 150, 5, 0);
        g.drawString("Vidas: " + personagem.vidas, 300, 5, 0);
        g.drawString("Pts: " + pontuacao, 450, 5, 0);
        
        flushGraphics();
    }
}
