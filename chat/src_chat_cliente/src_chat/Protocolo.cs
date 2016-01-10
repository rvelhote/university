using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace src_chat_cliente
{
    //
    //  A classe PROTOCOLO pega nas mensagens recebidas do servidor e filtra determinados campos para análise            
    //
    class Protocolo
    {

        //
        //  O comando a executar (ex: LOGIN, LOGOFF, MSG_PRIV)
        //
        //  Retorna ERRO_CMD caso o comando seja desconhecido
        //
        public String getComando(String msg)
        {
            int index = msg.IndexOf('|', 0, msg.Length);

            if (index > 0)
            {
                return msg.Substring(0, index);
            }

            return "ERRO_CMD";            
        }


        //
        //  Retorna o nome do utilizador a quem se destina a mensagem
        //  É utilizado em Conversações Privadas
        //   
        public String getNomeDestino(String msg)
        {
            return filtra("NOME_DESTINO=", msg);
        }


        //
        //  Retorna o Nome de Utilizador que realizou determinada operação
        //  (neste caso pode ser enviar uma mensagem (pub ou priv), fazer login ou logoff)
        //
        public String getNomeUtilizador(String msg)
        {
            return filtra("NOME_UTILIZADOR=", msg);
        }


        //
        //  Retorna a mensagem enviada
        //
        public String getMensagem(String msg)
        {
            return filtra("MENSAGEM=", msg);            
        }


        //
        //  Retorna o nome do ficheiro a enviar
        //
        public String getNomeFicheiro(String msg)
        {
            return filtra("NOME_FICHEIRO=", msg);
        }


        //
        //  Retorna o estado        
        //
        public string getEstado(String msg)
        {
            return filtra("ESTADO=", msg);
        }


        //
        //  Quando o utilizador faz login, recebe a lista de utilizadores do servidor
        //  Esta função filtra nome a nome cada utilizador
        //
        //  MSG está como ref porque queremos que o seu valor permaneça alterado quando sair da função
        //
        //  A string da lista de utilizadores é no seguinte formato
        //  # LISTA_U|NOME_UTILIZADOR=nome (estado),nome (estado)...|        
        //
        public String getListaUtilizadores(ref String msg)
        {
            String nome;
            int posInicioInfo = 0, posFimInfo = 0;

            msg = msg.Substring(posInicioInfo, (msg.Length - posInicioInfo));

            //  Sacar o nome do utilizador
            posInicioInfo = msg.IndexOf("=") + 1;
            posFimInfo = msg.IndexOf(",");

            //  Verificar se já foram todos os nome retirados
            if (posInicioInfo <= 0 || posFimInfo <= 0)
            {
                return null;
            }

            //  Guardar o nome
            nome = msg.Substring(posInicioInfo, posFimInfo - posInicioInfo);

            //  Remover o nome
            msg = msg.Remove(posInicioInfo, (posFimInfo + 1) - posInicioInfo);

            return nome;
        }


        //
        //  Retorna o que está entre os caracteres = e |
        //  Se tipo filtro for "NOME_UTILIZADOR" e na string msg estiver "...|NOME_UTILIZADOR=blabla|..."        
        //  esta função vai retornar blabla
        //
        private String filtra(String tipoFiltro, String msg)
        {
            String tmp;
            int posInicioInfo = 0, posFimInfo = 0;

            //  Sacar a String "NOME_UTILIZADOR=" da mensagem
            posInicioInfo = msg.IndexOf(tipoFiltro);
            tmp = msg.Substring(posInicioInfo, (msg.Length - posInicioInfo));

            //  Verificar as posições dos delimitadores
            posFimInfo = tmp.IndexOf("|");
            posInicioInfo = tmp.IndexOf("=") + 1;

            return tmp.Substring(posInicioInfo, posFimInfo - posInicioInfo);
        }


        //
        //  Correr o algoritmo de encriptação em msg
        //
        //  Funciona da seguinte forma:
        //  msg = abc
        //
        //  por cada caracter, retirar o seu equivalente numérico
        //  a = 20
        //  b = 21
        //  c = 22
        //
        //  Adicionar +1 a esse número e voltar a converter para caracter
        //  a = 20 -> 21 = b
        //  b = 21 -> 22 = c
        //  c = 22 -> 23 = d
        //
        //  A mensagem encriptada é: bcd
        //
        public String Encriptar(String msg)
        {
            String msgEncriptada = "";

            for (int i = 0; i < msg.Length; i++)
            {
                msgEncriptada += (char)((int)(msg[i] + 1));
            }

            return msgEncriptada;
        }


        //
        //  Correr o algoritmo de desencriptação em msg
        //
        //  Funciona da seguinte forma:
        //  msg = bcd
        //
        //  por cada caracter, retirar o seu equivalente numérico
        //  b = 21
        //  c = 22
        //  d = 23
        //
        //  Subtrair -1 a esse número e voltar a converter para caracter
        //  b = 21 -> 20 = a
        //  c = 22 -> 21 = b
        //  d = 23 -> 22 = c
        //
        //  A mensagem encriptada é: abc
        //
        public String Desencriptar(String msg)
        {
            String msgDesencriptada = "";

            for (int i = 0; i < msg.Length; i++)
            {
                msgDesencriptada += (char)((int)(msg[i] - 1));
            }

            return msgDesencriptada;
        }
    }
}
