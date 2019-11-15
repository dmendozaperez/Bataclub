using System;
using System.Collections.Generic;
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
using Bata.Clases;
using System.Data;
using ConsultReniec;
using System.IO;
using System.ComponentModel;

namespace Bata
{
    /// <summary>
    /// Lógica de interacción para Promocion.xaml
    /// </summary>
    /// 
    public partial class Promocion : Window
    {
        public Promocion()
        {
            InitializeComponent();
        }
       
        public static Window _principal { set; get; }

        BackgroundWorker _trabajo;
        private DataTable dtdni = null;
        private DataTable dtruc = null;
        private DataTable dtruc2 = null;
        private Boolean RegistradoEnFlujosBataClub = false;

        private Boolean _porc = false;
        private string _empruc = "";
        private string _empraz = "";
        private Decimal _monto = 0;
        string _tienda { set; get; }

        private string _serie, _correlativo = "";
        private Int32 _porc_desc = 0;
        private Int32 _pares_max = 0;
        private string _tipo_desc = "";

        private string _tipo_cupon = "";
        public static Boolean _activo_form;
        //http://148.102.50.44/web_site_cliente/Cons_Cliente.asmx
        private void btCloseSesion_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btBackPanelLiq_Click(object sender, RoutedEventArgs e)
        {
            Principal frm = new Principal();
            frm.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cargar.Visibility = Visibility.Hidden;
            tabvale.IsEnabled = true;
            tabcliente.IsEnabled = false;
            limpiar_objec();
            limpiar();
            if (Environment.GetEnvironmentVariable("codtda") != null)
                _tienda = "50" + Environment.GetEnvironmentVariable("codtda").ToString();

            if (_tienda.Length == 0 || _tienda == null) _tienda = "";

            txtbuscar.Focus();
        }
        private void limpiar_objec()
        {
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
            txtapepat.IsReadOnly = true;
            txtapemat.IsReadOnly = true;

            txtemail.Background = Brushes.White;
            txttelefono.Background = Brushes.White;
            txtnombres.Background = Brushes.White;
            txtapepat.Background = Brushes.White;
            txtapemat.Background = Brushes.White;

            pn1.Visibility = Visibility.Collapsed;
            lblmsg.Visibility = Visibility.Collapsed;

            dtdni = null;
            dtruc = null;
            dtruc2 = null;

            txtdniruc.IsEnabled = true;            

        }

        private void print_data(string _dniruc, DataTable dt)
        {
            try
            {          
                switch (_dniruc.Length)
                {
                    case 8:
                    case 9:
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
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message,
                                        "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void _consulta_dni_ruc_loading(string _dni_ruc)
        {

            dtdni = null;
            dtruc = null;
            dtruc2 = null;
            try
            {

                //vamos a buscar web service reniec

                //if (!(Clientes._persona_reniec == null))
                //{
                if (_dni_ruc.Length == 8 || _dni_ruc.Length == 9)
                {
                    Boolean nuevobataclub = false;
                    Boolean existe_cl_bata = false;
                    string barra_cliente = "";
                    //en este lado de codigo , verifificamos la web service de bata antes de consultar en reniec
                    DataTable dt = Clientes._consultacliente(_dni_ruc,ref RegistradoEnFlujosBataClub,ref nuevobataclub,ref existe_cl_bata,ref barra_cliente);
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
                        //CaptionResul();
                    }

                    //********************************

                }
                else
                {
                    Boolean nuevocliente = false;
                    Boolean existe_cl_bata = false;
                    string barra_cliente = "";
                    DataTable dt1 = Clientes._consultacliente(_dni_ruc,ref RegistradoEnFlujosBataClub,ref nuevocliente,ref existe_cl_bata,ref barra_cliente);
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

                //txtdniruc.SelectAll();
                //txtdniruc.Focus();
            }
            catch 
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

        private void limpiar()
        {

            
            _empruc = "";
            _empraz = "";
            _monto = 0;
            _porc = false;
            _serie = "";
            _correlativo = "";
            _porc_desc = 0;
            _pares_max = 0;
            _tipo_desc = "";
            _tipo_cupon = "";
            lblestado.Text = "";
            txtnombre_v.Text = "";
            txtdniruc_v.Text = "";
            txtfecha_v.Text = "";

            txttienda_us.Text = "";
            txtnombre_us.Text = "";
            txtfecha_us.Text = "";
        }

        private void btnbuscar_Click(object sender, RoutedEventArgs e)
        {
           
            buscar();           
        }

        private void txtbuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnbuscar_Click(btnbuscar, new RoutedEventArgs());
            }
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            _activo_form = false;
        }
        public void SoloNumeros(TextCompositionEventArgs e)
        {
            //se convierte a Ascci del la tecla presionada
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            //verificamos que se encuentre en ese rango que son entre el 0 y el 9
            if ((ascci >= 48 && ascci <= 57) || (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122))
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void txtbuscar_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            SoloNumeros(e);
        }

        private void btnactualizar_Click(object sender, RoutedEventArgs e)
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
                    _crear__actualiza_dbf();
                    return;
                }
            }

            if (txtdniruc.Text.Trim().Length>0)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                if (txtemail.Text.Trim().Length > 0)
                {
                    if (!Clientes.ComprobarFormatoEmail(txtemail.Text))
                    {
                        MessageBox.Show("El formato del Email. es incorrecto",
                                  "Administrador del Sistema", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Mouse.OverrideCursor = null;
                        return;
                    }
                }
                _crear__actualiza_dbf();
                Mouse.OverrideCursor = null;
            }
        }
        private void SetProgressText()
        {
            //ProgressText.Content = Progress.Value;
            pbStatus.IsIndeterminate = false;
        }
        private delegate void UpdateProgressBarDelegate(System.Windows.DependencyProperty dp, Object value);
        private void Process()
        {
            //Configure the ProgressBar
            pbStatus.Minimum = 0;
            pbStatus.Maximum = short.MaxValue;
            pbStatus.Value = 0;

            //Stores the value of the ProgressBar
            double value = 0;

            //Create a new instance of our ProgressBar Delegate that points
            //  to the ProgressBar's SetValue method.
            UpdateProgressBarDelegate updatePbDelegate = new UpdateProgressBarDelegate(pbStatus.SetValue);

            //Tight Loop:  Loop until the ProgressBar.Value reaches the max
            do
            {
                //value += 8;
                value += 35;

                /*Update the Value of the ProgressBar:
		          1)  Pass the "updatePbDelegate" delegate that points to the ProgressBar1.SetValue method
			      2)  Set the DispatcherPriority to "Background"
				  3)  Pass an Object() Array containing the property to update (ProgressBar.ValueProperty) and the new value */
                Dispatcher.Invoke(updatePbDelegate,
                    System.Windows.Threading.DispatcherPriority.Background,
                    new object[] { ProgressBar.ValueProperty, value });

            }
            while (pbStatus.Value != pbStatus.Maximum);

            if (pbStatus.Value == pbStatus.Maximum)
            {
                if (_principal!=null)
                {
                    _principal.WindowState = WindowState.Minimized;
                }
                this.Close();
            }

        }
        private void _crear__actualiza_dbf()
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
                    string _ruta_archivo = _ruta_txt + "\\" + _correlativo.ToString() + ".txt";

                    if (File.Exists(@_ruta_archivo))
                    {
                        File.Delete(@_ruta_archivo);
                    }

                    _limpiar_txt(_ruta_txt);

                    //_empruc = dtdatos.Rows[0]["empruc"].ToString().Trim();
                    //_empraz = dtdatos.Rows[0]["empraz"].ToString().Trim();
                    //_monto = Convert.ToDecimal(dtdatos.Rows[0]["MONTOVALE"]);


                    TextWriter tw = new StreamWriter(@_ruta_archivo, true);
                    tw.WriteLine(_serie + "," + ((_monto>0)?"M":"P") + "," + ((_monto > 0) ? Convert.ToInt32(_monto).ToString() : _porc_desc.ToString())  + "," + _pares_max.ToString() + "," + _dniruc + "," + _nombre + "," + _apepat + "," + _apemat + "," + _direccion + "," + _telefono + "," + _email + "," + _ubigeo + "," + _tipo_desc + "," + _empruc + "," + _empraz + "," + _tipo_cupon);


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
                    dt_dbf.Rows.Add(_serie, _correlativo.ToString(), _dniruc, _nombre, _apepat, _apemat, _telefono, _email);

                    #region<BATACLUB CLIENTES>
                    string _correo_envio = "";string _telef_envia = "";
                    string _valida = Clientes._actualiza_cliente(_dniruc, _nombre, _apepat, _apemat, _telefono, _email, _tienda, ref _correo_envio, ref _telef_envia);
                    #endregion

                    Clientes._insertar_cliente_bata(_dniruc, _nombre, _apepat, _apemat, _email, _telefono, _tienda);

                    Boolean tempdbf = Basico._generadbf__ins_upd(dt_dbf);


                    tw.Flush();
                    tw.Close();
                    tw.Dispose();
                    btnactualizar.IsEnabled = false;
                    txtdniruc.IsEnabled = false;
                    cargar.Visibility = Visibility.Visible;
                    Process();
                    //pbStatus.IsIndeterminate = !pbStatus.IsIndeterminate;
                    //pbStatus.MarqueeAnimationSpeed = 0;
                    //if (pbStatus.IsIndeterminate)
                    //{ }
                    ////ProgressText.Content = "";
                    //else { 
                    //    SetProgressText();
                    //}


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
                try
                { 
                    if (validar_buscar)
                    {
                        Mouse.OverrideCursor = null;
                        validar_buscar = false;
                        return;
                    }

                    limpiar_objec();
                    string _dni_ruc = txtdniruc.Text;
                    if (_dni_ruc.Length == 0)
                    {
                        MessageBox.Show("Ingrese el numero DNI ó RUC",
                              "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Mouse.OverrideCursor = null;
                        return;
                    }

                    if (_dni_ruc.Length != 8 && _dni_ruc.Length!=9 && _dni_ruc.Length != 11)
                    {
                        MessageBox.Show("El numero DNI ó RUC es incorrecto",
                              "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Mouse.OverrideCursor = null;
                        return;
                    }

                    pn1.Visibility = Visibility.Visible;
                    lblmsg.Visibility = Visibility.Visible;
                    txtdniruc.IsEnabled = false;                    
                    _trabajo = new BackgroundWorker();
                    _trabajo.WorkerReportsProgress = false;
                    _trabajo.DoWork += (obj, ea) => _loading_procesos(_dni_ruc);
                    _trabajo.ProgressChanged += new ProgressChangedEventHandler(progressReport);
                    _trabajo.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerComplete);
                    _trabajo.RunWorkerAsync();

                    //Mouse.OverrideCursor = Cursors.Wait;
                    //consulta_dni_ruc();
                    //_crear__actualiza_dbf();
                    //isLoading();
                    // Mouse.OverrideCursor = null;
                }
                catch (Exception exc)
                {
                    limpiar_objec();
                    MessageBox.Show(exc.Message,
                        "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Mouse.OverrideCursor = null;
            }
        }
        void workerComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            txtdniruc.IsEnabled = true;
            //btconsulta.IsEnabled = true;
            print_data(txtdniruc.Text, dtdni);
            pn1.Visibility = Visibility.Collapsed;
            lblmsg.Visibility = Visibility.Collapsed;



        }
        void progressReport(Object sender, ProgressChangedEventArgs e)
        {

        }
        private void _loading_procesos(string _dni_ruc)
        {
            try
            { 
                 _consulta_dni_ruc_loading(_dni_ruc);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message,
                "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //_crear_actualiza_dbf_loading();
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
                        if (myInfo.Nombres == "Cancelado por fallecimiento.")
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
                        //MessageBox.Show("Error Desconocido",
                        //"Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
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
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                    Boolean nuevobataclub = false;
                    Boolean existe_cl_bata = false;
                    string barra_cliente = "";
                    //en este lado de codigo , verifificamos la web service de bata antes de consultar en reniec
                    DataTable dt = Clientes._consultacliente(_dni_ruc,ref RegistradoEnFlujosBataClub,ref nuevobataclub,ref existe_cl_bata,ref barra_cliente);
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

                        }
                        else
                        {
                            PersonaReniec myInfo = new PersonaReniec(); //Clientes._persona_reniec;                                
                                                                        //myInfo.GetInfo(_dni_ruc, Clientes._str_codigo_captcha_reniec);
                            DataTable dt2 = Clientes._consultaReniec(_dni_ruc);

                            //if (dt2.Rows.Count>0)
                            //{
                            //    myInfo.Nombres = dt2.Rows[0]["nombres"].ToString();

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
                    Boolean nuevobataclub = false;
                    Boolean existe_cl_bata = false;
                    string barra_cliente = "";
                    DataTable dt1 = Clientes._consultacliente(_dni_ruc,ref RegistradoEnFlujosBataClub,ref nuevobataclub,ref existe_cl_bata,ref barra_cliente);
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
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message,
                 "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            if (txtdni.Text.Trim().Length > 0)
            {
                //if (txtemail.Text.Trim().Length == 0 || txttelefono.Text.Trim().Length == 0)
                //{
                //    txtemail.IsReadOnly = false;
                //    txttelefono.IsReadOnly = false;
                    txtemail.Background = Brushes.Khaki;
                    txttelefono.Background = Brushes.Khaki;
                    txtemail.IsReadOnly = false;
                    txttelefono.IsReadOnly = false;
                    
                    if (txtemail.Text.Trim().Length>0 || txttelefono.Text.Trim().Length>0)
                    {
                        btnactualizar.IsEnabled = true;
                    }

                //btnactualizar.IsEnabled = true;

                //}
                //if (txtemail.Text.Trim().Length > 0 && txttelefono.Text.Trim().Length > 0)
                //{
                //    txtemail.IsReadOnly = false;
                //    txttelefono.IsReadOnly = false;
                //    btnactualizar.IsEnabled = true;
                //}
            }
            Mouse.OverrideCursor = null;
        }

        private void txttelefono_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            { 
               btnactualizar.IsEnabled = (txttelefono.Text.Trim().Length == 0) ? false:true;
               if (!btnactualizar.IsEnabled)
                {
                    btnactualizar.IsEnabled = (txtemail.Text.Trim().Length == 0) ? false : true;
                }
            }
            catch
            {

            }
        }
        private void txtdireccion_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                btnactualizar.IsEnabled = (txtdireccion.Text.Trim().Length == 0) ? false : true;
                if (!btnactualizar.IsEnabled)
                {
                    btnactualizar.IsEnabled = (txttelefono.Text.Trim().Length == 0) ? false : true;
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

        private void buscar()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            limpiar();
            if (txtbuscar.Text.Trim().Length==0)
            {
                Mouse.OverrideCursor = null;
                lblestado.Text = "Ingrese El N° de Vale";
                txtbuscar.Focus();

                return;
            }

            DataSet ds = Clientes._consulta_vales("", txtbuscar.Text.Trim().ToString(), _tienda);

            if (ds==null)
            {
                lblestado.Text = "No hay Conexion en internet";
                txtbuscar.Focus();
            }
            else
            {
                if (ds.Tables.Count==1)
                {
                    DataTable dtvalida = ds.Tables[0];
                    lblestado.Text = dtvalida.Rows[0]["descripcion"].ToString();
                    txtbuscar.Focus();
                }
                else
                {
                    DataTable dtvalida= ds.Tables[0];
                    lblestado.Text = dtvalida.Rows[0]["descripcion"].ToString();
                    DataTable dtdatos= ds.Tables[1];
                    _serie = dtdatos.Rows[0]["serie"].ToString().Trim(); 
                    _correlativo = dtdatos.Rows[0]["correlativo"].ToString().Trim();
                    _porc_desc = Convert.ToInt32(dtdatos.Rows[0]["Porc_Descuento"]);
                    _pares_max = Convert.ToInt32(dtdatos.Rows[0]["pares_max"]);
                    _tipo_desc= dtdatos.Rows[0]["tipo_des"].ToString().Trim();
                    _tipo_cupon= dtdatos.Rows[0]["val_tipcupid"].ToString().Trim();
                    _empruc = dtdatos.Rows[0]["empruc"].ToString().Trim(); 
                    _empraz = dtdatos.Rows[0]["empraz"].ToString().Trim(); 
                    _monto =Convert.ToDecimal(dtdatos.Rows[0]["MONTOVALE"]); 
                    //_porc = false;

                    string _dni_b = dtdatos.Rows[0]["DNI"].ToString().Trim();
                    string _nombres_b = dtdatos.Rows[0]["nombres"].ToString().Trim();
                    string _fecha_b = dtdatos.Rows[0]["fecha_emi"].ToString().Trim();

                    string _tienda_us = dtdatos.Rows[0]["tienda_ven"].ToString().Trim();
                    string _cliente_us = dtdatos.Rows[0]["cliente_venta"].ToString().Trim();
                    string _fecha_us = dtdatos.Rows[0]["fecha_venta"].ToString().Trim();

                    txtdniruc_v.Text = _dni_b;
                    txtnombre_v.Text = _nombres_b;
                    txtfecha_v.Text = _fecha_b;
                    txttienda_us.Text = _tienda_us;
                    txtnombre_us.Text = _cliente_us;
                    txtfecha_us.Text = _fecha_us;
                   
                    string _valida= dtvalida.Rows[0]["estado"].ToString();

                    if (_valida!="3")
                    {
                        if (_monto == 0)
                        {
                            txtbuscar.Text = "";
                            tabvale.IsEnabled = false;
                            tabcliente.IsEnabled = true;
                            tabvalescliente.SelectedIndex = 1;
                            this.tabvalescliente.UpdateLayout();
                            txtdniruc.Focus();
                        }
                        else
                        {
                            lblestado.Text = "El Numero de Vale " + txtbuscar.Text + ", No es Valido en esta ventana.";
                        }
                    }
                }
            }
            
            Mouse.OverrideCursor = null;
        }
        Boolean validar_buscar = false;
       
        private void txtdniruc_TextChanged(object sender, TextChangedEventArgs e)
        {
            validar_buscar = false;
        }

        private void txtbuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _strbuscar = txtbuscar.Text.Trim().ToString();
            if (_strbuscar.Length == 15 || _strbuscar.Length == 18)
            {
                validar_buscar = true;
                buscar();
                //validar_buscar = false;
            }
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
    }
}
