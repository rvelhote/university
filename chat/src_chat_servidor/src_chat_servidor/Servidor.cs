using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.IO;
using System.Threading;


namespace src_chat_servidor
{
    public class Servidor
    {
        IPAddress enderecoIP;
        int porta;

        //  O socket que vai estar � escuta
        Socket sktServidor;        

        //  Vari�vel controladora do n�mero de clientes
        int numClientes = 0;        

        //  Para podermos aceder ao formul�rio a partir da classe
        frmServidor oFrmServidor;

        //  ArrayList que vai conter objectos do tupo InfoCliente
        //  Cada elemento da ArrayList corresponde a um cliente ligado ao servidor
        ArrayList arrayClientes = new ArrayList();
        
        //  Objecto que permite a utiliza��o da classe protocolo
        Protocolo protocolo = new Protocolo();

        //  Objecto que permite a utiliza��o da classe BaseDeDados
        BaseDeDados bd = new BaseDeDados();

        //  Vari�veis que v�o guardar a informa��o recebida no socket
        Byte[] msg_skt_buffer = new Byte[4096];
        int tam_msg_skt_buffer;




        //
        //  Construtor
        //      p: porta a utilizar
        //      frm: um objecto to tipo frmServidor para podermos alterar controlos no formul�rio a partir desta classe
        //
        public Servidor(int p, frmServidor frm)
        {            
            enderecoIP = IPAddress.Any;
            porta = p;

            //  Para podermos aceder aos controlos do formul�rio servidor
            oFrmServidor = frm;
        }


        //
        //  Inicia o servidor na porta seleccionada
        //
        public void IniciarServidor()
        {
            /*
             *      InterNetwork == IPV4
             *      Stream == Utilizar TCP
             *      TCP == Definir o protocolo a utilizar como TCP             
             */
            sktServidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //  "Colar" o socket na porta e no endere�oIP seleccionados
            sktServidor.Bind(new IPEndPoint(enderecoIP, porta));

            //  
            sktServidor.Listen(3);

            //  
            sktServidor.BeginAccept(new AsyncCallback(AceitarLigacao), null);

            //
            oFrmServidor.InserirNovaMensagem = "Servidor iniciado!";

            //  Ligar a base de dados
            if (!bd.Ligar(oFrmServidor.LocalizacaoBD))
            {
                //
                oFrmServidor.InserirNovaMensagem = "ERRO: A Base de Dados n�o foi inicializada! (provavelmente n�o foi escolhida uma ou n�o existe)";
                DesligarServidor();
            }
            else
            {
                //
                oFrmServidor.InserirNovaMensagem = "Base de Dados de utilizadores inicializada!";
            }

            oFrmServidor.InserirMensagemConsola = "Consola Iniciada!";

        }


        //
        //  Desliga o servidor e, como consequ�ncia, todos os clientes ligados e a base de dados
        //
        //  retorna: um valor (true ou false) a indicar se foi bem sucedido ou n�o a desligar o servidor
        //
        public bool DesligarServidor()
        {
            if (numClientes > 0)
            {
                for (int i = 0; i < arrayClientes.Count; i++)
                {
                    ((InfoCliente)arrayClientes[i]).sktCli.Send(Encoding.Unicode.GetBytes(protocolo.Encriptar("SERVIDOR_VAI_DESLIGAR|")));
                }

                for (int i = 0; i < arrayClientes.Count; i++)
                {
                    DesligarCliente(((InfoCliente)arrayClientes[i]).sktCli, false);
                }
            }
            
            sktServidor.Close(0);
            oFrmServidor.InserirNovaMensagem = "Servidor Desligado!";

            bd.Desligar();
            oFrmServidor.InserirNovaMensagem = "Base de Dados de utilizadores desligada!";

            return true;
        }


        //
        //  Quando um cliente se liga ao servidor esta fun��o � chamada
        //      iar: o objecto que "activou" a fun��o
        //
        private void AceitarLigacao(IAsyncResult iar)
        {
            try
            {

                arrayClientes.Add(new InfoCliente());

                //  Adicionar novo cliente ao ArrayList
                //  
                //  #Nome                
                //  #Estado
                //  #O socket a utilizar para realizar a comunica��o
                //
                ((InfoCliente)arrayClientes[numClientes]).NovoCliente("", "Online", sktServidor.EndAccept(iar));
                ((InfoCliente)arrayClientes[numClientes]).sktCli.BeginReceive(msg_skt_buffer, 0, msg_skt_buffer.Length, SocketFlags.None, new AsyncCallback(ReceberDados), ((InfoCliente)arrayClientes[numClientes]).sktCli);

                numClientes++;

                sktServidor.BeginAccept(new AsyncCallback(AceitarLigacao), null);
            }
            catch (SocketException)
            {
                oFrmServidor.InserirNovaMensagem = "Erro ao aceitar liga��o!";
            }
            catch (ObjectDisposedException)
            {
            }
            catch (AccessViolationException)
            {
            }

            
        }


        //
        //  Terminar a recep��o de dados e trat�-los
        //      iar: o objecto que "activou" a fun��o
        //  
        private void ReceberDados(IAsyncResult iar)
        {
            Socket sktRecebido = (Socket)iar.AsyncState;

            try
            {
                tam_msg_skt_buffer = sktRecebido.EndReceive(iar);
                if (tam_msg_skt_buffer > 0)
                {                    
                    String msg = protocolo.Desencriptar(Encoding.Unicode.GetString(msg_skt_buffer, 0, tam_msg_skt_buffer));
                    String cmd = protocolo.getComando(msg);

                    //  Consola
                    oFrmServidor.InserirMensagemConsola = System.Environment.NewLine + "#####";
                    oFrmServidor.InserirMensagemConsola = "Mensagem Encriptada: " + protocolo.Encriptar(msg) + System.Environment.NewLine + "Mensagem Desencriptada: " + msg;
                    oFrmServidor.InserirMensagemConsola = "Comando a Executar: " + cmd;


                    //  Actualizar os registos de utilizador no servidor e avisar os outros clientes ligados de que algu�m novo
                    //  se juntou ao chat
                    if (cmd == "LOGIN")
                    {

                        if (bd.ValidarUtilizador(protocolo.getNomeUtilizador(msg), protocolo.getPassword(msg)))
                        {
                            //  Se = null -> n�o est� ligado ao servidor portanto pode-se aceitar
                            if (RetornaSocketDeCliente(protocolo.getNomeUtilizador(msg)) == null)
                            {

                                ((InfoCliente)arrayClientes[RetornaClienteComSocket(sktRecebido)]).nickName = protocolo.getNomeUtilizador(msg);

                                oFrmServidor.InserirNovaMensagem = "Foi aceite uma nova liga��o de "
                                                                + protocolo.getNomeUtilizador(msg)
                                                                + " ("
                                                                + sktRecebido.RemoteEndPoint.ToString() + ")";

                                sktRecebido.Send(Encoding.Unicode.GetBytes(protocolo.Encriptar("LOGIN_OK|")));

                                getListaUtilizadores(sktRecebido, protocolo.getNomeUtilizador(msg));

                                EnviarMensagemParaTodos(msg, sktRecebido);

                                //
                                oFrmServidor.lblNumUtilizadores.Text = Convert.ToString(numClientes) + " Utilizadores";

                                //  Adicionar o cliente � list view
                                String[] inf = new String[50];
                                inf[0] = protocolo.getNomeUtilizador(msg); inf[1] = sktRecebido.RemoteEndPoint.ToString(); inf[2] = "Online";

                                oFrmServidor.lstviewUtilizadores.Items.Add(new ListViewItem(inf));
                            }

                            //  Liga��o duplicada
                            else
                            {
                                oFrmServidor.InserirNovaMensagem = "Foi recusada uma liga��o a "
                                                            + protocolo.getNomeUtilizador(msg)
                                                            + " ("
                                                            + sktRecebido.RemoteEndPoint.ToString() + ") -- Conta Duplicada";

                                sktRecebido.Send(Encoding.Unicode.GetBytes(protocolo.Encriptar("ACESSO_NEGADO|MENSAGEM=J� existe algu�m ligado com essa conta!|")));
                                DesligarCliente(sktRecebido, false);
                            }
                        }

                        //  Password/Nome Utilizador Incorrectos
                        else
                        {
                            oFrmServidor.InserirNovaMensagem = "Foi recusada uma liga��o a "
                                                            + protocolo.getNomeUtilizador(msg)
                                                            + " ("
                                                            + sktRecebido.RemoteEndPoint.ToString() + ") -- Password/Nome Utilizador Incorrectos";

                            sktRecebido.Send(Encoding.Unicode.GetBytes(protocolo.Encriptar("ACESSO_NEGADO|MENSAGEM=O acesso ao servidor foi negado porque o nome de utilizador ou password est�o incorrectos!|")));
                            DesligarCliente(sktRecebido, false);
                        }
                    }

                    //
                    //
                    else if (cmd == "LOGOFF")
                    {
                        for (int i = 0; i < oFrmServidor.lstviewUtilizadores.Items.Count; i++)
                        {
                            if (oFrmServidor.lstviewUtilizadores.Items[i].SubItems[0].Text == protocolo.getNomeUtilizador(msg))
                            {
                                oFrmServidor.lstviewUtilizadores.Items.RemoveAt(i);
                            }
                        }

                        //  Avisar os outros clientes de que algu�m se desligou e apagar o registo de utilizador do servidor                                                
                        EnviarMensagemParaTodos(msg, sktRecebido);
                        DesligarCliente(sktRecebido, true);

                        //
                        oFrmServidor.lblNumUtilizadores.Text = Convert.ToString(numClientes) + " Utilizadores";
                    }

                    //
                    //
                    else if (cmd == "MSG_PUB")
                    {
                        EnviarMensagemParaTodos(msg, sktRecebido);
                        oFrmServidor.InserirMensagemConsola = "Mensagem P�BLICA enviada por " + protocolo.getNomeUtilizador(msg);
                    }

                    //
                    //
                    else if (cmd == "MSG_PRIV")
                    {
                        EnviarMensagemParaUtilizador(protocolo.getNomeDestino(msg), msg);
                        oFrmServidor.InserirMensagemConsola = "Mensagem PRIVADA enviada por " + protocolo.getNomeUtilizador(msg) + " para " + protocolo.getNomeDestino(msg);
                    }

                    //
                    //
                    else if (cmd == "ESTADO_ALTERADO")
                    {
                        for (int i = 0; i < oFrmServidor.lstviewUtilizadores.Items.Count; i++)
                        {
                            if (oFrmServidor.lstviewUtilizadores.Items[i].SubItems[0].Text == protocolo.getNomeUtilizador(msg))
                            {
                                oFrmServidor.lstviewUtilizadores.Items[i].SubItems[2].Text = protocolo.getEstado(msg);
                            }
                        }

                        oFrmServidor.InserirMensagemConsola = protocolo.getNomeUtilizador(msg) + " alterou o seu estado para '" + protocolo.getEstado(msg) + "'";

                        ((InfoCliente)arrayClientes[RetornaClienteComSocket(sktRecebido)]).estadoCliente = protocolo.getEstado(msg);
                        EnviarMensagemParaTodos(msg, sktRecebido);
                    }
                                            

                    //
                    //
                    else if (cmd == "QUAL_O_ESTADO")
                    {
                        InfoCliente objTemp = RetornaObjectoCliente(protocolo.getNomeUtilizador(msg));

                        sktRecebido.Send(Encoding.Unicode.GetBytes(protocolo.Encriptar("O_ESTADO_E|NOME_UTILIZADOR=" + protocolo.getNomeUtilizador(msg) + "|ESTADO=" + objTemp.estadoCliente + "|")));
                    }


                    //  Erro. Algu�m est� a enviar mensagens que n�o est�o de acordo com o protocolo
                    //
                    else if (cmd == "ERRO_CMD")
                    {
                        oFrmServidor.InserirNovaMensagem = "**Foi recebido um comando inv�lido de " + sktRecebido.RemoteEndPoint.ToString();
                        DesligarCliente(sktRecebido, false);
                    }

                    //  Retomar a escuta de mensagens
                    sktRecebido.BeginReceive(msg_skt_buffer, 0, msg_skt_buffer.Length, SocketFlags.None, new AsyncCallback(ReceberDados), sktRecebido);
                }
            }
            catch (SocketException)
            {
                oFrmServidor.InserirNovaMensagem = "N�o foi poss�vel receber a mensagem";
            }
            catch (ObjectDisposedException)
            {

            }
        }


        //
        //  Desliga um cliente do servidor
        //      discoSkt: O socket a ser desligado
        //      mostraMsg: Se � escrito na janela do servidor a mensagem a indicar que o cliente se desligou. �s vezes n�o � necess�ria essa msg.
        //  
        private void DesligarCliente(Socket discoSkt, bool mostraMsg)
        {
            try
            {
                if (mostraMsg)
                {
                    oFrmServidor.InserirNovaMensagem = ((InfoCliente)arrayClientes[RetornaClienteComSocket(discoSkt)]).nickName
                                                    + " (" + discoSkt.RemoteEndPoint.ToString() + ") desligou-se do servidor!";
                }

                arrayClientes.RemoveAt(RetornaClienteComSocket(discoSkt));

                numClientes--;

                discoSkt.Shutdown(SocketShutdown.Both);
                discoSkt.Close();

                return;
            }
            catch (SocketException) { }
            catch (ArgumentOutOfRangeException) { }
        }


        //
        //  Com um determinado Socket ser� retornada a posi��o no arrayClientes a que corresponde o Socket.
        //      skt: Socket a pesquisar
        //
        //  retorna: uma posica��o no arrayClientes
        //
        private int RetornaClienteComSocket(Socket skt)
        {
            for (int i = 0; i < arrayClientes.Count; i++)
            {
                if (((InfoCliente)arrayClientes[i]).sktCli == skt)
                {
                    return i;
                }
            }

            return -1;
        }


        //
        //  Com um nome de cliente (definido por "nick") ser� retornado o Socket correspondente a esse cliente
        //      nick: nome a pesquisar
        //
        //  retorna: o socket que o cliente a pesquisar est� a utilizar nas comunica��es com o servidor
        //
        private Socket RetornaSocketDeCliente(String nick)
        {
            for (int i = 0; i < arrayClientes.Count; i++)
            {
                if (((InfoCliente)arrayClientes[i]).nickName.CompareTo(nick) == 0)
                {
                    return ((InfoCliente)arrayClientes[i]).sktCli;
                }
            }

            return null;
        }


        //
        //  Com o nickname do cliente obtemos o object correspondente na ArrayList
        //      nick: Nome do cliente a pesquisar
        //
        //  retorna: O Objecto correspondeste na ArrayList
        // 
        private InfoCliente RetornaObjectoCliente(String nick)
        {
            for (int i = 0; i < arrayClientes.Count; i++)
            {
                if (((InfoCliente)arrayClientes[i]).nickName.CompareTo(nick) == 0)
                {
                    return ((InfoCliente)arrayClientes[i]);
                }
            }

            return null;
        }


        //
        //  Envia uma mensagem para todos os utilizadores ligados ao servidor excepto o cliente que a provocou
        //      msg: a mensagem a enviar
        //      sktQueEnviou: o socket pertencente ao cliente que originalmente enviou a mensagem
        //
        private void EnviarMensagemParaTodos(String msg, Socket sktQueEnviou)
        {            
            for (int i = 0; i < arrayClientes.Count; i++)
            {
                if (((InfoCliente)arrayClientes[i]).sktCli != sktQueEnviou)
                {
                    ((InfoCliente)arrayClientes[i]).sktCli.Send(Encoding.Unicode.GetBytes(protocolo.Encriptar(msg)));                    
                }
            }
        }


        //
        //  Envia uma mensagem para um utilizador espec�fico (definido pela vari�vel "nick")
        //  O arrayClientes � pesquisado em busca do utilizador com esse nick
        //      nick: o nome de utilizador ao qual de destina a mensagem
        //      msg: a mensagem                        
        //
        private void EnviarMensagemParaUtilizador(String nick, String msg)
        {           
            for (int i = 0; i < arrayClientes.Count; i++)
            {
                if (nick == ((InfoCliente)arrayClientes[i]).nickName)
                {
                    ((InfoCliente)arrayClientes[i]).sktCli.Send(Encoding.Unicode.GetBytes(protocolo.Encriptar(msg)));                    
                }
            }
        }


        //
        //  Enviar a lista de utilizadores para o utilizador que acabou de fazer login
        //      skt: O socket que pediu a lista de utilizadores
        //      nome: o nome do utilizador que pediu a lista de utilizadores. serve para excluir esse utilizador da lista
        //
        private void getListaUtilizadores(Socket skt, String nome)
        {
            String str;

            str = "LISTA_U|NOME_UTILIZADOR=";

            for (int i = 0; i < arrayClientes.Count; i++)
            {
                if (((InfoCliente)arrayClientes[i]).nickName != nome)
                {
                    str += ((InfoCliente)arrayClientes[i]).nickName + " (" + ((InfoCliente)arrayClientes[i]).estadoCliente + "),";
                }
            }

            skt.Send(Encoding.Unicode.GetBytes(protocolo.Encriptar(str + "|")));
        }
    }
}
