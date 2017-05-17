using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.IO;

namespace Bata
{
    /// <summary>
    /// Lógica de interacción para Descuento_Bata.xaml
    /// </summary>
    public partial class Descuento_Bata : Window
    {
        public static Boolean _activo_form = false;

        public static Window _principal { set; get; }
        BackgroundWorker _trabajo;

        private DateTime tiempoInicial  ;
        private DateTime tiempoFinal;
        private Boolean evaluando = false;
        DataSet dsbuscar = null;
        DataTable dtvalidacion = null;
        DataTable dtdatos = null;

        string _tienda { set; get; }
        string _tipo_des { set; get; }

        private string _serie="";
        private Int32 _porc_desc = 0;
        private Int32 _pares_max = 0;
        private string _tipo_desc = "";

        private string _correlativo = "";

        private Boolean key_combina = true;

        public Descuento_Bata()
        {
            InitializeComponent();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            _activo_form = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Environment.GetEnvironmentVariable("codtda") != null)
                _tienda = Environment.GetEnvironmentVariable("codtda");

            if (_tienda != null)
            {
                _tienda = "50" + _tienda.ToString();
            }

            cargar.Visibility = Visibility.Hidden;
           
            limpiar_objec();
            limpiar();
            txtdniruc.Focus();
        }
        private void limpiar()
        {
            _correlativo = "";
            _serie = "";           
            _porc_desc = 0;
            _pares_max = 0;
            _tipo_desc = "";
            lblestado.Text = "";
            _tipo_des = "302002";
            dsbuscar = null;
            dtvalidacion = null;
            dtdatos = null;

        }
        private void limpiar_objec()
        {
            txtdni.Text = "";
            txtnombres.Text = "";
            txtapepat.Text = "";
            txtdescuento.Text = "";
            txtapemat.Text = "";
            txtfechac.Text = "";
            txtntransac.Text = "";
            
            btnactualizar.IsEnabled = false;
            
            pn1.Visibility = Visibility.Collapsed;
            lblmsg.Visibility = Visibility.Collapsed;
            

            txtdniruc.IsEnabled = true;

        }
        private void btnbuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnactualizar_Click(object sender, RoutedEventArgs e)
        {
            if (txtdniruc.Text.Trim().Length > 0)
            {
                Mouse.OverrideCursor = Cursors.Wait;                                               
                _crear__actualiza_dbf();
                Mouse.OverrideCursor = null;
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
                    string _direccion = "";
                    string _telefono = "";
                    string _email = "";
                    string _ubigeo = "";

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
                    string _ruta_archivo = _ruta_txt + "\\" + /*_dniruc.ToString()*/ _correlativo + ".txt";

                    if (File.Exists(@_ruta_archivo))
                    {
                        File.Delete(@_ruta_archivo);
                    }

                    _limpiar_txt(_ruta_txt);

                    TextWriter tw = new StreamWriter(@_ruta_archivo, true);
                    tw.WriteLine(_serie + "," + "P" + "," + _porc_desc.ToString() + "," + _pares_max.ToString() + "," + _dniruc + "," + _nombre + "," + _apepat + "," + _apemat + "," + _direccion + "," + _telefono + "," + _email + "," + _ubigeo + "," + _tipo_desc);
                    tw.Flush();
                    tw.Close();
                    tw.Dispose();
                    btnactualizar.IsEnabled = false;
                    txtdniruc.IsEnabled = false;
                    cargar.Visibility = Visibility.Visible;
                    Process();
                   
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message,
                     "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
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
                value += 8;

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
        Boolean validar_buscar = false;
        void progressReport(Object sender, ProgressChangedEventArgs e)
        {

        }
        private void txtdniruc_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) || e.KeyboardDevice.IsKeyDown(Key.RightCtrl))
            //{
            //    switch (e.Key)
            //    {
            //        case Key.V:
            //            e.Handled = false;
            //            //handle D key
            //            break;
            //        case Key.X:
            //            //handle X key
            //            break;
            //    }
            //}
            Clipboard.Clear();
            Clipboard.SetText("");

            //if (e.Key==Key.LeftCtrl && e.Key == Key.V)
            //{
            //    //switch (e.Key)
            //    //{
            //    //    case Key.C:
            //    //        e.Handled = true;
            //    //        txtdniruc.SelectionLength = 0;
            //    //        break;
            //    //    case Key.P:
            //    //        e.Handled = true;
            //    //        txtdniruc.SelectionLength = 0;
            //    //        break;
            //    //    case Key.X:
            //            e.Handled = true;
            //            txtdniruc.SelectionLength = 0;
            //            //break;
            //    //}
            //}


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
                    limpiar();
                    string _dni_ruc = txtdniruc.Text;
                    if (_dni_ruc.Length == 0)
                    {
                        MessageBox.Show("Ingrese el numero de DNI",
                              "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Mouse.OverrideCursor = null;
                        return;
                    }

                    if (_dni_ruc.Length != 8 && _dni_ruc.Length != 11)
                    {
                        MessageBox.Show("El numero DNI",
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
            print_data();
            pn1.Visibility = Visibility.Collapsed;
            lblmsg.Visibility = Visibility.Collapsed;



        }
        private void print_data()
        {
            
            if (dsbuscar!= null)
            {
                if (dsbuscar.Tables.Count > 1)
                {                    
                    dtvalidacion =dsbuscar.Tables[0];
                    dtdatos = dsbuscar.Tables[1];

                    txtdni.Text = dtdatos.Rows[0]["dni"].ToString();
                    txtnombres.Text = dtdatos.Rows[0]["nombres"].ToString();
                    txtapepat.Text = dtdatos.Rows[0]["apepat"].ToString();
                    txtapemat.Text = dtdatos.Rows[0]["apemat"].ToString();
                    txtdescuento.Text =Convert.ToInt32(dtdatos.Rows[0]["tip_porc"]).ToString() + "%";
                    txtfechac.Text = dtdatos.Rows[0]["fechafin"].ToString(); ;
                    txtntransac.Text = dtdatos.Rows[0]["Tip_ComMax"].ToString();
                    _correlativo = dtdatos.Rows[0]["contador"].ToString().PadLeft(8,'0');
                    _porc_desc = Convert.ToInt32(dtdatos.Rows[0]["tip_porc"]);
                    _pares_max = Convert.ToInt32(dtdatos.Rows[0]["tip_parmax"]);
                    _serie= dtdatos.Rows[0]["Tip_id"].ToString();
                    lblestado.Text = dtvalidacion.Rows[0]["Descripcion"].ToString();
                    

                }
                else
                {
                    dtvalidacion=dsbuscar.Tables[0];
                    lblestado.Text = dtvalidacion.Rows[0]["Descripcion"].ToString();
                }

               
                
                
            }
            else
            {
                lblestado.Text = "No hay Conexion en internet";
            }
                                                    
            txtdniruc.SelectAll();
            txtdniruc.Focus();
            if (txtdni.Text.Trim().Length > 0)
            {                

                if (txtapepat.Text.Trim().Length > 0 || txtnombres.Text.Trim().Length > 0)
                {
                    btnactualizar.IsEnabled = true;
                }
            }

        }
        private void _loading_procesos(string _dni_ruc)
        {
            _consulta_dni_ruc_loading(_dni_ruc);
            //_crear_actualiza_dbf_loading();
        }
        private void _consulta_dni_ruc_loading(string _dni_ruc)
        {

            dsbuscar = null;
            dtvalidacion = null;
            dtdatos = null;
          
            try
            {                                                           
                DataSet ds = Clientes._consulta_des_dni(_dni_ruc, _tienda, _tipo_des);
                dsbuscar = ds;                                   
            }
            catch (Exception exc)
            {
                throw;
               
            }
            
        }
        private void txtdniruc_TextChanged(object sender, TextChangedEventArgs e)
        {
          
                
            //End If

            //Else
            //    If largo >= 1 Then 'evaluamos el tiempo
            //        tiempoFinal = Now
            //        Dim segundos As Long = DateDiff(DateInterval.Second, tiempoInicial, tiempoFinal)
            //        If segundos >= 1 Then
            //            MsgBox("Entrada no permitida por teclado", MsgBoxStyle.Exclamation, "C¢digo")
            //            Me.txtCodBarras.Text = ""
            //            evaluando = False
            //        End If
            //    End If
            //End If
            //If largo = 0 Then
            //    evaluando = False
            //End If
        }

        private void txtbuscar_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key==Key.RightCtrl || e.Key == Key.LeftCtrl)
            //{
            //    switch (e.Key)
            //    {
            //        case  Key.C:
            //            txtbuscar.Text = "";
            //        case Key.P:
            //        case Key.X:
            //            e.Handled = true;
            //            txtbuscar.SelectionLength = 0;
            //            break;
            //    }
            //}

        }

        private void txtbuscar_PreviewTextInput(object sender, TextCompositionEventArgs e)        
        {
           
        }

        private void txtbuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //long largo = txtbuscar.Text.Length;
            //if (!evaluando && largo >= 1)
            //{
            //    tiempoInicial = DateTime.Now;
            //    evaluando = true;
            //}
            //else
            //{
            //    if (largo >= 1)
            //    {
            //        tiempoFinal = DateTime.Now;
            //        TimeSpan diffTime = tiempoFinal - tiempoInicial;
            //        long segundos = diffTime.Seconds; //DateA DateDiff(DateInterval.Second, tiempoInicial, tiempoFinal)
            //        if (segundos >= 1)
            //        {
            //            MessageBox.Show("Entrada no permitida por teclado");
            //            txtbuscar.Text = "";
            //            evaluando = false;
            //        }
            //    }
            //}
            //if (largo == 0)
            //{
            //    evaluando = false;
            //}
        }

        private void btBackPanelLiq_Click(object sender, RoutedEventArgs e)
        {
            Principal frm = new Principal();
            frm.Show();
            this.Close();
        }

        private void btCloseSesion_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txttelefono_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtdireccion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtemail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtdniruc_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtdniruc_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            SoloNumeros(e);
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

        private void txtdniruc_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (!key_combina) return;
            long largo = txtdniruc.Text.Length;
            if (!evaluando && largo >= 1)
            {
                tiempoInicial = DateTime.Now;
                evaluando = true;
            }
            else
            {
                if (largo >= 1)
                {
                    tiempoFinal = DateTime.Now;
                    TimeSpan diffTime = tiempoFinal - tiempoInicial;
                    long segundos = diffTime.Seconds; //DateA DateDiff(DateInterval.Second, tiempoInicial, tiempoFinal)
                    if (segundos >= 1)
                    {
                        MessageBox.Show("Entrada no permitida por teclado",
                       "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        //MessageBox.Show("Entrada no permitida por teclado");
                        txtdniruc.Text = "";
                        evaluando = false;
                    }
                }
            }
            if (largo == 0)
            {
                evaluando = false;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.SystemKey == Key.F4 && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            //{
            //    MessageBox.Show("ok");
            //}
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.F4 && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) )
            //{
            //    MessageBox.Show("ok");
            //}
            if (e.Key == Key.Tab && (Keyboard.Modifiers & (ModifierKeys.Control | ModifierKeys.Shift)) == (ModifierKeys.Control | ModifierKeys.Shift))
            {
                key_combina = false;
                //MessageBox.Show("CTRL + SHIFT + TAB trapped");
            }
            if (e.Key == Key.F1 && (Keyboard.Modifiers & (ModifierKeys.Control | ModifierKeys.Shift)) == (ModifierKeys.Control | ModifierKeys.Shift))
            {
                key_combina = true;
                //MessageBox.Show("CTRL + SHIFT + TAB trapped");
            }
        }

        private void txtdniruc_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        void ClickPaste(Object sender, RoutedEventArgs args) { txtdniruc.Paste(); }
        void ClickCopy(Object sender, RoutedEventArgs args) { txtdniruc.Copy(); }
        void ClickCut(Object sender, RoutedEventArgs args) { txtdniruc.Cut(); }
        void ClickSelectAll(Object sender, RoutedEventArgs args) { txtdniruc.SelectAll(); }
        void ClickClear(Object sender, RoutedEventArgs args) { txtdniruc.Clear(); }
        void ClickUndo(Object sender, RoutedEventArgs args) { txtdniruc.Undo(); }
        void ClickRedo(Object sender, RoutedEventArgs args) { txtdniruc.Redo(); }

        void ClickSelectLine(Object sender, RoutedEventArgs args)
        {
            int lineIndex = txtdniruc.GetLineIndexFromCharacterIndex(txtdniruc.CaretIndex);
            int lineStartingCharIndex = txtdniruc.GetCharacterIndexFromLineIndex(lineIndex);
            int lineLength = txtdniruc.GetLineLength(lineIndex);
            txtdniruc.Select(lineStartingCharIndex, lineLength);
        }

        void CxmOpened(Object sender, RoutedEventArgs args)
        {
            // Only allow copy/cut if something is selected to copy/cut.
            if (txtdniruc.SelectedText == "")
                cxmItemCopy.IsEnabled = cxmItemCut.IsEnabled = false;
            else
                cxmItemCopy.IsEnabled = cxmItemCut.IsEnabled = true;

            // Only allow paste if there is text on the clipboard to paste.
            if (Clipboard.ContainsText())
                cxmItemPaste.IsEnabled = true;
            else
                cxmItemPaste.IsEnabled = false;
        }
    }
}
