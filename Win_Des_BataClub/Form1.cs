using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_Des_BataClub
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ws_bataclub.Autenticacion conexion_ws = new ws_bataclub.Autenticacion();
            conexion_ws.user_name = "F8CB7D6FFA8BC631396B7C39262BD6";
            conexion_ws.user_password = "8A05E0EE00BD343B093A9E215DF765";
            


            ws_bataclub.WS_BataClubSoapClient conexionData = new ws_bataclub.WS_BataClubSoapClient();
            var conexion_estado= conexionData.ws_conexion(conexion_ws);

            #region<GENERACION DE CODIGO DE BARRA POR EMAIL>

            ws_bataclub.WS_BataClubSoapClient generacupon = new ws_bataclub.WS_BataClubSoapClient();
            var barra_obj = generacupon.ws_genera_cupon("pruebametri", "pruebametri@bata.com", "21156125", 20, 6,1,"GRUPO");

            #endregion

            #region<GENERACION DE BARRA POR BLOQUE>
            //ws_bataclub.WS_BataClubSoapClient genecupon2 = new ws_bataclub.WS_BataClubSoapClient();
            //ws_bataclub.
            //ws_bataclub.
            //ws_bataclub.
            //ws_bataclub.
            //ws_bataclub.l

            //ws_bataclub.data_genera_cupon[] listar_cliente=new ws_bataclub.data_genera_cupon()[];

            //ws_bataclub. c = new ws_bataclub.WS_BataClubSoap();

            //genecupon2.list_client

            //genecupon2.
            //genecupon2.list_client

            //genecupon2.

            //genecupon2.ws_genera_cupon_array(20, 6, 1, "GRUPO",)
            //genecupon2.

            #endregion

        }
    }
}
