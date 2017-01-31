using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_BataClub.Bll
{
    public class conexion_ws
    {
        public int cod_error { set; get; }
        public string des_error { set; get; }
        public static Boolean _conexion_ws { set; get; }
    }
}