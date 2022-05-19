using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conjetura_del_Goldbach
{
    public partial class Form1 : Form
    {
        // Atributos
        private int Num;
        private Calculo Lista;

        /// <summary>
        /// Clase principal
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumero.Text == "")
                {
                    MessageBox.Show("Por favor ingrese al menos un dígito", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumero.Focus();
                }
                else
                    if ((Convert.ToUInt32(txtNumero.Text) % 2) != 0 || Convert.ToUInt32(txtNumero.Text) <= 2)
                    {
                        MessageBox.Show("Este número no cumples las condiciones de la cojetura de Goldbach. Inténtelo de nuevo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumero.Clear(); txtNumero.Focus();
                    }
                    else
                    {
                        Num = Convert.ToInt32(txtNumero.Text);

                        Lista = new Calculo(Num);

                        int[] ArregloPrimos = Lista.CalcularPrimos();

                        int CantidadSuma = 1;

                        for (int m = 0; m < ArregloPrimos.Length; m++)
                        {
                            for (int n = 0; n < ArregloPrimos.Length; n++)
                            {
                                if (ArregloPrimos[m] + ArregloPrimos[n] == Num)
                                {
                                    ListaSumas.Items.Add(string.Format("\n\n{0}) {1} + {2} = {3}", CantidadSuma, ArregloPrimos[m], ArregloPrimos[n], Num));
                                    CantidadSuma++; ArregloPrimos[n] = 0;
                                }
                            }
                        }

                    }
            }
            catch (Exception ex) { MessageBox.Show("Ha ocurrido esto: " + ex); }
           
        }

        private void txtNumero_TextChanged(object sender, EventArgs e) { }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtNumero.Clear();
            ListaSumas.Items.Clear();
            txtNumero.Focus();
        }

        private void SoloNumero(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true; return;
            }
        }
    }
}
