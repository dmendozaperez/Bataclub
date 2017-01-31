using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using www.bataclubvales.com.Bll;
namespace www.bataclubvales.com.Form.Control
{
    public partial class Editar_Password : System.Web.UI.Page
    {
        Users _user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Constants.NameSessionUser] == null) Utilities.logout(Page.Session, Page.Response);
            else
                _user = (Users)Session[Constants.NameSessionUser];
            if (!IsPostBack)
            {
                txtPassAnterior.Focus();
                txtusername.Text = _user._usu_nombre;
               
            }
        }

      

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if ((_user._usu_contraseña).Equals(txtPassAnterior.Text.Trim())
                         &
                        (!string.IsNullOrEmpty(txtPassNew.Text.Trim()))

                        )
                    {
                        _user._usu_est_id= "A";
                        _user._usu_contraseña=(txtPassNew.Text.Trim());
                        string _error=_user._modificar_contraseña_user();
                        if (_error.Length>0)
                        {
                            msnMessage.LoadMessage(_error, UserControl.ucMessage.MessageType.Error);               
                        }
                        else
                        { 
                        msnMessage.LoadMessage("Su contraseña se ha cambiado satisfactoriamente.", UserControl.ucMessage.MessageType.Information);
                        }
                    }
                    else
                    {
                        throw new InvalidCastException();
                    }
                }
            }
            catch (InvalidCastException)
            {
                msnMessage.LoadMessage("Hubo un error. No se realizaron los cambios por que la contraseña anterior no es valida o la nueva contraseña ya la habia utilizado.", UserControl.ucMessage.MessageType.Error);               
            }
        }
    }
}