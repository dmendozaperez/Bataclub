using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
//using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Bata
{
    /// <summary>
    /// Lógica de interacción para MarcacionHorario.xaml
    /// </summary>
    public partial class MarcacionAsistencia : Window
    {

        private Boolean evaluando = false;
        private DateTime tiempoInicial;
        private DateTime tiempoFinal;
        private string wcodtda = Environment.GetEnvironmentVariable("CODTDA");  // variable de entorno
        public static Boolean _activo_form = false;

        //System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        //dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
        //dispatcherTimer.Interval = new TimeSpan(0,5,0);
        //dispatcherTimer.Start();


        //DataObject.AddPastingHandler(control, this.OnCancelCommand);
        //DataObject.AddCopyingHandler(control, this.OnCancelCommand);

        public MarcacionAsistencia()
        {
            InitializeComponent();
            txtcodsuper.Focus();
        }

        private void cmdGrabar_Click(object sender, RoutedEventArgs e)
        {

            if (Validar())
            {
                Grabar();
            }

        }

        private void Grabar()
        {
            string graba = "1";
            if (graba == "1")
            {
                Mouse.OverrideCursor = Cursors.Wait; // cursor de espera
                
                string wcodsuper    = txtcodsuper.Password.Substring(0, 5);  //txtcodsuper.Text.Substring(1, 5);                
                DateTime wfechahora = DateTime.Now;
                string wuser        = "POSNET"; // usuario en blanco

                BataTransaction.Autenticacion aut = new BataTransaction.Autenticacion();
                aut.user_name     = "emcomer";
                aut.user_password = "Bata2013";

                BataTransaction.bata_transaccionSoapClient ws = new BataTransaction.bata_transaccionSoapClient();

                var resul = ws.ws_inserta_asistencia(aut, wcodsuper, wcodtda, wfechahora, wuser);
                string wrpta1 = "", wrpta2 = "";

                Mouse.OverrideCursor = null; // fin cursor de espera

                if (resul != null)
                {
                    wrpta1 = resul[0].ToString(); // "1"
                    wrpta2 = resul[1].ToString(); // "Los datos se grabaron exitosamente"

                    if (wrpta1 == "1")
                    {
                        System.Windows.MessageBox.Show("La Marcación se grabo correctamente", "Atención",MessageBoxButton.OK,MessageBoxImage.Information);
                        NuevoIngreso();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("ERROR al grabar Marcación " + wrpta2, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("ERROR al grabar Marcación " + wrpta2, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                

            }

        }

        private Boolean Validar()
        {
            if (txtcodsuper.Password.Trim() == string.Empty)
            {
                MessageBox.Show("Escanee su codigo de barras", "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false; 
            }

            // Volver a validar los tiempos de digitacion
            TimeSpan diffTime = tiempoFinal - tiempoInicial;
            long segundos = diffTime.Milliseconds; //DateA DateDiff(DateInterval.Second, tiempoInicial, tiempoFinal)
            if (segundos >= 1000)
            {
                MessageBox.Show("Entrada no permitida por teclado, Solo se permite la marcación con el escaner","Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }

            return true;
        }

        private void txtcodsuper_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //if (!key_combina) return;
            long largo = txtcodsuper.Password.Length;
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
                    double segundos = diffTime.TotalSeconds; //DateA DateDiff(DateInterval.Second, tiempoInicial, tiempoFinal)
                    if (segundos > 1)
                    {
                        MessageBox.Show("Entrada no permitida por teclado",
                       "Solo se permite la marcación con el escaner", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        txtcodsuper.Password = "";
                        evaluando = false;
                    }

                    if (txtcodsuper.Password.Length > 5)
                    {
                        txtnomsuper.Text = txtcodsuper.Password.Substring(5).ToUpper(); // Muestra el apellido del supervisor
                    }
                }
            }
            if (largo == 0)
            {
                evaluando = false;
            }
        }

        private void NuevoIngreso()
        {
            txtcodsuper.Password = "";
            txtnomsuper.Text = "";
            evaluando        = false;
            txtcodsuper.Focus();
        }

        private void txtcodsuper_PreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if ((e.Command == ApplicationCommands.Cut) ||
                (e.Command == ApplicationCommands.Copy) ||
                (e.Command == ApplicationCommands.Paste))
            {
                e.Handled = true;
                e.CanExecute = false;
            }
        }

        private void cmdCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            if (string.IsNullOrEmpty(wcodtda))
            {
                MessageBox.Show("VARIABLE DE ENTORNO [TIENDA] NO DEFINIDA", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                cmdgrabar.IsEnabled = false;

            }

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            txtfechahora.Text = DateTime.Now.ToString("HH:mm:ss");
            //CommandManager.InvalidateRequerySuggested();
            //listBox1.Items.MoveCurrentToLast();
            //listBox1.SelectedItem = listBox1.Items.CurrentItem;
            //listBox1.ScrollIntoView(listBox1.Items.CurrentItem);
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            _activo_form = false;
        }
    }
}
