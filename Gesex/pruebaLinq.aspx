<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="pruebaLinq.aspx.vb" Inherits="Gesex.pruebaLinq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
                <asp:LinkButton ID="nombre_asignaturaLink" Text='<%# Eval("nombre_asignatura") %>' CommandName="List" runat="server" OnCommand="CommandBtn_Click" />
            </li>
        </ItemTemplate>
        <SelectedItemTemplate>
            <li>
                <asp:LinkButton ID="nombre_asignaturaLink" Text='<%# Eval("nombre_asignatura") %>' CommandName="Selected" CssClass="selected" runat="server" OnCommand="CommandBtn_Click" />
            </li>
        </SelectedItemTemplate>
    </asp:ListView>

    </form>
</body>
</html>
