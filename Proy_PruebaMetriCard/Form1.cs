using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proy_PruebaMetriCard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _error = "";
            Basico_Metricard.BasicoMetri._ejecuta_proceso_envia_metricard(ref _error);
            //********************
            //si es que hay un error entonces grabamos el error en tabla del sql
            if (_error.Trim().Length > 0)
            {
                Basico_Metricard.BasicoMetri.insertar_error_service_metricard(_error);
            }

           
            //Basico_Metricard.BasicoMetri._ejecuta_proceso_envia_metricard(ref _error);

            if (_error.Length==0)
            {
                MessageBox.Show("ok se envio", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            { 
                MessageBox.Show(_error, "aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
