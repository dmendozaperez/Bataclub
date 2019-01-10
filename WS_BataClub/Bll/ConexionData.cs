using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WS_BataClub.Bll
{
    public class ConexionData
    {
        private static string _conexion =Encripta.encryption.RijndaelDecryptString(ConfigurationManager.ConnectionStrings["SQL_PE"].ConnectionString);
        public static string conexion
        {
            get { return _conexion; }
            //get { return "Server=posperu.bgr.pe;Database=BDPOS;User ID=pos_oracle;Password=Bata2018**;Trusted_Connection=False;"; }
        }
    }
}