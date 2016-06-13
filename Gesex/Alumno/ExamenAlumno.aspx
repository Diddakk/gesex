<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ExamenAlumno.aspx.vb" Inherits="Gesex.ExamenAlumno" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%=nombreExamen%></h3>
    <a class="btn btn-default" href="/Alumno/Alumno.aspx">Volver</a> 
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="PreguntasYRespuestasPlaceHolder" Visible="true" />
    <div>
        <asp:Button ID="EnviarPregYRespButton" CssClass="btn btn-default" runat="server" Text="Enviar" />
    </div>
</asp:Content>
