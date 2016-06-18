<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Alumno.aspx.vb" Inherits="Gesex.Alumno" %>
<%@ Register Src="~/include/ctlInscribirseEnAsignatura.ascx" TagPrefix="uc1" TagName="ctlInscribirseEnAsignatura" %>
<%@ Register Src="~/include/ctlMostrarAsignaturas.ascx" TagPrefix="uc1" TagName="ctlMostrarAsignaturas" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-8 col-md-offset-2 contenedor alumnoPage">
        <div class="col-md-6 col-md-offset-3">
            <button id="verInscribirseButton" class="btn btn-default" type="button" >Inscribirse en una asignatura</button>
        </div>
        <uc1:ctlMostrarAsignaturas runat="server" ID="mostrarAsignaturas" />    
        <uc1:ctlInscribirseEnAsignatura runat="server" ID="ctlInscribirseEnAsignatura" />
        
    </div>

</asp:Content>
