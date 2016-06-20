Public Class AsignaturaProfesor
    Inherits System.Web.UI.Page

    Dim nombreUsuario As String = String.Empty
    Protected nombreAsignatura As String = String.Empty
    Dim claveAsignatura As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        claveAsignatura = Request.QueryString("id_asignatura")
        nombreAsignatura = Request.QueryString("nombre_asignatura")
        nombreUsuario = Session("s_nombre")

        mostrarExamenes()

    End Sub

    Private Sub mostrarExamenes()
        Try
            Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext

            Dim exam As List(Of examen) = (From e In context.examen
                                           Where e.clave_asignatura = claveAsignatura
                                           Select e).ToList

            Dim bdr As New StringBuilder

            bdr.Append("<div class=""col-md-12 contenedor mostrarExamenesDiv"">")
            bdr.Append("<h4>Exámenes</h4>")
            bdr.Append("<ul>")
            For Each ex As examen In exam

                bdr.Append("<li>")
                bdr.AppendFormat("<a href='ExamenProfesor.aspx?id_examen={0}&nombre_examen={1}&clave_asignatura={2}'>{1}</a>", ex.id_examen, ex.nombre_examen, claveAsignatura)
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

            Dim hace As New usuario_hace_examen With {
            .id_examen = exam.id_examen,
            .nombre_usuario = nombreUsuario}
            context.usuario_hace_examen.InsertOnSubmit(hace)
            context.SubmitChanges()
            Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)

        Catch ex As Exception
            FailureText.Text = "No se ha podido crear el examen"
            ErrorMessage.Visible = True
        End Try


    End Sub


End Class