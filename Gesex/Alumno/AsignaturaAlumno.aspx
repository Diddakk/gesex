<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AsignaturaAlumno.aspx.vb" Inherits="Gesex.AsignaturaAlumno" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>        
        <h3><%=asignatura%></h3>
        <a href="Alumno.aspx">Volver</a> 
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="ExamenesPlaceHolder" Visible="true" />
    </div>
</asp:Content>
