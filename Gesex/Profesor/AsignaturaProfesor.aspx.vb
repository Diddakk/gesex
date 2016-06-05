Public Class AsignaturaProfesor
    Inherits System.Web.UI.Page

    Dim nombreUsuario As String = String.Empty
    Protected claveAsignatura As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        nombreUsuario = Session("s_nombre")
        claveAsignatura = Session("s_claveAsignatura")

    End Sub

    Protected Sub crearExamenEventMethod(ByVal sender As Object, ByVal e As System.EventArgs) Handles crearExamenButton.Click

        crearExamen()

    End Sub

    Private Sub crearExamen()

        Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext
        Dim exam As New examen With {
            .fecha_examen = fechaExamenInput.Value,
            .clave_asignatura = claveAsignatura,
            .nombre_examen = nombreExamenTextBox.Text}
        context.examen.InsertOnSubmit(exam)
        Try

            context.SubmitChanges()
            fechaExamenInput.Value = String.Empty
            nombreExamenTextBox.Text = String.Empty
            FailureText.Text = String.Empty
            ErrorMessage.Visible = False

        Catch ex As Exception
            FailureText.Text = "No se ha podido crear el examen"
            ErrorMessage.Visible = True
        End Try

    End Sub


    Protected Sub verCrearExamenEventMethod(ByVal sender As Object, ByVal e As System.EventArgs) Handles verCrearExamenButton.Click
        crearExamenVisible()
    End Sub
    Private Sub crearExamenVisible()
        If crearExamenPlaceHolder.Visible = False Then
            crearExamenPlaceHolder.Visible = True
        Else
            crearExamenPlaceHolder.Visible = False
        End If
    End Sub

End Class