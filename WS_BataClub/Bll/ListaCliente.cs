using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_BataClub.Bll
{
    [Serializable]
    public class ListaCliente
    {
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string barra { get; set; }
        public string error { get; set; }
        
    }
    public class ListaItems
    {
        public ListaCliente[] Lista { get; set; }
    }
}