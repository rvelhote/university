namespace EncodingModulation
{
    partial class frmEncodeModulation
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
            this.labelInsereBinario = new System.Windows.Forms.Label();
            this.textBoxCodigoBinario = new System.Windows.Forms.TextBox();
            this.panelGrafismo = new System.Windows.Forms.Panel();
            this.checkBoxNRZL = new System.Windows.Forms.CheckBox();
            this.checkBoxBipolarAMI = new System.Windows.Forms.CheckBox();
            this.checkBoxPseudoternary = new System.Windows.Forms.CheckBox();
            this.checkBoxNRZI = new System.Windows.Forms.CheckBox();
            this.checkBoxDiferencialManchester = new System.Windows.Forms.CheckBox();
            this.checkBoxManchester = new System.Windows.Forms.CheckBox();
            this.buttonCorreAlgoritmos = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageEncoding = new System.Windows.Forms.TabPage();
            this.tabPageModulation = new System.Windows.Forms.TabPage();
            this.groupBoxControlos = new System.Windows.Forms.GroupBox();
            this.labelValorTempo = new System.Windows.Forms.Label();
            this.labelValorAmplitude = new System.Windows.Forms.Label();
            this.labelValorFrequencia = new System.Windows.Forms.Label();
            this.hScrollBarTempo = new System.Windows.Forms.HScrollBar();
            this.hScrollBarAmplitude = new System.Windows.Forms.HScrollBar();
            this.hScrollBarFrequencia = new System.Windows.Forms.HScrollBar();
            this.labelTempo = new System.Windows.Forms.Label();
            this.labelAmplitude = new System.Windows.Forms.Label();
            this.labelFrequencia = new System.Windows.Forms.Label();
            this.radioButtonPhaseShiftKeying = new System.Windows.Forms.RadioButton();
            this.radioButtonFrequencyShiftKeying = new System.Windows.Forms.RadioButton();
            this.radioButtonAmplitudeShiftKeying = new System.Windows.Forms.RadioButton();
            this.panelGrafismoModulation = new System.Windows.Forms.Panel();
            this.labelValorFrequencia2 = new System.Windows.Forms.Label();
            this.hScrollBarFrequencia2 = new System.Windows.Forms.HScrollBar();
            this.labelFrequencia2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageEncoding.SuspendLayout();
            this.tabPageModulation.SuspendLayout();
            this.groupBoxControlos.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInsereBinario
            // 
            this.labelInsereBinario.AutoSize = true;
            this.labelInsereBinario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelInsereBinario.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInsereBinario.Location = new System.Drawing.Point(217, 11);
            this.labelInsereBinario.Name = "labelInsereBinario";
            this.labelInsereBinario.Size = new System.Drawing.Size(137, 13);
            this.labelInsereBinario.TabIndex = 0;
            this.labelInsereBinario.Text = "insere o código binário:";
            // 
            // textBoxCodigoBinario
            // 
            this.textBoxCodigoBinario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCodigoBinario.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCodigoBinario.Location = new System.Drawing.Point(352, 7);
            this.textBoxCodigoBinario.Name = "textBoxCodigoBinario";
            this.textBoxCodigoBinario.Size = new System.Drawing.Size(225, 21);
            this.textBoxCodigoBinario.TabIndex = 1;
            this.textBoxCodigoBinario.Text = "01001100011";
            this.textBoxCodigoBinario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCodigoBinario_KeyPress);
            // 
            // panelGrafismo
            // 
            this.panelGrafismo.BackColor = System.Drawing.SystemColors.Control;
            this.panelGrafismo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrafismo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelGrafismo.Location = new System.Drawing.Point(163, 8);
            this.panelGrafismo.Name = "panelGrafismo";
            this.panelGrafismo.Size = new System.Drawing.Size(819, 448);
            this.panelGrafismo.TabIndex = 2;
            // 
            // checkBoxNRZL
            // 
            this.checkBoxNRZL.AutoSize = true;
            this.checkBoxNRZL.Checked = true;
            this.checkBoxNRZL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNRZL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxNRZL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxNRZL.Location = new System.Drawing.Point(8, 36);
            this.checkBoxNRZL.Name = "checkBoxNRZL";
            this.checkBoxNRZL.Size = new System.Drawing.Size(56, 17);
            this.checkBoxNRZL.TabIndex = 3;
            this.checkBoxNRZL.Text = "NRZ-L";
            this.checkBoxNRZL.UseVisualStyleBackColor = true;
            // 
            // checkBoxBipolarAMI
            // 
            this.checkBoxBipolarAMI.AutoSize = true;
            this.checkBoxBipolarAMI.Checked = true;
            this.checkBoxBipolarAMI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBipolarAMI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxBipolarAMI.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxBipolarAMI.Location = new System.Drawing.Point(8, 188);
            this.checkBoxBipolarAMI.Name = "checkBoxBipolarAMI";
            this.checkBoxBipolarAMI.Size = new System.Drawing.Size(90, 17);
            this.checkBoxBipolarAMI.TabIndex = 4;
            this.checkBoxBipolarAMI.Text = "Bipolar-AMI";
            this.checkBoxBipolarAMI.UseVisualStyleBackColor = true;
            // 
            // checkBoxPseudoternary
            // 
            this.checkBoxPseudoternary.AutoSize = true;
            this.checkBoxPseudoternary.Checked = true;
            this.checkBoxPseudoternary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPseudoternary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxPseudoternary.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPseudoternary.Location = new System.Drawing.Point(8, 264);
            this.checkBoxPseudoternary.Name = "checkBoxPseudoternary";
            this.checkBoxPseudoternary.Size = new System.Drawing.Size(107, 17);
            this.checkBoxPseudoternary.TabIndex = 6;
            this.checkBoxPseudoternary.Text = "Pseudoternary";
            this.checkBoxPseudoternary.UseVisualStyleBackColor = true;
            // 
            // checkBoxNRZI
            // 
            this.checkBoxNRZI.AutoSize = true;
            this.checkBoxNRZI.Checked = true;
            this.checkBoxNRZI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNRZI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxNRZI.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxNRZI.Location = new System.Drawing.Point(8, 112);
            this.checkBoxNRZI.Name = "checkBoxNRZI";
            this.checkBoxNRZI.Size = new System.Drawing.Size(50, 17);
            this.checkBoxNRZI.TabIndex = 5;
            this.checkBoxNRZI.Text = "NRZI";
            this.checkBoxNRZI.UseVisualStyleBackColor = true;
            // 
            // checkBoxDiferencialManchester
            // 
            this.checkBoxDiferencialManchester.AutoSize = true;
            this.checkBoxDiferencialManchester.Checked = true;
            this.checkBoxDiferencialManchester.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDiferencialManchester.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxDiferencialManchester.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDiferencialManchester.Location = new System.Drawing.Point(8, 416);
            this.checkBoxDiferencialManchester.Name = "checkBoxDiferencialManchester";
            this.checkBoxDiferencialManchester.Size = new System.Drawing.Size(153, 17);
            this.checkBoxDiferencialManchester.TabIndex = 8;
            this.checkBoxDiferencialManchester.Text = "Diferencial Manchester";
            this.checkBoxDiferencialManchester.UseVisualStyleBackColor = true;
            // 
            // checkBoxManchester
            // 
            this.checkBoxManchester.AutoSize = true;
            this.checkBoxManchester.Checked = true;
            this.checkBoxManchester.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxManchester.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxManchester.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxManchester.Location = new System.Drawing.Point(8, 340);
            this.checkBoxManchester.Name = "checkBoxManchester";
            this.checkBoxManchester.Size = new System.Drawing.Size(90, 17);
            this.checkBoxManchester.TabIndex = 7;
            this.checkBoxManchester.Text = "Manchester";
            this.checkBoxManchester.UseVisualStyleBackColor = true;
            // 
            // buttonCorreAlgoritmos
            // 
            this.buttonCorreAlgoritmos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCorreAlgoritmos.Location = new System.Drawing.Point(584, 7);
            this.buttonCorreAlgoritmos.Name = "buttonCorreAlgoritmos";
            this.buttonCorreAlgoritmos.Size = new System.Drawing.Size(154, 23);
            this.buttonCorreAlgoritmos.TabIndex = 9;
            this.buttonCorreAlgoritmos.Text = "correr algoritmos";
            this.buttonCorreAlgoritmos.UseVisualStyleBackColor = true;
            this.buttonCorreAlgoritmos.Click += new System.EventHandler(this.buttonCorreAlgoritmos_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPageEncoding);
            this.tabControl1.Controls.Add(this.tabPageModulation);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(2, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(998, 499);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPageEncoding
            // 
            this.tabPageEncoding.BackColor = System.Drawing.Color.Transparent;
            this.tabPageEncoding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageEncoding.Controls.Add(this.panelGrafismo);
            this.tabPageEncoding.Controls.Add(this.checkBoxNRZL);
            this.tabPageEncoding.Controls.Add(this.checkBoxDiferencialManchester);
            this.tabPageEncoding.Controls.Add(this.checkBoxBipolarAMI);
            this.tabPageEncoding.Controls.Add(this.checkBoxManchester);
            this.tabPageEncoding.Controls.Add(this.checkBoxNRZI);
            this.tabPageEncoding.Controls.Add(this.checkBoxPseudoternary);
            this.tabPageEncoding.Location = new System.Drawing.Point(4, 4);
            this.tabPageEncoding.Name = "tabPageEncoding";
            this.tabPageEncoding.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEncoding.Size = new System.Drawing.Size(990, 473);
            this.tabPageEncoding.TabIndex = 0;
            this.tabPageEncoding.Text = "Encoding";
            // 
            // tabPageModulation
            // 
            this.tabPageModulation.BackColor = System.Drawing.Color.Transparent;
            this.tabPageModulation.Controls.Add(this.groupBoxControlos);
            this.tabPageModulation.Controls.Add(this.radioButtonPhaseShiftKeying);
            this.tabPageModulation.Controls.Add(this.radioButtonFrequencyShiftKeying);
            this.tabPageModulation.Controls.Add(this.radioButtonAmplitudeShiftKeying);
            this.tabPageModulation.Controls.Add(this.panelGrafismoModulation);
            this.tabPageModulation.Location = new System.Drawing.Point(4, 4);
            this.tabPageModulation.Name = "tabPageModulation";
            this.tabPageModulation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageModulation.Size = new System.Drawing.Size(990, 473);
            this.tabPageModulation.TabIndex = 1;
            this.tabPageModulation.Text = "Modulation";
            // 
            // groupBoxControlos
            // 
            this.groupBoxControlos.Controls.Add(this.labelValorFrequencia2);
            this.groupBoxControlos.Controls.Add(this.hScrollBarFrequencia2);
            this.groupBoxControlos.Controls.Add(this.labelFrequencia2);
            this.groupBoxControlos.Controls.Add(this.labelValorTempo);
            this.groupBoxControlos.Controls.Add(this.labelValorAmplitude);
            this.groupBoxControlos.Controls.Add(this.labelValorFrequencia);
            this.groupBoxControlos.Controls.Add(this.hScrollBarTempo);
            this.groupBoxControlos.Controls.Add(this.hScrollBarAmplitude);
            this.groupBoxControlos.Controls.Add(this.hScrollBarFrequencia);
            this.groupBoxControlos.Controls.Add(this.labelTempo);
            this.groupBoxControlos.Controls.Add(this.labelAmplitude);
            this.groupBoxControlos.Controls.Add(this.labelFrequencia);
            this.groupBoxControlos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxControlos.Location = new System.Drawing.Point(8, 182);
            this.groupBoxControlos.Name = "groupBoxControlos";
            this.groupBoxControlos.Size = new System.Drawing.Size(148, 274);
            this.groupBoxControlos.TabIndex = 7;
            this.groupBoxControlos.TabStop = false;
            // 
            // labelValorTempo
            // 
            this.labelValorTempo.AutoSize = true;
            this.labelValorTempo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelValorTempo.Location = new System.Drawing.Point(57, 255);
            this.labelValorTempo.Name = "labelValorTempo";
            this.labelValorTempo.Size = new System.Drawing.Size(34, 13);
            this.labelValorTempo.TabIndex = 8;
            this.labelValorTempo.Text = "0 ms";
            // 
            // labelValorAmplitude
            // 
            this.labelValorAmplitude.AutoSize = true;
            this.labelValorAmplitude.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelValorAmplitude.Location = new System.Drawing.Point(62, 178);
            this.labelValorAmplitude.Name = "labelValorAmplitude";
            this.labelValorAmplitude.Size = new System.Drawing.Size(14, 13);
            this.labelValorAmplitude.TabIndex = 7;
            this.labelValorAmplitude.Text = "0";
            // 
            // labelValorFrequencia
            // 
            this.labelValorFrequencia.AutoSize = true;
            this.labelValorFrequencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelValorFrequencia.Location = new System.Drawing.Point(52, 48);
            this.labelValorFrequencia.Name = "labelValorFrequencia";
            this.labelValorFrequencia.Size = new System.Drawing.Size(31, 13);
            this.labelValorFrequencia.TabIndex = 6;
            this.labelValorFrequencia.Text = "0 Hz";
            // 
            // hScrollBarTempo
            // 
            this.hScrollBarTempo.Location = new System.Drawing.Point(12, 241);
            this.hScrollBarTempo.Maximum = 1000;
            this.hScrollBarTempo.Name = "hScrollBarTempo";
            this.hScrollBarTempo.Size = new System.Drawing.Size(123, 14);
            this.hScrollBarTempo.TabIndex = 5;
            this.hScrollBarTempo.Value = 70;
            this.hScrollBarTempo.ValueChanged += new System.EventHandler(this.hScrollBarTempo_ValueChanged);
            // 
            // hScrollBarAmplitude
            // 
            this.hScrollBarAmplitude.Location = new System.Drawing.Point(12, 164);
            this.hScrollBarAmplitude.Name = "hScrollBarAmplitude";
            this.hScrollBarAmplitude.Size = new System.Drawing.Size(123, 14);
            this.hScrollBarAmplitude.TabIndex = 4;
            this.hScrollBarAmplitude.Value = 25;
            this.hScrollBarAmplitude.ValueChanged += new System.EventHandler(this.hScrollBarAmplitude_ValueChanged);
            // 
            // hScrollBarFrequencia
            // 
            this.hScrollBarFrequencia.Location = new System.Drawing.Point(6, 34);
            this.hScrollBarFrequencia.Maximum = 200;
            this.hScrollBarFrequencia.Name = "hScrollBarFrequencia";
            this.hScrollBarFrequencia.Size = new System.Drawing.Size(123, 14);
            this.hScrollBarFrequencia.TabIndex = 3;
            this.hScrollBarFrequencia.Value = 50;
            this.hScrollBarFrequencia.ValueChanged += new System.EventHandler(this.hScrollBarFrequencia_ValueChanged);
            // 
            // labelTempo
            // 
            this.labelTempo.AutoSize = true;
            this.labelTempo.Location = new System.Drawing.Point(35, 226);
            this.labelTempo.Name = "labelTempo";
            this.labelTempo.Size = new System.Drawing.Size(79, 13);
            this.labelTempo.TabIndex = 2;
            this.labelTempo.Text = "Tempo (ms):";
            // 
            // labelAmplitude
            // 
            this.labelAmplitude.AutoSize = true;
            this.labelAmplitude.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelAmplitude.Location = new System.Drawing.Point(39, 149);
            this.labelAmplitude.Name = "labelAmplitude";
            this.labelAmplitude.Size = new System.Drawing.Size(68, 13);
            this.labelAmplitude.TabIndex = 1;
            this.labelAmplitude.Text = "Amplitude:";
            // 
            // labelFrequencia
            // 
            this.labelFrequencia.AutoSize = true;
            this.labelFrequencia.Location = new System.Drawing.Point(20, 19);
            this.labelFrequencia.Name = "labelFrequencia";
            this.labelFrequencia.Size = new System.Drawing.Size(99, 13);
            this.labelFrequencia.TabIndex = 0;
            this.labelFrequencia.Text = "Frequência (Hz):";
            // 
            // radioButtonPhaseShiftKeying
            // 
            this.radioButtonPhaseShiftKeying.AutoSize = true;
            this.radioButtonPhaseShiftKeying.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonPhaseShiftKeying.Location = new System.Drawing.Point(7, 125);
            this.radioButtonPhaseShiftKeying.Name = "radioButtonPhaseShiftKeying";
            this.radioButtonPhaseShiftKeying.Size = new System.Drawing.Size(128, 17);
            this.radioButtonPhaseShiftKeying.TabIndex = 6;
            this.radioButtonPhaseShiftKeying.Tag = "8";
            this.radioButtonPhaseShiftKeying.Text = "Phase Shift Keying";
            this.radioButtonPhaseShiftKeying.UseVisualStyleBackColor = true;
            // 
            // radioButtonFrequencyShiftKeying
            // 
            this.radioButtonFrequencyShiftKeying.AutoSize = true;
            this.radioButtonFrequencyShiftKeying.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonFrequencyShiftKeying.Location = new System.Drawing.Point(7, 76);
            this.radioButtonFrequencyShiftKeying.Name = "radioButtonFrequencyShiftKeying";
            this.radioButtonFrequencyShiftKeying.Size = new System.Drawing.Size(153, 17);
            this.radioButtonFrequencyShiftKeying.TabIndex = 5;
            this.radioButtonFrequencyShiftKeying.Tag = "8";
            this.radioButtonFrequencyShiftKeying.Text = "Frequency Shift Keying";
            this.radioButtonFrequencyShiftKeying.UseVisualStyleBackColor = true;
            // 
            // radioButtonAmplitudeShiftKeying
            // 
            this.radioButtonAmplitudeShiftKeying.AutoSize = true;
            this.radioButtonAmplitudeShiftKeying.Checked = true;
            this.radioButtonAmplitudeShiftKeying.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonAmplitudeShiftKeying.Location = new System.Drawing.Point(7, 27);
            this.radioButtonAmplitudeShiftKeying.Name = "radioButtonAmplitudeShiftKeying";
            this.radioButtonAmplitudeShiftKeying.Size = new System.Drawing.Size(152, 17);
            this.radioButtonAmplitudeShiftKeying.TabIndex = 4;
            this.radioButtonAmplitudeShiftKeying.TabStop = true;
            this.radioButtonAmplitudeShiftKeying.Tag = "8";
            this.radioButtonAmplitudeShiftKeying.Text = "Amplitude Shift Keying";
            this.radioButtonAmplitudeShiftKeying.UseVisualStyleBackColor = true;
            // 
            // panelGrafismoModulation
            // 
            this.panelGrafismoModulation.BackColor = System.Drawing.SystemColors.Control;
            this.panelGrafismoModulation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrafismoModulation.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelGrafismoModulation.Location = new System.Drawing.Point(168, 8);
            this.panelGrafismoModulation.Name = "panelGrafismoModulation";
            this.panelGrafismoModulation.Size = new System.Drawing.Size(816, 448);
            this.panelGrafismoModulation.TabIndex = 3;
            // 
            // labelValorFrequencia2
            // 
            this.labelValorFrequencia2.AutoSize = true;
            this.labelValorFrequencia2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelValorFrequencia2.Location = new System.Drawing.Point(57, 111);
            this.labelValorFrequencia2.Name = "labelValorFrequencia2";
            this.labelValorFrequencia2.Size = new System.Drawing.Size(31, 13);
            this.labelValorFrequencia2.TabIndex = 11;
            this.labelValorFrequencia2.Text = "0 Hz";
            // 
            // hScrollBarFrequencia2
            // 
            this.hScrollBarFrequencia2.Location = new System.Drawing.Point(11, 97);
            this.hScrollBarFrequencia2.Maximum = 200;
            this.hScrollBarFrequencia2.Name = "hScrollBarFrequencia2";
            this.hScrollBarFrequencia2.Size = new System.Drawing.Size(123, 14);
            this.hScrollBarFrequencia2.TabIndex = 10;
            this.hScrollBarFrequencia2.Value = 50;
            this.hScrollBarFrequencia2.ValueChanged += new System.EventHandler(this.hScrollBarFrequencia2_ValueChanged);
            // 
            // labelFrequencia2
            // 
            this.labelFrequencia2.AutoSize = true;
            this.labelFrequencia2.Location = new System.Drawing.Point(25, 82);
            this.labelFrequencia2.Name = "labelFrequencia2";
            this.labelFrequencia2.Size = new System.Drawing.Size(109, 13);
            this.labelFrequencia2.TabIndex = 9;
            this.labelFrequencia2.Text = "Frequência 2 (Hz):";
            // 
            // frmEncodeModulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 537);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonCorreAlgoritmos);
            this.Controls.Add(this.textBoxCodigoBinario);
            this.Controls.Add(this.labelInsereBinario);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(1020, 566);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1020, 566);
            this.Name = "frmEncodeModulation";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encoding And Modulation Techniques";
            this.Load += new System.EventHandler(this.frmEncodeModulation_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageEncoding.ResumeLayout(false);
            this.tabPageEncoding.PerformLayout();
            this.tabPageModulation.ResumeLayout(false);
            this.tabPageModulation.PerformLayout();
            this.groupBoxControlos.ResumeLayout(false);
            this.groupBoxControlos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInsereBinario;
        private System.Windows.Forms.TextBox textBoxCodigoBinario;
        private System.Windows.Forms.Panel panelGrafismo;
        private System.Windows.Forms.CheckBox checkBoxNRZL;
        private System.Windows.Forms.CheckBox checkBoxBipolarAMI;
        private System.Windows.Forms.CheckBox checkBoxPseudoternary;
        private System.Windows.Forms.CheckBox checkBoxNRZI;
        private System.Windows.Forms.CheckBox checkBoxDiferencialManchester;
        private System.Windows.Forms.CheckBox checkBoxManchester;
        private System.Windows.Forms.Button buttonCorreAlgoritmos;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageEncoding;
        private System.Windows.Forms.TabPage tabPageModulation;
        private System.Windows.Forms.Panel panelGrafismoModulation;
        private System.Windows.Forms.RadioButton radioButtonAmplitudeShiftKeying;
        private System.Windows.Forms.RadioButton radioButtonFrequencyShiftKeying;
        private System.Windows.Forms.RadioButton radioButtonPhaseShiftKeying;
        private System.Windows.Forms.GroupBox groupBoxControlos;
        private System.Windows.Forms.Label labelAmplitude;
        private System.Windows.Forms.Label labelFrequencia;
        private System.Windows.Forms.Label labelTempo;
        private System.Windows.Forms.HScrollBar hScrollBarFrequencia;
        private System.Windows.Forms.HScrollBar hScrollBarTempo;
        private System.Windows.Forms.HScrollBar hScrollBarAmplitude;
        private System.Windows.Forms.Label labelValorFrequencia;
        private System.Windows.Forms.Label labelValorTempo;
        private System.Windows.Forms.Label labelValorAmplitude;
        private System.Windows.Forms.Label labelValorFrequencia2;
        private System.Windows.Forms.HScrollBar hScrollBarFrequencia2;
        private System.Windows.Forms.Label labelFrequencia2;
    }
}

