Public Class AsignaturaProfesor
    Inherits System.Web.UI.Page
    Protected asignatura As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        asignatura = Session("s_asignatura")

    End Sub

    Protected Sub entrarExamenEventMethod(ByVal sender As Object, ByVal e As System.EventArgs) Handles entrarExamenButton.Click

        crearExamen()

    End Sub

    Private Sub crearExamen()

        MsgBox("TODO insert antes de Linq")

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