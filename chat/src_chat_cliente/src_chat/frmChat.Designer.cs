namespace src_chat_cliente
{
    partial class frmChat
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
            this.components = new System.ComponentModel.Container();
            this.btnEnviarMsgPublico = new System.Windows.Forms.Button();
            this.lstUtilizadoresPublico = new System.Windows.Forms.ListBox();
            this.contextListaUtilizadoresPublico = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rtxtChatPublico = new System.Windows.Forms.RichTextBox();
            this.contextChatTexto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.limparToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alterarEstadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.almocoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jantarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.voltojaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ausenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtMsgPublico = new System.Windows.Forms.TextBox();
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.contextTabs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabpageChatPublico = new System.Windows.Forms.TabPage();
            this.tabpageOpcoes = new System.Windows.Forms.TabPage();
            this.gbUtilizador = new System.Windows.Forms.GroupBox();
            this.btnLogoff = new System.Windows.Forms.Button();
            this.msktxtPassword = new System.Windows.Forms.MaskedTextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtNomeUtilizador = new System.Windows.Forms.TextBox();
            this.lblNomeUtilizador = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.gbServidor = new System.Windows.Forms.GroupBox();
            this.txtEnderecoServidor = new System.Windows.Forms.TextBox();
            this.txtPorta = new System.Windows.Forms.TextBox();
            this.lblPortaServidor = new System.Windows.Forms.Label();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.contextListaUtilizadoresPublico.SuspendLayout();
            this.contextChatTexto.SuspendLayout();
            this.tabPrincipal.SuspendLayout();
            this.contextTabs.SuspendLayout();
            this.tabpageChatPublico.SuspendLayout();
            this.tabpageOpcoes.SuspendLayout();
            this.gbUtilizador.SuspendLayout();
            this.gbServidor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEnviarMsgPublico
            // 
            this.btnEnviarMsgPublico.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarMsgPublico.Location = new System.Drawing.Point(831, 562);
            this.btnEnviarMsgPublico.Name = "btnEnviarMsgPublico";
            this.btnEnviarMsgPublico.Size = new System.Drawing.Size(112, 60);
            this.btnEnviarMsgPublico.TabIndex = 0;
            this.btnEnviarMsgPublico.Text = "Enviar";
            this.btnEnviarMsgPublico.UseVisualStyleBackColor = true;
            this.btnEnviarMsgPublico.Click += new System.EventHandler(this.btnEnviarMsgPublico_Click);
            // 
            // lstUtilizadoresPublico
            // 
            this.lstUtilizadoresPublico.ContextMenuStrip = this.contextListaUtilizadoresPublico;
            this.lstUtilizadoresPublico.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstUtilizadoresPublico.FormattingEnabled = true;
            this.lstUtilizadoresPublico.HorizontalScrollbar = true;
            this.lstUtilizadoresPublico.Location = new System.Drawing.Point(831, 6);
            this.lstUtilizadoresPublico.Name = "lstUtilizadoresPublico";
            this.lstUtilizadoresPublico.Size = new System.Drawing.Size(112, 550);
            this.lstUtilizadoresPublico.TabIndex = 2;
            this.lstUtilizadoresPublico.DoubleClick += new System.EventHandler(this.lstUtilizadoresPublico_DoubleClick);
            // 
            // contextListaUtilizadoresPublico
            // 
            this.contextListaUtilizadoresPublico.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirTabToolStripMenuItem});
            this.contextListaUtilizadoresPublico.Name = "contextMenuStrip1";
            this.contextListaUtilizadoresPublico.Size = new System.Drawing.Size(130, 26);
            // 
            // abrirTabToolStripMenuItem
            // 
            this.abrirTabToolStripMenuItem.Name = "abrirTabToolStripMenuItem";
            this.abrirTabToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.abrirTabToolStripMenuItem.Text = "Abrir Tab";
            this.abrirTabToolStripMenuItem.Click += new System.EventHandler(this.abrirTabToolStripMenuItem_Click);
            // 
            // rtxtChatPublico
            // 
            this.rtxtChatPublico.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtChatPublico.ContextMenuStrip = this.contextChatTexto;
            this.rtxtChatPublico.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtChatPublico.Location = new System.Drawing.Point(3, 6);
            this.rtxtChatPublico.Name = "rtxtChatPublico";
            this.rtxtChatPublico.ReadOnly = true;
            this.rtxtChatPublico.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtxtChatPublico.Size = new System.Drawing.Size(822, 550);
            this.rtxtChatPublico.TabIndex = 13;
            this.rtxtChatPublico.Text = "";
            // 
            // contextChatTexto
            // 
            this.contextChatTexto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.limparToolStripMenuItem,
            this.toolStripSeparator1,
            this.logoutToolStripMenuItem,
            this.alterarEstadoToolStripMenuItem});
            this.contextChatTexto.Name = "contextChatTexto";
            this.contextChatTexto.Size = new System.Drawing.Size(174, 76);
            // 
            // limparToolStripMenuItem
            // 
            this.limparToolStripMenuItem.Name = "limparToolStripMenuItem";
            this.limparToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.limparToolStripMenuItem.Text = "Limpar Mensagens";
            this.limparToolStripMenuItem.Click += new System.EventHandler(this.limparToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // alterarEstadoToolStripMenuItem
            // 
            this.alterarEstadoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlineToolStripMenuItem,
            this.almocoToolStripMenuItem,
            this.jantarToolStripMenuItem1,
            this.voltojaToolStripMenuItem2,
            this.ausenteToolStripMenuItem});
            this.alterarEstadoToolStripMenuItem.Name = "alterarEstadoToolStripMenuItem";
            this.alterarEstadoToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.alterarEstadoToolStripMenuItem.Text = "Alterar Estado";
            // 
            // onlineToolStripMenuItem
            // 
            this.onlineToolStripMenuItem.Name = "onlineToolStripMenuItem";
            this.onlineToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.onlineToolStripMenuItem.Text = "Online";
            this.onlineToolStripMenuItem.Click += new System.EventHandler(this.onlineToolStripMenuItem_Click);
            // 
            // almocoToolStripMenuItem
            // 
            this.almocoToolStripMenuItem.Name = "almocoToolStripMenuItem";
            this.almocoToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.almocoToolStripMenuItem.Text = "Almoço";
            this.almocoToolStripMenuItem.Click += new System.EventHandler(this.almocoToolStripMenuItem_Click);
            // 
            // jantarToolStripMenuItem1
            // 
            this.jantarToolStripMenuItem1.Name = "jantarToolStripMenuItem1";
            this.jantarToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.jantarToolStripMenuItem1.Text = "Jantar";
            this.jantarToolStripMenuItem1.Click += new System.EventHandler(this.jantarToolStripMenuItem1_Click);
            // 
            // voltojaToolStripMenuItem2
            // 
            this.voltojaToolStripMenuItem2.Name = "voltojaToolStripMenuItem2";
            this.voltojaToolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.voltojaToolStripMenuItem2.Text = "Volto Já";
            this.voltojaToolStripMenuItem2.Click += new System.EventHandler(this.voltojaToolStripMenuItem2_Click);
            // 
            // ausenteToolStripMenuItem
            // 
            this.ausenteToolStripMenuItem.Name = "ausenteToolStripMenuItem";
            this.ausenteToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.ausenteToolStripMenuItem.Text = "Ausente";
            this.ausenteToolStripMenuItem.Click += new System.EventHandler(this.ausenteToolStripMenuItem_Click);
            // 
            // txtMsgPublico
            // 
            this.txtMsgPublico.AcceptsReturn = true;
            this.txtMsgPublico.BackColor = System.Drawing.SystemColors.Window;
            this.txtMsgPublico.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsgPublico.Location = new System.Drawing.Point(6, 562);
            this.txtMsgPublico.MaxLength = 450;
            this.txtMsgPublico.Multiline = true;
            this.txtMsgPublico.Name = "txtMsgPublico";
            this.txtMsgPublico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgPublico.Size = new System.Drawing.Size(819, 60);
            this.txtMsgPublico.TabIndex = 14;
            this.txtMsgPublico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMsgPublico_KeyPress);
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabPrincipal.ContextMenuStrip = this.contextTabs;
            this.tabPrincipal.Controls.Add(this.tabpageChatPublico);
            this.tabPrincipal.Controls.Add(this.tabpageOpcoes);
            this.tabPrincipal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPrincipal.HotTrack = true;
            this.tabPrincipal.Location = new System.Drawing.Point(5, 4);
            this.tabPrincipal.Multiline = true;
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(957, 654);
            this.tabPrincipal.TabIndex = 15;            
            // 
            // contextTabs
            // 
            this.contextTabs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fecharToolStripMenuItem});
            this.contextTabs.Name = "contextTabs";
            this.contextTabs.Size = new System.Drawing.Size(119, 26);
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.fecharToolStripMenuItem.Text = "Fechar";
            this.fecharToolStripMenuItem.Click += new System.EventHandler(this.fecharToolStripMenuItem_Click);
            // 
            // tabpageChatPublico
            // 
            this.tabpageChatPublico.Controls.Add(this.txtMsgPublico);
            this.tabpageChatPublico.Controls.Add(this.rtxtChatPublico);
            this.tabpageChatPublico.Controls.Add(this.lstUtilizadoresPublico);
            this.tabpageChatPublico.Controls.Add(this.btnEnviarMsgPublico);
            this.tabpageChatPublico.Location = new System.Drawing.Point(4, 4);
            this.tabpageChatPublico.Name = "tabpageChatPublico";
            this.tabpageChatPublico.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageChatPublico.Size = new System.Drawing.Size(949, 628);
            this.tabpageChatPublico.TabIndex = 0;
            this.tabpageChatPublico.Text = "@the.bench";
            // 
            // tabpageOpcoes
            // 
            this.tabpageOpcoes.Controls.Add(this.gbUtilizador);
            this.tabpageOpcoes.Controls.Add(this.gbServidor);
            this.tabpageOpcoes.Location = new System.Drawing.Point(4, 4);
            this.tabpageOpcoes.Name = "tabpageOpcoes";
            this.tabpageOpcoes.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageOpcoes.Size = new System.Drawing.Size(949, 628);
            this.tabpageOpcoes.TabIndex = 2;
            this.tabpageOpcoes.Text = "Opções";
            // 
            // gbUtilizador
            // 
            this.gbUtilizador.Controls.Add(this.btnLogoff);
            this.gbUtilizador.Controls.Add(this.msktxtPassword);
            this.gbUtilizador.Controls.Add(this.lblPassword);
            this.gbUtilizador.Controls.Add(this.txtNomeUtilizador);
            this.gbUtilizador.Controls.Add(this.lblNomeUtilizador);
            this.gbUtilizador.Controls.Add(this.btnLogin);
            this.gbUtilizador.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUtilizador.Location = new System.Drawing.Point(477, 6);
            this.gbUtilizador.Name = "gbUtilizador";
            this.gbUtilizador.Size = new System.Drawing.Size(400, 137);
            this.gbUtilizador.TabIndex = 1;
            this.gbUtilizador.TabStop = false;
            this.gbUtilizador.Text = "Utilizador";
            // 
            // btnLogoff
            // 
            this.btnLogoff.Location = new System.Drawing.Point(319, 48);
            this.btnLogoff.Name = "btnLogoff";
            this.btnLogoff.Size = new System.Drawing.Size(75, 23);
            this.btnLogoff.TabIndex = 10;
            this.btnLogoff.Text = "Logoff";
            this.btnLogoff.UseVisualStyleBackColor = true;
            this.btnLogoff.Visible = false;
            this.btnLogoff.Click += new System.EventHandler(this.btnLogoff_Click);
            // 
            // msktxtPassword
            // 
            this.msktxtPassword.Location = new System.Drawing.Point(111, 68);
            this.msktxtPassword.Name = "msktxtPassword";
            this.msktxtPassword.PasswordChar = '*';
            this.msktxtPassword.Size = new System.Drawing.Size(145, 21);
            this.msktxtPassword.TabIndex = 9;
            this.msktxtPassword.Text = "mestre";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(36, 71);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(64, 13);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Password:";
            // 
            // txtNomeUtilizador
            // 
            this.txtNomeUtilizador.Location = new System.Drawing.Point(111, 34);
            this.txtNomeUtilizador.Name = "txtNomeUtilizador";
            this.txtNomeUtilizador.Size = new System.Drawing.Size(145, 21);
            this.txtNomeUtilizador.TabIndex = 7;
            this.txtNomeUtilizador.Text = "Ricardo";
            // 
            // lblNomeUtilizador
            // 
            this.lblNomeUtilizador.AutoSize = true;
            this.lblNomeUtilizador.Location = new System.Drawing.Point(6, 37);
            this.lblNomeUtilizador.Name = "lblNomeUtilizador";
            this.lblNomeUtilizador.Size = new System.Drawing.Size(99, 13);
            this.lblNomeUtilizador.TabIndex = 6;
            this.lblNomeUtilizador.Text = "Nome Utilizador:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(319, 48);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // gbServidor
            // 
            this.gbServidor.Controls.Add(this.txtEnderecoServidor);
            this.gbServidor.Controls.Add(this.txtPorta);
            this.gbServidor.Controls.Add(this.lblPortaServidor);
            this.gbServidor.Controls.Add(this.lblEndereco);
            this.gbServidor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbServidor.Location = new System.Drawing.Point(71, 6);
            this.gbServidor.Name = "gbServidor";
            this.gbServidor.Size = new System.Drawing.Size(400, 137);
            this.gbServidor.TabIndex = 0;
            this.gbServidor.TabStop = false;
            this.gbServidor.Text = "Servidor";
            // 
            // txtEnderecoServidor
            // 
            this.txtEnderecoServidor.Location = new System.Drawing.Point(89, 34);
            this.txtEnderecoServidor.Name = "txtEnderecoServidor";
            this.txtEnderecoServidor.Size = new System.Drawing.Size(124, 21);
            this.txtEnderecoServidor.TabIndex = 5;
            this.txtEnderecoServidor.Text = "127.0.0.1";
            // 
            // txtPorta
            // 
            this.txtPorta.Location = new System.Drawing.Point(89, 68);
            this.txtPorta.Name = "txtPorta";
            this.txtPorta.Size = new System.Drawing.Size(124, 21);
            this.txtPorta.TabIndex = 4;
            this.txtPorta.Text = "8080";
            // 
            // lblPortaServidor
            // 
            this.lblPortaServidor.AutoSize = true;
            this.lblPortaServidor.Location = new System.Drawing.Point(42, 71);
            this.lblPortaServidor.Name = "lblPortaServidor";
            this.lblPortaServidor.Size = new System.Drawing.Size(41, 13);
            this.lblPortaServidor.TabIndex = 3;
            this.lblPortaServidor.Text = "Porta:";
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.Location = new System.Drawing.Point(6, 37);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(77, 13);
            this.lblEndereco.TabIndex = 1;
            this.lblEndereco.Text = "Endereço IP:";
            // 
            // frmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 664);
            this.Controls.Add(this.tabPrincipal);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(975, 693);
            this.MinimumSize = new System.Drawing.Size(975, 693);
            this.Name = "frmChat";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Não estás ligado a nenhum servidor!";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmChatPublico_FormClosed);
            this.Load += new System.EventHandler(this.frmChatPublico_Load);
            this.contextListaUtilizadoresPublico.ResumeLayout(false);
            this.contextChatTexto.ResumeLayout(false);
            this.tabPrincipal.ResumeLayout(false);
            this.contextTabs.ResumeLayout(false);
            this.tabpageChatPublico.ResumeLayout(false);
            this.tabpageChatPublico.PerformLayout();
            this.tabpageOpcoes.ResumeLayout(false);
            this.gbUtilizador.ResumeLayout(false);
            this.gbUtilizador.PerformLayout();
            this.gbServidor.ResumeLayout(false);
            this.gbServidor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEnviarMsgPublico;
        public System.Windows.Forms.ListBox lstUtilizadoresPublico;
        private System.Windows.Forms.ContextMenuStrip contextListaUtilizadoresPublico;
        private System.Windows.Forms.RichTextBox rtxtChatPublico;
        private System.Windows.Forms.TextBox txtMsgPublico;
        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabpageChatPublico;
        private System.Windows.Forms.ContextMenuStrip contextTabs;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
        private System.Windows.Forms.TabPage tabpageOpcoes;
        private System.Windows.Forms.GroupBox gbUtilizador;
        private System.Windows.Forms.GroupBox gbServidor;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtNomeUtilizador;
        private System.Windows.Forms.Label lblNomeUtilizador;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPorta;
        private System.Windows.Forms.Label lblPortaServidor;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.TextBox txtEnderecoServidor;
        private System.Windows.Forms.MaskedTextBox msktxtPassword;
        private System.Windows.Forms.ContextMenuStrip contextChatTexto;
        private System.Windows.Forms.ToolStripMenuItem limparToolStripMenuItem;
        private System.Windows.Forms.Button btnLogoff;
        private System.Windows.Forms.ToolStripMenuItem abrirTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alterarEstadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem almocoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jantarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem voltojaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ausenteToolStripMenuItem;


        //
        //  Conjunto de propriedades para podermos alterar os controlos
        //
        public string InserirNovaMensagem
        {
            get
            {
                return rtxtChatPublico.Text;
            }
            set
            {
                rtxtChatPublico.AppendText(value + System.Environment.NewLine);

                rtxtChatPublico.SelectionStart = rtxtChatPublico.TextLength;
                rtxtChatPublico.ScrollToCaret();
            }
        }
        public string InserirNovoUtilizador
        {            
            set
            {
                lstUtilizadoresPublico.Items.Add(value);
            }
        }
        public string RemoverUtilizador
        {
            set
            {
                lstUtilizadoresPublico.Items.Remove(value);
            }
        }
        public System.Windows.Forms.TabPage NovoChatPrivado
        {
            set
            {                
                tabPrincipal.Controls.Add(value);
            }
        }
        public int AutoSeleccionaTab
        {
            set
            {
                tabPrincipal.SelectedIndex = value;
            }

            get
            {
                return tabPrincipal.Controls.Count - 1;
            }
        }
        public bool LimparChat
        {
            set
            {
                rtxtChatPublico.ResetText();
            }
        }
        public System.String AlterarEstadoUtilizador
        {
            set
            {
                System.String nome = value.Substring(0, value.IndexOf("(") - 1);
                
                for (int i = 0; i < lstUtilizadoresPublico.Items.Count; i++)
                {                    
                    if (nome == lstUtilizadoresPublico.Items[i].ToString().Substring(0, lstUtilizadoresPublico.Items[i].ToString().IndexOf("(") - 1))
                    {
                        lstUtilizadoresPublico.Items[i] = value;
                        break;
                    }
                }
            }
        }
        public bool ActivarBotoes
        {
            set
            {
                btnLogoff.Visible = false;

                txtNomeUtilizador.Enabled = true;
                txtEnderecoServidor.Enabled = true;
                txtPorta.Enabled = true;
                msktxtPassword.Enabled = true;
                btnLogin.Visible = true;

                lstUtilizadoresPublico.Items.Clear();
            }
        }
    }
}

