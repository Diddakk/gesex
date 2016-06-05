<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctlMostrarAsignaturas.ascx.vb" Inherits="Gesex.ctlMostrarAsignaturas" %>

<div>
    <h3>Asignaturas</h3>
    <asp:Button ID="refrescarAsignaturasButton" Text="Refrescar Asignaturas" runat="server" OnClick="refrescarAsignaturasEventMethod" CausesValidation="False" />
    <asp:ListView ID="AsignaturasListView" runat="server" >
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
                <asp:LinkButton ID="nombre_asignaturaLink" Text='<%# Eval("clave_asignatura") %>' CommandName="List" runat="server" OnCommand="CommandBtn_Click" />
            </li>
        </ItemTemplate>
        <SelectedItemTemplate>
            <li>
                <asp:LinkButton ID="nombre_asignaturaLink" Text='<%# Eval("clave_asignatura") %>' CommandName="Selected" CssClass="selected" runat="server" OnCommand="CommandBtn_Click" />
            </li>
        </SelectedItemTemplate>
    </asp:ListView>
    
</div>


