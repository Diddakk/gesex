Imports System.Data.SqlClient
Public Class ctlInscribirseEnAsignatura
    Inherits System.Web.UI.UserControl

    Dim nombreUsuario As String = String.Empty
    Dim nombreAsignatura As String = String.Empty
    Dim claveAsignatura As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        nombreUsuario = Session("s_nombre")
    End Sub

    Protected Sub inscribirseEventMethod(ByVal sender As Object, ByVal e As System.EventArgs) Handles InscribirseButton.Click

        If comprobarAsignatura() Then inscribirse()

    End Sub

    Private Sub inscribirse()

        Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext
        Dim cursa As New usuario_cursa_asignatura With {
            .nombre_usuario = nombreUsuario,
            .clave_asignatura = claveAsignatura}
        context.usuario_cursa_asignatura.InsertOnSubmit(cursa)
        Try
            context.SubmitChanges()
            claveAsignaturaTextBox.Text = String.Empty
            nombreAsignaturaTextBox.Text = String.Empty
            FailureText.Text = String.Empty
            ErrorMessage.Visible = False
        Catch ex As Exception
            FailureText.Text = "No puede inscribirse dos veces en una asignatura"
            ErrorMessage.Visible = True
        End Try
    End Sub

    Private Function comprobarAsignatura() As Boolean
        Dim ret As Boolean = False
        Try
            Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext
            Dim asig As asignatura = (From a In context.asignatura
                                      Where a.nombre_asignatura = nombreAsignaturaTextBox.Text And a.clave_asignatura = claveAsignaturaTextBox.Text
                                      Select a).First
            nombreAsignatura = asig.nombre_asignatura
            claveAsignatura = asig.clave_asignatura
            'MsgBox("Select OK")
            ret = True
        Catch ex As Exception
            'FailureText.Text = ex.ToString()
            'ErrorMessage.Visible = True
            FailureText.Text = "Esta asignatura no existe, compruebe el nombre y la calve"
            ErrorMessage.Visible = True
            nombreAsignaturaTextBox.Text = String.Empty
            claveAsignaturaTextBox.Text = String.Empty
            ret = False
        End Try
        Return ret
    End Function
End Class