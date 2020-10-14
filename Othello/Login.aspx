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
      <h1 class="display-2"><b>¡Othello!</b></h1> <h4>by iGameGT &copy;</h4>
    </div>

    <div class="container px-5 pt-5 mb-5 fondo">

      <div class="row">
        <form id="registro">
        <div class="col-sm-12 col-md-12 col-lg-6">
          <h2 class="mb-3 text-center rounded">Regístrate</h2>

          <asp:TextBox runat="server" placeholder="Nombres" AutoCompleteType="Disabled" CssClass="cajon" id="fname"/><br/>

          <asp:TextBox runat="server" id="sname" placeholder="Apellidos" AutoCompleteType="Disabled" CssClass="cajon"/><br/>

          <asp:TextBox runat="server" id="fnac" placeholder="Fecha de nacimiento" onfocus="(this.type='date')" CssClass="cajon"/><br/>

          <asp:TextBox runat="server" id="pais" placeholder="País" CssClass="cajon"/><br/>

          <asp:TextBox runat="server" id="correo" placeholder="Correo" AutoCompleteType="Disabled" CssClass="cajon" TextMode="Email"/><br/>

          <asp:TextBox runat="server" id="uname" placeholder="Usuario" AutoCompleteType="Disabled" CssClass="cajon"/><br/>
          
          <asp:TextBox runat="server" id="password" placeholder="Contraseña" CssClass="cajon" TextMode="Password"/>

          <asp:Button runat="server" id="enviar" CssClass="btn btn-outline-light mt-5" Text="Registrarse" OnClick="Registrar"/>
        </div>

        <div class="col-sm-12 col-md-12 col-lg-6 border-left border-secondary paddo">
          <h2 class="text-center mb-3 rounded">Inicia sesión</h2><br />
            <label for="loginname" class="mb-1">Username:</label><br>
            <asp:TextBox runat="server" id="loginname" AutoCompleteType="Disabled" CssClass="logeo"/><br/>

            <label for="loginpassword" class="mb-1">Contraseña:</label><br>
            <asp:TextBox runat="server" id="loginpassword" CssClass="logeo mb-4" TextMode="Password"/><br/>

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