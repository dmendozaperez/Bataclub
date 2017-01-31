<%@ Page Title="" Language="C#" MasterPageFile="~/Design/Site.Master" AutoEventWireup="true" CodeBehind="Editar_Password.aspx.cs" Inherits="www.bataclubvales.com.Form.Control.Editar_Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
     <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $("input:text").width('200px');
        });
    </script>
    Cambio de Clave de Acceso
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPageDesc" runat="server">
    Realice el cambio de la clave de acceso a su cuenta, recuerde que la clave es acceso confidencial del usuario al sistema .
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="summaryError" runat="server" CssClass="ui-state-highlight"
        HeaderText="Corrija los siguientes campos" ShowMessageBox="True" ValidationGroup="valerror"
        ForeColor="" />
      <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <asp:UpdatePanel ID="upPanelMsg" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <AQControl:Message runat="server" Visible="false" ID="msnMessage"></AQControl:Message>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnguardar" EventName="click" />            
        </Triggers>
    </asp:UpdatePanel>
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
    <table cellpadding="6" cellspacing="6" width="100%">
        <tr>
            <td class="fsal f13" colspan="2">
                Formulario de cambio de contraseña
            </td>
        </tr>
        <tr>
            <td>
                <label class="f12">
                    Nombre de <u>u</u>suario:
                </label>
                <br />
                <label>
                    (Desc: Usuario registrado para inicio de sesión)
                </label>
            </td>
            <td>
                <asp:TextBox ID="txtusername" runat="server" AccessKey="u" Enabled="False" ValidationGroup="valerror"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <label class="f12">
                    *C<u>o</u>ntraseña actual:
                </label>
                <br />
                <label>
                    (Desc: Dígite su clave actual vigente)
                </label>
            </td>
            <td>
                <asp:TextBox ID="txtPassAnterior" runat="server" AccessKey="o" ValidationGroup="valerror"
                    Width="200px" CausesValidation="True" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ValidatorPassAnterior" runat="server" ControlToValidate="txtPassAnterior"
                    CssClass="error" Display="Dynamic" ErrorMessage="Digite la contraseña que va a cambiar."
                    ValidationGroup="valerror" ForeColor="" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label class="f12">
                    *<u>N</u>ueva contraseña:
                </label>
                <br />
                <label>
                    (Desc: Dígite su nueva clave)
                </label>
            </td>
            <td>
                <asp:TextBox ID="txtPassNew" runat="server" AccessKey="n" ValidationGroup="valerror"
                    Width="200px" CausesValidation="True" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ValidatorPassNew" runat="server" ControlToValidate="txtPassNew"
                    CssClass="error" Display="Dynamic" ErrorMessage="Digite la nueva contraseña."
                    ForeColor="" SetFocusOnError="True" ValidationGroup="valerror">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexTextBox1" Display="Dynamic" ControlToValidate="txtPassNew"
                    runat="server" ValidationExpression="^[\s\S]{2,100}$" Text="La nueva clave debe de poseer minimo 8 caracteres"
                    ErrorMessage="La nueva clave debe de poseer minimo 8 caracteres." ValidationGroup="valerror">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label class="f12">
                    *Con<u>f</u>irmar nueva contraseña:
                </label>
                <br />
                <label>
                    (Desc: Verificación de nueva clave)
                </label>
            </td>
            <td>
                <asp:TextBox ID="txtPassRenew" runat="server" AccessKey="f" ValidationGroup="valerror"
                    Width="200px" CausesValidation="True" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="ValidatorNews" runat="server" ControlToValidate="txtPassRenew"
                    CssClass="error" Display="Dynamic" ErrorMessage="La contraseña nueva no es igual. Por favor vuelva y digitela."
                    ForeColor="" ValidationGroup="valerror" SetFocusOnError="True" ControlToCompare="txtPassNew">*</asp:CompareValidator><asp:RequiredFieldValidator
                        ID="ValidatorPassRenew" runat="server" ControlToValidate="txtPassRenew" CssClass="error"
                        Display="Dynamic" ErrorMessage="Vuelva y digita la nueva contraseña." ForeColor=""
                        SetFocusOnError="True" ValidationGroup="valerror">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td align="left" style="width: 524px">
                            &nbsp;</td>
                        <td align="left">
                            <asp:Button ID="btnguardar" runat="server" Text="(G)uardar cambios" ValidationGroup="valerror"
                                AccessKey="g" onclick="btnguardar_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
