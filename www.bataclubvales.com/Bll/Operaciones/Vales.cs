using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace www.bataclubvales.com.Bll
{
    public class Vales
    {
        public static string _anular_vales(string _barra, string _usu)
        {
            string _error = "";
            string sqlquery = "USP_Anular_Vales";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@barra", _barra);
                cmd.Parameters.AddWithValue("@usu_nombres", _usu);
                cmd.ExecuteNonQuery();
            }
            catch(Exception exc)
            {
                _error = exc.Message;
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return _error;
        }
        public static string _insertar_vales(string _estado,string _barra,string _nombres,string _email,string _dni,decimal _por_des,DateTime _fecha_ini,DateTime _fecha_fin,string _usu)
        {
            string _error = "";
            string sqlquery = "USP_Insertar_Vales";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@estado", _estado);
                cmd.Parameters.AddWithValue("@barra", _barra);

                cmd.Parameters.AddWithValue("@nombres", _nombres);
                cmd.Parameters.AddWithValue("@email", _email);
                cmd.Parameters.AddWithValue("@dni", _dni);
                cmd.Parameters.AddWithValue("@pordes", _por_des);
                cmd.Parameters.AddWithValue("@fechaini", _fecha_ini);
                cmd.Parameters.AddWithValue("@fechafin", _fecha_fin);
                cmd.Parameters.AddWithValue("@usu_nombres", _usu);
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                _error = exc.Message;
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return _error;
        }
        public static DataTable dtinicionewvale()
        {
            string sqlquery = "USP_LeerNuevoVale";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataTable dt = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static DataTable dtconsultavales_paginacion(ref int currentPage,ref int pageSize,ref int _TotalRowCount,string _Buscar )
        {
            string sqlquery = "USP_ListaValesActivos_Pag";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataTable dt = null;
            try
            {
                 pageSize = 10;
                _TotalRowCount = 0;
                int startRowNumber = ((currentPage - 1) * pageSize) + 1;
                cn = new SqlConnection(Conexion.myconexion());
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StartIndex", startRowNumber);
                cmd.Parameters.AddWithValue("@PageSize", pageSize);
                cmd.Parameters.AddWithValue("@buscar", _Buscar);

                SqlParameter parTotalCount = new SqlParameter("@TotalCount", SqlDbType.Int);
                parTotalCount.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parTotalCount);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                _TotalRowCount = Convert.ToInt32(parTotalCount.Value);
            }
            catch(Exception exc)
            {
                dt = null;
            }
            return dt;
        }

        public static DataTable dtconultavales()
        {
            string sqlquery = "USP_ListaValesActivos";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataTable dt = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }
    }
}