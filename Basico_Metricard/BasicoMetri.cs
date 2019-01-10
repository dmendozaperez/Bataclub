using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using Basico_Metricard.ServicioConversion;

namespace Basico_Metricard
{
    
    public class BasicoMetri
    {
        private static string conexion= "Server=POSPERUBD.BGR.PE;Database=BDPOS;User ID=pos_oracle;Password=Bata2018**;Trusted_Connection=False;";


        private static Boolean _update_cupon_metricard(string _barra,ref string _error)
        {
            string sqlquery = "USP_UpdateCupon_Metricard";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            Boolean _valida = false;
            try
            {
                cn = new SqlConnection(conexion);
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BARRA", _barra);
                cmd.ExecuteNonQuery();
                _valida = true;
            }
            catch
            {
                if (cn != null)
                    if (cn.State == ConnectionState.Open) cn.Close();
                _valida = false;
            }
            if (cn != null)
                if (cn.State == ConnectionState.Open) cn.Close();
            return _valida;
        }

        private static Boolean _update_venta_metricard(string _serie, string _numeroDoc, ref string _error)
        {
            string sqlquery = "USP_UpdateVenta_Metricard";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            Boolean _valida = false;
            try
            {
                cn = new SqlConnection(conexion);
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SERIE", _serie);
                cmd.Parameters.AddWithValue("@NROdOC", _numeroDoc);
                cmd.ExecuteNonQuery();
                _valida = true;
            }
            catch
            {
                if (cn != null)
                    if (cn.State == ConnectionState.Open) cn.Close();
                _valida = false;
            }
            if (cn != null)
                if (cn.State == ConnectionState.Open) cn.Close();
            return _valida;
        }
        private static DataTable dt_tienda()
        {
            DataTable dt = null;
            string sqlquery = "USP_ListaTdaMetriN";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlquery, cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            dt = new DataTable();
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception)
            {

                dt = null;
            }
            return dt;
        }
        private static DataTable dt_cupones_convert(ref string _error)
        {
            string sqlquery = "USP_EnviaCupon_MetriCard";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataTable dt=null;
            try
            {
                cn = new SqlConnection(conexion);
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch(Exception e)
            {
                _error = e.Message;
                dt = null;
            }
            return dt;
        }

        private static DataTable dt_ventas_convert(ref string _error)
        {
            string sqlquery = "USP_EnviaVenta_MetriCard";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataTable dt = null;
            try
            {
                cn = new SqlConnection(conexion);
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception e)
            {
                _error = e.Message;
                dt = null;
            }
            return dt;
        }

        private static IEnumerable _grupo_doc_array(DataTable dtcupon)
        {
            IEnumerable _array = null;
            try
            {

            }
            catch
            {
                _array = null;
            }
            return _array;
        }
        public static string Right(string param, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            string result = param.Substring(param.Length - length, length);
            //return the result of the operation
            return result;
        }
        public static string Left(string param, int length)
        {
            //we start at 0 since we want to get the characters starting from the
            //left and with the specified lenght and assign it to a variable
            string result = param.Substring(0, length);
            //return the result of the operation
            return result;
        }

        public static void insertar_error_service_metricard(string _error)
        {
            string sqlquery = "[USP_Insertar_Errores_Service_Metricard]";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(conexion);
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@error", _error);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                if (cn != null)
                    if (cn.State == ConnectionState.Open) cn.Close();
            }
            if (cn != null)
                if (cn.State == ConnectionState.Open) cn.Close();
        }
        public static void _ejecuta_proceso_envia_metricard(ref String _error)
        {
            DataTable dtcupones = null;
            DataTable dttienda = null;
            //string _error = "";
            ServicioConversionClient cliente = null;
            try
            {


                #region<ACTUALIZAR TIENDAS>
                dttienda = dt_tienda();

                if (dttienda!=null)
                {
                    if (dttienda.Rows.Count>0)
                    {
                        cliente = new ServicioConversionClient();
                        for (Int32 i=0;i<dttienda.Rows.Count;++i)
                        {
                                string codtda = dttienda.Rows[i]["cod_entid"].ToString();
                                string destda = dttienda.Rows[i]["des_entid"].ToString();

                                Tienda tienda = cliente.ConsultarTiendaPorCodigo(codtda);

                                if (tienda == null)
                                {
                                    tienda = new ServicioConversion.Tienda();
                                    tienda.Nombre = destda;
                                    tienda.Codigo = codtda;
                                    RespuestaServicio respuesta_tda = cliente.AgregarTienda(tienda);

                                }
                           
                        }
                    }
                }
                #endregion

                dtcupones = dt_cupones_convert(ref _error);
                if (dtcupones != null)
                {
                    if (dtcupones.Rows.Count > 0)
                    {
                        /*VAMOS ACUTALIZAR LAS CAMPAÑAS*/
                        var grupo_promocion = from item in dtcupones.AsEnumerable()
                                          group item by
                                          new
                                          {
                                              PROMOCION = item["promocion"].ToString()
                                          }
                                        into G
                                          select new
                                          {
                                              PROMOCION = G.Key.PROMOCION
                                          };

                        /*******************************/
                        /*VAMOS ACTUALIZAR agrupar tienda*/
                        var grupo_tda = from item in dtcupones.AsEnumerable()
                                        group item by
                                        new
                                        {
                                            COD_ENTID = item["cod_entid"].ToString(),
                                            DES_ENTID = item["des_entid"].ToString()
                                        }
                        into G
                                        select new
                                        {
                                            COD_ENTID = G.Key.COD_ENTID,
                                            DES_ENTID = G.Key.DES_ENTID
                                        };
                        /*********************************************/
                        /*agrupar linea*/
                        var grupo_linea = from item in dtcupones.AsEnumerable()
                                          group item by
                                          new
                                          {
                                              COD_LINEA = item["cod_linea"].ToString(),
                                              DES_LINEA = item["des_linea"].ToString()
                                          }
                        into G
                                          select new
                                          {
                                              COD_LINEA = G.Key.COD_LINEA,
                                              DES_LINEA = G.Key.DES_LINEA
                                          };

                        /********************************/
                        /*agrupar articulo*/
                        var grupo_articulo = from item in dtcupones.AsEnumerable()
                                             group item by
                                             new
                                             {
                                                 COD_ARTIC = item["cod_artic"].ToString(),
                                                 DES_ARTIC = item["des_artic"].ToString(),
                                                 DES_MARCA = item["des_marca"].ToString(),
                                                 PRE_ARTIC = Convert.ToDecimal(item["precio"])
                                             }
                        into G
                                             select new
                                             {
                                                 COD_ARTIC = G.Key.COD_ARTIC,
                                                 DES_ARTIC = G.Key.DES_ARTIC,
                                                 DES_MARCA = G.Key.DES_MARCA,
                                                 PRE_ARTIC = G.Key.PRE_ARTIC
                                             };
                        /*******************************/

                        /*agrupar documento cabezera de documento*/
                        var grupo_doc = from item in dtcupones.AsEnumerable()
                                        group item by
                                        new
                                        {
                                            COD_ENTID = item["cod_entid"].ToString(),
                                            DES_ENTID = item["des_entid"].ToString(),
                                            NOMBRE_CLIENTE = item["nombre_cliente"].ToString(),
                                            BARRA = item["barra"].ToString(),
                                            EMAIL_CLIENTE = item["email_cliente"].ToString(),
                                            DNI_CLIENTE = item["dni_cliente"].ToString(),
                                            FECHA_DOC = Convert.ToDateTime(item["fecha_doc"]),
                                            SERIE_DOC = item["serie_doc"].ToString(),
                                            NUMERO_DOC = item["numero_doc"].ToString(),
                                            TOTAL_INC_IGV = Convert.ToDecimal(item["total_inc_igv"]),
                                            TOTAL_SIN_IGV = Convert.ToDecimal(item["total_sin_igv"]),
                                            DESCUENTO_MONTO = Convert.ToDecimal(item["descuento_monto"]),
                                            PORC_DESC = Convert.ToDecimal(item["porc_desc"]),
                                            TELEFONO_CLIENTE = item["telefono_cliente"].ToString(),
                                            IMPUESTO = Convert.ToDecimal(item["impuesto"]),
                                            PROMOCION = item["promocion"].ToString(),
                                            APE_CLIENTE = item["apellido_cliente"].ToString(),
                                            NOM_CLIENTE = item["nombres_cliente"].ToString(),
                                            EST_BARRA=item["estado_barra"].ToString()
                                        }
                        into G
                                        select new
                                        {
                                            COD_ENTID = G.Key.COD_ENTID,
                                            DES_ENTID = G.Key.DES_ENTID,
                                            NOMBRE_CLIENTE = G.Key.NOMBRE_CLIENTE,
                                            BARRA = G.Key.BARRA,
                                            EMAIL_CLIENTE = G.Key.EMAIL_CLIENTE,
                                            DNI_CLIENTE = G.Key.DNI_CLIENTE,
                                            FECHA_DOC = G.Key.FECHA_DOC,
                                            SERIE_DOC = G.Key.SERIE_DOC,
                                            NUMERO_DOC = G.Key.NUMERO_DOC,
                                            TOTAL_INC_IGV = G.Key.TOTAL_INC_IGV,
                                            TOTAL_SIN_IGV = G.Key.TOTAL_SIN_IGV,
                                            DESCUENTO_MONTO = G.Key.DESCUENTO_MONTO,
                                            PORC_DESC = G.Key.PORC_DESC,
                                            TELEFONO_CLIENTE = G.Key.TELEFONO_CLIENTE,
                                            IMPUESTO = G.Key.IMPUESTO,
                                            PROMOCION = G.Key.PROMOCION,
                                            APE_CLIENTE = G.Key.APE_CLIENTE,
                                            NOM_CLIENTE = G.Key.NOM_CLIENTE,
                                            EST_BARRA=G.Key.EST_BARRA
                                        };

                        if (grupo_doc != null)
                        {
                            if (grupo_doc.Count() > 0)
                            {
                                /*LLAMAR INSTANCIA DE LA WS DE METRI*/
                                cliente = new ServicioConversionClient();

                                /*CREACION DE PROMOCION*/
                                #region<CREACION DE PROMOCION>
                                if (grupo_promocion!=null)
                                {
                                    foreach(var key in grupo_promocion)
                                    {
                                        Campana campana = cliente.ConsultarCampanaPorCodigo(key.PROMOCION.ToString());

                                        if (campana==null)
                                        {
                                            campana = new Campana();
                                            campana.Codigo = key.PROMOCION.ToString();
                                            campana.Nombre = key.PROMOCION.ToString();

                                            RespuestaServicio respuesta_cam = cliente.CrearCampana(campana);

                                        }
                                    }
                                }

                                #endregion
                                /**********************************/

                                /*CREACION DE TIENDAS QUE NO FIGUREN EN METRICARD*/
                                #region<CREACION DE TIENDAS>
                                if (grupo_tda != null)
                                {
                                    foreach (var key in grupo_tda)
                                    {
                                        Tienda tienda = cliente.ConsultarTiendaPorCodigo(key.COD_ENTID);

                                        if (tienda == null)
                                        {
                                            tienda = new ServicioConversion.Tienda();
                                            tienda.Nombre = key.DES_ENTID;
                                            tienda.Codigo = key.COD_ENTID;
                                            RespuestaServicio respuesta_tda = cliente.AgregarTienda(tienda);

                                        }
                                    }
                                }
                                #endregion
                                #region<CREACION DE LINEA>
                                if (grupo_linea != null)
                                {
                                    foreach (var key in grupo_linea)
                                    {
                                        TipoProducto linea = cliente.ConsultarTipoProducto(key.COD_LINEA);

                                        if (linea == null)
                                        {
                                            linea = new TipoProducto { Codigo = key.COD_LINEA, Nombre = key.DES_LINEA };

                                            RespuestaServicio respuesta_linea = cliente.AgregarTipoProducto(linea);
                                        }
                                    }
                                }
                                #endregion
                                #region<CREACION DE ARTICULOS>
                                if (grupo_articulo != null)
                                {
                                    decimal _contar = grupo_articulo.Count();
                                    foreach (var key in grupo_articulo)
                                    {
                                        Producto articulo = cliente.ConsultarProducto(key.COD_ARTIC);



                                        if (articulo == null)
                                        {
                                            articulo = new Producto();
                                            articulo.Activo = true;
                                            articulo.Codigo = key.COD_ARTIC;
                                            articulo.Descripcion = key.DES_ARTIC;
                                            articulo.Empresa = key.DES_MARCA;
                                            articulo.Nombre = key.DES_ARTIC;
                                            articulo.Precio = key.PRE_ARTIC;

                                            RespuestaServicio respuesta_articulo = cliente.AgregarProducto(articulo);
                                        }
                                    }
                                }
                                #endregion                                
                            }
                            #region<ENVIO DE DOCUMENTOS CABECERA Y DETALLE>
                            foreach (var key in grupo_doc)
                            {
                                String _est_barra = key.EST_BARRA.ToString();
                                bool _existe_cupon = cliente.ExisteConversionPorCupon(key.BARRA);
                              
                                if (_existe_cupon)
                                {
                                    Boolean _anular_cupon = cliente.AnularConversionPorCupon(key.BARRA);
                                }
                                if (_est_barra!="A")
                                {
                                    Documento documento = new Documento();
                                    documento.ApellidosCliente = key.APE_CLIENTE;
                                    documento.CodigoDescuentoUtilizado = key.BARRA;
                                    documento.CorreoCliente = key.EMAIL_CLIENTE;
                                    documento.DNICliente = key.DNI_CLIENTE;
                                    documento.FechaDocumento = key.FECHA_DOC;
                                    documento.TipoDocumento = (Left(key.SERIE_DOC, 1) == "B") ? TipoDocumento.BOLETA : TipoDocumento.FACTURA;
                                    documento.TipoPago = "Efectivo";
                                    documento.Total = key.TOTAL_INC_IGV;
                                    documento.TotalSinImpuesto = key.TOTAL_SIN_IGV;
                                    documento.ValorDescuento = key.DESCUENTO_MONTO;
                                    documento.PorcentajeDescuento = Convert.ToDouble(key.PORC_DESC);
                                    documento.TelefonoCliente = key.TELEFONO_CLIENTE;
                                    documento.NumeroDocumento = key.SERIE_DOC + key.NUMERO_DOC;
                                    documento.Notas = "";
                                    documento.NombresCliente = key.NOM_CLIENTE;
                                    documento.Impuesto = key.IMPUESTO;
                                    documento.CodigoCampana = key.PROMOCION;

                                    Tienda tda_doc;// = cliente.ConsultarTiendaPorCodigo(key.COD_ENTID);
                                    tda_doc = cliente.ConsultarTiendaPorCodigo(key.COD_ENTID);

                                    if (tda_doc != null)
                                    {
                                        documento.IdTienda = tda_doc.IdTienda;
                                    }

                                    /*AHORA VEMOS DETALLE*/
                                    var DOC_DET = from item in dtcupones.AsEnumerable()
                                                  where item.Field<String>("barra") == key.BARRA.ToString()
                                                  select new
                                                  {
                                                      CANTIDAD = Convert.ToInt32(item["cantidad"]),
                                                      COD_ART = item["cod_artic"].ToString(),
                                                      NOM_ART = item["des_artic"].ToString(),
                                                      PRECIO = Convert.ToDecimal(item["precio"])
                                                  };
                                    if (DOC_DET != null)
                                    {
                                        int nrodetalle = DOC_DET.Count();

                                        ProductoDocumento[] list = new ProductoDocumento[nrodetalle];
                                        var ele = 0;
                                        foreach (var key_det in DOC_DET)
                                        {
                                            ProductoDocumento artidulo_doc = new ProductoDocumento();
                                            artidulo_doc.Cantidad = key_det.CANTIDAD;
                                            artidulo_doc.CodigoProducto = key_det.COD_ART;
                                            artidulo_doc.NombreProducto = key_det.NOM_ART;
                                            artidulo_doc.PrecioUnitario = key_det.PRECIO;
                                            list[ele] = artidulo_doc;
                                            ele++;
                                        }

                                        documento.Productos = list;
                                        
                                       RespuestaServicio respuesta_documento = cliente.RegistrarDocumento(documento);

                                        /*EN ESTE PASO VAMOS HACER UN UPDATE LA TABLA SQL*/
                                        if (respuesta_documento.OperacionExitosa)
                                        {
                                            Boolean _valida = _update_cupon_metricard(key.BARRA, ref _error);
                                        }


                                    }

                                }
                                else
                                {
                                    Boolean _valida = _update_cupon_metricard(key.BARRA, ref _error);
                                }
                                #endregion
                            }

                        }
                    }
                }
            }
            catch (Exception exc)
            {
                _error = exc.Message;
            }
            
        }


        public static void _ejecuta_proceso_enviaVenta_metricard(ref String _error)
        {
            DataTable dtVentas = null;
            DataTable dttienda = null;
            //string _error = "";
            ServicioConversionClient cliente = null;
            string paso = "";
            try
            {

                string _hora_ejecucion = hora_venta_ejecucion("01");

                DateTime myDt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

                string _hora_actual = myDt.ToString("HH:mm");

                if (_hora_actual != _hora_ejecucion) return;

                #region<ACTUALIZAR TIENDAS>
                dttienda = dt_tienda();

                if (dttienda != null)
                {
                    if (dttienda.Rows.Count > 0)
                    {
                        cliente = new ServicioConversionClient();
                        for (Int32 i = 0; i < dttienda.Rows.Count; ++i)
                        {
                            string codtda = dttienda.Rows[i]["cod_entid"].ToString();
                            string destda = dttienda.Rows[i]["des_entid"].ToString();

                            Tienda tienda = cliente.ConsultarTiendaPorCodigo(codtda);

                            if (tienda == null)
                            {
                                tienda = new ServicioConversion.Tienda();
                                tienda.Nombre = destda;
                                tienda.Codigo = codtda;
                                RespuestaServicio respuesta_tda = cliente.AgregarTienda(tienda);

                            }

                        }
                    }
                }
                #endregion

                dtVentas = dt_ventas_convert(ref _error);
                if (dtVentas != null)
                {
                    if (dtVentas.Rows.Count > 0)
                    {
                      
                        /*VAMOS ACTUALIZAR agrupar tienda*/
                        var grupo_tda = from item in dtVentas.AsEnumerable()
                                        group item by
                                        new
                                        {
                                            COD_ENTID = item["cod_entid"].ToString(),
                                            DES_ENTID = item["des_entid"].ToString()
                                        }
                        into G
                                        select new
                                        {
                                            COD_ENTID = G.Key.COD_ENTID,
                                            DES_ENTID = G.Key.DES_ENTID
                                        };
                        /*********************************************/
                        /*agrupar linea*/
                        var grupo_linea = from item in dtVentas.AsEnumerable()
                                          group item by
                                          new
                                          {
                                              COD_LINEA = item["cod_linea"].ToString(),
                                              DES_LINEA = item["des_linea"].ToString()
                                          }
                        into G
                                          select new
                                          {
                                              COD_LINEA = G.Key.COD_LINEA,
                                              DES_LINEA = G.Key.DES_LINEA
                                          };

                        /********************************/
                        /*agrupar articulo*/
                        var grupo_articulo = from item in dtVentas.AsEnumerable()
                                             group item by
                                             new
                                             {
                                                 COD_ARTIC = item["cod_artic"].ToString(),
                                                 DES_ARTIC = item["des_artic"].ToString(),
                                                 DES_MARCA = item["des_marca"].ToString(),
                                                 PRE_ARTIC = Convert.ToDecimal(item["precio"])
                                             }
                        into G
                                             select new
                                             {
                                                 COD_ARTIC = G.Key.COD_ARTIC,
                                                 DES_ARTIC = G.Key.DES_ARTIC,
                                                 DES_MARCA = G.Key.DES_MARCA,
                                                 PRE_ARTIC = G.Key.PRE_ARTIC
                                             };
                        /*******************************/
                        paso = "paso 1";
                        /*agrupar documento cabezera de documento*/
                        var grupo_doc = from item in dtVentas.AsEnumerable()
                                        group item by
                                        new
                                        {
                                            COD_ENTID = item["cod_entid"].ToString(),
                                            DES_ENTID = item["des_entid"].ToString(),
                                            NOMBRE_CLIENTE = item["nombre_cliente"].ToString(),
                                            BARRA = item["barra"].ToString(),
                                            EMAIL_CLIENTE = item["email_cliente"].ToString(),
                                            DNI_CLIENTE = item["dni_cliente"].ToString(),
                                            FECHA_DOC = Convert.ToDateTime(item["fecha_doc"]),
                                            SERIE_DOC = item["serie_doc"].ToString(),
                                            NUMERO_DOC = item["numero_doc"].ToString(),
                                            TOTAL_INC_IGV = Convert.ToDecimal(item["total_inc_igv"]),
                                            TOTAL_SIN_IGV = Convert.ToDecimal(item["total_sin_igv"]),
                                            DESCUENTO_MONTO = Convert.ToDecimal(item["descuento_monto"]),
                                            PORC_DESC = Convert.ToDecimal(item["porc_desc"]),
                                            TELEFONO_CLIENTE = item["telefono_cliente"].ToString(),
                                            IMPUESTO = Convert.ToDecimal(item["impuesto"]),
                                            PROMOCION = item["promocion"].ToString(),
                                            APE_CLIENTE = item["apellido_cliente"].ToString(),
                                            NOM_CLIENTE = item["nombres_cliente"].ToString(),
                                            EST_BARRA = item["estado_barra"].ToString()
                                        }
                        into G
                                        select new
                                        {
                                            COD_ENTID = G.Key.COD_ENTID,
                                            DES_ENTID = G.Key.DES_ENTID,
                                            NOMBRE_CLIENTE = G.Key.NOMBRE_CLIENTE,
                                            BARRA = G.Key.BARRA,
                                            EMAIL_CLIENTE = G.Key.EMAIL_CLIENTE,
                                            DNI_CLIENTE = G.Key.DNI_CLIENTE,
                                            FECHA_DOC = G.Key.FECHA_DOC,
                                            SERIE_DOC = G.Key.SERIE_DOC,
                                            NUMERO_DOC = G.Key.NUMERO_DOC,
                                            TOTAL_INC_IGV = G.Key.TOTAL_INC_IGV,
                                            TOTAL_SIN_IGV = G.Key.TOTAL_SIN_IGV,
                                            DESCUENTO_MONTO = G.Key.DESCUENTO_MONTO,
                                            PORC_DESC = G.Key.PORC_DESC,
                                            TELEFONO_CLIENTE = G.Key.TELEFONO_CLIENTE,
                                            IMPUESTO = G.Key.IMPUESTO,
                                            PROMOCION = G.Key.PROMOCION,
                                            APE_CLIENTE = G.Key.APE_CLIENTE,
                                            NOM_CLIENTE = G.Key.NOM_CLIENTE,
                                            EST_BARRA = G.Key.EST_BARRA
                                        };

                        paso = "paso 2";

                        if (grupo_doc != null)
                        {
                            paso = "paso null";
                            if (grupo_doc.Count() > 0)
                            {
                                paso = "paso count";
                                /*LLAMAR INSTANCIA DE LA WS DE METRI*/
                                cliente = new ServicioConversionClient();
                                paso = "paso instancia";
                                /*CREACION DE TIENDAS QUE NO FIGUREN EN METRICARD*/
                                #region<CREACION DE TIENDAS>
                                if (grupo_tda != null)
                                {
                                    paso = "paso tda ini";
                                    foreach (var key in grupo_tda)
                                    {
                                        Tienda tienda = cliente.ConsultarTiendaPorCodigo(key.COD_ENTID);

                                        if (tienda == null)
                                        {
                                            tienda = new ServicioConversion.Tienda();
                                            tienda.Nombre = key.DES_ENTID;
                                            tienda.Codigo = key.COD_ENTID;
                                            RespuestaServicio respuesta_tda = cliente.AgregarTienda(tienda);

                                        }
                                    }
                                    paso = "paso tda fin";
                                }
                                #endregion
                                #region<CREACION DE LINEA>
                                if (grupo_linea != null)
                                {
                                    paso = "paso linea ini";
                                    foreach (var key in grupo_linea)
                                    {
                                        TipoProducto linea = cliente.ConsultarTipoProducto(key.COD_LINEA);

                                        if (linea == null)
                                        {
                                            linea = new TipoProducto { Codigo = key.COD_LINEA, Nombre = key.DES_LINEA };

                                            RespuestaServicio respuesta_linea = cliente.AgregarTipoProducto(linea);
                                        }
                                    }
                                    paso = "paso linea fin";
                                }
                                #endregion
                                #region<CREACION DE ARTICULOS>
                                if (grupo_articulo != null)
                                {
                                    decimal _contar = grupo_articulo.Count();
                                    paso = "paso articulo ini";
                                    foreach (var key in grupo_articulo)
                                    {
                                        Producto articulo = cliente.ConsultarProducto(key.COD_ARTIC);



                                        if (articulo == null)
                                        {
                                            articulo = new Producto();
                                            articulo.Activo = true;
                                            articulo.Codigo = key.COD_ARTIC;
                                            articulo.Descripcion = key.DES_ARTIC;
                                            articulo.Empresa = key.DES_MARCA;
                                            articulo.Nombre = key.DES_ARTIC;
                                            articulo.Precio = key.PRE_ARTIC;

                                            RespuestaServicio respuesta_articulo = cliente.AgregarProducto(articulo);
                                        }
                                    }
                                    paso = "paso articulo fin";
                                }
                                #endregion                                
                            }
                            #region<ENVIO DE DOCUMENTOS CABECERA Y DETALLE>
                            foreach (var key in grupo_doc)
                            {
                                paso = "paso 3.1";
                                bool _existe_doc = cliente.ExisteConversion(key.SERIE_DOC + key.NUMERO_DOC);

                                if (_existe_doc)
                                {
                                    Boolean _anular_doc = cliente.AnularConversion(key.SERIE_DOC + key.NUMERO_DOC);
                                }

                                paso = "paso 3";

                                Documento documento = new Documento();
                                documento.ApellidosCliente = key.APE_CLIENTE;
                                documento.CodigoDescuentoUtilizado = key.BARRA;
                                documento.CorreoCliente = key.EMAIL_CLIENTE;
                                documento.DNICliente = key.DNI_CLIENTE;
                                documento.FechaDocumento = key.FECHA_DOC;
                                documento.TipoDocumento = (Left(key.SERIE_DOC, 1) == "B") ? TipoDocumento.BOLETA : TipoDocumento.FACTURA;
                                documento.TipoPago = "Efectivo";
                                documento.Total = key.TOTAL_INC_IGV;
                                documento.TotalSinImpuesto = key.TOTAL_SIN_IGV;
                                documento.ValorDescuento = key.DESCUENTO_MONTO;
                                documento.PorcentajeDescuento = Convert.ToDouble(key.PORC_DESC);
                                documento.TelefonoCliente = key.TELEFONO_CLIENTE;
                                documento.NumeroDocumento = key.SERIE_DOC + key.NUMERO_DOC;
                                documento.Notas = "";
                                documento.NombresCliente = key.NOM_CLIENTE;
                                documento.Impuesto = key.IMPUESTO;
                                documento.CodigoCampana = key.PROMOCION;


                                paso = "paso 4";

                                Tienda tda_doc;// = cliente.ConsultarTiendaPorCodigo(key.COD_ENTID);
                                tda_doc = cliente.ConsultarTiendaPorCodigo(key.COD_ENTID);

                                if (tda_doc != null)
                                {
                                    documento.IdTienda = tda_doc.IdTienda;
                                }

                                /*AHORA VEMOS DETALLE*/
                                var DOC_DET = from item in dtVentas.AsEnumerable()
                                              where item.Field<String>("serie_doc") == key.SERIE_DOC.ToString() && item.Field<String>("numero_doc") == key.NUMERO_DOC.ToString()
                                              select new
                                              {
                                                  CANTIDAD = Convert.ToInt32(item["cantidad"]),
                                                  COD_ART = item["cod_artic"].ToString(),
                                                  NOM_ART = item["des_artic"].ToString(),
                                                  PRECIO = Convert.ToDecimal(item["precio"])
                                              };
                                if (DOC_DET != null)
                                {
                                    int nrodetalle = DOC_DET.Count();

                                    ProductoDocumento[] list = new ProductoDocumento[nrodetalle];
                                    var ele = 0;
                                    foreach (var key_det in DOC_DET)
                                    {
                                        ProductoDocumento artidulo_doc = new ProductoDocumento();
                                        artidulo_doc.Cantidad = key_det.CANTIDAD;
                                        artidulo_doc.CodigoProducto = key_det.COD_ART;
                                        artidulo_doc.NombreProducto = key_det.NOM_ART;
                                        artidulo_doc.PrecioUnitario = key_det.PRECIO;
                                        list[ele] = artidulo_doc;                                     
                                        ele++;
                                    }

                                    documento.Productos = list;
                                  RespuestaServicio respuesta_documento = cliente.RegistrarDocumento(documento);

                                    /*EN ESTE PASO VAMOS HACER UN UPDATE LA TABLA SQL*/
                                    if (respuesta_documento.OperacionExitosa)
                                    {
                                        Boolean _valida = _update_venta_metricard(key.SERIE_DOC, key.NUMERO_DOC, ref _error);
                                    }


                                }

                               
                            #endregion
                            }

                        }
                    }
                }
            }
            catch (Exception exc)
            {
                _error = exc.Message + "==>" + paso  ;
            }

        }

        /*CAPTURAR HORA DEL SERVICIO PARA LA VENTA A EJECUTARSE*/
        private static string hora_venta_ejecucion(string _cod_servicio)
        {
            string hora_sql = "";
            string sqlquery = "USP_MetricardServicioConfig";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    if (cn.State == 0) cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlquery, cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cod_servicio", _cod_servicio);
                        cmd.Parameters.Add("@out_time", SqlDbType.VarChar, 15);
                        cmd.Parameters["@out_time"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        hora_sql =(string)cmd.Parameters["@out_time"].Value;
                    }
                }
            }
            catch (Exception)
            {

                hora_sql = "";
            }
            return hora_sql;

        }
        /******************************************/
    }

}
