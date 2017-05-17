using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proy_Prueba
{
    public partial class Consultar : Form
    {
        public Consultar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultaCliente.Cons_ClienteSoapClient consulta = new ConsultaCliente.Cons_ClienteSoapClient();
            var cliente = consulta.ws_persona_reniec(textBox1.Text);
            DataTable dt =(DataTable) cliente;
            string _valor = "";

            //ConsultaCliente.Cons_ClienteSoapClient consulta = new ConsultaCliente.Cons_ClienteSoapClient();
            //Boolean existe = consulta.ws_verifica_version_apltda("50210", "WPF", "123");

            //if (!existe)
            //{
            //    string _update = consulta.ws_update_apltda("50210", "WPF", "123");
            //}

            /*modifca*/
        }
    }
}
