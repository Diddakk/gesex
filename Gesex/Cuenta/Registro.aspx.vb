Imports System.Data.SqlClient
Public Class Registro
    Inherits System.Web.UI.Page
    Dim connection As New SqlConnection
    Dim command As New SqlCommand
    Dim query As String = String.Empty
    Dim nombre As String = String.Empty
    Dim tipo As String = String.Empty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub registroEventMethod(ByVal sender As Object, ByVal e As System.EventArgs)
        registrarUsuario()
    End Sub

    Private Sub registrarUsuario()
        Try

            Dim numInserted As Integer
            Dim connString As String = System.Configuration.ConfigurationManager.ConnectionStrings("BDConn").ToString()
            Dim connection = New SqlConnection(connString)
            connection.Open()
            query = "INSERT INTO dbo.usuario (nombre_usuario, password_usuario, tipo_usuario) values (@nom, @pword, @type)"
            Dim command = New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@nom", nombreTextBox.Text)
            command.Parameters.AddWithValue("@pword", passTextBox.Text)
            command.Parameters.AddWithValue("@type", tipoRadioButtonList.SelectedValue)
            'command.ExecuteReader()
            numInserted = command.ExecuteNonQuery()
            connection.Close()
            If numInserted <> 0 Then
                Session("s_nombre") = nombreTextBox.Text
                tipo = tipoRadioButtonList.SelectedValue
                Session("s_tipo") = tipo
                If tipo = "profesor" Then
                    Response.BufferOutput = True
                    Response.Redirect("~/Profesor/Profesor.aspx", False)
                Else
                    Response.BufferOutput = True
                    Response.Redirect("~/Alumno/Alumno.aspx", False)
                End If
            Else
                FailureText.Text = "Registro no válido, pruebe otro nombre de usuario"
                ErrorMessage.Visible = True
            End If


        Catch ex As Exception

            FailureText.Text = ex.ToString()
            ErrorMessage.Visible = True

        End Try

    End Sub


End Class