using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using ConsultReniec;
using System.Text.RegularExpressions;
using Bata.ws_clientedniruc;

namespace Bata.Clases
{
    public class Clientes
    {
        public static Image _img_captcha { set; get; }
        public static  PersonaReniec _persona_reniec { set; get; }
        //public static PersonaSunat _persona_sunat { set; get; }

        public static string _str_codigo_captcha_sunat { set; get; }
        public static string _str_codigo_captcha_reniec { set; get; }

        
        public static DataSet _consulta_vales(string _corre,string _code,string _cod_tda="")
        {
            DataSet ds = null;
            try
            {
                ws_clientedniruc.Cons_ClienteSoapClient ws_cliente = new ws_clientedniruc.Cons_ClienteSoapClient();
                ds = ws_cliente.ws_buscar_vales(_corre, _code, _cod_tda);
            }
            catch
            {
                ds = null;
            }
            return ds;
        }
        public static string _update_vales(string _serie, string _correlativo, string _cod_tda_venta, string _dni_venta,
            string _nombres_venta, string _fecha_doc, string _tipo_doc, string _serie_doc, string _numero_doc,
            string _estado_doc, string _fc_nint, string _email_venta, string _telefono_venta)
        {
            string _error = "";
            try
            {
                ws_clientedniruc.Cons_ClienteSoapClient ws_vales = new ws_clientedniruc.Cons_ClienteSoapClient();
                _error = ws_vales.ws_update_vales(_serie, _correlativo, _cod_tda_venta, _dni_venta,
                                                  _nombres_venta,_fecha_doc,_tipo_doc,_serie_doc,_numero_doc,
                                                  _estado_doc,_fc_nint,_email_venta,_telefono_venta);
            }
            catch(Exception exc)
            {
                _error = exc.Message;
            }
            return _error;
        }
        public static string _update_venta_empl(string _Tip_Id_Ven, string _Nro_Dni_Ven, string _Cod_Tda_Ven,
                                                   string _Nro_Doc_Ven, string _Tip_Doc_Ven, string _Ser_Doc_Ven,
                                                   string _Num_Doc_Ven, string _Fec_Doc_Ven, string _Est_Doc_Ven,
                                                   string _Fc_Nin_Ven)
        {
            string _error = "";
            try
            {
                Cons_ClienteSoapClient ws_update = new Cons_ClienteSoapClient();
                _error = ws_update.ws_update_venta_empl(_Tip_Id_Ven, _Nro_Dni_Ven, _Cod_Tda_Ven,
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
        public static Boolean _insertar_cliente_bata(string dniruc, string nombres, string apelpat, string apemat,
                                                     string email, string telefono, string codtda)
        {
            Boolean valida = false;
            try
            {
                 ws_clientedniruc.Cons_ClienteSoapClient cliente_bata = new Cons_ClienteSoapClient();
                valida = cliente_bata.ws_insertcliente_bata(dniruc,nombres,apelpat,apemat,
                                                            email,telefono,codtda);
            }
            catch (Exception)
            {
                valida = false;                
            }
            return valida;
        }
        public static DataTable _consulta_cliente_bata(string _dniruc)
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                dt.TableName = "Cliente";
                dt.Columns.Add("fc_ruc", typeof(string));
                dt.Columns.Add("fc_nomb", typeof(string));
                dt.Columns.Add("fc_apep", typeof(string));
                dt.Columns.Add("fc_apem", typeof(string));
                dt.Columns.Add("fc_tele", typeof(string));
                dt.Columns.Add("fc_mail", typeof(string));
                dt.Columns.Add("fc_dcli", typeof(string));
                dt.Columns.Add("fc_cubi", typeof(string));

                ws_clientedniruc.Cons_ClienteSoapClient cliente_bata = new Cons_ClienteSoapClient();

                DataTable dt_bata = cliente_bata.ws_conscliente_bata(_dniruc);

                if (dt_bata.Rows.Count>0)
                {
                    string _fc_ruc = dt_bata.Rows[0]["dniruc"].ToString();
                    string _fc_nomb = dt_bata.Rows[0]["nombres"].ToString();// (datosCliente.Nombres != null) ? datosCliente.Nombres.ToString() : "";
                    string _fc_apep = dt_bata.Rows[0]["apelpat"].ToString();// (datosCliente.Apellidos != null) ? datosCliente.Apellidos.ToString() : "";
                    string _fc_apem = dt_bata.Rows[0]["apemat"].ToString();// (datosCliente.ApellidoMaterno != null) ? datosCliente.ApellidoMaterno.ToString() : "";
                    string _fc_tele = dt_bata.Rows[0]["telefono"].ToString();// (datosCliente.Celular != null) ? datosCliente.Celular : "";
                    //if (_fc_tele.Length == 0) _fc_tele = (datosCliente.Fono != null) ? datosCliente.Fono.ToString() : "";
                    string _fc_mail = dt_bata.Rows[0]["email"].ToString();// (datosCliente.eMail != null) ? datosCliente.eMail.ToString() : "";
                    string _fc_dcli = ""; //dt_bata.Rows[0]["dniruc"].ToString();// (datosCliente.Localidad != null) ? datosCliente.Localidad.ToString() : "";
                    dt.Rows.Add(_fc_ruc, _fc_nomb.ToUpper(), _fc_apep.ToUpper(), _fc_apem, _fc_tele, _fc_mail, _fc_dcli.ToUpper(), "");
                }

            }
            catch (Exception)
            {
                dt = null;

            }
            return dt;
        }

        public static DataTable _consultacliente(string _dniruc,ref Boolean flujo_metri,ref Boolean nuevo_bataclub,ref Boolean no_existe_cl_bata)
        {
            DataTable dt = null;
            
            try
            {
                dt = new DataTable();
                dt.TableName = "Cliente";
                dt.Columns.Add("fc_ruc", typeof(string));
                dt.Columns.Add("fc_nomb", typeof(string));
                dt.Columns.Add("fc_apep", typeof(string));
                dt.Columns.Add("fc_apem", typeof(string));
                dt.Columns.Add("fc_tele", typeof(string));
                dt.Columns.Add("fc_mail", typeof(string));
                dt.Columns.Add("fc_dcli", typeof(string));
                dt.Columns.Add("fc_cubi", typeof(string));

                #region<Modificando web service bata club bata>
                Ws_BataClub.BataEcommerceSoapClient cliente_bataclub = new Ws_BataClub.BataEcommerceSoapClient();
                Ws_BataClub.ValidateAcceso header = new Ws_BataClub.ValidateAcceso();
                header.Username = "EA646294-11F4-4836-8C6E-F5D9B5F681FC";
                header.Password = "DB959DFE-E49A-4F9B-8CD5-97364EE31FBA";

                Ws_BataClub.Cliente_Parameter_Bataclub parameter = new Ws_BataClub.Cliente_Parameter_Bataclub();
                parameter.dni = _dniruc;
                parameter.dni_barra = "";
                parameter.envia_correo = "0"/*QUE NO ENVIE CORREO*/;

                var datacliente = cliente_bataclub.ws_consultar_Cliente(header, parameter);

                if (datacliente!=null)
                {
                    if (datacliente.existe_cliente)
                    {
                        //var datosCliente = cliente_metri.ObtenerDatosCliente_DniString(_dniruc);
                        string _fc_ruc =  datacliente.dni.ToString();//  datosCliente.DNI_String.ToString();
                        string _fc_nomb = datacliente.primerNombre;//(datosCliente.Nombres != null) ? datosCliente.Nombres.ToString() : "";
                        string _fc_apep = datacliente.apellidoPater;// (datosCliente.Apellidos != null) ? datosCliente.Apellidos.ToString() : "";
                        string _fc_apem = datacliente.apellidoMater;// (datosCliente.ApellidoMaterno != null) ? datosCliente.ApellidoMaterno.ToString() : "";
                        string _fc_tele = datacliente.telefono;// (datosCliente.Celular != null) ? datosCliente.Celular : "";
                        //if (_fc_tele.Length == 0) _fc_tele = (datosCliente.Fono != null) ? datosCliente.Fono.ToString() : "";
                        string _fc_mail = datacliente.correo;// (datosCliente.eMail != null) ? datosCliente.eMail.ToString() : "";
                        string _fc_dcli ="" ;//(datosCliente.Localidad != null) ? datosCliente.Localidad.ToString() : "";
                        dt.Rows.Add(_fc_ruc, _fc_nomb.ToUpper(), _fc_apep.ToUpper(), _fc_apem, _fc_tele, _fc_mail, _fc_dcli.ToUpper(), "");
                        flujo_metri = datacliente.miembro_bataclub;// datosCliente.RegistradoEnFlujosBataClub;


                        #region<ESTA REGION ES PARA VALIDAR SI EXISTE EL CLIENTE>
                        ws_clientedniruc.Cons_ClienteSoapClient valida_cliente = new Cons_ClienteSoapClient();
                        no_existe_cl_bata = valida_cliente.ws_bc_cl_not_exists(_dniruc);
                        #endregion
                    }
                    else
                    {
                        nuevo_bataclub = true;
                    }
                }
                else
                {
                    nuevo_bataclub = true;
                }

                #endregion
                    //consultando en la ws de metricard
                //    ServiceMetricard.ServicioClienteClient cliente_metri = new ServiceMetricard.ServicioClienteClient();

                //bool existe_cliente = cliente_metri.EsCliente_DniString(_dniruc);
                //if (existe_cliente)
                //{
                //    var datosCliente = cliente_metri.ObtenerDatosCliente_DniString(_dniruc);
                //    string _fc_ruc = datosCliente.DNI_String.ToString();
                //    string _fc_nomb = (datosCliente.Nombres!=null)?datosCliente.Nombres.ToString():"";
                //    string _fc_apep = (datosCliente.Apellidos!=null)? datosCliente.Apellidos.ToString():"";
                //    string _fc_apem = (datosCliente.ApellidoMaterno != null) ? datosCliente.ApellidoMaterno.ToString() : "";
                //    string _fc_tele = (datosCliente.Celular != null)?datosCliente.Celular: "";
                //    if (_fc_tele.Length == 0) _fc_tele = (datosCliente.Fono != null) ? datosCliente.Fono.ToString() : "";
                //    string _fc_mail = (datosCliente.eMail!=null)? datosCliente.eMail.ToString():"";
                //    string _fc_dcli =(datosCliente.Localidad!=null)? datosCliente.Localidad.ToString():"";
                //    dt.Rows.Add(_fc_ruc, _fc_nomb.ToUpper(), _fc_apep.ToUpper(), _fc_apem, _fc_tele, _fc_mail, _fc_dcli.ToUpper(), "");
                //    flujo_metri = datosCliente.RegistradoEnFlujosBataClub;


                //    #region<ESTA REGION ES PARA VALIDAR SI EXISTE EL CLIENTE>
                //    ws_clientedniruc.Cons_ClienteSoapClient valida_cliente = new Cons_ClienteSoapClient();
                //    no_existe_cl_bata = valida_cliente.ws_bc_cl_not_exists(_dniruc);
                //    #endregion

                //}
                //else
                //{
                //    nuevo_bataclub = true;
                //}


                //ws_clientedniruc.Cons_ClienteSoapClient ws_cliente=new ws_clientedniruc.Cons_ClienteSoapClient();
                //dt = ws_cliente.ws_conscliente(_dniruc);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static DataSet _consulta_des_dni(string _dni,string _cod_tda,string _tip_id)
        {
            DataSet ds = null;
            try
            {
                Cons_ClienteSoapClient ws_des_dni = new Cons_ClienteSoapClient();
                ds = ws_des_dni.ws_buscar_desxdni(_dni,_cod_tda,_tip_id);
            }
            catch
            {
                ds = null;
            }
            return ds;
        }

        public static DataTable _consultaSunat(string _ruc)
        {
            DataTable dt = null;
            try
            {

                ws_clientedniruc.Cons_ClienteSoapClient ws_cliente = new ws_clientedniruc.Cons_ClienteSoapClient();
                dt = ws_cliente.ws_persona_sunat(_ruc);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static DataTable _consultaReniec(string _dni)
        {
            DataTable dt = null;
            try
            {

                ws_clientedniruc.Cons_ClienteSoapClient ws_cliente = new ws_clientedniruc.Cons_ClienteSoapClient();
                dt = ws_cliente.ws_persona_reniec(_dni);

            }
            catch(Exception exc)
            {
                dt = null;
            }
            return dt;
        }
        
        public static string _actualiza_cliente(string _ruc, string _nombres, string _apepat, string _apemat,
                                                 string _telefono, string _email, string _tda,ref string _correo_envio,ref string _telef_envia)
        {
            string _valida = "";           
            try
            {
                //ws_clientedniruc.Cons_ClienteSoapClient ws_cliente = new ws_clientedniruc.Cons_ClienteSoapClient();
                //_valida = ws_cliente.ws_update_cliente(_ruc, _nombres, _apepat, _apemat, _telefono, _email, _tda);
                //return "";
                //consultando en la ws de metricard

                #region<REGION BATACLUB BATA>
                Ws_BataClub.BataEcommerceSoapClient cliente_bataclub = new Ws_BataClub.BataEcommerceSoapClient();
                Ws_BataClub.ValidateAcceso header = new Ws_BataClub.ValidateAcceso();
                header.Username = "EA646294-11F4-4836-8C6E-F5D9B5F681FC";
                header.Password = "DB959DFE-E49A-4F9B-8CD5-97364EE31FBA";

                Ws_BataClub.Ent_Cliente_BataClub cliente = new Ws_BataClub.Ent_Cliente_BataClub();
                cliente.canal = "03";
                cliente.dni = _ruc;
                cliente.primerNombre = _nombres;
                cliente.apellidoPater = _apepat;
                cliente.apellidoMater = _apemat;
                cliente.correo = _email;
                cliente.telefono = _telefono;
                cliente.tienda = _tda;

                Ws_BataClub.Cliente_Parameter_Bataclub parameter = new Ws_BataClub.Cliente_Parameter_Bataclub();
                parameter.dni = _ruc;
                parameter.dni_barra = "";
                parameter.correo_update = _email;

                var existe_cl = cliente_bataclub.ws_consultar_Cliente(header, parameter);

                var registra_cl = cliente_bataclub.ws_registrar_Cliente(header, cliente);


                //if (!existe_cl.existe_cliente)
                //{
                //    if (_email.Length != 0)
                //    {
                //        var respuesta3 = cliente_metri.EnviarCorreoBienvenidaCliente_DniString(_ruc);
                //        _correo_envio = "1";
                //    }
                //    else
                //    {
                //        _telef_envia = "1";
                //    }
                //}



                if (registra_cl!=null)
                {
                    /*se inserto correctamente*/
                    if (registra_cl.codigo=="0")
                    {
                        if (!existe_cl.existe_cliente)
                        {
                            if (_email.Length != 0)
                            {                             
                                _correo_envio = "1";
                            }
                            else
                            {
                                _telef_envia = "1";
                            }
                        }
                        else
                        {
                            if (_email.Length != 0)
                            {                                
                                _correo_envio = "0";
                            }
                            else
                            {
                                _telef_envia = "0";
                            }
                        }
                    }
                    else
                    {
                        _valida = registra_cl.descripcion;
                    }                    

                }
                else
                {
                    _valida = "error de conexion de web service bata";
                }
                #endregion

                //ServiceMetricard.ServicioClienteClient cliente_metri = new ServiceMetricard.ServicioClienteClient();
                
                //bool existe_cliente = cliente_metri.EsCliente_DniString(_ruc);
                //insertando en la ws de metricard
                //ServiceMetricard.Cliente update_cliente_metri = new ServiceMetricard.Cliente { DNI_String = _ruc, Nombres = _nombres, Apellidos = _apepat,ApellidoMaterno=_apemat, eMail = _email, Celular = _telefono,CodigoTienda= _tda };
                //si no existe entonces insertamos
                
                //if (!existe_cliente)
                //{
                //    var respuesta1 = cliente_metri.IngresarDatosNuevoCliente(update_cliente_metri);
                //    if (!respuesta1.OperacionExitosa) _valida = respuesta1.Mensaje;//"Error de MetriCard";
                //    if (respuesta1.OperacionExitosa)
                //    {
                //        if (_email.Length!=0)
                //        { 
                //           var respuesta3 = cliente_metri.EnviarCorreoBienvenidaCliente_DniString(_ruc);
                //            _correo_envio = "1";
                //        }
                //        else
                //        {
                //            _telef_envia = "1";
                //        }

                //    }
                //}
                //else
                //{
                //    var respuesta2 = cliente_metri.ActualizarDatosCliente(update_cliente_metri);
                //    if (!respuesta2.OperacionExitosa) _valida = "Error de MetriCard";

                //    if (respuesta2.OperacionExitosa)
                //    {
                //        if (_email.Length != 0)
                //        {
                //            var respuesta3 = cliente_metri.EnviarCorreoBienvenidaCliente_DniString(_ruc);
                //            _correo_envio = "0";
                //        }
                //        else
                //        {
                //            _telef_envia = "0";
                //        }
                //    }

                //}


                //ServiceMetricard.ServicioClienteClient 


                //insertando en la ws de metricard
                //ServiceMetricard.Cliente update_cliente_metri = new ServiceMetricard.Cliente { DNI_String = _ruc, Nombres = _nombres, Apellidos = _apepat + " " + _apemat, eMail = _email, Celular = _telefono };

                



            }
            catch(Exception exc)
            {
                _valida = exc.Message;
            }
            return _valida;
        }
        public static bool ComprobarFormatoEmail(string seMailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(seMailAComprobar, sFormato))
            {
                if (Regex.Replace(seMailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        #region<METODOS CONEXION DE BASE PRUEBA>

        public static Boolean update_cliente(string _dni,string _ape_nom)
        {
            Boolean _valor = true;
            try
            {
                using (System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection("Server=10.10.10.208;Database=BdTienda;User ID=sa;Password=Bata2013;Trusted_Connection=False;"))
                {
                    if (cn.State == 0) cn.Open();
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("UPDATE tmpvales SET NOMBRES_VENTA='" + _ape_nom  +"' WHERE Est_Id='CO' AND DNI_VENTA='" + _dni + "'", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch
            {
                _valor = false;
            }
            return _valor;
        }

        public static DataTable dtclienteb()
        {
            DataTable dt = null;            
            try
            {
                using (System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection("Server=10.10.10.208;Database=BdTienda;User ID=sa;Password=Bata2013;Trusted_Connection=False;"))
                {
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("SELECT distinct DNI_Venta FROM tmpvales WHERE Est_Id='CO' AND Nombres_Venta NOT LIKE  '%,%'", cn))
                    {
                        cmd.CommandTimeout = 0;
                        //cmd.CommandText =
                        using (System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd))
                        {
                            dt = new DataTable();
                            da.Fill(dt);
                        }
                    }
                }

            }
           catch
            {
                dt = null;
            }
            return dt;
        }
        #endregion

    }
}
