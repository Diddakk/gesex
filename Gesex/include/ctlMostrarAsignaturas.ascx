<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctlMostrarAsignaturas.ascx.vb" Inherits="Gesex.ctlMostrarAsignaturas" %>


<div class="col-md-12 contenedor mostrarAsigDiv"> 
    <h4>Tus asignaturas</h4>   
    
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="AsignaturasPlaceHolder" Visible="true" />
    
</div>


