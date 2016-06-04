Public Class Alumno
    Inherits System.Web.UI.Page
    Dim nombre As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


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