using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace www.bataclubvales.com.Bll
{
    public class ApplicationClass
    {
        #region<VARIABLES>
        public decimal _APN_ID { get; set; }
        public string _APV_NAME { get; set; }        
        public string _APV_URL { get; set; }
        public decimal _APN_ORDER { get; set; }        
        public string _APV_STATUS { get; set; }
        public string _APV_HELP { get; set; }
        public string _APV_COMMENTS { get; set; }
        #endregion

        #region <Metodos Publicos>

        public static bool deleteAppFunction(decimal _AFN_APLIID, decimal _AFN_FUNCTIONID)
        {
            bool _valida = false;
            string sqlquery = "USP_Borrar_Apl_Fun";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@apl_fun_aplid", _AFN_APLIID);
                cmd.Parameters.AddWithValue("@apl_fun_funid", _AFN_FUNCTIONID);
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
        public static bool insertAppFunction(decimal _AFN_APLIID, decimal _AFN_FUNCTIONID)
        {
            bool _valida = false;
            string sqlquery = "USP_Insertar_Apl_Fun";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@apl_fun_aplid", _AFN_APLIID);
                cmd.Parameters.AddWithValue("@apl_fun_funid", _AFN_FUNCTIONID);
                cmd.ExecuteNonQuery();
                _valida=true;
            }
            catch
            {
                _valida=false;
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return _valida;
        }
        public static DataSet ApplicationByFunc(decimal FUN_ID)
        {
            string sqlquery = "USP_Leer_Apl_Fun";
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
                cmd.Parameters.AddWithValue("@Fun_Id", FUN_ID);
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


        public bool InsertApplication()
        {
            bool _valida = false;
            string sqlquery = "USP_Insertar_Aplicacion";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@apl_id", _APN_ID);
                cmd.Parameters.AddWithValue("@apl_nombre", _APV_NAME);                
                cmd.Parameters.AddWithValue("@apl_url", _APV_URL);
                cmd.Parameters.AddWithValue("@apl_orden", _APN_ORDER);
                cmd.Parameters.AddWithValue("@apl_est_id", _APV_STATUS);
                cmd.Parameters.AddWithValue("@apl_ayuda", _APV_HELP);
                cmd.Parameters.AddWithValue("@apl_comentario", _APV_COMMENTS);
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
        public static bool UpdateApplication(decimal APN_ID, string APV_NAME, string APV_URL, decimal APN_ORDER, string APV_STATUS, string APV_HELP, string APV_COMMENTS)
        {
            bool _valida = false;
            string sqlquery = "USP_Modificar_Aplicacion";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@apl_id", APN_ID);
                cmd.Parameters.AddWithValue("@apl_nombre", APV_NAME);                
                cmd.Parameters.AddWithValue("@apl_url", APV_URL);
                cmd.Parameters.AddWithValue("@apl_orden", APN_ORDER);
                cmd.Parameters.AddWithValue("@apl_est_id", APV_STATUS);
                cmd.Parameters.AddWithValue("@apl_ayuda", APV_HELP);
                cmd.Parameters.AddWithValue("@apl_comentario", APV_COMMENTS);
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

        public static DataTable GetAllAplications()
        {
            string sqlquery = "USP_Leer_Aplicacion";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataTable dt = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch
            {
                dt = null;
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return dt;
        }

        #endregion
    }
}