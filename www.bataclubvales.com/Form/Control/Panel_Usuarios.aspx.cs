using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using www.bataclubvales.com.Bll;
using System.Data;
using System.Web.Services;
namespace www.bataclubvales.com.Form.Control
{
    public partial class Panel_Usuarios : System.Web.UI.Page
    {
        private Users _user;

        private bool respuesta;

        string DSFunctions = "DataSetFunctions";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Constants.NameSessionUser] == null)
                Utilities.logout(Page.Session, Page.Response);
            else
                _user = (Users)Session[Constants.NameSessionUser];

            if (!IsPostBack)
            {
                Session.Remove(DSFunctions);
                fillDropDawn();
                fill();
            }
        }
        protected void fill()
        {
            DataSet data = Users._leer_usuario();
            //data.Tables[0].DefaultView.Sort = "Usu_Login";
            gridFunctions.DataSource = data.Tables[0];
            gridFunctions.DataBind();
            Session[DSFunctions] = data;
        }
        protected void fillDropDawn()
        {
            //cabezera grabar
            DataTable dtestado = Users._leer_estado(0);
            dtestado.DefaultView.Sort = "Est_Descripcion";
            dwestadog.DataSource = dtestado;
            dwestadog.DataTextField = "Est_Descripcion";
            dwestadog.DataValueField = "Est_Id";
            dwestadog.DataBind();
            dwestadog.Items.Insert(0, new ListItem("(vacio)", ""));
            dwestadog.SelectedValue = "A";

            ////leer usuario intranet supervisor
            //DataTable dtsupervisor = Users._leer_super_intranet();
            //dtsupervisor.DefaultView.Sort = "descripcion";
            //dwsuper.DataSource = dtsupervisor;
            //dwsuper.DataTextField = "descripcion";
            //dwsuper.DataValueField = "codigo";
            //dwsuper.DataBind();
            //dwsuper.Items.Insert(0, new ListItem("(vacio)", ""));
           
            //***************************

            DataTable dtnivel = Users._leer_Nivel();
            dtnivel.DefaultView.Sort = "Niv_Nombre";
            dwnivelg.DataSource = dtnivel;
            dwnivelg.DataTextField = "Niv_Nombre";
            dwnivelg.DataValueField = "Niv_Id";
            dwnivelg.DataBind();
            dwnivelg.Items.Insert(0, new ListItem("(vacio)", ""));


            //*******************

            //DataTable dtestado = Users._leer_estado(0);
            dtestado.DefaultView.Sort = "Est_Descripcion";
            dwestado.DataSource = dtestado;
            dwestado.DataTextField = "Est_Descripcion";
            dwestado.DataValueField = "Est_Id";
            dwestado.DataBind();
            dwestado.Items.Insert(0, new ListItem("(vacio)", ""));


            //DataTable dtnivel = Users._leer_Nivel();
            dtnivel.DefaultView.Sort = "Niv_Nombre";
            dwnivel.DataSource = dtnivel;
            dwnivel.DataTextField = "Niv_Nombre";
            dwnivel.DataValueField = "Niv_Id";
            dwnivel.DataBind();
            dwnivel.Items.Insert(0, new ListItem("(vacio)", ""));

        }
     
        protected void gridFunctions_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridFunctions.PageIndex = e.NewPageIndex;
            DataSet data = (DataSet)Session[DSFunctions];
            data.Tables[0].DefaultView.Sort = "Usu_Login";
            gridFunctions.DataSource = data.Tables[0];
            gridFunctions.DataBind();
        }
        public void eraseFields()
        {
            txtnombre.Text = "";
            txtdocumento.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtcelular.Text = "";
            txtcorreo.Text = "";
            txtlogin.Text = "";
            txtcontraseña.Text = "";
            
            //DDPadre.SelectedIndex = 0;
        }

        [WebMethod()]        
        public static Users_Intranet getsupervisor(string cod_super)
        {
            Users_Intranet user_in;
            try
            {
                DataTable dt = Users_Intranet._leer_datos_intranet(cod_super);
                if (dt!=null)
                {
                    if (dt.Rows.Count>0)
                    {
                        user_in = new Users_Intranet
                        {
                            _usu_documento_intranet = dt.Rows[0]["documento"].ToString(),
                            _usu_direccion_intranet = dt.Rows[0]["direccion"].ToString(),
                        };
                    }
                    else
                    {
                        user_in = new Users_Intranet();
                    }
                }
                else
                {
                    user_in = new Users_Intranet();
                }
            }
            catch
            {
                user_in = new Users_Intranet();
            }
            return user_in;
        }

        [WebMethod()]
        public static string ajaxUpdateUsuario(decimal usu_id, string usu_nombre, string usu_documento, string usu_direccion, string usu_telefono,
                                               string usu_celular,string usu_correo,string usu_contraseña,string usu_id_estado,string usu_id_nivel)
        {



            
            bool respuesta = Users.updateUsuario(usu_id,usu_nombre,usu_documento,usu_direccion,usu_telefono,usu_celular,usu_correo,usu_contraseña,usu_id_estado,usu_id_nivel);

            if (respuesta)
                return "1";
            else
                return "-1";
        }

        protected void btnrefresh_Click(object sender, EventArgs e)
        {
            fill();
        }

        protected void btnSaveusuario_Click(object sender, EventArgs e)
        {            
            msnMessage.HideMessage();
            try
            {
                string _nombre = txtnombre.Text;
                string _documento = txtdocumento.Text;
                string _direccion = txtdireccion.Text;
                string _telefono =txttelefono.Text;
                string _celular = txtcelular.Text;
                string _correo = txtcorreo.Text;
                string _login = txtlogin.Text;
                string _contraseña =txtcontraseña.Text;
                string _est_id = dwestadog.SelectedValue;
                string _niv_id = dwnivelg.SelectedValue;
                string _sup_id = dwsuper.SelectedValue;

                if (_est_id.Length==0)
                {
                    msnMessage.LoadMessage("No ha seleccionado el estado del usuario", UserControl.ucMessage.MessageType.Error);
                    dwestadog.Focus();
                    return;
                }

                if (_niv_id.Length == 0)
                {
                    msnMessage.LoadMessage("No ha seleccionado el nivel del usuario", UserControl.ucMessage.MessageType.Error);
                    dwnivelg.Focus();
                    return;
                }

                if (_niv_id == "03" && _sup_id.Length==0)
                {
                    msnMessage.LoadMessage("No ha seleccionado ningun usuario", UserControl.ucMessage.MessageType.Error);
                    dwsuper.Focus();
                    return;
                }

                respuesta = Users._grabar_usuario(_nombre, _documento, _direccion, _telefono, _celular, _correo, _login, _contraseña, _est_id, _niv_id, _sup_id);

                if (respuesta)
                {
                    msnMessage.LoadMessage("Usuario insertada satisfactoriamente", UserControl.ucMessage.MessageType.Information);
                    eraseFields();
                    fill();
                }
                else
                    msnMessage.LoadMessage("Ocurrio un problema durante la insercion", UserControl.ucMessage.MessageType.Error);

            }
            catch (Exception) { msnMessage.LoadMessage("Ocurrio un problema durante la insercion", UserControl.ucMessage.MessageType.Error); }
        }
        

    }
}