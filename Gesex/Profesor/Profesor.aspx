﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Profesor.aspx.vb" Inherits="Gesex.Profesor" %>

<%@ Register Src="~/include/ctlMostrarAsignaturas.ascx" TagPrefix="uc1" TagName="ctlMostrarAsignaturas" %>
<%@ Register Src="~/include/ctlInscribirseEnAsignatura.ascx" TagPrefix="uc1" TagName="ctlInscribirseEnAsignatura" %>


<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-md-8 col-md-offset-2 contenedor profePage">
        <div class="col-md-6 col-md-offset-3">
            <button id="verCrearAsignaturasButton" class="btn btn-default" type="button" >Nueva asignatura</button>      
        </div>
        <asp:PlaceHolder runat="server" ID="crearAsignaturasPlaceHolder" >
            <div class="col-md-6 col-md-offset-3 contenedor crearPage hidden">
                <h3>Crear una asignatura</h3>
                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                </asp:PlaceHolder>
                <div>
                    <asp:Label runat="server" AssociatedControlID="nombreAsignaturaTextBox">Nombre</asp:Label>
                    <div>
                        <asp:TextBox ID="nombreAsignaturaTextBox" runat="server" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="nombreAsignaturaTextBox" ErrorMessage="El campo de nombre es obligatorio." />
                    </div>
                </div>
                <div>
                    <asp:Label runat="server" AssociatedControlID="claveAsignaturaTextBox">Clave:</asp:Label>
                    <div>
                        <asp:TextBox ID="claveAsignaturaTextBox" runat="server" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="claveAsignaturaTextBox" ErrorMessage="El campo de clave es obligatorio." />
                    </div>
                </div>
                <div>
                    <asp:Button ID="crearAsignaturaButton" CssClass="btn btn-default" Text="Crear" runat="server" OnClick="crearAsignaturaEventMethod" />
                </div>

            </div>
        </asp:PlaceHolder>
    
        <uc1:ctlMostrarAsignaturas runat="server" ID="mostrarAsignaturas" />

    </div>

</asp:Content>
