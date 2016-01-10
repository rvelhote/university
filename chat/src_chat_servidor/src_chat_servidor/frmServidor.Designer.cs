namespace src_chat_servidor
{
    partial class frmServidor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLigarServidor = new System.Windows.Forms.Button();
            this.rtxtMensagens = new System.Windows.Forms.RichTextBox();
            this.btnDesligarServidor = new System.Windows.Forms.Button();
            this.lbMsgServidor = new System.Windows.Forms.Label();
            this.tabServidorPrincipal = new System.Windows.Forms.TabControl();
            this.tabpageServidor = new System.Windows.Forms.TabPage();
            this.tabpageConsola = new System.Windows.Forms.TabPage();
            this.rtxtConsola = new System.Windows.Forms.RichTextBox();
            this.tabpageOpcoes = new System.Windows.Forms.TabPage();
            this.gbServidor = new System.Windows.Forms.GroupBox();
            this.btnEscolherBD = new System.Windows.Forms.Button();
            this.txtLocalizacaoBD = new System.Windows.Forms.TextBox();
            this.lblLocBD = new System.Windows.Forms.Label();
            this.txtPortaServidor = new System.Windows.Forms.TextBox();
            this.lblPortaServidor = new System.Windows.Forms.Label();
            this.tabpageUtilizadores = new System.Windows.Forms.TabPage();
            this.gbListaUtilizadores = new System.Windows.Forms.GroupBox();
            this.lstviewUtilizadores = new System.Windows.Forms.ListView();
            this.chNickname = new System.Windows.Forms.ColumnHeader();
            this.chIP = new System.Windows.Forms.ColumnHeader();
            this.chEstado = new System.Windows.Forms.ColumnHeader();
            this.lblNumUtilizadores = new System.Windows.Forms.Label();
            this.ofdEscolherBD = new System.Windows.Forms.OpenFileDialog();
            this.tabServidorPrincipal.SuspendLayout();
            this.tabpageServidor.SuspendLayout();
            this.tabpageConsola.SuspendLayout();
            this.tabpageOpcoes.SuspendLayout();
            this.gbServidor.SuspendLayout();
            this.tabpageUtilizadores.SuspendLayout();
            this.gbListaUtilizadores.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLigarServidor
            // 
            this.btnLigarServidor.Location = new System.Drawing.Point(650, 20);
            this.btnLigarServidor.Name = "btnLigarServidor";
            this.btnLigarServidor.Size = new System.Drawing.Size(75, 23);
            this.btnLigarServidor.TabIndex = 0;
            this.btnLigarServidor.Text = "Ligar";
            this.btnLigarServidor.UseVisualStyleBackColor = true;
            this.btnLigarServidor.Click += new System.EventHandler(this.btnLigarServidor_Click);
            // 
            // rtxtMensagens
            // 
            this.rtxtMensagens.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtMensagens.Location = new System.Drawing.Point(6, 20);
            this.rtxtMensagens.Name = "rtxtMensagens";
            this.rtxtMensagens.ReadOnly = true;
            this.rtxtMensagens.Size = new System.Drawing.Size(638, 422);
            this.rtxtMensagens.TabIndex = 1;
            this.rtxtMensagens.Text = "";
            // 
            // btnDesligarServidor
            // 
            this.btnDesligarServidor.Enabled = false;
            this.btnDesligarServidor.Location = new System.Drawing.Point(650, 49);
            this.btnDesligarServidor.Name = "btnDesligarServidor";
            this.btnDesligarServidor.Size = new System.Drawing.Size(75, 23);
            this.btnDesligarServidor.TabIndex = 4;
            this.btnDesligarServidor.Text = "Desligar";
            this.btnDesligarServidor.UseVisualStyleBackColor = true;
            this.btnDesligarServidor.Click += new System.EventHandler(this.btnDesligarServidor_Click);
            // 
            // lbMsgServidor
            // 
            this.lbMsgServidor.AutoSize = true;
            this.lbMsgServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMsgServidor.Location = new System.Drawing.Point(3, 4);
            this.lbMsgServidor.Name = "lbMsgServidor";
            this.lbMsgServidor.Size = new System.Drawing.Size(75, 13);
            this.lbMsgServidor.TabIndex = 6;
            this.lbMsgServidor.Text = "Mensagens:";
            // 
            // tabServidorPrincipal
            // 
            this.tabServidorPrincipal.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabServidorPrincipal.Controls.Add(this.tabpageServidor);
            this.tabServidorPrincipal.Controls.Add(this.tabpageConsola);
            this.tabServidorPrincipal.Controls.Add(this.tabpageOpcoes);
            this.tabServidorPrincipal.Controls.Add(this.tabpageUtilizadores);
            this.tabServidorPrincipal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabServidorPrincipal.Location = new System.Drawing.Point(3, 4);
            this.tabServidorPrincipal.Name = "tabServidorPrincipal";
            this.tabServidorPrincipal.SelectedIndex = 0;
            this.tabServidorPrincipal.Size = new System.Drawing.Size(739, 474);
            this.tabServidorPrincipal.TabIndex = 10;
            // 
            // tabpageServidor
            // 
            this.tabpageServidor.Controls.Add(this.lbMsgServidor);
            this.tabpageServidor.Controls.Add(this.btnDesligarServidor);
            this.tabpageServidor.Controls.Add(this.rtxtMensagens);
            this.tabpageServidor.Controls.Add(this.btnLigarServidor);
            this.tabpageServidor.Location = new System.Drawing.Point(4, 4);
            this.tabpageServidor.Name = "tabpageServidor";
            this.tabpageServidor.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageServidor.Size = new System.Drawing.Size(731, 448);
            this.tabpageServidor.TabIndex = 0;
            this.tabpageServidor.Text = "Servidor";
            // 
            // tabpageConsola
            // 
            this.tabpageConsola.Controls.Add(this.rtxtConsola);
            this.tabpageConsola.Location = new System.Drawing.Point(4, 4);
            this.tabpageConsola.Name = "tabpageConsola";
            this.tabpageConsola.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageConsola.Size = new System.Drawing.Size(731, 448);
            this.tabpageConsola.TabIndex = 1;
            this.tabpageConsola.Text = "Consola";
            // 
            // rtxtConsola
            // 
            this.rtxtConsola.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtConsola.Location = new System.Drawing.Point(6, 6);
            this.rtxtConsola.Name = "rtxtConsola";
            this.rtxtConsola.ReadOnly = true;
            this.rtxtConsola.Size = new System.Drawing.Size(719, 436);
            this.rtxtConsola.TabIndex = 10;
            this.rtxtConsola.Text = "";
            // 
            // tabpageOpcoes
            // 
            this.tabpageOpcoes.Controls.Add(this.gbServidor);
            this.tabpageOpcoes.Location = new System.Drawing.Point(4, 4);
            this.tabpageOpcoes.Name = "tabpageOpcoes";
            this.tabpageOpcoes.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageOpcoes.Size = new System.Drawing.Size(731, 448);
            this.tabpageOpcoes.TabIndex = 3;
            this.tabpageOpcoes.Text = "Opções";
            // 
            // gbServidor
            // 
            this.gbServidor.Controls.Add(this.btnEscolherBD);
            this.gbServidor.Controls.Add(this.txtLocalizacaoBD);
            this.gbServidor.Controls.Add(this.lblLocBD);
            this.gbServidor.Controls.Add(this.txtPortaServidor);
            this.gbServidor.Controls.Add(this.lblPortaServidor);
            this.gbServidor.Location = new System.Drawing.Point(6, 6);
            this.gbServidor.Name = "gbServidor";
            this.gbServidor.Size = new System.Drawing.Size(719, 119);
            this.gbServidor.TabIndex = 1;
            this.gbServidor.TabStop = false;
            this.gbServidor.Text = "Servidor";
            // 
            // btnEscolherBD
            // 
            this.btnEscolherBD.AutoSize = true;
            this.btnEscolherBD.Location = new System.Drawing.Point(341, 70);
            this.btnEscolherBD.Name = "btnEscolherBD";
            this.btnEscolherBD.Size = new System.Drawing.Size(26, 23);
            this.btnEscolherBD.TabIndex = 4;
            this.btnEscolherBD.Text = "...";
            this.btnEscolherBD.UseVisualStyleBackColor = true;
            this.btnEscolherBD.Click += new System.EventHandler(this.btnEscolherBD_Click);
            // 
            // txtLocalizacaoBD
            // 
            this.txtLocalizacaoBD.BackColor = System.Drawing.SystemColors.Window;
            this.txtLocalizacaoBD.Location = new System.Drawing.Point(104, 70);
            this.txtLocalizacaoBD.Name = "txtLocalizacaoBD";
            this.txtLocalizacaoBD.ReadOnly = true;
            this.txtLocalizacaoBD.Size = new System.Drawing.Size(231, 21);
            this.txtLocalizacaoBD.TabIndex = 3;
            this.txtLocalizacaoBD.Text = "D:\\Ficheiros Ricardo\\Projectos\\SRC\\chat\\bd_src.mdb";
            // 
            // lblLocBD
            // 
            this.lblLocBD.AutoSize = true;
            this.lblLocBD.Location = new System.Drawing.Point(6, 73);
            this.lblLocBD.Name = "lblLocBD";
            this.lblLocBD.Size = new System.Drawing.Size(92, 13);
            this.lblLocBD.TabIndex = 2;
            this.lblLocBD.Text = "Base de Dados:";
            // 
            // txtPortaServidor
            // 
            this.txtPortaServidor.Location = new System.Drawing.Point(53, 32);
            this.txtPortaServidor.Name = "txtPortaServidor";
            this.txtPortaServidor.Size = new System.Drawing.Size(114, 21);
            this.txtPortaServidor.TabIndex = 1;
            this.txtPortaServidor.Text = "8080";
            // 
            // lblPortaServidor
            // 
            this.lblPortaServidor.AutoSize = true;
            this.lblPortaServidor.Location = new System.Drawing.Point(6, 35);
            this.lblPortaServidor.Name = "lblPortaServidor";
            this.lblPortaServidor.Size = new System.Drawing.Size(41, 13);
            this.lblPortaServidor.TabIndex = 0;
            this.lblPortaServidor.Text = "Porta:";
            // 
            // tabpageUtilizadores
            // 
            this.tabpageUtilizadores.Controls.Add(this.gbListaUtilizadores);
            this.tabpageUtilizadores.Location = new System.Drawing.Point(4, 4);
            this.tabpageUtilizadores.Name = "tabpageUtilizadores";
            this.tabpageUtilizadores.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageUtilizadores.Size = new System.Drawing.Size(731, 448);
            this.tabpageUtilizadores.TabIndex = 4;
            this.tabpageUtilizadores.Text = "Utilizadores";
            // 
            // gbListaUtilizadores
            // 
            this.gbListaUtilizadores.Controls.Add(this.lstviewUtilizadores);
            this.gbListaUtilizadores.Controls.Add(this.lblNumUtilizadores);
            this.gbListaUtilizadores.Location = new System.Drawing.Point(6, 6);
            this.gbListaUtilizadores.Name = "gbListaUtilizadores";
            this.gbListaUtilizadores.Size = new System.Drawing.Size(719, 436);
            this.gbListaUtilizadores.TabIndex = 0;
            this.gbListaUtilizadores.TabStop = false;
            this.gbListaUtilizadores.Text = "Lista de Utilizadores";
            // 
            // lstviewUtilizadores
            // 
            this.lstviewUtilizadores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNickname,
            this.chIP,
            this.chEstado});
            this.lstviewUtilizadores.Location = new System.Drawing.Point(6, 20);
            this.lstviewUtilizadores.Name = "lstviewUtilizadores";
            this.lstviewUtilizadores.Size = new System.Drawing.Size(707, 319);
            this.lstviewUtilizadores.TabIndex = 2;
            this.lstviewUtilizadores.UseCompatibleStateImageBehavior = false;
            this.lstviewUtilizadores.View = System.Windows.Forms.View.Details;
            // 
            // chNickname
            // 
            this.chNickname.Text = "Nickname";
            this.chNickname.Width = 300;
            // 
            // chIP
            // 
            this.chIP.Text = "IP:Porta";
            this.chIP.Width = 250;
            // 
            // chEstado
            // 
            this.chEstado.Text = "Estado";
            this.chEstado.Width = 150;
            // 
            // lblNumUtilizadores
            // 
            this.lblNumUtilizadores.AutoSize = true;
            this.lblNumUtilizadores.Location = new System.Drawing.Point(6, 342);
            this.lblNumUtilizadores.Name = "lblNumUtilizadores";
            this.lblNumUtilizadores.Size = new System.Drawing.Size(84, 13);
            this.lblNumUtilizadores.TabIndex = 1;
            this.lblNumUtilizadores.Text = "0 Utilizadores";
            // 
            // ofdEscolherBD
            // 
            this.ofdEscolherBD.Filter = ".mdb|*.mdb";
            this.ofdEscolherBD.Title = "Escolhe um ficheiro de Base De Dados";
            // 
            // frmServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 481);
            this.Controls.Add(this.tabServidorPrincipal);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(754, 510);
            this.MinimumSize = new System.Drawing.Size(754, 510);
            this.Name = "frmServidor";
            this.ShowIcon = false;
            this.Text = "Servidor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmServidor_FormClosed);
            this.Load += new System.EventHandler(this.frmServidor_Load);
            this.tabServidorPrincipal.ResumeLayout(false);
            this.tabpageServidor.ResumeLayout(false);
            this.tabpageServidor.PerformLayout();
            this.tabpageConsola.ResumeLayout(false);
            this.tabpageOpcoes.ResumeLayout(false);
            this.gbServidor.ResumeLayout(false);
            this.gbServidor.PerformLayout();
            this.tabpageUtilizadores.ResumeLayout(false);
            this.gbListaUtilizadores.ResumeLayout(false);
            this.gbListaUtilizadores.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLigarServidor;
        private System.Windows.Forms.RichTextBox rtxtMensagens;



        //
        //  Alterar controlos
        //
        public string InserirNovaMensagem
        {
            get
            {
                return rtxtMensagens.Text;
            }
            set
            {
                rtxtMensagens.AppendText(value + System.Environment.NewLine);

                rtxtMensagens.SelectionStart = rtxtMensagens.TextLength;
                rtxtMensagens.ScrollToCaret();                
            }
        }
        public string LocalizacaoBD
        {
            get
            {
                return txtLocalizacaoBD.Text;
            }
        }
        public string InserirMensagemConsola
        {
            set
            {
                //rtxtConsola.Text += (value + System.Environment.NewLine);
                rtxtConsola.AppendText(value + System.Environment.NewLine);

                rtxtConsola.SelectionStart = rtxtConsola.TextLength;
                rtxtConsola.ScrollToCaret();
            }
        }



        private System.Windows.Forms.Button btnDesligarServidor;
        private System.Windows.Forms.Label lbMsgServidor;
        private System.Windows.Forms.TabControl tabServidorPrincipal;
        private System.Windows.Forms.TabPage tabpageServidor;
        private System.Windows.Forms.TabPage tabpageConsola;
        private System.Windows.Forms.TabPage tabpageOpcoes;
        private System.Windows.Forms.GroupBox gbServidor;
        private System.Windows.Forms.TextBox txtPortaServidor;
        private System.Windows.Forms.Label lblPortaServidor;
        private System.Windows.Forms.RichTextBox rtxtConsola;
        private System.Windows.Forms.TabPage tabpageUtilizadores;
        private System.Windows.Forms.Label lblLocBD;
        private System.Windows.Forms.TextBox txtLocalizacaoBD;
        private System.Windows.Forms.GroupBox gbListaUtilizadores;
        private System.Windows.Forms.Button btnEscolherBD;
        private System.Windows.Forms.OpenFileDialog ofdEscolherBD;
        public System.Windows.Forms.Label lblNumUtilizadores;
        public System.Windows.Forms.ListView lstviewUtilizadores;
        private System.Windows.Forms.ColumnHeader chNickname;
        private System.Windows.Forms.ColumnHeader chIP;
        private System.Windows.Forms.ColumnHeader chEstado;
    }
}

