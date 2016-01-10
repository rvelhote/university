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
using System.Collections;

namespace src_chat_cliente
{
    public partial class frmChat : Form
    {
        //  Um novo objecto da classe Cliente
        private Cliente cliente;



        //
        //  DoubleClick num elemento da lista de utilizadores evoca esta função
        //  Neste caso, vamos criar um novo TAB (conversa privada) com o utilizador seleccionado
        //
        public void lstUtilizadoresPublico_DoubleClick(object sender, EventArgs e)
        {
            if (lstUtilizadoresPublico.SelectedItem != null)
            {
                String nome = Convert.ToString(lstUtilizadoresPublico.SelectedItem);
                nome = nome.Substring(0, nome.IndexOf("(") - 1);

                if (
                    //  Não pode ser o próprio
                    nome != cliente.infoCliente.nickName

                    //  Verificar se já existe um TAB aberto com o utilizador seleccionado
                    && cliente.VerificarCliente(nome) == -1)
                {

                    CriarNovoTab(nome);

                    //  Auto-Seleccionar o tab que acabamos de abrir
                    //  TabOps é uma propriedade que está definida em frmChat.Designer.cs
                    //
                    AutoSeleccionaTab = AutoSeleccionaTab;
                }

            }
        }


        //
        //  Função que cria um novo TAB
        //      nome: o nome do TAB. Corresponde ao nome de utilizador com o qual abrimos o TAB
        //    
        public void CriarNovoTab(String nome)
        {
            //  Adicionar o objecto à ArrayList
            cliente.infoCliente.arrayChatPrivado.Add(new Tabs(cliente));

            //  Aceder às propriedados do objecto criado a partir da ArrayList
            //  Cast para podermos utilizar as propriedades da classe Tabs
            ((Tabs)cliente.infoCliente.arrayChatPrivado[cliente.infoCliente.numChatsPrivados]).Text = nome;           

            //  Adicionar o novo tab ao container principal de tabs
            this.NovoChatPrivado = ((Tabs)cliente.infoCliente.arrayChatPrivado[cliente.infoCliente.numChatsPrivados]);

            cliente.EnviarMensagens("QUAL_O_ESTADO|NOME_UTILIZADOR=" + nome + "|NOME_DESTINO=" + cliente.infoCliente.nickName + "|");

            cliente.infoCliente.numChatsPrivados++;
        }


        //
        //  Enviar uma mensagem para o chat público quando carregamos no BOTÃO ENVIAR
        //
        private void btnEnviarMsgPublico_Click(object sender, EventArgs e)
        {            
            if (txtMsgPublico.Text.Length != 0)
            {
                rtxtChatPublico.AppendText("[" + cliente.infoCliente.nickName + "]# " + txtMsgPublico.Text + System.Environment.NewLine);
                
                cliente.EnviarMensagens("MSG_PUB|NOME_UTILIZADOR=" + cliente.infoCliente.nickName + "|MENSAGEM=" + txtMsgPublico.Text + "|");

                //  Auto-Scroll
                rtxtChatPublico.SelectionStart = rtxtChatPublico.TextLength;
                rtxtChatPublico.ScrollToCaret();   
                
                //txtMsgPublico.Focus();
                txtMsgPublico.ResetText();
            }
        }


        //
        //  Enviar uma mensagem para o chat público quando carregamos na TECLA ENTER
        //
        private void txtMsgPublico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMsgPublico.Text.Length != 0 && e.KeyChar == Convert.ToChar(Keys.Return) && cliente !=  null)
            {
                //  Dizer ao compilador para ignorar o ENTER (não o colocar na textbox)
                e.Handled = true;

                rtxtChatPublico.AppendText("[" + cliente.infoCliente.nickName + "]# " + txtMsgPublico.Text + System.Environment.NewLine);                
                cliente.EnviarMensagens("MSG_PUB|NOME_UTILIZADOR=" + cliente.infoCliente.nickName + "|MENSAGEM=" + txtMsgPublico.Text + "|");

                //  Auto-Scroll
                rtxtChatPublico.SelectionStart = rtxtChatPublico.TextLength;
                rtxtChatPublico.ScrollToCaret();

                //txtMsgPublico.Focus();
                txtMsgPublico.ResetText();
            }
        }


        //  
        //  Fechar um TAB
        //
        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            //  Só é permitido fechar TABs de conversação privada
            if (tabPrincipal.SelectedTab.Text != "@the.bench"  && tabPrincipal.SelectedTab.Text != "Opções")
            {
                cliente.EliminarJanelaPrivada(tabPrincipal.SelectedTab.Text);

                tabPrincipal.Controls.Remove(tabPrincipal.SelectedTab);                
            }            
        }


        //
        //  Fazer LOGIN no servidor
        //
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtNomeUtilizador.Text.Length == 0 || txtPorta.Text.Length == 0 || txtEnderecoServidor.Text.Length == 0 || msktxtPassword.Text.Length == 0)
            {
                MessageBox.Show("Assim não dá!", "Ooops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }           

            //  Invocar o construtor
            cliente = new Cliente(txtEnderecoServidor.Text, Convert.ToInt16(txtPorta.Text), this);

            //  Actualizar infoCliente com as cenas seleccionada nas Opções
            cliente.infoCliente.nickName = txtNomeUtilizador.Text;
            cliente.infoCliente.password = msktxtPassword.Text;
            cliente.infoCliente.estadoCliente = " (Online)";

            //  Ligar
            cliente.LigarAoServidor();
                                    
            //  Ao fazer login passar automaticamente para o TAB do chat principal
            tabPrincipal.SelectedIndex = 0;

            //  Desactivar inserção de dados
            txtNomeUtilizador.Enabled = false;
            txtEnderecoServidor.Enabled = false;
            txtPorta.Enabled = false;
            msktxtPassword.Enabled = false;
            btnLogin.Visible = false;

            btnLogoff.Visible = true;
        }


        //
        //  Limpa todas as mensagens recebidas
        //
        private void limparToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimparChat = true;
        }


        //
        //  Faz LOGOFF do utilizador quando se carrega no botão
        //
        private void btnLogoff_Click(object sender, EventArgs e)
        {
            if (cliente != null)
            {
                cliente.Desligar();

                btnLogoff.Visible = false;

                txtNomeUtilizador.Enabled = true;
                txtEnderecoServidor.Enabled = true;
                txtPorta.Enabled = true;
                msktxtPassword.Enabled = true;
                btnLogin.Visible = true;

                this.lstUtilizadoresPublico.Items.Clear();
            }
        }


        //
        //  Cria um novo TAB através de um clique com o botão direito no nome do utilizador
        //
        private void abrirTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstUtilizadoresPublico.SelectedItem != null)
            {
                String nome = Convert.ToString(lstUtilizadoresPublico.SelectedItem);
                nome = nome.Substring(0, nome.IndexOf("(") - 1);

                if (
                    //  Não pode ser o próprio
                    nome != cliente.infoCliente.nickName

                    //  Verificar se já existe um TAB aberto com o utilizador seleccionado
                    && cliente.VerificarCliente(nome) == -1)
                {

                    CriarNovoTab(nome);

                    //  Auto-Seleccionar o tab que acabamos de abrir
                    //  TabOps é uma propriedade que está definida em frmChat.Designer.cs
                    //
                    AutoSeleccionaTab = AutoSeleccionaTab;
                }

            }
        }


        //
        // O utilizador fez logoff através do menu do botão direito
        //
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cliente != null)
            {
                cliente.Desligar();

                btnLogoff.Visible = false;

                txtNomeUtilizador.Enabled = true;
                txtEnderecoServidor.Enabled = true;
                txtPorta.Enabled = true;
                msktxtPassword.Enabled = true;
                btnLogin.Visible = true;

                lstUtilizadoresPublico.Items.Clear();
            }
        }


        //  
        //  Alterar o estado do utilizador através do botão direito do rato
        //
        private void onlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cliente.AlterarEstado("Online");
        }
        private void almocoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cliente.AlterarEstado("Almoço");
        }
        private void jantarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cliente.AlterarEstado("Jantar");
        }
        private void voltojaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            cliente.AlterarEstado("Volto Já");
        }
        private void ausenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cliente.AlterarEstado("Ausente");
        }


        //
        //  O construtor do formulário. Inicializa os seus controlos
        //
        public frmChat()
        {
            InitializeComponent();
        }


        //
        //  Carregamos no X
        //  Desligar o cliente do servidor
        //
        private void frmChatPublico_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cliente != null)
            {
                cliente.Desligar();
            }
        }


        //
        //  Ao carregar o formulário
        //
        private void frmChatPublico_Load(object sender, EventArgs e)
        {
            //  pfff
            Control.CheckForIllegalCrossThreadCalls = false;

            //  Auto-Seleccionar o TAB opções ao iniciar o programa
            tabPrincipal.SelectedIndex = 1;
        }

    }
}