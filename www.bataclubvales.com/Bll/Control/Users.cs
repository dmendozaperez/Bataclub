using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace www.bataclubvales.com.Bll
{
    public class Users
    {
        #region<ATRIBUTOS>
        public Int32 _usu_id { set; get; }
        public string _usu_nombre { set; get; }
        public string _usu_contraseña { set; get; }
        
        public string _usu_est_id { set; get; }
        public string _nombre { set; get; }
        public string _usu_niv_id { set; get; }
        public string _usu_nivel { set; get; }
        public DateTime _usu_creacion { set; get; }
        public string _cod_super { set; get; }
        public string _user_responsable { set; get; }

        #endregion

        

        #region<Metodos Estaticos>

        public static Boolean deleteusertienda(string _cod_tda, decimal _usu_id)
        {
            Boolean _valida = false;
            String sqlquery = "USP_Borrar_Usuario_Tienda";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_id", _usu_id);
                cmd.Parameters.AddWithValue("@usu_tda", _cod_tda);
                cmd.ExecuteNonQuery();
                _valida = true;
            }
            catch
            {
                _valida = false;
            }
            if (cn.State==ConnectionState.Open) cn.Close();
            return _valida;
        }
        public static Boolean insertar_user_tienda(string _cod_tda,decimal _usu_id)
        {
            Boolean _valida = false;
            string sqlquery = "USP_Insertar_Usuario_Tienda";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_id", _usu_id);
                cmd.Parameters.AddWithValue("@usu_cod_tda", _cod_tda);
                cmd.ExecuteNonQuery();
                _valida = true;
            }
            catch
            {
                _valida = false;
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return _valida;
        }
        public static DataTable _leer_super_intranet()
        {
            string sqlquery = "USP_Intranet_Get_Supervisor";
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
            if (cn.State == ConnectionState.Open) cn.Close();
            return dt;
        }
        public static bool updateUsuario(decimal _usu_id,string _usu_nombre,string _usu_documento,string _usu_direccion,string _usu_telefono,
                                         string _usu_celular,string _usu_correo,string _usu_contraseña,string _usu_id_estado,string _usu_id_nivel)
        {
            bool _valida=false;
            string sqlquery = "USP_Modificar_Usuario";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_id", _usu_id);
                cmd.Parameters.AddWithValue("@usu_nombre", _usu_nombre);
                cmd.Parameters.AddWithValue("@usu_documento", _usu_documento);
                cmd.Parameters.AddWithValue("@usu_direccion", _usu_direccion);
                cmd.Parameters.AddWithValue("@usu_telefono", _usu_telefono);
                cmd.Parameters.AddWithValue("@usu_celular", _usu_celular);
                cmd.Parameters.AddWithValue("@usu_correo", _usu_correo);
                cmd.Parameters.AddWithValue("@usu_contraseña", _usu_contraseña);
                cmd.Parameters.AddWithValue("@usu_id_estado", _usu_id_estado);
                cmd.Parameters.AddWithValue("@usu_id_nivel", _usu_id_nivel);
                cmd.ExecuteNonQuery();
                _valida = true;
            }
            catch
            {
                _valida = false;
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return _valida;
        }

        public static DataTable _leer_Nivel()
        {
            string sqlquery = "USP_Leer_Nivel";
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
            if (cn.State == ConnectionState.Open) cn.Close();
            return dt;
        }
        public static DataTable _leer_estado_concepto()
        {
            string sqlquery = "USP_Leer_Concepto_Estado";
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
            if (cn.State == ConnectionState.Open) cn.Close();
            return dt;
        }
        public static DataTable _leer_estado(Decimal _id_mod)
        {
            string sqlquery = "USP_Leer_Estado";
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
                cmd.Parameters.AddWithValue("@Est_Id_mod", _id_mod);
                da=new SqlDataAdapter(cmd);
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

        public static DataSet _leer_usuario_supervisor()
        {
            string sqlquery = "USP_Leer_Usuario_Supervisor";
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

        public static DataSet _leer_usuario()
        {            
            String sqlquery = "USP_Leer_Usuario";
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

        public static void _insertar_auditoria(Decimal _id_uder)
        {
            string sqlquery = "USP_Insertar_Auditoria";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@aud_id_user", _id_uder);
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            if (cn.State == ConnectionState.Open) cn.Close();
        }
        public static DataTable _leer_usuario(string _usv_username)
        {
            DataTable dt = null;
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            string sqlcommand = "USP_Leer_Usuario_Acceso";
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                cmd = new SqlCommand(sqlcommand, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("@Usu_Nombre", _usv_username);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return dt;
        }
        public  string _modificar_contraseña_user()
        {
            string _error = "";
            string sqlquery = "USP_Usuario_Modificar_Contraseña";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_id", _usu_id);
                cmd.Parameters.AddWithValue("@contraseña", _usu_contraseña);
                cmd.ExecuteNonQuery();

            }
            catch(Exception exc)
            {
                _error = exc.Message;
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return _error;
        }
        public static bool _grabar_usuario(string _nombre,string _documento,string _direccion,string _telefono,string _celular,
                                           string _correo, string _login, string _contraseña, string _usu_id_estado, string _usu_id_nivel, string _usu_cod_sup)
        {
            bool _valida = false;
            string sqlquery = "USP_Insertar_Usuario";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Conexion.myconexion());
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_nombre", _nombre);
                cmd.Parameters.AddWithValue("@usu_documento", _documento);
                cmd.Parameters.AddWithValue("@usu_direccion", _direccion);
                cmd.Parameters.AddWithValue("@usu_telefono", _telefono);
                cmd.Parameters.AddWithValue("@usu_celular", _celular);
                cmd.Parameters.AddWithValue("@usu_correo", _correo);
                cmd.Parameters.AddWithValue("@usu_login", _login);
                cmd.Parameters.AddWithValue("@usu_contraseña", _contraseña);
                cmd.Parameters.AddWithValue("@usu_id_estado", _usu_id_estado);
                cmd.Parameters.AddWithValue("@usu_id_nivel",_usu_id_nivel);
                cmd.Parameters.AddWithValue("@usu_cod_sup", _usu_cod_sup);
                cmd.ExecuteNonQuery();
                _valida = true;
            }
            catch
            {
                _valida = false;
            }
            if (cn.State == ConnectionState.Open) cn.Close();
            return _valida;
        }
        #endregion
    }

    public class Users_Intranet
    {
        public string _usu_documento_intranet { set; get; }
        public string _usu_direccion_intranet { set; get; }

        public string _intranet_tienda { set; get; }
        public string _intranet_cod_dis { set; get; }
        public string _intranet_empresa { set; get; }
        public string _intranet_asociado { set; get; }
        public string _intranet_ubicacion { set; get; }
        public string _intranet_localidad { set; get; }
        public string _numero_visita { set; get; }
        public string _fecha_hora_inicio { set; get; }
        public string _semana_bata { set; get; }
        public static DataTable _leer_categoria()
        {
            string sqlquery = "USP_Intranet_Get_Categoria";
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
        public static DataTable _leer_dato_tienda_detalle(string _cod_super,Decimal _user_id)
        {
            string sqlquery = "USP_Intranet_get_Tienda_Datos";
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
                cmd.Parameters.AddWithValue("@cod_super", _cod_super);
                cmd.Parameters.AddWithValue("@user_id", _user_id);
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
        public static DataTable _leer_datos_tienda_super(string cod_super,decimal _user_id)
        {
            string sqlquery = "USP_Intranet_Get_Tienda_Super";
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
                cmd.Parameters.AddWithValue("@cod_super", cod_super);
                cmd.Parameters.AddWithValue("@user_id", _user_id);
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
        public static DataTable _leer_datos_intranet(string _cod_super)
        {
            string sqlquery = "USP_Intranet_Get_Super_Filtro";
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
                cmd.Parameters.AddWithValue("@cod_super", _cod_super);
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
        public static DataSet get_intranet_tienda(decimal _user_id)
        {
            string sqlquery = "USP_Leer_Lista_Super_Tda";
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
                cmd.Parameters.AddWithValue("@usu_id", _user_id);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            catch
            {
                ds = null;
            }
            if (cn.State==ConnectionState.Open) cn.Close();
            return ds;
        }
        public static DataSet get_usuario_tda(decimal _user_id)
        {
            string sqlquery = "USP_Leer_Relacion_Super_Tda";
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
                cmd.Parameters.AddWithValue("@usu_id", _user_id);
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
    }
}