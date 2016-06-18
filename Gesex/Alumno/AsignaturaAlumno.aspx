<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AsignaturaAlumno.aspx.vb" Inherits="Gesex.AsignaturaAlumno" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>        
        <div class="row">
            <h3>Asignatura: <%=nombreAsignatura%></h3>
            <p class="pull-right"><a class="btn btn-default" href="/Alumno/Alumno.aspx">Volver</a></p>
        </div>
        <div class="container contenedor">
            <ul class="nav nav-tabs nav-justified">
                <li class="active"><a href="#examenesDivAA">Examenes</a></li>
                <li ><a href="#examenesYNotasDivAA">Notas</a></li>
                <li ><a href="#examenesActivosDivAA">Activos</a></li>
            </ul>
          </div>
        <div class="tab-content col-md-8 col-md-offset-2 contenedor">
            
            
            <div id="examenesDivAA" class="tab-pane fade in active">
                
                    <h4 class="text-center">Examenes disponibles</h4>
                
                    <asp:Literal runat="server" ID="ExamenesLiteral" />
                    <asp:PlaceHolder runat="server" ID="exMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="exText" />
                        </p>
                    </asp:PlaceHolder>
                </div>
            
            <div id="examenesYNotasDivAA" class="tab-pane fade">
                
                <h4 class="text-center">Notas</h4>
                
                <asp:Literal runat="server" ID="ExamenesYNotasLiteral" />
                <asp:PlaceHolder runat="server" ID="exynMessage" Visible="false">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="exynText" />
                    </p>
                </asp:PlaceHolder>
            </div>
            
            <div id="examenesActivosDivAA" class="tab-pane fade">
                
                <h4 class="text-center">Examenes activos</h4>
                
                <asp:Literal runat="server" ID="ExamenesActivosLiteral" />

                <asp:PlaceHolder runat="server" ID="exActMessage" Visible="false">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="exActText" />
                    </p>
                </asp:PlaceHolder>

            </div>            
            
        </div>
    </div>
</asp:Content>
