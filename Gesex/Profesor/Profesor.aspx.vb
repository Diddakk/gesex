Imports System.Data.SqlClient
Public Class Profesor
    Inherits System.Web.UI.Page

    Dim connection As New SqlConnection
    Dim command As New SqlCommand
    Dim reader As SqlDataReader
    Dim query As String = String.Empty
    Dim nombre As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.IsNullOrWhiteSpace(Session("s_nombre")) Then
            Response.BufferOutput = True
            Response.Redirect("~/Default.aspx", False)
        End If
    End Sub



    Protected Sub entrarAsignaturaEventMethod(ByVal sender As Object, ByVal e As System.EventArgs) Handles entrarAsignaturaButton.Click

        crearAsignatura()

    End Sub

    Protected Sub crearAsignatura()
        Try
            nombre = Session("s_nombre")
            Dim connString As String = System.Configuration.ConfigurationManager.ConnectionStrings("BDConn").ToString()
            connection = New SqlConnection(connString)
            connection.Open()

            Query = "INSERT INTO dbo.asignatura (clave_asignatura, nombre_asignatura) values (@key, @nom)"
            Command = New SqlCommand(Query, connection)
            Command.Parameters.AddWithValue("@key", claveAsignaturaTextBox.Text)
            Command.Parameters.AddWithValue("@nom", nombreAsignaturaTextBox.Text)
            reader = Command.ExecuteReader()
            reader.Close()

            Query = "INSERT INTO dbo.usuario_cursa_asignatura (clave_asignatura, nombre_usuario) values (@key, @nom)"
            Command = New SqlCommand(Query, connection)
            Command.Parameters.AddWithValue("@key", claveAsignaturaTextBox.Text)
            Command.Parameters.AddWithValue("@nom", nombre)
            Command.ExecuteReader()
            reader.Close()

            connection.Close()
            crearAsignaturasPlaceHolder.Visible = False
            claveAsignaturaTextBox.Text = String.Empty
            nombreAsignaturaTextBox.Text = String.Empty


        Catch ex As Exception
            FailureText.Text = "Esta asignatura no existe, compruebe el nombre y la calve"
            ErrorMessage.Visible = True
        End Try

    End Sub

    Protected Sub verCrearAsignaturasEventMethod(ByVal sender As Object, ByVal e As System.EventArgs) Handles verCrearAsignaturasButton.Click
        crearAsignaturaVisible()
    End Sub
    Protected Sub crearAsignaturaVisible()
        If crearAsignaturasPlaceHolder.Visible = False Then
            crearAsignaturasPlaceHolder.Visible = True
        Else
            crearAsignaturasPlaceHolder.Visible = False
        End If
    End Sub

    Protected Sub verInscribirseEventMethod(ByVal sender As Object, ByVal e As System.EventArgs) Handles verInscribirseButton.Click
        inscribirVisible()
    End Sub
    Private Sub inscribirVisible()
        If ctlInscribirseEnAsignatura.Visible = False Then
            ctlInscribirseEnAsignatura.Visible = True
        Else
            ctlInscribirseEnAsignatura.Visible = False
        End If
    End Sub


End Class