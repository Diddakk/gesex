Public Class ExamenAlumno
    Inherits System.Web.UI.Page

    Dim nombreUsuario As String = String.Empty
    Protected nombreExamen As String = String.Empty
    Dim idExamen As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        nombreExamen = Request.QueryString("nombre_examen")
        idExamen = Request.QueryString("id_examen")
        nombreUsuario = Session("s_nombre")

        mostrarPreguntasYRespuestas()


    End Sub

    Private Sub mostrarPreguntasYRespuestas()
        Dim bdr As New StringBuilder
        Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext

        Try

            Dim check As Boolean = (From p In context.pregunta
                                    Where p.nombre_usuario = nombreUsuario And p.id_examen = idExamen
                                    Select p).Any

            bdr.Append("<div>")
            bdr.Append("<ul>")

            If check Then

                'TODO mostrar preguntas enviadas
                'Dim pregList As List(Of pregunta) = (From p In context.pregunta
                '                                     Where p.nombre_usuario = nombreUsuario And p.id_examen = idExamen
                '                                     Select p).ToList
                'For Each p As pregunta In pregList
                'Next

                MsgBox("Ya ha entregado las preguntas de este examen", MsgBoxStyle.MsgBoxSetForeground)
                Response.BufferOutput = True
                Response.Redirect("~/Alumno/AsignaturaAlumno.aspx", False)

            Else

                For i As Integer = 1 To 3

                    bdr.Append("<li>")
                    bdr.AppendFormat("<p>Pregunta Nº{0}</p>", i)
                    bdr.AppendFormat("<input id='p{0}' name='p{0}' type='text'>", i)
                    bdr.Append("<ul>")
                    For j As Integer = 1 To 3

                        bdr.Append("<li>")
                        bdr.AppendFormat("<p>Respuesta Nº{0}</p>", j)
                        bdr.AppendFormat("<input id='p{0}r{1}c' name='p{0}c' value='p{0}r{1}' type='radio'>", i, j)
                        bdr.AppendFormat("<input id='p{0}r{1}' name='p{0}r{1}' type='text'>", i, j)
                        bdr.Append("</li>")

                    Next
                    bdr.Append("</ul>")
                    bdr.Append("</li>")

                Next

            End If

            bdr.Append("</ul>")
            bdr.Append("</div>")

            PreguntasYRespuestasPlaceHolder.Controls.Add(New LiteralControl(bdr.ToString()))

        Catch ex As Exception
            FailureText.Text = ex.ToString()
            'FailureText.Text = "Ningún examen disponible"
            ErrorMessage.Visible = True
        End Try

    End Sub

    Protected Sub EnviarPregYRespButton_Click(sender As Object, e As EventArgs) Handles EnviarPregYRespButton.Click

        Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext
        Dim check As Boolean = (From p In context.pregunta
                                Where p.nombre_usuario = nombreUsuario And p.id_examen = idExamen
                                Select p).Any
        If check Then
            'TODO update
        Else
            ' buscar al profe que creó el examen
            Dim profe As String = (From p In context.usuario_hace_examen
                                   Join u In context.usuario
                                       On p.nombre_usuario Equals u.nombre_usuario
                                   Where p.id_examen = idExamen And u.tipo_usuario = "profesor"
                                   Select p.nombre_usuario).First


            For i As Integer = 1 To 3

                Dim idPregunta As Integer
                If (From id As pregunta In context.pregunta
                    Where id.id_examen = idExamen
                    Select id.id_pregunta).Any Then

                    idPregunta = (From id As pregunta In context.pregunta
                                  Where id.id_examen = idExamen
                                  Select id.id_pregunta).Max
                    idPregunta = idPregunta + 1

                Else

                    idPregunta = 1

                End If

                Dim txtPreg As String = Request.Form("p" & i)
                Dim nuevaPregunta As New pregunta With {
                .id_examen = idExamen,
                .id_pregunta = idPregunta,
                .nombre_usuario = nombreUsuario,
                .texto_pregunta = txtPreg}

                context.pregunta.InsertOnSubmit(nuevaPregunta)
                context.SubmitChanges()

                'Dim idPreg As Integer = (From p In context.pregunta
                '                         Where p.nombre_usuario = nombreUsuario And p.id_examen = idExamen And p.texto_pregunta = txtPreg
                '                         Select p.id_pregunta).First

                For j As Integer = 1 To 3

                    Dim txtResp As String = Request.Form("p" & i & "r" & j)
                    Dim corr As Integer = 0
                    Dim fid As String = "p" & i & "c"
                    Dim fval As String = "p" & i & "r" & j
                    If Request.Form(fid) IsNot Nothing Then
                        If Request.Form(fid).ToString = fval Then
                            corr = 1
                        End If
                    End If

                    Dim idRespuesta As Integer
                    If (From id As respuesta In context.respuesta
                        Where id.id_examen = idExamen And id.id_pregunta = idPregunta And id.nombre_usuario = profe
                        Select id.id_respuesta).Any Then

                        idRespuesta = (From id As respuesta In context.respuesta
                                       Where id.id_examen = idExamen And id.id_pregunta = idPregunta
                                       Select id.id_respuesta).Max
                        idRespuesta = idRespuesta + 1


                    Else

                        idRespuesta = 1

                    End If


                    Dim nuevaResp As New respuesta With {
                        .id_examen = idExamen,
                        .id_pregunta = idPregunta,
                        .id_respuesta = idRespuesta,
                        .nombre_usuario = profe,
                        .texto_respuesta = txtResp,
                        .correcta = corr}
                    context.respuesta.InsertOnSubmit(nuevaResp)
                    context.SubmitChanges()
                Next

            Next

        End If

        Response.BufferOutput = True
        Response.Redirect("~/Alumno/Alumno.aspx", False)

    End Sub

End Class