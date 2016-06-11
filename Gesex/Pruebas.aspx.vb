Public Class Pruebas
    Inherits System.Web.UI.Page

    Protected nombreExamen As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        nombreExamen = Request.QueryString("nombre_examen")
    End Sub

End Class