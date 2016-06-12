﻿Public Class ExamenActivo
    Inherits System.Web.UI.Page

    Dim nombreUsuario As String = String.Empty
    Protected asignatura As String = String.Empty
    Protected nombreExamen As String = String.Empty
    Private idExamen As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        nombreUsuario = Session("s_nombre")
        asignatura = Session("s_claveAsignatura")
        nombreExamen = Request.QueryString("nombre_examen")
        idExamen = Request.QueryString("id_examen")

        mostrarExamen()

    End Sub

    Private Sub mostrarExamen()
        Dim bdr As New StringBuilder
        Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext




        Try
            Dim check As Boolean = (From ex In context.examen
                                    Where ex.id_examen = idExamen And ex.activar_examen = True
                                    Select ex).Any

            Dim check2 As Boolean = (From r In context.respuesta
                                     Where r.nombre_usuario = nombreUsuario And r.id_examen = idExamen
                                     Select r).Any
            If check2 Then
                MsgBox("Ya ha hecho este examen", MsgBoxStyle.MsgBoxSetForeground)
                Response.BufferOutput = True
                Response.Redirect("~/Alumno/AsignaturaAlumno.aspx", False)
            End If

            If check Then

                Dim profe As String = (From p In context.usuario_hace_examen
                                       Join u In context.usuario
                                   On p.nombre_usuario Equals u.nombre_usuario
                                       Where p.id_examen = idExamen And u.tipo_usuario = "profesor"
                                       Select p.nombre_usuario).First


                bdr.Append("<div>")
                bdr.Append("<ul>")

                Dim pregList As List(Of pregunta) = (From p In context.pregunta
                                                     Where p.id_examen = idExamen And p.validada = True
                                                     Select p).ToList

                For Each p As pregunta In pregList



                    bdr.Append("<li>")
                    bdr.AppendFormat("<p>{0}</p>", p.texto_pregunta)
                    bdr.Append("<ul>")

                    Dim respList As List(Of respuesta) = (From r As respuesta In context.respuesta
                                                          Where r.id_examen = idExamen And r.id_pregunta = p.id_pregunta And r.nombre_usuario = profe
                                                          Select r).ToList
                    For Each r As respuesta In respList

                        bdr.Append("<li>")
                        bdr.Append("<p>")
                        bdr.AppendFormat("<input id='p{0}r{1}c' name='p{0}c' value='p{0}r{1}' type='radio' />", r.id_pregunta, r.id_respuesta)
                        bdr.AppendFormat(" {0}</p>", r.texto_respuesta)
                        bdr.Append("</li>")

                    Next

                    bdr.Append("</ul>")
                    bdr.Append("</li>")

                Next
                bdr.Append("</ul>")
                bdr.Append("</div>")
                ExamenActivoPlaceHolder.Controls.Add(New LiteralControl(bdr.ToString()))

            Else
                MsgBox("Este examen no está activo", MsgBoxStyle.MsgBoxSetForeground)
                Response.BufferOutput = True
                Response.Redirect("~/Alumno/AsignaturaAlumno.aspx", False)
            End If

        Catch ex As Exception
            FailureText.Text = ex.ToString()
            'FailureText.Text = "Ningún examen disponible"
            ErrorMessage.Visible = True
        End Try

    End Sub

    Protected Sub EnviarExamenEventMethod(sender As Object, e As EventArgs) Handles EnviarExamenButton.Click
        Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext

        Dim pregList As List(Of Integer) = (From p In context.pregunta
                                            Where p.id_examen = idExamen
                                            Select p.id_pregunta).ToList

        Dim profe As String = (From p In context.usuario_hace_examen
                               Join u In context.usuario
                                   On p.nombre_usuario Equals u.nombre_usuario
                               Where p.id_examen = idExamen And u.tipo_usuario = "profesor"
                               Select p.nombre_usuario).First


        For Each preg In pregList

            Dim respList As List(Of respuesta) = (From r In context.respuesta
                                                  Where r.id_examen = idExamen And r.id_pregunta = preg And r.nombre_usuario = profe
                                                  Select r).ToList



            For Each resp In respList

                Dim fval As String = "p" & preg & "r" & resp.id_respuesta
                Dim fid As String = "p" & preg & "c"


                If Request.Form(fid) IsNot Nothing Then
                    If Request.Form(fid).ToString = fval Then

                        Dim nuevaResp As New respuesta With {
                        .id_examen = idExamen,
                        .id_pregunta = preg,
                        .id_respuesta = resp.id_respuesta,
                        .nombre_usuario = nombreUsuario,
                        .correcta = True}

                        context.respuesta.InsertOnSubmit(nuevaResp)
                        context.SubmitChanges()

                    End If
                End If

                'Dim respCorrecta As Boolean = resp.correcta
                'If respAlumno = respAlumno Then
                '    'TODO comparar para la nota
                'End If
            Next
        Next
        Response.BufferOutput = True
        Response.Redirect("~/Alumno/Alumno.aspx", False)
    End Sub
End Class