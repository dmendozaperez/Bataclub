<%@ Page Title="" Language="C#" MasterPageFile="~/Design/Site.Master" AutoEventWireup="true" CodeBehind="ValesUpd.aspx.cs" Inherits="www.bataclubvales.com.Form.Vales.ValesUpd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headCPH" runat="server">
      <link media="screen" rel="stylesheet" href="../../Scripts/Colorbox/colorbox.css" />
      <script src="../../Scripts/Colorbox/jquery.colorbox.js" type="text/javascript"></script>      
    <%--  <script src="../../Scripts/Js/Evaluacion.js" type="text/javascript"></script>  --%>    
   <%-- <script type="text/javascript" src="../../Scripts/jquery-1.3.2.min.js" > </script>--%>
   <%-- <script type="text/javascript" src="../../Scripts/jquery.tablesorter-2.0.3.js"></script>--%>
 <%--<script type="text/javascript">
  jQuery(document).ready(function () {
      $("#dgvales").tablesorter({ debug: false, widgets: ['zebra'], sortList: [[0, 0]] });
  });
</script>--%>

    <script type="text/javascript">
        function openDialogLoad() {
            $("#dialog-load").dialog({ modal: true, closeOnEscape: false, closeText: 'hide', resizable: false, width: 400 });
            $("#dialog-load").dialog().dialog("widget").find(".ui-dialog-titlebar-close").hide();
        }
        function closeDialogLoad() {
            $("#dialog-load").dialog("close");
        }
    </script>
    <script type="text/javascript">
        var btnnuevo, btncancelar, tips;
    </script>
     <script type="text/javascript">
        function pageLoad() {
            var isAsyncPostback = Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack();
            if (isAsyncPostback) {
                //Examples of how to assign the ColorBox event to elements
                $(".iframe").colorbox({ width: "86%", height: "98%", iframe: true });
            }
        }
    </script>
      <script type="text/javascript" language="javascript">

        // Validaciones
        function updateTips(t) {
            tips
			.text(tips.text() + t)
			.addClass("ui-state-highlight");
            setTimeout(function () {
                tips.removeClass("ui-state-highlight", 1500);
            }, 500);
        }

        function checkLength(o, n, min, max) {
            if (o.val().length > max || o.val().length < min) {
                o.addClass("ui-state-error");
                updateTips("Tamaño del campo " + n + " debe estar entre " +
					min + " y " + max + ". ");
                return false;
            } else {
                return true;
            }
        }

        //
        function checkRegexp(o, regexp, n) {
            if (!(regexp.test(o.val()))) {
                o.addClass("ui-state-error");
                updateTips(n);
                return false;
            } else {
                return true;
            }
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {       
            $("#tabs1").tabs({
                collapsible: false,
                selected: -1
            });
            $('#tabs1').tabs('select', '#tabs-1'); // Para seleccionar el tab 1 y que este colapsado el panel de insercion de rol           
            var $tabs = $('#tabs1').tabs({ selected: 0, disabled: [1, 2] });
            $tabs.tabs('enable', 0).tabs('select', 0).tabs('disable', 1);
            btnnuevo = $("input[id$='btnnuevo']");

            btnactualizar = $("input[id$='btnactualizar']");
            btncancelar = $("input[id$='btncancelar']");
            tips = $("#validateTips");
            btnnuevo.click(function () {                 
                <%--'<%Session["Estado"] = "'1'"; %>' ;--%>
                limpiar_object();
                get_newvale();
                $tabs.tabs('enable', 1).tabs('select', 1).tabs('disable', 0);             
            })
            

            $("#btact")
            .button()
                .click(function () {
                
                    if (validacion()) {
                        var txtnombres = $("input[id$='txtnombres']");
                        var txtdni = $("input[id$='txtdni']");
                        var txtemail = $("input[id$='txtemail']");
                        var txtdes = $("input[id$='txtdes']");
                        var txtdesde = $("input[id$='txtdesde']");
                        var txthasta = $("input[id$='txthasta']");
                        var lblbarra = document.getElementById("<%=lblbarra.ClientID %>");

                        //var bnaceptar = $("input[id$='btnactualizar']");
                        //allFields = $([]).add(bnaceptar);
                        $("#dialog-confirm").dialog({
                            autoOpen: false,
                            resizable: false,
                            width: 400,
                            height: 160,
                            title: 'Vamos a actualizar el numero de vale ¿continuamos?',
                            modal: true,
                            buttons: {
                                "Continuar": function () {
                                    //var bValid = true;
                                    //var valida;
                                    //allFields.removeClass("ui-state-error");
                                    //bnaceptar.click();
                                    //search();
                                    add_vale_descuento(txtnombres.val(), txtemail.val(), txtdni.val(), txtdes.val(), txtdesde.val(), txthasta.val(), lblbarra.innerText);

                                },
                                Cancelar: function () {
                                    $(this).dialog("close");
                                }
                            },
                            close: function () {
                                //allFields.val("").removeClass("ui-state-error");
                            }
                        });

                        $("#dialog-confirm").dialog("open");

                    }
        
            });
            $("#btcancel")
           .button()
               .click(function () {
                   $tabs.tabs('enable', 0).tabs('select', 0).tabs('disable', 1);
               })
            //btnactualizar.click(function () {

            //    //if (validacion())
            //    //{
            //    //    var txtnombres = $("input[id$='txtnombres']"); 
            //    //    var txtdni = $("input[id$='txtdni']"); 
            //    //    var txtemail = $("input[id$='txtemail']");
            //    //    var txtdes = $("input[id$='txtdes']"); 
            //    //    var txtdesde = $("input[id$='txtdesde']");
            //    //    var txthasta = $("input[id$='txthasta']");
            //    //    //var bnaceptar = $("input[id$='btnactualizar']");
            //    //    //allFields = $([]).add(bnaceptar);
            //    //    $("#dialog-confirm").dialog({
            //    //        autoOpen: false,
            //    //        resizable: false,
            //    //        width: 400,
            //    //        height: 160,
            //    //        title: 'Vamos a generar un nuevo numero de vale ¿continuamos?',
            //    //        modal: true,
            //    //        buttons: {
            //    //            "Continuar": function () {
            //    //                //var bValid = true;
            //    //                //var valida;
            //    //                //allFields.removeClass("ui-state-error");
            //    //                //bnaceptar.click();
            //    //                //search();
            //    //                add_vale_descuento(txtnombres.val(), txtemail.val(), txtdni.val(), txtdes.val(), txtdesde.val(), txthasta.val());

            //    //            },
            //    //            Cancelar: function () {
            //    //                $(this).dialog("close");
            //    //            }
            //    //        },
            //    //        close: function () {
            //    //            //allFields.val("").removeClass("ui-state-error");
            //    //        }
            //    //    });

            //    //    $("#dialog-confirm").dialog("open");
                    
            //    //}
                
               
            //})

            //btncancelar.click(function () {
            //    $tabs.tabs('enable', 0).tabs('select', 0).tabs('disable', 1);
            //})
        })
        
        function tab_mover() {
            var $tabs = $('#tabs1').tabs({ selected: 0, disabled: [1, 2] });
            $tabs.tabs('enable', 0).tabs('select', 0).tabs('disable', 1);
        }

        function tab_mover_next() {
            var $tabs = $('#tabs1').tabs({ selected: 0, disabled: [1, 2] });
            $tabs.tabs('enable', 1).tabs('select', 1).tabs('disable', 0);
        }

        function add_vale_descuento(_nombres,_email,_dni,_pordes,_fechaini,_fechafin,_barra) {
            $.ajax({
                type: "POST",
                data: "{  '_nombres': '" + _nombres + "','_email': '" + _email + "','_dni': '" + _dni + "','_pordes': '" + _pordes + "','_fechaini': '" + _fechaini + "','_fechafin': '" + _fechafin + "','_barra': '" + _barra + "'}",
                url: "ValesUpd.aspx/ajax_add_vale",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    if (result.d.length == 0) {
                        
                        $("#dialog-confirm").dialog("close");
                        //var $tabs = $('#tabs1').tabs({ selected: 0, disabled: [1, 2] });

                        var bnaceptar = $("input[id$='btnactualizar']");

                        openDialogLoad();

                        bnaceptar.click();

                        //$tabs.tabs('enable', 0).tabs('select', 0).tabs('disable', 1);
                        

                       
                    }
                    else {
                        $("#dialog-confirm").dialog("close");
                        alert(result.d);
                    }
                },
                error: function (result) { $("#dialog-confirm").dialog("close"); alert("A ocurrido un error y no se han realizado los cambios, verifique que su sesión no haya expirado, e intente de nuevo." + result); }
            });
        }
        function limpiar_object() {
            var txtnombres = document.getElementById('<%=txtnombres.ClientID %>');
            var txtemail = document.getElementById('<%=txtemail.ClientID %>');
            var txtdni = document.getElementById('<%=txtdni.ClientID %>');
            var txtdes = document.getElementById('<%=txtdes.ClientID %>');
            var txtdesde = document.getElementById('<%=txtdesde.ClientID %>');
            var txthasta = document.getElementById('<%=txthasta.ClientID %>');
            var lblbarra = document.getElementById('<%=lblbarra.ClientID %>');
            var lblcode = document.getElementById('<%=lblcode.ClientID %>');

            lblbarra.innerText = "";
            lblcode.innerText = "";
            txtnombres.value = "";
            txtemail.value = "";
            txtdni.value = "";
            txtdes.value = "";
            txtdesde.value = "";
            txthasta.value = "";
            
        }

             function refresh_session() {
            $.ajax({
                type: "POST",                
                url: "ValesUpd.aspx/ajax_get_updatevale",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {                                                      
                },
                error: function (result) { alert("A ocurrido un error y no se han realizado los cambios, verifique que su sesión no haya expirado, e intente de nuevo." + result); }
            });
         }

        function edicion_vales(obj) {

             refresh_session();

             var GridView1 = document.getElementById("<%=dgvales.ClientID %>");
             var rowIndex = obj.offsetParent.parentNode.rowIndex;

             limpiar_object();
             
            
             var lblestado = document.getElementById('<%=lblestado.ClientID %>');
             var lblbarra = document.getElementById('<%=lblbarra.ClientID %>');
             var lblcode = document.getElementById('<%=lblcode.ClientID %>');   
             var txtnombres = document.getElementById('<%=txtnombres.ClientID %>');   
             var txtemail = document.getElementById('<%=txtemail.ClientID %>');   
             var txtdni = document.getElementById('<%=txtdni.ClientID %>');
             var txtdes = document.getElementById('<%=txtdes.ClientID %>');
             var txtdesde = document.getElementById('<%=txtdesde.ClientID %>');
             var txthasta = document.getElementById('<%=txthasta.ClientID %>');

             lblestado.innerText = '[Editando Vale]';

             var _code = GridView1.rows[rowIndex].cells[0].getElementsByTagName("span");
             var _barra = GridView1.rows[rowIndex].cells[1].getElementsByTagName("span");
             var _nombre = GridView1.rows[rowIndex].cells[2].getElementsByTagName("span");
             var _email = GridView1.rows[rowIndex].cells[3].getElementsByTagName("span");
             var _dni = GridView1.rows[rowIndex].cells[4].getElementsByTagName("span");
             var _des = GridView1.rows[rowIndex].cells[5].getElementsByTagName("span");
             var _fdesde = GridView1.rows[rowIndex].cells[6].getElementsByTagName("span");
             var _fhasta = GridView1.rows[rowIndex].cells[7].getElementsByTagName("span");

             var str_des = _des[0].innerHTML;
             
             lblcode.innerText = _code[0].innerHTML;;
             lblbarra.innerText = _barra[0].innerHTML;
             txtnombres.value = _nombre[0].innerHTML;
             txtemail.value = _email[0].innerHTML;
             txtdni.value = _dni[0].innerHTML;
             txtdes.value = str_des.substring(0, 2);
             txtdesde.value = _fdesde[0].innerHTML;
             txthasta.value = _fhasta[0].innerHTML;

             var $tabs = $('#tabs1').tabs({ selected: 0, disabled: [1, 2] });
             $tabs.tabs('enable', 1).tabs('select', 1).tabs('disable', 0);

        }


        function validacion() {
            tips.text("");
            var _valor = true;
            var txtnombres = $("input[id$='txtnombres']"); //document.getElementById('<%=txtnombres.ClientID %>');            
            var txtemail = $("input[id$='txtemail']");
            var txtdes = $("input[id$='txtdes']"); //document.getElementById('<%=txtdes.ClientID %>');
            var txtdesde = $("input[id$='txtdesde']");
            var txthasta = $("input[id$='txthasta']");
            var grupotext = $([]).add(txtnombres).add(txtemail).add(txtdes).add(txtdesde).add(txthasta);

            grupotext.removeClass("ui-state-error");

            if (txtnombres.val().length == "") {
                txtnombres.addClass("ui-state-error");
                updateTips(" Ingrese el nombre del cliente.");
                txtnombres.focus();
                return false;
            }
           
            if (txtdes.val() == "" || txtdes.val() == "0") {
                txtdes.addClass("ui-state-error");
                updateTips(" Ingrese el % descuento.");
                txtdes.focus();
                return false;
            }

            _valor = checkRegexp(txtemail, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, " Dígite un correo válido. ej. user@bata.com.");            

            if (!_valor) {
                txtemail.focus();
                return _valor;
            }
            if (txtdesde.val().length == "") {
                txtdesde.addClass("ui-state-error");
                updateTips(" Ingrese la fecha de Inicio del Vale.");
                //txtdesde.focus();
                return false;
            }
            if (txthasta.val().length == "") {
                txthasta.addClass("ui-state-error");
                updateTips(" Ingrese la fecha final del Vale.");
                //txtdesde.focus();
                return false;
            }

            return _valor
        }

        function get_newvale() {
            $.ajax({
                type: "POST",
                //data: "{  'items': '" + items + "','area': '" + area + "'}",
                url: "ValesUpd.aspx/ajax_get_newvale",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    var lblestado = document.getElementById('<%=lblestado.ClientID %>');
                    var lblbarra = document.getElementById('<%=lblbarra.ClientID %>');
                    var lblcode = document.getElementById('<%=lblcode.ClientID %>');
                    var txtdes = document.getElementById('<%=txtdes.ClientID %>');                    
                    var txtnombres = document.getElementById('<%=txtnombres.ClientID %>');                    
                    lblestado.innerText = '[Nuevo Vale de Descuento]';
                    lblbarra.innerText = result.d[0];
                    lblcode.innerText = result.d[1];
                    txtdes.value = result.d[2];
                    txtnombres.focus();
                    //txtcomentario.value = result.d[2];                                     
                },
                error: function (result) { alert("A ocurrido un error y no se han realizado los cambios, verifique que su sesión no haya expirado, e intente de nuevo." + result); }
            });
        }

    </script>
      <style type="text/css">
          .auto-style1 {
              width: 135px;
          }
          .auto-style3 {
              height: 9px;
          }
          .auto-style4 {
              font-size: 1.2em;
              width: 73px;
          }
          .auto-style5 {
              font-size: 1.2em;
              width: 74px;
          }
          .auto-style6 {
              height: 9px;
              width: 74px;
          }
          .auto-style7 {
              width: 74px;
          }
          .auto-style8 {
              height: 9px;
              width: 135px;
          }
          .auto-style9 {
              width: 260px;
          }
      </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    Actualizacion de Vales Activos 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageDesc" runat="server">
    En esta ventana se ingresara y consultara los vales activos de las tiendas
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True" EnableScriptGlobalization="True"></asp:ScriptManager>   
  
    <asp:UpdatePanel ID="upPanelMsg" runat="server">
        <ContentTemplate>
            <AQControl:Message runat="server" Visible="false" ID="msnMessage"></AQControl:Message>
        </ContentTemplate>
    </asp:UpdatePanel>    
     <div id="tabs1">
          <ul>
            <li><a href="#tabs-1">Consulta</a></li>
            <li><a href="#tabs-2">Actualizar</a></li>
        </ul>
         <div id="tabs-1">
             <div>

                 <table style="width:100%;">
                     <tr>
                         <td>                                                           
                             <table>
                                 <tr>
                                     <td class="auto-style9">

                                     </td>
                                     <td>

                                     </td>
                                     <td>
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                            <ProgressTemplate>
                                            <center>
                                            <div style="position: absolute; left: 0; background: #f5f5f5; filter: alpha(opacity=85);
                                            opacity: 0.85; font-family: Georgia; text-align: center; width: 100%; font-size: medium;">
                                            <img src="../../Design/images/ajax-loader.gif" alt="Por Favor Espere; Cargando Información." />
                                            Cargando información...
                                            </div>
                                            </center>
                                            </ProgressTemplate>
                                            </asp:UpdateProgress>
                                     </td>
                                 </tr>                               
                                 <tr>
                                      <td style="color:red;" class="auto-style9">
                                         Buscar por Code,Barra,Nombres,Email y Dni:&nbsp;
                                     </td>
                                     <td style="width:180px;">
                                         <asp:TextBox ID="txtbuscar" runat="server"  ></asp:TextBox>                                    
                                     </td>
                                     <td>
                                         <asp:Button ID="btnbuscar" style="display:none;" Text="Filtrar" runat="server" OnClick="btnbuscar_Click" />
                                     </td>
                                     <td>
                                         <asp:Button ID="btnrefresh" Text="Buscar" runat="server" OnClick="btnrefresh_Click" />
                                     </td>
                                 </tr>
                             </table>                                                             
                         </td>                         
                     </tr>  
                     <tr>
                         <td>                            
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                                 <ContentTemplate>
                                     <asp:GridView ID="dgvales" runat="server" AutoGenerateColumns="False"
                SkinID="evaviewSkin" PageSize="15" OnPageIndexChanging="dgvales_PageIndexChanging" OnRowCreated="dgvales_RowCreated" OnRowCommand="dgvales_RowCommand" OnRowDataBound="dgvales_RowDataBound" >
                <Columns>
                      <asp:TemplateField HeaderText="[Code-128]">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("[Code-128]") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblcode_g" runat="server" Text='<%# Bind("[Code-128]") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>          
                    <asp:TemplateField HeaderText="[Barra]">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Barra") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblbarra_g" runat="server" Text='<%# Bind("Barra") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>                   
                     <asp:TemplateField HeaderText="[Nombres]">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("nombres") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("nombres") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="[E-Mail]">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="[Dni ó RUC]">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("dni") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("dni") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="[%Desc]">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Porc_Descuento","{0:##%}") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Porc_Descuento","{0:##%}") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Fecha Inicio]">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Fecha_Emision", "{0:d}") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Fecha_Emision", "{0:d}") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="[Fecha Final]">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Fecha_Caducado", "{0:d}") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("Fecha_Caducado", "{0:d}") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="[Estado]">
                        <EditItemTemplate>
                            <asp:Label ID="TextBox7" runat="server" Text='<%# Bind("[Est_Descripcion]") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblestado_g" runat="server" Text='<%# Bind("[Est_Descripcion]") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="[Campaña]">
                        <EditItemTemplate>
                            <asp:Label ID="TextBox7" runat="server" Text='<%# Bind("[CAMP]") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblcamp_g" runat="server" Text='<%# Bind("[CAMP]") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit." ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgedit" OnClick='<%# "edicion_vales(this);" %>' CommandArgument='<%# Eval("Barra")%>'
                                                CommandName="EditOrder" runat="server" ImageUrl="~/Design/images/Botones/b_edit_order.png"
                                                Visible="false" ToolTip="Cargar para edición." BorderWidth="0" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="Anular" ItemStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                            <asp:ImageButton ID="ibanular" CommandName="starnular"  CommandArgument='<%# Eval("Barra")%>'
                                                  Visible="false" runat="server" ImageUrl="~/Design/images/Botones/delete_off.png" ToolTip="eliminar registro" BorderWidth="0" />
                      
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                </Columns>
                <%--<HeaderStyle Wrap="False" />--%>
            </asp:GridView>
                                 </ContentTemplate>
                                 <Triggers>
                                     <asp:AsyncPostBackTrigger ControlID="dgvales" EventName="PageIndexChanging" />
                                     <asp:AsyncPostBackTrigger ControlID="btnnuevo" EventName="Click" />                                                                        
                                     <asp:AsyncPostBackTrigger ControlID="btnrefresh" EventName="Click" />
                                     <asp:AsyncPostBackTrigger ControlID="btnbuscar" EventName="Click" />
                                     <asp:AsyncPostBackTrigger ControlID="btnactualizar" EventName="Click" />
                                     <asp:AsyncPostBackTrigger ControlID="btncancelar" EventName="Click" />
                                     <asp:AsyncPostBackTrigger ControlID="dgvales" EventName="RowCommand" />
                                     <asp:AsyncPostBackTrigger ControlID="dlPager" EventName="ItemCommand" />
                                 </Triggers>
                             </asp:UpdatePanel>
                         </td>
                     </tr>
                     <tr>
                         <td>
                             <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                 <ContentTemplate>
                                 <asp:DataList CellPadding="5" RepeatDirection="Horizontal" runat="server" ID="dlPager" BackColor="Khaki"
                                        onitemcommand="dlPager_ItemCommand">
                                        <ItemTemplate>
                                        <asp:LinkButton  ForeColor="Blue" Enabled='<%#Eval("Enabled") %>' runat="server" ID="lnkPageNo" Text='<%#Eval("Text") %>' CommandArgument='<%#Eval("Value") %>' CommandName="PageNo"></asp:LinkButton>
                                        </ItemTemplate>
                                </asp:DataList>
                                </ContentTemplate>
                             </asp:UpdatePanel>
                                
                         </td>
                     </tr>
                     <tr>
                         <td>

                         </td>
                     </tr>
                     <tr>
                         <td>
                            <asp:Button ID="btnnuevo" runat="server" Text="Ingresar Nuevo Vale de Descuento" />
                         </td>
                         <td>

                         </td>
                     </tr>
                     </table>

             </div>
         </div>
         <div id="tabs-2">
             <table style="align-content:center">   
                 <tr>
                     <td>

                     </td>
                     <td>

                     </td>
                     <td>
                          <p id="validateTips">
                            </p>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style1">
                        
                     </td>
                     <td class="auto-style5" style="color:red;">
                         Estado:<br />
                     </td>
                     <td>
                         <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                             <ContentTemplate>--%>
                             <asp:Label ID="lblestado" runat="server" Text="" Font-Bold="true" ForeColor="Red" Font-Size="14px"></asp:Label>
                           <%--  </ContentTemplate>
                         </asp:UpdatePanel>    --%>                      
                     </td>
                     <td>
                       
                     </td>
                 </tr>                       
                 <tr>
                     <td class="auto-style1">
                        
                     </td>
                     <td class="auto-style5">
                         Barra:<br />
                     </td> 
                     <td>
                         <asp:Label ID="lblbarra" runat="server" Text="" Font-Bold="true" ForeColor="#0099cc" Font-Size="16px"></asp:Label>
                     </td>    
                     <td class="auto-style4">
                         Dni:<br />
                     </td>     
                     <td>
                         <asp:TextBox ID="txtdni" runat="server" TabIndex="3" MaxLength="11" Width="120"></asp:TextBox>
                     </td>            
                 </tr>
                 <tr>
                     <td class="auto-style1">
                        
                     </td>
                     <td class="auto-style5">
                         Code:<br />
                     </td>
                     <td>
                         <asp:Label ID="lblcode" runat="server" Text="" Font-Bold="true" Font-Size="16px"></asp:Label>
                     </td>
                     <td class="auto-style4">
                          %Desc.<br />
                     </td>
                     <td>
                         <asp:TextBox ID="txtdes" runat="server" TabIndex="3" MaxLength="2" Width="25"></asp:TextBox>
                     </td>     
                 </tr>
                 <tr>
                     <td class="auto-style1">
                        
                     </td>
                     <td class="auto-style5">
                         Nombres:<br />
                     </td>
                     <td>
                         <asp:TextBox ID="txtnombres" runat="server" TabIndex="1" MaxLength="100" Width="300px"></asp:TextBox>
                     </td>
                     <td class="auto-style4">
                         F.Inicio:<br />
                     </td>
                      <td>
                                <asp:UpdatePanel ID="upStartDate" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtdesde" Enabled="false" runat="server" TabIndex="4" AccessKey="f"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="calendar" runat="server" Animated="true" 
                                            FirstDayOfWeek="Monday" Format="dd/MM/yyyy" PopupButtonID="imgCalendard" 
                                            TargetControlID="txtdesde" />
                                    </ContentTemplate>                                   
                                </asp:UpdatePanel>
                            </td>
                             <td align="left">
                                            <asp:Image ID="imgCalendard"  runat="server" ImageUrl="~/Design/images/Botones/b_calendar_ico.gif"
                                                onmouseover="this.style.background='red';" Height="20px" Width="20px" onmouseout="this.style.background=''"
                                                Style="cursor:pointer;" />
                            </td>
                 </tr>
                 <tr>
                     <td class="auto-style1">
                        
                     </td>
                     <td class="auto-style5">
                         E-Mail:<br />
                     </td>
                     <td>
                         <asp:TextBox ID="txtemail" runat="server" TabIndex="2" MaxLength="100" Width="300px"></asp:TextBox>
                     </td>
                     <td class="auto-style4">
                       F.Final:<br />
                     </td>
                      <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txthasta" Enabled="false" TabIndex="5" runat="server" AccessKey="f"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="true" 
                                            FirstDayOfWeek="Monday" Format="dd/MM/yyyy" PopupButtonID="imgCalendarh" 
                                            TargetControlID="txthasta" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                             <td align="left">
                                            <asp:Image ID="imgCalendarh"  runat="server" ImageUrl="~/Design/images/Botones/b_calendar_ico.gif"
                                                onmouseover="this.style.background='red';" Height="20px" Width="20px" onmouseout="this.style.background=''"
                                                Style="cursor:pointer;" />
                            </td>
                 </tr>
                 <tr>
                     <td class="auto-style8">

                     </td>
                      <td class="auto-style6">

                     </td>
                      <td class="auto-style3">

                     </td>
                 </tr>
                 <tr>
                      <td class="auto-style1">
                        
                     </td>
                      <td class="auto-style7">
                        
                     </td>
                     <td>
                         <table>
                             <tr>
                                 <td>
                                       <asp:Button ID="btnactualizar" style="display:none"  TabIndex="6" runat="server" Text="Actualizar" OnClick="btnactualizar_Click"  />
                                         <button type="button" value=" (A)ctualizar" id="btact" tabindex="6"
                                         title="Proceda actualizar vale">
                                        (A)ctualizar</button>  
                                 </td>
                                 <td>
                                     <asp:Button ID="btncancelar" TabIndex="7" style="display:none" runat="server" Text="Cancelar" OnClick="btncancelar_Click" />
                                      <button type="button" value=" (C)ancelar" id="btcancel" tabindex="7"
                                         title="Cancela la operación">
                                        (C)ancelar</button>  
                                 </td>
                             </tr>
                         </table>                                                
                     </td>
                     <td>
                         
                     </td>
                     <td>

                     </td>
                     <td>

                     </td>
                     <td>
                          
                     </td>
                 </tr>
             </table>
            
         </div>
     </div>
     <div id="dialog-confirm" style="display: none;">
    <p>
        <span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>
        Actualizaremos el vale de descuento; ¿desea continuar?</p>
    </div>
     <div id="dialog-load" style="display:none"   title="Guardando informacion">
    <p>
        <span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>
        Estamos guardando la informacion, por favor espere un momento.</p>    
    <p style="text-align: center">
        <img src="../../Design/images/ajax-loader.gif" alt="Por Favor Espere; Guardando Información." />        
        </p>
           <ajaxToolkit:UpdatePanelAnimationExtender ID="upae" runat="server" TargetControlID="UpdatePanel1">
            <Animations>
                                        <OnUpdating>
                                            <Sequence>
                                                <%-- Disable all the controls --%>
                                                <Parallel duration="0">
                                                    <EnableAction AnimationTarget="btnbuscar" Enabled="false" />                                                   
                                                    <EnableAction AnimationTarget="btnrefresh" Enabled="false" />                                                   
                                                    <EnableAction AnimationTarget="btnnuevo" Enabled="false" />                                                   
                                                </Parallel>
                                            </Sequence>
                                        </OnUpdating>
                                        <OnUpdated>
                                            <Sequence>
                                                <%-- Enable all the controls --%>
                                                <Parallel duration="0">
                                                    <EnableAction AnimationTarget="btnbuscar" Enabled="true" />
                                                    <EnableAction AnimationTarget="btnrefresh" Enabled="true" />
                                                    <EnableAction AnimationTarget="btnnuevo" Enabled="true" />
                                                </Parallel>
                                            </Sequence>
                                        </OnUpdated>
            </Animations>
        </ajaxToolkit:UpdatePanelAnimationExtender>
</div>
</asp:Content>
