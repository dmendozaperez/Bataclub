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

        private void btnEnvioVenta_Click(object sender, EventArgs e)
        {

            string _error = "";
            Basico_Metricard.BasicoMetri._ejecuta_proceso_enviaVenta_metricard(ref _error);
            //********************
            //si es que hay un error entonces grabamos el error en tabla del sql
            if (_error.Trim().Length > 0)
            {
                Basico_Metricard.BasicoMetri.insertar_error_service_metricard(_error);
            }


            //Basico_Metricard.BasicoMetri._ejecuta_proceso_envia_metricard(ref _error);

            if (_error.Length == 0)
            {
                MessageBox.Show("ok se envio", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(_error, "aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnenviometri_Click(object sender, EventArgs e)
        {
            Int32 existe = 0;Int32 no_existe = 0;
            Cursor.Current = Cursors.WaitCursor;
            Basico_Metricard.BasicoMetri._envio_cliente_metri(ref existe,ref no_existe);
            MessageBox.Show("ok se envio existe cliente==>" + existe.ToString() + " no existe cliente==>" + no_existe.ToString()  , "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Cursor.Current = Cursors.Default;
        }
    }
}
