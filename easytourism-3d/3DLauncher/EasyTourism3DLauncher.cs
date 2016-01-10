using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using EasyTourism3DLauncher.WebService;
using System.Threading;
using System.Resources;
using System.Globalization;
using System.Diagnostics;


namespace EasyTourism3DLauncher
{
    public partial class EasyTourism3DLauncher : Form
    {
        private ResourceManager resourceManager;

        public ResourceManager ResourceManager
        {
            get { return resourceManager; }
            set { resourceManager = value; }
        }
        
        private CultureInfo cultureInfo;

        public CultureInfo CultureInfo
        {
            get { return cultureInfo; }
            set { cultureInfo = value; }
        }

        public EasyTourism3DLauncher()
        {
            InitializeComponent();            
        }

        private void buttonAuthenticate_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text.Length <= 0)
            {
                MessageBox.Show("Indique o seu Nome de Utilizador");
            }
            else if (maskedTextBoxPassword.Text.Length <= 0)
            {
                MessageBox.Show("Indique a sua Password");
            }
            else
            {
                EasyTourismServices webService = new EasyTourismServices();
                WebService.TourList tlist = webService.TourListForTourist(textBoxUsername.Text, maskedTextBoxPassword.Text);

                if (!tlist.authenticated)
                {
                    MessageBox.Show("A Autenticação falhou");
                }
                else if (tlist.tours.Length > 0) 
                {
                    dataGridViewRotas.DataSource = tlist.tours;
                    buttonAuthenticate.Text = "Actualizar";
                }
                else
                {
                    MessageBox.Show("Não tem rotas disponíveis");
                }
            }
        }

        private void buttonBeginSimulation_Click(object sender, EventArgs e)
        {
            if (dataGridViewRotas.RowCount > 0)
            {
                if (Process.GetProcessesByName("EasyTourism3D").Length > 0)
                {
                    MessageBox.Show("Já está a correr a aplicação");
                }
                else
                {

                    Process.Start("EasyTourism3D.exe", textBoxUsername.Text
                                                        + " " + maskedTextBoxPassword.Text
                                                        + " " + dataGridViewRotas.CurrentRow.Cells[0].Value.ToString()
                                                        + " " + comboBoxResolution.SelectedText
                                                        + " " + this.getISO()
                                                        + " " + checkBoxFullscreen.Checked.ToString()
                                                        + " " + checkBoxSaveTour.Checked.ToString());
                }
            }
            else
            {
                MessageBox.Show("Não tem nenhuma rota seleccionada");
            }                        
        }

        private String getISO()
        {
            String code = "pt-PT";

            switch (comboBoxLanguage.SelectedIndex)
            {
                case 1:
                    {
                        code = "en-US";
                        break;
                    }

                case 0:
                default:
                    {
                        code = "pt-PT";
                        break;
                    }
            }

            return code;
        }
    }
}
