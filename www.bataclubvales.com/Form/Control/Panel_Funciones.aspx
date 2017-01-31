<%@ Page Title="" Language="C#" MasterPageFile="~/Design/Site.Master" AutoEventWireup="true" CodeBehind="Panel_Funciones.aspx.cs" Inherits="www.bataclubvales.com.Form.Control.Panel_Funciones" %>
<asp:Content ID="Content4" ContentPlaceHolderID="headCPH" runat="server">
     <link media="screen" rel="stylesheet" href="../../Scripts/Colorbox/colorbox.css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">        
    <script src="../../Scripts/Colorbox/jquery.colorbox.js" type="text/javascript"></script>
    Control de Funciones 
    <script type="text/javascript">
        $(document).ready(function () {
            $(".iframe").colorbox({ width: "35%", height: "50%", iframe: true });
            $("#tabs").tabs({
                collapsible: true
            });
            $('#tabs').tabs('select', '#tab-1'); // Para seleccionar el tab 1 y que este colapsado el panel de insercion de rol 
        });

        function updateFunction(FUN_ID, FUV_NAME, FUV_DESCRIPTION, FUN_ORDER, FUN_FATHER) {
            removeFieldsErrors();
            $("#impFav_name").val(FUV_NAME);
            $("#impFun_Order").val(FUN_ORDER);
            $("#impFuv_Desc").val(FUV_DESCRIPTION);
            $("#<%= DDPadre2.ClientID %> option[value='" + FUN_FATHER + "']").attr('selected', 'selected');
            $("#dialog").dialog({ width: 400, height: 230, modal: true, title: 'Editar ' + FUV_NAME, open: true });
            $("#dialog").dialog({ buttons: [{
                text: "Actualizar Funcion",
                click: function () {
                    if (Validacion())
                        updateFunctionAjax(FUN_ID);
                }
            }]
            });
        }

        function updateFunctionAjax(FUN_ID) {
            $.ajax({
                type: "POST",
                data: "{  'FUN_ID': '" + FUN_ID + "','FUV_NAME': '" + $("#impFav_name").val() + "','FUV_DESCRIPTION': '" + $("#impFuv_Desc").val() + "','_FUN_ORDER': '" + $("#impFun_Order").val() + "','_FUN_FATHER': '" + $("#<%= DDPadre2.ClientID %>").val() + "'}",
                url: "Panel_Funciones.aspx/ajaxUpdateFunction",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    if (result.d == new String("1")) {
                        $('#dialog').dialog("close");
                        var bnaceptar = $("input[id$='btnrefresh']");
                        allFields = $([]).add(bnaceptar);
                        bnaceptar.click();
                    }
                    else {
                        alert("Ocurrio un error durante la acutalizacion");
                    }
                },
                error: function (result) { alert("A ocurrido un error y no se han realizado los cambios, verifique que su sesión no haya expirado, e intente de nuevo." + result); }
            });
        }
        function Validacion() {
            var bValid = true;
            removeFieldsErrors();

            bValid = bValid && checkNull($("#impFav_name"), "*Nombre de la funcion no puede estar vacio");

            return bValid;
        }

        function removeFieldsErrors() {
            $("#validateTips").text("");
            $("#impFav_name").removeClass("ui-state-error");
        }

        // Validaciones
        function checkNull(field, t) {
            if (field.val() == "") {
                field.addClass("ui-state-error")
                updateTips(t);
                return false;
            }
            else { return true; }
        }

        function updateTips(t) {
            $("#validateTips")
			.text($("#validateTips").text() + t)
            .addClass("ui-state-highlight");
            setTimeout(function () {
                $("#validateTips").removeClass("ui-state-highlight", 3500);
            }, 500);
        }

        function pageLoad() {
            var isAsyncPostback = Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack();
            if (isAsyncPostback) {
                //Examples of how to assign the ColorBox event to elements
                $(".iframe").colorbox({ width: "35%", height: "50%", iframe: true });
            }
        }

    </script>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPageDesc" runat="server"> 
    Muestra la lista de Funciones utilizadas. Permite crear nuevas funciones dentro
    del sistema y editar las existentes.   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <!-- Area de errores -->
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
     <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <AQControl:Message ID="msnMessage" Visible="false" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSaveFuction" EventName="click" />
        </Triggers>
    </asp:UpdatePanel>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Nueva Funcion</a></li>
        </ul>
        <div id="tabs-1">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        Nombre:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server" Width="260px" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RFValidator" runat="server" ErrorMessage="*" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Padre:
                    </td>
                    <td>
                        <asp:DropDownList ID="DDPadre" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Orden
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrden" runat="server" Width="260px" />
                    </td>
                    <td>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Descripcion:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDesc" runat="server" Width="260px" />
                    </td>
                    <td>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Sistema:
                    </td>
                    <td>
                        <asp:DropDownList ID="DDFUN_System" runat="server">
                            <asp:ListItem Text="Sistema de Auditoria" Value="1" Selected="True" />                           
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        <asp:Button ID="btnSaveFuction" Text="Guardar" runat="server" OnClick="btnSaveFuction_Click" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnrefresh" runat="server" OnClick="btnrefresh_Click" Text="Button" ValidationGroup="G1"  style="display:none" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <br />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:GridView ID="gridFunctions" AllowPaging="True" runat="server" AutoGenerateColumns="False"
                SkinID="gridviewSkin" 
                OnPageIndexChanging="gridFunctions_PageIndexChanging">
                <Columns>                    
                    <asp:BoundField DataField="FUN_ID" HeaderText="Id" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fun_nombre" HeaderText="Nombre" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fun_orden" HeaderText="Orden" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fun_padre" HeaderText="Padre" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fun_sis_id" HeaderText="Sistema" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <center>
                                <a href="#" onclick="updateFunction('<%# Eval("FUN_ID") %>','<%# Eval("FUN_NOMBRE") %>','<%# Eval("FUN_DESCRIPCION") %>','<%# Eval("FUN_ORDEN") %>','<%# Eval("FUN_PADRE") %>')">
                                    <asp:Image ID="Image1" ImageUrl="~/Design/images/Botones/editOrder.png" runat="server" />
                                </a>
                            </center>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Aplicacion">
                        <ItemTemplate>
                            <center>
                                <a class="iframe" href="panelFunc_App.aspx?FUN_ID=<%# Eval("FUN_ID")%>&FUN_NOMBRE=<%# Eval("FUN_NOMBRE") %>)"
                                 title="Adicionar aplicacion a funcion.">
                                    <asp:Image ID="Image2" ImageUrl="~/Design/images/Botones/b_app.png" runat="server" />
                                </a>
                            </center>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnrefresh" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <div id="dialog" class="f13" style="display: none; font-size: 10px;">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    Nombre:
                </td>
                <td>
                    <input id="impFav_name" type="text" name="name" value=" " style="width: 300px" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Padre:
                </td>
                <td>
                    <asp:DropDownList ID="DDPadre2" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Orden:
                </td>
                <td>
                    <input id="impFun_Order" type="text" name="name" value=" " style="width: 300px" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Description:
                </td>
                <td>
                    <input id="impFuv_Desc" type="text" name="name" value=" " style="width: 300px" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <p id="validateTips">
                    </p>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
