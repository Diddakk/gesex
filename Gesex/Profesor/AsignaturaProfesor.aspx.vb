Public Class AsignaturaProfesor
    Inherits System.Web.UI.Page

    Dim nombreUsuario As String = String.Empty
    Protected claveAsignatura As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        nombreUsuario = Session("s_nombre")
        claveAsignatura = Session("s_claveAsignatura")

        mostrarExamenes()

    End Sub

    Private Sub mostrarExamenes()
        Try
            Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext

            Dim exam As List(Of examen) = (From e In context.examen
                                           Where e.clave_asignatura = claveAsignatura
                                           Select e).ToList

            Dim bdr As New StringBuilder
            bdr.Append("<div>")
            bdr.Append("<ul>")
            For Each ex As examen In exam

                bdr.Append("<li>")
                bdr.AppendFormat("<a href='ExamenProfesor.aspx?id_examen={0}&nombre_examen={1}'>{1}</a>", ex.id_examen, ex.nombre_examen)
                bdr.Append("</li>")

            Next

            bdr.Append("</ul>")
            bdr.Append("</div>")

            'Response.Write(bdr)
            ExamenesPlaceHolder.Controls.Add(New LiteralControl(bdr.ToString()))

        Catch ex As Exception
            'FailureText.Text = ex.ToString()
            FailureText.Text = "Ningún examen disponible"
            ErrorMessage.Visible = True
        End Try
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

        Dim hace As New usuario_hace_examen With {
            .id_examen = exam.id_examen,
            .nombre_usuario = nombreUsuario}
        context.usuario_hace_examen.InsertOnSubmit(hace)
        context.SubmitChanges()

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