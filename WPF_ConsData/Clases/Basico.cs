using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Bata.Clases
{
    public class Basico
    {
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
    }
}
