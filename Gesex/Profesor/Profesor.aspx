<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Profesor.aspx.vb" Inherits="Gesex.Profesor" %>
<%@ Register Src="~/include/ctlMostrarAsignaturas.ascx" TagPrefix="uc1" TagName="ctlMostrarAsignaturas" %>
<%@ Register Src="~/include/ctlInscribirseEnAsignatura.ascx" TagPrefix="uc1" TagName="ctlInscribirseEnAsignatura" %>


<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Button ID="verCrearAsignaturasButton" Text="Crear una Asignatura" runat="server" OnClick="verCrearAsignaturasEventMethod" CausesValidation="False" />
    
    <asp:Button ID="verInscribirseButton" Text="Inscribirse en una Asignatura" runat="server" OnClick="verInscribirseEventMethod" CausesValidation="False" />

    <asp:PlaceHolder runat="server" ID="crearAsignaturasPlaceHolder" Visible="false">
        <div>
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
                <asp:Button ID="entrarAsignaturaButton" Text="Entrar" runat="server" OnClick="entrarAsignaturaEventMethod" />
            </div>

        </div>
    </asp:PlaceHolder>

    <uc1:ctlInscribirseEnAsignatura runat="server" ID="ctlInscribirseEnAsignatura" Visible="false" />

    <uc1:ctlMostrarAsignaturas runat="server" ID="mostrarAsignaturas" />

</asp:Content>
