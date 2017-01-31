using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proy_Prueba
{
    public partial class Form1 : Form
    {
        //ConsultReniec.PersonaSunat myInfo;
        public Form1()
        {
            InitializeComponent();
            try
            {
                CargarImagen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void CaptionResul()
        {
            //try
            //{
            //    switch (myInfo.GetResul)
            //    {
            //        case ConsultReniec.PersonaSunat.Resul.Ok:
            //           this.txtDireccion.Text = myInfo.Nombres + " " + myInfo.ApePaterno + " " + myInfo.ApeMaterno;
            //            break;
            //        case ConsultReniec.PersonaSunat.Resul.NoResul:
            //            this.txtDireccion.Text = "No existe DNI";
            //            break;
            //        case ConsultReniec.PersonaSunat.Resul.ErrorCapcha:
            //            CargarImagen();
            //            this.txtDireccion.Text = "Ingrese imagen correctamente";
            //            break;
            //        case ConsultReniec.PersonaSunat.Resul.Error:
            //            this.txtDireccion.Text = "Error Desconocido";
            //            break;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        void CargarImagen()
        {
            //try
            //{
            //    if (myInfo == null)
            //        myInfo = new ConsultReniec.PersonaSunat();
            //    this.pictureCapcha.Image = myInfo.GetCapcha;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarImagen();
                this.txtCapcha.SelectAll();
                this.txtCapcha.Focus();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //llamamos a los metodos de la libreria ConsultaReniec...
            //    myInfo.GetInfo(this.txtNumDni.Text, this.txtCapcha.Text);
            //    this.txtDireccion.Text = myInfo.ApeMaterno;
            //    this.txtRazon.Text = myInfo.Nombres;
            //    this.txtRuc.Text = txtNumDni.Text;
            //    this.txtNumDni.Text = "";
            //    this.txtCapcha.Text = "";
            //    CargarImagen(); 
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureCapcha.Visible = true;
        }
        //este es el metodo que agregue ... el evento KeyPress para la tecla enter ...
        //ahora les explico ... luego de quitar el color y procesar la imagen esta quedaria asi 
        private void txtNumDni_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            //if (e.KeyChar == Convert.ToChar(Keys.Enter))
            //{
            //    myInfo.GetInfo(this.txtNumDni.Text, myInfo.UseTesseract());
            //    if (myInfo.Nombres == "Error!")
            //    {
            //        CargarImagen();
            //        myInfo.GetInfo(this.txtNumDni.Text, myInfo.UseTesseract());
            //        this.txtDireccion.Text = myInfo.ApeMaterno;
            //        this.txtRazon.Text = myInfo.Nombres;
            //        this.txtRuc.Text = txtNumDni.Text;
            //        this.txtNumDni.Text = "";
            //        this.txtCapcha.Text = "";
            //        CargarImagen();
            //    }
            //    else
            //    {
            //        this.txtDireccion.Text = myInfo.ApeMaterno;
            //        this.txtRazon.Text = myInfo.Nombres;
            //        this.txtRuc.Text = txtNumDni.Text;
            //        this.txtNumDni.Text = "";
            //        this.txtCapcha.Text = "";
            //        CargarImagen();
            //    }
            //}
            
        }
    }
}
