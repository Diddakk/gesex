Public Class AsignaturaAlumno
    Inherits System.Web.UI.Page

    Dim nombreUsuario As String = String.Empty
    Protected nombreAsignatura As String = String.Empty
    Dim asignatura As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        nombreUsuario = Session("s_nombre")
        asignatura = Request.QueryString("id_asignatura")
        nombreAsignatura = Request.QueryString("nombre_asignatura")

        mostrarExamenes()
        mostrarExamenesYNotas()
        mostrarExamenesActivos()

    End Sub

    Private Sub mostrarExamenes()

        Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext
        If (From e In Context.examen
            Where e.clave_asignatura = asignatura
            Select e).any Then


            Dim bdr As New StringBuilder


            Dim exam As List(Of examen) = (From e In context.examen
                                           Where e.clave_asignatura = asignatura
                                           Select e).ToList

            bdr.Append("<div  class=""contenedor"">")
            bdr.Append("<ul>")
            For Each ex As examen In exam

                bdr.Append("<li>")
                bdr.AppendFormat("<a href='ExamenAlumno.aspx?id_examen={0}&nombre_examen={1}'>{1}</a>", ex.id_examen, ex.nombre_examen)
                bdr.Append("</li>")

            Next

            bdr.Append("</ul>")
            bdr.Append("</div>")

            'Response.Write(bdr)
            ExamenesLiteral.Text = bdr.ToString

        Else

            'FailureText.Text = ex.ToString()
            exText.Text = "Ningún examen disponible"
            exMessage.Visible = True
        End If



    End Sub

    Private Sub mostrarExamenesActivos()

        Dim bdr As New StringBuilder
        Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext


        If (From ex In context.examen
            Where ex.activar_examen = True And ex.clave_asignatura = asignatura
            Select ex).Any Then

            Dim ExActList As List(Of examen) = (From ex In context.examen
                                                Where ex.activar_examen = True And ex.clave_asignatura = asignatura
                                                Select ex).ToList

            bdr.Append("<div class=""contenedor"">")
            bdr.Append("<ul>")

            For Each ex In ExActList

                bdr.Append("<li>")
                bdr.AppendFormat("<a href='ExamenActivo.aspx?id_examen={0}&nombre_examen={1}'>{1}</a>", ex.id_examen, ex.nombre_examen)
                bdr.Append("</li>")

            Next

            bdr.Append("</ul>")
            bdr.Append("</div>")
            ExamenesActivosLiteral.Text = bdr.ToString

        Else
            exActText.Text = "Ningún examen activo"
            exActMessage.Visible = True

        End If


    End Sub

    Private Sub mostrarExamenesYNotas()


        Dim context As DataClassesGesexDataContext = New DataClassesGesexDataContext

        If (From e In context.examen
            Group Join n In context.usuario_hace_examen
                                                   On e.id_examen Equals n.id_examen
                                                   Into en = Group
            From n In en.DefaultIfEmpty
            Where e.clave_asignatura = asignatura And n.nombre_usuario = nombreUsuario
            Select New examenYnota With {.idExamen = e.id_examen, .nombreExamen = e.nombre_examen, .nota = n.nota_hace}).Any Then




            Dim exam As List(Of examenYnota) = (From e In context.examen
                                                Group Join n In context.usuario_hace_examen
                                                   On e.id_examen Equals n.id_examen
                                                   Into en = Group
                                                From n In en.DefaultIfEmpty
                                                Where e.clave_asignatura = asignatura And n.nombre_usuario = nombreUsuario
                                                Select New examenYnota With {.idExamen = e.id_examen, .nombreExamen = e.nombre_examen, .nota = n.nota_hace}).ToList


            Dim bdr As New StringBuilder

            bdr.Append("<div class=""contenedor"">")
            bdr.Append("<ul>")
            For Each ex As examenYnota In exam

                bdr.Append("<li>")
                bdr.AppendFormat("<span class=""nomExAA"">{0}</span>", ex.nombreExamen)
                bdr.AppendFormat("<span class=""notaAA"">Nota: {0}</span>", ex.nota)
                bdr.Append("</li>")

            Next

            bdr.Append("</ul>")
            bdr.Append("</div>")

            'Response.Write(bdr)
            ExamenesYNotasLiteral.Text = bdr.ToString

        Else
            'FailureText.Text = ex.ToString()
            exynText.Text = "Ningún examen disponible"
            exynMessage.Visible = True



        End If

    End Sub

    Public Class examenYnota

        Public idExamen As String
        Public nombreExamen As String
        Public nota As Decimal

        Public Sub New()

        End Sub
    End Class
End Class