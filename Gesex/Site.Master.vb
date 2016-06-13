Public Class Site
    Inherits System.Web.UI.MasterPage

    Dim nombre As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not String.IsNullOrWhiteSpace(Session("s_nombre")) Then
            nombre = CStr(Session("s_nombre"))
            usuarioLabel.Text = nombre
        End If

    End Sub
    Protected Sub logoutEventMethod(ByVal sender As Object, ByVal e As System.EventArgs) Handles logoutButton.Click
        Session.Clear()
        Session.Abandon()
        Response.BufferOutput = True
        Response.Redirect("/Default.aspx", False)
    End Sub

End Class