Imports System.Data.SqlClient
Public Class _Default
    Inherits System.Web.UI.Page

    Dim connection As New SqlConnection
    Dim command As New SqlCommand
    Dim reader As SqlDataReader
    Dim query As String = String.Empty
    Dim nombre As String = String.Empty
    Dim tipo As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub verLoginEventMethod(ByVal sender As Object, ByVal e As System.EventArgs) Handles verLoginButton.Click

        If InfoPlaceHolder.Visible = True Then
            InfoPlaceHolder.Visible = False
            LoginPlaceHolder.Visible = True
        End If

    End Sub

    Protected Sub entrarEventMethod(ByVal sender As Object, ByVal e As System.EventArgs) Handles entrarButton.Click

        doQueryLogin()

    End Sub

    Protected Sub doQueryLogin()
        Try

            Dim connString As String = System.Configuration.ConfigurationManager.ConnectionStrings("BDConn").ToString()
            connection = New SqlConnection(connString)
            connection.Open()
            query = "SELECT * FROM dbo.usuario WHERE nombre_usuario=@nom AND password_usuario=@pword"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@nom", nombreTextBox.Text)
            command.Parameters.AddWithValue("@pword", passTextBox.Text)
            reader = command.ExecuteReader()
            While reader.HasRows() AndAlso reader.Read()
                nombre = reader.GetString(reader.GetOrdinal("nombre_usuario"))
                tipo = reader.GetString(reader.GetOrdinal("tipo_usuario"))
            End While
            If reader.HasRows Then
                Session("s_nombre") = nombre
                Session("s_tipo") = tipo
                If tipo = "profesor" Then
                    Response.BufferOutput = True
                    Response.Redirect("~/Profesor/Profesor.aspx", False)
                Else
                    Response.BufferOutput = True
                    Response.Redirect("~/Alumno/Alumno.aspx", False)
                End If
            Else
                FailureText.Text = "Intento de inicio de sesión no válido"
                ErrorMessage.Visible = True
            End If

            reader.Close()
            connection.Close()

        Catch ex As Exception

            FailureText.Text = ex.ToString()
            ErrorMessage.Visible = True

        End Try
    End Sub

End Class