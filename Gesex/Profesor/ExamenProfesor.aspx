<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ExamenProfesor.aspx.vb" Inherits="Gesex.ExamenProfesor" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%=nombreExamen%></h3>
    <a href="AsignaturaProfesor.aspx">Volver</a> 
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>
    <div>
        <asp:Button ID="ActivarExamenButton" runat="server" Text="Activar Examen" />
        <asp:Literal runat="server" ID="ExamenActivoLiteral" Text="Este examen está activo" Visible="false" />
    </div>    
    <asp:PlaceHolder runat="server" ID="PreguntasYRespuestasPlaceHolder" Visible="true" />
    <div>
        <asp:Button ID="EnviarPregYRespButton" runat="server" Text="Enviar" />
    </div>
    
</asp:Content>
