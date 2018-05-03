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
    public partial class Datos_Cliente : Window
    {
        public static Boolean _activo_form = false;
        private string _DNI = "";
        public  DataTable datos = null;

        /*public Datos_Cliente()
        {
            InitializeComponent();
        }*/

        public Datos_Cliente(string DNI)
        {
            InitializeComponent();
            _DNI = DNI;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtdni.Text = _DNI;
            txtapemat.Text = "";
            txtapepat.Text = "";
            txtnombres.Text = "";
            btnactualizar.IsEnabled = false;
            txtnombres.Focus();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            if (txtapemat.Text.Length > 0 && txtapepat.Text.Length > 0 && txtnombres.Text.Length > 0)
            {
            }
            else
            {
                MessageBox.Show("Ingrese nuevamente DNI.",
               "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            _activo_form = false;
        }

        private void btCloseSesion_Click(object sender, RoutedEventArgs e)
        {
            if (txtapemat.Text.Length > 0 && txtapepat.Text.Length > 0 && txtnombres.Text.Length > 0)
            {
                DataTable dt = new DataTable();
                dt.TableName = "Cliente";
                dt.Columns.Add("fc_ruc", typeof(string));
                dt.Columns.Add("fc_nomb", typeof(string));
                dt.Columns.Add("fc_apep", typeof(string));
                dt.Columns.Add("fc_apem", typeof(string));

                dt.Rows.Add(txtdni.Text, txtnombres.Text, txtapepat.Text, txtapemat.Text);
                datos = dt;
                DialogResult = false;
                this.Close();
            }else
            {
                MessageBox.Show("Es Obligatorio ingresar esta informacion",
               "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btBackPanelLiq_Click(object sender, RoutedEventArgs e)
        {
            if (txtapemat.Text.Length > 0 && txtapepat.Text.Length > 0 && txtnombres.Text.Length > 0)
            {
                DataTable dt = new DataTable();
                dt.TableName = "Cliente";
                dt.Columns.Add("fc_ruc", typeof(string));
                dt.Columns.Add("fc_nomb", typeof(string));
                dt.Columns.Add("fc_apep", typeof(string));
                dt.Columns.Add("fc_apem", typeof(string));

                dt.Rows.Add(txtdni.Text, txtnombres.Text, txtapepat.Text, txtapemat.Text);
                datos = dt;
                DialogResult = false;
                this.Close();
            }
            else
            {
                MessageBox.Show("Es Obligatorio ingresar esta informacion",
               "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtdatos_TextChanged(object sender, RoutedEventArgs e)
        {
            if (txtapemat!= null && txtapepat != null && txtnombres != null)
            {
                if (txtapemat.Text.Length > 0 && txtapepat.Text.Length > 0 && txtnombres.Text.Length > 0)
                {
                    if(btnactualizar!= null)
                    {
                        btnactualizar.IsEnabled = true;
                    }
                }
                else
                {
                    if (btnactualizar != null)
                    {
                        btnactualizar.IsEnabled = false;
                    }
                }
            }
        }

        private void btnactualizar_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.TableName = "Cliente";
            dt.Columns.Add("fc_ruc", typeof(string));
            dt.Columns.Add("fc_nomb", typeof(string));
            dt.Columns.Add("fc_apep", typeof(string));
            dt.Columns.Add("fc_apem", typeof(string));

            dt.Rows.Add(txtdni.Text, txtnombres.Text, txtapepat.Text, txtapemat.Text);
            datos = dt;
            //DialogResult = false;
            this.Close();
        }
        
    }
}
