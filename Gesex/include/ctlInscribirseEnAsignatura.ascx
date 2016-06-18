<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctlInscribirseEnAsignatura.ascx.vb" Inherits="Gesex.ctlInscribirseEnAsignatura" %>
    

<div class="col-md-6 col-md-offset-3 contenedor inscribAsigDiv hidden">        
    <h4>Inscríbete en una asignatura</h4>
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
        <asp:Button ID="InscribirseButton" CssClass="btn btn-default" Text="Inscribirse" runat="server" OnClick="inscribirseEventMethod" />
    </div>
        
</div>