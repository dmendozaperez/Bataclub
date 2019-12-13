using Epson_Ticket;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Bata.Clases
{
    public class Basico
    {
        private static string[] caracteres =
       {
        "§","°",
        " ","á",
        "‚","é",
        "¡","í",
        "¢","ó",
        "£","ú",
        "µ","Á",
        " ","É",
        "Ö","Í",
        "à","Ó",
        "é","Ú",
        "¥","Ñ",
        "¤","ñ",
    };
        private static string ReemplazarCaracteresEspeciales(string origen)
        {
            string destino = "";
            List<string> listCaracteres = new List<string>();
            for (int i = 0; i < origen.Length; i++)
            {
                listCaracteres.Add(origen[i].ToString());
            }

            for (int i = 0; i < listCaracteres.Count; i++)
            {
                for (int j = 0; j < caracteres.Length; j = j + 2)
                {
                    if (listCaracteres[i] == caracteres[j])
                    {
                        listCaracteres[i] = listCaracteres[i].Replace(listCaracteres[i], caracteres[j + 1]);
                        j = caracteres.Length + 1;
                    }
                }
            }

            for (int i = 0; i < listCaracteres.Count; i++)
            {
                destino = destino + listCaracteres[i];
            }

            return destino;
        }

        public static Boolean _generadbf__ins_upd(DataTable dt_in)
        {
            //string _serie,string _correlativo,string _dni,string _nombres,
            //                                     string _apepat,string _apemat,string _telefono,string _email
            Boolean _valida = false;
            DBF.NET.DBFNET temp_dbf;
            try
            {

                if (dt_in == null) return false;
                if (dt_in.Rows.Count ==0) return false;

                temp_dbf = new DBF.NET.DBFNET();
                /*en este metodo vamos a crear la carpeta temp dbf in*/
                string _ruta_folder_dbf = temp_dbf._path_envia;
                string _ruta_file_dbf = temp_dbf._path_envia + "\\TEMPIN.dbf";  
                /*si no existe carpeta temp*/
                if (!Directory.Exists(@_ruta_folder_dbf)) Directory.CreateDirectory(@_ruta_folder_dbf);

                /*creamos las columnas del temporal in porque no existe*/
                temp_dbf.tabla = "TEMPIN";
                temp_dbf.addcol("serie", DBF.NET.Tipo.Caracter, "10");
                temp_dbf.addcol("numero", DBF.NET.Tipo.Caracter, "15");
                temp_dbf.addcol("dni", DBF.NET.Tipo.Caracter, "15");
                temp_dbf.addcol("nombres", DBF.NET.Tipo.Caracter, "100");
                temp_dbf.addcol("apepat", DBF.NET.Tipo.Caracter, "100");
                temp_dbf.addcol("apemat", DBF.NET.Tipo.Caracter, "100");
                temp_dbf.addcol("telefono", DBF.NET.Tipo.Caracter, "50");
                temp_dbf.addcol("email", DBF.NET.Tipo.Caracter, "100");
                /*****************************/
                /*si no existe el archivo db temp*/
                if (!File.Exists(@_ruta_file_dbf))
                {                                   
                    /*crear dbf*/
                    temp_dbf.creardbf();
                    temp_dbf.Insertar_tabla(dt_in);
                    _valida = true;
                }
                else
                {
                    string _serie = dt_in.Rows[0]["serie"].ToString();
                    string _numero = dt_in.Rows[0]["numero"].ToString();
                    Boolean _valida_delete = temp_dbf.delete(_serie, _numero);

                    if (_valida_delete)
                    temp_dbf.Insertar_tabla(dt_in);


                    _valida = true;
                }                
            }
            catch
            {
                temp_dbf = null;
                _valida = false;
            }
            return _valida;
        }
        #region<IMPRIMIR TICKETS BATACLUB>
        public static void Imprime_Bataclub(string Barra)
        {
            string impresora = "Ticket";
            try
            {


                //SendStringToPrinter(impresora, Barra);
                //return;

                ws_clientedniruc.Cons_ClienteSoapClient format_bc = new ws_clientedniruc.Cons_ClienteSoapClient();

                var imp=format_bc.ws_formato_bataclub();



                //string line1 = ReemplazarCaracteresEspeciales(imp[0].texto);
                //string line2 = ReemplazarCaracteresEspeciales(imp[1].texto);
                //string line3 = ReemplazarCaracteresEspeciales(imp[3].texto);

                string line1 = (imp[0].texto);
                string line2 = (imp[1].texto);
                string line3 = (imp[3].texto);

                CrearTicket tk = new CrearTicket();
                tk.TextoCentro(line1);
                tk.lineasGuio();
                tk.TextoCentro(line2);
                tk.lineasGuio();
                tk.TextoIzquierda(line3);
                tk.lineasGuio();
                tk.TextoCentro(Barra);
                tk.lineasGuio();
                tk.ImprimirTicket(impresora);
                tk.lineasGuio();

                BarcodeLib.Barcode Codigo = new BarcodeLib.Barcode();
                Codigo.IncludeLabel = true;
                System.Drawing.Image im = Codigo.Encode(BarcodeLib.TYPE.CODE128, Barra, System.Drawing.Color.Black, System.Drawing.Color.White, 400, 100);

                tk.HeaderImage = im;

                tk.PrintQR(impresora);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            CrearTicket tk = new CrearTicket();
            Bata.Clases.RawPrinterHelper.SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            // Send the converted ANSI string to the printer.
            //SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
        #endregion
    }
}
