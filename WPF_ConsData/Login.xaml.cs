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
using System.Deployment.Application;
using Bata.Clases;
using ConsultReniec;
using System.Drawing;
//using AForge.Imaging.Filters;
using System.IO;
using System.Drawing.Imaging;
//using AForge;

namespace Bata
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        PersonaReniec myInfo;
        //IntRange red = new IntRange(0, 255);
        //IntRange green = new IntRange(0, 255);
        //IntRange blue = new IntRange(0, 255);
        public Login()
        {
            InitializeComponent();
            //if (ApplicationDeployment.IsNetworkDeployed)
            //{
            //    ApplicationDeployment appDeployment = ApplicationDeployment.CurrentDeployment;
            //    Version version = appDeployment.CurrentVersion;
            //    //txtcodigo.Text = "Version : " + version.ToString();
            //}
            //else
            //{
            //    // txtcodigo.Text = "Version : [not deployed via ClickOnce]";
            //}
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //actualizar version
            //Mouse.OverrideCursor = Cursors.Wait;
            actualizar_win();
            //Mouse.OverrideCursor = null;
            //****
            iniciarsession();
            //Mouse.OverrideCursor = Cursors.Wait;
            //CargarImagen();
            //txtcodigo.Focus();
            //Mouse.OverrideCursor = null;

        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
                      
            iniciarsession();
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

        private void iniciarsession()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            //si la web service de reniec esta inactivo entonces ingresa 

            if (!txtcodigo.IsEnabled)
            {
                DialogResult = true;
                this.Close();  
                Mouse.OverrideCursor = null;
                return;
            }


            string _codigo = txtcodigo.Text;
            if (_codigo.Length == 0)
            {
                MessageBox.Show("Ingrese el codigo de la imagen...",
                     "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
                txtcodigo.Focus();
                Mouse.OverrideCursor = null;
            }
            PersonaReniec myInfo = Clientes._persona_reniec;
            //myInfo.UseTesseract()
            myInfo.GetInfo("41149120", _codigo);
            //myInfo.GetInfo("10426026118", myInfo.UseTesseract());
            CaptionResul();
            Mouse.OverrideCursor = null;
        }
        private void CaptionResul()
        {
            PersonaReniec myInfo = Clientes._persona_reniec;
            try
            {

                switch (myInfo.GetResul)
                {
                    case PersonaReniec.Resul.Ok:
                        Clientes._str_codigo_captcha_reniec = txtcodigo.Text;
                        DialogResult = true;
                        this.Close();
                        break;
                    case PersonaReniec.Resul.NoResul:
                        MessageBox.Show("No existe DNI",
                       "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtcodigo.SelectAll();
                        txtcodigo.Focus();
                        break;
                    case PersonaReniec.Resul.ErrorCapcha:
                        CargarImagen();
                        MessageBox.Show("Ingrese imagen correctamente",
                        "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtcodigo.SelectAll();
                        txtcodigo.Focus();
                        break;
                    case PersonaReniec.Resul.Error:
                        MessageBox.Show("Error Desconocido",
                        "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtcodigo.SelectAll();
                        txtcodigo.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CargarImagen()
        {

            try
            {
                if (myInfo == null)
                    myInfo = new PersonaReniec();
                System.Drawing.Image img = myInfo.GetCapcha;

                //guardar en variable global
                Clientes._img_captcha = img;

                byte[] imgb = imageToByteArray(img);// .GetCapcha();
                //La convierto a BitmapImage
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = new System.IO.MemoryStream(imgb);
                image.EndInit();
                //Pongo la imagen como fuente
                imgKey.Source = image;

                Bitmap bmp = new Bitmap(ToWinFormsBitmap(image));
                FiltroInvertir(ref bmp);
                ColorFiltros(ref bmp);

                FiltroInvertir(ref bmp);

                imgKey.Source = ToWpfBitmap(bmp);


                Clientes._persona_reniec = myInfo;
                //this.imgKey.Source = HelperFunctions.returnImage(iconStream2);// .  Image = myInfo.GetCapcha;
            }
            catch (Exception ex)
            {
                txtcodigo.IsEnabled = false;                
                
                MessageBox.Show(ex.Message,
                     "Bata - Mensaje De Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ColorFiltros(ref Bitmap bmp)
        {
            //Red Min - MAX
            //red.Min = Math.Min(red.Max, byte.Parse("229"));
            //red.Max = Math.Max(red.Min, byte.Parse("255"));
            ////Verde Min - MAX
            //green.Min = Math.Min(green.Max, byte.Parse("0"));
            //green.Max = Math.Max(green.Min, byte.Parse("255"));
            ////Azul Min - MAX
            //blue.Min = Math.Min(blue.Max, byte.Parse("0"));
            //blue.Max = Math.Max(blue.Min, byte.Parse("130"));
            ActualizarFiltro(ref bmp);
        }
        private void ActualizarFiltro(ref Bitmap bmp)
        {
            //ColorFiltering FiltroColor = new ColorFiltering();
            //FiltroColor.Red = red;
            //FiltroColor.Green = green;
            //FiltroColor.Blue = blue;
            //IFilter Filtro = FiltroColor;
            ////Bitmap bmp = new Bitmap(imgKey.Source);
            //Bitmap XImage = Filtro.Apply(bmp);

            //bmp = XImage;

            //pictureCapchaE.Image = XImage;
        }
        private Bitmap ToWinFormsBitmap(BitmapSource bitmapsource)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapsource));
                enc.Save(stream);

                using (var tempBitmap = new Bitmap(stream))
                {
                    // According to MSDN, one "must keep the stream open for the lifetime of the Bitmap."
                    // So we return a copy of the new bitmap, allowing us to dispose both the bitmap and the stream.
                    return new Bitmap(tempBitmap);
                }
            }
        }
        private void FiltroInvertir(ref Bitmap bmp)
        {
            //IFilter Filtro = new Invert();
            //Bitmap XImage = Filtro.Apply(bmp);

            //bmp = XImage;
            //imgKey.Source = ToWpfBitmap(XImage);
            //pictureCapchaE.Image = XImage;
        }
        private  byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        public  BitmapSource ToWpfBitmap(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Bmp);

                stream.Position = 0;
                BitmapImage result = new BitmapImage();
                result.BeginInit();
                // According to MSDN, "The default OnDemand cache option retains access to the stream until the image is needed."
                // Force the bitmap to load right now so we can dispose the stream.
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();
                return result;
            }
        }

        private void btconsulta_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            CargarImagen();
            Mouse.OverrideCursor = null;
        }       
    }
}
