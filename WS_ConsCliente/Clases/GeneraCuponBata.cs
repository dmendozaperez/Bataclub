using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_ConsCliente.Clases
{
    [Serializable]
    public class GeneraCuponBata
    {
        public string nombres_prin { get; set; }
        public string nombres { get; set; }
        public string apepat { get; set; }
        public string apemat { get; set; }
        public string email { get; set; }
        public string dni { get; set; }
        public decimal pordes { get; set; }
        public DateTime fechaini { get; set; }
        public DateTime fechafin { get; set; }
        public decimal paresmax { get; set; }
        public string grupo { get; set; }
        public string barra { get; set; }
        public string correlativo { get; set; }
        public string serie { get; set; }
        public string tipcup { get; set; }

        public string tda_gen_cup { get; set; }
    }
}