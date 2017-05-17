using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace GeneraBarraPDF.Bll
{
    public class Basico
    {
        public static string conexion
        {
            get { return "Server=10.10.10.208;Database=BdTienda;User ID=sa;Password=Bata2013;Trusted_Connection=False;"; }
        }
        private static DataTable dtbarra()
        {
            String sqlquery = "USP_GetBarraGenera";
            DataTable dt = null;
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {
                cn = new SqlConnection(conexion);
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

        public static void ejecuta_pdf(string file_html,string path_destination,ref Int32 _contar)
        {
            DataTable dt = null;
            try
            {
                dt = dtbarra();

                if (dt!=null)
                {
                    if (dt.Rows.Count>0)
                    {

                        string readContentsprincipal;
                        using (StreamReader streamReader = new StreamReader(@file_html, Encoding.UTF8))
                        {
                            readContentsprincipal = streamReader.ReadToEnd();
                        }

                        for (Int32 i=0;i<dt.Rows.Count;++i)
                        {
                            _contar += 1;
                            string _barra = dt.Rows[i]["Barra"].ToString();
                            string _montovale = dt.Rows[i]["MontoVale"].ToString(); 
                            string _montoletra = dt.Rows[i]["MontLetras"].ToString();
                            string _interno = dt.Rows[i]["Correlativo"].ToString();
                            string _readcontentsecundario = readContentsprincipal;
                            _readcontentsecundario = _readcontentsecundario.Replace("xxxxxxxxxxxxxxx",_barra);
                            _readcontentsecundario = _readcontentsecundario.Replace("MONTOS", _montovale);
                            _readcontentsecundario = _readcontentsecundario.Replace("MONTOL", _montoletra);
                            _readcontentsecundario = _readcontentsecundario.Replace("INTERNO", _interno);

                            string _montovale_int = Convert.ToInt32(dt.Rows[i]["MontoVale"]).ToString();

                            string _file_pdf = "BATA_" + _barra.ToString() + "_" + _montovale_int + ".pdf";
                            string _file_path_pdf = path_destination + "\\" + _file_pdf.ToString();

                            GeneraPDF(_readcontentsecundario, _file_path_pdf);
                        }
                    }
                }

            }
            catch
            {
               
            }
        }

        private static bool GeneraPDF(string readContents, string _file_pdf_destino)
        {
            Boolean _valida = false;
            try
            {
                //string readContents;
                //using (StreamReader streamReader = new StreamReader(@_file_html, Encoding.UTF8))
                //{
                //    readContents = streamReader.ReadToEnd();
                //}
                //readContents = readContents.Replace("XXXXXXXX", "AAAAAAA");
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                htmlToPdf.PageHeight = 242;
                htmlToPdf.PageWidth = 170;
                var margins = new NReco.PdfGenerator.PageMargins();
                margins.Bottom = 2;
                margins.Top = 1;
                margins.Left = 2;
                margins.Right = 5;
                htmlToPdf.Margins = margins;
                htmlToPdf.Orientation = NReco.PdfGenerator.PageOrientation.Portrait;
                htmlToPdf.Zoom = 1F;
                htmlToPdf.Size = NReco.PdfGenerator.PageSize.A4;
                var pdfBytes = htmlToPdf.GeneratePdf(readContents);
                File.WriteAllBytes(@_file_pdf_destino, pdfBytes);
                _valida = true;
            }
            catch
            {
                _valida = false;
            }
            return _valida;
        }
    }
}
