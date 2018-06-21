using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WS_ConsCliente.Clases;

namespace WS_ConsCliente
{
    public class Basico
    {

        #region<METODO PARA ACTUALIZAR DECUENTO DE EMPLEADOS>

        public static Boolean _valida_tda_bg(string _tda)
        {
            Boolean _valida = false;
            string sqlquery = "USP_Valida_BGWB";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(ConexionData.conexion);
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_tda", _tda);
                cmd.Parameters.Add("@valida", SqlDbType.Bit);
                cmd.Parameters["@valida"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                _valida = Convert.ToBoolean(cmd.Parameters["@valida"].Value);
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

        public static string update_venta_empleado(string _Tip_Id_Ven,string _Nro_Dni_Ven,string _Cod_Tda_Ven,
	                                               string _Nro_Doc_Ven,string _Tip_Doc_Ven,string _Ser_Doc_Ven,
	                                               string _Num_Doc_Ven,string _Fec_Doc_Ven,string _Est_Doc_Ven,
	                                               string _Fc_Nin_Ven )
        {
            string _error = "";
            string sqlquery = "USP_Update_venta_empleado";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(ConexionData.conexion);
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tip_Id_Ven", _Tip_Id_Ven);
                cmd.Parameters.AddWithValue("@Nro_Dni_Ven", _Nro_Dni_Ven);
                cmd.Parameters.AddWithValue("@Cod_Tda_Ven", _Cod_Tda_Ven);
                cmd.Parameters.AddWithValue("@Nro_Doc_Ven", _Nro_Doc_Ven);
                cmd.Parameters.AddWithValue("@Tip_Doc_Ven", _Tip_Doc_Ven);
                cmd.Parameters.AddWithValue("@Ser_Doc_Ven", _Ser_Doc_Ven);
                cmd.Parameters.AddWithValue("@Num_Doc_Ven", _Num_Doc_Ven);
                cmd.Parameters.AddWithValue("@Fec_Doc_Ven",_Fec_Doc_Ven);
                cmd.Parameters.AddWithValue("@Est_Doc_Ven", _Est_Doc_Ven);
                cmd.Parameters.AddWithValue("@Fc_Nin_Ven", _Fc_Nin_Ven);
                cmd.ExecuteNonQuery();
            }
            catch(Exception exc)
            {
                _error = exc.Message;
                if (cn != null) ;
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            if (cn != null) ;
            if (cn.State == ConnectionState.Open) cn.Close();
            return _error;
        }


        #endregion

        #region<METODO PARA VALES>
        public PromBata get_prombata(string cod,string tda,string dni)
        {
            PromBata getdata = null;
            string sqlquery = "USP_GetValidaPromBata";
            try
            {
                using (SqlConnection cn = new SqlConnection(ConexionData.conexion))
                {
                    if (cn.State == 0) cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlquery, cn))
                    {

                        getdata = new PromBata();

                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cod_prom", cod);
                        cmd.Parameters.AddWithValue("@cod_tda", tda);
                        cmd.Parameters.AddWithValue("@dni", dni);

                        cmd.Parameters.Add("@valida", SqlDbType.Bit);
                        cmd.Parameters.Add("@nom_prom", SqlDbType.VarChar,100);
                        cmd.Parameters.Add("@fecha_ini", SqlDbType.Date);
                        cmd.Parameters.Add("@fecha_fin", SqlDbType.Date);
                        cmd.Parameters.Add("@por_des", SqlDbType.Money);
                        cmd.Parameters.Add("@max_pares", SqlDbType.Decimal);

                        cmd.Parameters["@valida"].Direction = ParameterDirection.Output;
                        cmd.Parameters["@nom_prom"].Direction = ParameterDirection.Output;
                        cmd.Parameters["@fecha_ini"].Direction = ParameterDirection.Output;
                        cmd.Parameters["@fecha_fin"].Direction = ParameterDirection.Output;
                        cmd.Parameters["@por_des"].Direction = ParameterDirection.Output;
                        cmd.Parameters["@max_pares"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();
                        getdata.valida = (Boolean)cmd.Parameters["@valida"].Value;
                        getdata.nom_prom =(string)cmd.Parameters["@nom_prom"].Value;
                        getdata.fecha_ini =(DateTime) cmd.Parameters["@fecha_ini"].Value;
                        getdata.fecha_fin =(DateTime) cmd.Parameters["@fecha_fin"].Value;
                        getdata.por_des =(decimal) cmd.Parameters["@por_des"].Value;
                        getdata.max_par=(decimal) cmd.Parameters["@max_pares"].Value;
                       

                    }
                }
            }
            catch(Exception exc)
            {
                getdata = null;
            }
            return getdata;
        }


        public static string update_vales(string _serie,string _correlativo,string _cod_tda_venta,string _dni_venta,
            string _nombres_venta,string _fecha_doc,string _tipo_doc,string _serie_doc,string _numero_doc,
            string _estado_doc,string _fc_nint,string _email_venta,string _telefono_venta)
        {
            string _error = "";
            string sqlquery = "USP_UPDATE_VALES";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(ConexionData.conexion);
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@serie", _serie);
                cmd.Parameters.AddWithValue("@correlativo", _correlativo);
                cmd.Parameters.AddWithValue("@cod_tda_venta", _cod_tda_venta);                
                cmd.Parameters.AddWithValue("@dni_venta", _dni_venta);
                cmd.Parameters.AddWithValue("@nombres_venta", _nombres_venta);

                cmd.Parameters.AddWithValue("@fecha_doc", _fecha_doc);
                cmd.Parameters.AddWithValue("@tipo_doc", _tipo_doc);
                cmd.Parameters.AddWithValue("@serie_doc", _serie_doc);
                cmd.Parameters.AddWithValue("@numero_doc", _numero_doc);
                cmd.Parameters.AddWithValue("@estado_doc", _estado_doc);

                cmd.Parameters.AddWithValue("@fc_nint", _fc_nint);
                cmd.Parameters.AddWithValue("@emai_venta", _email_venta);
                cmd.Parameters.AddWithValue("@telefono_venta", _telefono_venta);

                cmd.ExecuteNonQuery();
            }
            catch(Exception exc)
            {
                _error = exc.Message;
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return _error;
        }
        public static DataSet ds_vales(string _correlativo, string _code,string _cod_tda="")
        {            
            string sqlquery = "USP_BUSCAR_VALES";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataSet ds = null;
            try
            {
                cn = new SqlConnection(ConexionData.conexion);
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correlativo", _correlativo);
                cmd.Parameters.AddWithValue("@code",_code);
                cmd.Parameters.AddWithValue("@tda", _cod_tda);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables.Count>1)
                {
                    ds.Tables[0].TableName = "Validacion";
                    ds.Tables[1].TableName = "Datos";
                }
                else
                {
                    ds.Tables[0].TableName = "Validacion";
                }
            }
            catch
            {
                ds = null;
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return ds;
        }

        public static DataSet ds_desdni(string _dni,string _cod_tda,string _tip_des)
        {
            string sqlquery = "USP_LeerDesEmp";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataSet ds = null;
            try
            {
                cn = new SqlConnection(ConexionData.conexion);
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dni_emp", _dni);
                cmd.Parameters.AddWithValue("@cod_tda", _cod_tda);
                cmd.Parameters.AddWithValue("@tip_id", _tip_des);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables.Count > 1)
                {
                    ds.Tables[0].TableName = "Validacion";
                    ds.Tables[1].TableName = "Datos";
                }
                else
                {
                    ds.Tables[0].TableName = "Validacion";
                }
            }
            catch
            {
                ds = null;
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return ds;
        }
        #endregion

        public static string _actualizar_cliente(string _ruc,string _nombres,string _apepat,string _apemat,
                                                 string _telefono,string _email,string _tda)
        {
            string sqlquery = "USP_Update_FMcli";
            string _valida = "";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(ConexionData.conexion);
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fc_ruc", _ruc);
                cmd.Parameters.AddWithValue("@nombres", _nombres);
                cmd.Parameters.AddWithValue("@apepat", _apepat);
                cmd.Parameters.AddWithValue("@apemat", _apemat);
                cmd.Parameters.AddWithValue("@telefono", _telefono);
                cmd.Parameters.AddWithValue("@email", _email);
                cmd.Parameters.AddWithValue("@tda", _tda);
                cmd.ExecuteNonQuery();
            }
            catch(Exception exc)
            {
                _valida = exc.Message;
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return _valida;
        }
        /// <summary>
        /// insertar clientes bata
        /// </summary>
        /// <param name="numero de dni"></param>
        /// <param name="nombres"></param>
        /// <param name="apelpat"></param>
        /// <param name="apemat"></param>
        /// <param name="email"></param>
        /// <param name="telefono"></param>
        /// <param name="codtda"></param>
        /// <returns></returns>
        public static Boolean _insertar_cliente_bata(string dniruc,string nombres,string apelpat,string apemat,
                                                     string email,string telefono,string codtda)
        {
            Boolean valida = false;
            string sqlquery = "USP_Ins_Mod_ClienteBata";
            try
            {
                using (SqlConnection cn = new SqlConnection(ConexionData.conexion))
                {
                    try
                    {
                        if (cn.State == 0) cn.Open();
                        using (SqlCommand cmd = new SqlCommand(sqlquery, cn))
                        {
                            cmd.CommandTimeout = 0;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@dniruc", dniruc);
                            cmd.Parameters.AddWithValue("@nombres", nombres);
                            cmd.Parameters.AddWithValue("@apelpat", apelpat);
                            cmd.Parameters.AddWithValue("@apemat", apemat);
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@telefono", telefono);
                            cmd.Parameters.AddWithValue("@codtda", codtda);
                            cmd.ExecuteNonQuery();
                            valida = true;
                        }
                    }
                    catch (Exception)
                    {
                        
                    }
                    if (cn != null)
                        if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            catch (Exception)
            {
                valida = false;                
            }
            return valida;
        }
        /// <summary>
        /// consulta de clientes bata
        /// </summary>
        /// <param name="numero de dni"></param>
        /// <returns></returns>
        public static DataTable _consulta_cliente_bata(string _dniruc)
        {
            string sqlquery = "USP_Cons_ClienteBata";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataTable dt = null;
            try
            {
                
                cn = new SqlConnection(ConexionData.conexion);
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DNI", _dniruc);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dt.TableName = "cliente";
            }
            catch
            { 
                dt=null;
            }
            if (cn!=null)
            if (cn.State==ConnectionState.Open) cn.Close();
            return dt;
        }

        public static void get_cupon_genauto(ref GeneraCuponBata set_cupon)
        {
           
            string sqlquery = "[USP_Insertar_Vales_Bata]";
            try
            {
                using (SqlConnection cn = new SqlConnection(ConexionData.conexion))
                {
                    if (cn.State ==0) cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlquery, cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombres", set_cupon.nombres);
                        cmd.Parameters.AddWithValue("@email", set_cupon.email);
                        cmd.Parameters.AddWithValue("@dni", set_cupon.dni);
                        cmd.Parameters.AddWithValue("@pordes", set_cupon.pordes);
                        cmd.Parameters.AddWithValue("@fecha_ini", set_cupon.fechaini);
                        cmd.Parameters.AddWithValue("@fecha_fin", set_cupon.fechafin);
                        cmd.Parameters.AddWithValue("@paresmax", set_cupon.paresmax);
                        cmd.Parameters.AddWithValue("@Grupo", set_cupon.grupo);

                        cmd.Parameters.Add("@barra",SqlDbType.VarChar,20);
                        cmd.Parameters.Add("@serget", SqlDbType.VarChar, 6);
                        cmd.Parameters.Add("@numget", SqlDbType.VarChar, 8);
                        cmd.Parameters.Add("@tipcup", SqlDbType.VarChar, 5);


                        cmd.Parameters["@barra"].Direction = ParameterDirection.Output;
                        cmd.Parameters["@serget"].Direction = ParameterDirection.Output;
                        cmd.Parameters["@numget"].Direction = ParameterDirection.Output;
                        cmd.Parameters["@tipcup"].Direction = ParameterDirection.Output;


                        cmd.ExecuteNonQuery();
                        set_cupon.barra =(string) cmd.Parameters["@barra"].Value;
                        set_cupon.serie = (string)cmd.Parameters["@serget"].Value;
                        set_cupon.correlativo = (string)cmd.Parameters["@numget"].Value;
                        set_cupon.tipcup=(string)cmd.Parameters["@tipcup"].Value;
                    }
                }

            }
            catch
            {
                throw;
            }
           
        }

        public static List<Barra> buscar_barra_dni(string _dni)
        {
            List<Barra> listar = null;
            string sqlquery = "USP_ConsultaCuponesActivo";
            try
            {
                using (SqlConnection cn = new SqlConnection(ConexionData.conexion))
                {
                    if (cn.State == 0) cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlquery, cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@dni", _dni);
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            listar = new List<Barra>();
                            while (dr.Read())
                            {
                                Barra ag = new Barra();
                                ag.barra = dr["barra"].ToString();
                                ag.promocion = dr["promocion"].ToString();
                                ag.fechac =Convert.ToDateTime(dr["fechac"]);
                                listar.Add(ag);
                            }
                        }
                    }
                }
            }
            catch
            {
                listar = null;
            }
            return listar;
        }

        #region<METODOS GIFT CARD>
        public static DataTable BuscarGiftCard(string numero)
        {
            DataTable dt = null;

            using (SqlConnection sql = new SqlConnection(ConexionData.conexion))
            {
                try
                {
                    if (sql.State == 0) sql.Open();
                    SqlDataAdapter da = new SqlDataAdapter("USP_Busca_GiftCard", sql);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@codigo_act", SqlDbType.VarChar).Value = numero;
                    DataTable res = new DataTable();
                    da.Fill(res);
                    sql.Close();
                    dt = res;
                }
                catch (Exception Ex)
                {
                    if (sql != null)
                        if (sql.State == ConnectionState.Open) sql.Close();
                    throw Ex;
                }
            }

            return dt;
        }
        public static DataTable BuscarTicketGF(string empresa, string serie, string numero)
        {
            DataTable dt = null;

            using (SqlConnection sql = new SqlConnection(ConexionData.conexion))
            {
                try
                {
                    if (sql.State == 0) sql.Open();
                    SqlDataAdapter da = new SqlDataAdapter("USP_Busca_TicketGF", sql);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@empresa", SqlDbType.VarChar).Value = empresa;
                    da.SelectCommand.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
                    da.SelectCommand.Parameters.Add("@numero", SqlDbType.VarChar).Value = numero;
                    DataTable res = new DataTable();
                    da.Fill(res);
                    sql.Close();
                    dt = res;
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }

            return dt;
        }
        public static void ActivaGiftCard(string numero, string dni_activa, string nombres, string apepat, string apemat)
        {
            using (SqlConnection sql = new SqlConnection(ConexionData.conexion))
            {
                try
                {
                    if (sql.State == 0) sql.Open();
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "USP_ActEst_GiftCard";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = sql;

                    cmd.Parameters.Add("@codigo", SqlDbType.VarChar).Value = numero;
                    cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = "DS";
                    cmd.Parameters.Add("@dni", SqlDbType.VarChar).Value = dni_activa;
                    cmd.Parameters.Add("@nombres", SqlDbType.VarChar).Value = nombres;
                    cmd.Parameters.Add("@apepat", SqlDbType.VarChar).Value = apepat;
                    cmd.Parameters.Add("@apemat", SqlDbType.VarChar).Value = apemat;

                    cmd.ExecuteNonQuery();

                    sql.Close();
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
        }

        public static void GrabarSQL_Ticket(string tienda,  string serie,   string codigo,  string fecha,   string dni,       string nombres, 
                                            string apepat,  string apemat,  string forpag,  string tarjeta, string nro_tarj,  string detail)
        {
            using (SqlConnection sql = new SqlConnection(ConexionData.conexion))
            {
                try
                {
                    if (sql.State == 0) sql.Open();
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "USP_Graba_Ticket";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = sql;

                    cmd.Parameters.Add("@tienda", SqlDbType.VarChar).Value = tienda;
                    cmd.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
                    cmd.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;
                    cmd.Parameters.Add("@fecha", SqlDbType.VarChar).Value = DateTime.Now;
                    cmd.Parameters.Add("@dni", SqlDbType.VarChar).Value = dni;
                    cmd.Parameters.Add("@nombres", SqlDbType.VarChar).Value = nombres;
                    cmd.Parameters.Add("@apepat", SqlDbType.VarChar).Value = apepat;
                    cmd.Parameters.Add("@apemat", SqlDbType.VarChar).Value = apemat;
                    cmd.Parameters.Add("@forpag", SqlDbType.VarChar).Value = forpag;
                    cmd.Parameters.Add("@tarjeta", SqlDbType.VarChar).Value = tarjeta;
                    cmd.Parameters.Add("@nro_tarj", SqlDbType.VarChar).Value = nro_tarj;
                    cmd.Parameters.Add("@detail", SqlDbType.VarChar).Value = detail;

                    string valida = "'" + tienda + "','" + serie + "','" + codigo + "','" + fecha + "','" + dni + "','" + nombres + "','" + apepat + "','" + apemat + "','" + forpag + "','" + tarjeta + "','" + nro_tarj+ "','" + detail + "'";
                    cmd.ExecuteNonQuery();
                    sql.Close();
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
        }
        #endregion

        #region<REGION DE CONEXIONES DATA BATALUB>

        public static string _update_apltda(string _cod_tda,string _nom_apl,string _ver_apl)
        {
            String sqlquery = "USP_Update_AplTda";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            string _error = "";
            try
            {
                cn = new SqlConnection(ConexionData.conexion_bataclub);
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_tda", _cod_tda);
                cmd.Parameters.AddWithValue("@nom_apl", _nom_apl);
                cmd.Parameters.AddWithValue("@ver_apl", _ver_apl);
                cmd.ExecuteNonQuery();
            }
            catch(Exception exc)
            {
                _error = exc.Message;
                if (cn != null)
                    if (cn.State == ConnectionState.Open) cn.Close();
            }
            if (cn != null)
                if (cn.State == ConnectionState.Open) cn.Close();
            return _error;
        }
        public static Boolean _existe_version_apl(string _cod_tda,string _nom_apl,string _ver_apl)
        {
            string sqlquery = "USP_Verifica_AplTda";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            Boolean _valida = false;
            try
            {
                cn = new SqlConnection(ConexionData.conexion_bataclub);
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_tda", _cod_tda);
                cmd.Parameters.AddWithValue("@nom_apl", _nom_apl);
                cmd.Parameters.AddWithValue("@ver_apl", _ver_apl);
                cmd.Parameters.Add("@exi_ver", SqlDbType.Bit);
                cmd.Parameters["@exi_ver"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                _valida =Convert.ToBoolean(cmd.Parameters["@exi_ver"].Value);
            }
            catch(Exception exc)
            {
                _valida = false;
                if (cn != null)
                    if (cn.State == ConnectionState.Open) cn.Close();
            }
            if (cn != null)
                if (cn.State == ConnectionState.Open) cn.Close();
            return _valida;
        }

        #endregion
        #region<REGION DE SOPORTE>
        public List<Soporte> get_soporte_list()
        {
            List<Soporte> lista = null;
            string sqlquery = "USP_GetSoporteTienda";
            try
            {
                using (SqlConnection cn = new SqlConnection(ConexionData.conexion))
                {
                    try
                    {
                        if (cn.State == 0) cn.Open();
                        using (SqlCommand cmd = new SqlCommand(sqlquery, cn))
                        {
                            cmd.CommandTimeout = 0;
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlDataReader dr = cmd.ExecuteReader();

                            if (dr.HasRows)
                            {
                                lista = new List<Soporte>();
                                while(dr.Read())
                                {
                                    Soporte sop = new Soporte();
                                    sop.nombre = dr["sop_nom"].ToString();
                                    sop.celular = dr["sop_cel"].ToString();
                                    lista.Add(sop);
                                }
                            }

                        }
                    }
                    catch (Exception)
                    {
                        lista = null;
                    }
                    if (cn != null)
                        if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            catch (Exception)
            {
                lista = null;                
            }
            return lista;
        }
        #endregion
    }

    public class PromBata
    {
        public Boolean valida { get; set; }
        public string nom_prom { get; set; }
        public DateTime fecha_ini { get; set; }
        public DateTime fecha_fin { get; set; }
        public Decimal por_des { get; set; }
        public Decimal max_par { get; set; }
    }
}