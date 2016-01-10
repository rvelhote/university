using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Collections;

namespace src_chat_cliente
{
    /*
     *      Classe que contém dados do cliente actual 
     */
    public class InfoCliente
    {
        //  Nickname
        public String nickName;

        //  Password
        public String password;

        //  Socket que está a ser utlizado para comunicar com o servidor
        public Socket sktCliente;

        //  Estado actual (ex: Ausente, Online)
        public String estadoCliente;

        //  ArrayList que vai guardar os tabs de conversação privada que o utilizador tem abertos com outros utilizadores
        public ArrayList arrayChatPrivado = new ArrayList();

        //  Variável de controlo de Tabs Privados
        public int numChatsPrivados = 0;
    }
}
