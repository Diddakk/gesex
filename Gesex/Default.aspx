<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.vb" Inherits="Gesex._Default" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="defaultPage">
        <div class="col-md-4 col-md-offset-8 entrarYReg">
            <button type="button" id="loginButton" class="btn btn-default" >Entrar</button>    
            <a class="btn btn-default" href="/Cuenta/Registro.aspx" >Registrarse</a>
        </div>
        <div class="col-md-12">
            <h2 class="text-center">Gestor de exámenes colaborativo</h2>
        </div>
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                <p class="text-danger">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
            </asp:PlaceHolder>
            
        <div class="col-md-10 col-md-offset-1 contenedor infoDiv">
            <p>
                Gesex es una aplicación web de gestión de exámenes colaborativa.
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
    
        <div class="col-md-3 col-md-offset-4 contenedor loginDiv hidden">
            
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
                    <asp:TextBox ID="passTextBox" TextMode="password" runat="server"  />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="passTextBox" ErrorMessage="El campo de contraseña es obligatorio." />
                </div>
            </div>
            <div>
                <asp:Button ID="entrarButton" CssClass="btn btn-default" Text="Entrar" runat="server" OnClick="entrarEventMethod" />
            </div>
        </div>
    </div>
</asp:Content>
