using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_BataClub.Bll
{
    public class ConexionData
    {
        public static string conexion
        {
            get { return "Server=10.10.10.208;Database=BdTienda;User ID=sa;Password=Bata2013;Trusted_Connection=False;"; }
        }
    }
}