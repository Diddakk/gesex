Public Class ctlMostrarAsignaturas
    Inherits System.Web.UI.UserControl
    Dim nombre As String = String.Empty
    Dim tipo As String = String.Empty
    Dim asignaturaElegida As String = String.Empty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        nombre = CStr(Session("s_nombre"))
        tipo = CStr(Session("s_tipo"))
        muestraAsignatura()
    End Sub

    Protected Sub refrescarAsignaturasEventMethod(ByVal sender As Object, ByVal e As System.EventArgs) Handles refrescarAsignaturasButton.Click

        AsignaturasListView.DataBind()

    End Sub

    Private Sub muestraAsignatura()
        SqlDataSource1.SelectCommand = "SELECT asignatura.nombre_asignatura FROM usuario_cursa_asignatura 
  LEFT JOIN  asignatura on (usuario_cursa_asignatura.clave_asignatura=asignatura.clave_asignatura)
  WHERE nombre_usuario = '" & nombre & "'"
    End Sub

    Protected Sub CommandBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AsignaturasListView.SelectedIndexChanged

        asignaturaElegida = DirectCast(sender, LinkButton).Text
        Session("s_asignatura") = asignaturaElegida
        If tipo = "profesor" Then
            Response.BufferOutput = True
            Response.Redirect("~/Profesor/AsignaturaProfesor.aspx", False)
        Else
            Response.BufferOutput = True
            Response.Redirect("~/Alumno/AsignaturaAlumno.aspx", False)
        End If

    End Sub

End Class