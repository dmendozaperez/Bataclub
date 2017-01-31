using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.IO;
using ConsultReniec;

//using ConsultReniec;
//using ConsultaSunat;
namespace WS_ConsCliente
{
    /// <summary>
    /// Descripción breve de Cons_Cliente
    /// </summary>
    [WebService(Namespace = "http://www.consultabata.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Cons_Cliente : System.Web.Services.WebService
    {

        [WebMethod]
        public Boolean ws_validatdabgwb(string _cod_tda)
        {
            Boolean _valida = false;
            try
            {
                _valida = Basico._valida_tda_bg(_cod_tda);
            }
            catch
            {
                _valida = false;
            }
            return _valida;
        }

        [WebMethod]
        public string ws_update_cliente(string _ruc, string _nombres, string _apepat, string _apemat,
                                                 string _telefono, string _email, string _tda)
        {
            string _valida = "";
            try
            {
                _valida = Basico._actualizar_cliente(_ruc, _nombres, _apepat, _apemat, _telefono, _email, _tda);
            }
            catch(Exception exc)
            {
                _valida = exc.Message;
            }
            return _valida;
        }



        [WebMethod]
        public string ws_update_venta_empl(string _Tip_Id_Ven, string _Nro_Dni_Ven, string _Cod_Tda_Ven,
                                                   string _Nro_Doc_Ven, string _Tip_Doc_Ven, string _Ser_Doc_Ven,
                                                   string _Num_Doc_Ven, string _Fec_Doc_Ven, string _Est_Doc_Ven,
                                                   string _Fc_Nin_Ven)
        {
            string _error = "";
            try
            {
                _error = Basico.update_venta_empleado(_Tip_Id_Ven, _Nro_Dni_Ven, _Cod_Tda_Ven,
                                                    _Nro_Doc_Ven, _Tip_Doc_Ven, _Ser_Doc_Ven,
                                                    _Num_Doc_Ven, _Fec_Doc_Ven, _Est_Doc_Ven,
                                                    _Fc_Nin_Ven);
            }
            catch(Exception exc)
            {
                _error = exc.Message;
            }
            return _error;
        }

        [WebMethod]
        public string ws_update_vales(string _serie, string _correlativo, string _cod_tda_venta, string _dni_venta,
            string _nombres_venta, string _fecha_doc, string _tipo_doc, string _serie_doc, string _numero_doc,
            string _estado_doc, string _fc_nint, string _email_venta, string _telefono_venta)
        {
            string _error = "";
            try
            {
                _error = Basico.update_vales(_serie, _correlativo, _cod_tda_venta, _dni_venta,
                _nombres_venta, _fecha_doc, _tipo_doc, _serie_doc, _numero_doc, _estado_doc, _fc_nint,_email_venta,_telefono_venta);
            }
            catch(Exception exc)
            {
                _error = exc.Message;
            }
            return _error;
        }

        [WebMethod]
        public DataSet ws_buscar_vales(string _correlativo,string _code,string _tda="")
        {
            DataSet ds = null;
            try
            {
                ds = Basico.ds_vales(_correlativo, _code, _tda);
            }
            catch
            {
                ds = null;
            }
            return ds;
        }
        [WebMethod]
        public DataSet ws_buscar_desxdni(string _dni,string _codtda,string _tip_des)
        {
            DataSet ds = null;
            try
            {
                ds = Basico.ds_desdni(_dni,_codtda,_tip_des);
            }
            catch
            {
                ds = null;
            }
            return ds;
        }

        [WebMethod]
        public DataTable  ws_conscliente(string _dniruc)
        {
            DataTable dtcliente = null;
            try
            {
                dtcliente=Basico._data_cliente(_dniruc);
            }
            catch
            { 
                dtcliente=null;
            }

            return dtcliente;
        }
        //public enum Resul
        //{
        //    /// <summary>
        //    /// Se encontro la persona
        //    /// </summary>
        //    Ok = 0,
        //    /// <summary>
        //    /// No se encontro la persona
        //    /// </summary>
        //    NoResul = 1,
        //    /// <summary>
        //    /// la imagen capcha no es valida
        //    /// </summary>
        //    ErrorCapcha = 2,
        //    /// <summary>
        //    /// Error no especificado
        //    /// </summary>
        //    Error = 3,
        //}

        [WebMethod]
        public DataTable ws_persona_reniec(string _dni)
        {
            DataTable dt = null;
            ConsultReniec.PersonaReniec myInfo= new ConsultReniec.PersonaReniec(); 
            string _codigo_captcha = "";            
            try
            {
                dt = new DataTable();
                dt.Columns.Add("dni", typeof(string));
                dt.Columns.Add("nombres", typeof(string));                                
                dt.Columns.Add("apepat", typeof(string));
                dt.Columns.Add("apemat", typeof(string));
                dt.Columns.Add("estado", typeof(Int32));
                string filePath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                string _tessdata = Path.GetDirectoryName(filePath) + "\\tessdata";
              
                _codigo_captcha = myInfo.UseTesseract(_tessdata);
                myInfo.GetInfo(_dni, _codigo_captcha);

                if (myInfo.Nombres==null)
                {
                    _codigo_captcha = myInfo.UseTesseract(_tessdata);
                    myInfo.GetInfo(_dni, _codigo_captcha);
                }

                if (myInfo.Nombres == null)
                {
                    _codigo_captcha = myInfo.UseTesseract(_tessdata);
                    myInfo.GetInfo(_dni, _codigo_captcha);
                }
                //if (myInfo.Nombres == "Error!")
                //{
                //myInfo.GetInfo(_dni, myInfo.UseTesseract(_tessdata));
                dt.Rows.Add(_dni, myInfo.Nombres,myInfo.ApePaterno,myInfo.ApeMaterno, myInfo.estado_reniec);


                //_estado = myInfo.es;
                //}
                //else
                //{
                //    //dt.Rows.Add(myInfo.direccion, myInfo.Nombres, _dni, myInfo.telefono);

                //}
                dt.TableName = "cliente";
            }
            catch
            {
                //myInfo = null;
                dt = null;
            }
            return dt;
        }

        [WebMethod]
        public Data_Sunat ws_info_sunat(string _ruc)
        {
            Data_Sunat data = null;
            ConsultaSunat.PersonaSunat myInfo;
            string _codigo_captcha = "";
            try
            {
                data = new Data_Sunat();
                

                string filePath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                string _tessdata = Path.GetDirectoryName(filePath) + "\\tessdata";
                myInfo = new ConsultaSunat.PersonaSunat();

                _codigo_captcha = myInfo.UseTesseract(_tessdata);
                myInfo.GetInfo(_ruc, _codigo_captcha);

                if (myInfo.Nombres == "Error!")
                {
                    _codigo_captcha = myInfo.UseTesseract(_tessdata);
                    myInfo.GetInfo(_ruc, _codigo_captcha);
                }
                if (myInfo.Nombres == "Error!")
                {
                    _codigo_captcha = myInfo.UseTesseract(_tessdata);
                    myInfo.GetInfo(_ruc, _codigo_captcha);
                }

                if (myInfo.Nombres == "Error!")
                {
                    myInfo.GetInfo(_ruc, myInfo.UseTesseract(_tessdata));
                    //dt.Rows.Add(myInfo.direccion, myInfo.Nombres, _ruc, myInfo.telefono);
                    data.direccion = myInfo.direccion;
                    data.nombres = myInfo.Nombres;
                    data.ruc = _ruc;
                    data.telefono =myInfo.telefono;


                }
                else
                {
                    //dt.Rows.Add(myInfo.direccion, myInfo.Nombres, _ruc, myInfo.telefono);
                    data.direccion = myInfo.direccion;
                    data.nombres = myInfo.Nombres;
                    data.ruc = _ruc;
                    data.telefono = myInfo.telefono;

                }                
            }
            catch
            {
                data = null;
            }
            return data;
        }

        [WebMethod]
        public DataTable ws_persona_sunat(string _ruc)
        {
            DataTable dt = null;
            ConsultaSunat.PersonaSunat myInfo;
            string _codigo_captcha = "";
            try
            {
                dt = new DataTable();
                dt.Columns.Add("direccion", typeof(string));
                dt.Columns.Add("nombres", typeof(string));
                dt.Columns.Add("ruc", typeof(string));
                dt.Columns.Add("telefono", typeof(string));

                string filePath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                string _tessdata = Path.GetDirectoryName(filePath) + "\\tessdata";    
                myInfo = new ConsultaSunat.PersonaSunat();
                _codigo_captcha = myInfo.UseTesseract(_tessdata);
                myInfo.GetInfo(_ruc, _codigo_captcha);

                if (myInfo.Nombres == "Error!")
                {
                    _codigo_captcha = myInfo.UseTesseract(_tessdata);
                    myInfo.GetInfo(_ruc, _codigo_captcha);
                }
                if (myInfo.Nombres == "Error!")
                {
                    _codigo_captcha = myInfo.UseTesseract(_tessdata);
                    myInfo.GetInfo(_ruc, _codigo_captcha);
                }
                if (myInfo.Nombres == "Error!")
                {
                    _codigo_captcha = myInfo.UseTesseract(_tessdata);
                    myInfo.GetInfo(_ruc, _codigo_captcha);
                }


                if (myInfo.Nombres == "Error!")
                {
                    myInfo.GetInfo(_ruc, myInfo.UseTesseract(_tessdata));
                    dt.Rows.Add(myInfo.direccion, myInfo.Nombres, _ruc,myInfo.telefono);

                }
                else
                {
                    dt.Rows.Add(myInfo.direccion, myInfo.Nombres, _ruc, myInfo.telefono);
                  
                }
                dt.TableName = "cliente";
            }
            catch
            {
                dt = null;
            }
            return dt;
        }


        #region<REGIONES PARA CONEXIONES BATACLUB BD>
        [WebMethod]
        public Boolean ws_verifica_version_apltda(string _cod_tda, string _nom_apl, string _ver_apl)
        {
            Boolean _valida = false;
            try
            {
                _valida = Basico._existe_version_apl(_cod_tda, _nom_apl, _ver_apl);
            }
            catch
            {
                _valida = false;
            }
            return _valida;
        }
        [WebMethod]
        public string ws_update_apltda(string _cod_tda, string _nom_apl, string _ver_apl)
        {
            string _error = "";
            try
            {
                _error = Basico._update_apltda(_cod_tda, _nom_apl, _ver_apl);
            }
            catch(Exception exc)
            {
                _error = exc.Message;
            }
            return _error;
        }
        #endregion
    }
}
