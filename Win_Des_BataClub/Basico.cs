using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win_Des_BataClub
{
    public class Basico
    {
        public static string conexion
        {
            get { return "Server=172.28.7.14;Database=BdPos;User ID=pos_oracle;Password=Bata2018**;Trusted_Connection=False;"; }
        }

        public static DataTable dtlista()
        {
            string sqlquery = "USP_ListDataTempoBataClub";
            DataTable dt = null;
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
            catch
            {
                dt = null;
            }
            return dt;
        }
    }
}
