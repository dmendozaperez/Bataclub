using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WS_ConsCliente
{
    public class ConexionData
    {
        //private static string _conexion = ConfigurationManager.ConnectionStrings["SQL_PROD_PE"].ConnectionString;
        //private static string _conexion_bataclub = ConfigurationManager.ConnectionStrings["SQL_PROD_BC"].ConnectionString;
        public static string conexion
        {
            //get { return _conexion; }
            //get { return "Server=10.10.10.208;Database=BdTienda;User ID=sa;Password=Bata2013;Trusted_Connection=False;"; }
            get { return "Server=192.168.2.14;Database=BDPOS;User ID=pos_oracle;Password=Bata2018**;Trusted_Connection=False;"; ; }
        }
        public static string conexion_bataclub
        {
            //get { return _conexion_bataclub; }
            //get { return "Server=10.10.10.208;Database=BdBataClub;User ID=sa;Password=Bata2013;Trusted_Connection=False;"; }
            get { return "Server=192.168.2.14;Database=BDBATACLUB;User ID=pos_oracle;Password=Bata2018**;Trusted_Connection=False;"; }
        }
    }
}