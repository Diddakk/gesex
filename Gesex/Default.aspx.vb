Public Class _Default
    Inherits System.Web.UI.Page

    Dim nombre As String = String.Empty
    Dim pass As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub verLoginEventMethod(ByVal sender As Object, ByVal e As System.EventArgs) Handles verLoginButton.Click
        If InfoPlaceHolder.Visible = True Then
            InfoPlaceHolder.Visible = False
            LoginPlaceHolder.Visible = True
        End If
    End Sub

    Protected Sub entrarEventMethod(ByVal sender As Object, ByVal e As System.EventArgs) Handles entrarButton.Click
        nombre = nombreTextBox.Text
        pass = passTextBox.Text
        Try
            Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext
            Dim user As usuario = (From u In context.usuario
                                   Where u.nombre_usuario = nombre And u.password_usuario = pass
                                   Select u).First
            Session("s_nombre") = user.nombre_usuario
            Session("s_tipo") = user.tipo_usuario
            If user.tipo_usuario = "profesor" Then
                Response.BufferOutput = True
                Response.Redirect("~/Profesor/Profesor.aspx", False)
            Else
                Response.BufferOutput = True
                Response.Redirect("~/Alumno/Alumno.aspx", False)
            End If
        Catch ex As Exception
            FailureText.Text = "Intento de inicio de sesión no válido"
            ErrorMessage.Visible = True
        End Try
    End Sub
End Class