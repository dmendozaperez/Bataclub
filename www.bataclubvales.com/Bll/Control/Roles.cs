using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace www.bataclubvales.com.Bll
{
    public class Roles
    {
        #region <Atributos>
        
        private decimal _RON_ID { get; set; }
        private string _ROV_NAME { get; set; }
        private string _ROV_DESCRIPTION { get; set; }

        /// <summary>
        /// Nombre de conexion a bd
        /// </summary>

        #endregion
        #region <Metodos Estaticos>
        public static bool insertRole(string ROV_NAME, string ROV_DESCRIPTION)
        {
            bool _valida = false;
            string sqlquery = "USP_Insertar_Roles";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rol_id", 0);
                cmd.Parameters.AddWithValue("@rol_nombre", ROV_NAME);
                cmd.Parameters.AddWithValue("@rol_descripcion", ROV_DESCRIPTION);
                cmd.ExecuteNonQuery();
                _valida=true;
            }
            catch (Exception)
            { 
                _valida=false; 
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return _valida;
        }
        public static DataSet getRoles()
        {
            string sqlquery = "USP_Leer_Roles";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataSet ds = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            catch
            {
                ds = null;
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return ds;
        }
        public static bool updateRole(int RON_ID, string ROV_NAME, string ROV_DESCRIPTION)
        {
            bool _valida = false;
            string sqlquery = "USP_Modificar_Roles";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rol_id", RON_ID);
                cmd.Parameters.AddWithValue("@rol_nombre", ROV_NAME);
                cmd.Parameters.AddWithValue("@rol_descripcion", ROV_DESCRIPTION);

                cmd.ExecuteNonQuery();

                _valida=true;
            }
            catch (Exception) 
            {
                _valida = false;
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return _valida;
        }
        public static DataSet GetRolesByUser(decimal USN_USERID)
        {
            string sqlquery = "USP_Leer_Roles_Usuario";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataSet ds = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_id", USN_USERID);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            catch
            {
                ds = null;
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return ds;
        }
        public static bool insertUserRole(decimal _URN_ROLEID, decimal _URN_USERID)
        {
            bool _valida = false;
            string sqlquery = "USP_Insertar_Usuario_Roles";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_rol_idusu", _URN_USERID);
                cmd.Parameters.AddWithValue("@usu_rol_idrol", _URN_ROLEID);
                cmd.ExecuteNonQuery();
                _valida=true;
            }
            catch (Exception) 
            {
                _valida=false;
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return _valida;
        }
        public static bool deleteUserRole(decimal _URN_ROLEID, decimal _URN_USERID)
        {
            bool _valida = false;
            string sqlquery = "USP_Borrar_Usuario_Roles";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_rol_idusu", _URN_USERID);
                cmd.Parameters.AddWithValue("@usu_rol_idrol", _URN_ROLEID);
                cmd.ExecuteNonQuery();
                _valida=true;
            }
            catch (Exception) 
            { 
                _valida=false;
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return _valida;
        }
        #endregion
    }
}