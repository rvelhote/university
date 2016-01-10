using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;

namespace src_chat_servidor
{
    class BaseDeDados
    {
        private OleDbConnection LigacaoBD = null;
        private OleDbDataReader LeitorBD = null;


        //
        //  Ligar a Base de Dados
        //      locBD: A localização da base de dados no disco rígido (ou qualquer outro suporte)        
        //
        //  Retorna: true se a ligação foi bem sucedida
        //           false se a ligação falhou (provavelmente porque não existe ou não foi seleccionada uma BD)
        //
        public bool Ligar(String locBD)
        {
            try
            {
                LigacaoBD = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + locBD);
                LigacaoBD.Open();

                return true;
            }
            catch (OleDbException)
            {
                return false;
            }
        }


        //
        //  Desligar a Base de Dados
        //
        public void Desligar()
        {
            LigacaoBD.Close();
        }


        //
        //  Validar o Utilizador que se ligou ao servidor
        //      nome: O Nome de Utilizador
        //      pass: Password
        //  
        //  Retorna: true se o utilizador foi encontrado na Base de Dados e se a password estava correcta
        //           false se o utilizador não existe ou a password estava incorrecta
        //
        public bool ValidarUtilizador(String nome, String pass)
        {
            try
            {
                OleDbCommand cmdSQL = LigacaoBD.CreateCommand();
                cmdSQL.CommandText = "SELECT * FROM tabela_utilizadores_src";
                LeitorBD = cmdSQL.ExecuteReader();

                while (LeitorBD.Read())
                {
                    if (LeitorBD.GetString(0) == nome && LeitorBD.GetString(1) == pass)
                    {
                        return true;
                    }
                }
            }
            catch (OleDbException) { }
                
            return false;
            
        }
    }
}
