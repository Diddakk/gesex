Public Class ExamenAlumno
    Inherits System.Web.UI.Page

    Protected nombreExamen As String = String.Empty
    Dim claveExamen As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        nombreExamen = Request.QueryString("nombre_examen")
        claveExamen = Request.QueryString("id_examen")

        mostrarPreguntasYRespuestas()

    End Sub

    Private Sub mostrarPreguntasYRespuestas()

        Try
            Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext

            'Dim check As Boolean = (From p In context.pregunta
            'Where p.)

            'Dim preg As List(Of pregunta) = (From)

        Catch ex As Exception
            'FailureText.Text = ex.ToString()
            FailureText.Text = "Ningún examen disponible"
            ErrorMessage.Visible = True
        End Try

    End Sub



End Class