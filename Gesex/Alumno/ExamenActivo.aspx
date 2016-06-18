<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ExamenActivo.aspx.vb" Inherits="Gesex.ExamenActivo" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
        
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h4>Examen: <%=nombreExamen%></h4>
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
    <div class="tab-content col-md-10 col-md-offset-1 contenedor">
        <asp:PlaceHolder runat="server" ID="ExamenActivoPlaceHolder" Visible="true" />
        <div>
            <asp:Button ID="EnviarExamenButton" CssClass="btn btn-default" runat="server" Text="Enviar" OnClick="EnviarExamenEventMethod" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="JqFun" ContentPlaceHolderID="JqueryStuff" runat="server">
      <script type="text/javascript">        
        //$(window).blur(function () {
            //alert("blu");
            //window.location.href = "/Alumno/ExamenAlumno.aspx";
        //});  
    </script>  
</asp:Content>