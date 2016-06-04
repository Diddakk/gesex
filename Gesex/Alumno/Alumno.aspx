<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Alumno.aspx.vb" Inherits="Gesex.Alumno" %>
<%@ Register Src="~/include/ctlInscribirseEnAsignatura.ascx" TagPrefix="uc1" TagName="ctlInscribirseEnAsignatura" %>
<%@ Register Src="~/include/ctlMostrarAsignaturas.ascx" TagPrefix="uc1" TagName="ctlMostrarAsignaturas" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <p>Alumno</p>    

    <asp:Button ID="verInscribirseButton" Text="Inscribirse en una Asignatura" runat="server" OnClick="verInscribirseEventMethod" CausesValidation="False" />
    
    <uc1:ctlInscribirseEnAsignatura runat="server" ID="ctlInscribirseEnAsignatura" Visible="false" />
    
    <uc1:ctlMostrarAsignaturas runat="server" ID="mostrarAsignaturas" />    

</asp:Content>
