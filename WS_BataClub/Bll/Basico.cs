using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace WS_BataClub.Bll
{
    public class Basico
    {
        public static string _genera_vales(string _nombres,string _email,string _dni,int _pordes,int _dias,int _pares_max,string _tipo_des)
        {
            string sqlquery = "[USP_Insertar_Vales_Metricard]";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            string _barra = "";          
            try
            {
                cn = new SqlConnection(ConexionData.conexion);
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombres", _nombres);
                cmd.Parameters.AddWithValue("@email", _email);
                cmd.Parameters.AddWithValue("@dni", _dni);
                cmd.Parameters.AddWithValue("@pordes", _pordes);
                cmd.Parameters.AddWithValue("@dias", _dias);
                cmd.Parameters.AddWithValue("@paresmax", _pares_max);
                cmd.Parameters.AddWithValue("@Grupo", _tipo_des);

                cmd.Parameters.Add("@barra", SqlDbType.VarChar, 20);
                cmd.Parameters["@barra"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();


                _barra = cmd.Parameters["@barra"].Value.ToString();

            }
            catch
            {
                if (cn != null)
                    if (cn.State == ConnectionState.Open) cn.Close();
                throw;               
            }
            if (cn != null)
                if (cn.State == ConnectionState.Open) cn.Close();
            return _barra;
        }
        public static Boolean VerificarPermisos(Autenticacion value)
        {
            Boolean _valida_permiso = false;
            if (value == null)
            {
                _valida_permiso = false;
            }
            else
            {
                _valida_permiso = VALIDA_USUARIO_WS(value.user_name, value.user_password);
            }
            return _valida_permiso;
        }
        private static Boolean VALIDA_USUARIO_WS(string _usuario, string _password)
        {
            Boolean _valida = false;
            string sqlquery = "[USP_Acceso_Ws_Metri]";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(ConexionData.conexion);
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USU_WS_NAME", _usuario);
                cmd.Parameters.AddWithValue("@USU_WS_PASS", _password);
                cmd.Parameters.Add("@VALIDA_USU", SqlDbType.Bit);
                cmd.Parameters["@VALIDA_USU"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                _valida = Convert.ToBoolean(cmd.Parameters["@VALIDA_USU"].Value);
            }
            catch (Exception exc)
            {
               // _error_msg = exc.Message;
                _valida = false;
            }
            if (cn != null)
                if (cn.State == ConnectionState.Open) cn.Close();
            return _valida;
        }
        public static List<ListaCliente> return_barra_list(ListaItems list_cliente, int _pordes, int _dias, int _pares_max, string _tipo_des)
        {
            string sqlquery = "[USP_Insertar_Vales_Metricard_Grupo]";
            List<ListaCliente> list_return =null;
            try
            {               

                if (list_cliente.Lista.Count()>0)
                {
                    /*verificamos si la lista hay valores si esta haci entonces creamos un datatable temporal*/
                    DataTable dt = new DataTable();
                    dt.Columns.Add("dni", typeof(string));
                    dt.Columns.Add("nombres", typeof(string));
                    dt.Columns.Add("apellidos", typeof(string));
                    dt.Columns.Add("email", typeof(string));
                    dt.Columns.Add("barra", typeof(string));

                    foreach(var item in list_cliente.Lista)
                    {
                        dt.Rows.Add(item.dni, item.nombre, item.apellidos, item.email, item.barra);
                    }

                    using (SqlConnection cn = new SqlConnection(ConexionData.conexion))
                    {
                        using (SqlCommand cmd = new SqlCommand(sqlquery, cn))
                        {
                            cmd.CommandTimeout = 0;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@pordes", _pordes);
                            cmd.Parameters.AddWithValue("@dias", _dias);
                            cmd.Parameters.AddWithValue("@paresmax",_pares_max);
                            cmd.Parameters.AddWithValue("@prom_des", _tipo_des);
                            cmd.Parameters.AddWithValue("@tmpcupones", dt);

                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                DataTable dtbarra = new DataTable();
                                da.Fill(dtbarra);

                                if (dtbarra.Rows.Count>0)
                                {
                                    list_return = new List<ListaCliente>();

                                    list_return = (from item in dtbarra.AsEnumerable()
                                                          select new ListaCliente
                                                          {
                                                              dni= item.Field<string>("dni"),
                                                              nombre= item.Field<string>("nombres"),
                                                              apellidos = item.Field<string>("apellidos"),
                                                              email = item.Field<string>("email"),
                                                              barra = item.Field<string>("barra"),
                                                          }).ToList();
                                }

                            }
                        }
                    }
                }

            }
            catch(Exception exc)
            {
                list_return = null;
            }
            return list_return;
        }
    }
}