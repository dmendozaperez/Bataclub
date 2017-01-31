using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace www.bataclubvales.com.Bll
{
    public class ApplicationFunctions
    {
        public int _id { set; get; }
        public string _nombre { set; get; }
        public string _descripcion { set; get; }
        public string _comentario { set; get; }
        public int _idpadre { set; get; }
        public string _url { set; get; }
        public Boolean _verifica_submenu { set; get; }

        #region<METODOS ESTATICOS>
        public static List<ApplicationFunctions> getFunctions_tree(decimal _bas_id)
        {
            DataTable dt = null;
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            string sqlquery = "USP_Leer_Funcion_Arbol";
            try
            {

                List<ApplicationFunctions> colappfunctions = new List<ApplicationFunctions>();               
                cn = new SqlConnection(Conexion.myconexion());
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("@bas_id", _bas_id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

               
                foreach (DataRow row in dt.Rows)
                {

                    colappfunctions.Add(
                        new ApplicationFunctions
                        {
                            _id = Int32.Parse(row["fun_id"].ToString()),
                            _nombre = row["fun_nombre"].ToString(),
                            _descripcion = row["Fun_Descripcion"].ToString(),
                            _idpadre = Int32.Parse(row["fun_padre"].ToString()),                            
                            _url = row["apl_url"].ToString(),
                            _comentario = row["apl_comentario"].ToString(),
                            _verifica_submenu=Convert.ToBoolean(row["verifica_submenu"]),
                        }
                        );
                }

                return colappfunctions;
            }
            catch (Exception e) { throw new Exception(e.Message, e.InnerException); }
        }
        #endregion
    }
}