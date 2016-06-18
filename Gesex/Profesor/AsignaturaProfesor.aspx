<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AsignaturaProfesor.aspx.vb" Inherits="Gesex.AsignaturaProfesor" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="col-md-8 col-md-offset-2 contenedor asProfePage">

        <div class="row">
            <h3>Asignatura: <%=nombreAsignatura%></h3> 
            <p class="pull-right"><a class="btn btn-default" href="/Profesor/Profesor.aspx">Volver</a></p>
        </div>
        <div class="col-md-6 col-md-offset-3">
            <button id="verCrearExamenButton" class="btn btn-default" type="button" >Nuevo examen</button>
        </div>
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false" >
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="crearExamenPlaceHolder" >
            <div class="col-md-6 col-md-offset-3 contenedor crearExamenDiv hidden">
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
                    <asp:Button ID="crearExamenButton" CssClass="btn btn-default" Text="Entrar" runat="server" OnClick="crearExamenEventMethod" />
                </div>
            </div>
        </asp:PlaceHolder>

        <asp:PlaceHolder runat="server" ID="ExamenesPlaceHolder" Visible="true" />

    </div>

</asp:Content>
