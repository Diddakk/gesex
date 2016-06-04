Imports System.Data.SqlClient
Public Class ctlInscribirseEnAsignatura
    Inherits System.Web.UI.UserControl

    Dim connString As String = String.Empty
    Dim connection As New SqlConnection
    Dim command As New SqlCommand
    Dim reader As SqlDataReader
    Dim query As String = String.Empty
    Dim nombreUsuario As String = String.Empty
    Dim nombreAsignatura As String = String.Empty
    Dim claveAsignatura As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        nombreUsuario = Session("s_nombre")
    End Sub

    Protected Sub inscribirseEventMethod(ByVal sender As Object, ByVal e As System.EventArgs) Handles InscribirseButton.Click

        If comprobarAsignatura() Then

            inscribirse()

        End If

    End Sub

    Private Function comprobarAsignatura() As Boolean
        Dim ret As Boolean = False
        Try
            connString = System.Configuration.ConfigurationManager.ConnectionStrings("BDConn").ToString()
            connection = New SqlConnection(connString)
            connection.Open()
            query = "SELECT * FROM dbo.asignatura WHERE nombre_asignatura=@nom AND clave_asignatura=@key"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@nom", nombreAsignaturaTextBox.Text)
            command.Parameters.AddWithValue("@key", claveAsignaturaTextBox.Text)
            reader = command.ExecuteReader()
            If reader.HasRows() AndAlso reader.Read() Then
                nombreAsignatura = reader.GetString(reader.GetOrdinal("nombre_asignatura"))
                claveAsignatura = reader.GetString(reader.GetOrdinal("clave_asignatura"))
                reader.Close()
                ret = True
            Else
                FailureText.Text = "Esta asignatura no existe, compruebe el nombre y la calve"
                ErrorMessage.Visible = True
                reader.Close()
                connection.Close()
                nombreAsignaturaTextBox.Text = String.Empty
                claveAsignaturaTextBox.Text = String.Empty

            End If
        Catch ex As Exception
            FailureText.Text = ex.ToString()
            ErrorMessage.Visible = True
        End Try
        Return ret
    End Function

    Private Sub inscribirse()

        Try
            Dim al As Alumno = New Alumno
            query = "INSERT INTO dbo.usuario_cursa_asignatura (clave_asignatura, nombre_usuario) values (@key, @nom)"
            command = New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@key", claveAsignatura)
            command.Parameters.AddWithValue("@nom", nombreUsuario)
            command.ExecuteReader()
            reader.Close()
            connection.Close()
            claveAsignaturaTextBox.Text = String.Empty
            nombreAsignaturaTextBox.Text = String.Empty
            FailureText.Text = "Insert ok"
            ErrorMessage.Visible = True
        Catch ex As Exception
            FailureText.Text = "No puede inscribirse dos veces en una asignatura"
            ErrorMessage.Visible = True
        End Try

    End Sub


End Class