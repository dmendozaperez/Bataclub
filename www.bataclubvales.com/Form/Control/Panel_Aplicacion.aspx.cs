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
    public partial class Panel_Aplicacion : System.Web.UI.Page
    {
        public bool respuesta;
        public Users _user;

        public string DSApplication = "DataSetApplications";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Constants.NameSessionUser] == null)
                Utilities.logout(Page.Session, Page.Response);
            else
                _user = (Users)Session[Constants.NameSessionUser];

            if (!IsPostBack)
            {
                Session.Remove(DSApplication);              
                llenarGrillar();
            }    
        }
       
        protected void llenarGrillar()
        {
            DataTable data = ApplicationClass.GetAllAplications();
            data.DefaultView.Sort = "apl_nombre";
            GridApplication.DataSource = data;
            GridApplication.DataBind();
            Session[DSApplication] = data;
        }
        protected void SaveApp_Click(object sender, EventArgs e)
        {
            ApplicationClass App = new ApplicationClass();

           
            App._APN_ID = 0;
            App._APV_NAME = txtNombre.Text.Trim();            
            App._APV_URL = txtRutaUrl.Text;

            if (txtOrden.Text != String.Empty)
                App._APN_ORDER = Convert.ToDecimal(txtOrden.Text);
            
            App._APV_STATUS = DDStatus.SelectedValue;
            App._APV_HELP = txtRutaUrlHelp.Text;
            App._APV_COMMENTS = txtComentario.Text;

            respuesta = App.InsertApplication();

            if (respuesta)
            {
                llenarGrillar();
                eraseFields();
            }
        }
        public void eraseFields()
        {
            txtNombre.Text = "";
            txtComentario.Text = "";
            txtOrden.Text = "";
            txtRutaUrl.Text = "";
            txtRutaUrlHelp.Text = "";            
        }
       

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            msnMessage.HideMessage();

            if (txtFilterGrid.Text != String.Empty)
            {
                llenarGrillar();
                DataTable data = (DataTable)Session[DSApplication];
                EnumerableRowCollection<DataRow> filteredRows = data.AsEnumerable().Where(x => x.Field<string>("apl_nombre").ToUpper().Contains(txtFilterGrid.Text.Trim().ToUpper()));

                if (filteredRows.Count() > 0)
                {
                    DataTable dataFiltrado = filteredRows.CopyToDataTable();
                    Session[DSApplication] = dataFiltrado;
                    dataFiltrado.DefaultView.Sort = "apl_nombre";
                    GridApplication.DataSource = dataFiltrado;
                    GridApplication.DataBind();
                }
                else
                    msnMessage.LoadMessage("Palabra no encontrada.", UserControl.ucMessage.MessageType.Information);
            }
            else
            {
                msnMessage.LoadMessage("Digite una palabra para filtrar por nombre", UserControl.ucMessage.MessageType.Information);
                llenarGrillar();
            }
        }

        protected void GridApplication_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridApplication.PageIndex = e.NewPageIndex;
            DataTable data = (DataTable)Session[DSApplication];
            data.DefaultView.Sort = "apl_nombre";
            GridApplication.DataSource = data;
            GridApplication.DataBind();
        }
        [WebMethod()]
        public static string ajaxUpdateApp(decimal APN_ID, string APV_NAME, string APV_URL, decimal APN_ORDER, string APV_STATUS, string APV_HELP, string APV_COMMENTS)
        {

            bool respuesta = ApplicationClass.UpdateApplication(APN_ID, APV_NAME, APV_URL, APN_ORDER, APV_STATUS, APV_HELP, APV_COMMENTS);

            if (respuesta)
                return "1";
            else
                return "-1";

        }

        protected void btnrefresh_Click(object sender, EventArgs e)
        {
            llenarGrillar();
        }

        
    }
}