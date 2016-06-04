<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Registro.aspx.vb" Inherits="Gesex.Registro" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>Registrarse</p>
    <a href="../Default.aspx">Inicio</a>
    <a href="#">Registrarse</a>
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>
    <div>
        <asp:Label runat="server" AssociatedControlID="nombreTextBox">Nombre</asp:Label>
        <div>
            <asp:TextBox ID="nombreTextBox" runat="server" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="nombreTextBox" ErrorMessage="El campo de nombre es obligatorio." />
        </div>
    </div>
    <div>
        <asp:Label runat="server" AssociatedControlID="passTextBox">Contraseña</asp:Label>
        <div>
            <asp:TextBox ID="passTextBox" TextMode="password" runat="server" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="passTextBox" ErrorMessage="El campo de contraseña es obligatorio." />
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirmar contraseña</asp:Label>
        <div>
            <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                Display="Dynamic" ErrorMessage="El campo de confirmación de contraseña es obligatorio." />
            <asp:CompareValidator runat="server" ControlToCompare="passTextBox" ControlToValidate="ConfirmPassword"
                Display="Dynamic" ErrorMessage="La contraseña y la contraseña de confirmación no coinciden." />
        </div>
    </div>
    <div>
        <asp:Label runat="server" AssociatedControlID="tipoRadioButtonList">Tipo</asp:Label>
        <div>
            <asp:RadioButtonList ID="tipoRadioButtonList" runat="server">
                <asp:ListItem id="profesorRadioItem" runat="server" Value="profesor" Text="Profesor" />
                <asp:ListItem id="alumnoRadioItem" runat="server" Value="alumno" Text="Alumno" Selected="True" />
            </asp:RadioButtonList>
        </div>
    </div>
    <div>
        <asp:Button ID="registroButton" Text="Registrarse" runat="server" OnClick="registroEventMethod" />
    </div>

</asp:Content>
