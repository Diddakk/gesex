<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctlMostrarAsignaturas.ascx.vb" Inherits="Gesex.ctlMostrarAsignaturas" %>

<div>
    <h3>Asignaturas</h3>
    <asp:Button ID="refrescarAsignaturasButton" CssClass="btn btn-default" Text="Refrescar Asignaturas" runat="server" OnClick="refrescarAsignaturasEventMethod" CausesValidation="False" />
    <%--<asp:ListView ID="AsignaturasListView" runat="server" >
        <EmptyDataTemplate>
            <span>No está inscrito en ninguna asignatura.</span>
        </EmptyDataTemplate>
        <LayoutTemplate>
            <div class="itemPlaceholderContainer">
                <ul>
                    <li id="itemPlaceholder" runat="server" />
                </ul>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <li>
                <asp:LinkButton ID="nombre_asignaturaLink" CssClass="btn btn-default" Text='<%# Eval("clave_asignatura") %>' CommandName="List" runat="server" OnCommand="CommandBtn_Click" />
            </li>
        </ItemTemplate>
        <SelectedItemTemplate>
            <li>
                <asp:LinkButton ID="nombre_asignaturaLink" CssClass="btn btn-default selected" Text='<%# Eval("clave_asignatura") %>' CommandName="Selected" runat="server" OnCommand="CommandBtn_Click" />
            </li>
        </SelectedItemTemplate>
    </asp:ListView>--%>

    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="AsignaturasPlaceHolder" Visible="true" />
    
</div>


