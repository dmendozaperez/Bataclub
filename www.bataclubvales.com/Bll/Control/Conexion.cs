using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
namespace www.bataclubvales.com.Bll
{
    public class Conexion
    {
        static string strconexion = Encripta.encryption.RijndaelDecryptString(ConfigurationManager.ConnectionStrings["SQL_PE"].ConnectionString);
        //static string strconexion = "Server=posperu.bgr.pe;Database=BDBATACLUB;User ID=pos_oracle;Password=Bata2018**;Trusted_Connection=False;";
        public static string myconexion()
        {
            return strconexion;
        }
    }
}