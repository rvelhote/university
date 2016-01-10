using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EncodingModulation
{
    public partial class frmEncodeModulation : Form
    {
        //private Graficos g;

        public frmEncodeModulation()
        {
            InitializeComponent();            
        }

        private void textBoxCodigoBinario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = true;

                if (tabControl1.SelectedIndex == 0)
                {
                    correrAlgoritmosEncoding();
                }
                else
                {
                    correrAlgoritmosModulation();
                }
            }

            if (e.KeyChar != '1' && e.KeyChar != '0' && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                e.Handled = true;
            }

            if (textBoxCodigoBinario.TextLength >= 25 && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void buttonCorreAlgoritmos_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                correrAlgoritmosEncoding();
            }
            else
            {
                correrAlgoritmosModulation();
            }
        }

        private void correrAlgoritmosModulation()
        {
            Graficos g = new Graficos(panelGrafismoModulation.CreateGraphics());

            panelGrafismoModulation.Refresh();

            if (textBoxCodigoBinario.TextLength <= 0)
            {
                MessageBox.Show("tens que inserir um código binário!", "Ooops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                panelGrafismoModulation.Refresh();
                g.desenharQuadro();
                return;
            }

            if (radioButtonAmplitudeShiftKeying.Checked)
            {
                Modulation.aplicarAmplitudeShiftKeying(textBoxCodigoBinario.Text, g, Convert.ToDouble(hScrollBarFrequencia.Value), Convert.ToDouble(hScrollBarAmplitude.Value), hScrollBarTempo.Value);
            }
            else if (radioButtonFrequencyShiftKeying.Checked)
            {
                Modulation.aplicarFrequencyShiftKeying(textBoxCodigoBinario.Text, g, Convert.ToDouble(hScrollBarFrequencia.Value), Convert.ToDouble(hScrollBarAmplitude.Value), hScrollBarTempo.Value, Convert.ToDouble(hScrollBarFrequencia2.Value));
            }
            else if (radioButtonPhaseShiftKeying.Checked)
            {
                Modulation.aplicarPhaseShiftKeying(textBoxCodigoBinario.Text, g, Convert.ToDouble(hScrollBarFrequencia.Value), Convert.ToDouble(hScrollBarAmplitude.Value), hScrollBarTempo.Value);                
            }
        }

        private void correrAlgoritmosEncoding()
        {
            Graficos g = new Graficos(panelGrafismo.CreateGraphics());

            panelGrafismo.Refresh();
            g.desenharQuadro();

            if (textBoxCodigoBinario.TextLength <= 0)
            {
                MessageBox.Show("tens que inserir um código binário!", "Ooops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                panelGrafismo.Refresh();
                g.desenharQuadro();
                return;
            }
            else if (!checkBoxBipolarAMI.Checked && !checkBoxDiferencialManchester.Checked && !checkBoxNRZI.Checked && !checkBoxNRZL.Checked
                        && !checkBoxPseudoternary.Checked && !checkBoxManchester.Checked)
            {
                MessageBox.Show("tens que seleccionar pelo menos um tipo de codificação!", "Ooops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                panelGrafismo.Refresh();
                g.desenharQuadro();
                return;
            }

            if (checkBoxBipolarAMI.Checked)
            {
                Encoding.aplicarBipolarAMI(textBoxCodigoBinario.Text, g);
            }

            if (checkBoxDiferencialManchester.Checked)
            {
                Encoding.aplicarDiferencialManchester(textBoxCodigoBinario.Text, g);
            }

            if (checkBoxNRZI.Checked)
            {
                Encoding.aplicarNRZI(textBoxCodigoBinario.Text, g);
            }

            if (checkBoxNRZL.Checked)
            {
                Encoding.aplicarNRZL(textBoxCodigoBinario.Text, g);
            }

            if (checkBoxPseudoternary.Checked)
            {
                Encoding.aplicarPseudoternary(textBoxCodigoBinario.Text, g);
            }

            if (checkBoxManchester.Checked)
            {
                Encoding.aplicarManchester(textBoxCodigoBinario.Text, g);
            }
        }

        private void frmEncodeModulation_Load(object sender, EventArgs e)
        {
            labelValorFrequencia.Text = Convert.ToString(hScrollBarFrequencia.Value) + " Hz";
            labelValorAmplitude.Text = Convert.ToString(hScrollBarAmplitude.Value);
            labelValorTempo.Text = Convert.ToString(hScrollBarTempo.Value) + " ms";
            labelValorFrequencia2.Text = Convert.ToString(hScrollBarFrequencia2.Value) + " Hz";
        }

        private void hScrollBarFrequencia_ValueChanged(object sender, EventArgs e)
        {
            Graficos g = new Graficos(panelGrafismoModulation.CreateGraphics());
            panelGrafismoModulation.Refresh();

            labelValorFrequencia.Text = Convert.ToString(hScrollBarFrequencia.Value) + " Hz";

            if (radioButtonAmplitudeShiftKeying.Checked)
            {
                Modulation.aplicarAmplitudeShiftKeying(textBoxCodigoBinario.Text, g, Convert.ToDouble(hScrollBarFrequencia.Value), Convert.ToDouble(hScrollBarAmplitude.Value), hScrollBarTempo.Value);
            }
            else if (radioButtonFrequencyShiftKeying.Checked)
            {
                Modulation.aplicarFrequencyShiftKeying(textBoxCodigoBinario.Text, g, Convert.ToDouble(hScrollBarFrequencia.Value), Convert.ToDouble(hScrollBarAmplitude.Value), hScrollBarTempo.Value, Convert.ToDouble(hScrollBarFrequencia2.Value));
            }
            else if (radioButtonPhaseShiftKeying.Checked)
            {
                Modulation.aplicarPhaseShiftKeying(textBoxCodigoBinario.Text, g, Convert.ToDouble(hScrollBarFrequencia.Value), Convert.ToDouble(hScrollBarAmplitude.Value), hScrollBarTempo.Value);                
            }
        }

        private void hScrollBarAmplitude_ValueChanged(object sender, EventArgs e)
        {
            Graficos g = new Graficos(panelGrafismoModulation.CreateGraphics());
            panelGrafismoModulation.Refresh();

            labelValorAmplitude.Text = Convert.ToString(hScrollBarAmplitude.Value);

            if (radioButtonAmplitudeShiftKeying.Checked)
            {
                Modulation.aplicarAmplitudeShiftKeying(textBoxCodigoBinario.Text, g, Convert.ToDouble(hScrollBarFrequencia.Value), Convert.ToDouble(hScrollBarAmplitude.Value), hScrollBarTempo.Value);
            }
            else if (radioButtonFrequencyShiftKeying.Checked)
            {
                Modulation.aplicarFrequencyShiftKeying(textBoxCodigoBinario.Text, g, Convert.ToDouble(hScrollBarFrequencia.Value), Convert.ToDouble(hScrollBarAmplitude.Value), hScrollBarTempo.Value, Convert.ToDouble(hScrollBarFrequencia2.Value));
            }
            else if (radioButtonPhaseShiftKeying.Checked)
            {
                Modulation.aplicarPhaseShiftKeying(textBoxCodigoBinario.Text, g, Convert.ToDouble(hScrollBarFrequencia.Value), Convert.ToDouble(hScrollBarAmplitude.Value), hScrollBarTempo.Value);                
            }
        }

        private void hScrollBarTempo_ValueChanged(object sender, EventArgs e)
        {
            Graficos g = new Graficos(panelGrafismoModulation.CreateGraphics());
            panelGrafismoModulation.Refresh();

            labelValorTempo.Text = Convert.ToString(hScrollBarTempo.Value) + " ms";

            if (radioButtonAmplitudeShiftKeying.Checked)
            {
                Modulation.aplicarAmplitudeShiftKeying(textBoxCodigoBinario.Text, g, Convert.ToDouble(hScrollBarFrequencia.Value), Convert.ToDouble(hScrollBarAmplitude.Value), hScrollBarTempo.Value);
            }
            else if (radioButtonFrequencyShiftKeying.Checked)
            {
                Modulation.aplicarFrequencyShiftKeying(textBoxCodigoBinario.Text, g, Convert.ToDouble(hScrollBarFrequencia.Value), Convert.ToDouble(hScrollBarAmplitude.Value), hScrollBarTempo.Value, Convert.ToDouble(hScrollBarFrequencia2.Value));
            }
            else if (radioButtonPhaseShiftKeying.Checked)
            {
                Modulation.aplicarPhaseShiftKeying(textBoxCodigoBinario.Text, g, Convert.ToDouble(hScrollBarFrequencia.Value), Convert.ToDouble(hScrollBarAmplitude.Value), hScrollBarTempo.Value);                
            }
        }

        private void hScrollBarFrequencia2_ValueChanged(object sender, EventArgs e)
        {          
            this.labelValorFrequencia2.Text = Convert.ToString(this.hScrollBarFrequencia2.Value) + " hz";

            if (radioButtonFrequencyShiftKeying.Checked)
            {
                Graficos g = new Graficos(panelGrafismoModulation.CreateGraphics());
                panelGrafismoModulation.Refresh();

                Modulation.aplicarFrequencyShiftKeying(textBoxCodigoBinario.Text, g, Convert.ToDouble(hScrollBarFrequencia.Value), Convert.ToDouble(hScrollBarAmplitude.Value), hScrollBarTempo.Value, Convert.ToDouble(hScrollBarFrequencia2.Value));
            }
        }
    }
}