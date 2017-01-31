<%@ Page Title="" Language="C#" MasterPageFile="~/Design/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="www.bataclubvales.com.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">   
     
    Página inicial del sistema de información de Bata Peru (BataClub)   
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPageDesc" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <script src="scripts/easySlider1.7.js" type="text/javascript"></script>
  <%--  <script type="text/javascript">
        var iniciarEfecto;
        $(function () {
            var galeria = function () {
                $("#ulImages").html('');
                if ($("#controls").length > 0) {
                    $("#controls").html('');
                }
                $.ajax({
                    url: 'Default.aspx/Galeria',
                    dataType: 'json',
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    error: function (obj, error) {
                        alert('Se ha producido un error al traer las imágenes');
                    },
                    success: CrearGaleria
                });
            }

            galeria();

            iniciarEfecto = function () {
                $("#slider").easySlider({
                    auto: true,
                    continuous: true,
                    numeric: true,
                    pause: 2500
                });
            }
        })
        function CrearGaleria(data) {
            var elem;
            $.each(data.d, function (key, val) {
                elem = "<li><a><img src=" + val.imagen + " /></a></li>";
                $("#ulImages").append(elem);
            })
            iniciarEfecto();
        }
    </script>--%>
  <div id="slider" class="slider">
      <div>
       <ul id="ulImages"></ul>
        </div>     
  </div>
</asp:Content>
