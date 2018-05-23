using Epson_Ticket;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Bata.Clases
{
    class GiftCards
    {
        private static string _path_dbf
        {
            //get { return "D:\\POS-Net\\DBFs Prueba\\"; }
            get { return "D:\\POS\\"; }
        }

        public static DataTable BuscarGiftCard(string numero)
        {
            DataTable dt = null;

            try
            {
                ws_clientedniruc.Cons_ClienteSoapClient ws_cliente = new ws_clientedniruc.Cons_ClienteSoapClient();
                dt = ws_cliente.ws_BuscarGiftCard(numero);
            }
            catch (Exception Ex)
            {

                dt = null;
            }
            return dt;
        }
        
        public static DataTable BuscarTicketGF(string empresa, string serie, string numero)
        {
            DataTable dt = null;

            try
            {
                ws_clientedniruc.Cons_ClienteSoapClient ws_cliente = new ws_clientedniruc.Cons_ClienteSoapClient();
                dt = ws_cliente.ws_BuscarTicketGF( empresa,  serie,  numero);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static void ActivaGiftCard(string numero, string dni_activa, string nombres, string apepat, string apemat)
        {
            try
            {
                ws_clientedniruc.Cons_ClienteSoapClient ws_cliente = new ws_clientedniruc.Cons_ClienteSoapClient();
                ws_cliente.ws_ActivaGiftCard(numero, dni_activa, nombres, apepat, apemat);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public static void GrabarSQL_Ticket(string tienda, string serie, string codigo, string fecha, string dni, string nombres, string apepat, string apemat, string forpag, string tarjeta, string nro_tarj, string detail)
        {
            try
            {
                ws_clientedniruc.Cons_ClienteSoapClient ws_cliente = new ws_clientedniruc.Cons_ClienteSoapClient();
                ws_cliente.ws_GrabarSQL_Ticket(tienda, serie, codigo, fecha, dni, nombres, apepat, apemat, forpag, tarjeta, nro_tarj, detail);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public static string GrabarDBF_Ticket(string empresa, string serie, string fecha, string dni, string nombres, string apepat, string apemat, string forpag, string tarjeta, string nro_tarj, DataTable detalle)
        {
            string sConn = "Provider = vfpoledb.1;Data Source=" + System.IO.Path.GetDirectoryName(_path_dbf) + ";Collating Sequence=general";

            string codigo = "";
            string detail = "";
            string sucursal = "";
            string fecha_sql = fecha.Substring(6, 4) + fecha.Substring(0, 2) + fecha.Substring(3, 2);
            string tab_fpctrl = "FPCTRL" + empresa;     // Leer
            using (System.Data.OleDb.OleDbConnection dbConn = new System.Data.OleDb.OleDbConnection(sConn))
            {
                try
                {
                    dbConn.Open();

                    //-- Obtenemos datos de Control (Parametros Generales)
                    string sql_datos_gral = "SELECT * FROM " + tab_fpctrl + " ";
                    System.Data.OleDb.OleDbCommand dat_grales = new System.Data.OleDb.OleDbCommand(sql_datos_gral, dbConn);
                    System.Data.OleDb.OleDbDataAdapter dat_gral = new System.Data.OleDb.OleDbDataAdapter(dat_grales);
                    DataTable datos_gral = new DataTable();
                    dat_gral.Fill(datos_gral);

                    sucursal = datos_gral.Rows[0]["C_SUCU"].ToString().Trim();
                    if(sucursal.Length < 5)
                    {
                        sucursal = "50" + sucursal;
                    }

                    string consulta = "SELECT MAX(NUMERO) As NUMERO FROM TKACTIVC WHERE Serie = '" + serie + "'";
                    System.Data.OleDb.OleDbCommand con = new System.Data.OleDb.OleDbCommand(consulta, dbConn);
                    System.Data.OleDb.OleDbDataAdapter cona = new System.Data.OleDb.OleDbDataAdapter(con);
                    DataTable dt = new DataTable();
                    cona.Fill(dt);

                    if (dt.Rows.Count > 0 && dt.Rows[0]["NUMERO"].ToString()!= "")
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            codigo = (Convert.ToInt32(r["NUMERO"]) + 1).ToString().Trim().PadLeft(8).Replace(" ", "0");
                        }
                    }
                    else
                    {
                        codigo = "1".PadLeft(8).Replace(" ", "0");
                    }

                    string inserta = "Insert Into TKACTIVC (SERIE, NUMERO, FECHA, TIDE, DIDE, NOMCLI, APEPAT, APEMAT, FORPAG, TARJET, NROTAR) ";
                    inserta += "VALUES ('" + serie + "', '" + codigo + "', CTOD('" + fecha + "'), '1', '" + dni + "', '" + nombres + "', '" + apepat + "', '" + apemat + "', '" + forpag + "', '" + tarjeta + "', '" + nro_tarj + "')";
                    System.Data.OleDb.OleDbCommand mov_cab = new System.Data.OleDb.OleDbCommand(inserta, dbConn);
                    mov_cab.ExecuteNonQuery();

                    foreach (DataRow row in detalle.Rows)
                    {
                        // Datos para SQL
                        if (detail != "") { detail += "|"; }
                        detail += row["Cod_Barra"].ToString() + "/" + row["Cantidad"].ToString() + "/" + row["Monto"].ToString();

                        // Datos para DBF
                        string det = "Insert Into TKACTIVD (SERIE, NUMERO, CODACTI, CANT, MTOUNI) ";
                        det += "VALUES ('" + serie + "', '" + codigo + "', '" + row["Cod_Barra"].ToString() + "', " + row["Cantidad"].ToString() + ", " + row["Monto"].ToString() + ")";
                        System.Data.OleDb.OleDbCommand mov_det = new System.Data.OleDb.OleDbCommand(det, dbConn);
                        mov_det.ExecuteNonQuery();
                    }
                    dbConn.Close();

                    GrabarSQL_Ticket(sucursal, serie, codigo, fecha_sql, dni, nombres, apepat, apemat, forpag, tarjeta, nro_tarj, detail);
                }
                catch (Exception ex)
                {
                    dbConn.Close();
                    throw ex;
                }

            }
            return codigo;
        }


        public static void GrabarDBF_Stock(string empresa, string tp_doc, string serie, string numero, string fecha, string dni, string nombres, string apepat, string apemat, DataTable detalle)
        {
            string sConn = "Provider = vfpoledb.1;Data Source=" + System.IO.Path.GetDirectoryName(_path_dbf) + ";Collating Sequence=general";

            string tabla_error = "";
            string msaje_error = "";

            using (System.Data.OleDb.OleDbConnection dbConn = new System.Data.OleDb.OleDbConnection(sConn))
            {
                try
                {
                    dbConn.Open();

                    //-- Obtenemos los datos para completar los nombres de tablas
                    string mes = fecha.Substring(0, 2);
                    string ano = fecha.Substring(9, 1);
                    string ano_comp = fecha.Substring(6, 4);
                    string sem = (Convert.ToInt32(mes) < 7) ? "1" : "2";
                    string tab_fpctrl = "FPCTRL" + empresa;     // Leer
                    string tab_fpdocu = "FPDOCU" + empresa;     // Leer
                    string tab_fcierr = "FCIERR" + empresa;     // Leer
                    string tab_ftperi = "FTPERI" + empresa;     // Leer
                    string tab_fstka = "FSTKA" + ano + empresa;     // Actualizar
                    string tab_fstkg = "FSTKG" + ano + empresa;     // Actualizar
                    string tab_fmc = "FMC" + mes + ano + empresa;   // Agregar
                    string tab_fmd = "FMD" + mes + ano + empresa;   // Agregar
                    string tab_fmk = "FMK" + mes + ano + empresa;   // Agregar
                    string tab_fresum = "FRESUM" + empresa;         // Actualizar

                    int contador = 0;

                    string cod_almacen = "";
                    string tipo_prod = "";
                    string sucursal = "";
                    string semana = "";

                    //-- Obtenemos datos de Control (Parametros Generales)
                    string sql_datos_gral = "SELECT * FROM " + tab_fpctrl + " ";
                    tabla_error = tab_fpctrl;
                    System.Data.OleDb.OleDbCommand dat_grales = new System.Data.OleDb.OleDbCommand(sql_datos_gral, dbConn);
                    System.Data.OleDb.OleDbDataAdapter dat_gral = new System.Data.OleDb.OleDbDataAdapter(dat_grales);
                    DataTable datos_gral = new DataTable();
                    dat_gral.Fill(datos_gral);

                    //-- Obtenemos datos de semana activa
                    string sql_datos_peri = "SELECT * FROM " + tab_ftperi + " WHERE P_YEAR = '" + ano_comp + "' AND P_FINI <= CTOD('" + fecha + "') AND P_FFIN >= CTOD('" + fecha + "')";
                    tabla_error = tab_ftperi;
                    System.Data.OleDb.OleDbCommand com_dat_peri = new System.Data.OleDb.OleDbCommand(sql_datos_peri, dbConn);
                    System.Data.OleDb.OleDbDataAdapter ada_dat_peri = new System.Data.OleDb.OleDbDataAdapter(com_dat_peri);
                    DataTable dat_peri = new DataTable();
                    ada_dat_peri.Fill(dat_peri);

                    // Llenamos los datos
                    cod_almacen = datos_gral.Rows[0]["C_CALM"].ToString().Trim();
                    sucursal = datos_gral.Rows[0]["C_SUCU"].ToString().Trim();
                    tipo_prod = "A";
                    semana = dat_peri.Rows[0]["P_PERI"].ToString().Trim();

                    //Valida estado de cierre
                    string sql_val_fcierr = "SELECT * FROM " + tab_fcierr + " WHERE CI_CSUC='" + sucursal + "' AND CI_FECH=CTOD('" + fecha + "')";
                    tabla_error = tab_fcierr;
                    System.Data.OleDb.OleDbCommand com_val_fcierr = new System.Data.OleDb.OleDbCommand(sql_val_fcierr, dbConn);
                    System.Data.OleDb.OleDbDataAdapter ada_val_fcierr = new System.Data.OleDb.OleDbDataAdapter(com_val_fcierr);
                    DataTable dat_val_fcierr = new DataTable();
                    ada_val_fcierr.Fill(dat_val_fcierr);

                    if (dat_val_fcierr.Rows.Count > 0)
                    {
                        if (dat_val_fcierr.Rows[0]["CI_ESTA"].ToString().Trim() != "C")
                        {
                            // Empezamos a realizar las modificaciones de Stock por registro
                            foreach (DataRow row in detalle.Rows)
                            {
                                // Conteo de Items
                                contador = contador + 1;

                                /**************************************/
                                /*****************FSTKA****************/
                                /**************************************/
                                string sql_val_fstka = "SELECT * FROM " + tab_fstka + " WHERE SA_ALMA='" + cod_almacen + "' AND SA_TANE='' AND SA_CONS='' AND SA_TIPO='" + tipo_prod + "' AND SA_ARTI='" + row["Articulo"].ToString() + "1' And SA_REGL='00' AND  SA_COLO=''";
                                tabla_error = tab_fstka;
                                System.Data.OleDb.OleDbCommand com_val_fstka = new System.Data.OleDb.OleDbCommand(sql_val_fstka, dbConn);
                                System.Data.OleDb.OleDbDataAdapter ada_val_fstka = new System.Data.OleDb.OleDbDataAdapter(com_val_fstka);
                                DataTable dat_val_fstka = new DataTable();
                                ada_val_fstka.Fill(dat_val_fstka);

                                if (dat_val_fstka.Rows.Count > 0)
                                {// Si encuentra registros (Actualiza)
                                    string sql_act_fstka = "UPDATE " + tab_fstka + " SET SA_SA" + mes + "=SA_SA" + mes + "-" + row["Cantidad"].ToString() + ", SA_ACUSEM" + sem + "=SA_ACUSEM" + sem + "+" + row["Cantidad"].ToString() + " WHERE SA_ALMA='" + cod_almacen + "' AND SA_TANE='' AND SA_CONS='' AND SA_TIPO='" + tipo_prod + "' AND SA_ARTI='" + row["Articulo"].ToString() + "1' And SA_REGL='00' AND  SA_COLO=''";
                                    System.Data.OleDb.OleDbCommand com_act_fstka = new System.Data.OleDb.OleDbCommand(sql_act_fstka, dbConn);
                                    com_act_fstka.ExecuteNonQuery();
                                }
                                else
                                {// Si no lo encuentra en la tabla (crea un nuevo registro a partir del año anterior)
                                 // Tener en cuenta que esto solo sucede en Enero
                                    string ano_ant = "";
                                    if (ano == "0") { ano_ant = "9"; } else { ano_ant = (Convert.ToInt32(ano) - 1).ToString(); }
                                    string tab_fstka_ant = "FSTKA" + ano_ant + empresa;
                                    //Obtengo datos anteriores
                                    string sql_ant_fstka = "SELECT * FROM " + tab_fstka_ant + " WHERE SA_ALMA='" + cod_almacen + "' AND SA_TANE='' AND SA_CONS='' AND SA_TIPO='" + tipo_prod + "' AND SA_ARTI='" + row["Articulo"].ToString() + "1' And SA_REGL='00' AND  SA_COLO=''";
                                    tabla_error = tab_fstka_ant;
                                    System.Data.OleDb.OleDbCommand com_ant_fstka = new System.Data.OleDb.OleDbCommand(sql_ant_fstka, dbConn);
                                    System.Data.OleDb.OleDbDataAdapter ada_ant_fstka = new System.Data.OleDb.OleDbDataAdapter(com_ant_fstka);
                                    DataTable dat_ant_fstka = new DataTable();
                                    ada_ant_fstka.Fill(dat_ant_fstka);

                                    //grabo nueva linea
                                    string sql_ins_fstka = "INSERT INTO " + tab_fstka + " (SA_TIPO, SA_ARTI, SA_REGL, SA_COLO, SA_CLA1, SA_CLA2, SA_CLA3, SA_CLA4, SA_CLA5, SA_CLA6, SA_CLA7, SA_ALMA, SA_TANE, SA_CONS, SA_SA01, SA_SA02, SA_SA03, SA_SA04, SA_SA05, SA_SA06, SA_SA07, SA_SA08, SA_SA09, SA_SA10, SA_SA11, SA_SA12, SA_ACUSEM1, SA_ACUSEM2) ";
                                    sql_ins_fstka += "VALUES ('" + dat_ant_fstka.Rows[0]["SA_TIPO"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_ARTI"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_REGL"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_COLO"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_CLA1"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_CLA2"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_CLA3"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_CLA4"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_CLA5"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_CLA6"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_CLA7"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_ALMA"].ToString() + "',";
                                    sql_ins_fstka += "'" + dat_ant_fstka.Rows[0]["SA_TANE"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_CONS"].ToString() + "', " + (Convert.ToInt32(dat_ant_fstka.Rows[0]["SA_SA12"]) - Convert.ToInt32(row["Cantidad"])).ToString() + ", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, " + row["Cantidad"].ToString() + ", 0)";
                                    System.Data.OleDb.OleDbCommand com_ins_fstka = new System.Data.OleDb.OleDbCommand(sql_ins_fstka, dbConn);
                                    com_ins_fstka.ExecuteNonQuery();
                                }

                                /**************************************/
                                /*****************FSTKG****************/
                                /**************************************/
                                string sql_val_fstkg = "SELECT * FROM " + tab_fstkg + " WHERE SG_TIPO='" + tipo_prod + "' AND SG_ARTI='" + row["Articulo"].ToString() + "1' And SG_REGL='00' AND  SG_COLO=''";
                                tabla_error = tab_fstkg;
                                System.Data.OleDb.OleDbCommand com_val_fstkg = new System.Data.OleDb.OleDbCommand(sql_val_fstkg, dbConn);
                                System.Data.OleDb.OleDbDataAdapter ada_val_fstkg = new System.Data.OleDb.OleDbDataAdapter(com_val_fstkg);
                                DataTable dat_val_fstkg = new DataTable();
                                ada_val_fstkg.Fill(dat_val_fstkg);
                                tabla_error = tab_fstkg;

                                if (dat_val_fstkg.Rows.Count > 0)
                                {// Si encuentra registros (Actualiza)
                                    string sql_act_fstkg = "UPDATE " + tab_fstkg + " SET SG_SA" + mes + "=SG_SA" + mes + "-" + row["Cantidad"] + ", SG_ACUSEM" + sem + "=SG_ACUSEM" + sem + "+" + row["Cantidad"].ToString() + " WHERE SG_TIPO='" + tipo_prod + "' AND SG_ARTI='" + row["Articulo"].ToString() + "1' And SG_REGL='00' AND  SG_COLO=''";
                                    System.Data.OleDb.OleDbCommand com_act_fstkg = new System.Data.OleDb.OleDbCommand(sql_act_fstkg, dbConn);
                                    com_act_fstkg.ExecuteNonQuery();
                                }
                                else
                                {// Si no lo encuentra en la tabla (crea un nuevo registro a partir del año anterior)
                                 // Tener en cuenta que esto solo sucede en Enero
                                    string ano_ant = "";
                                    if (ano == "0") { ano_ant = "9"; } else { ano_ant = (Convert.ToInt32(ano) - 1).ToString(); }
                                    string tab_fstkg_ant = "FSTKG" + ano_ant + empresa;
                                    //Obtengo datos anteriores
                                    string sql_ant_fstkg = "SELECT * FROM " + tab_fstkg_ant + " WHERE SG_TIPO='" + tipo_prod + "' AND SG_ARTI='" + row["Articulo"].ToString() + "1' And SG_REGL='00' AND  SG_COLO=''";
                                    tabla_error = tab_fstkg_ant;
                                    System.Data.OleDb.OleDbCommand com_ant_fstkg = new System.Data.OleDb.OleDbCommand(sql_ant_fstkg, dbConn);
                                    System.Data.OleDb.OleDbDataAdapter ada_ant_fstkg = new System.Data.OleDb.OleDbDataAdapter(com_ant_fstkg);
                                    DataTable dat_ant_fstkg = new DataTable();
                                    ada_ant_fstkg.Fill(dat_ant_fstkg);

                                    //grabo nueva linea
                                    string sql_ins_fstkg = "INSERT INTO " + tab_fstkg + " (SG_TIPO, SG_ARTI, SG_REGL, SG_COLO, SG_CLA1, SG_CLA2, SG_CLA3, SG_CLA4, SG_CLA5, SG_CLA6, SG_CLA7, SG_SA01, SG_SA02, SG_SA03, SG_SA04, SG_SA05, SG_SA06, SG_SA07, SG_SA08, SG_SA09, SG_SA10, SG_SA11, SG_SA12, SG_CS01, SG_CS02, SG_CS03, SG_CS04, SG_CS05, SG_CS06, SG_CS07, SG_CS08, SG_CS09, SG_CS10, SG_CS11, SG_CS12, SG_CD01, SG_CD02, SG_CD03, SG_CD04, SG_CD05, SG_CD06, SG_CD07, SG_CD08, SG_CD09, SG_CD10, SG_CD11, SG_CD12, SG_CRES, SG_CRED, SG_ACUSEM1, SG_ACUSEM2, SG_FCRE, SG_USER, SG_ISTK, SG_MMES, SG_MANO) ";
                                    sql_ins_fstkg += "VALUES ('" + dat_ant_fstkg.Rows[0]["SG_TIPO"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_ARTI"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_REGL"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_COLO"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_CLA1"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_CLA2"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_CLA3"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_CLA4"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_CLA5"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_CLA6"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_CLA7"].ToString() + "', ";
                                    sql_ins_fstkg += "" + (Convert.ToInt32(dat_ant_fstkg.Rows[0]["SG_SA12"]) - Convert.ToInt32(row["Cantidad"])).ToString() + ", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,    0, 0, " + row["Cantidad"].ToString() + ", 0, CTOD('" + fecha + "'), '" + dat_ant_fstkg.Rows[0]["SG_USER"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_ISTK"].ToString() + "', '" + mes + "', '" + ano_comp + "')";
                                    System.Data.OleDb.OleDbCommand com_ins_fstkg = new System.Data.OleDb.OleDbCommand(sql_ins_fstkg, dbConn);
                                    com_ins_fstkg.ExecuteNonQuery();
                                }
                                int stock_ini;
                                /**************************************/
                                /*****************FRESUM***************/
                                /**************************************/
                                // consulto si existe
                                string sql_val_fresum = "SELECT * FROM " + tab_fresum + " WHERE R_SALM='" + cod_almacen.Substring(0, 3) + "' AND R_YEAR='" + ano_comp + "' AND R_SEMA = '" + semana + "' AND R_ARTI = '" + row["Articulo"].ToString() + "1' AND R_REGL='00' AND  R_COLO=''";
                                tabla_error = tab_fresum;
                                System.Data.OleDb.OleDbCommand com_val_fresum = new System.Data.OleDb.OleDbCommand(sql_val_fresum, dbConn);
                                System.Data.OleDb.OleDbDataAdapter ada_val_fresum = new System.Data.OleDb.OleDbDataAdapter(com_val_fresum);
                                DataTable dat_val_fresum = new DataTable();
                                ada_val_fresum.Fill(dat_val_fresum);

                                if (dat_val_fresum.Rows.Count > 0)
                                {// Si encuentro datos, los actualizo
                                    string sql_upd_fresum = "UPDATE " + tab_fresum + " SET R_STOK = R_STOK-" + row["Cantidad"].ToString() + ", R_VTAU = R_VTAU+" + row["Cantidad"].ToString() + ", R_VTAS = R_VTAS+" + row["Monto"].ToString() + " WHERE R_SALM='" + cod_almacen.Substring(0, 3) + "' AND R_YEAR='" + ano_comp + "' AND R_SEMA = '" + semana + "' AND R_ARTI = '" + row["Articulo"].ToString() + "1' AND R_REGL='00' AND  R_COLO=''";
                                    System.Data.OleDb.OleDbCommand com_upd_fresum = new System.Data.OleDb.OleDbCommand(sql_upd_fresum, dbConn);
                                    com_upd_fresum.ExecuteNonQuery();

                                    //guardar stock inicial
                                    stock_ini = Convert.ToInt32(dat_val_fresum.Rows[0]["R_STOK"]);
                                }
                                else
                                {// Si no lo encuentro en la tabla genero nuevo registro
                                 //Buscar los datos de la semana anterior para poder registrar nueva semana
                                 //Semana Anterior
                                    string sql_datos_peri_ant = "SELECT *  FROM " + tab_ftperi + " WHERE P_YEAR = '" + ano_comp + "' AND P_FINI <= CTOD('" + fecha + "')-7 AND P_FFIN >= CTOD('" + fecha + "')-7";
                                    tabla_error = tab_ftperi;
                                    System.Data.OleDb.OleDbCommand com_dat_peri_ant = new System.Data.OleDb.OleDbCommand(sql_datos_peri_ant, dbConn);
                                    System.Data.OleDb.OleDbDataAdapter ada_dat_peri_ant = new System.Data.OleDb.OleDbDataAdapter(com_dat_peri_ant);
                                    DataTable dat_peri_ant = new DataTable();
                                    ada_dat_peri_ant.Fill(dat_peri_ant);

                                    // Datos registrados en Semana Anterior
                                    string sql_val_fresum_ant = "SELECT * FROM " + tab_fresum + " WHERE R_SALM='" + cod_almacen.Substring(0, 3) + "' AND R_YEAR='" + ano_comp + "' AND R_SEMA = '" + dat_peri_ant.Rows[0]["P_PERI"].ToString().Trim() + "' AND R_ARTI = '" + row["Articulo"].ToString() + "1' AND R_REGL='00' AND  R_COLO=''";
                                    tabla_error = tab_fresum;
                                    System.Data.OleDb.OleDbCommand com_val_fresum_ant = new System.Data.OleDb.OleDbCommand(sql_val_fresum_ant, dbConn);
                                    System.Data.OleDb.OleDbDataAdapter ada_val_fresum_ant = new System.Data.OleDb.OleDbDataAdapter(com_val_fresum_ant);
                                    DataTable dat_val_fresum_ant = new DataTable();
                                    ada_val_fresum_ant.Fill(dat_val_fresum_ant);

                                    //grabo nueva linea
                                    string sql_ins_resum = "INSERT INTO " + tab_fresum + " (R_SALM, R_YEAR, R_SEMA, R_ARTI, R_REGL, R_COLO, R_STOK, R_VTAU, R_VTAS, R_PREC) ";
                                    sql_ins_resum += "VALUES ('" + cod_almacen.Substring(0, 3) + "', '" + ano_comp + "', '" + semana + "', '" + row["Articulo"].ToString() + "1', '00', '', " + dat_val_fresum_ant.Rows[0]["R_STOK"].ToString().Trim() + "-" + row["Cantidad"].ToString() + ", " + row["Cantidad"].ToString() + ", " + row["Monto"].ToString() + ", " + dat_val_fresum_ant.Rows[0]["R_PREC"].ToString().Trim() + ")";
                                    System.Data.OleDb.OleDbCommand com_ins_resum = new System.Data.OleDb.OleDbCommand(sql_ins_resum, dbConn);
                                    com_ins_resum.ExecuteNonQuery();

                                    //guardar stock inicial
                                    stock_ini = Convert.ToInt32(dat_val_fresum_ant.Rows[0]["R_STOK"]);
                                }

                                //Obtener datos para ingresar los Movimientos
                                string sql_dat_mov = "SELECT * FROM " + tab_fpdocu + " WHERE D_CODI = '" + tp_doc + "'";
                                tabla_error = tab_fpdocu;
                                System.Data.OleDb.OleDbCommand com_dat_mov = new System.Data.OleDb.OleDbCommand(sql_dat_mov, dbConn);
                                System.Data.OleDb.OleDbDataAdapter ada_dat_mov = new System.Data.OleDb.OleDbDataAdapter(com_dat_mov);
                                DataTable dat_dat_mov = new DataTable();
                                ada_dat_mov.Fill(dat_dat_mov);

                                /**************************************/
                                /*****************FMC******************/
                                /**************************************/
                                //grabo nueva linea
                                string sql_ins_fmc = "INSERT INTO " + tab_fmc + " (V_TFOR, V_PROC, V_CFOR, V_SFOR, V_NFOR, V_FFOR, V_MONE, V_TASA, V_ALMO, V_ALMD, V_TANE, V_ANEX, V_TDOC, V_SUNA, V_SDOC, V_NDOC, V_FDOC, V_TREF, V_SREF, V_NREF, V_TIPO, V_ARTI, V_REGL, V_COLO, V_CANT, V_PRES, V_PRED, V_VVTS, V_VVTD, V_AUTO, V_PTOT, V_IMPR, V_CUSE, V_MUSE, V_FCRE, V_FMOD, V_FTRX, V_MEMO, V_CTRA, V_MOTR, V_PAR1, V_PAR2, V_PAR3, V_LLE1, V_LLE2, V_LLE3, V_TIPE, V_RUC2, V_RZO2, V_HSTD) ";
                                sql_ins_fmc += "VALUES ('" + dat_dat_mov.Rows[0]["D_TIPO"].ToString() + "', '2', '" + tp_doc + "', '" + serie + "', '" + numero + "', CTOD('" + fecha + "'), '01', 1, '" + cod_almacen + "', '" + dat_dat_mov.Rows[0]["D_ALMD"].ToString() + "', '', '','" + tp_doc + "','" + dat_dat_mov.Rows[0]["D_SUNA"].ToString() + "', '" + serie + "', '" + numero + "', CTOD('" + fecha + "'), '', '', '', '', '', '','', " + row["Cantidad"].ToString() + ", 0, 0, 0, 0, '', " + (Convert.ToDecimal(row["Monto"]) * Convert.ToInt32(row["Cantidad"])).ToString() + ", '2', 'VEN', 'VEN', CTOD('" + fecha + "'), CTOD('" + fecha + "'), CTOD('  /  /    '), '', '', '', '', '', '', '', '', '', '', '', '', '') ";
                                System.Data.OleDb.OleDbCommand com_ins_fmc = new System.Data.OleDb.OleDbCommand(sql_ins_fmc, dbConn);
                                com_ins_fmc.ExecuteNonQuery();

                                /**************************************/
                                /*****************FMD******************/
                                /**************************************/
                                //grabo nueva linea
                                string sql_ins_fmd = "INSERT INTO " + tab_fmd + " (I_TFOR, I_PROC, I_CFOR, I_SFOR, I_NFOR, I_TIPO, I_ARTI, I_REGL, I_COLO, I_ITEM, I_UNIC, I_EQU1, I_UNIM, I_CANC, I_CANM, I_PRES, I_PRED, I_VVTS, I_VVTD, I_PLIS, I_PTOT, I_IMPR, I_CUSE, I_MUSE, I_FCRE, I_FMOD, I_FALL, I_SOLU, I_UMOD, I_FECM, I_HMOD) ";
                                sql_ins_fmd += "VALUES ('" + dat_dat_mov.Rows[0]["D_TIPO"].ToString() + "', '2', '" + tp_doc + "', '" + serie + "', '" + numero + "', 'A', '" + row["Articulo"].ToString() + "1', '00', '', '" + contador.ToString().PadLeft(3).Replace(" ", "0") + "', '', " + row["Cantidad"].ToString() + ", '', 0, " + row["Cantidad"].ToString() + ", 0, " + row["Monto"].ToString() + ", 0, 0, " + row["Cantidad"].ToString() + ", 0, '1', 'VEN', 'VEN', CTOD('" + fecha + "'), CTOD('" + fecha + "'), '', '', '', CTOD('  /  /    '), '')";
                                System.Data.OleDb.OleDbCommand com_ins_fmd = new System.Data.OleDb.OleDbCommand(sql_ins_fmd, dbConn);
                                com_ins_fmd.ExecuteNonQuery();

                                /**************************************/
                                /*****************FMK******************/
                                /**************************************/
                                //grabo nueva linea
                                string sql_ins_fmk = "INSERT INTO " + tab_fmk + " (J_TFOR, J_CFOR, J_SUNA, J_SFOR, J_NFOR, J_FFOR, J_ALMA, J_ALMR, J_TANE, J_ANEX, J_TDOC, J_SDOC, J_NDOC, J_TREF, J_SREF, J_NREF, J_TIPO, J_ARTI, J_REGL, J_COLO, J_ITEM, J_ENSA, J_CANT, J_COSS, J_COSD, J_STKI, J_STKF, J_COIS, J_COID, J_COFS, J_COFD, J_PLIS, J_IMPR) ";
                                sql_ins_fmk += "VALUES ('" + dat_dat_mov.Rows[0]["D_TIPO"].ToString() + "', '" + tp_doc + "','" + dat_dat_mov.Rows[0]["D_SUNA"].ToString() + "', '" + serie + "', '" + numero + "', CTOD('" + fecha + "'), '" + cod_almacen + "', '" + dat_dat_mov.Rows[0]["D_ALMD"].ToString() + "', '', '', '" + tp_doc + "', '" + serie + "', '" + numero + "', '', '', '', 'A', '" + row["Articulo"].ToString() + "1', '00', '', '" + contador.ToString().PadLeft(3).Replace(" ", "0") + "', '2', " + row["Cantidad"].ToString() + ", 0, 0, " + stock_ini + ", " + stock_ini + "-" + row["Cantidad"].ToString() + ", 0, 0, 0, 0, " + row["Monto"].ToString() + ", '2')";
                                System.Data.OleDb.OleDbCommand com_ins_fmk = new System.Data.OleDb.OleDbCommand(sql_ins_fmk, dbConn);
                                com_ins_fmk.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            msaje_error = "Estado del día ya se encuentra cerrado";
                            throw new System.ArgumentException("Estado del día ya se encuentra cerrado", "FCIERR");
                        }
                    }
                    else
                    {
                        msaje_error = "El día de hoy aún no se aperturó";
                        throw new System.ArgumentException("El día de hoy aún no se aperturó", "FCIERR");
                    }

                    dbConn.Close();
                }
                catch (Exception ex)
                {
                    if (msaje_error == "")
                    { msaje_error = "El artículo seleccionado no se encuentra en las tablas de Stock."; }
                    dbConn.Close();
                    throw new System.ArgumentException(msaje_error, tabla_error);
                    //throw ex;
                }
            }
        }



        public static string Grabar_Ticket(string empresa, string tp_doc, string serie, string fecha, string dni, string nombres, string apepat, string apemat, string forpag, string tarjeta, string nro_tarj, DataTable detalle)
        {
            string sConn = "Provider = vfpoledb.1;Data Source=" + System.IO.Path.GetDirectoryName(_path_dbf) + ";Collating Sequence=general";

            string codigo = "";
            string numero = "";
            string detail = "";
            string tabla_error = "";
            string msaje_error = "";

            string cod_almacen = "";
            string tipo_prod = "";
            string sucursal = "";
            string semana = "";

            //-- Control de RollBack
            bool fstka = false;
            bool fstkg = false;
            bool fresum = false;
            bool fstka_cr = false;
            bool fstkg_cr = false;
            bool fresum_cr = false;
            bool fmc = false;
            bool fmd = false;
            bool fmk = false;
            bool tkactivc = false;
            bool tkactivd = false;

            string[] detalle_rb = new string[3];
            List<string[]> fstka_det_rb = new List<string[]>();
            List<string[]> fstkg_det_rb = new List<string[]>();
            List<string[]> fresum_det_rb = new List<string[]>();
            List<string[]> fstka_cr_det_rb = new List<string[]>();
            List<string[]> fstkg_cr_det_rb = new List<string[]>();
            List<string[]> fresum_cr_det_rb = new List<string[]>();
            List<string[]> fmc_det_rb = new List<string[]>();
            List<string[]> fmd_det_rb = new List<string[]>();
            List<string[]> fmk_det_rb = new List<string[]>();

            string fecha_sql = fecha.Substring(6, 4) + fecha.Substring(0, 2) + fecha.Substring(3, 2);

            //-- Obtenemos los datos para completar los nombres de tablas
            string mes = fecha.Substring(0, 2);
            string ano = fecha.Substring(9, 1);
            string ano_comp = fecha.Substring(6, 4);
            string sem = (Convert.ToInt32(mes) < 7) ? "1" : "2";
            string tab_fpctrl = "FPCTRL" + empresa;     // Leer
            string tab_fpdocu = "FPDOCU" + empresa;     // Leer
            string tab_fcierr = "FCIERR" + empresa;     // Leer
            string tab_ftperi = "FTPERI" + empresa;     // Leer
            string tab_fstka = "FSTKA" + ano + empresa;     // Actualizar
            string tab_fstkg = "FSTKG" + ano + empresa;     // Actualizar
            string tab_fmc = "FMC" + mes + ano + empresa;   // Agregar
            string tab_fmd = "FMD" + mes + ano + empresa;   // Agregar
            string tab_fmk = "FMK" + mes + ano + empresa;   // Agregar
            string tab_fresum = "FRESUM" + empresa;         // Actualizar

            using (System.Data.OleDb.OleDbConnection dbConn = new System.Data.OleDb.OleDbConnection(sConn))
            {
                try
                {
                    dbConn.Open();
                    
                    int contador = 0;

                    //-- Obtenemos datos de Control (Parametros Generales)
                    string sql_datos_gral = "SELECT * FROM " + tab_fpctrl + " ";
                    tabla_error = tab_fpctrl;
                    System.Data.OleDb.OleDbCommand dat_grales = new System.Data.OleDb.OleDbCommand(sql_datos_gral, dbConn);
                    System.Data.OleDb.OleDbDataAdapter dat_gral = new System.Data.OleDb.OleDbDataAdapter(dat_grales);
                    DataTable datos_gral = new DataTable();
                    dat_gral.Fill(datos_gral);

                    //-- Obtenemos datos de semana activa
                    string sql_datos_peri = "SELECT * FROM " + tab_ftperi + " WHERE P_YEAR = '" + ano_comp + "' AND P_FINI <= CTOD('" + fecha + "') AND P_FFIN >= CTOD('" + fecha + "')";
                    tabla_error = tab_ftperi;
                    System.Data.OleDb.OleDbCommand com_dat_peri = new System.Data.OleDb.OleDbCommand(sql_datos_peri, dbConn);
                    System.Data.OleDb.OleDbDataAdapter ada_dat_peri = new System.Data.OleDb.OleDbDataAdapter(com_dat_peri);
                    DataTable dat_peri = new DataTable();
                    ada_dat_peri.Fill(dat_peri);

                    // Llenamos los datos
                    cod_almacen = datos_gral.Rows[0]["C_CALM"].ToString().Trim();
                    sucursal = datos_gral.Rows[0]["C_SUCU"].ToString().Trim();
                    tipo_prod = "A";
                    semana = dat_peri.Rows[0]["P_PERI"].ToString().Trim();

                    //Valida estado de cierre
                    string sql_val_fcierr = "SELECT * FROM " + tab_fcierr + " WHERE CI_CSUC='" + sucursal + "' AND CI_FECH=CTOD('" + fecha + "')";
                    tabla_error = tab_fcierr;
                    System.Data.OleDb.OleDbCommand com_val_fcierr = new System.Data.OleDb.OleDbCommand(sql_val_fcierr, dbConn);
                    System.Data.OleDb.OleDbDataAdapter ada_val_fcierr = new System.Data.OleDb.OleDbDataAdapter(com_val_fcierr);
                    DataTable dat_val_fcierr = new DataTable();
                    ada_val_fcierr.Fill(dat_val_fcierr);

                    if (dat_val_fcierr.Rows.Count > 0)
                    {
                        if (dat_val_fcierr.Rows[0]["CI_ESTA"].ToString().Trim() != "C")
                        {
                            //-- Datos generales para Ticket de Activación
                            sucursal = datos_gral.Rows[0]["C_SUCU"].ToString().Trim();
                            if (sucursal.Length < 5)
                            {
                                sucursal = "50" + sucursal;
                            }

                            string consulta = "SELECT MAX(NUMERO) As NUMERO FROM TKACTIVC WHERE Serie = '" + serie + "'";
                            System.Data.OleDb.OleDbCommand con = new System.Data.OleDb.OleDbCommand(consulta, dbConn);
                            System.Data.OleDb.OleDbDataAdapter cona = new System.Data.OleDb.OleDbDataAdapter(con);
                            DataTable dt = new DataTable();
                            cona.Fill(dt);

                            if (dt.Rows.Count > 0 && dt.Rows[0]["NUMERO"].ToString() != "")
                            {
                                foreach (DataRow r in dt.Rows)
                                {
                                    codigo = (Convert.ToInt32(r["NUMERO"]) + 1).ToString().Trim().PadLeft(8).Replace(" ", "0");
                                }
                            }
                            else
                            {
                                codigo = "1".PadLeft(8).Replace(" ", "0");
                            }
                            numero = codigo;

                            // Empezamos a realizar las modificaciones de Stock por registro
                            foreach (DataRow row in detalle.Rows)
                            {
                                // Conteo de Items
                                contador = contador + 1;
                                
                                /**************************************/
                                /*****************FSTKA****************/
                                /**************************************/
                                string sql_val_fstka = "SELECT * FROM " + tab_fstka + " WHERE SA_ALMA='" + cod_almacen + "' AND SA_TANE='' AND SA_CONS='' AND SA_TIPO='" + tipo_prod + "' AND SA_ARTI='" + row["Articulo"].ToString() + "1' And SA_REGL='00' AND  SA_COLO=''";
                                tabla_error = tab_fstka;
                                System.Data.OleDb.OleDbCommand com_val_fstka = new System.Data.OleDb.OleDbCommand(sql_val_fstka, dbConn);
                                System.Data.OleDb.OleDbDataAdapter ada_val_fstka = new System.Data.OleDb.OleDbDataAdapter(com_val_fstka);
                                DataTable dat_val_fstka = new DataTable();
                                ada_val_fstka.Fill(dat_val_fstka);

                                detalle_rb[0] = row["Articulo"].ToString();
                                detalle_rb[1] = row["Cantidad"].ToString();
                                detalle_rb[2] = row["Monto"].ToString();

                                if (dat_val_fstka.Rows.Count > 0)
                                {// Si encuentra registros (Actualiza)
                                    string sql_act_fstka = "UPDATE " + tab_fstka + " SET SA_SA" + mes + "=SA_SA" + mes + "-" + row["Cantidad"].ToString() + ", SA_ACUSEM" + sem + "=SA_ACUSEM" + sem + "+" + row["Cantidad"].ToString() + " WHERE SA_ALMA='" + cod_almacen + "' AND SA_TANE='' AND SA_CONS='' AND SA_TIPO='" + tipo_prod + "' AND SA_ARTI='" + row["Articulo"].ToString() + "1' And SA_REGL='00' AND  SA_COLO=''";
                                    System.Data.OleDb.OleDbCommand com_act_fstka = new System.Data.OleDb.OleDbCommand(sql_act_fstka, dbConn);
                                    com_act_fstka.ExecuteNonQuery();
                                    fstka = true;
                                    fstka_det_rb.Add(detalle_rb);
                                }
                                else
                                {// Si no lo encuentra en la tabla (crea un nuevo registro a partir del año anterior)
                                 // Tener en cuenta que esto solo sucede en Enero
                                    string ano_ant = "";
                                    if (ano == "0") { ano_ant = "9"; } else { ano_ant = (Convert.ToInt32(ano) - 1).ToString(); }
                                    string tab_fstka_ant = "FSTKA" + ano_ant + empresa;
                                    //Obtengo datos anteriores
                                    string sql_ant_fstka = "SELECT * FROM " + tab_fstka_ant + " WHERE SA_ALMA='" + cod_almacen + "' AND SA_TANE='' AND SA_CONS='' AND SA_TIPO='" + tipo_prod + "' AND SA_ARTI='" + row["Articulo"].ToString() + "1' And SA_REGL='00' AND  SA_COLO=''";
                                    tabla_error = tab_fstka_ant;
                                    System.Data.OleDb.OleDbCommand com_ant_fstka = new System.Data.OleDb.OleDbCommand(sql_ant_fstka, dbConn);
                                    System.Data.OleDb.OleDbDataAdapter ada_ant_fstka = new System.Data.OleDb.OleDbDataAdapter(com_ant_fstka);
                                    DataTable dat_ant_fstka = new DataTable();
                                    ada_ant_fstka.Fill(dat_ant_fstka);

                                    //grabo nueva linea
                                    string sql_ins_fstka = "INSERT INTO " + tab_fstka + " (SA_TIPO, SA_ARTI, SA_REGL, SA_COLO, SA_CLA1, SA_CLA2, SA_CLA3, SA_CLA4, SA_CLA5, SA_CLA6, SA_CLA7, SA_ALMA, SA_TANE, SA_CONS, SA_SA01, SA_SA02, SA_SA03, SA_SA04, SA_SA05, SA_SA06, SA_SA07, SA_SA08, SA_SA09, SA_SA10, SA_SA11, SA_SA12, SA_ACUSEM1, SA_ACUSEM2) ";
                                    sql_ins_fstka += "VALUES ('" + dat_ant_fstka.Rows[0]["SA_TIPO"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_ARTI"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_REGL"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_COLO"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_CLA1"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_CLA2"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_CLA3"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_CLA4"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_CLA5"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_CLA6"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_CLA7"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_ALMA"].ToString() + "',";
                                    sql_ins_fstka += "'" + dat_ant_fstka.Rows[0]["SA_TANE"].ToString() + "', '" + dat_ant_fstka.Rows[0]["SA_CONS"].ToString() + "', " + (Convert.ToInt32(dat_ant_fstka.Rows[0]["SA_SA12"]) - Convert.ToInt32(row["Cantidad"])).ToString() + ", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, " + row["Cantidad"].ToString() + ", 0)";
                                    System.Data.OleDb.OleDbCommand com_ins_fstka = new System.Data.OleDb.OleDbCommand(sql_ins_fstka, dbConn);
                                    com_ins_fstka.ExecuteNonQuery();
                                    fstka_cr = true;
                                    fstka_cr_det_rb.Add(detalle_rb);
                                }

                                /**************************************/
                                /*****************FSTKG****************/
                                /**************************************/
                                string sql_val_fstkg = "SELECT * FROM " + tab_fstkg + " WHERE SG_TIPO='" + tipo_prod + "' AND SG_ARTI='" + row["Articulo"].ToString() + "1' And SG_REGL='00' AND  SG_COLO=''";
                                tabla_error = tab_fstkg;
                                System.Data.OleDb.OleDbCommand com_val_fstkg = new System.Data.OleDb.OleDbCommand(sql_val_fstkg, dbConn);
                                System.Data.OleDb.OleDbDataAdapter ada_val_fstkg = new System.Data.OleDb.OleDbDataAdapter(com_val_fstkg);
                                DataTable dat_val_fstkg = new DataTable();
                                ada_val_fstkg.Fill(dat_val_fstkg);
                                tabla_error = tab_fstkg;

                                if (dat_val_fstkg.Rows.Count > 0)
                                {// Si encuentra registros (Actualiza)
                                    string sql_act_fstkg = "UPDATE " + tab_fstkg + " SET SG_SA" + mes + "=SG_SA" + mes + "-" + row["Cantidad"] + ", SG_ACUSEM" + sem + "=SG_ACUSEM" + sem + "+" + row["Cantidad"].ToString() + " WHERE SG_TIPO='" + tipo_prod + "' AND SG_ARTI='" + row["Articulo"].ToString() + "1' And SG_REGL='00' AND  SG_COLO=''";
                                    System.Data.OleDb.OleDbCommand com_act_fstkg = new System.Data.OleDb.OleDbCommand(sql_act_fstkg, dbConn);
                                    com_act_fstkg.ExecuteNonQuery();
                                    fstkg = true;
                                    fstkg_det_rb.Add(detalle_rb);
                                }
                                else
                                {// Si no lo encuentra en la tabla (crea un nuevo registro a partir del año anterior)
                                 // Tener en cuenta que esto solo sucede en Enero
                                    string ano_ant = "";
                                    if (ano == "0") { ano_ant = "9"; } else { ano_ant = (Convert.ToInt32(ano) - 1).ToString(); }
                                    string tab_fstkg_ant = "FSTKG" + ano_ant + empresa;
                                    //Obtengo datos anteriores
                                    string sql_ant_fstkg = "SELECT * FROM " + tab_fstkg_ant + " WHERE SG_TIPO='" + tipo_prod + "' AND SG_ARTI='" + row["Articulo"].ToString() + "1' And SG_REGL='00' AND  SG_COLO=''";
                                    tabla_error = tab_fstkg_ant;
                                    System.Data.OleDb.OleDbCommand com_ant_fstkg = new System.Data.OleDb.OleDbCommand(sql_ant_fstkg, dbConn);
                                    System.Data.OleDb.OleDbDataAdapter ada_ant_fstkg = new System.Data.OleDb.OleDbDataAdapter(com_ant_fstkg);
                                    DataTable dat_ant_fstkg = new DataTable();
                                    ada_ant_fstkg.Fill(dat_ant_fstkg);

                                    //grabo nueva linea
                                    string sql_ins_fstkg = "INSERT INTO " + tab_fstkg + " (SG_TIPO, SG_ARTI, SG_REGL, SG_COLO, SG_CLA1, SG_CLA2, SG_CLA3, SG_CLA4, SG_CLA5, SG_CLA6, SG_CLA7, SG_SA01, SG_SA02, SG_SA03, SG_SA04, SG_SA05, SG_SA06, SG_SA07, SG_SA08, SG_SA09, SG_SA10, SG_SA11, SG_SA12, SG_CS01, SG_CS02, SG_CS03, SG_CS04, SG_CS05, SG_CS06, SG_CS07, SG_CS08, SG_CS09, SG_CS10, SG_CS11, SG_CS12, SG_CD01, SG_CD02, SG_CD03, SG_CD04, SG_CD05, SG_CD06, SG_CD07, SG_CD08, SG_CD09, SG_CD10, SG_CD11, SG_CD12, SG_CRES, SG_CRED, SG_ACUSEM1, SG_ACUSEM2, SG_FCRE, SG_USER, SG_ISTK, SG_MMES, SG_MANO) ";
                                    sql_ins_fstkg += "VALUES ('" + dat_ant_fstkg.Rows[0]["SG_TIPO"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_ARTI"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_REGL"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_COLO"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_CLA1"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_CLA2"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_CLA3"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_CLA4"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_CLA5"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_CLA6"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_CLA7"].ToString() + "', ";
                                    sql_ins_fstkg += "" + (Convert.ToInt32(dat_ant_fstkg.Rows[0]["SG_SA12"]) - Convert.ToInt32(row["Cantidad"])).ToString() + ", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,    0, 0, " + row["Cantidad"].ToString() + ", 0, CTOD('" + fecha + "'), '" + dat_ant_fstkg.Rows[0]["SG_USER"].ToString() + "', '" + dat_ant_fstkg.Rows[0]["SG_ISTK"].ToString() + "', '" + mes + "', '" + ano_comp + "')";
                                    System.Data.OleDb.OleDbCommand com_ins_fstkg = new System.Data.OleDb.OleDbCommand(sql_ins_fstkg, dbConn);
                                    com_ins_fstkg.ExecuteNonQuery();
                                    fstkg_cr = true;
                                    fstkg_cr_det_rb.Add(detalle_rb);
                                }

                                int stock_ini;
                                /**************************************/
                                /*****************FRESUM***************/
                                /**************************************/
                                // consulto si existe
                                string sql_val_fresum = "SELECT * FROM " + tab_fresum + " WHERE R_SALM='" + cod_almacen.Substring(0, 3) + "' AND R_YEAR='" + ano_comp + "' AND R_SEMA = '" + semana + "' AND R_ARTI = '" + row["Articulo"].ToString() + "1' AND R_REGL='00' AND  R_COLO=''";
                                tabla_error = tab_fresum;
                                System.Data.OleDb.OleDbCommand com_val_fresum = new System.Data.OleDb.OleDbCommand(sql_val_fresum, dbConn);
                                System.Data.OleDb.OleDbDataAdapter ada_val_fresum = new System.Data.OleDb.OleDbDataAdapter(com_val_fresum);
                                DataTable dat_val_fresum = new DataTable();
                                ada_val_fresum.Fill(dat_val_fresum);

                                if (dat_val_fresum.Rows.Count > 0)
                                {// Si encuentro datos, los actualizo
                                    string sql_upd_fresum = "UPDATE " + tab_fresum + " SET R_STOK = R_STOK-" + row["Cantidad"].ToString() + ", R_VTAU = R_VTAU+" + row["Cantidad"].ToString() + ", R_VTAS = R_VTAS+" + row["Monto"].ToString() + " WHERE R_SALM='" + cod_almacen.Substring(0, 3) + "' AND R_YEAR='" + ano_comp + "' AND R_SEMA = '" + semana + "' AND R_ARTI = '" + row["Articulo"].ToString() + "1' AND R_REGL='00' AND  R_COLO=''";
                                    System.Data.OleDb.OleDbCommand com_upd_fresum = new System.Data.OleDb.OleDbCommand(sql_upd_fresum, dbConn);
                                    com_upd_fresum.ExecuteNonQuery();
                                    fresum = true;
                                    fresum_det_rb.Add(detalle_rb);

                                    //guardar stock inicial
                                    stock_ini = Convert.ToInt32(dat_val_fresum.Rows[0]["R_STOK"]);
                                }
                                else
                                {// Si no lo encuentro en la tabla genero nuevo registro
                                 //Buscar los datos de la semana anterior para poder registrar nueva semana
                                 //Semana Anterior
                                    string sql_datos_peri_ant = "SELECT *  FROM " + tab_ftperi + " WHERE P_YEAR = '" + ano_comp + "' AND P_FINI <= CTOD('" + fecha + "')-7 AND P_FFIN >= CTOD('" + fecha + "')-7";
                                    tabla_error = tab_ftperi;
                                    System.Data.OleDb.OleDbCommand com_dat_peri_ant = new System.Data.OleDb.OleDbCommand(sql_datos_peri_ant, dbConn);
                                    System.Data.OleDb.OleDbDataAdapter ada_dat_peri_ant = new System.Data.OleDb.OleDbDataAdapter(com_dat_peri_ant);
                                    DataTable dat_peri_ant = new DataTable();
                                    ada_dat_peri_ant.Fill(dat_peri_ant);

                                    // Datos registrados en Semana Anterior
                                    string sql_val_fresum_ant = "SELECT * FROM " + tab_fresum + " WHERE R_SALM='" + cod_almacen.Substring(0, 3) + "' AND R_YEAR='" + ano_comp + "' AND R_SEMA = '" + dat_peri_ant.Rows[0]["P_PERI"].ToString().Trim() + "' AND R_ARTI = '" + row["Articulo"].ToString() + "1' AND R_REGL='00' AND  R_COLO=''";
                                    tabla_error = tab_fresum;
                                    System.Data.OleDb.OleDbCommand com_val_fresum_ant = new System.Data.OleDb.OleDbCommand(sql_val_fresum_ant, dbConn);
                                    System.Data.OleDb.OleDbDataAdapter ada_val_fresum_ant = new System.Data.OleDb.OleDbDataAdapter(com_val_fresum_ant);
                                    DataTable dat_val_fresum_ant = new DataTable();
                                    ada_val_fresum_ant.Fill(dat_val_fresum_ant);

                                    //grabo nueva linea
                                    string sql_ins_resum = "INSERT INTO " + tab_fresum + " (R_SALM, R_YEAR, R_SEMA, R_ARTI, R_REGL, R_COLO, R_STOK, R_VTAU, R_VTAS, R_PREC) ";
                                    sql_ins_resum += "VALUES ('" + cod_almacen.Substring(0, 3) + "', '" + ano_comp + "', '" + semana + "', '" + row["Articulo"].ToString() + "1', '00', '', " + dat_val_fresum_ant.Rows[0]["R_STOK"].ToString().Trim() + "-" + row["Cantidad"].ToString() + ", " + row["Cantidad"].ToString() + ", " + row["Monto"].ToString() + ", " + dat_val_fresum_ant.Rows[0]["R_PREC"].ToString().Trim() + ")";
                                    System.Data.OleDb.OleDbCommand com_ins_resum = new System.Data.OleDb.OleDbCommand(sql_ins_resum, dbConn);
                                    com_ins_resum.ExecuteNonQuery();
                                    fresum_cr = true;
                                    fresum_cr_det_rb.Add(detalle_rb);

                                    //guardar stock inicial
                                    stock_ini = Convert.ToInt32(dat_val_fresum_ant.Rows[0]["R_STOK"]);
                                }
                                fresum_det_rb.Add(detalle_rb);
                                

                                //Obtener datos para ingresar los Movimientos
                                string sql_dat_mov = "SELECT * FROM " + tab_fpdocu + " WHERE D_CODI = '" + tp_doc + "'";
                                tabla_error = tab_fpdocu;
                                System.Data.OleDb.OleDbCommand com_dat_mov = new System.Data.OleDb.OleDbCommand(sql_dat_mov, dbConn);
                                System.Data.OleDb.OleDbDataAdapter ada_dat_mov = new System.Data.OleDb.OleDbDataAdapter(com_dat_mov);
                                DataTable dat_dat_mov = new DataTable();
                                ada_dat_mov.Fill(dat_dat_mov);

                                /**************************************/
                                /*****************FMC******************/
                                /**************************************/
                                //grabo nueva linea
                                string sql_ins_fmc = "INSERT INTO " + tab_fmc + " (V_TFOR, V_PROC, V_CFOR, V_SFOR, V_NFOR, V_FFOR, V_MONE, V_TASA, V_ALMO, V_ALMD, V_TANE, V_ANEX, V_TDOC, V_SUNA, V_SDOC, V_NDOC, V_FDOC, V_TREF, V_SREF, V_NREF, V_TIPO, V_ARTI, V_REGL, V_COLO, V_CANT, V_PRES, V_PRED, V_VVTS, V_VVTD, V_AUTO, V_PTOT, V_IMPR, V_CUSE, V_MUSE, V_FCRE, V_FMOD, V_FTRX, V_MEMO, V_CTRA, V_MOTR, V_PAR1, V_PAR2, V_PAR3, V_LLE1, V_LLE2, V_LLE3, V_TIPE, V_RUC2, V_RZO2, V_HSTD) ";
                                tabla_error = tab_fmc;
                                sql_ins_fmc += "VALUES ('" + dat_dat_mov.Rows[0]["D_TIPO"].ToString() + "', '2', '" + tp_doc + "', '" + serie + "', '" + numero + "', CTOD('" + fecha + "'), '01', 1, '" + cod_almacen + "', '" + dat_dat_mov.Rows[0]["D_ALMD"].ToString() + "', '', '','" + tp_doc + "','" + dat_dat_mov.Rows[0]["D_SUNA"].ToString() + "', '" + serie + "', '" + numero + "', CTOD('" + fecha + "'), '', '', '', '', '', '','', " + row["Cantidad"].ToString() + ", 0, 0, 0, 0, '', " + (Convert.ToDecimal(row["Monto"]) * Convert.ToInt32(row["Cantidad"])).ToString() + ", '2', 'VEN', 'VEN', CTOD('" + fecha + "'), CTOD('" + fecha + "'), CTOD('  /  /    '), '', '', '', '', '', '', '', '', '', '', '', '', '') ";
                                System.Data.OleDb.OleDbCommand com_ins_fmc = new System.Data.OleDb.OleDbCommand(sql_ins_fmc, dbConn);
                                com_ins_fmc.ExecuteNonQuery();
                                fmc = true;
                                detalle_rb[0] = row["Articulo"].ToString();
                                detalle_rb[1] = row["Cantidad"].ToString();
                                detalle_rb[2] = row["Monto"].ToString();
                                fmc_det_rb.Add(detalle_rb);

                                /**************************************/
                                /*****************FMD******************/
                                /**************************************/
                                //grabo nueva linea
                                string sql_ins_fmd = "INSERT INTO " + tab_fmd + " (I_TFOR, I_PROC, I_CFOR, I_SFOR, I_NFOR, I_TIPO, I_ARTI, I_REGL, I_COLO, I_ITEM, I_UNIC, I_EQU1, I_UNIM, I_CANC, I_CANM, I_PRES, I_PRED, I_VVTS, I_VVTD, I_PLIS, I_PTOT, I_IMPR, I_CUSE, I_MUSE, I_FCRE, I_FMOD, I_FALL, I_SOLU, I_UMOD, I_FECM, I_HMOD) ";
                                tabla_error = tab_fmd;
                                sql_ins_fmd += "VALUES ('" + dat_dat_mov.Rows[0]["D_TIPO"].ToString() + "', '2', '" + tp_doc + "', '" + serie + "', '" + numero + "', 'A', '" + row["Articulo"].ToString() + "1', '00', '', '" + contador.ToString().PadLeft(3).Replace(" ", "0") + "', '', " + row["Cantidad"].ToString() + ", '', 0, " + row["Cantidad"].ToString() + ", 0, " + row["Monto"].ToString() + ", 0, 0, " + row["Cantidad"].ToString() + ", 0, '1', 'VEN', 'VEN', CTOD('" + fecha + "'), CTOD('" + fecha + "'), '', '', '', CTOD('  /  /    '), '')";
                                System.Data.OleDb.OleDbCommand com_ins_fmd = new System.Data.OleDb.OleDbCommand(sql_ins_fmd, dbConn);
                                com_ins_fmd.ExecuteNonQuery();
                                fmd = true;
                                detalle_rb[0] = row["Articulo"].ToString();
                                detalle_rb[1] = row["Cantidad"].ToString();
                                detalle_rb[2] = row["Monto"].ToString();
                                fmd_det_rb.Add(detalle_rb);

                                /**************************************/
                                /*****************FMK******************/
                                /**************************************/
                                //grabo nueva linea
                                string sql_ins_fmk = "INSERT INTO " + tab_fmk + " (J_TFOR, J_CFOR, J_SUNA, J_SFOR, J_NFOR, J_FFOR, J_ALMA, J_ALMR, J_TANE, J_ANEX, J_TDOC, J_SDOC, J_NDOC, J_TREF, J_SREF, J_NREF, J_TIPO, J_ARTI, J_REGL, J_COLO, J_ITEM, J_ENSA, J_CANT, J_COSS, J_COSD, J_STKI, J_STKF, J_COIS, J_COID, J_COFS, J_COFD, J_PLIS, J_IMPR) ";
                                tabla_error = tab_fmk;
                                sql_ins_fmk += "VALUES ('" + dat_dat_mov.Rows[0]["D_TIPO"].ToString() + "', '" + tp_doc + "','" + dat_dat_mov.Rows[0]["D_SUNA"].ToString() + "', '" + serie + "', '" + numero + "', CTOD('" + fecha + "'), '" + cod_almacen + "', '" + dat_dat_mov.Rows[0]["D_ALMD"].ToString() + "', '', '', '" + tp_doc + "', '" + serie + "', '" + numero + "', '', '', '', 'A', '" + row["Articulo"].ToString() + "1', '00', '', '" + contador.ToString().PadLeft(3).Replace(" ", "0") + "', '2', " + row["Cantidad"].ToString() + ", 0, 0, " + stock_ini + ", " + stock_ini + "-" + row["Cantidad"].ToString() + ", 0, 0, 0, 0, " + row["Monto"].ToString() + ", '2')";
                                System.Data.OleDb.OleDbCommand com_ins_fmk = new System.Data.OleDb.OleDbCommand(sql_ins_fmk, dbConn);
                                com_ins_fmk.ExecuteNonQuery();
                                fmk = true;
                                detalle_rb[0] = row["Articulo"].ToString();
                                detalle_rb[1] = row["Cantidad"].ToString();
                                detalle_rb[2] = row["Monto"].ToString();
                                fmk_det_rb.Add(detalle_rb);
                            }

                            string inserta = "Insert Into TKACTIVC (SERIE, NUMERO, FECHA, TIDE, DIDE, NOMCLI, APEPAT, APEMAT, FORPAG, TARJET, NROTAR) ";
                            inserta += "VALUES ('" + serie + "', '" + codigo + "', CTOD('" + fecha + "'), '1', '" + dni + "', '" + nombres + "', '" + apepat + "', '" + apemat + "', '" + forpag + "', '" + tarjeta + "', '" + nro_tarj + "')";
                            System.Data.OleDb.OleDbCommand mov_cab = new System.Data.OleDb.OleDbCommand(inserta, dbConn);
                            mov_cab.ExecuteNonQuery();
                            tkactivc = true;

                            foreach (DataRow rowt in detalle.Rows)
                            {
                                // Datos para SQL
                                if (detail != "") { detail += "|"; }
                                detail += rowt["Cod_Barra"].ToString() + "/" + rowt["Cantidad"].ToString() + "/" + rowt["Monto"].ToString();

                                // Datos para DBF
                                string det = "Insert Into TKACTIVD (SERIE, NUMERO, CODACTI, CANT, MTOUNI) ";
                                det += "VALUES ('" + serie + "', '" + codigo + "', '" + rowt["Cod_Barra"].ToString() + "', " + rowt["Cantidad"].ToString() + ", " + rowt["Monto"].ToString() + ")";
                                System.Data.OleDb.OleDbCommand mov_det = new System.Data.OleDb.OleDbCommand(det, dbConn);
                                mov_det.ExecuteNonQuery();
                                tkactivd = true;
                            }

                            GrabarSQL_Ticket(sucursal, serie, codigo, fecha_sql, dni, nombres, apepat, apemat, forpag, tarjeta, nro_tarj, detail);
                        }
                        else
                        {
                            msaje_error = "Estado del día ya se encuentra cerrado";
                            throw new System.ArgumentException("Estado del día ya se encuentra cerrado", "FCIERR");
                        }
                    }
                    else
                    {
                        msaje_error = "El día de hoy aún no se aperturó";
                        throw new System.ArgumentException("El día de hoy aún no se aperturó", "FCIERR");
                    }

                    dbConn.Close();
                }
                catch (Exception ex)
                {
                    //-- Mensaje de Error
                    if (msaje_error == "")
                    { msaje_error = "El artículo seleccionado no se encuentra en las tablas de Stock."; }

                    //RollBack Manual
                    if (fstka)
                    {
                        foreach (string[] row in fstka_det_rb)
                        {
                            string sql_act_fstka_rb = "UPDATE " + tab_fstka + " SET SA_SA" + mes + "=SA_SA" + mes + "+" + row[1].ToString() + ", SA_ACUSEM" + sem + "=SA_ACUSEM" + sem + "-" + row[1].ToString() + " WHERE SA_ALMA='" + cod_almacen + "' AND SA_TANE='' AND SA_CONS='' AND SA_TIPO='" + tipo_prod + "' AND SA_ARTI='" + row[0].ToString() + "1' And SA_REGL='00' AND  SA_COLO=''";
                            System.Data.OleDb.OleDbCommand com_act_fstka_rb = new System.Data.OleDb.OleDbCommand(sql_act_fstka_rb, dbConn);
                            com_act_fstka_rb.ExecuteNonQuery();
                        }
                    }
                    if (fstkg)
                    {
                        foreach (string[] row in fstkg_det_rb)
                        {
                            string sql_act_fstkg_rb = "UPDATE " + tab_fstkg + " SET SG_SA" + mes + "=SG_SA" + mes + "+" + row[1] + ", SG_ACUSEM" + sem + "=SG_ACUSEM" + sem + "-" + row[1].ToString() + " WHERE SG_TIPO='" + tipo_prod + "' AND SG_ARTI='" + row[0].ToString() + "1' And SG_REGL='00' AND  SG_COLO=''";
                            System.Data.OleDb.OleDbCommand com_act_fstkg_rb = new System.Data.OleDb.OleDbCommand(sql_act_fstkg_rb, dbConn);
                            com_act_fstkg_rb.ExecuteNonQuery();
                        }
                    }
                    if (fresum)
                    {
                        foreach (string[] row in fresum_det_rb)
                        {
                            string sql_upd_fresum_rb = "UPDATE " + tab_fresum + " SET R_STOK = R_STOK+" + row[1].ToString() + ", R_VTAU = R_VTAU-" + row[1].ToString() + ", R_VTAS = R_VTAS-" + row[2].ToString() + " WHERE R_SALM='" + cod_almacen.Substring(0, 3) + "' AND R_YEAR='" + ano_comp + "' AND R_SEMA = '" + semana + "' AND R_ARTI = '" + row[0].ToString() + "1' AND R_REGL='00' AND  R_COLO=''";
                            System.Data.OleDb.OleDbCommand com_upd_fresum_rb = new System.Data.OleDb.OleDbCommand(sql_upd_fresum_rb, dbConn);
                            com_upd_fresum_rb.ExecuteNonQuery();
                        }
                    }
                    if (fstka_cr)
                    {
                        foreach (string[] row in fstka_cr_det_rb)
                        {
                            string sql_del_fstka_rb = "DELETE " + tab_fstka + " WHERE SA_ALMA='" + cod_almacen + "' AND SA_TANE='' AND SA_CONS='' AND SA_TIPO='" + tipo_prod + "' AND SA_ARTI='" + row[0].ToString() + "1' And SA_REGL='00' AND  SA_COLO=''";
                            System.Data.OleDb.OleDbCommand com_del_fstka_rb = new System.Data.OleDb.OleDbCommand(sql_del_fstka_rb, dbConn);
                            com_del_fstka_rb.ExecuteNonQuery();
                        }
                    }
                    if (fstkg_cr)
                    {
                        foreach (string[] row in fstkg_cr_det_rb)
                        {
                            string sql_del_fstkg_rb = "DELETE " + tab_fstkg + " WHERE SG_TIPO = '" + tipo_prod + "' AND SG_ARTI = '" + row[0].ToString() + "1' And SG_REGL = '00' AND SG_COLO = ''";
                            System.Data.OleDb.OleDbCommand com_del_fstkg_rb = new System.Data.OleDb.OleDbCommand(sql_del_fstkg_rb, dbConn);
                            com_del_fstkg_rb.ExecuteNonQuery();
                        }
                    }
                    if (fresum_cr)
                    {
                        foreach (string[] row in fresum_cr_det_rb)
                        {
                            string sql_del_fresum_rb = "DELETE " + tab_fstka + " WHERE SA_ALMA='" + cod_almacen + "' AND SA_TANE='' AND SA_CONS='' AND SA_TIPO='" + tipo_prod + "' AND SA_ARTI='" + row[0].ToString() + "1' And SA_REGL='00' AND  SA_COLO=''";
                            System.Data.OleDb.OleDbCommand com_del_fresum_rb = new System.Data.OleDb.OleDbCommand(sql_del_fresum_rb, dbConn);
                            com_del_fresum_rb.ExecuteNonQuery();
                        }
                    }
                    if(fmc)
                    {
                        string sql_del_fmc_rb = "DELETE " + tab_fmc + " WHERE V_SFOR='" + serie + "' AND V_NFOR='" + numero + "'";
                        System.Data.OleDb.OleDbCommand com_del_fmc_rb = new System.Data.OleDb.OleDbCommand(sql_del_fmc_rb, dbConn);
                        com_del_fmc_rb.ExecuteNonQuery();

                    }
                    if (fmd)
                    {
                        string sql_del_fmd_rb = "DELETE " + tab_fmd + " WHERE I_SFOR='" + serie + "' AND I_SFOR='" + numero + "'";
                        System.Data.OleDb.OleDbCommand com_del_fmd_rb = new System.Data.OleDb.OleDbCommand(sql_del_fmd_rb, dbConn);
                        com_del_fmd_rb.ExecuteNonQuery();

                    }
                    if (fmk)
                    {
                        string sql_del_fmk_rb = "DELETE " + tab_fmk + " WHERE J_SFOR='" + serie + "' AND J_NFOR='" + numero + "'";
                        System.Data.OleDb.OleDbCommand com_del_fmk_rb = new System.Data.OleDb.OleDbCommand(sql_del_fmk_rb, dbConn);
                        com_del_fmk_rb.ExecuteNonQuery();

                    }
                    if (tkactivc)
                    {
                        string sql_del_tkactivc_rb = "DELETE TKACTIVC WHERE SERIE='" + serie + "' AND NUMERO='" + numero + "'";
                        System.Data.OleDb.OleDbCommand com_del_tkactivc_rb = new System.Data.OleDb.OleDbCommand(sql_del_tkactivc_rb, dbConn);
                        com_del_tkactivc_rb.ExecuteNonQuery();

                    }
                    if (tkactivd)
                    {
                        string sql_del_tkactivd_rb = "DELETE TKACTIVD WHERE SERIE='" + serie + "' AND NUMERO='" + numero + "'";
                        System.Data.OleDb.OleDbCommand com_del_tkactivd_rb = new System.Data.OleDb.OleDbCommand(sql_del_tkactivd_rb, dbConn);
                        com_del_tkactivd_rb.ExecuteNonQuery();

                    }

                    // Cierra conexión
                    dbConn.Close();
                    throw new System.ArgumentException(msaje_error, tabla_error);
                    //throw ex;
                }
            }
            return codigo;
        }

        #region<FORMATO DE IMPRESION EPSON>
        public static string SetBold = System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27, (byte)'|', (byte)'b', (byte)'C' });
        private static string TruncateAt(string text, int maxWidth)
        {
            string retVal = text;
            if (text.Length > maxWidth)
                retVal = text.Substring(0, maxWidth);
            return retVal;
        }

        public static string Generar_Impresion(string _empresa, string _serie, string _numero_doc)
        {

            try
            {
                #region<IMPRESION DE TICKETS DE ACTIVACION>
                DataTable dt = BuscarTicketGF(_empresa, _serie, _numero_doc);

                if (dt != null) 
                { 
                    if (dt.Rows.Count > 0)
                    { 
                        #region<VARIABLES DE EMPRESA TICKETS>
                        string _marca_emp = dt.Rows[0]["encabezado"].ToString();
                        string _direccion_emp = dt.Rows[0]["direccion"].ToString();
                        string _Telefono_emp = dt.Rows[0]["telefono"].ToString();
                        string _razon_social_emp = dt.Rows[0]["raz_social"].ToString();
                        string _ruc_emp = dt.Rows[0]["ruc"].ToString();
                        string _nota = dt.Rows[0]["Glosa"].ToString();
                        #endregion
                        #region<VARIABLES DE IMPRESORA>
                        /*string _autoriacion_imp = "Autorizacion : " + dt.Rows[0]["Emp_Autorizacion"].ToString();
                        string _serie_imp = "Impresora : " + dt.Rows[0]["serie_impresora"].ToString();

                        Decimal _monto_efe = Convert.ToDecimal(dt.Rows[0]["montoefe"]);
                        Decimal _monto_tar = Convert.ToDecimal(dt.Rows[0]["montotar"]);
                        Decimal _monto_vue = Convert.ToDecimal(dt.Rows[0]["montovuel"]);*/
                        #endregion
                        #region<TIPO DE DOCUMENTO>
                        string _ticket = dt.Rows[0]["ticket"].ToString();
                        string _tipo_numero = "Nro: " + _ticket;
                        DateTime _fecha_doc = Convert.ToDateTime(dt.Rows[0]["fecha"]);
                        string _fecha_doc_text = "Fecha : " + _fecha_doc.ToString("dd/MM/yyyy") + " , " + _fecha_doc.ToString("hh:mm tt");
                        //decimal _igv = Convert.ToDecimal(dt.Rows[0]["Ven_Igv_Porc"].ToString());

                        //decimal _percepcionp = Convert.ToDecimal(dt.Rows[0]["Ven_PercepcionP"].ToString());
                        //decimal _percepcionm = Convert.ToDecimal(dt.Rows[0]["Ven_PercepcionM"].ToString());
                        //string _cod_hash = dt.Rows[0]["cod_hash"].ToString();
                        //string _estadook = dt.Rows[0]["EstadoOk"].ToString();
                        //Decimal _monto_nc = Convert.ToDecimal(dt.Rows[0]["monto_nc"].ToString();
                        //string _referencia_nc = dt.Rows[0]["referencia_nc"].ToString();
                        #endregion
                        #region<VARIABLES DE CLIENTES>
                        string _cliente_nom = dt.Rows[0]["cliente"].ToString();
                        string _cliente_dni_ruc = dt.Rows[0]["dni"].ToString();
                        #endregion
                        #region<FORMATO DE IMPRESION TICKET>
                        CrearTicket tk = new CrearTicket();
                        tk.TextoCentro(_marca_emp);
                        tk.TextoCentro(_direccion_emp);
                        tk.TextoCentro("Telefono " + _Telefono_emp);
                        tk.TextoCentro(_razon_social_emp);
                        tk.TextoCentro(_ruc_emp);
                        tk.TextoIzquierda("");
                        tk.TextoCentro("TICKET DE ACTIVACION - GIFT CARD");
                        tk.TextoIzquierda("");
                        tk.TextoIzquierda(_tipo_numero);
                        tk.TextoIzquierda("");
                        tk.lineasGuio();
                        tk.TextoIzquierda("Cliente : ");
                        tk.TextoIzquierda(_cliente_nom);
                        tk.TextoIzquierda("DNI :  " + _cliente_dni_ruc);
                        tk.TextoIzquierda(_fecha_doc_text);
                        tk.TextoIzquierda("");
                        tk.EncabezadoVenta("CODIGO  | DESCR.         | CNT | PRECIO ");
                        tk.lineasIgual();
                        //items del tickets
                        decimal Total = 0;
                        for (Int32 i = 0; i < dt.Rows.Count; ++i)
                        {
                            string _iarticulo = dt.Rows[i]["cod_artic"].ToString();
                            string _articulonombre = dt.Rows[i]["descripcion"].ToString();
                            string _des_largo = TruncateAt("Cod: "+dt.Rows[i]["cod_uso"].ToString().PadRight(40), 40);
                            decimal _cantidad = Convert.ToInt32(dt.Rows[i]["cantidad"]);
                            Decimal _articulo_total = Convert.ToDecimal(dt.Rows[i]["monto"].ToString())* _cantidad;
                            string _codigo_descripcion = TruncateAt(_iarticulo.PadRight(10), 10) +
                                    TruncateAt(_articulonombre.PadRight(13), 14) + TruncateAt(_cantidad.ToString("#0").PadLeft(5), 5) + TruncateAt(_articulo_total.ToString("#0.00").PadLeft(9), 9);
                            tk.AgregarItems(_codigo_descripcion);
                            tk.AgregarItems(_des_largo);
                            Total += _articulo_total;
                        }

                        decimal totalpagar = Total;

                        tk.lineasGuio();
                        tk.AgregarFooter("     " + TruncateAt("TOTAL".ToString().PadRight(16), 16) + TruncateAt("S/".ToString().PadRight(3), 3) + TruncateAt(totalpagar.ToString("#0.00").PadLeft(14), 14));

                        #region<REGION DE VENTAS DIRECTA CON PAGO>
                        /*if (Ent_Global._pvt_almaid != "11")
                        {
                            tk.lineasGuio();
                            tk.AgregarFooter(TruncateAt("EFECTIVO".ToString().PadRight(21), 21) + TruncateAt("S/".ToString().PadRight(3), 3) + TruncateAt(_monto_efe.ToString("#0.00").PadLeft(14), 14));
                            //VERIFICAR SI SE PAGA CON TARJETA//
                            if (ds.Tables.Count > 1)
                            {
                                DataTable dttarjeta = ds.Tables[1];
                                if (dttarjeta != null)
                                {
                                    if (dttarjeta.Rows.Count > 0)
                                    {
                                        tk.AgregarFooter(TruncateAt("TARJETA".ToString().PadRight(16), 16));
                                        for (Int32 i = 0; i < dttarjeta.Rows.Count; ++i)
                                        {
                                            string nom_tarjeta = dttarjeta.Rows[i]["bin_des"].ToString();
                                            string num_tarjeta = dttarjeta.Rows[i]["num_tar"].ToString();
                                            Decimal monto_tarjeta = Convert.ToDecimal(dttarjeta.Rows[i]["monto_tar"]);
                                            tk.AgregarFooter(TruncateAt(nom_tarjeta.ToString().PadRight(22), 22) + " " + TruncateAt(_monto_efe.ToString(num_tarjeta.ToString()).PadLeft(16), 16));
                                            tk.AgregarFooter("                     " + TruncateAt("S/".ToString().PadRight(3), 3) + TruncateAt(monto_tarjeta.ToString("#0.00").PadLeft(14), 14));
                                        }
                                    }
                                }
                            }
                            tk.AgregarFooter(TruncateAt("VUELTO".ToString().PadRight(21), 21) + TruncateAt("S/".ToString().PadRight(3), 3) + TruncateAt(_monto_vue.ToString("#0.00").PadLeft(14), 14));
                        }*/
                        #endregion

                        tk.lineasGuio();
                        //tk.TextoCentro(_cod_hash);
                        tk.lineasGuio();
                        tk.TextoIzquierda(_nota);
                        tk.lineasGuio();
                        tk.TextoCentro("*** GRACIAS POR SU PREFERENCIA ***");
                        tk.lineasGuio();
                        tk.CortaTicket();
                        tk.ImprimirTicket("TICKET");

                        #region<EN ESTE CASO CAPTURAMOS EL FORMATO DE TXT SUNAT PARA EL QR>
                        /*DataTable dtformato = ds.Tables[2];

                                string _formato_doc = "";

                                if (dtformato != null)
                                {
                                    if (dtformato.Rows.Count > 0)
                                    {
                                        _formato_doc = dtformato.Rows[0]["formatsunat"].ToString();
                                    }
                                }*/

                        #endregion
                        /*
                        Fe_Sunat_Qr fesunat_qr = new Fe_Sunat_Qr();
                        byte[] codigo_qr = fesunat_qr.GetQrSunatInvoiceCdp(_formato_doc);

                        Image im = byteArrayToImage(codigo_qr);
                        Bitmap bmp = new Bitmap(im, new Size(100, 100));
                        tk.HeaderImage = bmp;
                        tk.PrintQR(_impresora);*/

                        if (!CrearTicket._esta_imp)
                        {
                            return null;
                        }
                        #endregion
                    }
                            
                }
                #endregion

                /*#region<IMPRESION DE NOTA DE CREDITO>
                if (_tipo == "N")
                {
                    DataSet ds = Dat_NotaCredito.leer_NC_tk(_numero_doc);
                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];

                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                #region<VARIABLES DE EMPRESA TICKETS>
                                string _marca_emp = dt.Rows[0]["Alm_Descripcion"].ToString();
                                string _direccion_emp = dt.Rows[0]["Alm_Direccion"].ToString();
                                string _Telefono_emp = dt.Rows[0]["Alm_Telefono"].ToString();
                                string _razon_social_emp = dt.Rows[0]["Emp_Razon"].ToString();
                                string _ruc_emp = dt.Rows[0]["Emp_Ruc"].ToString();
                                String _nota = dt.Rows[0]["nota"].ToString();
                                string _impresora = dt.Rows[0]["impresora"].ToString();
                                #endregion
                                #region<VARIABLES DE IMPRESORA>
                                string _autoriacion_imp = "Autorizacion : " + dt.Rows[0]["Emp_Autorizacion"].ToString();
                                string _serie_imp = "Impresora : " + dt.Rows[0]["serie_impresora"].ToString();
                                #endregion
                                #region<TIPO DE DOCUMENTO>
                                string _numero = dt.Rows[0]["nrodoc"].ToString();
                                string _tipo_numero = "NOTA DE CREDITO: " + _numero;
                                DateTime _fecha_doc = Convert.ToDateTime(dt.Rows[0]["Not_Fecha"]);
                                string _fecha_doc_text = "Fecha : " + _fecha_doc.ToString("dd/MM/yyyy") + " , " + _fecha_doc.ToString("hh:mm tt");
                                decimal _igv = Convert.ToDecimal(dt.Rows[0]["Ven_Igv_Porc"].ToString());
                                //decimal _percepcionp = Convert.ToDecimal(dt.Rows[0]["Ven_PercepcionP"].ToString());
                                //decimal _percepcionm = Convert.ToDecimal(dt.Rows[0]["Ven_PercepcionM"].ToString());
                                string _cod_hash = dt.Rows[0]["cod_hash"].ToString();
                                String _estadook = dt.Rows[0]["EstadoOk"].ToString();
                                //Decimal _monto_nc = Convert.ToDecimal(dt.Rows[0]["monto_nc"].ToString());
                                string _referencia_nc = dt.Rows[0]["referencia"].ToString();
                                #endregion
                                #region<VARIABLES DE CLIENTES>
                                string _cliente_nom = dt.Rows[0]["nombres"].ToString();
                                string _cliente_dni_ruc = dt.Rows[0]["Bas_Documento"].ToString();
                                #endregion
                                #region<FORMATO DE IMPRESION FACTURA O BOLETA>
                                CrearTicket tk = new CrearTicket();
                                tk.TextoCentro(_marca_emp);
                                tk.TextoCentro(_direccion_emp);
                                tk.TextoCentro("Telefono " + _Telefono_emp);
                                tk.TextoCentro(_razon_social_emp);
                                tk.TextoCentro(_ruc_emp);
                                tk.TextoIzquierda(_autoriacion_imp);
                                tk.TextoIzquierda(_serie_imp);
                                tk.TextoIzquierda(_tipo_numero);
                                tk.TextoIzquierda("");
                                tk.TextoCentro("DETALLE DE COMPRA");
                                tk.TextoIzquierda("");
                                tk.lineasGuio();
                                tk.TextoIzquierda("Cliente : ");
                                tk.TextoIzquierda(_cliente_nom);
                                tk.TextoIzquierda(((_numero.Substring(0, 1).ToString() == "F") ? "R.U.C : " : "DNI :  ") + _cliente_dni_ruc);
                                tk.TextoIzquierda(_fecha_doc_text);
                                tk.TextoIzquierda("");
                                tk.EncabezadoVenta("CODIGO  | DESCR.         | CNT | PRECIO ");
                                tk.lineasIgual();
                                //items del tickets
                                decimal dSubtotal = 0;
                                decimal descuento = 0;
                                for (Int32 i = 0; i < dt.Rows.Count; ++i)
                                {
                                    string _iarticulo = dt.Rows[i]["Art_Id"].ToString();
                                    string _articulonombre = dt.Rows[i]["Art_Descripcion"].ToString();
                                    string _des_largo = TruncateAt(dt.Rows[i]["Art_Descripcion"].ToString().PadRight(40), 40);
                                    string _talla = dt.Rows[i]["Not_Det_TalId"].ToString();
                                    decimal _cantidad = Convert.ToInt32(dt.Rows[i]["Not_Det_Cantidad"]);
                                    Decimal _articulo_total = Convert.ToDecimal(dt.Rows[i]["articulo_total"].ToString());
                                    decimal _comision = Convert.ToDecimal(dt.Rows[i]["Not_Det_ComisionM"].ToString());
                                    string _codigo_descripcion = TruncateAt(_iarticulo.PadRight(10), 10) +
                                    TruncateAt(_articulonombre.PadRight(9), 10) + TruncateAt(_talla.PadLeft(4), 4) + TruncateAt(_cantidad.ToString("#0").PadLeft(5), 5) + TruncateAt(_articulo_total.ToString("#0.00").PadLeft(9), 9);
                                    tk.AgregarItems(_codigo_descripcion);
                                    tk.AgregarItems(_des_largo);
                                    dSubtotal += _articulo_total;
                                    descuento += _comision;
                                }

                                double mtoigv = Math.Round((Double.Parse(dSubtotal.ToString()) - Convert.ToDouble(descuento)) * double.Parse(_igv.ToString()), 2, MidpointRounding.AwayFromZero);
                                Int32 porcigv = Convert.ToInt32((_igv * 100));
                                decimal totalpagar = ((dSubtotal - descuento) + Convert.ToDecimal(mtoigv));

                                tk.lineasGuio();
                                tk.AgregarFooter("     " + TruncateAt("SUB-TOTAL".ToString().PadRight(16), 16) + TruncateAt("S/".ToString().PadRight(3), 3) + TruncateAt(dSubtotal.ToString("#0.00").PadLeft(14), 14));
                                tk.AgregarFooter("     " + TruncateAt("DESCUENTO(-)".ToString().PadRight(16), 16) + TruncateAt("S/".ToString().PadRight(3), 3) + TruncateAt(descuento.ToString("#0.00").PadLeft(14), 14));
                                tk.AgregarFooter("     " + TruncateAt("IGV " + porcigv + "%".ToString().PadRight(16), 16) + TruncateAt("S/".ToString().PadRight(3), 3) + TruncateAt(mtoigv.ToString("#0.00").PadLeft(14), 14));
                                tk.AgregarFooter("     " + TruncateAt("------------".ToString().PadRight(14), 14));

                                if (_estadook != "2")
                                {
                                    tk.AgregarFooter("     " + TruncateAt("TOTAL".ToString().PadRight(16), 16) + TruncateAt("S/".ToString().PadRight(3), 3) + TruncateAt(((dSubtotal - descuento) + Convert.ToDecimal(mtoigv)).ToString("#0.00").PadLeft(14), 14));
                                }

                                if (_estadook == "1")
                                {
                                    tk.AgregarFooter("     " + TruncateAt("------------".ToString().PadRight(14), 14));
                                    //tk.AgregarFooter("     " + TruncateAt("PERCEPCION " + _percepcionp + "%".ToString().PadRight(16), 16) + TruncateAt("S/".ToString().PadRight(3), 3) + TruncateAt(_percepcionm.ToString("#0.00").PadLeft(14), 14));
                                    tk.AgregarFooter("     " + TruncateAt("------------".ToString().PadRight(14), 14));
                                    tk.AgregarFooter("     " + TruncateAt("TOTAL A PAGAR".ToString().PadRight(16), 16) + TruncateAt("S/".ToString().PadRight(3), 3) + TruncateAt(totalpagar.ToString("#0.00").PadLeft(14), 14));
                                }

                                if (_estadook == "2")
                                {
                                    Decimal _var_sb = Convert.ToDecimal(((dSubtotal - descuento) + Convert.ToDecimal(mtoigv)));

                                    //if (_var_sb < _monto_nc)
                                    //{
                                    //    _monto_nc = _var_sb;
                                    //}
                                    //decimal _total_nc = _var_sb - _monto_nc;

                                    //decimal _total_pagar_nc = (_var_sb - _monto_nc) ;

                                    //tk.AgregarFooter("     " + TruncateAt("DESC NC  (-)".ToString().PadRight(16), 16) + TruncateAt("S/".ToString().PadRight(3), 3) + TruncateAt(_monto_nc.ToString("#0.00").PadLeft(14), 14));
                                    //tk.AgregarFooter("     " + TruncateAt("------------".ToString().PadRight(14), 14));
                                    //tk.AgregarFooter("     " + TruncateAt("TOTAL".ToString().PadRight(16), 16) + TruncateAt("S/".ToString().PadRight(3), 3) + TruncateAt(_total_nc.ToString("#0.00").PadLeft(14), 14));
                                    //if (_total_nc != 0)
                                    //{
                                    //    tk.AgregarFooter("     " + TruncateAt("------------".ToString().PadRight(14), 14));
                                    //    //tk.AgregarFooter("     " + TruncateAt("PERCEPCION " + _percepcionp + "%".ToString().PadRight(16), 16) + TruncateAt("S/".ToString().PadRight(3), 3) + TruncateAt(_percepcionm.ToString("#0.00").PadLeft(14), 14));
                                    //    tk.AgregarFooter("     " + TruncateAt("------------".ToString().PadRight(14), 14));
                                    //    tk.AgregarFooter("     " + TruncateAt("TOTAL A PAGAR".ToString().PadRight(16), 16) + TruncateAt("S/".ToString().PadRight(3), 3) + TruncateAt(_total_pagar_nc.ToString("#0.00").PadLeft(14), 14));
                                    //}
                                    //tk.lineasGuio();
                                    //tk.TextoIzquierda(_referencia_nc);
                                }

                                tk.lineasGuio();
                                tk.TextoIzquierda("FIRMA:");
                                tk.AgregarFooter(TruncateAt("EFECTIVO:".ToString().PadRight(21), 21) + TruncateAt("S/".ToString().PadRight(3), 3) + TruncateAt(((dSubtotal - descuento) + Convert.ToDecimal(mtoigv)).ToString("#0.00").PadLeft(14), 14));
                                tk.lineasGuio();
                                tk.TextoIzquierda("REFERENCIA DE N/C: " + _referencia_nc);
                                tk.lineasGuio();
                                tk.TextoCentro(_cod_hash);
                                tk.lineasGuio();
                                tk.TextoIzquierda(_nota);
                                tk.lineasGuio();
                                tk.TextoCentro("*** GRACIAS POR SU COMPRA ***");
                                tk.lineasGuio();
                                tk.ImprimirTicket(_impresora);

                                #region<EN ESTE CASO CAPTURAMOS EL FORMATO DE TXT SUNAT PARA EL QR>
                                DataTable dtformato = ds.Tables[1];

                                string _formato_doc = "";

                                if (dtformato != null)
                                {
                                    if (dtformato.Rows.Count > 0)
                                    {
                                        _formato_doc = dtformato.Rows[0]["formatsunat"].ToString();
                                    }
                                }
                                #endregion
                                Fe_Sunat_Qr fesunat_qr = new Fe_Sunat_Qr();
                                byte[] codigo_qr = fesunat_qr.GetQrSunatNoteCdp(_formato_doc);

                                Image im = byteArrayToImage(codigo_qr);
                                Bitmap bmp = new Bitmap(im, new Size(100, 100));
                                tk.HeaderImage = bmp;
                                tk.PrintQR(_impresora);

                                //byte[] codigo_qr = null;
                                //Image im = byteArrayToImage(codigo_qr);
                                //Bitmap bmp = new Bitmap(im, new Size(100, 100));
                                //tk.HeaderImage = bmp;
                                //tk.PrintQR(_impresora);

                                //tk.CortaTicket();
                                //tk.ImprimirTicket(_impresora);


                                if (!CrearTicket._esta_imp)
                                {
                                    return null;
                                }
                                #endregion
                            }
                        }

                    }
                }
                #endregion*/
                return "ok";
            }
            catch
            {
                return null;
            }
        }
        /*private static Image byteArrayToImage(byte[] bytesArr)
        {
            MemoryStream memstr = new MemoryStream(bytesArr);
            Image img = Image.FromStream(memstr);
            return img;
        }*/
        #endregion
    }

}
