using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_ConsData;
using Bata;
using System.IO;
using Bata.Clases;
using System.Windows.Threading;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using Epson_Ticket;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Bata
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
            //_tienda = "50" + Environment.GetEnvironmentVariable("codtda").ToString();

            Promocion._principal = this;

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            actualizar_vale();
        }
        string _tienda { set; get; }    

        private void telefono_email_clienteV(string _fc_nint,ref string _emai,ref string telefono)
        {
            string sqlquery = "select FC_LCON,FC_RUC from FFACTC02 where fc_nint='" + _fc_nint + "'";
            OleDbConnection cn = null;
            OleDbCommand cmd = null;
            OleDbDataAdapter da = null;
            DataTable dt = null;            
            string _path_default = @"D:\POS";
            //conexion
            string _conexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _path_default + ";Extended Properties=dBASE IV;";
            try
            {
                cn = new OleDbConnection(_conexion);
                cmd = new OleDbCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                da = new OleDbDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                if (dt!=null)
                {
                    if (dt.Rows.Count>0)
                    {
                        telefono = dt.Rows[0]["FC_LCON"].ToString();
                        String _dni= dt.Rows[0]["FC_RUC"].ToString();
                        sqlquery = "select fc_mail from FMACLI02 where fc_ruc='" + _dni + "'";
                        cmd = new OleDbCommand(sqlquery, cn);
                        cmd.CommandTimeout = 0;
                        da = new OleDbDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                _emai = dt.Rows[0]["fc_mail"].ToString();
                            }
                        }

                    }
                }
            }
            catch(Exception exc)
            {

            }
        }

        private Boolean  get_tel_email_in(String file_in,ref string _dni,ref string _nombres,ref string _telefono,ref string _email)
        {
            Boolean _valida = false;
            try
            {
                if (File.Exists(@file_in))
                {
                    string line;
                    using (StreamReader sr = new StreamReader(@file_in))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {

                            string[] split = line.Split(new Char[] { ',' });
                            _dni = split[4].ToString().Trim();
                            _nombres = split[6].ToString().Trim() + ", " + split[5].ToString().Trim();
                            _telefono = split[9].ToString().Trim();
                            _email = split[10].ToString().Trim();

                            if (_dni.Length > 0)
                            {
                                _valida = true;
                                return _valida;
                            }

                            //_valida = true;
                            //return _valida;
                        }
                    }

                }
            }
            catch
            {
                _valida = false;
            }
            return _valida;
        }

        private Boolean captura_data_dbf_in(string _serie,string _numero,ref string _dni,ref string _nombres,
                                            ref string _telefono,ref string _email)
        {
            Boolean _valida = false;
            DBF.NET.DBFNET select_table = null;
            try
            {
                select_table = new DBF.NET.DBFNET();
                select_table.tabla = "TEMPIN";
                DataTable dt = select_table.selectrow(_serie, _numero);
                if (dt!=null)
                {
                    if (dt.Rows.Count>0)
                    {
                        _dni = dt.Rows[0]["DNI"].ToString();
                        _nombres = dt.Rows[0]["APEPAT"].ToString() + " " + dt.Rows[0]["APEMAT"].ToString() + ", " + dt.Rows[0]["NOMBRES"].ToString();
                        _telefono = dt.Rows[0]["TELEFONO"].ToString();                        
                        _email = dt.Rows[0]["EMAIL"].ToString();
                        _valida = true;                        
                    }
                }

            }
            catch
            {
                _valida = false;
            }
            return _valida;
        }

        private void actualizar_vale()
        {
            try
            {
                string _ruta_txt_out = @"D:\Cons\Vales\out";
                string _ruta_txt_in = @"D:\Cons\Vales\in";
                if (Directory.Exists(@_ruta_txt_out))
                {
                    string[] _archivos_txt = Directory.GetFiles(@_ruta_txt_out, "*.txt");
                    if (_archivos_txt.Length > 0)
                    {
                        for (Int32 a = 0; a < _archivos_txt.Length; ++a)
                        {
                            string _archivo = _archivos_txt[a].ToString();
                            string _nombrearchivo_txt = System.IO.Path.GetFileNameWithoutExtension(@_archivo);
                            string _rutaarchivo_in = @_ruta_txt_in + "\\" + _nombrearchivo_txt + ".txt";

                            //string _ven_dni = "";
                            //string _ven_nombre = "";
                            //string _ven_email = "";
                            //string _ven_telefono = "";
                            //get_tel_email_in(_rutaarchivo_in, ref _ven_dni, ref _ven_nombre, ref _ven_email, ref _ven_telefono);

                            int counter = 0;
                            string line;

                            string _error = "";Int32 _ingreso_data = 0;
                            // Read the file and display it line by line.
                            using (StreamReader sr = new StreamReader(@_archivo))
                            {
                                try
                                {
                               
                                while ((line = sr.ReadLine()) != null)
                                {
                                    string _cadena = "";
                                    Int32 _fecha_int = 0;                                  
                                    if (line.Length>0)
                                    {                                       
                                        Int32 _abierto = 0;
                                        //quitar las , dentro de un cadena
                                        for (Int32 i=0;i<line.Length;++i)
                                        {
                                            if (_abierto == 0 && line.Substring(i, 1) == "," && _fecha_int != 2)
                                            {
                                                _cadena += line.Substring(i, 1);
                                            }

                                            if (line.Substring(i, 1)== "\"")
                                            {
                                                _abierto += 1;                                               
                                            }

                                            if (line.Substring(i, 1) != "," && _abierto>=1)
                                            {
                                                _cadena += line.Substring(i, 1);
                                            }

                                            if (_fecha_int == 2)
                                            {
                                                _cadena += line.Substring(i, 1);
                                            }

                                            if (line.Substring(i, 1) == ",")
                                            {
                                                _fecha_int += 1;

                                            }

                                            if (_abierto == 2) _abierto = 0;
                                                
                                        }
                                    }

                                    _cadena = _cadena.Replace("\"", "");

                                    //-- Agregamos condicion para GiftCard - Henry Morales - 16/04/18
                                    if (_nombrearchivo_txt== "000051" || _nombrearchivo_txt == "000055")
                                        if (_cadena.Trim().Length == 0) break;

                                    string[] split = _cadena.Split(new Char[] { ',' });
                                    string _serie = "";
                                    string _numero = "";
                                    _serie = split[0].ToString(); _numero = split[1].ToString();


                                    string _dni_venta, _nombres_venta,_tipo_doc,_serie_doc,_numero_doc, _estado_doc, _fecha_doc;                                    

                                    if (_serie.Trim().Length > 0)
                                    {
                                        _ingreso_data = 1;
                                        _fecha_doc = split[2].ToString();
                                        _tipo_doc = split[3].ToString().Trim();
                                        _serie_doc = split[4].ToString().Trim();
                                        _numero_doc = split[5].ToString().Trim();
                                        _dni_venta = split[6].ToString().Trim();
                                        _nombres_venta= split[7].ToString().Trim();
                                        _estado_doc= split[8].ToString().Trim();
                                        _tienda ="50" + split[9].ToString().Trim();

                                        string _fc_nint = "";// (_estado_doc == "A") ? "" : split[10].ToString().Trim();
                                        if (split.Count()>10)
                                        {
                                            _fc_nint = (_estado_doc == "A") ? "" : split[10].ToString().Trim();
                                        }


                                        //string _fc_nint=(_estado_doc=="A")?"": split[10].ToString().Trim();
                                        string _emai_venta = "";
                                        string _telefono_venta = "";

                                            //SERIE 302001=BATACLUB
                                            //SERIE 302002=EMPLEADOS
                                            //SERIE 302003=BENEFICIOS
                                            //SERIE 302004=GEL Y OTROS RRHH
                                            //SERIE 000051=VALES
                                            //SERIE 000055=GIFT CARD

                                            //-- Agregamos condicion para GiftCard - Henry Morales - 16/04/18
                                            if (_serie== "302001" || _serie == "302002" || _serie == "302003" || _serie == "302004" || _serie == "000051" || _serie == "000055")
                                        { 
                                            /*en este proceso vamos a capturar el archivo dbf cuando se genero en el in*/

                                            if (!captura_data_dbf_in(_serie,_numero,ref _dni_venta,ref _nombres_venta,ref _telefono_venta,ref _emai_venta))
                                            { 
                                            /*******************************************/
                                                if (!get_tel_email_in(_rutaarchivo_in,ref _dni_venta,ref _nombres_venta,ref _telefono_venta,ref _emai_venta))
                                                { 
                                                    telefono_email_clienteV(_fc_nint, ref _emai_venta, ref _telefono_venta);
                                                }
                                            }
                                            //-- Agregamos condicion para GiftCard - Henry Morales - 16/04/18
                                            _error = Clientes._update_vales(_serie.Trim().ToString(),(_serie!= "000051" && _serie != "000055") ? _nombrearchivo_txt:_numero, _tienda,_dni_venta,_nombres_venta,_fecha_doc,_tipo_doc,_serie_doc,_numero_doc,_estado_doc, _fc_nint,_emai_venta,_telefono_venta);
                                        }
                                        else
                                        {
                                            //if (!get_tel_email_in(_rutaarchivo_in, ref _dni_venta, ref _nombres_venta, ref _telefono_venta, ref _emai_venta))
                                            //{
                                            //    telefono_email_clienteV(_fc_nint, ref _emai_venta, ref _telefono_venta);
                                            //}
                                            //_dni_venta = _nombrearchivo_txt;
                                            _error = Clientes._update_venta_empl(_serie, _dni_venta, _tienda, _serie_doc + _numero_doc, _tipo_doc, _serie_doc, _numero_doc, _fecha_doc, _estado_doc, _fc_nint);
                                        }

                                    }
                                    //-- Agregamos condicion para GiftCard - Henry Morales - 16/04/18
                                    if (_serie!= "000051" && _serie != "000055")
                                        if (_error.Length == 0) break;

                                    //System.Console.WriteLine(line);
                                    counter++;
                                }
                                }
                                catch (Exception)
                                {


                                }
                              

                            }

                            //System.IO.StreamReader file =
                            //    new System.IO.StreamReader(@_archivo);
                            

                            if (_error.Length == 0 && _ingreso_data == 1)
                            {
                                File.Delete(@_archivo);
                                
                                if (File.Exists(@_rutaarchivo_in))
                                {
                                    File.Delete(@_rutaarchivo_in);
                                }

                            }
                        }
                    }
                }
            }
            catch(Exception exc)
            {
                //string _RUTA = @"D\ERROR.TXT";
                //TextWriter tw = new StreamWriter(_RUTA, true);
                //tw.WriteLine(exc.Message);
                //tw.Flush();
                //tw.Close();
                //tw.Dispose();
            }
        }

        private void limpiar_ws_client()
        {
            string _ruta_txt = @"D:\Cons\Cliente";
            try
            {
                string[] _archivos_txt = Directory.GetFiles(@_ruta_txt, "*.txt");
                if (_archivos_txt.Length>0)
                {
                    for (Int32 a = 0; a < _archivos_txt.Length; ++a)
                    {
                        string _archivo = _archivos_txt[a].ToString();

                        if (File.Exists(@_archivo))
                        {
                            File.Delete(@_archivo);
                        }
                    }
                }
            }
            catch (Exception)
            {

                
            }
        }

        private void version_click_once()
        {
            try
            {
                Version myVersion=null;
                if (ApplicationDeployment.IsNetworkDeployed)
                { 
                    myVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                }
                if (myVersion!= null)
                {
                    string tda = _tienda.Substring(2, 3).ToString();
                    this.Title = "Bata-Desktop Aplication > POS.NET > Version >" + myVersion.ToString() + " > Tienda: " + tda;
                }
            }
            catch (Exception)
            {

                
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Environment.GetEnvironmentVariable("codtda") != null)
                    _tienda = "50" + Environment.GetEnvironmentVariable("codtda").ToString();

                actualizar_click_once();
                _verifica_version();
                version_click_once();
                limpiar_ws_client();
                /*deshabilitar boton de empl*/
               // _tienda = "50283";
                ws_clientedniruc.Cons_ClienteSoapClient opc_tda = new ws_clientedniruc.Cons_ClienteSoapClient();
                Boolean btn_habilita = opc_tda.ws_validatdabgwb(_tienda);

                btndesemp.Visibility = (btn_habilita == true) ? Visibility.Visible : Visibility.Hidden;

                /*lista de soporte de tienda*/
                get_soporte_bata();

            }
            catch (Exception exc)
            {
                btndesemp.IsEnabled = false;
                btnvales.IsEnabled = false;
                btnGiftCard.IsEnabled = false;
                btncliente.IsEnabled = false;
                btnvalesc.IsEnabled = false;
                MessageBox.Show(exc.Message, "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
         
            //btndesemp.Visibility = Visibility.Hidden;

            //   actualizar_vale();
        }
        private void _verifica_version()
        {
            Version version_apl=null;
            try
            {
                if (ApplicationDeployment.IsNetworkDeployed)
                    version_apl = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                if (version_apl!=null)
                {
                    if (_tienda!=null || _tienda.Length>0)
                    {
                        ws_clientedniruc.Cons_ClienteSoapClient versionclik = new ws_clientedniruc.Cons_ClienteSoapClient();
                        Boolean existe = versionclik.ws_verifica_version_apltda(_tienda, "WPF", version_apl.ToString());

                        if (!existe)
                        {
                            string _update = versionclik.ws_update_apltda(_tienda, "WPF", version_apl.ToString());
                        }
                    }
                }
                
            }
            catch
            {

            }
        }

        private void actualizar_click_once()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            actualizar_win();
            Mouse.OverrideCursor = null;
        }
        private void actualizar_win()
        {
            UpdateCheckInfo info = null;

            // If not deployed via network, it's either installed from cd or running on your own development pc.
            if (!ApplicationDeployment.IsNetworkDeployed)
            {
                //MessageBox.Show("This application was not deployed using ClickOnce", "Check for updates", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ApplicationDeployment updateCheck = ApplicationDeployment.CurrentDeployment;

                try
                {
                    // Get detailed information.
                    info = updateCheck.CheckForDetailedUpdate();

                }
                catch (DeploymentDownloadException dde)
                {
                    //  MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    // MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    //MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    return;
                }

                // Check if update is actually available.

                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;

                    // Check if update is required. If not, ask user if they actually want to install.
                    //if (!info.IsUpdateRequired)
                    //{
                    //    MessageBoxResult msbResult = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                    //    if (!(msbResult == MessageBoxResult.OK))
                    //    {
                    //        doUpdate = false;
                    //    }
                    //}

                    // Perform the actual update.
                    if (doUpdate)
                    {
                        try
                        {
                            updateCheck.Update();
                            //MessageBox.Show("La Aplicacion se actualizo a una nueva version.", "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Information);

                            System.Windows.Forms.Application.Restart();

                            System.Windows.Application.Current.Shutdown();

                            //System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                            //Application.Current.Shutdown();

                            //System.Windows.Application.Current.Shutdown();
                            //System.Windows.Forms.Application.Restart();
                            //Application.res Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            //      MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
                            return;
                        }
                    }
                }
                else
                {
                    //MessageBox.Show("No update is currently available", "Check for updates", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btCloseSesion_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
            //this.Close();
        }

        private void btBackPanelLiq_Click(object sender, RoutedEventArgs e)
        {

        }
        private void get_soporte_bata()
        {
            ws_clientedniruc.Cons_ClienteSoapClient ws_lista_soporte = null;
            try
            {
                ws_lista_soporte = new ws_clientedniruc.Cons_ClienteSoapClient();
                var lista_soporte= ws_lista_soporte.ws_lista_soporte();

                dg1.ItemsSource = lista_soporte;
            }
            catch (Exception)
            {

                
            }
        }
        private static System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }
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
        private void btncliente_Click(object sender, RoutedEventArgs e)
        {

            //#region<IMPRIMIR TICKETS>

            //Ticket ticket = new Ticket();

            //string file = @"D:\INTERFA\CARVAJAL1\IN\Boletas\QR\B1438123.txt";
            //StreamReader sr = new StreamReader(@file, Encoding.Default);

            //string linea;
            //string line;
            //int counter = 0;
            //while ((line = sr.ReadLine()) != null)
            //{
            //    string str = line.PadLeft(40, ' ');
            //    str = line.PadRight(40, ' ');

            //    ticket.AddHeaderLine(str);
            //    //System.Console.WriteLine(line);
            //    counter++;
            //}

            ////ticket.AddHeaderLine("                    Bata         ");
            ////ticket.AddHeaderLine("EXPEDIDO EN:");
            ////ticket.AddHeaderLine("CALLE CONOCIDA");
            ////ticket.AddHeaderLine("PUEBLA, PUEBLA");
            ////ticket.AddHeaderLine("RFC: CSI-020226-MV4");

            ////byte[] im = System.IO.File.ReadAllBytes(@"D:\qrprueba.png");

            ////Image Imagen = byteArrayToImage(im);

            ////Por ejemplo

            ////ticket.AddSubHeaderLine("Ticket # 1");
            ////ticket.AddSubHeaderLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());

            ////ticket.AddItem("Cantidad", "Nombre producto", "Total");

            ////ticket.AddTotal("SUBTOTAL", "12.00");
            ////ticket.AddTotal("IVA", "0");
            ////ticket.AddTotal("TOTAL", "24");
            ////ticket.AddTotal("", "");
            ////ticket.AddTotal("RECIBIDO", "0");
            ////ticket.AddTotal("CAMBIO", "0");
            ////ticket.AddTotal("", "");

            ////ticket.AddFooterLine("VUELVA PRONTO");
            //byte[] im = System.IO.File.ReadAllBytes(@"D:\qrprueba.png");
            ////byteArrayToImage(im);

            //System.Drawing.Image im1 = byteArrayToImage(im);
            //Bitmap bmp = new Bitmap(im1, new System.Drawing.Size(100, 100));

            ////Bitmap bmp = new Bitmap(im, new System.Drawing.Size(100, 100));
            //ticket.HeaderImage = bmp;
            //ticket.PrintTicket("Ticket");

            ////string file = @"D:\INTERFA\CARVAJAL1\IN\Boletas\QR\B1438123.txt";
            ////StreamReader sr = new StreamReader(@file, Encoding.Default);
            ////string _formato_doc = sr.ReadToEnd();
            ////sr.Close();

            ////string[] str = Regex.Split(_formato_doc, "<td>");

            ////string str_cab = str[0].Trim();
            ////str_cab = ReemplazarCaracteresEspeciales(str_cab.TrimEnd());
            ////str_cab = str_cab + "\n";
            ////str_cab = str_cab + "\n";
            ////str_cab = str_cab.Replace("\n", "");

            ////string[] str_div = str_cab.Split('\r');

            ////Ticket ticket = new Ticket();
            ////string linea;
            ////string line;
            ////int counter = 0;
            ////while ((line = sr.ReadLine()) != null)
            ////{
            ////    string str = line.PadLeft(40, ' ');
            ////    str = line.PadRight(40, ' ');

            ////    ticket.AddHeaderLine(str);
            ////    //System.Console.WriteLine(line);
            ////    counter++;
            ////}

            ////foreach (string str1 in sr.ReadLine())
            ////{
            ////    ticket.AddHeaderLine(str1);
            ////}

            ////ticket.AddItem(str_cab);
            ////ticket.AddSubHeaderLine(str_cab);
            ////ticket.PrintTicket("Ticket");

            //List<string> valor = new List<string>();
            //valor.Add("A4F32A98EF993BC");
            ////valor.Add("F367E8BB72C3000");
            ////valor.Add("FD09947C418D0AC");
            ////valor.Add("CDE088389A5D104");
            ////valor.Add("C957F07FEA65008");
            ////valor.Add("75624C893F95204");
            ////valor.Add("80FF4F1D13930E3");
            ////valor.Add("BC88F9C7B36C650");
            ////valor.Add("99C655EDE68BC80"); 
            ////valor.Add("64C8A0EEDE59E84");
            ////valor.Add("882821BA87B33F6");

            ////Ticket ticket = new Ticket();

            ////ticket.AddHeaderLine("ChafiTienda");
            ////ticket.AddHeaderLine("EXPEDIDO EN:");
            ////ticket.AddHeaderLine("CALLE CONOCIDA");
            ////ticket.AddHeaderLine("PUEBLA, PUEBLA");
            ////ticket.AddHeaderLine("RFC: CSI-020226-MV4");



            ////System.Drawing.Image Imagen = byteArrayToImage(im);

            ////Por ejemplo

            ////ticket.AddSubHeaderLine("Ticket # 1");
            ////ticket.AddSubHeaderLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());

            ////ticket.AddItem("Cantidad", "Nombre producto", "Total");

            ////ticket.AddTotal("SUBTOTAL", "12.00");
            ////ticket.AddTotal("IVA", "0");
            ////ticket.AddTotal("TOTAL", "24");
            ////ticket.AddTotal("", "");
            ////ticket.AddTotal("RECIBIDO", "0");
            ////ticket.AddTotal("CAMBIO", "0");
            ////ticket.AddTotal("", "");

            ////ticket.AddFooterLine("VUELVA PRONTO");
            ////ticket.HeaderImage = Imagen;
            ////ticket.PrintTicket("Ticket");


            //foreach (string v in valor)
            //{
            //    Basico.Imprime_Bataclub(v.ToString());
            //}


            //return;
            ////CrearTicket tk = new CrearTicket();
            ////BarcodeLib.Barcode Codigo = new BarcodeLib.Barcode();
            ////Codigo.IncludeLabel = true;
            ////System.Drawing.Image im = Codigo.Encode(BarcodeLib.TYPE.CODE128, "020F92BB8B52853",System.Drawing.Color.Black, System.Drawing.Color.White, 400, 100);

            //////im.Save(@"D:\DBF\FMC\imagen.jpg");

            //////Bitmap bmp = new Bitmap(im, new System.Drawing.Size(100, 100));
            ////tk.HeaderImage = im;
            ////tk.PrintQR("AQ");
            //return;
            //#endregion

            if (!MainWindow._activo_form)
            {
                //_verifica_version();
                MainWindow frm = new MainWindow();
                frm.Show();
                //this.Close();
                MainWindow._activo_form = true;
            }
            

        }

        private void btnvales_Click(object sender, RoutedEventArgs e)
        {
            if (!Promocion._activo_form)
            {
                Promocion frm = new Promocion();
                frm.Show();
                //this.Close();
                Promocion._activo_form = true;
            }
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btndesemp_Click(object sender, RoutedEventArgs e)
        {
            if (!Descuento_Bata._activo_form)
            {
                Descuento_Bata frm = new Descuento_Bata();
                frm.Show();
                //this.Close();
                Descuento_Bata._activo_form = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
            DataTable dt = Clientes.dtclienteb();

            for(Int32 i=0;i<dt.Rows.Count;++i)
            {
                string dni = dt.Rows[i]["DNI_Venta"].ToString();
                Boolean _flujo = false;
                    Boolean nuevocliente = false;
                    Boolean existe_cl_bata = false;
                    string barra_cliente = "";
                    DataTable dtmetri = Clientes._consultacliente(dni,ref _flujo,ref nuevocliente,ref existe_cl_bata,ref barra_cliente);

                if (dtmetri!=null)
                {
                    if (dtmetri.Rows.Count>0)
                    {
                        string _telefono = dtmetri.Rows[0]["fc_tele"].ToString();string _email = dtmetri.Rows[0]["fc_mail"].ToString();
                            string _nombres = dtmetri.Rows[0]["fc_nomb"].ToString();string _apepat= dtmetri.Rows[0]["fc_apep"].ToString();
                            string _apemat = dtmetri.Rows[0]["fc_apem"].ToString();string _correo_envio = "";string _telef_envia = "";

                           string _nom_ape= _apepat +  ", " + _nombres;

                            Boolean _valor = Clientes.update_cliente(dni, _nom_ape);

                            //if (_telefono.Length>0 || _email.Length>0)
                            //{ 
                            //    string _valida = Clientes._actualiza_cliente(dni, _nombres, _apepat, _apemat, _telefono, _email, _tienda, ref _correo_envio, ref _telef_envia);
                            //}

                        }
                }

            }
                MessageBox.Show("correcto", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                Mouse.OverrideCursor = null;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message,"Aviso",MessageBoxButton.OK,MessageBoxImage.Error);
                Mouse.OverrideCursor = null;
            }
        }

        private void btnvalesc_Click(object sender, RoutedEventArgs e)
        {
            if (!ValesCompra._activo_form)
            {
                //_verifica_version();
                ValesCompra frm = new ValesCompra();
                frm.Show();
                //this.Close();
                ValesCompra._activo_form = true;
            }
        }

        /// <summary>
        /// Método que se activa para ingresar a la opción de Activación Gift Cards
        /// Modificado por : Henry Morales - 16/04/2018
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btngiftcard_Click(object sender, RoutedEventArgs e)
        {
            if (!ActivaGiftCard._activo_form)
            {
                ActivaGiftCard frm = new ActivaGiftCard();
                frm.Show();
                //this.Close();
                ActivaGiftCard._activo_form = true;
            }
        }

        private void btnsoport_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://soporte.bgr.pe/glpi");

            // Process.Start("http://localhost:53228/ArticuloStock/Index_Acceso?emp=ok");

            //Process.Start("http://www.bgr.pe/bataweb/ArticuloStock/Index_Acceso?varemp=1FCCD4D0-19C6-45AC-AFAC-FC0EF4AF32D5");

            // Response.Cookies["Usuario"].Value = "Invitado";
            //Response.Cookies["contraseña"].Value = "Invitado123";
            //Response.Redirect("../ArticuloStock/Index");
        }

        private void btnstk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //_tienda = "50210";
                //string strCambiante = DateTime.Now.ToString("M/d/yyyy");
                //string nombre = strCambiante + "_" + Environment.MachineName;
                string strparam = string.Empty;
                byte[] encryted = null;
                #region<REGION PARA LAS TDAS XSTORE>

                //_tienda = "50210";

                if (_tienda == null) _tienda = "";

                if ( _tienda.Length==0)
                {
                    string strCambiante = DateTime.Now.ToString("M/d/yyyy");
                    string nombre = strCambiante + "_" + Environment.MachineName;
                    //string nombre = strCambiante + "_" + "TIENDA-140-1";
                    //string strparam = string.Empty;
                    encryted = System.Text.Encoding.Unicode.GetBytes(nombre);
                    strparam = Convert.ToBase64String(encryted);
                }
                #endregion
                else
                { 
                   // _tienda = "50290";
                    encryted = System.Text.Encoding.Unicode.GetBytes(_tienda);
                    strparam = Convert.ToBase64String(encryted);
                }
                ProcessStartInfo startInfo = new ProcessStartInfo("http://posperu.bgr.pe/BataWeb/LoginIntermedio/Login?variable=" + strparam);

                //ProcessStartInfo startInfo = new ProcessStartInfo("http://localhost:53228/LoginIntermedio/Login?variable=" + strparam);

                //ProcessStartInfo startInfo = new ProcessStartInfo("http://localhost/bataweb/LoginIntermedio/Login?variable=" + strparam);

                Process.Start(startInfo);


               
            }
            catch
            {

            }
        }

        private void btnMarcacion_Click(object sender, RoutedEventArgs e)
        {
            if (!MarcacionAsistencia._activo_form)
            {
                //_verifica_version();
                MarcacionAsistencia frm = new MarcacionAsistencia();
                frm.Show();
                //this.Close();
                MarcacionAsistencia._activo_form = true;
            }
        }
    }
}
