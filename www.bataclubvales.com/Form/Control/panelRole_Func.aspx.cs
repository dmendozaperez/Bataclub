using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using www.bataclubvales.com.Bll;
using System.Data;
namespace www.bataclubvales.com.Form.Control
{
    public partial class panelRole_Func : System.Web.UI.Page
    {
        protected Users _user;

        
        public decimal _RON_ID { get; set; }
        public decimal _FUN_ID { get; set; }

        public bool respuesta;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblInfo.Text = Request.QueryString["ROV_NAME"];
            _RON_ID = Convert.ToDecimal(Request.QueryString["RON_ID"]);

            if (Session[Constants.NameSessionUser] == null)
                Utilities.logout(Page.Session, Page.Response);
            else
                _user = (Users)Session[Constants.NameSessionUser];

            if (!IsPostBack)
            {
                llenarDrop();
                llenarGrilla();
            }
        }
        public void llenarGrilla()
        {
            GridFunctions.DataSource = Functions.GetFunctionsByRol(_RON_ID);
            GridFunctions.DataBind();
        }
        public void llenarDrop()
        {
            DataTable datos = Functions.GetAllFunctionsDS().Tables[0];
            datos.DefaultView.Sort = "fun_nombre";
            DDListFunctions.DataSource = datos;
            DDListFunctions.DataTextField = "fun_nombre";
            DDListFunctions.DataValueField = "fun_id";
            DDListFunctions.DataBind();
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            _FUN_ID = Convert.ToDecimal(DDListFunctions.SelectedValue);

            respuesta = Functions.InsertRoleFunction(_FUN_ID, _RON_ID);

            if (respuesta)
            {
                lblInfo.Text = "Adicion correcta";
                llenarGrilla();
            }
            else
            {
                lblInfo.Text = "Ocurrio un problema";
            }
        }

        protected void GridFunctions_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridFunctions.PageIndex = e.NewPageIndex;
            llenarGrilla();
        }

        protected void GridFunctions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                _FUN_ID = Convert.ToDecimal(e.CommandArgument);

                respuesta = Functions.RemoveRoleFunction(_FUN_ID, _RON_ID);

                if (respuesta)
                    llenarGrilla();
            }
        }
    }
}