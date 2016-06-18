<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ExamenProfesor.aspx.vb" Inherits="Gesex.ExamenProfesor" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h3><%=nombreExamen%></h3>
        <p class="pull-right"><a class="btn btn-default" href="/Profesor/Profesor.aspx">Volver</a></p>
    </div> 
    <div class="col-md-6 col-md-offset-3">
        <button id="verValidarExamenesButton" class="btn btn-default" type="button" >Notas</button>      
    </div>
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>
   <div class="col-md-6 col-md-offset-1 contenedor">
        <asp:Button ID="ActivarExamenButton" CssClass="btn btn-default" runat="server" Text="Activar Examen" />
        <asp:Literal runat="server" ID="ExamenActivoLiteral" Text="Este examen está activo" Visible="false" />
    </div> 
    <div class="tab-content col-md-10 col-md-offset-1 pyrDiv contenedor">
        <h4>Preguntas y respuestas</h4>
        <asp:PlaceHolder runat="server" ID="PreguntasYRespuestasPlaceHolder" Visible="true" />
        <div>
            <asp:Button ID="EnviarPregYRespButton" CssClass="btn btn-default" runat="server" Text="Validar" />
        </div>
    </div>
    <div class="tab-content col-md-10 col-md-offset-1 notasPDiv contenedor hidden">
        <h4>Notas</h4>
        <asp:PlaceHolder runat="server" ID="NotasPlaceHolder" Visible="true" />
    </div>
    
</asp:Content>
