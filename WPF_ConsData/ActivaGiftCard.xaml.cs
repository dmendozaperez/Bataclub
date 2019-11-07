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
using System.Data;
using Bata.Clases;
using System.ComponentModel;
using ConsultReniec;
using System.IO;

namespace Bata
{
    /// <summary>
    /// Lógica de interacción para ActivaGiftCard.xaml
    /// </summary>
    public partial class ActivaGiftCard : Window
    {
        public static Boolean _activo_form = false;
        string _tienda { set; get; }
        private string tipo_docu = "AC";
        private string serie;
        private string cod_empresa = "02";

        private DataTable dtdni = null;
        private DataTable dtruc = null;
        private DataTable dtruc2 = null;

        private string  _cod_arti = "";
        private string  _cod_activ = "";
        private string  _desc_artic = "";
        private string _cod_promocion = "";
        private string  _fecha_crea = "";
        private Int32   _cantidad = 0;
        private decimal _monto      = 0;
        private string  _cod_barra = "";
        private string  _estado = "";
        

        private Boolean RegistradoEnFlujosBataClub = false;
        BackgroundWorker _trabajo;
        public static Window _principal { set; get; }
        private DataTable dtcuponlista = null;

        /// <summary>
        /// Al momento de crear la ventana, se inicializan datos y componentes
        /// </summary>
        public ActivaGiftCard()
        {
            InitializeComponent();
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtfecha.IsEnabled = false;
            lblestado.Text = "";
            txtdniruc.Focus();
        }
       
        /// <summary>
        /// método de cierre de ventana, se ejecuta previo al cierre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            _activo_form = false;
        }

        /// <summary>
        /// metodo que realiza el cierre de la ventana, y regreso a Principal.xaml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btBackPanelLiq_Click(object sender, RoutedEventArgs e)
        {
            Principal frm = new Principal();
            frm.Show();
            this.Close();
        }

        /// <summary>
        /// método de cierre de session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCloseSesion_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// método que se ejecuta cuando una tecla es presionada en txtbuscar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">tecla presionada</param>
        private void txtbuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnbuscar_Click(btnbuscar, new RoutedEventArgs());
            }
        }

        /// <summary>
        /// método que se ejecuta al presionar una tecla, se ejecuta antes de reconocer tecla apretada en txtbuscar
        /// se usa para validar la tecla que se ha presionado y solo permitir alguna de ellas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">texto tecla presionada</param>
        private void txtbuscar_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            SoloNumerosLetras(e);
        }

        /// <summary>
        /// método que se ejecuta al presionar una tecla, se ejecuta antes de reconocer tecla apretada en txtnrotarj
        /// se usa para validar la tecla que se ha presionado y solo permitir alguna de ellas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">texto tecla presionada</param>
        private void txtnrotarj_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            SoloNumero(e);
        }
        
        private void txtnrotarj_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.End || e.Key == Key.Home || e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.LeftShift || e.Key == Key.RightShift)
            { }
            else
            {
                string cad_ini = txtnrotarj.Text.Replace("*", "").Trim();
                int len = cad_ini.Length;
                if (txtnrotarj.Text.Length >= 6)
                {
                    txtnrotarj.Text = cad_ini.Substring(0, 6) + "******" + cad_ini.Substring(6, len - 6);
                }
                txtnrotarj.Focus();
                txtnrotarj.Select(txtnrotarj.Text.Length, 0);
            }
        }

        /// <summary>
        /// método que evalúa las teclas presionadas y permite que sólo los números y letras sean escritas
        /// </summary>
        /// <param name="e">texto tecla presionada</param>
        public void SoloNumerosLetras(TextCompositionEventArgs e)
        {
            if (e.Text != "")
            {
                //se convierte a Ascci del la tecla presionada
                int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
                //verificamos que se encuentre en ese rango que son entre el 0 y el 9
                if ((ascci >= 48 && ascci <= 57) || (ascci >= 65 && ascci <= 90) || (ascci >= 97 && ascci <= 122))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
        }

        /// <summary>
        /// método que evalúa las teclas presionadas y permite que sólo los números sean escritas
        /// </summary>
        /// <param name="e">texto tecla presionada</param>
        public void SoloNumero(TextCompositionEventArgs e)
        {
            if (e.Text != "")
            {
                //se convierte a Ascci del la tecla presionada
                int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
                //verificamos que se encuentre en ese rango que son entre el 0 y el 9
                if (ascci >= 48 && ascci <= 57)
                    e.Handled = false;
                else
                    e.Handled = true;
            }
        }

        /// <summary>
        /// método que evalúa las teclas presionadas y permite que sólo los números y separadores decimales (.) sean escritas
        /// </summary>
        /// <param name="e">texto tecla presionada</param>
        public void SoloDecimal(TextCompositionEventArgs e)
        {
            if (e.Text != "")
            {
                //se convierte a Ascci del la tecla presionada
                int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
                //verificamos que se encuentre en ese rango que son entre el 0 y el 9
                if ((ascci >= 48 && ascci <= 57) || ascci == 46)
                    e.Handled = false;
                else
                    e.Handled = true;
            }
        }

        /// <summary>
        /// método que se ejecuta cuando el texto contenido en txtbuscar es cambiado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbuscar_TextChanged(object sender, TextChangedEventArgs e)
        {

            /* Lectora de Barra ya manda un Enter
            // Se cambia la especificación de tamaño de código de Activacion (de 11 a 18 caracteres) - 27/04/2018
            string _strbuscar = txtbuscar.Text.Trim().ToString();
            if (_strbuscar.Length == 18)//busca si llega a una cantidad de caracteres
            {
                validar_buscar = true;
                buscar();
                //validar_buscar = false;
            }*/
        }

        /// <summary>
        /// método que permite la creación de la tabal dtcuponlista, la cual controlará los articulos en grilla
        /// </summary>
        private void crear_tabla()
        {
            dtcuponlista = new DataTable();
            dtcuponlista.Columns.Add("Articulo", typeof(string));
            dtcuponlista.Columns.Add("Promocion", typeof(string));
            dtcuponlista.Columns.Add("Descripcion", typeof(string));
            dtcuponlista.Columns.Add("Fec_crea", typeof(string));
            dtcuponlista.Columns.Add("Numero", typeof(string));
            dtcuponlista.Columns.Add("Cantidad", typeof(int));
            dtcuponlista.Columns.Add("Monto", typeof(Decimal));
            dtcuponlista.Columns.Add("Cod_Barra", typeof(string));
            dtcuponlista.Columns.Add("Estado", typeof(string));
        }

        /// <summary>
        /// método que realiza la busqueda de Gift Card a ser activada, en la BD
        /// devolviendo el estado en que este se encuentra
        /// </summary>
        private void buscar()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            limpiar();
            if (txtbuscar.Text.Trim().Length == 0)
            {
                Mouse.OverrideCursor = null;
                lblestado.Text = "Ingrese El N° de Gift Card";
                txtbuscar.Focus();

                return;
            }

            DataTable dt = GiftCards.BuscarGiftCard(txtbuscar.Text.Trim().ToString());

            if (dt == null)
            {
                lblestado.Text = "No hay Conexion en internet";
                txtbuscar.Focus();
            }
            else
            {
                DataTable dtvalida = dt;


                if (dtvalida.Rows.Count > 0)
                {
                    lblestado.Text = dtvalida.Rows[0]["descripcion"].ToString();

                    _cod_arti = dtvalida.Rows[0]["articulo"].ToString().Trim();
                    _cod_activ = dtvalida.Rows[0]["activacion"].ToString().Trim();
                    _cod_promocion = dtvalida.Rows[0]["promocion"].ToString().Trim();
                    _desc_artic = dtvalida.Rows[0]["descripcion"].ToString().Trim();
                    _fecha_crea = dtvalida.Rows[0]["fec_crea"].ToString().Trim();
                    _cantidad = Convert.ToInt32(dtvalida.Rows[0]["cant"]);
                    _monto = Convert.ToDecimal(dtvalida.Rows[0]["monto"]);
                    _cod_barra = dtvalida.Rows[0]["cod_barra"].ToString().Trim();
                    _estado = dtvalida.Rows[0]["estado"].ToString().Trim();

                    
                    string _valida = dtvalida.Rows[0]["estado"].ToString();

                    if (_valida != "CO") // Diferente de Consumido
                    {
                        if (_valida != "DS") // Diferente de Activado
                        {
                            if (_monto > 0)
                            {
                                if (dtcuponlista != null)
                                {
                                    Boolean _valida_existe = true;

                                    if (dtcuponlista.Rows.Count > 0)
                                    {
                                        DataRow[] fila_existe = dtcuponlista.Select("Cod_Barra='" + _cod_barra + "'");

                                        _valida_existe = (fila_existe.Length == 0) ? true : false;
                                    }

                                    if (_valida_existe)
                                    {
                                        dtcuponlista.Rows.Add(_cod_arti, _cod_promocion, _desc_artic, _fecha_crea, _cod_activ, _cantidad, _monto, _cod_barra, _estado);
                                        txtbuscar.Text = "";
                                        dg1.ItemsSource = dtcuponlista.DefaultView;
                                        calculatotales();
                                        btnsig.Visibility = (dtcuponlista.Rows.Count > 0) ? Visibility.Visible : Visibility.Hidden;
                                        btnant.Visibility = (dtcuponlista.Rows.Count > 0) ? Visibility.Visible : Visibility.Hidden;
                                        //btnactualizar.IsEnabled = true;
                                    }
                                    else
                                    {
                                        lblestado.Text = "El Numero de Gift Card " + _cod_barra + ", Ya existe en la lista. Por favor ingrese otro.";
                                        txtbuscar.SelectAll();
                                        txtbuscar.Focus();
                                    }
                                }
                            }
                            else
                            {
                                lblestado.Text = "El Numero de Gift Card " + _cod_barra + ", No es Válido en esta ventana.";
                                txtbuscar.SelectAll();
                                txtbuscar.Focus();
                            }
                        }
                        else
                        {// Diferente de Activado
                            lblestado.Text = "El Numero de Gift Card " + _cod_barra + ", Ya ha sido Activado Anteriormente.";
                            txtbuscar.SelectAll();
                            txtbuscar.Focus();
                        }
                    }
                    else
                    {// Diferente de Usado
                        lblestado.Text = "El Numero de Gift Card " + _cod_barra + ", Ya ha sido Usado.";
                        txtbuscar.SelectAll();
                        txtbuscar.Focus();
                    }
                }
                else
                {// No se encuentra
                    lblestado.Text = "El Numero de Gift Card " + _cod_barra + ", No es Válido.";
                    txtbuscar.SelectAll();
                    txtbuscar.Focus();
                }
            }
            Mouse.OverrideCursor = null;
        }

        /// <summary>
        /// método que se ejecuta cuando se presiona el boton btnbuscar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnbuscar_Click(object sender, RoutedEventArgs e)
        {
            buscar();
        }

        /// <summary>
        /// método que se ejecuta cuando se presiona el boton btnsig (ubicado en la primera pestaña)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnsig_Click(object sender, RoutedEventArgs e)
        {
            tabvale.IsEnabled = false;
            tabpago.IsEnabled = true;
            tabvalescliente.SelectedIndex = 1;
            this.tabvalescliente.UpdateLayout();
            txtdniruc.Focus();
        }

        /// <summary>
        /// método que se ejecuta cuando se presiona el boton btnant (ubicado en la segunda pestaña)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnant_Click(object sender, RoutedEventArgs e)
        {
            tabvale.IsEnabled = true;
            tabpago.IsEnabled = false;
            tabvalescliente.SelectedIndex = 0;
            this.tabvalescliente.UpdateLayout();

            lblefectivo.FontWeight = FontWeights.Normal;
            lbltarjeta.FontWeight = FontWeights.Normal;
            rdefect.IsChecked = false;
            rdtarjet.IsChecked = false;
            txtefemonto.IsEnabled = false;
            txtefevuelto.IsEnabled = false;
            txtefemonto.Text = "monto efectivo";
            txtefevuelto.Text = "vuelto efectivo";
            txtnrotarj.IsEnabled = false;
            txttrjmonto.IsEnabled = false;
            cboTipTarj.IsEnabled = false;
            txttrjmonto.Text = "monto tarjeta";
            txtnrotarj.Text = "numero tarjeta";
            cboTipTarj.SelectedItem = null;
            btnactualizar.IsEnabled = false;

            txtbuscar.Focus();
        }

        /// <summary>
        /// métpdp que se ejecuta cuando se cambia la selección del radio button (segunda pestaña)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rad_checked(object sender, RoutedEventArgs e)
        {
            DataView dv = dtcuponlista.DefaultView;
            decimal valor = dv.Table.AsEnumerable().Sum(y => y.Field<Decimal>("Monto"));
            if (rdefect.IsChecked.Value)
            {
                lblefectivo.FontWeight = FontWeights.Bold;
                lbltarjeta.FontWeight = FontWeights.Normal;
                txtefemonto.IsEnabled = true;
                txtefevuelto.IsEnabled = true;
                txtefemonto.Text = valor.ToString("0,0.00");
                txtefevuelto.Text = 0.ToString("0,0.00");
                txtnrotarj.IsEnabled = false;
                txttrjmonto.IsEnabled = false;
                cboTipTarj.IsEnabled = false;
                txttrjmonto.Text = "monto tarjeta";
                txtnrotarj.Text = "numero tarjeta";
                cboTipTarj.SelectedItem = null;
                btnactualizar.IsEnabled = true;
                txtefemonto.Focus();
                txtefemonto.SelectAll();
            }
            if (rdtarjet.IsChecked.Value)
            {
                lblefectivo.FontWeight = FontWeights.Normal;
                lbltarjeta.FontWeight = FontWeights.Bold;
                txtefemonto.IsEnabled = false;
                txtefevuelto.IsEnabled = false;
                txtefemonto.Text = "monto efectivo";
                txtefevuelto.Text = "vuelto efectivo";
                txttrjmonto.IsEnabled = true;
                txtnrotarj.IsEnabled = true;
                cboTipTarj.IsEnabled = true;
                txttrjmonto.Text = valor.ToString("0,0.00");
                txtnrotarj.Text = "";
                cboTipTarj.SelectedItem = null;
                btnactualizar.IsEnabled = false;
                cboTipTarj.Focus();
            }
            if (!rdefect.IsChecked.Value && !rdtarjet.IsChecked.Value)
            {
                lblefectivo.FontWeight = FontWeights.Normal;
                lbltarjeta.FontWeight = FontWeights.Normal;
                txtefemonto.IsEnabled = false;
                txtefevuelto.IsEnabled = false;
                txtefemonto.Text = "monto efectivo";
                txtefevuelto.Text = "vuelto efectivo";
                txtnrotarj.IsEnabled = false;
                txttrjmonto.IsEnabled = false;
                cboTipTarj.IsEnabled = false;
                txttrjmonto.Text = "monto tarjeta";
                txtnrotarj.Text = "numero tarjeta";
                cboTipTarj.SelectedItem = null;
                btnactualizar.IsEnabled = false;
            }
        }

        /// <summary>
        /// método que se ejecuta cuando es presionada una tecla en txtdniruc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        MessageBox.Show("Ingrese el numero DNI",
                              "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Mouse.OverrideCursor = null;
                        return;
                    }

                    if (_dni_ruc.Length != 8)
                    {
                        MessageBox.Show("El numero DNI es incorrecto",
                              "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Mouse.OverrideCursor = null;
                        return;
                    }
                    
                    /// Se crea tarea en background
                    txtdniruc.IsEnabled = false;
                    _trabajo = new BackgroundWorker();
                    _trabajo.WorkerReportsProgress = false;
                    _trabajo.DoWork += (obj, ea) => _loading_procesos(_dni_ruc);
                    _trabajo.ProgressChanged += new ProgressChangedEventHandler(progressReport);
                    _trabajo.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerComplete);
                    _trabajo.RunWorkerAsync();
                    
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

        /// <summary>
        /// método que se ejecuta cuando la tarea en back ground es culminada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void workerComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            txtdniruc.IsEnabled = true;
            print_data(txtdniruc.Text, dtdni);
        }

        /// <summary>
        /// método que se ejecuta cuando la tarea en back ground está en proceso (cuerpo de tarea)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void progressReport(Object sender, ProgressChangedEventArgs e)
        {

        }

        /// <summary>
        /// método que captura resultados de Web Service de Reniec, y los muestra según sea el caso
        /// </summary>
        private void CaptionResul()
        {
            PersonaReniec myInfo = Clientes._persona_reniec;
            try
            {

                switch (myInfo.estado_reniec)
                {
                    case 231:
                        //txtdni.Text = txtdniruc.Text;
                        txtnombre.Text = myInfo.ApePaterno + " " + myInfo.ApeMaterno +", "+myInfo.Nombres;
                        txtnombres.Text = myInfo.Nombres;
                        txtapepat.Text = myInfo.ApePaterno;
                        txtapemat.Text = myInfo.ApeMaterno;
                        txtbuscar.Focus();
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
                        MessageBox.Show("Error Desconocido",
                        "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtdniruc.SelectAll();
                        txtdniruc.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                /// Se agregó método para contingencia en caso de que RENIEc no responda
                //throw ex;
                MessageBox.Show("Error al buscar DNI en RENIEC. Favor de llenar manualmente los datos.",
                 "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
                abrir_Datos_Cliente(txtdniruc.Text);
            }
        }

        /// <summary>
        /// evalua resultados obtenidos de consulta  Web Service de BataClub
        /// </summary>
        /// <param name="_dniruc"></param>
        /// <param name="dt"></param>
        private void print_data(string _dniruc, DataTable dt)
        {
            switch (_dniruc.Length)
            {
                case 8:
                    if (dtdni != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            txtnombre.Text = dt.Rows[0]["fc_apep"].ToString() + " " + dt.Rows[0]["fc_apem"].ToString() + ", " + dt.Rows[0]["fc_nomb"].ToString();
                            txtnombres.Text = dt.Rows[0]["fc_nomb"].ToString();
                            txtapepat.Text = dt.Rows[0]["fc_apep"].ToString();
                            txtapemat.Text = dt.Rows[0]["fc_apem"].ToString();
                            txtbuscar.Focus();
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
            }

        }

        /// <summary>
        /// método que se ejecuta al iniciar la tarea en background
        /// </summary>
        /// <param name="_dni_ruc"></param>
        private void _loading_procesos(string _dni_ruc)
        {
            _consulta_dni_ruc_loading(_dni_ruc);
            //_crear_actualiza_dbf_loading();
        }

        /// <summary>
        /// método que busca los datos de cliente, a través del DNI ingresado
        /// </summary>
        /// <param name="_dni_ruc">número de DNI del cliente</param>
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
                if (_dni_ruc.Length == 8)
                {
                    Boolean nuevobataclub = false;
                    Boolean existe_cl_bata = false;
                    //en este lado de codigo , verifificamos la web service de bata antes de consultar en reniec
                    string barra_cliente = "";
                    DataTable dt = Clientes._consultacliente(_dni_ruc, ref RegistradoEnFlujosBataClub,ref nuevobataclub,ref existe_cl_bata,ref barra_cliente);
                    dtdni = dt;
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                          

                        }
                        else
                        {
                            PersonaReniec myInfo = new PersonaReniec(); //Clientes._persona_reniec;                                
                                                                        //myInfo.GetInfo(_dni_ruc, Clientes._str_codigo_captcha_reniec);
                            DataTable dt2 = Clientes._consultaReniec(_dni_ruc);

                            myInfo.GetInfo(dt2);
                            Clientes._persona_reniec = myInfo;
                           
                        }
                    }
                    else
                    {
                        PersonaReniec myInfo = new PersonaReniec(); 
                        DataTable dt2 = Clientes._consultaReniec(_dni_ruc);

                        myInfo.GetInfo(dt2);
                        Clientes._persona_reniec = myInfo;
                        //CaptionResul();
                    }

                    //********************************

                }
                else
                {
                    Boolean nuevobataclub = false;
                    Boolean existe_cl_bata = false;
                    string barra_cliente = "";
                    DataTable dt1 = Clientes._consultacliente(_dni_ruc, ref RegistradoEnFlujosBataClub,ref nuevobataclub,ref existe_cl_bata,ref barra_cliente);
                    dtruc = dt1;
                    if (dt1 != null)
                    {
                        if (dt1.Rows.Count > 0)
                        {
                           
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
                                       
                                    }
                                }
                            }
                            else
                            {
                                
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
            catch (Exception exc)
            {
                throw;
                //MessageBox.Show("Error al buscar DNI en RENIEC. Favor de llenar manualmente los datos.",
                // "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// método que abre ventana emergente para el llenado de datos manual del Cliente
        /// Contingencia por cuando Web Service de Reniec no funcione
        /// </summary>
        /// <param name="dni">DNI ingresado</param>
        private void abrir_Datos_Cliente(string dni)
        {
            /*Application.Current.Dispatcher.Invoke((Action)delegate
            {*/

            if (!Datos_Cliente._activo_form)
            {
                Datos_Cliente frm2 = new Datos_Cliente(dni);
                frm2.Owner = this; AplicarEfecto(this);
                frm2.Show();
                Datos_Cliente._activo_form = true;
                frm2.Closed += Frm2_Closed;
            }

            /*});*/
        }

        /// <summary>
        /// método complementario que no permite continuar hasta haber llenado datos
        /// </summary>
        /// <param name="win">ventana que invoca a la emergente</param>
        private void AplicarEfecto(Window win)
        {
            var objBlur = new System.Windows.Media.Effects.BlurEffect();
            objBlur.Radius = 5;
            win.Effect = objBlur;
        }

        /// <summary>
        /// método complementario que permite continuar, luego de cerrar ventana emergente
        /// </summary>
        /// <param name="win">ventana que invoca a la emergente</param>
        private void QuitarEfecto(Window win)
        {
            win.Effect = null;
        }

        /// <summary>
        /// método que se ejecuta antes de que la ventana emergente se cierre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm2_Closed(object sender, EventArgs e)
        {
            Datos_Cliente ventana = sender as Datos_Cliente;
            if (ventana.datos != null)
            {
                dtdni = ventana.datos;
                print_data(txtdniruc.Text, dtdni);
            }
            else
            {
                txtdniruc.Text = "";
                txtdniruc.Focus();
            }
            QuitarEfecto(this);
        }

        Boolean validar_buscar = false;

        /// <summary>
        /// método que se ejecuta cuando el texto en el campo txtdniruc es cambiado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtdniruc_TextChanged(object sender, TextChangedEventArgs e)
        {
            validar_buscar = false;
        }

        /// <summary>
        /// método que se ejecuta cuando el texto en el campo txtefemonto es cambiado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtefemonto_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (dtcuponlista != null)
            {
                if (txtefemonto.Text.Trim() != "" && rdefect.IsChecked.Value)
                {
                    DataView dv = dtcuponlista.DefaultView;
                    decimal vuelto = Convert.ToDecimal(txtefemonto.Text) - dv.Table.AsEnumerable().Sum(y => y.Field<Decimal>("Monto"));
                    if (vuelto >= 0)
                    {
                        txtefevuelto.Text = vuelto.ToString("0,0.00");
                        btnactualizar.IsEnabled = true;
                    }
                    else
                    {
                        txtefevuelto.Text = 0.ToString("0,0.00");
                        btnactualizar.IsEnabled = false;
                    }
                }
                else
                {
                    txtefevuelto.Text = 0.ToString("0,0.00");
                    btnactualizar.IsEnabled = false;
                }
            }
        }

        /// <summary>
        /// método que se ejecuta cuando la seleccion de cboTipTarj es cambiado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTipTarj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboTipTarj.SelectedItem != null && rdtarjet.IsChecked.Value)
            {
                btnactualizar.IsEnabled = true;
            }
            else
            {
                btnactualizar.IsEnabled = false;
            }
        }

        /// <summary>
        /// método que se ejecuta antes de que el texto en el campo txtefemonto es cambiado
        /// es usado para controlar las teclas permitidas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtefemonto_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            SoloDecimal(e);
        }

        /// <summary>
        /// método que se ejecuta cuando es presionado el botón btnactualizar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnactualizar_Click(object sender, RoutedEventArgs e)
        {
            if (txtdniruc.Text.Trim().Length > 0 && dtcuponlista != null)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                
                _crear__actualiza_dbf();
                Mouse.OverrideCursor = null;
            }
        }

        /// <summary>
        /// método que ejecuta el procesamiento de toda la información, y el grabado en los diversos repositorios
        /// </summary>
        private void _crear__actualiza_dbf()
        {//-- Procesamiento de Información
           
            try
            {
                /// Se almacenan datos principales
                string codigo = "";
                string tipo_tarj = "";
                string num_tarj = "";
                if (rdtarjet.IsChecked.Value)
                {
                    ComboBoxItem escoger = (ComboBoxItem)(cboTipTarj.SelectedValue);
                    tipo_tarj = escoger.Uid.ToString();
                    num_tarj = txtnrotarj.Text.Trim();
                }

                string _validatxt = txtdniruc.Text.Trim();
                string _validatxt2 = txtnombre.Text.Trim();

                /// se valida que esten llenos los campos principales
                if (_validatxt.Length != 0 && _validatxt2.Length != 0 )
                {
                    string _dniruc = txtdniruc.Text.Trim();
                    string _nombre = txtnombres.Text.Trim();
                    string _apepat = txtapepat.Text.Trim();
                    string _apemat = txtapemat.Text.Trim();

                    _nombre = _nombre.Replace(",", " ");
                    _apepat = _apepat.Replace(",", " ");
                    _apemat = _apemat.Replace(",", " ");
                    
                    /// Se valida la que el table dtcuponlista tenga datos (detalle de la activación)
                    if (dtcuponlista!=null)
                    {
                        string _forpag = "";
                        if (rdefect.IsChecked.Value) { _forpag = "E"; }
                        if (rdtarjet.IsChecked.Value) { _forpag = "T"; }
                        string fecha_dbf = txtfecha.Text.Substring(3, 2) + "/" + txtfecha.Text.Substring(0, 2) + "/" + txtfecha.Text.Substring(6, 4);
                        //**-- Ejecuta Guardado en DBF de Ticket
                        //codigo = GiftCards.GrabarDBF_Ticket(cod_empresa, serie, fecha_dbf, _dniruc, _nombre, _apepat, _apemat, _forpag, tipo_tarj, num_tarj, dtcuponlista);
                        //**-- Ejecuta Actualización de Stock
                        //GiftCards.GrabarDBF_Stock(cod_empresa, tipo_docu, serie, codigo, fecha_dbf, _dniruc, _nombre, _apepat, _apemat, dtcuponlista);
                        codigo = GiftCards.Grabar_Ticket(cod_empresa, tipo_docu, serie, fecha_dbf, _dniruc, _nombre, _apepat, _apemat, _forpag, tipo_tarj, num_tarj, dtcuponlista);
                        /// se recorre el detalle de la activación
                        for (Int32 i=0;i<dtcuponlista.Rows.Count;++i)
                        {
                            _cod_arti = dtcuponlista.Rows[i]["Articulo"].ToString().Trim();
                            _cod_promocion = dtcuponlista.Rows[i]["Promocion"].ToString().Trim();
                            _desc_artic = dtcuponlista.Rows[i]["Descripcion"].ToString().Trim();
                            _fecha_crea = dtcuponlista.Rows[i]["Fec_crea"].ToString().Trim();
                            _cod_activ = dtcuponlista.Rows[i]["Numero"].ToString().Trim();
                            _cantidad = Convert.ToInt32(dtcuponlista.Rows[i]["Cantidad"]);
                            _monto = Convert.ToDecimal(dtcuponlista.Rows[i]["Monto"]);
                            _cod_barra = dtcuponlista.Rows[i]["Cod_Barra"].ToString().Trim();
                            _estado = dtcuponlista.Rows[i]["Estado"].ToString().Trim();

                            //**-- Ejecuta Actualizacion en SQL Server
                            GiftCards.ActivaGiftCard(_cod_barra, _dniruc, _nombre, _apepat, _apemat);
                            
                            
                        }
                    }
                    /// se genera impresión de Ticket de Activación
                    GiftCards.Generar_Impresion(cod_empresa, serie, codigo);

                    /// Se resetean campos
                    dtcuponlista.Rows.Clear();
                    dg1.ItemsSource = dtcuponlista.DefaultView;
                    calculatotales();
                    txtdniruc.IsEnabled = true;
                    txtdniruc.Text = "";
                    txtnombre.Text = "";
                    btnactualizar.IsEnabled = false;
                    btnant.Visibility = Visibility.Hidden;
                    txtdniruc.IsEnabled = false;
                    cargar.Visibility = Visibility.Visible;
                    Process();
                    limpiar();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message,
                     "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        /// <summary>
        /// método que muestra progreso de procesamiento de datos
        /// </summary>
        /// <param name="dp"></param>
        /// <param name="value"></param>
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
                if (_principal != null)
                {
                    _principal.WindowState = WindowState.Minimized;
                }
                this.Close();
            }

        }

        /// <summary>
        /// metodo que limpia archivo txt
        /// </summary>
        /// <param name="_ruta">ruta en donde se encuentran los archivos a limipiar</param>
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

        /// <summary>
        /// método que se ejecuta al momento de presionar eliminar en una línea de detalle en la activación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btneliminar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)((Button)e.Source).DataContext;

            string _barra = (String)row["Cod_Barra"].ToString();

            dtcuponlista.Rows.Remove(row.Row);

            lblestado.Text = "";

            dg1.ItemsSource = dtcuponlista.DefaultView;
            calculatotales();

            btnsig.Visibility = (dtcuponlista.Rows.Count > 0) ? Visibility.Visible : Visibility.Hidden;
            btnant.Visibility = (dtcuponlista.Rows.Count > 0) ? Visibility.Visible : Visibility.Hidden;

        }

        /// <summary>
        /// método que actualiza los totales que se muestran en las pantallas
        /// </summary>
        private void calculatotales()
        {
            try
            {
                DataView dv = dtcuponlista.DefaultView;

                lblt1.Content = string.Format("{0:C2}", dv.Table.AsEnumerable().Sum(y => y.Field<Decimal>("Monto")));
                lblt2.Content = lblt1.Content;
            }
            catch
            {

            }
        }

        /// <summary>
        /// metodo que limpia los campos y datos, para poder iniciar nuevamente un proceso
        /// </summary>
        /// <param name="clear_table"> se creará la tabla cuponlista ?</param>
        private void limpiar_objec(Boolean clear_table=false)
        {
            txtnombre.Text = "";

            dtdni = null;
            dtruc = null;
            dtruc2 = null;
            txtdniruc.IsEnabled = true;

            pn1.Visibility = Visibility.Collapsed;
            lblmsg.Visibility = Visibility.Collapsed;

            if (clear_table)
            {
                crear_tabla();

                calculatotales();

                btnsig.Visibility = (dtcuponlista.Rows.Count > 0) ? Visibility.Visible : Visibility.Hidden;
                btnant.Visibility = (dtcuponlista.Rows.Count > 0) ? Visibility.Visible : Visibility.Hidden;
            }
        }

        /// <summary>
        /// método que se ejecuta cuando la pantalla se está activando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            limpiar_objec(true);
            limpiar();
            if (Environment.GetEnvironmentVariable("codtda") != null) { 
                _tienda = "50" + Environment.GetEnvironmentVariable("codtda").ToString();
                serie = "0" + Environment.GetEnvironmentVariable("codtda").ToString();
            }
            if (_tienda.Length == 0 || _tienda == null) _tienda = "";

            txtdniruc.Focus();
        }
        
        /// <summary>
        /// limpia los campos y selecciones realizadas, de la pestaña de pagos
        /// </summary>
        private void limpiar()
        {

            _cod_arti = "";
            _cod_activ = "";
            _desc_artic = "";
            _fecha_crea = "";
            _cantidad = 0;
            _monto = 0;
            _cod_barra = "";
            _estado = "";

            cargar.Visibility = Visibility.Hidden;
            tabvale.IsEnabled = true;
            tabpago.IsEnabled = false;

            tabdet1.IsEnabled = true;
            //tabdet2.IsEnabled = false;

            tabdet.SelectedIndex = 0;
            this.tabdet.UpdateLayout();

            /*pago*/
            lblefectivo.FontWeight = FontWeights.Normal;
            lbltarjeta.FontWeight = FontWeights.Normal;
            rdefect.IsChecked = false;
            rdtarjet.IsChecked = false;
            txtefemonto.IsEnabled = false;
            txtefevuelto.IsEnabled = false;
            txtefemonto.Text = "monto efectivo";
            txtefevuelto.Text = "vuelto efectivo";
            txtnrotarj.IsEnabled = false;
            txttrjmonto.IsEnabled = false;
            txttrjmonto.Text = "monto tarjeta";
            txtnrotarj.Text = "numero tarjeta";
            btnactualizar.IsEnabled = false;
        }

    }
}
