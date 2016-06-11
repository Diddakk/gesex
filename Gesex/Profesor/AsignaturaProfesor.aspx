<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AsignaturaProfesor.aspx.vb" Inherits="Gesex.AsignaturaProfesor" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>        
        <h3><%=claveAsignatura%></h3> 
        <a href="Profesor.aspx">Volver</a>
    </div>

    <asp:Button ID="verCrearExamenButton" Text="Crear un Examen" runat="server" OnClick="verCrearExamenEventMethod" CausesValidation="False" />
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false" >
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="crearExamenPlaceHolder" Visible="false">
        <div>
            <h3>Crear un exámen</h3>            
            <div>
                <asp:Label runat="server" AssociatedControlID="nombreExamenTextBox">Nombre</asp:Label>
                <div>
                    <asp:TextBox ID="nombreExamenTextBox" runat="server" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="nombreExamenTextBox" ErrorMessage="El campo de nombre es obligatorio." />
                </div>
            </div>
            <div>
                <div>
                    <input type="date" id="fechaExamenInput" runat="server" />
                </div>
            </div>
            <div>
                <asp:Button ID="crearExamenButton" Text="Entrar" runat="server" OnClick="crearExamenEventMethod" />
            </div>
        </div>
    </asp:PlaceHolder>

    <asp:PlaceHolder runat="server" ID="ExamenesPlaceHolder" Visible="true" />


</asp:Content>
