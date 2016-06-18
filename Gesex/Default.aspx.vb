Public Class _Default
    Inherits System.Web.UI.Page

    Dim nombre As String = String.Empty
    Dim pass As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub entrarEventMethod(ByVal sender As Object, ByVal e As System.EventArgs) Handles entrarButton.Click
        nombre = nombreTextBox.Text
        pass = passTextBox.Text
        Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext
        If (From u In context.usuario
            Where u.nombre_usuario = nombre And u.password_usuario = pass
            Select u).Any Then
            Dim user As usuario = (From u In context.usuario
                                   Where u.nombre_usuario = nombre And u.password_usuario = pass
                                   Select u).First
            Session("s_nombre") = user.nombre_usuario
            Session("s_tipo") = user.tipo_usuario
            If user.tipo_usuario = "profesor" Then
                Response.BufferOutput = True
                Response.Redirect("/Profesor/Profesor.aspx", False)
            Else
                Response.BufferOutput = True
                Response.Redirect("/Alumno/Alumno.aspx", False)
            End If
        Else

            FailureText.Text = "Intento de inicio de sesión no válido"
            ErrorMessage.Visible = True
        End If
    End Sub
End Class