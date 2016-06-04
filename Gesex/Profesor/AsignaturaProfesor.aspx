<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AsignaturaProfesor.aspx.vb" Inherits="Gesex.AsignaturaProfesor" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>        
        <h3><%=asignatura%></h3> 
        <a href="Profesor.aspx">Volver</a>
    </div>

    <asp:Button ID="verCrearExamenButton" Text="Crear un Examen" runat="server" OnClick="verCrearExamenEventMethod" CausesValidation="False" />

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
                <asp:Button ID="entrarExamenButton" Text="Entrar" runat="server" OnClick="entrarExamenEventMethod" />
            </div>
        </div>
    </asp:PlaceHolder>


</asp:Content>
