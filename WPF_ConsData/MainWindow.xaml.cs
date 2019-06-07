using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Deployment.Application;
using Bata.Clases;
using Bata;
using ConsultReniec;
using ConsultaSunat;
using System.Data.OleDb;
using System.IO;
using System.ComponentModel;
using System.Threading;
namespace WPF_ConsData
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker _trabajo;        

        public static Boolean _activo_form=false;

        public static Window _principal { set; get; }

        private DataTable dtdni = null;
        private DataTable dtruc = null;
        private DataTable dtruc2 = null;

        private Boolean _reniec_sunat = false;

        private Boolean RegistradoEnFlujosBataClub = false;

        private Boolean nuevo_bataclub = false;

        private Boolean no_existe_cl_bata = false;

        private PromBata getpromo_bata = null;

        string _tienda { set; get; }
        public MainWindow()
        {
            InitializeComponent();
            //_trabajo.DoWork += _Trabajo_DoWork;
            //_trabajo.RunWorkerCompleted += _trabajo_RunWorkerCompleted;

        }
        //private void _trabajo_RunWorkerCompleted(object Sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        //{
        //    if (!e.Cancelled)
        //    {
        //        //label2.Content = "Complete My Background Work";

        //    }
        //    else
        //    {
        //        //label2.Content = "Sorry it's Fail";
        //    }
        //}
        //private void _Trabajo_DoWork(object Sender, DoWorkEventArgs e)
        //{
        //    _trabajo.WorkerReportsProgress = true;
        //    for (Int32 i = 1; i <= 100; ++i)
        //    {
        //        _trabajo.ReportProgress(i / 10);
        //        Thread.Sleep(10);
        //    }
            
        //        //e.Result = dt_importa_stk();
            

        //    //for (int i = 0; i <= 100; i++)
        //    //{
        //    //    for (int j = 1; j <= 10000000; j++)
        //    //    {

        //    //    }
        //    //    if (_trabajo.CancellationPending)
        //    //    {
        //    //        e.Cancel = true;
        //    //        return;
        //    //    }
        //    //    //UpdateMyDelegatedelegate UpdateMyDelegate = new UpdateMyDelegatedelegate(UpdateMyDelegateLabel);
        //    //    //label1.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, UpdateMyDelegate, i + 5);

        //    //}
        //}
        //String fc_cubi = "";
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
                    if (!info.IsUpdateRequired)
                    {
                        // MessageBoxResult msbResult = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        // if (!(msbResult == MessageBoxResult.OK))
                        // {
                        //doUpdate = false;
                        // }
                    }

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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //actualizar_click_once();
            limpiar_objec();
            //DisplayLoginScreen();
            txtdniruc.Focus();

            if (Environment.GetEnvironmentVariable("codtda")!=null)
            _tienda = Environment.GetEnvironmentVariable("codtda");

            if (_tienda!=null)
            {
                _tienda = "50" + _tienda.ToString();
            }
           

            //System.Collections.IDictionary variablesEntorno = Environment.GetEnvironmentVariables();
            //foreach (System.Collections.DictionaryEntry de in variablesEntorno)
            //{
            //    Console.WriteLine(de.Key + ": " + de.Value);

                //    MessageBox.Show(de.Key + ": " + de.Value);
                //}
        }
        private void _generar_pase()
        {
            string _nombre = txtnombres.Text.ToString().Trim();
            if (_nombre.Length > 0)
            { 
                //generar archivo de texto ruc o dni
                //string _ruta=@"D:\dniruc";
                //if (!Directory.Exists(@_ruta_carvajal_xml))
                //{
                //    Directory.CreateDirectory(@_ruta_carvajal_xml);
                //}
            }
        }

        private void _crear_actualiza_dbf_loading()
        {
            //OleDbConnection cn1=null;
            //OleDbCommand cmd1=null;
            //OleDbCommand cmd2=null;
            //OleDbCommand cmd3=null;
            try
            {
                string _validatxt = txtdni.Text.Trim();
                if (_validatxt.Length != 0 && _validatxt != "Error!")
                {
                    string _dniruc = txtdni.Text.Trim();
                    string _nombre = txtnombres.Text.Trim();
                    string _apepat = txtapepat.Text.Trim();
                    string _apemat = txtapemat.Text.Trim();
                    string _direccion = txtdireccion.Text.Trim();
                    string _telefono = txttelefono.Text.Trim();
                    string _email = txtemail.Text.Trim();
                    string _ubigeo = txtubigeo.Text.Trim();

                    _nombre = _nombre.Replace(",", " ");
                    _apepat = _apepat.Replace(",", " ");
                    _apemat = _apemat.Replace(",", " ");
                    _direccion = _direccion.Replace(",", " ");
                    _telefono = _telefono.Replace(",", " ");
                    _email = _email.Replace(",", " ");
                    _ubigeo = _ubigeo.Replace(",", " ");

                    string _ruta_txt = @"D:\Cons\Cliente";
                    if (!Directory.Exists(@_ruta_txt))
                    {
                        Directory.CreateDirectory(@_ruta_txt);
                    }
                    string _ruta_archivo = _ruta_txt + "\\WsClient.txt";

                    if (File.Exists(@_ruta_archivo))
                    {
                        File.Delete(@_ruta_archivo);
                    }

                    TextWriter tw = new StreamWriter(@_ruta_archivo, true);
                    tw.WriteLine(_dniruc + "," + _nombre + "," + _apepat + "," + _apemat + "," + _direccion + "," + _telefono + "," + _email + "," + _ubigeo);
                    tw.Flush();
                    tw.Close();
                    tw.Dispose();

                    //string _query_create_dbf = "Create Table WsClient (dniruc C(11), nombres C(100),apepat C(80),apemat C(80),direc C(200),telef C(50),email C(80))";
                    //string _query_insert_dbf = "Insert Into WsClient(dniruc,nombres,apepat,apemat,direc,telef,email) " +
                    //"Values (?,?,?,?,?,?,?)";
                    //cn1 = new OleDbConnection("Provider=VFPOLEDB.1;Data Source=" + @_ruta_dbf + ";");
                    //cn1.Open();
                    ////'-- Make some VFP data to play with
                    //cmd1 = new OleDbCommand(_query_create_dbf, cn1);
                    //cmd2 = new OleDbCommand(_query_insert_dbf, cn1);


                    //cmd2.CommandType = CommandType.Text;
                    //cmd2.Parameters.AddWithValue("dniruc", _dniruc);
                    //cmd2.Parameters.AddWithValue("nombres", _nombre);
                    //cmd2.Parameters.AddWithValue("apepat", _apepat);
                    //cmd2.Parameters.AddWithValue("apemat", _apemat);
                    //cmd2.Parameters.AddWithValue("direc", _direccion);
                    //cmd2.Parameters.AddWithValue("telef", _telefono);
                    //cmd2.Parameters.AddWithValue("email", _email);

                    //cmd1.ExecuteNonQuery();
                    //cmd2.ExecuteNonQuery();                        
                    //cn1.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message,
                     "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //if (cn1!=null)
            //if (cn1.State == ConnectionState.Open) cn1.Close();
        }

        private void _crear_actualiza_dbf()
        {
            //OleDbConnection cn1=null;
            //OleDbCommand cmd1=null;
            //OleDbCommand cmd2=null;
            //OleDbCommand cmd3=null;
            try
            {
                string _validatxt = txtdni.Text.Trim();
                if (_validatxt.Length != 0 && _validatxt != "Error!")
                {
                    string _dniruc = txtdni.Text.Trim();
                    string _nombre = txtnombres.Text.Trim();
                    string _apepat = txtapepat.Text.Trim();
                    string _apemat = txtapemat.Text.Trim();
                    string _direccion = txtdireccion.Text.Trim();
                    string _telefono = txttelefono.Text.Trim();
                    string _email = txtemail.Text.Trim();
                    string _ubigeo = txtubigeo.Text.Trim();

                    _nombre = _nombre.Replace(",", " ");
                    _apepat = _apepat.Replace(",", " ");
                    _apemat = _apemat.Replace(",", " ");
                    _direccion = _direccion.Replace(",", " ");
                    _telefono = _telefono.Replace(",", " ");
                    _email = _email.Replace(",", " ");
                    _ubigeo = _ubigeo.Replace(",", " ");

                        string _ruta_txt = @"D:\Cons\Cliente";
                        if (!Directory.Exists(@_ruta_txt))
                        {
                            Directory.CreateDirectory(@_ruta_txt);
                        }
                        string _ruta_archivo = _ruta_txt + "\\WsClient.txt";

                        if (File.Exists(@_ruta_archivo))
                        {
                            File.Delete(@_ruta_archivo);
                        }

                        TextWriter tw = new StreamWriter(@_ruta_archivo, true);
                        tw.WriteLine('\u0022' +_dniruc + '\u0022' + "," + '\u0022' + _nombre + '\u0022' + "," + '\u0022' + _apepat + '\u0022' + "," + '\u0022' + _apemat + '\u0022' + "," + '\u0022' + _direccion + '\u0022' + "," + '\u0022' + _telefono + '\u0022' + "," + '\u0022' + _email + '\u0022' + "," + '\u0022' + _ubigeo + '\u0022');
                        tw.Flush();
                        tw.Close();
                        tw.Dispose();

                        //string _query_create_dbf = "Create Table WsClient (dniruc C(11), nombres C(100),apepat C(80),apemat C(80),direc C(200),telef C(50),email C(80))";
                        //string _query_insert_dbf = "Insert Into WsClient(dniruc,nombres,apepat,apemat,direc,telef,email) " +
                        //"Values (?,?,?,?,?,?,?)";
                        //cn1 = new OleDbConnection("Provider=VFPOLEDB.1;Data Source=" + @_ruta_dbf + ";");
                        //cn1.Open();
                        ////'-- Make some VFP data to play with
                        //cmd1 = new OleDbCommand(_query_create_dbf, cn1);
                        //cmd2 = new OleDbCommand(_query_insert_dbf, cn1);

                        
                        //cmd2.CommandType = CommandType.Text;
                        //cmd2.Parameters.AddWithValue("dniruc", _dniruc);
                        //cmd2.Parameters.AddWithValue("nombres", _nombre);
                        //cmd2.Parameters.AddWithValue("apepat", _apepat);
                        //cmd2.Parameters.AddWithValue("apemat", _apemat);
                        //cmd2.Parameters.AddWithValue("direc", _direccion);
                        //cmd2.Parameters.AddWithValue("telef", _telefono);
                        //cmd2.Parameters.AddWithValue("email", _email);

                        //cmd1.ExecuteNonQuery();
                        //cmd2.ExecuteNonQuery();                        
                        //cn1.Close();
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message,
                     "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //if (cn1!=null)
            //if (cn1.State == ConnectionState.Open) cn1.Close();
        }
        private void DisplayLoginScreen()
        {
            ///
             Login  frm = new Login();
            ///
            frm.Owner = this;
            frm.ShowDialog();
            ///
            if (frm.DialogResult.HasValue && frm.DialogResult.Value)
            {
                ///
                //this.loadUserInSesion(frm.getUser());
            }
            else
                this.Close();
        }
        private void btCloseSesion_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        private void txtdniruc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
            {
                e.Handled = true;
            }

            if (e.Key == Key.Enter)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                btconsulta_Click(btconsulta, new RoutedEventArgs());
                //_consulta_dni_ruc();
                //_crear_actualiza_dbf();
                //isLoading();                           
                Mouse.OverrideCursor = null;
            }

        }

        private void btconsulta_Click(object sender, RoutedEventArgs e)
        {       
            try
            {
            Mouse.OverrideCursor = Cursors.Wait;
            limpiar_objec();
            string _dni_ruc = txtdniruc.Text;
            if (_dni_ruc.Length == 0)
            {
                MessageBox.Show("Ingrese el numero DNI ó RUC",
                      "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    Mouse.OverrideCursor = null;
                    return;
            }

            if (_dni_ruc.Length != 8 && _dni_ruc.Length != 11)
            {
                MessageBox.Show("El numero DNI ó RUC es incorrecto",
                      "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    Mouse.OverrideCursor = null;
                    return;
            }

            pn1.Visibility = Visibility.Visible;
            lblmsg.Visibility = Visibility.Visible;
            txtdniruc.IsEnabled = false;
            btconsulta.IsEnabled = false;
            _trabajo = new BackgroundWorker();
            _trabajo.WorkerReportsProgress = false;
            _trabajo.DoWork += (obj, ea) => _loading_procesos(_dni_ruc);
            _trabajo.ProgressChanged += new ProgressChangedEventHandler(progressReport);
            _trabajo.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerComplete);
            _trabajo.RunWorkerAsync();

            }
            catch(Exception exc)
            {
                limpiar_objec();
             MessageBox.Show(exc.Message,
                 "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Mouse.OverrideCursor = null;
        }
        void workerComplete(object sender,RunWorkerCompletedEventArgs e)
        {
            txtdniruc.IsEnabled = true;
            btconsulta.IsEnabled = true;
            print_data(txtdniruc.Text, dtdni);
            pn1.Visibility = Visibility.Collapsed;
            lblmsg.Visibility = Visibility.Collapsed;

            if (/*nuevo_bataclub &&*/ txtdni.Text.Length>0)
            {
                /*promocion automatica solo para registros nuevos*/
                //getpromo_bata = new PromBata();

                PromBata ejebata = new PromBata();

                getpromo_bata = ejebata.lista("01",_tienda,txtdni.Text.Trim());

            }

            if (no_existe_cl_bata)
            {
                /*promocion automatica solo para registros nuevos*/
                //getpromo_bata = new PromBata();

                PromBata ejebata = new PromBata();

                getpromo_bata = ejebata.lista("02", _tienda, txtdni.Text.Trim());


            }

            if (getpromo_bata != null)
            {
                if (getpromo_bata.valida)
                {
                    btnactualizar.Content = "Generar";
                    MessageBox.Show("El cliente tiene descuento especial [BATACLUB], Generar Cupon",
                       "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }

            if (RegistradoEnFlujosBataClub)
            { 
                MessageBox.Show("Cliente ya es miembro de BATACLUB.",
                            "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            //else
            //{
            //    //if (nuevo_bataclub)
            //    //{ 
            //        if (getpromo_bata!=null)
            //        {
            //            if (getpromo_bata.valida)
            //            {
            //                btnactualizar.Content = "Generar";
            //                MessageBox.Show("El cliente tiene descuento especial [BATACLUB], Generar Cupon",
            //                   "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Information);
            //            }
            //        }
            //    //}
            //    //var getpromo=
            //}

        }
        void progressReport(Object sender,ProgressChangedEventArgs e)
        {

        }
        private void _loading_procesos(string _dni_ruc)
        {
            _consulta_dni_ruc_loading(_dni_ruc);
            //_crear_actualiza_dbf_loading();
        }



        //public void isLoading()
        //{
        //    if (meLoader.Visibility == Visibility.Hidden)
        //        meLoader.Visibility = Visibility.Visible;
        //    else
        //        meLoader.Visibility = Visibility.Hidden;
        //}
        private void limpiar_objec()
        {
            no_existe_cl_bata = false;
            nuevo_bataclub = false;
            btnactualizar.Content = "Actualizar";
            getpromo_bata = null;
            dg1.ItemsSource = null;
            txtdni.Text = "";
            txtnombres.Text = "";
            txtapepat.Text = "";
            txtdireccion.Text = "";
            txtapemat.Text = "";
            txtemail.Text = "";
            txttelefono.Text = "";
            txtubigeo.Text = "";
            btnactualizar.IsEnabled = false;
            txttelefono.IsReadOnly = true;
            txtemail.IsReadOnly = true;
            txtnombres.IsReadOnly = true;
            txtapemat.IsReadOnly = true;
            txtapepat.IsReadOnly = true;

            txtemail.Background = Brushes.White;
            txttelefono.Background = Brushes.White;        
            txtnombres.Background = Brushes.White;
            txtapemat.Background = Brushes.White;
            txtapepat.Background = Brushes.White;


            btnactualizar.IsEnabled = false;
            txttelefono.IsReadOnly = true;
            txtemail.IsReadOnly = true;

            txtemail.Background = Brushes.White;
            txttelefono.Background = Brushes.White;

            pn1.Visibility = Visibility.Collapsed;
            lblmsg.Visibility = Visibility.Collapsed;

            dtdni = null;
            dtruc = null;
            dtruc2 = null;

            txtdniruc.IsEnabled = true;
            btconsulta.IsEnabled = true;

            _reniec_sunat = false;
            RegistradoEnFlujosBataClub = false;
        }
        private void consulta_cupones_dni(string dni)
        {
            Bata.ws_clientedniruc.Cons_ClienteSoapClient ws_cliente =null ;// new Bata.ws_clientedniruc.Cons_ClienteSoapClient();
            try
            {
                ws_cliente= new Bata.ws_clientedniruc.Cons_ClienteSoapClient();
                var listar = ws_cliente.ws_buscar_barra_dni(dni);
                if (listar != null)
                {
                    dg1.ItemsSource = listar;
                }
            }
            catch
            {
                ws_cliente = null;
            }
        }
        private void print_data(string _dniruc,DataTable dt)
        {
           /*CONSULTAR CUPONES ACTIVOS POR DNI*/
           //if (RegistradoEnFlujosBataClub)
           // {
                consulta_cupones_dni(_dniruc);
            //}
           /**/
            tabcliente.SelectedIndex = 0;
            this.tabcliente.UpdateLayout();
            switch (_dniruc.Length)
            {
                case 8:
                    if (dtdni != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            txtdni.Text = dt.Rows[0]["fc_ruc"].ToString();
                            txtnombres.Text = dt.Rows[0]["fc_nomb"].ToString();
                            txtapepat.Text = dt.Rows[0]["fc_apep"].ToString();
                            txtapemat.Text = dt.Rows[0]["fc_apem"].ToString();
                            txttelefono.Text = dt.Rows[0]["fc_tele"].ToString();
                            txtemail.Text = dt.Rows[0]["fc_mail"].ToString();
                            txtdireccion.Text = dt.Rows[0]["fc_dcli"].ToString();
                            txtubigeo.Text = dt.Rows[0]["fc_cubi"].ToString();

                            //if (!_reniec_sunat)
                            //{
                            //    txtnombres.IsReadOnly = false;
                            //    txtapemat.IsReadOnly = false;
                            //    txtapepat.IsReadOnly = false;

                            //    txtnombres.Background = Brushes.Khaki;
                            //    txtapemat.Background = Brushes.Khaki;
                            //    txtapepat.Background = Brushes.Khaki;
                            //}

                        }
                        else
                        {
                            CaptionResul();
                        }
                    }
                    else
                    {
                        CaptionResul();
                    }
                    break;
                case 11:                                        
                    if (dtruc != null)
                    {
                        if (dtruc.Rows.Count > 0)
                        {
                            txtdni.Text = dtruc.Rows[0]["fc_ruc"].ToString();
                            txtnombres.Text = dtruc.Rows[0]["fc_nomb"].ToString();
                            txtapepat.Text = dtruc.Rows[0]["fc_apep"].ToString();
                            txtapemat.Text = dtruc.Rows[0]["fc_apem"].ToString();
                            txttelefono.Text = dtruc.Rows[0]["fc_tele"].ToString();
                            txtemail.Text = dtruc.Rows[0]["fc_mail"].ToString();
                            txtdireccion.Text = dtruc.Rows[0]["fc_dcli"].ToString();
                            txtubigeo.Text = dtruc.Rows[0]["fc_cubi"].ToString();
                            if (!_reniec_sunat)
                            {
                                txtnombres.IsReadOnly = false;
                                txtapemat.IsReadOnly = false;
                                txtapepat.IsReadOnly = false;

                                txtnombres.Background = Brushes.Khaki;
                                txtapemat.Background = Brushes.Khaki;
                                txtapepat.Background = Brushes.Khaki;
                            }
                        }
                        else
                        {                           
                            if (dtruc2 != null)
                            {
                                if (dtruc2.Rows.Count == 0)
                                {
                                    MessageBox.Show("hubo un problema con la web service Bata",
                                    "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                }
                                else
                                {

                                    if (dtruc2.Rows[0]["nombres"].ToString() == "Error!")
                                    {
                                        MessageBox.Show("hubo un problema con la consulta, intente de nuevo o verifique el numero de ruc",
                                    "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                    }
                                    else
                                    {
                                        this.txtdireccion.Text = dtruc2.Rows[0]["direccion"].ToString();
                                        this.txtnombres.Text = dtruc2.Rows[0]["nombres"].ToString();
                                        this.txtdni.Text = txtdniruc.Text;
                                        this.txttelefono.Text = dtruc2.Rows[0]["telefono"].ToString();
                                        if (!_reniec_sunat)
                                        {
                                            txtnombres.IsReadOnly = false;
                                            txtapemat.IsReadOnly = false;
                                            txtapepat.IsReadOnly = false;

                                            txtnombres.Background = Brushes.Khaki;
                                            txtapemat.Background = Brushes.Khaki;
                                            txtapepat.Background = Brushes.Khaki;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("hubo un problema con la web service Bata",
                                "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                            }
                        }
                    }
                    else
                    {
                       
                        if (dtruc2 != null)
                        {
                            if (dtruc2.Rows.Count == 0)
                            {
                                MessageBox.Show("hubo un problema con la web service Bata",
                                "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            }
                            else
                            {

                                if (dtruc2.Rows[0]["nombres"].ToString() == "Error!")
                                {
                                    MessageBox.Show("hubo un problema con la consulta, intente de nuevo o verifique el numero de ruc",
                                "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                }
                                else
                                {
                                    this.txtdireccion.Text = dtruc2.Rows[0]["direccion"].ToString();
                                    this.txtnombres.Text = dtruc2.Rows[0]["nombres"].ToString();
                                    this.txtdni.Text = txtdniruc.Text;
                                    this.txttelefono.Text = dtruc2.Rows[0]["telefono"].ToString();

                                    if (!_reniec_sunat)
                                    {
                                        txtnombres.IsReadOnly = false;
                                        txtapemat.IsReadOnly = false;
                                        txtapepat.IsReadOnly = false;

                                        txtnombres.Background = Brushes.Khaki;
                                        txtapemat.Background = Brushes.Khaki;
                                        txtapepat.Background = Brushes.Khaki;
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("hubo un problema con la web service Bata",
                            "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                        }
                    }
                    break;
            }

          

            txtdniruc.SelectAll();
            txtdniruc.Focus();
            if (txtdni.Text.Trim().Length > 0)
            {

                txtemail.Background = Brushes.Khaki;
                txttelefono.Background = Brushes.Khaki;
                txtemail.IsReadOnly = false;
                txttelefono.IsReadOnly = false;

                if (txtemail.Text.Trim().Length > 0 || txttelefono.Text.Trim().Length > 0)
                {
                    btnactualizar.IsEnabled = true;
                }
            }
            if (txtnombres.Background == Brushes.Khaki) txtnombres.Focus();

        }

        private void _consulta_dni_ruc_loading(string _dni_ruc)
        {
           
            dtdni = null;
            dtruc = null;
            dtruc2 = null;
            _reniec_sunat = false;
            try
            {

                //vamos a buscar web service reniec

                //if (!(Clientes._persona_reniec == null))
                //{
                if (_dni_ruc.Length == 8)
                {
                    no_existe_cl_bata = false;
                    //en este lado de codigo , verifificamos la web service de bata antes de consultar en reniec
                    DataTable dt = Clientes._consultacliente(_dni_ruc,ref RegistradoEnFlujosBataClub,ref nuevo_bataclub,ref no_existe_cl_bata);
                    dtdni = dt;
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {                          
                            //txtdni.Text = dt.Rows[0]["fc_ruc"].ToString();
                            //txtnombres.Text = dt.Rows[0]["fc_nomb"].ToString();
                            //txtapepat.Text = dt.Rows[0]["fc_apep"].ToString();
                            //txtapemat.Text = dt.Rows[0]["fc_apem"].ToString();
                            //txttelefono.Text = dt.Rows[0]["fc_tele"].ToString();
                            //txtemail.Text = dt.Rows[0]["fc_mail"].ToString();
                            //txtdireccion.Text = dt.Rows[0]["fc_dcli"].ToString();
                            //txtubigeo.Text = dt.Rows[0]["fc_cubi"].ToString();

                        }
                        else
                        {
                            PersonaReniec myInfo = new PersonaReniec(true); //Clientes._persona_reniec;                                
                                                                        //myInfo.GetInfo(_dni_ruc, Clientes._str_codigo_captcha_reniec);
                            DataTable dt2 = Clientes._consultaReniec(_dni_ruc);

                            myInfo.GetInfo(dt2);
                            Clientes._persona_reniec = myInfo;
                            _reniec_sunat = true;
                            //CaptionResul();
                            //}
                            //Mouse.OverrideCursor = null;
                        }
                    }
                    else
                    {
                        PersonaReniec myInfo = new PersonaReniec(true); //Clientes._persona_reniec;                                
                                                                    //myInfo.GetInfo(_dni_ruc, Clientes._str_codigo_captcha_reniec);
                        DataTable dt2 = Clientes._consultaReniec(_dni_ruc);

                        myInfo.GetInfo(dt2);
                        Clientes._persona_reniec = myInfo;

                        _reniec_sunat = true;
                        //CaptionResul();
                    }

                    //********************************

                }
                else
                {
                    //Boolean existe_cl_bata = false;
                    DataTable dt1 = Clientes._consultacliente(_dni_ruc,ref RegistradoEnFlujosBataClub,ref nuevo_bataclub,ref no_existe_cl_bata);
                    dtruc = dt1;
                    if (dt1 != null)
                    {
                        if (dt1.Rows.Count > 0)
                        {
                            //txtdni.Text = dt1.Rows[0]["fc_ruc"].ToString();
                            //txtnombres.Text = dt1.Rows[0]["fc_nomb"].ToString();
                            //txtapepat.Text = dt1.Rows[0]["fc_apep"].ToString();
                            //txtapemat.Text = dt1.Rows[0]["fc_apem"].ToString();
                            //txttelefono.Text = dt1.Rows[0]["fc_tele"].ToString();
                            //txtemail.Text = dt1.Rows[0]["fc_mail"].ToString();
                            //txtdireccion.Text = dt1.Rows[0]["fc_dcli"].ToString();
                            //txtubigeo.Text = dt1.Rows[0]["fc_cubi"].ToString();
                        }
                        else
                        {
                            DataTable dt = Clientes._consultaSunat(_dni_ruc);
                            dtruc2 = dt;
                            if (dt != null)
                            {
                                if (dt.Rows.Count == 0)
                                {
                                    //MessageBox.Show("hubo un problema con la web service Bata",
                                    //"Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                }
                                else
                                {

                                    if (dt.Rows[0]["nombres"].ToString() == "Error!")
                                    {
                                    //    MessageBox.Show("hubo un problema con la consulta, intente de nuevo o verifique el numero de ruc",
                                    //"Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                    }
                                    else
                                    {
                                        _reniec_sunat = true;
                                        //this.txtdireccion.Text = dt.Rows[0]["direccion"].ToString();
                                        //this.txtnombres.Text = dt.Rows[0]["nombres"].ToString();
                                        //this.txtdni.Text = txtdniruc.Text;
                                        //this.txttelefono.Text = dt.Rows[0]["telefono"].ToString();
                                    }
                                }
                            }
                            else
                            {
                                //MessageBox.Show("hubo un problema con la web service Bata",
                                //"Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                            }
                        }
                    }
                    else
                    {
                        DataTable dt = Clientes._consultaSunat(_dni_ruc);
                        dtruc2 = dt;
                        if (dt != null)
                        {
                            if (dt.Rows.Count == 0)
                            {
                                //MessageBox.Show("hubo un problema con la web service Bata",
                                //"Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            }
                            else
                            {

                                if (dt.Rows[0]["nombres"].ToString() == "Error!")
                                {
                                //    MessageBox.Show("hubo un problema con la consulta, intente de nuevo o verifique el numero de ruc",
                                //"Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                }
                                else
                                {
                                    _reniec_sunat = true;
                                    //this.txtdireccion.Text = dt.Rows[0]["direccion"].ToString();
                                    //this.txtnombres.Text = dt.Rows[0]["nombres"].ToString();
                                    //this.txtdni.Text = txtdniruc.Text;
                                    //this.txttelefono.Text = dt.Rows[0]["telefono"].ToString();
                                }
                            }
                        }
                        else
                        {
                            //MessageBox.Show("hubo un problema con la web service Bata",
                            //"Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                        }
                    }

                    //Mouse.OverrideCursor = null;
                }
                //if (dtdni == null) nuevo_bataclub = false;
                //if (dtruc == null) nuevo_bataclub = false;
                //if (dtruc2 == null) nuevo_bataclub = false;
                //if (dtdni!=null)
                //{
                //    if (dtdni.Rows.Count==0) nuevo_bataclub = false;
                //}
                //if (dtruc != null)
                //{
                //    if (dtruc.Rows.Count == 0) nuevo_bataclub = false;
                //}
                //if (dtruc2 != null)
                //{
                //    if (dtruc2.Rows.Count == 0) nuevo_bataclub = false;
                //}

                /*en este caso si el cliente es nuevo*/
                //if (nuevo_bataclub)
                //{
                //    /*promocion automatica solo para registros nuevos*/
                //    //getpromo_bata = new PromBata();

                //    PromBata ejebata = new PromBata();

                //    getpromo_bata = ejebata.lista("01");

                //}
                //txtdniruc.SelectAll();
                //txtdniruc.Focus();
            }
            catch (Exception exc)
            {
                throw;
                //MessageBox.Show(exc.Message,
                // "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //if (txtdni.Text.Trim().Length > 0)
            //{

            //    txtemail.Background = Brushes.Khaki;
            //    txttelefono.Background = Brushes.Khaki;
            //    txtemail.IsReadOnly = false;
            //    txttelefono.IsReadOnly = false;

            //    if (txtemail.Text.Trim().Length > 0 || txttelefono.Text.Trim().Length > 0)
            //    {
            //        btnactualizar.IsEnabled = true;
            //    }
            //}
            //Mouse.OverrideCursor = null;
        }
       

        private void _consulta_dni_ruc()
        {
          
            Mouse.OverrideCursor = Cursors.Wait;
            limpiar_objec();
            string _dni_ruc = txtdniruc.Text;
            if (_dni_ruc.Length == 0)
            { 
                MessageBox.Show("Ingrese el numero DNI ó RUC",
                      "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                Mouse.OverrideCursor = null;
                return;
            }

            if (_dni_ruc.Length != 8 && _dni_ruc.Length != 11)
            {
                MessageBox.Show("El numero DNI ó RUC es incorrecto",
                      "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                Mouse.OverrideCursor = null;
                return;
            }

            
         
            try
            {      
          
                //vamos a buscar web service reniec

                //if (!(Clientes._persona_reniec == null))
                //{
                    if (_dni_ruc.Length == 8)
                    {
                        
                        //en este lado de codigo , verifificamos la web service de bata antes de consultar en reniec
                        DataTable dt = Clientes._consultacliente(_dni_ruc,ref RegistradoEnFlujosBataClub,ref nuevo_bataclub,ref no_existe_cl_bata);
                        
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                txtdni.Text = dt.Rows[0]["fc_ruc"].ToString();
                                txtnombres.Text = dt.Rows[0]["fc_nomb"].ToString();
                                txtapepat.Text = dt.Rows[0]["fc_apep"].ToString();
                                txtapemat.Text = dt.Rows[0]["fc_apem"].ToString();
                                txttelefono.Text = dt.Rows[0]["fc_tele"].ToString();
                                txtemail.Text = dt.Rows[0]["fc_mail"].ToString();
                                txtdireccion.Text = dt.Rows[0]["fc_dcli"].ToString();
                                txtubigeo.Text = dt.Rows[0]["fc_cubi"].ToString();

                            if (!_reniec_sunat)
                            {
                                txtnombres.IsReadOnly = false;
                                txtapemat.IsReadOnly = false;
                                txtapepat.IsReadOnly = false;

                                txtnombres.Background = Brushes.Khaki;
                                txtapemat.Background = Brushes.Khaki;
                                txtapepat.Background = Brushes.Khaki;
                            }

                        }
                            else
                            {
                                PersonaReniec myInfo = new PersonaReniec(); //Clientes._persona_reniec;                                
                                //myInfo.GetInfo(_dni_ruc, Clientes._str_codigo_captcha_reniec);
                                DataTable dt2 = Clientes._consultaReniec(_dni_ruc);                               

                                myInfo.GetInfo(dt2);
                                Clientes._persona_reniec = myInfo;
                                CaptionResul();
                                //}
                                Mouse.OverrideCursor = null;
                            }
                        }

                        //********************************
                     
                    }
                    else
                    {

                        DataTable dt1 = Clientes._consultacliente(_dni_ruc,ref RegistradoEnFlujosBataClub,ref nuevo_bataclub,ref no_existe_cl_bata);
                        if (dt1 != null)
                        {
                            if (dt1.Rows.Count > 0)
                            {
                                txtdni.Text = dt1.Rows[0]["fc_ruc"].ToString();
                                txtnombres.Text = dt1.Rows[0]["fc_nomb"].ToString();
                                txtapepat.Text = dt1.Rows[0]["fc_apep"].ToString();
                                txtapemat.Text = dt1.Rows[0]["fc_apem"].ToString();
                                txttelefono.Text = dt1.Rows[0]["fc_tele"].ToString();
                                txtemail.Text = dt1.Rows[0]["fc_mail"].ToString();
                                txtdireccion.Text = dt1.Rows[0]["fc_dcli"].ToString();
                                txtubigeo.Text = dt1.Rows[0]["fc_cubi"].ToString();

                                if (!_reniec_sunat)
                                {
                                    txtnombres.IsReadOnly = false;
                                    txtapemat.IsReadOnly = false;
                                    txtapepat.IsReadOnly = false;

                                    txtnombres.Background = Brushes.Khaki;
                                    txtapemat.Background = Brushes.Khaki;
                                    txtapepat.Background = Brushes.Khaki;                              
                                }   
                            }
                            else
                            {
                                DataTable dt = Clientes._consultaSunat(_dni_ruc);

                                if (dt != null)
                                {
                                    if (dt.Rows.Count == 0)
                                    {
                                        MessageBox.Show("hubo un problema con la web service Bata",
                                        "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                    }
                                    else
                                    {

                                        if (dt.Rows[0]["nombres"].ToString() == "Error!")
                                        {
                                            MessageBox.Show("hubo un problema con la consulta, intente de nuevo o verifique el numero de ruc",
                                        "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);                                                                      
                                        }
                                        else
                                        {
                                            this.txtdireccion.Text = dt.Rows[0]["direccion"].ToString();
                                            this.txtnombres.Text = dt.Rows[0]["nombres"].ToString();
                                            this.txtdni.Text = txtdniruc.Text;
                                            this.txttelefono.Text = dt.Rows[0]["telefono"].ToString();

                                        if (!_reniec_sunat)
                                        {
                                            txtnombres.IsReadOnly = false;
                                            txtapemat.IsReadOnly = false;
                                            txtapepat.IsReadOnly = false;

                                            txtnombres.Background = Brushes.Khaki;
                                            txtapemat.Background = Brushes.Khaki;
                                            txtapepat.Background = Brushes.Khaki;
                                        }

                                    }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("hubo un problema con la web service Bata",
                                    "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                                }
                            }
                        }
                        else
                        {
                            DataTable dt = Clientes._consultaSunat(_dni_ruc);

                            if (dt != null)
                            {
                                if (dt.Rows.Count == 0)
                                {
                                    MessageBox.Show("hubo un problema con la web service Bata",
                                    "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                }
                                else
                                {

                                    if (dt.Rows[0]["nombres"].ToString() == "Error!")
                                    {
                                        MessageBox.Show("hubo un problema con la consulta, intente de nuevo o verifique el numero de ruc",
                                    "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);                                                                       
                                    }
                                    else
                                    {
                                        this.txtdireccion.Text = dt.Rows[0]["direccion"].ToString();
                                        this.txtnombres.Text = dt.Rows[0]["nombres"].ToString();
                                        this.txtdni.Text = txtdniruc.Text;
                                        this.txttelefono.Text = dt.Rows[0]["telefono"].ToString();

                                            if (!_reniec_sunat)
                                            {
                                                txtnombres.IsReadOnly = false;
                                                txtapemat.IsReadOnly = false;
                                                txtapepat.IsReadOnly = false;

                                                txtnombres.Background = Brushes.Khaki;
                                                txtapemat.Background = Brushes.Khaki;
                                                txtapepat.Background = Brushes.Khaki;
                                            }
                                }
                                }
                            }
                            else
                            {
                                MessageBox.Show("hubo un problema con la web service Bata",
                                "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                            }
                        }                                           

                        Mouse.OverrideCursor = null;
                    }
               
                txtdniruc.SelectAll();
                txtdniruc.Focus();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message,
                 "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (txtdni.Text.Trim().Length > 0)
            {
               
                txtemail.Background = Brushes.Khaki;
                txttelefono.Background = Brushes.Khaki;
                txtemail.IsReadOnly = false;
                txttelefono.IsReadOnly = false;

                if (txtemail.Text.Trim().Length > 0 || txttelefono.Text.Trim().Length > 0)
                {
                    btnactualizar.IsEnabled = true;
                }              
            }          
            Mouse.OverrideCursor = null;
        }
        private void CaptionResul()
        {
            PersonaReniec myInfo = Clientes._persona_reniec;
            try
            {

                switch (myInfo.estado_reniec)
                {
                    case 231:
                        txtdni.Text = txtdniruc.Text;
                        txtnombres.Text = myInfo.Nombres;
                        txtapepat.Text = myInfo.ApePaterno;
                        txtapemat.Text = myInfo.ApeMaterno;
                        
                        break;
                    case 222:                        
                        MessageBox.Show("No existe DNI",
                       "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtdniruc.SelectAll();
                        txtdniruc.Focus();
                        break;
                    case 217:
                        if (myInfo.Nombres=="Cancelado por fallecimiento.")
                        {
                            MessageBox.Show(myInfo.Nombres,
                        "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                        else
                        {
                        MessageBox.Show("Vuelva a intentarlo",
                        "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        txtdniruc.SelectAll();
                        txtdniruc.Focus();
                        break;
                    case 0:
                        MessageBox.Show("1. No se encuentra sus datos en nuestra base de datos \r\n2. Hay un Error en la Web Service RENIEC... \r\n \r\nPOR FAVOR INGRESE MANUALMENTE LOS DATOS EN LAS CASILLAS SOMBREADAS",
                       "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        txtnombres.Background = Brushes.Khaki;
                        txtapepat.Background = Brushes.Khaki;
                        txtapemat.Background = Brushes.Khaki;
                        txtemail.Background = Brushes.Khaki;
                        txttelefono.Background = Brushes.Khaki;
                        txtdni.Text = txtdniruc.Text;
                        txttelefono.IsReadOnly = false;
                        txtemail.IsReadOnly = false;
                        txtnombres.IsReadOnly = false;
                        txtapepat.IsReadOnly = false;
                        txtapemat.IsReadOnly = false;


                        //txtdniruc.SelectAll();
                        //txtdniruc.Focus();
                        txtnombres.Focus();
                        //txtdniruc.SelectAll();
                        //txtdniruc.Focus();
                        break;
                        //MessageBox.Show("Web Service de Reniec esta INACTIVO",
                        //"Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
                        //txtdniruc.SelectAll();
                        //txtdniruc.Focus();
                        //break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btBackPanelLiq_Click(object sender, RoutedEventArgs e)
        {
            Principal maw = new Principal();
            ///
            maw.Show();
            this.Close();
            ///
            
        }
        private static void _limpiar_txt(string _ruta)
        {

            try
            {
                string[] _file = Directory.GetFiles(@_ruta, "*.*");

                foreach (string f in _file)
                {
                    // Remove path from the file name.                  
                    File.Delete(f.ToString());
                }
            }
            catch
            {

            }
        }
        private void _crear__actualiza_dbf(CuponGenerado cupongen)
        {
            
            try
            {


                string _validatxt = txtdni.Text.Trim();
                if (_validatxt.Length != 0 && _validatxt != "Error!")
                {
                    string _dniruc = txtdni.Text.Trim();
                    string _nombre = txtnombres.Text.Trim();
                    string _apepat = txtapepat.Text.Trim();
                    string _apemat = txtapemat.Text.Trim();
                    string _direccion = txtdireccion.Text.Trim();
                    string _telefono = txttelefono.Text.Trim();
                    string _email = txtemail.Text.Trim();
                    string _ubigeo = txtubigeo.Text.Trim();

                    _nombre = _nombre.Replace(",", " ");
                    _apepat = _apepat.Replace(",", " ");
                    _apemat = _apemat.Replace(",", " ");
                    _direccion = _direccion.Replace(",", " ");
                    _telefono = _telefono.Replace(",", " ");
                    _email = _email.Replace(",", " ");
                    _ubigeo = _ubigeo.Replace(",", " ");

                    string _ruta_txt = @"D:\Cons\Vales\in";
                    string _ruta_txt_out = @"D:\Cons\Vales\out";
                    if (!Directory.Exists(@_ruta_txt))
                    {
                        Directory.CreateDirectory(@_ruta_txt);
                    }
                    if (!Directory.Exists(@_ruta_txt_out))
                    {
                        Directory.CreateDirectory(@_ruta_txt_out);
                    }
                    string _ruta_archivo = _ruta_txt + "\\" + cupongen.correlativo.ToString() + ".txt";

                    if (File.Exists(@_ruta_archivo))
                    {
                        File.Delete(@_ruta_archivo);
                    }

                    _limpiar_txt(_ruta_txt);

                    


                    TextWriter tw = new StreamWriter(@_ruta_archivo, true);
                    tw.WriteLine(cupongen.serie + "," + "P" + "," + Convert.ToInt32(cupongen.pordes).ToString() + "," + cupongen.paresmax.ToString() + "," + _dniruc + "," + _nombre + "," + _apepat + "," + _apemat + "," + _direccion + "," + _telefono + "," + _email + "," + _ubigeo + ",,,," + cupongen.tipcup);


                    /*En este proceso vamos a crear el dbf y actualizar o insertar*/
                    DataTable dt_dbf = new DataTable();
                    dt_dbf.Columns.Add("serie", typeof(string));
                    dt_dbf.Columns.Add("numero", typeof(string));
                    dt_dbf.Columns.Add("dni", typeof(string));
                    dt_dbf.Columns.Add("nombres", typeof(string));
                    dt_dbf.Columns.Add("apepat", typeof(string));
                    dt_dbf.Columns.Add("apemat", typeof(string));
                    dt_dbf.Columns.Add("telefono", typeof(string));
                    dt_dbf.Columns.Add("email", typeof(string));
                    dt_dbf.Rows.Add(cupongen.serie,cupongen.correlativo.ToString(), _dniruc, _nombre, _apepat, _apemat, _telefono, _email);


                    Boolean tempdbf = Basico._generadbf__ins_upd(dt_dbf);


                    tw.Flush();
                    tw.Close();
                    tw.Dispose();
                    btnactualizar.IsEnabled = false;
                    txtdniruc.IsEnabled = false;
                    //cargar.Visibility = Visibility.Visible;
                    //Process();
                   
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message,
                     "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
        }
        private void btnactualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (txtdni.Text.Trim().Length > 0)
                {
                    if (txtnombres.Background == Brushes.Khaki)
                    {
                        if (txtnombres.Text.Trim().Length == 0)
                        {
                            MessageBox.Show("Ingrese el nombre del cliente",
                                      "Administrador del Sistema", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            txtnombres.Focus();
                            Mouse.OverrideCursor = null;
                            return;
                        }
                        if (txtapepat.Text.Trim().Length == 0)
                        {
                            MessageBox.Show("Ingrese el apellido paterno del cliente",
                                      "Administrador del Sistema", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            txtapepat.Focus();
                            Mouse.OverrideCursor = null;
                            return;

                        }
                        if (txtemail.Text.Trim().Length > 0)
                        {
                            if (!Clientes.ComprobarFormatoEmail(txtemail.Text))
                            {
                                MessageBox.Show("El formato del Email. es incorrecto",
                                          "Administrador del Sistema", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                txtemail.Focus();
                                Mouse.OverrideCursor = null;
                                return;
                            }
                        }
                      
                       // return;
                    }
                }

                if (txtdni.Text.Trim().Length==0)
            {
                MessageBox.Show("No hay Datos para actualizar.",
                                   "Administrador del Sistema", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }


            if (txttelefono.Text.Trim().Length==0 && txtemail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese el numero de telefono o Email.",
                                  "Administrador del Sistema", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (txtemail.Text.Trim().Length>0)
            { 
                if (!Clientes.ComprobarFormatoEmail(txtemail.Text))
                    {
                        MessageBox.Show("El formato del Email. es incorrecto",
                                  "Administrador del Sistema", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }
            }
                //MessageBoxResult msbResult = MessageBox.Show("¿Realmente desea Actualizar el cliente en nuestra Base de datos ? ",
                //                  "Administrador del Sistema", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                /////
                //if (msbResult == MessageBoxResult.OK)
                //{
            Mouse.OverrideCursor = Cursors.Wait;

            string _ruc = txtdni.Text, _nombres = txtnombres.Text, _apepat = txtapepat.Text, _apemat = txtapemat.Text,
                                            _telefono = txttelefono.Text, _email = txtemail.Text, _tda = "50100";
            string _correo_envio = "";
            string _telef_envia = "";

            #region<REGION DE NUEVOS CLIENTES, GENERAR BARRA Y ENVIAR AL POS>
                //if (nuevo_bataclub)
                //{
                    if (getpromo_bata != null)
                    {
                        if (getpromo_bata.valida)
                        {
                            CuponGenerado set_cupon = new CuponGenerado();
                            set_cupon.nombres_prin = _nombres;
                            set_cupon.nombres = _nombres + " " + _apepat + " " + _apemat;
                            set_cupon.apepat = _apepat;
                            set_cupon.apemat = _apemat;
                            set_cupon.email = _email;
                            set_cupon.dni = _ruc;
                            set_cupon.pordes = getpromo_bata.por_des;
                            set_cupon.fechaini = getpromo_bata.fecha_ini;
                            set_cupon.fechafin = getpromo_bata.fecha_fin;
                            set_cupon.paresmax = getpromo_bata.max_par;
                            set_cupon.grupo = getpromo_bata.nom_prom;
                            set_cupon.tda_gen_cup = _tienda;

                            PromBata prom = new PromBata();
                            CuponGenerado get_cupon = prom.getcupon_generado(set_cupon);

                            if (get_cupon==null)
                            {
                                MessageBox.Show("!Hubo un error al generar el codigo de barra automatico",
                                "Administrador del Sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                                Mouse.OverrideCursor = null;
                                return;
                            }
                            if (get_cupon != null)
                            {
                                if (get_cupon.barra==null || get_cupon.barra.Length==0)
                                {
                                    MessageBox.Show("!Hubo un error al generar el codigo de barra automatico",
                                    "Administrador del Sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                                    Mouse.OverrideCursor = null;
                                    return;
                                }
                                else
                                {
                                /*IMPRIMIR CUPON*/
                                //Basico.Imprime_Bataclub(get_cupon.barra); 
                                /**/
                                _crear__actualiza_dbf(get_cupon);
                                Clientes._actualiza_cliente(_ruc, _nombres, _apepat, _apemat, _telefono, _email, _tienda, ref _correo_envio, ref _telef_envia);
                                    if (_principal != null)
                                    {
                                        _principal.WindowState = WindowState.Minimized;
                                    }
                                    MessageBox.Show("Se genero el cupon Satisfactoriamente,Por favor continue en el sistema POS ",
                                 "Administrador del Sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                                    this.Close();
                                    Mouse.OverrideCursor = null;
                                    return;
                                }
                            }
                        }
                    }
                //}
                #endregion



                string _valida = Clientes._actualiza_cliente(_ruc, _nombres, _apepat, _apemat, _telefono, _email, _tienda, ref _correo_envio, ref _telef_envia);

                //se actualizo datos del cliente se actua    
                string _msg = "Se Actualizo datos del cliente.";
                if (_correo_envio == "1") _msg = "Se Registro el Nuevo cliente y se envio un correo de bienvenida BATACLUB!..";
                if (_correo_envio == "0") _msg = "Se Actualizo el cliente y se envio un correo de BATACLUB!..";

                if (_telef_envia == "1") _msg = "Se Actualizo datos del cliente."; //"Se Registro el Nuevo cliente..";
                if (_telef_envia == "0") _msg = "Cliente ya registrado,se actualizo sólo el dato del teléfono";




                if (_valida.Length == 0)
                {
                    MessageBox.Show(_msg,
                                "Administrador del Sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                    _crear_actualiza_dbf();
                }
                else
                {
                    MessageBox.Show(_valida,
                                "Administrador del Sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                //}
            }
            catch(Exception exc)
            {
                MessageBoxResult msbResult = MessageBox.Show(exc.Message,
                             "Administrador del Sistema", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
            Mouse.OverrideCursor = null;
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            _activo_form = false;
        }

        private void txttelefono_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                btnactualizar.IsEnabled = (txttelefono.Text.Trim().Length == 0) ? false : true;
                if (!btnactualizar.IsEnabled)
                {
                    btnactualizar.IsEnabled = (txtemail.Text.Trim().Length == 0) ? false : true;
                }
            }
            catch
            {

            }
        }

        private void txtemail_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                btnactualizar.IsEnabled = (txtemail.Text.Trim().Length == 0) ? false : true;
                if (!btnactualizar.IsEnabled)
                {
                    btnactualizar.IsEnabled = (txttelefono.Text.Trim().Length == 0) ? false : true;
                }
            }
            catch
            {

            }
        }
    }
}
