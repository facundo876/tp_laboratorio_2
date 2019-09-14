using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();

        }
        /// <summary>
        ///     Limpia los datos de los textBots, ComboBox, y Label de la pantalla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperador.Text = "";
        }
        /// <summary>
        ///     Realiza la operacion con los datos de los textBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 = new Numero(txtNumero2.Text);

           lblResultado.Text =string.Format("{0}", Calculadora.Operar(numero1, numero2, cmbOperador.Text));
            
        }
        /// <summary>
        ///     Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        ///     Pasa de binario a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCanvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numeroBinario = new Numero(lblResultado.Text);
            
            lblResultado.Text = numeroBinario.DecimalBinario(lblResultado.Text);
            
        }
        /// <summary>
        ///     Pasa de binario a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numeroBinario = new Numero(lblResultado.Text);

            for (int i=0; i<lblResultado.Text.Length; i++)
            {
                
                if (!(lblResultado.Text[i] == '1' || lblResultado.Text[i] == '0'))
                {
                    break;
                }
                else if (i == (lblResultado.Text.Length-1))
                {
                    lblResultado.Text = numeroBinario.BinaroDecimal(lblResultado.Text);
                }
            }

            
        }
    }
}
