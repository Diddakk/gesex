<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Pruebas.aspx.vb" Inherits="Gesex.Pruebas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <h3><%=nombreExamen%></h3>
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="PreguntasYRespuestasPlaceHolder" Visible="true" />
        <div>
            <asp:Button ID="EnviarPregYRespButton" runat="server" Text="Enviar" />
        </div>
        
    </div>
    </form>
</body>
</html>
