using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using WS_BataClub.Bll;
namespace WS_BataClub
{
    /// <summary>
    /// Descripción breve de WS_BataClub
    /// </summary>
    [WebService(Namespace = "http://bataclub.com.pe/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_BataClub : Seguridad
    {
        //private  Boolean _conexion_service = false;
        [WebMethod, SoapHeader("CredencialAutenticacion")]
        public conexion_ws ws_conexion()
        {
            conexion_ws conexion = null;
            Boolean _valida_conexion = false;
            try
            {
                conexion = new conexion_ws();
                _valida_conexion=Basico.VerificarPermisos(CredencialAutenticacion);
            }
            catch
            {
                conexion = null;
            }
            conexion_ws._conexion_ws = _valida_conexion;
            if (!_valida_conexion)
            {
                conexion.cod_error = 0;
                conexion.des_error = "usuario y/o password no valida";
            }
            else
            {
                conexion.cod_error = 1;
                conexion.des_error = "Conexion Exitosa...";
            }

            return conexion; 

        }
        [WebMethod]
        public ListaCliente list_client()
        {
            return new ListaCliente();
        }
        [WebMethod]
        public ListaItems list_items()
        {
            return new ListaItems();
        }


       

        [WebMethod]
        public List<ListaCliente> ws_genera_list_barra(ListaItems list_cliente, int _pordes, int _dias, int _pares_max, string _tipo_des)
        {            
            List<ListaCliente> lista_return_barra = null;
            try
            {
                if (list_cliente.Lista.Count()>0)
                {
                     lista_return_barra =Basico.return_barra_list(list_cliente, _pordes, _dias, _pares_max, _tipo_des);
                   
                }                
            }
            catch
            {
                lista_return_barra = null;
            }
            return lista_return_barra;
        }

        [WebMethod]
        public data_genera_cupon ws_genera_cupon(string _nombres, string _email, string _dni, int _pordes, int _dias,int _pares_max,string _tipo_des)
        {
            data_genera_cupon _barra =null;
            string _str = "";
            int _cod_error = 0;
            string _des_error = "";
            try
            {
                if (conexion_ws._conexion_ws)
                { 
                   _barra = new data_genera_cupon();
                   _str =Basico._genera_vales(_nombres, _email, _dni, _pordes, _dias,_pares_max, _tipo_des);
                }
            }
            catch(Exception exc)
            {
                _cod_error = exc.HResult;
                _des_error = exc.Message;                
            }

            if (conexion_ws._conexion_ws)
            { 
                _barra.cod_barra = _str;
                _barra.cod_error = _cod_error;
                _barra.des_error = _des_error;
            }

            return _barra;
        }
        

    }
}
