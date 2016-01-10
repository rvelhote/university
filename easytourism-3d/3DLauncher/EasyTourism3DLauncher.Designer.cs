namespace EasyTourism3DLauncher
{
    partial class EasyTourism3DLauncher
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
            this.buttonBeginSimulation = new System.Windows.Forms.Button();
            this.groupBoxAuthentication = new System.Windows.Forms.GroupBox();
            this.maskedTextBoxPassword = new System.Windows.Forms.MaskedTextBox();
            this.buttonAuthenticate = new System.Windows.Forms.Button();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.groupBoxSimOptions = new System.Windows.Forms.GroupBox();
            this.checkBoxSaveTour = new System.Windows.Forms.CheckBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.checkBoxFullscreen = new System.Windows.Forms.CheckBox();
            this.labelResolution = new System.Windows.Forms.Label();
            this.comboBoxResolution = new System.Windows.Forms.ComboBox();
            this.groupBoxAvailableTours = new System.Windows.Forms.GroupBox();
            this.dataGridViewRotas = new System.Windows.Forms.DataGridView();
            this.tourID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.begin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxAuthentication.SuspendLayout();
            this.groupBoxSimOptions.SuspendLayout();
            this.groupBoxAvailableTours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRotas)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBeginSimulation
            // 
            this.buttonBeginSimulation.AutoSize = true;
            this.buttonBeginSimulation.Location = new System.Drawing.Point(372, 326);
            this.buttonBeginSimulation.Name = "buttonBeginSimulation";
            this.buttonBeginSimulation.Size = new System.Drawing.Size(97, 23);
            this.buttonBeginSimulation.TabIndex = 1;
            this.buttonBeginSimulation.Text = "Iniciar Simulação";
            this.buttonBeginSimulation.UseVisualStyleBackColor = true;
            this.buttonBeginSimulation.Click += new System.EventHandler(this.buttonBeginSimulation_Click);
            // 
            // groupBoxAuthentication
            // 
            this.groupBoxAuthentication.Controls.Add(this.maskedTextBoxPassword);
            this.groupBoxAuthentication.Controls.Add(this.buttonAuthenticate);
            this.groupBoxAuthentication.Controls.Add(this.textBoxUsername);
            this.groupBoxAuthentication.Controls.Add(this.labelPassword);
            this.groupBoxAuthentication.Controls.Add(this.labelUsername);
            this.groupBoxAuthentication.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAuthentication.Name = "groupBoxAuthentication";
            this.groupBoxAuthentication.Size = new System.Drawing.Size(184, 116);
            this.groupBoxAuthentication.TabIndex = 1;
            this.groupBoxAuthentication.TabStop = false;
            this.groupBoxAuthentication.Text = "Dados de Autenticação";
            // 
            // maskedTextBoxPassword
            // 
            this.maskedTextBoxPassword.Location = new System.Drawing.Point(70, 43);
            this.maskedTextBoxPassword.Name = "maskedTextBoxPassword";
            this.maskedTextBoxPassword.Size = new System.Drawing.Size(104, 20);
            this.maskedTextBoxPassword.TabIndex = 2;
            this.maskedTextBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonAuthenticate
            // 
            this.buttonAuthenticate.AutoSize = true;
            this.buttonAuthenticate.Location = new System.Drawing.Point(99, 81);
            this.buttonAuthenticate.Name = "buttonAuthenticate";
            this.buttonAuthenticate.Size = new System.Drawing.Size(75, 23);
            this.buttonAuthenticate.TabIndex = 1;
            this.buttonAuthenticate.Text = "Autenticar";
            this.buttonAuthenticate.UseVisualStyleBackColor = true;
            this.buttonAuthenticate.Click += new System.EventHandler(this.buttonAuthenticate_Click);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(70, 20);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(104, 20);
            this.textBoxUsername.TabIndex = 1;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(8, 46);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Password:";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(6, 23);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(58, 13);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username:";
            // 
            // groupBoxSimOptions
            // 
            this.groupBoxSimOptions.Controls.Add(this.checkBoxSaveTour);
            this.groupBoxSimOptions.Controls.Add(this.comboBoxLanguage);
            this.groupBoxSimOptions.Controls.Add(this.labelLanguage);
            this.groupBoxSimOptions.Controls.Add(this.checkBoxFullscreen);
            this.groupBoxSimOptions.Controls.Add(this.labelResolution);
            this.groupBoxSimOptions.Controls.Add(this.comboBoxResolution);
            this.groupBoxSimOptions.Location = new System.Drawing.Point(202, 12);
            this.groupBoxSimOptions.Name = "groupBoxSimOptions";
            this.groupBoxSimOptions.Size = new System.Drawing.Size(267, 116);
            this.groupBoxSimOptions.TabIndex = 5;
            this.groupBoxSimOptions.TabStop = false;
            this.groupBoxSimOptions.Text = "Opções da Simulação";
            // 
            // checkBoxSaveTour
            // 
            this.checkBoxSaveTour.AutoSize = true;
            this.checkBoxSaveTour.Checked = global::EasyTourism3DLauncher.Properties.Settings.Default.SaveTour;
            this.checkBoxSaveTour.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSaveTour.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EasyTourism3DLauncher.Properties.Settings.Default, "SaveTour", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxSaveTour.Location = new System.Drawing.Point(154, 85);
            this.checkBoxSaveTour.Name = "checkBoxSaveTour";
            this.checkBoxSaveTour.Size = new System.Drawing.Size(103, 17);
            this.checkBoxSaveTour.TabIndex = 7;
            this.checkBoxSaveTour.Text = "Gravar Percurso";
            this.checkBoxSaveTour.UseVisualStyleBackColor = true;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyTourism3DLauncher.Properties.Settings.Default, "Language", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "Português",
            "English"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(74, 50);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(116, 21);
            this.comboBoxLanguage.TabIndex = 5;
            this.comboBoxLanguage.Text = global::EasyTourism3DLauncher.Properties.Settings.Default.Language;            
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Location = new System.Drawing.Point(24, 53);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(44, 13);
            this.labelLanguage.TabIndex = 3;
            this.labelLanguage.Text = "Língua:";
            // 
            // checkBoxFullscreen
            // 
            this.checkBoxFullscreen.AutoSize = true;
            this.checkBoxFullscreen.Checked = global::EasyTourism3DLauncher.Properties.Settings.Default.SaveTour;
            this.checkBoxFullscreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFullscreen.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EasyTourism3DLauncher.Properties.Settings.Default, "SaveTour", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxFullscreen.Location = new System.Drawing.Point(74, 85);
            this.checkBoxFullscreen.Name = "checkBoxFullscreen";
            this.checkBoxFullscreen.Size = new System.Drawing.Size(74, 17);
            this.checkBoxFullscreen.TabIndex = 6;
            this.checkBoxFullscreen.Text = "Fullscreen";
            this.checkBoxFullscreen.UseVisualStyleBackColor = true;
            // 
            // labelResolution
            // 
            this.labelResolution.AutoSize = true;
            this.labelResolution.Location = new System.Drawing.Point(7, 26);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(61, 13);
            this.labelResolution.TabIndex = 1;
            this.labelResolution.Text = "Resolução:";
            // 
            // comboBoxResolution
            // 
            this.comboBoxResolution.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyTourism3DLauncher.Properties.Settings.Default, "Resolution", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxResolution.FormattingEnabled = true;
            this.comboBoxResolution.Items.AddRange(new object[] {
            "800x600",
            "1024x768",
            "1280x1024",
            "1680x1050"});
            this.comboBoxResolution.Location = new System.Drawing.Point(74, 23);
            this.comboBoxResolution.Name = "comboBoxResolution";
            this.comboBoxResolution.Size = new System.Drawing.Size(116, 21);
            this.comboBoxResolution.TabIndex = 4;
            this.comboBoxResolution.Text = global::EasyTourism3DLauncher.Properties.Settings.Default.Resolution;
            // 
            // groupBoxAvailableTours
            // 
            this.groupBoxAvailableTours.Controls.Add(this.dataGridViewRotas);
            this.groupBoxAvailableTours.Location = new System.Drawing.Point(12, 134);
            this.groupBoxAvailableTours.Name = "groupBoxAvailableTours";
            this.groupBoxAvailableTours.Size = new System.Drawing.Size(457, 186);
            this.groupBoxAvailableTours.TabIndex = 3;
            this.groupBoxAvailableTours.TabStop = false;
            this.groupBoxAvailableTours.Text = "Rotas Disponíveis";
            // 
            // dataGridViewRotas
            // 
            this.dataGridViewRotas.AllowUserToAddRows = false;
            this.dataGridViewRotas.AllowUserToDeleteRows = false;
            this.dataGridViewRotas.AllowUserToResizeColumns = false;
            this.dataGridViewRotas.AllowUserToResizeRows = false;
            this.dataGridViewRotas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tourID,
            this.cityName,
            this.begin});
            this.dataGridViewRotas.Location = new System.Drawing.Point(7, 20);
            this.dataGridViewRotas.MultiSelect = false;
            this.dataGridViewRotas.Name = "dataGridViewRotas";
            this.dataGridViewRotas.ReadOnly = true;
            this.dataGridViewRotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRotas.Size = new System.Drawing.Size(444, 160);
            this.dataGridViewRotas.TabIndex = 8;
            // 
            // tourID
            // 
            this.tourID.DataPropertyName = "tourID";
            this.tourID.HeaderText = "Identificação";
            this.tourID.Name = "tourID";
            this.tourID.ReadOnly = true;
            // 
            // cityName
            // 
            this.cityName.DataPropertyName = "cityName";
            this.cityName.HeaderText = "Cidade";
            this.cityName.Name = "cityName";
            this.cityName.ReadOnly = true;
            // 
            // begin
            // 
            this.begin.DataPropertyName = "begin";
            this.begin.HeaderText = "Data Início Visita";
            this.begin.Name = "begin";
            this.begin.ReadOnly = true;
            // 
            // EasyTourism3DLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 359);
            this.Controls.Add(this.groupBoxSimOptions);
            this.Controls.Add(this.groupBoxAuthentication);
            this.Controls.Add(this.groupBoxAvailableTours);
            this.Controls.Add(this.buttonBeginSimulation);
            this.MaximizeBox = false;
            this.Name = "EasyTourism3DLauncher";
            this.Text = "EasyTourism3D Launcher";
            this.groupBoxAuthentication.ResumeLayout(false);
            this.groupBoxAuthentication.PerformLayout();
            this.groupBoxSimOptions.ResumeLayout(false);
            this.groupBoxSimOptions.PerformLayout();
            this.groupBoxAvailableTours.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBeginSimulation;
        private System.Windows.Forms.GroupBox groupBoxAuthentication;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Button buttonAuthenticate;
        private System.Windows.Forms.GroupBox groupBoxSimOptions;
        private System.Windows.Forms.Label labelResolution;
        private System.Windows.Forms.ComboBox comboBoxResolution;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.CheckBox checkBoxFullscreen;
        private System.Windows.Forms.CheckBox checkBoxSaveTour;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.GroupBox groupBoxAvailableTours;        
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPassword;
        private System.Windows.Forms.DataGridView dataGridViewRotas;
        private System.Windows.Forms.DataGridViewTextBoxColumn tourID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn begin;
    }
}

