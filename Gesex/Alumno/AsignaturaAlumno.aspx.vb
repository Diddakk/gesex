Public Class AsignaturaAlumno
    Inherits System.Web.UI.Page

    Protected asignatura As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        asignatura = Session("s_claveAsignatura")

        mostrarExamenes()
        mostrarExamenesActivos()

    End Sub

    Private Sub mostrarExamenesActivos()

        Dim bdr As New StringBuilder
        Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext


        If (From ex In context.examen
            Where ex.activar_examen = True
            Select ex).Any Then

            Dim ExActList As List(Of examen) = (From ex In context.examen
                                                Where ex.activar_examen = True
                                                Select ex).ToList
            bdr.Append("<div>")
            bdr.Append("<ul>")

            For Each ex In ExActList

                bdr.Append("<li>")
                bdr.AppendFormat("<a href='ExamenActivo.aspx?id_examen={0}&nombre_examen={1}'>{1}</a>", ex.id_examen, ex.nombre_examen)
                bdr.Append("</li>")

            Next

            bdr.Append("</ul>")
            bdr.Append("</div>")
            ExamenesActivosLiteral.Text = bdr.ToString
            ExamenesActivosPlaceHolder.Visible = True

        End If


    End Sub

    Private Sub mostrarExamenes()

        Try
            Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext

            Dim exam As List(Of examen) = (From e In context.examen
                                           Where e.clave_asignatura = asignatura
                                           Select e).ToList

            Dim bdr As New StringBuilder
            bdr.Append("<div>")
            bdr.Append("<ul>")
            For Each ex As examen In exam

                bdr.Append("<li>")
                bdr.AppendFormat("<a href='ExamenAlumno.aspx?id_examen={0}&nombre_examen={1}'>{1}</a>", ex.id_examen, ex.nombre_examen)
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
End Class