<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.vb" Inherits="Gesex._Default" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Button ID="verLoginButton" Text="Entrar" runat="server" OnClick="verLoginEventMethod" />
    <a href="Cuenta/Registro.aspx">Registrarse</a>
    <h1>Gesex</h1>
    <h4>Gestor de exámenes colaborativo</h4>

    <asp:PlaceHolder runat="server" ID="InfoPlaceHolder" Visible="true">

        <div class="infoWeb">
            <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vulputate rhoncus est nec dapibus. 
            In hac habitasse platea dictumst. Curabitur quam orci, molestie in vulputate ac, imperdiet at dolor. 
            Mauris a erat at justo ultrices maximus a sit amet tortor. Donec pulvinar hendrerit ex, quis maximus 
            massa ultricies ac. Nulla facilisi. Nunc eu aliquam elit. Ut vulputate feugiat dapibus. Quisque egestas 
            massa scelerisque, egestas velit a, dignissim ipsum. Morbi quis est ultricies, ornare felis eu, efficitur 
            ante. Maecenas tempor dignissim imperdiet. Morbi consequat fermentum sem eu finibus. Nam auctor a risus vitae 
            facilisis. Vivamus consequat elementum urna quis gravida. Quisque dictum lorem eu tortor sagittis imperdiet.
            </p>
            <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vulputate rhoncus est nec dapibus. 
            In hac habitasse platea dictumst. Curabitur quam orci, molestie in vulputate ac, imperdiet at dolor. 
            Mauris a erat at justo ultrices maximus a sit amet tortor. Donec pulvinar hendrerit ex, quis maximus 
            massa ultricies ac. Nulla facilisi. Nunc eu aliquam elit. Ut vulputate feugiat dapibus. Quisque egestas 
            massa scelerisque, egestas velit a, dignissim ipsum. Morbi quis est ultricies, ornare felis eu, efficitur 
            ante. Maecenas tempor dignissim imperdiet. Morbi consequat fermentum sem eu finibus. Nam auctor a risus vitae 
            facilisis. Vivamus consequat elementum urna quis gravida. Quisque dictum lorem eu tortor sagittis imperdiet.
            </p>
            <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vulputate rhoncus est nec dapibus. 
            In hac habitasse platea dictumst. Curabitur quam orci, molestie in vulputate ac, imperdiet at dolor. 
            Mauris a erat at justo ultrices maximus a sit amet tortor. Donec pulvinar hendrerit ex, quis maximus 
            massa ultricies ac. Nulla facilisi. Nunc eu aliquam elit. Ut vulputate feugiat dapibus. Quisque egestas 
            massa scelerisque, egestas velit a, dignissim ipsum. Morbi quis est ultricies, ornare felis eu, efficitur 
            ante. Maecenas tempor dignissim imperdiet. Morbi consequat fermentum sem eu finibus. Nam auctor a risus vitae 
            facilisis. Vivamus consequat elementum urna quis gravida. Quisque dictum lorem eu tortor sagittis imperdiet.
            </p>
        </div>

    </asp:PlaceHolder>


    <asp:PlaceHolder runat="server" ID="LoginPlaceHolder" Visible="false">

        <div class="login">
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
            <div>
                <asp:Button ID="entrarButton" Text="Entrar" runat="server" OnClick="entrarEventMethod" />
            </div>
        </div>

    </asp:PlaceHolder>

    <%--<a href="Pruebas.aspx?nombre_examen=NombreDePrueba">Pruebas</a>--%>

</asp:Content>
