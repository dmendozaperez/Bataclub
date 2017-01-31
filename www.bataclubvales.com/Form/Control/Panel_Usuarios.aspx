<%@ Page Title="" Language="C#" MasterPageFile="~/Design/Site.Master" AutoEventWireup="true" CodeBehind="Panel_Usuarios.aspx.cs" Inherits="www.bataclubvales.com.Form.Control.Panel_Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headCPH" runat="server">
    <link media="screen" rel="stylesheet" href="../../Scripts/Colorbox/colorbox.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <script src="../../Scripts/Colorbox/jquery.colorbox.js" type="text/javascript"></script>    
    Control de Usuario
    <script type="text/javascript">
        function getDropdownListSelectedText() {
            var DropdownList = document.getElementById('<%=dwnivelg.ClientID %>');
            var SelectedIndex = DropdownList.selectedIndex;
            var SelectedValue = DropdownList.value;
            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;

            var _txtnombre = document.getElementById('<%=txtnombre.ClientID %>');
            var _dwsuper = document.getElementById('<%=dwsuper.ClientID %>');

            var _txtdoc = document.getElementById('<%=txtdocumento.ClientID %>');
            var _txtdir = document.getElementById('<%=txtdireccion.ClientID %>');

            if(SelectedValue=='03')
            {
                _txtnombre.style.display = "none";                                
                _dwsuper.style.display = "block";                               
                _txtdoc.readOnly = true;
                _txtdir.readOnly = true;
                _txtdoc.style.backgroundColor = "#FFFFCC";
                _txtdir.style.backgroundColor = "#FFFFCC";

            }
            else
            {
                _txtnombre.style.display = "block";
                _txtnombre.value = "";
                _dwsuper.style.display = "none";
                _txtdoc.readOnly = false;
                _txtdir.readOnly = false;
                _txtdoc.value = "";
                _txtdir.value = "";
                _dwsuper.value = "";
                _txtdoc.style.backgroundColor = "";
                _txtdir.style.backgroundColor = "";
               
            }          
        }
    </script>
    <script type="text/javascript">
        function getDropdownListSelectedText_super() {
            var DropdownList = document.getElementById('<%=dwsuper.ClientID %>');
            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
            var _txtnombre = document.getElementById('<%=txtnombre.ClientID %>');
            var SelectedIndex = DropdownList.selectedIndex;
            var SelectedValue = DropdownList.value;
            getsupervisor(SelectedValue);
            _txtnombre.value = SelectedText;           
        }
        function getsupervisor(cod) {
            //Ajax
            var urlMethod = "Panel_Usuarios.aspx/getsupervisor";
            var jsonData = '{cod_super:"' + cod + '"}';
            SendAjax(urlMethod, jsonData, showtext);
        }
        function SendAjax(urlMethod, jsonData, returnFunction) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: urlMethod,
                data: jsonData,
                dataType: "json",
                //async: true,
                success: function (msg) {
                    // 
                    if (msg != null) {
                        returnFunction(msg);
                    }
                },
                error: function (xhr, status, error) {
                    // Boil the ASP.NET AJAX error down to JSON.
                    var err = eval("(" + xhr.responseText + ")");
                    onAjaxError(err.Message);
                }
            });
        }
        function showtext(msg) {
            var val = msg.d;          
            $("input[id$='txtdocumento']").val(val._usu_documento_intranet).val();
            $("input[id$='txtdireccion']").val(val._usu_direccion_intranet).val();
        }
        function onAjaxError(errorMsg) {
            // Display the specific error raised by the server            
            showLoad(false, errorMsg, false);
            alert(errorMsg);
            $el.focus();
            afterLoad();
        }
    </script>

    <script type="text/javascript">
        function Chk_AdminClick(sender) {
            var chkBox = sender;
            var Checked = chkBox.checked;
            if (Checked == true) {
                document.getElementById("imp_contraseña").removeAttribute("readonly");
                document.getElementById("imp_contraseña").focus();
                document.getElementById("imp_contraseña").style.backgroundColor = "#FFFF99";
            }
            else {
                document.getElementById('imp_contraseña').value = "";
                document.getElementById("imp_contraseña").setAttribute("readonly", "readonly");
                document.getElementById("imp_contraseña").style.backgroundColor = "White";
                
            }
        }

    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $(".iframe").colorbox({ width: "35%", height: "50%", iframe: true });
            $("#tabs").tabs({
                collapsible: true
            });
            $('#tabs').tabs('select', '#tab-1'); // Para seleccionar el tab 1 y que este colapsado el panel de insercion de rol 
        });

        function updateusuario(usu_id, usu_nombre, usu_documento, usu_direccion, usu_telefono, usu_celular,usu_correo,usu_login,usu_estado,usu_nivel) {
            removeFieldsErrors();
            $("#imp_nombre").val(usu_nombre);
            $("#imp_documento").val(usu_documento);
            $("#imp_direccion").val(usu_direccion);
            $("#imp_telefono").val(usu_telefono);
            $("#imp_celular").val(usu_celular);
            $("#imp_correo").val(usu_correo);
            $("#imp_login").val(usu_login);
            $("#<%= dwestado.ClientID %> option[value='" + usu_estado + "']").attr('selected', 'selected');
            $("#<%= dwnivel.ClientID %> option[value='" + usu_nivel + "']").attr('selected', 'selected');
            $("#dialog").dialog({ width: 590, height: 240, modal: true, title: 'Editar ' + usu_login, open: true });
            $("#dialog").dialog({ buttons: [{
                text: "Actualizar Usuario",
                click: function () {
                    if (Validacion())
                        updateUsuarioAjax(usu_id);
                }
            }]
            });
        }

        function updateUsuarioAjax(usu_id) {
            $.ajax({
                type: "POST",
                data: "{  'usu_id': '" + usu_id + "','usu_nombre': '" + $("#imp_nombre").val() + "','usu_documento': '" + $("#imp_documento").val() + "','usu_direccion': '" + $("#imp_direccion").val() + "','usu_telefono': '" + $("#imp_telefono").val() + "','usu_celular': '" + $("#imp_celular").val() + "','usu_correo': '" + $("#imp_correo").val() + "','usu_contraseña': '" + $("#imp_contraseña").val() + "','usu_id_estado': '" + $("#<%= dwestado.ClientID %>").val() + "','usu_id_nivel': '" + $("#<%= dwnivel.ClientID %>").val() + "'}",
                url: "Panel_Usuarios.aspx/ajaxUpdateUsuario",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    if (result.d == new String("1")) {                        
                        var chkBox = document.getElementById("chkactv");
                        var Checked = chkBox.checked;

                        if (Checked != true) {

                            $('#dialog').dialog("close");
                            var bnaceptar = $("input[id$='btnrefresh']");
                            allFields = $([]).add(bnaceptar);
                            bnaceptar.click();
                        }
                        else
                        {
                            if ($("#imp_contraseña").val() == "")
                            {
                                alert("La Contraseña no puede estar vacia");
                            }
                            else
                            {
                                $('#dialog').dialog("close");
                                var bnaceptar = $("input[id$='btnrefresh']");
                                allFields = $([]).add(bnaceptar);
                                bnaceptar.click();
                            }
                            
                        }

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

            bValid = bValid && checkNull($("#imp_nombre"), "*Nombre del Usuario no puede estar vacio");
            //bValid = bValid && checkNull($("#imp_login"), "*Login del Usuario no puede estar vacio");

            return bValid;
        }

        function removeFieldsErrors() {
            $("#validateTips").text("");
            $("#imp_nombre").removeClass("ui-state-error");
            $("#imp_documento").removeClass("ui-state-error");
            $("#imp_direccion").removeClass("ui-state-error");
            $("#imp_telefono").removeClass("ui-state-error");
            $("#imp_celular").removeClass("ui-state-error");
            $("#imp_correo").removeClass("ui-state-error");
            $("#imp_login").removeClass("ui-state-error");            
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageDesc" runat="server">
    Formularios para crear usuario y  asignar roles.
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            <asp:AsyncPostBackTrigger ControlID="btnSaveusuario" EventName="click" />
        </Triggers>
    </asp:UpdatePanel>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Nuevo Usuario</a></li>
        </ul>
        <div id="tabs-1">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        Nombres:
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                             <ContentTemplate>
                            <asp:TextBox ID="txtnombre" runat="server" Width="250px" TabIndex="100" />
                                 <asp:DropDownList ID="dwsuper" runat="server" tabindex="109"  style="display:none;" onchange="getDropdownListSelectedText_super();" >
                    </asp:DropDownList>
                                 </ContentTemplate>
                        </asp:UpdatePanel>                                                
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RFValidator" runat="server" ErrorMessage="*" ControlToValidate="txtnombre"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        Correo</td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtcorreo" runat="server" Width="250px" TabIndex="105" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Documento</td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtdocumento" runat="server" Width="150px" TabIndex="101" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
                    </td>
                    <td>
                    </td>
                    <td>
                        Login</td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtlogin" runat="server" Width="150px" TabIndex="106" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
                    </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtlogin"></asp:RequiredFieldValidator>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Direccióon: </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtdireccion" runat="server" Width="260px" TabIndex="102" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
                    </td>
                    <td>
                    </td>
                    <td>
                        Contraseña</td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtcontraseña" runat="server" Width="150px" TabIndex="107" TextMode="Password" />
                            </ContentTemplate>
                        </asp:UpdatePanel>                        
                    </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtcontraseña"></asp:RequiredFieldValidator>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Telefono </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txttelefono" runat="server" Width="150px" TabIndex="103" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
                    </td>
                    <td></td>
                    <td>
                        Estado</td>
                    <td>
                        <asp:DropDownList ID="dwestadog" runat="server" tabindex="108">
                    </asp:DropDownList>

                    </td>

                    <td>

                        &nbsp;</td>

                </tr>
                <tr>
                    <td>
                        Celular</td>
                    <td>
                        <asp:TextBox ID="txtcelular" runat="server" Width="150px" TabIndex="104" />
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        Nivel de Usuario</td>
                    <td>                                                                                              
                                         <asp:DropDownList ID="dwnivelg" runat="server" tabindex="109" onchange="getDropdownListSelectedText();" >
                                         </asp:DropDownList>                                                                        
                                 
                        &nbsp;</td>

                    <td>

                        &nbsp;</td>

                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        &nbsp;</td>
                    <td>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td align="left">

                        <asp:Button ID="btnSaveusuario" Text="Guardar" runat="server" OnClick="btnSaveusuario_Click" TabIndex="110"/>
                    </td>
                    <td align="left">
                        <asp:Button ID="btnrefresh" runat="server" OnClick="btnrefresh_Click" Text="Button" ValidationGroup="G1" style="display:none;" />
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
                    <asp:BoundField DataField="Usu_Id" HeaderText="Id" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Usu_Nombre" HeaderText="Nombres" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Usu_Direccion" HeaderText="Direccion" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Usu_Telefono" HeaderText="Telefono" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Usu_Celular" HeaderText="Celular" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Usu_Correo" HeaderText="Correo">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Usu_Login" HeaderText="Login">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="estado" HeaderText="Estado">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Niv_Nombre" HeaderText="Nivel">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <center>
                                <a href="#" onclick="updateusuario('<%# Eval("Usu_Id") %>','<%# Eval("Usu_Nombre") %>','<%# Eval("Usu_Documento") %>','<%# Eval("Usu_Direccion") %>','<%# Eval("Usu_Telefono") %>','<%# Eval("Usu_Celular") %>','<%# Eval("Usu_Correo") %>','<%# Eval("Usu_Login") %>','<%# Eval("Est_Id") %>','<%# Eval("Niv_Id") %>')">
                                    <asp:Image ID="Image1" ImageUrl="~/Design/images/Botones/editOrder.png" runat="server" />
                                </a>
                            </center>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Roles">
                        <ItemTemplate>
                            <center>
                                <a class="iframe" href="Panel_Usuario_Roles.aspx?USN_USERID=<%# Eval("usu_id")%>&NAME=<%# Eval("Usu_Nombre") %>)"
                                 title="Adicionar Rol a Usuario.">
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
    <div id="dialog" class="f13" style="display:none; font-size: 10px;">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    Nombres:
                </td>
                <td>
                    <input id="imp_nombre" type="text" name="name" value=" " style="width: 250px" tabindex="1" />
                </td>
                <td>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    Correo</td>
                <td>
                    <input id="imp_correo" type="text" name="name1" value=" " style="width: 150px" tabindex="6" /></td>
            </tr>
            <tr>
                <td>
                    Documento:
                </td>
                <td>
                    <input id="imp_documento" type="text" name="name" value=" " style="width: 150px" tabindex="2" />
                </td>
                <td>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    Login</td>
                <td>
                    <input id="imp_login" type="text" name="name2" value=" " readonly="readonly"  style="width: 150px;" tabindex="7"/></td>
            </tr>
            <tr>
                <td>
                    Direccion:
                </td>
                <td>
                    <input id="imp_direccion" type="text" name="name0" value=" " style="width: 250px" tabindex="3" /></td>
                <td>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    Contraseña</td>
                <td>
                    <input id="imp_contraseña" type="password" name="name3" value="" readonly="readonly" style="width: 150px" tabindex="8" />
                </td>
                <td>

                    <input id="chkactv"  type="checkbox" name="ChkAdmin" value="Chk_Admin" onclick="Chk_AdminClick(this)" /></td>
            </tr>
            <tr>
                <td>
                    Telefono</td>
                <td>
                    <input id="imp_telefono" type="text" name="name" value=" " style="width: 150px" tabindex="4" />
                </td>
                <td>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    Estado</td>
                <td>
                    <asp:DropDownList ID="dwestado" runat="server" tabindex="9">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Celular </td>
                <td>
                    <input id="imp_celular" type="text" name="name" value=" " style="width: 150px" tabindex="5" />
                </td>
                <td>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    Nivel</td>
                <td>
                    <asp:DropDownList ID="dwnivel" runat="server" tabindex="10">
                    </asp:DropDownList>
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
