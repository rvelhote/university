using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace src_chat_cliente
{
    //
    //  A classe cliente trata das comunicações cliente-servidor e de tudo que diz repeito ao utilizador    
    //
    public class Cliente
    {
        //  Dados do servidor
        private IPAddress enderecoIP;
        private int porta;

        //  Uma instância do formulário de chat para podermos mexer nos seus controlos a partir da classe
        private frmChat oChatPrincipal;
       
        //  Buffer para guardar as mensagens recebidas do servidor através do socket
        private Byte[] msg_recebida_skt = new Byte[4096];

        //  Lida com mensagens recebidas do servidor     
        private Protocolo protocolo = new Protocolo();

        //
        //  Informação sobre este cliente
        //
        //  #Nickname
        //  #Socket que está a utilizar para comunicar com o servidor
        //  #Estado Actual
        //  #Uma ArrayList com os chats privados que o utilizador tem abertos
        //
        public InfoCliente infoCliente = new InfoCliente();
        
        //  Delegate para podermos criar os tabs
        public delegate void NovoTabDelegate(String nome);



        //
        //  Construtor da classe
        //      ip: o IP do servidor
        //      p: porta
        //      c: um objecto do tipo frmChat para podermos alterar controlos do formulário a partir desta classe
        //
        public Cliente(String ip, int p, frmChat c)
        {
            enderecoIP = IPAddress.Parse(ip);
            porta = p;
            oChatPrincipal = c;                        
        }


        //
        //  Faz a ligação ao servidor
        //
        public void LigarAoServidor()
        {
            //  Criar o socket
            infoCliente.sktCliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //  Criar o IPEnpoint (Endereço do Servidor + Porta)
            IPEndPoint ligacao = new IPEndPoint(enderecoIP, porta);
            
            //
            //  ligacao = IPEndpoint AKA o servidor ao qual ligar
            //  new AsyncCallback(Ligar) = Função a chamar quando for tentada uma ligação
            //  infoCliente.sktCliente = o socket que vai fazer a ligação
            //
            infoCliente.sktCliente.BeginConnect(ligacao, new AsyncCallback(Ligar), infoCliente.sktCliente);            
        }


        //
        //  Quando nos ligamos ao servidor esta função é chamada
        //       
        private void Ligar(IAsyncResult iar)
        {
            //  Objecto que activou esta função
            Socket sktLigacaoServidor = (Socket)iar.AsyncState;            

            try
            {
                if (sktLigacaoServidor.Connected)
                {                    
                    //  Notificar o servidor de que fiz login                    
                    EnviarMensagens("LOGIN|" + "NOME_UTILIZADOR=" + infoCliente.nickName + "|PASSWORD=" + infoCliente.password + "|ESTADO=" + infoCliente.estadoCliente + "|");

                    //
                    //  Iniciar a escuta por mensagens no socket específicado
                    //  As mensagens recebidas vão ser guardadas no buffer "msg_recebida_skt" e esperar tratamento
                    infoCliente.sktCliente.BeginReceive(msg_recebida_skt, 0, msg_recebida_skt.Length, SocketFlags.None, new AsyncCallback(ReceberDados), infoCliente.sktCliente);
                }
                else
                {
                    oChatPrincipal.InserirNovaMensagem = "Não foi possível ligar ao servidor!";
                    oChatPrincipal.ActivarBotoes = true;
                }

            }

            //  Servidor desligado/inactivo
            catch (SocketException)
            {
                oChatPrincipal.InserirNovaMensagem = "Não foi possível ligar ao servidor!";
                oChatPrincipal.ActivarBotoes = true;                
            }            
        }


        //
        //  Terminar a recepção de dados e tratá-los
        //
        private void ReceberDados(IAsyncResult iar)
        {
            //  Socker que activou a recepção de dados
            Socket sktmsg_recebida = (Socket)iar.AsyncState;

            try
            {
                //  Verificar se, de facto, foi recebida alguma informação
                int qtd = sktmsg_recebida.EndReceive(iar);
                if (qtd > 0)
                {                    
                    //  Converter a mensagem para uma forma mais usável
                    String msg = protocolo.Desencriptar(Encoding.Unicode.GetString(msg_recebida_skt, 0, qtd));

                    //  Sacar o comando enviado pelo servidor
                    String cmd = protocolo.getComando(msg);

                    //  Um novo cliente fez login
                    if (cmd == "LOGIN")
                    {
                        oChatPrincipal.InserirNovoUtilizador = protocolo.getNomeUtilizador(msg) + protocolo.getEstado(msg);
                        oChatPrincipal.InserirNovaMensagem = "**" + protocolo.getNomeUtilizador(msg) + " entrou no chat!";
                    }

                    //  Um cliente abandonou o servidor
                    else if (cmd == "LOGOFF")
                    {
                        oChatPrincipal.InserirNovaMensagem = "**" + protocolo.getNomeUtilizador(msg) + " abandonou o chat!";
                        oChatPrincipal.RemoverUtilizador = protocolo.getNomeUtilizador(msg) + protocolo.getEstado(msg);
                    }

                    //  Um certo utilizador enviou uma mensagem para o chat público
                    else if (cmd == "MSG_PUB")
                    {
                        oChatPrincipal.InserirNovaMensagem = "[" + protocolo.getNomeUtilizador(msg) + "]# "
                                                        + protocolo.getMensagem(msg);
                    }

                    //  Um certo utilizador enviou uma mensagem privada para outro utilizador qualquer
                    else if (cmd == "MSG_PRIV")
                    {
                        //  Verificar se o cliente já tem um tab criado com o utilizador que enviou a mensagem
                        int ret = VerificarCliente(protocolo.getNomeUtilizador(msg));

                        //  Se não tiver, temos que criar um novo através de um delegate
                        if (ret == -1)
                        {
                            oChatPrincipal.Invoke(new NovoTabDelegate(oChatPrincipal.CriarNovoTab), protocolo.getNomeUtilizador(msg));

                            ((Tabs)infoCliente.arrayChatPrivado[infoCliente.numChatsPrivados - 1]).NovaMensagem =
                                                                    "[" + protocolo.getNomeUtilizador(msg) + "]# " + protocolo.getMensagem(msg);
                        }

                        //  Se tiver, é só colar lá a mensagem
                        else
                        {
                            ((Tabs)infoCliente.arrayChatPrivado[ret]).NovaMensagem = "[" + protocolo.getNomeUtilizador(msg) + "]# " + protocolo.getMensagem(msg);
                        }
                    }

                    //  Recepção da lista de utilizadores
                    else if (cmd == "LISTA_U")
                    {
                        String nome;

                        do
                        {
                            nome = protocolo.getListaUtilizadores(ref msg);

                            if (nome != null)
                            {
                                oChatPrincipal.InserirNovoUtilizador = nome;
                            }

                        } while (nome != null);
                    }


                    //  Acesso negado ao servidor. Provavelmente o nome de utilizador ou password estão errados ou já existe alguém lá
                    else if (cmd == "ACESSO_NEGADO")
                    {
                        oChatPrincipal.InserirNovaMensagem = "**" + protocolo.getMensagem(msg);
                        oChatPrincipal.ActivarBotoes = true;

                    }

                    // Acesso ao servidor aceite
                    else if (cmd == "LOGIN_OK")
                    {
                        oChatPrincipal.InserirNovaMensagem = "**Ligado ao servidor! (" + infoCliente.sktCliente.RemoteEndPoint.ToString() + ")";
                        oChatPrincipal.InserirNovoUtilizador = infoCliente.nickName + infoCliente.estadoCliente;
                        oChatPrincipal.Text = "#[" + infoCliente.nickName + "] ligado em " + infoCliente.sktCliente.RemoteEndPoint.ToString();
                    }

                    //  Avisar todos os utilizadores de que o estado de um certo utilizador foi alterado
                    //
                    else if (cmd == "ESTADO_ALTERADO")
                    {
                        oChatPrincipal.InserirNovaMensagem = "**" + protocolo.getNomeUtilizador(msg) + " alterou o estado para '" + protocolo.getEstado(msg) + "'";
                        oChatPrincipal.AlterarEstadoUtilizador = protocolo.getNomeUtilizador(msg) + " (" + protocolo.getEstado(msg) + ")";

                        //  Verificar se existe alguma janela activa
                        int ret = VerificarCliente(protocolo.getNomeUtilizador(msg));
                        if (ret != -1)
                        {
                            ((Tabs)infoCliente.arrayChatPrivado[ret]).AlterarEstadoUtilizador = "Estado de " + protocolo.getNomeUtilizador(msg) + ": '" + protocolo.getEstado(msg) + "'";
                        }
                    }

                    //  Erro. Alguém está a enviar mensagens que não estão de acordo com o protocolo
                    //
                    else if (cmd == "ERRO_CMD")
                    {
                        oChatPrincipal.InserirNovaMensagem = "**Foi recebido um comando inválido";
                    }

                    //  O servidor vai abaixo!
                    //
                    else if (cmd == "SERVIDOR_VAI_DESLIGAR")
                    {
                        oChatPrincipal.InserirNovaMensagem = "**O Servidor vai ser desligado!";
                        oChatPrincipal.Text = "Não estás ligado a nenhum servidor!";

                        infoCliente.sktCliente = null;
                        oChatPrincipal.ActivarBotoes = true;

                        int x = infoCliente.arrayChatPrivado.Count;

                        for (int i = 0; i < x; i++)
                        {
                            infoCliente.arrayChatPrivado.RemoveAt(i);
                        }

                        infoCliente.numChatsPrivados = 0;
                    }

                    //  O estado do utilizador
                    //
                    else if (cmd == "O_ESTADO_E")
                    {
                        int ret = VerificarCliente(protocolo.getNomeUtilizador(msg));
                        if (ret != -1)
                        {
                            ((Tabs)infoCliente.arrayChatPrivado[ret]).AlterarEstadoUtilizador = "Estado de " + protocolo.getNomeUtilizador(msg) + ": '" + protocolo.getEstado(msg) + "'";
                        }
                    }

                    //  Depois de tratarmos a informação recebida, retomar a escuta de mensagens
                    sktmsg_recebida.BeginReceive(msg_recebida_skt, 0, msg_recebida_skt.Length, SocketFlags.None, new AsyncCallback(ReceberDados), sktmsg_recebida);
                }
            }
            catch (SocketException)
            {
            }
            catch (ObjectDisposedException)
            {
            }
            catch (AccessViolationException)
            {
            }
        }


        //
        //  Verificar se já existe um TAB aberto com um certo utilizador
        //      nick: o nickname do utilizador a pesquisar
        //
        //  Retorna: -1 se não existir
        //           a posição correspondente na ArrayList se existir
        //
        public int VerificarCliente(String nick)
        {
            for (int i = 0; i < infoCliente.arrayChatPrivado.Count; i++)
            {
                if (((Tabs)infoCliente.arrayChatPrivado[i]).Text == nick)
                {
                    return i;
                }
            }
           
            return -1;            
        }


        //
        //  Enviar a mensagem através do socket
        //      msg: a mensagem a enviar
        //
        public void EnviarMensagens(String msg)
        {
            try
            {
                infoCliente.sktCliente.Send(Encoding.Unicode.GetBytes(protocolo.Encriptar(msg)));
            }
            catch (SocketException)
            {
                oChatPrincipal.InserirNovaMensagem = "Não foi possível enviar a mensagem porque não estás ligado ao servidor!";
            }
            catch (NullReferenceException)
            {
                oChatPrincipal.InserirNovaMensagem = "Não foi possível enviar a mensagem porque não estás ligado ao servidor!";
            }
        }


        //
        //  Terminar a ligação ao servidor
        //
        public void Desligar()
        {            
            if (infoCliente.sktCliente != null && infoCliente.sktCliente.Connected)
            {
                //  Neste caso, é enviada uma mensagem de LOGOFF para o servidor que tratará de desligar os respectivos sockets
                //  assim que receba esta mensagem
                EnviarMensagens("LOGOFF|" + "NOME_UTILIZADOR=" + infoCliente.nickName + "|ESTADO=" + infoCliente.estadoCliente + "|");
                
                infoCliente.sktCliente = null;
                oChatPrincipal.InserirNovaMensagem = "**Desligado do servidor!";
                oChatPrincipal.Text = "Não estás ligado a nenhum servidor!";
            }
        }


        //
        //  Eliminar o tab da ArrayList. Esta função é chamada quando escolhemos FECHAR no menu de contexto dos TABS
        //      nome: o nome do utilizador do qual estamos a fechar a janela privada
        //
        public void EliminarJanelaPrivada(String nome)
        {
            infoCliente.arrayChatPrivado.RemoveAt(VerificarCliente(nome));
            infoCliente.numChatsPrivados--;
        }


        //
        //  Alterar o estado do cliente
        //      estado: o novo estado
        //
        public void AlterarEstado(String estado)
        {
            oChatPrincipal.InserirNovaMensagem = "**Alteraste o teu estado para '" + estado + "'";
            oChatPrincipal.AlterarEstadoUtilizador = infoCliente.nickName + " (" + estado + ")";
            infoCliente.estadoCliente = " (" + estado + ")";
            EnviarMensagens("ESTADO_ALTERADO|ESTADO=" + estado + "|NOME_UTILIZADOR=" + infoCliente.nickName + "|");
        }
    }
}