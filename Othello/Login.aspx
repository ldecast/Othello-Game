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
  </head>
  <body>
    <div class="container-fluid bg-success py-3 titulo text-center">
      <h1 class="display-2"><b>¡Welcome to Othello!</b></h1>
    </div>
    <div class="container pt-5 mb-5 fondo">
      <div class="row">
        <div class="col-sm-12 col-md-12 col-lg-6">
          <h2 class="mb-4 text-center rounded">Regístrate</h2>
          <form class="registro" id="registro">

          <label for="fname">Nombres:</label><br>
          <input type="text" id="fname" name="fname"><br>

          <label for="sname">Apellidos:</label><br>
          <input type="text" id="sname" name="sname"><br>

          <label for="fnac">Fecha de nacimiento:</label><br>
          <input type="date" id="fnac" name="fnac"><br>

          <label for="pais">País:</label><br>
          <input type="text" id="pais" name="pais"><br>

          <label for="uname">Username:</label><br>
          <input type="text" id="uname" name="uname"><br>
          
          <label for="correo">Correo:</label><br>
          <input type="email" id="correo" name="correo"><br>

          <label for="password">Contraseña:</label><br>
          <input type="password" id="password" name="password"><br>

          <input id="enviar" type="submit" class="btn btn-outline-dark" value="Registrarse">
          </form>
        </div>
        <div class="col-sm-12 col-md-12 col-lg-6 border-left border-secondary">
          <h2 class="text-center mb-4 rounded">Inicia sesión</h2>
          <form class="login pl-5" id="login">
            <label for="uname">Username:</label><br>
            <input type="text" id="uname" name="uname"><br>

            <label for="pass">Contraseña:</label><br>
            <input type="password" id="pass" name="pass"><br>
            <input id="logear" type="submit" class="btn btn-outline-dark" value="Ingresar">
          </form>
        </div>
      </div>
    </div>

    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
  </body>
</html>