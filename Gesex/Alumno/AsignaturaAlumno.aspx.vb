Public Class AsignaturaAlumno
    Inherits System.Web.UI.Page

    Protected asignatura As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        asignatura = Session("s_claveAsignatura")

    End Sub

End Class