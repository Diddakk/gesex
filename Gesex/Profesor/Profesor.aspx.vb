Imports System.Data.SqlClient
Public Class Profesor
    Inherits System.Web.UI.Page

    Dim nombreUsuario As String = String.Empty
    Dim claveAsignatura As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub crearAsignaturaEventMethod(ByVal sender As Object, ByVal e As System.EventArgs) Handles crearAsignaturaButton.Click

        crearAsignatura()

    End Sub

    Private Sub crearAsignatura()
        nombreUsuario = Session("s_nombre")
        Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext
        Dim asig As New asignatura With {
            .clave_asignatura = claveAsignaturaTextBox.Text,
            .nombre_asignatura = nombreAsignaturaTextBox.Text}
        context.asignatura.InsertOnSubmit(asig)
        Try
            context.SubmitChanges()
            claveAsignatura = asig.clave_asignatura
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
                FailureText.Text = "Ha habido un problema inscribiéndose en la asignatura"
                ErrorMessage.Visible = True
            End Try
        Catch ex As Exception
            FailureText.Text = "Esta asignatura ya existe, compruebe el nombre y la calve"
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