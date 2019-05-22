using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.IO;
using ConsultReniec;
using WS_ConsCliente.Clases;

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
        public Boolean ws_bc_cl_not_exists(string dni)
        {
            Boolean _noexiste = false;
            Basico valida_not = null;
            try
            {
                valida_not=new Basico();
                _noexiste=valida_not.get_valida_bc_cl_not_exists(dni);

            }
            catch (Exception)
            {

                _noexiste=false;
            }
            return _noexiste;
        }

        [WebMethod]
        public List<BataClubFormato> ws_formato_bataclub()
        {
            List<BataClubFormato> lista = null;
            Basico get_format = null;
            try
            {
                get_format = new Basico();
                lista = get_format.get_formato_bataclub();
            }
            catch (Exception)
            {
                lista = null;
            }
            return lista;
        }

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
        public List<Barra> ws_buscar_barra_dni(string dni)
        {
            List<Barra> bus = null;
            try
            {
                bus = Basico.buscar_barra_dni(dni);
            }
            catch
            {
                bus = null;
            }
            return bus;
        }
        [WebMethod]
        public GeneraCuponBata generacupon()
        {
            return new GeneraCuponBata();
        }

        [WebMethod]
        public GeneraCuponBata ws_getbarra(GeneraCuponBata genera_cupon)
        {
            GeneraCuponBata gen = null;
            try
            {
                Basico.get_cupon_genauto(ref genera_cupon);
                gen = genera_cupon;
            }
            catch
            {
                gen = null;
            }
            return gen;
        }

        [WebMethod]
        public PromBata ws_getprombata(string cod,string tda,string dni)
        {
            PromBata getprom = null;
            try
            {
                Basico get_bas = new Basico();
                getprom = get_bas.get_prombata(cod,tda,dni);
            }
            catch
            {
                getprom = null;
            }
            return getprom;
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
                dtcliente=Basico._consulta_cliente_bata(_dniruc);
            }
            catch
            { 
                dtcliente=null;
            }

            return dtcliente;
        }
        [WebMethod]
        public DataTable ws_conscliente_bata(string _dniruc)
        {
            DataTable dtcliente = null;
            try
            {
                dtcliente = Basico._consulta_cliente_bata(_dniruc);
            }
            catch
            {
                dtcliente = null;
            }
            return dtcliente;
        }
        [WebMethod]
        public Boolean ws_insertcliente_bata(string dniruc, string nombres, string apelpat, string apemat,
                                                     string email, string telefono, string codtda)
        {
            Boolean valida_ws = false;
            try
            {
                valida_ws = Basico._insertar_cliente_bata(dniruc, nombres, apelpat, apemat,
                                                          email, telefono, codtda);
            }
            catch (Exception)
            {
                valida_ws = false;               
            }
            return valida_ws;
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
            ConsultReniec.PersonaReniec myInfo= new ConsultReniec.PersonaReniec(true); 
            string _codigo_captcha = "";            
            try
            {
                dt = new DataTable();
                dt.Columns.Add("dni", typeof(string));
                dt.Columns.Add("nombres", typeof(string));                                
                dt.Columns.Add("apepat", typeof(string));
                dt.Columns.Add("apemat", typeof(string));
                dt.Columns.Add("estado", typeof(Int32));

                WsSunat.validateLogin conexion_ws = new WsSunat.validateLogin();
                conexion_ws.Username = "BataPeru";
                conexion_ws.Password = "Bata2018**.";
                WsSunat.Sunat_Reniec_PESoapClient ws_data = new WsSunat.Sunat_Reniec_PESoapClient();
                var data = ws_data.ws_persona_reniec(conexion_ws, _dni);
                string nombres = "";string ape_pat = "";string ape_mat = "";
                if (data!=null)
                {
                    if (data.Nombres.Trim().Length>0)
                    {
                        myInfo.estado_reniec = 231;
                        nombres = data.Nombres;
                        ape_pat = data.ApePat;
                        ape_mat = data.ApeMat;
                    }
                }


                //string filePath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                //string _tessdata = Path.GetDirectoryName(filePath) + "\\tessdata";

                //_codigo_captcha = myInfo.UseTesseract(_tessdata);
                //myInfo.GetInfo(_dni, _codigo_captcha);
                //myInfo.estado_reniec

                //if (myInfo.Nombres == null)
                //{
                //    _codigo_captcha = myInfo.UseTesseract(_tessdata);
                //    myInfo.GetInfo(_dni, _codigo_captcha);
                //}

                //if (myInfo.Nombres == null)
                //{
                //    _codigo_captcha = myInfo.UseTesseract(_tessdata);
                //    myInfo.GetInfo(_dni, _codigo_captcha);
                //}
                //if (myInfo.Nombres == "Error!")
                //{
                //myInfo.GetInfo(_dni, myInfo.UseTesseract(_tessdata));
                //dt.Rows.Add(_dni, myInfo.Nombres,myInfo.ApePaterno,myInfo.ApeMaterno, myInfo.estado_reniec);
                dt.Rows.Add(_dni, nombres,ape_pat,ape_mat, myInfo.estado_reniec);


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

                

                WsSunat.validateLogin valida_user = new WsSunat.validateLogin();
                valida_user.Username = "BataPeru";
                valida_user.Password = "Bata2018**.";

                WsSunat.Sunat_Reniec_PESoapClient c = new WsSunat.Sunat_Reniec_PESoapClient();
                var data_sunat = c.ws_persona_sunat(valida_user, _ruc);


                //string filePath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                //string _tessdata = Path.GetDirectoryName(filePath) + "\\tessdata";    
                myInfo = new ConsultaSunat.PersonaSunat(true);
                //_codigo_captcha = myInfo.UseTesseract(_tessdata);
                //myInfo.GetInfo(_ruc, _codigo_captcha);

                //if (myInfo.Nombres == "Error!")
                //{
                //    _codigo_captcha = myInfo.UseTesseract(_tessdata);
                //    myInfo.GetInfo(_ruc, _codigo_captcha);
                //}
                //if (myInfo.Nombres == "Error!")
                //{
                //    _codigo_captcha = myInfo.UseTesseract(_tessdata);
                //    myInfo.GetInfo(_ruc, _codigo_captcha);
                //}
                //if (myInfo.Nombres == "Error!")
                //{
                //    _codigo_captcha = myInfo.UseTesseract(_tessdata);
                //    myInfo.GetInfo(_ruc, _codigo_captcha);
                //}

                if (data_sunat.Valida_Sunat.Estado=="0")
                {
                    dt.Rows.Add(data_sunat.Direccion, data_sunat.Razon_Social, _ruc, data_sunat.Telefono);
                }
                else
                {
                    
                    dt.Rows.Add(myInfo.direccion, "Error!", _ruc, myInfo.telefono);
                }

                //if (myInfo.Nombres == "Error!")
                //{
                //    //myInfo.GetInfo(_ruc, myInfo.UseTesseract(_tessdata));
                //    dt.Rows.Add(myInfo.direccion, myInfo.Nombres, _ruc,myInfo.telefono);

                //}
                //else
                //{
                //    dt.Rows.Add(myInfo.direccion, myInfo.Nombres, _ruc, myInfo.telefono);
                  
                //}
                dt.TableName = "cliente";
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        #region<REGION PARA GIFT CARD>

        [WebMethod]
        public void ws_ActivaGiftCard(string numero, string dni_activa, string nombres, string apepat, string apemat)
        {
            /*DataTable ListaGiftCard = null;*/
            try
            {
                Basico.ActivaGiftCard(numero, dni_activa, nombres, apepat, apemat);

            }
            catch (Exception exc)
            {
                throw exc;
                /*ListaGiftCard = null;*/
            }
        }

        [WebMethod]
        public void ws_GrabarSQL_Ticket(string tienda, string serie, string codigo, string fecha, string dni, string nombres, string apepat, string apemat, string forpag, string tarjeta, string nro_tarj, string detail)
        {
            /*DataTable ListaGiftCard = null;*/
            try
            {
                Basico.GrabarSQL_Ticket(tienda, serie, codigo, fecha, dni, nombres, apepat, apemat, forpag, tarjeta, nro_tarj, detail);

            }
            catch (Exception exc)
            {
                throw exc;
                /*ListaGiftCard = null;*/
            }
        }

        [WebMethod]
        public DataTable ws_BuscarGiftCard(string numero)
        {
            DataTable ListaGiftCard = null;
            try
            {
                ListaGiftCard = Basico.BuscarGiftCard(numero);
                ListaGiftCard.TableName = "datos";
            }
            catch
            {
                ListaGiftCard = null;
            }
            return ListaGiftCard;
        }

        [WebMethod]
        public DataTable ws_BuscarTicketGF(string empresa, string serie, string numero)
        {
            DataTable dt = null;
            try
            {
                dt = Basico.BuscarTicketGF(empresa, serie, numero);
                dt.TableName = "datos";
            }
            catch (Exception exc)
            {
                throw exc;
            }

            return dt;
        }
        #endregion

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

        #region<REGION PARA SOPORTE>
        [WebMethod]
        public List<Soporte> ws_lista_soporte()
        {
            List<Soporte> lista = null;
            Basico get_sop = null;
            try
            {
                get_sop = new Basico();
                lista = get_sop.get_soporte_list();
            }
            catch (Exception)
            {
                lista = null;                    
            }
            return lista;
        }
        #endregion

    }
}
