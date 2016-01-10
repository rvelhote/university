using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace src_chat_servidor
{
    class InfoCliente
    {
        public String nickName;
        public Socket sktCli;
        public String estadoCliente;


        //
        //  Criar um novo cliente
        //      n: nickname
        //      ec: estado do cliente
        //      s: socket que está a ser utilizado nas comunicações
        //
        public void NovoCliente(String n, String ec, Socket s)
        {
            nickName = n;            
            estadoCliente = ec;
            sktCli = s;
        }
    }
}