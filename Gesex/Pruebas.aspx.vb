Public Class Pruebas
    Inherits System.Web.UI.Page

    Dim nombreUsuario As String = String.Empty
    Protected nombreExamen As String = String.Empty
    Dim idExamen As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        nombreExamen = "prueba1"
        idExamen = CInt("1")
        nombreUsuario = "alumno1"

        mostrarPreguntasYRespuestas()

    End Sub

    Private Sub mostrarPreguntasYRespuestas()
        Dim preg As String = String.Empty
        Dim resp As String = String.Empty
        Dim bdr As New StringBuilder
        Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext

        Try
            Dim check As Boolean = (From p In context.pregunta
                                    Where p.nombre_usuario = nombreUsuario And p.id_examen = idExamen
                                    Select p).Any

            Dim idPregunta As Integer = (From id As pregunta In context.pregunta
                                         Where id.id_examen = idExamen
                                         Select id.id_pregunta).Max
            bdr.AppendFormat("<h2>{0}</h2>", idPregunta)
            bdr.Append("<div>")
            bdr.Append("<ul>")

            If check Then

                'Dim pregList As List(Of pregunta) = (From p In context.pregunta
                '                                     Where p.nombre_usuario = nombreUsuario And p.id_examen = claveExamen
                '                                     Select p).ToList

                'For Each p As pregunta In pregList



                'Next

                'MsgBox("Ya ha entregado las preguntas de este examen")
                FailureText.Text = "Ningún examen disponible"
                ErrorMessage.Visible = True

            Else

                For i As Integer = 1 To 3

                    bdr.Append("<li>")
                    'bdr.Append("<input type='text' id=>")
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

            'Response.Write(bdr)
            PreguntasYRespuestasPlaceHolder.Controls.Add(New LiteralControl(bdr.ToString()))

        Catch ex As Exception
            FailureText.Text = ex.ToString()
            'FailureText.Text = "Ningún examen disponible"
            ErrorMessage.Visible = True
        End Try

    End Sub

    Protected Sub EnviarPregYRespButton_Click(sender As Object, e As EventArgs) Handles EnviarPregYRespButton.Click

        'Dim bdr As New StringBuilder
        'Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext
        'Dim check As Boolean = (From p In context.pregunta
        '                        Where p.nombre_usuario = nombreUsuario And p.id_examen = idExamen
        '                        Select p).Any
        'If check Then
        '    'TODO update
        'Else

        '    For i As Integer = 1 To 3

        '        Dim txtPreg As String = Request.Form("p" & i)
        '        Dim nuevaPregunta As New pregunta With {
        '        .id_examen = idExamen,
        '        .nombre_usuario = nombreUsuario,
        '        .texto_pregunta = txtPreg}

        '        context.pregunta.InsertOnSubmit(nuevaPregunta)
        '        context.SubmitChanges()

        '        Dim idPreg As Integer = (From p In context.pregunta
        '                                 Where p.nombre_usuario = nombreUsuario And p.id_examen = idExamen And p.texto_pregunta = txtPreg
        '                                 Select p.id_pregunta).First

        '        'bdr.AppendFormat("<p>P{0}</p>", nuevaPregunta.texto_pregunta)

        '        For j As Integer = 1 To 3

        '            Dim txtResp As String = Request.Form("p" & i & "r" & j)
        '            Dim corr As Integer = 0
        '            Dim fid As String = "p" & i & "c"
        '            Dim fval As String = "p" & i & "r" & j
        '            If Request.Form(fid) IsNot Nothing Then
        '                If Request.Form(fid).ToString = fval Then
        '                    corr = 1
        '                End If
        '            End If

        '            Dim nuevaResp As New respuesta With {
        '                .id_examen = idExamen,
        '                .id_pregunta = idPreg,
        '                .texto_respuesta = txtResp,
        '                .correcta = corr}
        '            context.respuesta.InsertOnSubmit(nuevaResp)
        '            context.SubmitChanges()
        '        Next

        '    Next

        'End If

    End Sub
End Class