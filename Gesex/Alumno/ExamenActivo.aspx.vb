Imports Gesex

Public Class ExamenActivo
    Inherits System.Web.UI.Page

    Dim nombreUsuario As String = String.Empty
    Protected nombreExamen As String = String.Empty
    Private idExamen As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        nombreUsuario = Session("s_nombre")
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
                EnviarExamenButton.Visible = False
                FailureText.Text = "Ningún examen disponible"
                ErrorMessage.Visible = True
            Else



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

                    Shuffle(pregList)

                    For Each p As pregunta In pregList



                        bdr.Append("<li>")
                        bdr.AppendFormat("<p>{0}</p>", p.texto_pregunta)
                        bdr.Append("<ul>")

                        Dim respList As List(Of respuesta) = (From r As respuesta In context.respuesta
                                                              Where r.id_examen = idExamen And r.id_pregunta = p.id_pregunta And r.nombre_usuario = profe
                                                              Select r).ToList
                        Shuffle(respList)
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
                    EnviarExamenButton.Visible = False
                    FailureText.Text = "Ningún examen disponible"
                    ErrorMessage.Visible = True
                End If
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
        CalcularNota(context, profe)
        Response.BufferOutput = True
        Response.Redirect("/Alumno/Alumno.aspx", False)
    End Sub

    Private Sub CalcularNota(context As DataClassesGesexDataContext, profe As String)

        Dim respExamenHS As HashSet(Of respuesta) = New HashSet(Of respuesta)(From re As respuesta In context.respuesta
                                                                              Where re.id_examen = idExamen And re.nombre_usuario = profe
                                                                              Select re)
        Dim respAlumnoHS As HashSet(Of respuesta) = New HashSet(Of respuesta)(From ra As respuesta In context.respuesta
                                                                              Where ra.id_examen = idExamen And ra.nombre_usuario = nombreUsuario
                                                                              Select ra)
        Dim nota As Decimal = 0
        Dim contador As Decimal = 0
        Dim total As Decimal = (From p As pregunta In context.pregunta
                                Where p.id_examen = idExamen And p.validada = True
                                Select p).Count

        For Each resAl In respAlumnoHS
            Dim resEx As Boolean = (From r In respExamenHS
                                    Where r.id_pregunta = resAl.id_pregunta And r.id_respuesta = resAl.id_respuesta And r.correcta = resAl.correcta
                                    Select r).Any
            If resEx Then
                contador = contador + 1
            End If

        Next
        Try
            nota = (contador / total) * 100
        Catch ex As Exception
            'FailureText.Text = "No hay preguntas a las que asignar una nota"
            FailureText.Text = ex.ToString()
            ErrorMessage.Visible = True
        End Try


        Dim ponerNota As New usuario_hace_examen With {
            .id_examen = idExamen,
            .nombre_usuario = nombreUsuario,
            .nota_hace = nota}


        context.usuario_hace_examen.InsertOnSubmit(ponerNota)
        context.SubmitChanges()

    End Sub

    Sub Shuffle(Of T)(list As IList(Of T))
        Dim r As Random = New Random()
        For i = 0 To list.Count - 1
            Dim index As Integer = r.Next(i, list.Count)
            If i <> index Then
                ' swap list(i) and list(index)
                Dim temp As T = list(i)
                list(i) = list(index)
                list(index) = temp
            End If
        Next
    End Sub

End Class