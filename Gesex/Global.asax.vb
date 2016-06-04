
Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Se desencadena al iniciar la aplicación
        Dim myScriptResDef As New ScriptResourceDefinition()
        myScriptResDef.Path = "~/scripts/jquery-2.2.4.js"
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", Nothing, myScriptResDef)
    End Sub
End Class