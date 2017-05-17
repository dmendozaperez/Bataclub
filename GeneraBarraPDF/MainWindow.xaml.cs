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
using GeneraBarraPDF.Bll;
namespace GeneraBarraPDF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnejecuta_Click(object sender, RoutedEventArgs e)
        {
            ejecutar();
        }
        private void ejecutar()
        {

            // Basico.GeneraPDF(@"D:\GeneraCupon\cupon2.html", @"D:\GeneraCupon\cupon.pdf");


            Mouse.OverrideCursor = Cursors.Wait;


            Int32 _contar = 0;

            Basico.ejecuta_pdf(@"D:\GeneraCupon\cupon2.html", @"D:\GeneraCupon\Barra",ref _contar);
            MessageBox.Show("Se Genero " + _contar.ToString() + " Codigo de Barra");
            Mouse.OverrideCursor = null;
        }
    }
}
