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

                                    if (_nombrearchivo_txt== "000051")
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

                                        if (_serie== "302001" || _serie == "302003" || _serie == "000051")
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
                                            _error = Clientes._update_vales(_serie.Trim().ToString(),(_serie!= "000051")? _nombrearchivo_txt:_numero, _tienda,_dni_venta,_nombres_venta,_fecha_doc,_tipo_doc,_serie_doc,_numero_doc,_estado_doc, _fc_nint,_emai_venta,_telefono_venta);
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

                                    if (_serie!= "000051")
                                        if (_error.Length == 0) break;

                                    //System.Console.WriteLine(line);
                                    counter++;
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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Environment.GetEnvironmentVariable("codtda")!=null)
            _tienda = "50" + Environment.GetEnvironmentVariable("codtda").ToString();

            actualizar_click_once();
            _verifica_version();


            /*deshabilitar boton de empl*/
           // _tienda = "50283";
            ws_clientedniruc.Cons_ClienteSoapClient opc_tda = new ws_clientedniruc.Cons_ClienteSoapClient();
            Boolean btn_habilita = opc_tda.ws_validatdabgwb(_tienda);

            btndesemp.Visibility = (btn_habilita == true) ? Visibility.Visible : Visibility.Hidden;

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

        private void btncliente_Click(object sender, RoutedEventArgs e)
        {
            
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
                DataTable dtmetri = Clientes._consultacliente(dni,ref _flujo);

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
    }
}
