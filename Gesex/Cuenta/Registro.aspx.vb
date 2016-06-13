Imports System.Data.SqlClient
Public Class Registro
    Inherits System.Web.UI.Page

    Dim nombre As String = String.Empty
    Dim pass As String = String.Empty
    Dim tipo As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub registroEventMethod(ByVal sender As Object, ByVal e As System.EventArgs)
        registrarUsuario()
    End Sub

    Private Sub registrarUsuario()
        nombre = nombreTextBox.Text
        pass = passTextBox.Text
        tipo = tipoRadioButtonList.SelectedValue
        Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext

        Dim nuevoUsuario As New usuario With {
            .nombre_usuario = nombre,
            .password_usuario = pass,
            .tipo_usuario = tipo}
        context.usuario.InsertOnSubmit(nuevoUsuario)
        Try
            context.SubmitChanges()

            Session("s_nombre") = nombreTextBox.Text
            tipo = tipoRadioButtonList.SelectedValue
            Session("s_tipo") = tipo
            If tipo = "profesor" Then
                Response.BufferOutput = True
                Response.Redirect("/Profesor/Profesor.aspx", False)
            Else
                Response.BufferOutput = True
                Response.Redirect("/Alumno/Alumno.aspx", False)
            End If

        Catch ex As Exception
            'FailureText.Text = "Registro no válido, pruebe otro nombre de usuario"
            'ErrorMessage.Visible = True
            FailureText.Text = ex.ToString()
            ErrorMessage.Visible = True
        End Try

    End Sub
End Class