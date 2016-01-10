using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace src_chat_cliente
{
    //
    //  A classe TABS serve para individualizar cada conversação privada     
    //  Extende de TabPage para podermos utilizar as mesmas funcionalides
    //
    public class Tabs : TabPage
    {
        //
        //  Controlos que fazem parte do TAB
        //
        private TextBox txtMsgPrivado = new TextBox();
        private RichTextBox rtxtChatPrivado = new RichTextBox();
        private PictureBox picOutroUtilizador = new PictureBox();
        private Button btnEnviarMsgPrivado = new Button();
        private Label lblEstado = new Label();


        //
        //  Para podermos utilizar a classe cliente aqui
        //
        private Cliente clientePrivado;



        //
        //  Inicializar o novo Tab
        //      cli: um objecto do tipo Cliente para podermos utilizar a classe aqui
        //
        public Tabs(Cliente cli)
        {
            clientePrivado = cli;

            this.txtMsgPrivado.Location = new System.Drawing.Point(3, 575);
            this.txtMsgPrivado.Multiline = true;
            this.txtMsgPrivado.Name = "txtMsgPrivado";
            this.txtMsgPrivado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgPrivado.Size = new System.Drawing.Size(859, 47);
            this.txtMsgPrivado.TabIndex = 19;
            this.txtMsgPrivado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMsgPrivado_KeyPress);

            this.rtxtChatPrivado.Location = new System.Drawing.Point(3, 19);
            this.rtxtChatPrivado.Name = "rtxtChatPrivado";
            this.rtxtChatPrivado.Size = new System.Drawing.Size(859, 550);
            this.rtxtChatPrivado.TabIndex = 18;
            this.rtxtChatPrivado.Text = "";

            this.btnEnviarMsgPrivado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarMsgPrivado.Location = new System.Drawing.Point(868, 575);
            this.btnEnviarMsgPrivado.Name = "btnEnviarMsgPrivado";
            this.btnEnviarMsgPrivado.Size = new System.Drawing.Size(75, 47);
            this.btnEnviarMsgPrivado.TabIndex = 16;
            this.btnEnviarMsgPrivado.Text = "Enviar";
            this.btnEnviarMsgPrivado.UseVisualStyleBackColor = true;
            this.btnEnviarMsgPrivado.Click += new System.EventHandler(this.EnviarMensagemPrivada_click);

            this.lblEstado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(3, 3);
            this.lblEstado.Size = new System.Drawing.Size(220, 13);
            this.lblEstado.Text = "Estado do Utilizador: ";
            this.lblEstado.Name = "lblEstado";

            this.Controls.Add(lblEstado);
            this.Controls.Add(txtMsgPrivado);
            this.Controls.Add(rtxtChatPrivado);
            this.Controls.Add(btnEnviarMsgPrivado);

            this.Text = clientePrivado.infoCliente.nickName;
        }


        //
        //  Envia a mensagem escrita em txtMsgPrivado para o utilizador quando se carrega no botão ENVIAR
        //
        private void EnviarMensagemPrivada_click(object sender, EventArgs e)
        {
            if (txtMsgPrivado.Text.Length != 0)
            {
                rtxtChatPrivado.AppendText("[" + clientePrivado.infoCliente.nickName + "]# " + txtMsgPrivado.Text + System.Environment.NewLine);

                clientePrivado.EnviarMensagens("MSG_PRIV|NOME_UTILIZADOR=" + clientePrivado.infoCliente.nickName +
                                                     "|NOME_DESTINO=" + this.Text +
                                                     "|MENSAGEM=" + txtMsgPrivado.Text + "|");

                rtxtChatPrivado.SelectionStart = rtxtChatPrivado.TextLength;
                rtxtChatPrivado.ScrollToCaret();
                //rtxtChatPrivado.Focus();
                txtMsgPrivado.ResetText();
                //txtMsgPrivado.Focus();
            }
        }


        //
        //  Envia a mensagem escrita em txtMsgPrivado para o utilizador quando se carrega na tecla ENTER
        //
        private void txtMsgPrivado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMsgPrivado.Text.Length != 0 && e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = true;

                rtxtChatPrivado.AppendText("[" + clientePrivado.infoCliente.nickName + "]# " + txtMsgPrivado.Text + System.Environment.NewLine);

                clientePrivado.EnviarMensagens("MSG_PRIV|NOME_UTILIZADOR=" + clientePrivado.infoCliente.nickName +
                                                 "|NOME_DESTINO=" + this.Text +
                                                 "|MENSAGEM=" + txtMsgPrivado.Text + "|");


                rtxtChatPrivado.SelectionStart = rtxtChatPrivado.TextLength;
                rtxtChatPrivado.ScrollToCaret();
                //rtxtChatPrivado.Focus();
                txtMsgPrivado.ResetText();
                //txtMsgPrivado.Focus();
            }
        }


        //
        //  Propriedades da classe para podermos alterar o conteúdo dos controlos (que são privados)
        //
        public String NovaMensagem
        {
            set
            {
                rtxtChatPrivado.AppendText(value + System.Environment.NewLine);

                rtxtChatPrivado.SelectionStart = rtxtChatPrivado.TextLength;
                rtxtChatPrivado.ScrollToCaret();

                /*rtxtChatPrivado.Focus();                
                txtMsgPrivado.Focus();*/
            }
        }
        public String AlterarEstadoUtilizador
        {
            set
            {
                lblEstado.Text = value;
            }
        }

    }
}
