<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Othello.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
<link rel="stylesheet" href="css\StyleSheet1.css" type="text/css">
<title>Login</title>
    <script type="text/javascript">
        function registrado() { alert("\tRegistro completado! \nInicie sesión para continuar."); }
        function notMatch() { alert("Los datos de usuario y/o contraseña son incorrectos. \n\tInténtelo de nuevo o complete el registro"); }
        function invalid() { alert("Por favor, revise que todos los campos estén llenos. Intente de nuevo"); }
    </script>
  </head>
  <body>
    <form runat="server">
    <div class="container-fluid bg-success py-3 titulo text-center">
      <h1 class="display-2"><b>¡Welcome to Othello!</b></h1>
    </div>

    <div class="container px-5 pt-5 mb-5 fondo">

      <div class="row">
        <form id="registro">
        <div class="col-sm-12 col-md-12 col-lg-6">
          <h2 class="mb-4 text-center rounded">Regístrate</h2>

          <label for="fname" class="mb-1">Nombres:</label><br>
          <asp:TextBox runat="server" class="cajon" id="fname"/><br/>

          <label for="sname" class="mb-1">Apellidos:</label><br>
          <asp:TextBox runat="server" id="sname" class="cajon"/><br/>

          <label for="fnac" class="mb-1">Fecha de nacimiento:</label><br>
          <asp:TextBox runat="server" id="fnac" class="cajon" TextMode="Date"/><br/>

          <label for="pais">País:</label><br>
          <asp:TextBox runat="server" id="pais" class="cajon"/><br/>

          <label for="correo" class="mb-1">Correo:</label><br>
          <asp:TextBox runat="server" id="correo" class="cajon" TextMode="Email"/><br/>

          <label for="uname" class="mb-1">Username:</label><br>
          <asp:TextBox runat="server" id="uname" class="cajon"/><br/>
          
          <label for="password" class="mb-1">Contraseña:</label><br>
          <asp:TextBox runat="server" id="password" class="cajon" TextMode="Password"/><br/>

          <asp:Button runat="server" id="enviar" CssClass="btn btn-outline-light" Text="Registrarse" OnClick="Registrar"/>
          <%--</form>--%>
        </div>

        <div class="col-sm-12 col-md-12 col-lg-6 border-left border-secondary paddo">
          <h2 class="text-center mb-4 rounded">Inicia sesión</h2>
          <%--<form class="login" id="login">--%>
            <label for="loginname" class="mb-1">Username:</label><br>
            <asp:TextBox runat="server" id="loginname" class="cajon"/><br/>

            <label for="loginpassword" class="mb-1">Contraseña:</label><br>
            <asp:TextBox runat="server" id="loginpassword" class="cajon" TextMode="Password"/><br/>

            <asp:Button runat="server" id="logear" CssClass="btn btn-outline-light" Text="Ingresar" OnClick="Logear"/>
          </form>
        </div>
      </div>
    </form>
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
  </body>
</html>