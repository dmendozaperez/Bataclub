using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace www.bataclubvales.com.Bll
{
    public class Functions
    {
        #region<VARIABLES>        
        public decimal _FUN_ID { get; set; }
        public string _FUV_NAME { get; set; }
        public string _FUV_DESCRIPTION { get; set; }
        public decimal? _FUN_ORDER { get; set; }
        public decimal? _FUN_FATHER { get; set; }
        public decimal _FUN_SYSTEM { get; set; }        
        #endregion

        public static bool updateFunction(decimal FUN_ID, string FUV_NAME, string FUV_DESCRIPTION, decimal? FUN_ORDER, decimal? FUN_FATHER)
        {
            bool _valida = false;
            SqlConnection cn = null;
            SqlCommand cmd = null;
            string sqlquery = "USP_Modificar_Funcion";
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fun_id", FUN_ID);
                cmd.Parameters.AddWithValue("@fun_nombre", FUV_NAME);
                cmd.Parameters.AddWithValue("@fun_descripcion", FUV_DESCRIPTION);
                cmd.Parameters.AddWithValue("@fun_orden", FUN_ORDER);
                cmd.Parameters.AddWithValue("@fun_padre", FUN_FATHER);

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
        public bool InsertFunction()
        {
            bool _valida = false;
            string sqlquery = "USP_Insertar_Funcion";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fun_id", _FUN_ID);
                cmd.Parameters.AddWithValue("@fun_nombre", _FUV_NAME);
                cmd.Parameters.AddWithValue("@fun_descripcion", _FUV_DESCRIPTION);
                cmd.Parameters.AddWithValue("@fun_orden", _FUN_ORDER);
                cmd.Parameters.AddWithValue("@fun_padre", _FUN_FATHER);
                cmd.Parameters.AddWithValue("@fun_sisid", _FUN_SYSTEM);
                cmd.ExecuteNonQuery();
                _valida= true;

            }
            catch (Exception)
            {
                _valida=false;
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return _valida;
        }

        #region<METODOS ESTATICOS>
        public static DataSet GetAllFunctionsDS()
        {
            string sqlquery = "USP_Leer_Funcion_Sistema";
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

        public static bool InsertRoleFunction(decimal _RFN_FUNCTIONID, decimal _RFN_ROLEID)
        {
            bool _valida = false;
            string sqlquery = "USP_Insertar_Roles_Funcion";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rol_fun_rolid", _RFN_ROLEID);
                cmd.Parameters.AddWithValue("@rol_fun_funid", _RFN_FUNCTIONID);
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
        public static bool RemoveRoleFunction(decimal _RFN_FUNCTIONID, decimal _RFN_ROLEID)
        {
            bool _valida = false;
            string sqlquery = "USP_Borrar_Roles_Funcion";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rol_fun_rolid", _RFN_ROLEID);
                cmd.Parameters.AddWithValue("@rol_fun_funid", _RFN_FUNCTIONID);
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
        public static DataSet GetFunctionsByRol(decimal RON_ID)
        {
            string sqlquery = "USP_Leer_Funcion_Roles";
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
                cmd.Parameters.AddWithValue("@rol_id", RON_ID);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                throw;
            }


        }
        #endregion
    }
}