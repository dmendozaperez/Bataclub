using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bata.Clases
{
    public class PromBata
    {
        #region<GENERACION DE PROMOCION INSTANTANEAS>
       
        public Boolean valida { get; set; }
        public string nom_prom { get; set; }
        public DateTime fecha_ini { get; set; }
        public DateTime fecha_fin { get; set; }
        public Decimal por_des { get; set; }
        public Decimal max_par { get; set; }


       

        public PromBata lista(string cod,string tda,string dni)
        {
            PromBata prom = null;
            try
            {
                ws_clientedniruc.Cons_ClienteSoapClient ws_prom = new ws_clientedniruc.Cons_ClienteSoapClient();
                var get_prom = ws_prom.ws_getprombata(cod, tda,dni);
                if (get_prom!=null)
                {
                    prom = new PromBata();
                    prom.valida = get_prom.valida;
                    prom.nom_prom = get_prom.nom_prom;
                    prom.fecha_ini = get_prom.fecha_ini;
                    prom.fecha_fin = get_prom.fecha_fin;
                    prom.por_des = get_prom.por_des;
                    prom.max_par = get_prom.max_par;
                }

            }
            catch
            {
                prom = null;
            }
            return prom;
        }
        public CuponGenerado getcupon_generado(CuponGenerado setgenerado)
        {
            ws_clientedniruc.GeneraCuponBata list_cupon_str = null;
            ws_clientedniruc.Cons_ClienteSoapClient genera_cupon = null;
            CuponGenerado cup_gen = null;
            try
            {
                cup_gen = new CuponGenerado();

                list_cupon_str = new ws_clientedniruc.GeneraCuponBata();
                list_cupon_str.nombres_prin = setgenerado.nombres_prin;
                list_cupon_str.nombres = setgenerado.nombres;
                list_cupon_str.apepat = setgenerado.apepat;
                list_cupon_str.apemat = setgenerado.apemat;
                list_cupon_str.email = setgenerado.email;
                list_cupon_str.dni = setgenerado.dni;
                list_cupon_str.pordes = setgenerado.pordes;
                list_cupon_str.fechaini = setgenerado.fechaini;
                list_cupon_str.fechafin = setgenerado.fechafin;
                list_cupon_str.paresmax = setgenerado.paresmax;
                list_cupon_str.grupo = setgenerado.grupo;
                list_cupon_str.barra = setgenerado.barra;
                list_cupon_str.tda_gen_cup = setgenerado.tda_gen_cup;

                genera_cupon = new ws_clientedniruc.Cons_ClienteSoapClient();

                var return_cupon = genera_cupon.ws_getbarra(list_cupon_str);

                cup_gen = new CuponGenerado();
                if (return_cupon!=null)
                {
                    cup_gen.nombres_prin = return_cupon.nombres_prin;
                    cup_gen.nombres = return_cupon.nombres;
                    cup_gen.apepat = return_cupon.apepat;
                    cup_gen.apemat = return_cupon.apemat;
                    cup_gen.email = return_cupon.email;
                    cup_gen.dni = return_cupon.dni;
                    cup_gen.pordes = return_cupon.pordes;
                    cup_gen.fechaini = return_cupon.fechaini;
                    cup_gen.fechafin = return_cupon.fechafin;
                    cup_gen.paresmax = return_cupon.paresmax;
                    cup_gen.grupo = return_cupon.grupo;
                    cup_gen.barra = return_cupon.barra;
                    cup_gen.serie = return_cupon.serie;
                    cup_gen.correlativo = return_cupon.correlativo;
                    cup_gen.tipcup = return_cupon.tipcup;            
                }

            }
            catch
            {
                cup_gen = null;
            }
            return cup_gen;
        }
        #endregion
    }
    public class CuponGenerado
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
