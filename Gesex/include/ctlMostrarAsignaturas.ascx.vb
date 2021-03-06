﻿Public Class ctlMostrarAsignaturas
    Inherits System.Web.UI.UserControl
    Dim nombreUsuario As String = String.Empty
    Dim tipo As String = String.Empty
    Dim asignaturaElegida As String = String.Empty
    Dim listaAsignaturas As List(Of asignatura)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        nombreUsuario = CStr(Session("s_nombre"))
        tipo = CStr(Session("s_tipo"))
        muestraAsignatura()
    End Sub

    Protected Sub refrescarAsignaturasEventMethod(ByVal sender As Object, ByVal e As System.EventArgs) Handles refrescarAsignaturasButton.Click
        muestraAsignatura()
    End Sub

    Private Sub muestraAsignatura()
        Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext
        listaAsignaturas = (From c In context.usuario_cursa_asignatura
                            Join a In context.asignatura
                                On c.clave_asignatura Equals a.clave_asignatura
                            Where c.nombre_usuario = nombreUsuario
                            Select a).ToList

        AsignaturasListView.DataSource = listaAsignaturas
        AsignaturasListView.DataBind()
    End Sub

    Protected Sub CommandBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AsignaturasListView.SelectedIndexChanged

        asignaturaElegida = DirectCast(sender, LinkButton).Text
        Session("s_claveAsignatura") = asignaturaElegida
        If tipo = "profesor" Then
            Response.BufferOutput = True
            Response.Redirect("~/Profesor/AsignaturaProfesor.aspx", False)
        Else
            Response.BufferOutput = True
            Response.Redirect("~/Alumno/AsignaturaAlumno.aspx", False)
        End If

    End Sub

End Class