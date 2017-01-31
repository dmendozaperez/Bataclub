﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

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
        public static DataTable _data_cliente(string _dniruc)
        {
            string sqlquery = "USP_ConsultaCliente";
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
                cmd.Parameters.AddWithValue("@dniruc", _dniruc);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dt.TableName = "cliente";
            }
            catch
            { 
                dt=null;
            }
            if (cn.State==ConnectionState.Open) cn.Close();
            return dt;
        }

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
    }
}