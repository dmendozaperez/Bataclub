using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using www.bataclubvales.com.Bll;
using System.Text.RegularExpressions;
using System.Web.Services;
//using System.Drawing;

namespace www.bataclubvales.com.Form.Vales
{
    public partial class ValesUpd : System.Web.UI.Page
    {
        private static Users _user;
        private static string _data_vales = "Datavales", _nameSessionDataFiltered = "InfoFilter",_nameSessionEstado= "Estado";
        private static string _buscar = "";
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (Session[Constants.NameSessionUser] == null) Utilities.logout(Page.Session, Page.Response);
            else
                _user = (Users)Session[Constants.NameSessionUser];
            if (!IsPostBack)
            {
                inicio();
                txtbuscar.Focus();
            }
        }
        private void sbfiltrar()
        {
            string _str =txtbuscar.Text;                       
            DataTable dt = Utilities.getFilterObject((DataTable)Session[_data_vales], "Code-128", "Barra", "nombres", "dni", "Fecha_Emision", "Fecha_Caducado", _str, _str, _str,_str,_str,_str);
            GridViewSourceType = "filtered";
            Session[_nameSessionDataFiltered] = dt;
            dgvales.DataSource = dt;
            dgvales.DataBind();            
           
        }
        public string GridViewSourceType
        {
            get
            {
                if (ViewState["GridViewSourceType"] == null)
                    ViewState["GridViewSourceType"] = string.Empty;
                return (string)ViewState["GridViewSourceType"];
            }
            set { ViewState["GridViewSourceType"] = value; }
        }
        private void inicio()
        {
            try
            {
                Session[_nameSessionEstado] = "0";
                _buscar = txtbuscar.Text.Trim().ToString();
                int pageSize = 10;
                int _TotalRowCount = 0;
                int currentPage = 1;// Convert.ToInt32(e.CommandArgument);
                //bindGrid(Convert.ToInt32(e.CommandArgument));
                DataTable dt = www.bataclubvales.com.Bll.Vales.dtconsultavales_paginacion(ref currentPage, ref pageSize, ref _TotalRowCount, _buscar);
                dgvales.DataSource = dt;
                dgvales.DataBind();
                generatePager(_TotalRowCount, pageSize, currentPage);

                //DataTable dt = www.bataclubvales.com.Bll.Vales.dtconultavales();
                //dgvales.DataSource = dt;
                //dgvales.DataBind();
                //Session[_data_vales] =dt;                                           
            }
            catch
            {

            }
        }

        protected void btnrefresh_Click(object sender, EventArgs e)
        {
            inicio();
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            sbfiltrar();
        }

      

        protected void btncancelar_Click(object sender, EventArgs e)
        {

        }

        protected void dgvales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvales.PageIndex = e.NewPageIndex;
            dgvales.DataSource = (DataTable)Session[_data_vales];
            dgvales.DataBind();
        }

        [WebMethod()]
        public static string ajax_add_vale(string _nombres,string _email,string _dni,string _pordes,string _fechaini,string _fechafin,string _barra)
        {
            string _valida = "";
            try
            {
               
                string _estado = HttpContext.Current.Session[_nameSessionEstado].ToString();
                _valida = www.bataclubvales.com.Bll.Vales._insertar_vales(_estado, _barra, _nombres, _email, _dni, Convert.ToDecimal(_pordes), Convert.ToDateTime(_fechaini)
                          ,Convert.ToDateTime(_fechafin), _user._nombre);               
            }
            catch(Exception exc)
            {
                
                _valida = exc.Message;
            }

            return _valida;
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            string script = "";
            inicio();
            script = string.Empty;
            script += "closeDialogLoad();";
            script += "tab_mover()";
            System.Web.UI.ScriptManager.RegisterStartupScript(UpdatePanel1, Page.GetType(), "CloseDialog", script, true);
        }

        protected void dgvales_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                // Numero de la fila
                int idRow = Convert.ToInt16(e.Row.RowIndex.ToString());

                try
                {

                            string _est = System.Web.UI.DataBinder.Eval(e.Row.DataItem, "Est_Id").ToString();

                            Image imgmodi = (Image)e.Row.FindControl("imgedit");
                            ///
                            imgmodi.Visible = (_est!= "CO")? true:false;


                            Image imgimp = (Image)e.Row.FindControl("ibanular");
                            ///
                            imgimp.Visible = (_est != "CO") ? true : false;




                }
                catch(Exception exc)
                {
                }
            }
        }

        protected void dgvales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType != DataControlRowType.DataRow)
                    return;
                string str = DataBinder.Eval(e.Row.DataItem, "Barra").ToString();
                ImageButton imageButton1 = (ImageButton)e.Row.FindControl("ibanular");
                imageButton1.Attributes.Add("onclick", "javascript:return confirm('¿Esta seguro de Anular el Vale número : -" + DataBinder.Eval(e.Row.DataItem, "Barra") + "- ?')");


                string _est = System.Web.UI.DataBinder.Eval(e.Row.DataItem, "Est_Id").ToString();

                if (_est == "CA")
                {
                    e.Row.BackColor = System.Drawing.Color.FromName("#ffc7ce");
                    //imgInv.Visible = true;
                    //e.Row.Cells[2].BackColor = Color.FromName("#c6efce");
                }
                if (_est == "CO")
                {
                    e.Row.BackColor = System.Drawing.Color.FromName("#d2f0de");
                    //imgInv.Visible = true;
                    //e.Row.Cells[2].BackColor = Color.FromName("#c6efce");
                }

            }
            catch
            {
            }
        }

        protected void dgvales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            msnMessage.HideMessage();

            //if (e.CommandName.Equals("EditOrder"))
            //{
            //    Session[_nameSessionEstado] = "2";
            //    GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            //    string _code = Convert.ToString(((Label)row.FindControl("lblcode_g")).Text.ToString());
            //    string _barra = Convert.ToString(((Label)row.FindControl("lblbarra_g")).Text.ToString());

              

            //    string script = "";               
            //    script = string.Empty;               
            //    script += "tab_mover_next()";
            //    System.Web.UI.ScriptManager.RegisterStartupScript(UpdatePanel1, Page.GetType(), "CloseDialog", script, true);


            //    lblestado.Text = "Modificando";
            //    lblcode.Text = _code;
            //    lblbarra.Text = _barra;
            //}

                if (e.CommandName.Equals("starnular"))
            {
                this.msnMessage.HideMessage();
                this.msnMessage.Visible = false;
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                string barra = e.CommandArgument.ToString();

                try
                {

                    string _valida = www.bataclubvales.com.Bll.Vales._anular_vales(barra, _user._nombre); //false; //ManifiestoBll._anular_manifiesto(_user._bas_id, Convert.ToDecimal(_idman));
                    if (_valida.Length==0)
                    {
                        txtbuscar.Text = "";               
                        inicio();                                                                   
                        msnMessage.LoadMessage("Se Anulo el Vale N° " + barra, UserControl.ucMessage.MessageType.Information);
                    }
                    else
                    {
                        msnMessage.LoadMessage(_valida, UserControl.ucMessage.MessageType.Error);
                    }

                }
                catch (Exception ex)
                {
                    msnMessage.LoadMessage(ex.Message, UserControl.ucMessage.MessageType.Error);
                }

            }
        }
        public void generatePager(int totalRowCount, int pageSize, int currentPage)
        {
            int totalLinkInPage = 5;
            int totalPageCount = (int)Math.Ceiling((decimal)totalRowCount / pageSize);

            int startPageLink = Math.Max(currentPage - (int)Math.Floor((decimal)totalLinkInPage / 2), 1);
            int lastPageLink = Math.Min(startPageLink + totalLinkInPage - 1, totalPageCount);

            if ((startPageLink + totalLinkInPage - 1) > totalPageCount)
            {
                lastPageLink = Math.Min(currentPage + (int)Math.Floor((decimal)totalLinkInPage / 2), totalPageCount);
                startPageLink = Math.Max(lastPageLink - totalLinkInPage + 1, 1);
            }

            List<ListItem> pageLinkContainer = new List<ListItem>();

            if (startPageLink != 1)
                pageLinkContainer.Add(new ListItem("Primero", "1", currentPage != 1));
            for (int i = startPageLink; i <= lastPageLink; i++)
            {
                pageLinkContainer.Add(new ListItem(i.ToString(), i.ToString(), currentPage != i));
            }
            if (lastPageLink != totalPageCount)
                pageLinkContainer.Add(new ListItem("Ultimo", totalPageCount.ToString(), currentPage != totalPageCount));

            dlPager.DataSource = pageLinkContainer;
            dlPager.DataBind();
        }
        protected void dlPager_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "PageNo")
            {
                int pageSize = 10;
                int _TotalRowCount = 0;
                int currentPage = Convert.ToInt32(e.CommandArgument);
                //bindGrid(Convert.ToInt32(e.CommandArgument));
                DataTable dt = www.bataclubvales.com.Bll.Vales.dtconsultavales_paginacion(ref currentPage, ref pageSize, ref _TotalRowCount, _buscar);
                dgvales.DataSource = dt;
                dgvales.DataBind();
                generatePager(_TotalRowCount, pageSize, currentPage);
            }
        }

        //protected void dgvales_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    //Message1.HideMessage();
        //    //if (e.CommandName.Equals("starnular"))
        //    //{

        //    //}
        //}

        [WebMethod()]
        public static string ajax_get_updatevale()
        {
            HttpContext.Current.Session[_nameSessionEstado] = "2";
            return "1";
        }

        [WebMethod()]
        public static string[] ajax_get_newvale()
        {
            HttpContext.Current.Session[_nameSessionEstado] = "0";
            string[] _valores = new string[4];

            DataTable dt = www.bataclubvales.com.Bll.Vales.dtinicionewvale();
            if (dt!=null)
            {
                if (dt.Rows.Count>0)
                {
                    _valores[0] = dt.Rows[0]["barra"].ToString();
                    _valores[1] = dt.Rows[0]["code"].ToString();
                    _valores[2] = dt.Rows[0]["Porc_Descuento"].ToString();
                    _valores[3] = dt.Rows[0]["Fecha_Emision"].ToString();
                    HttpContext.Current.Session[_nameSessionEstado] = "1";
                }
                else
                {
                    _valores[0] = "";
                    _valores[1] = "";
                    _valores[2] = "";
                    _valores[3] = "";
                }
            }
            else
            {
                _valores[0] = "";
                _valores[1] = "";
                _valores[2] = "";
                _valores[3] = "";
            }


            return _valores;
        }
    }
}