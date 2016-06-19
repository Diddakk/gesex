<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.vb" Inherits="Gesex._Default" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="defaultPage">
        <div class="col-md-4 col-md-offset-8 entrarYReg">
            <button type="button" id="loginButton" class="btn btn-default" >Entrar</button>    
            <a class="btn btn-default" href="/Cuenta/Registro.aspx" >Registrarse</a>
        </div>
        <div class="col-md-12">
            <h2 class="text-center">Gestor de exámenes colaborativo</h2>
        </div>
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                <p class="text-danger">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
            </asp:PlaceHolder>
            
        <div class="col-md-10 col-md-offset-1 contenedor infoDiv">
            <p>
                Gesex es una aplicación web de gestión de exámenes colaborativa en la que alumnos y profesores 
                colaboran para crear y hacer exámenes. Mediante esta colaboración, se reduce considerablemente la carga 
                de trabajo, permitiendo al profesor dedicar más tiempo a preparar las clases y no a la tediosa tarea de 
                corregir las mismas preguntas para cada uno de sus alumnos.
            </p>
            <p>
                El Profesor ha de crear una asignatura y para ella, crear exámenes. Estos exámenes estarán 
                compuestos por preguntas que envíen los alumnos. El Profesor hará una selección de preguntas y el 
                día del examen, lo activará. Luego podrá ver las notas de cada uno de sus alumnos.
            </p>
            <p>
                El Alumno, tendrá que inscribirse en una asignatura para poder acceder a los examenes. Enviará tres 
                preguntas con tres respuestas cada una, que posteriormente serán validadas si el Profesor así lo considera.
                Cuando tenga un examen activo en su listado, podrá acceder a él y hacer el examen. Luego podrá ver sus notas 
                en la pestaña correspondiente de la aplicación
            </p>
        </div>
    
        <div class="col-md-3 col-md-offset-4 contenedor loginDiv hidden">
            
            <div>
                <asp:Label runat="server" AssociatedControlID="nombreTextBox">Nombre</asp:Label>
                <div>
                    <asp:TextBox ID="nombreTextBox" runat="server" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="nombreTextBox" ErrorMessage="El campo de nombre es obligatorio." />
                </div>
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="passTextBox">Contraseña</asp:Label>
                <div>
                    <asp:TextBox ID="passTextBox" TextMode="password" runat="server"  />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="passTextBox" ErrorMessage="El campo de contraseña es obligatorio." />
                </div>
            </div>
            <div>
                <asp:Button ID="entrarButton" CssClass="btn btn-default" Text="Entrar" runat="server" OnClick="entrarEventMethod" />
            </div>
        </div>
    </div>
</asp:Content>
