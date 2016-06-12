<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ExamenActivo.aspx.vb" Inherits="Gesex.ExamenActivo" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
    <script type="text/javascript">        
        $(window).blur(function () {
            alert("blu");
        });
    </script>    
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3><%=asignatura%></h3>
    <h4><%=nombreExamen%></h4>
    <h2>ADVERTENCIA: Si cambia el foco de la ventana, será redirigido ala página principal.</h2>
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="ExamenActivoPlaceHolder" Visible="true" />
    <div>
        <asp:Button ID="EnviarExamenButton" runat="server" Text="Button" OnClick="EnviarExamenEventMethod" />
    </div>
</asp:Content>
<asp:Content ID="JqFun" ContentPlaceHolderID="JqueryStuff" runat="server">
    <script type="text/javascript">        
        $(window).blur(function () {
            //alert("blu");
            //window.location.href = "/Alumno/ExamenAlumno.aspx";
        });  
    </script>    
</asp:Content>