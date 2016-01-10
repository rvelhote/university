using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.IO;
using System.Threading;

namespace src_chat_servidor
{
    public partial class frmServidor : Form
    {
        //  Criar um novo objecto da classe servidor
        Servidor oServidor;


        //
        //  Botão para iniciar o servidor
        //
        private void btnLigarServidor_Click(object sender, EventArgs e)
        {
            btnLigarServidor.Enabled = false;
            btnDesligarServidor.Enabled = true;

            oServidor = new Servidor(Convert.ToInt16(txtPortaServidor.Text), this);
            oServidor.IniciarServidor();
        }


        //
        //  Carregamos no X
        //  Desligar o servidor
        //
        private void frmServidor_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                oServidor.DesligarServidor();
            }
            catch (NullReferenceException) { }
        }


        //
        //  Botão para desligar o servidor
        //
        private void btnDesligarServidor_Click(object sender, EventArgs e)
        {
            btnDesligarServidor.Enabled = false;
            btnLigarServidor.Enabled = true;

            oServidor.DesligarServidor();
        }


        //
        //  Botão para escolher o directório da base de dados
        //
        private void btnEscolherBD_Click(object sender, EventArgs e)
        {
            ofdEscolherBD.ShowDialog();
            txtLocalizacaoBD.Text = ofdEscolherBD.FileName;
        }


        //  
        //  Ao iniciar o formulário
        //
        private void frmServidor_Load(object sender, EventArgs e)
        {
            tabServidorPrincipal.SelectedIndex = 2;
        }


        //
        //  O Construtor da classe. Inicializa os controlos do formulário
        //
        public frmServidor()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
    }
}