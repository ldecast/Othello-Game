<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Othello.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
<link rel="stylesheet" href="css\StyleSheet2.css" type="text/css">

<title>Modalidades del juego</title>
  </head>
  <body>
    <form id="menu" runat="server">
    <div class="container">
        <%--<h1 class="display-1 text-center my-4 text-white">Hola</h1>--%>
        <div class="container-fluid text-center mt-4 mb-3">
        <asp:Label runat="server" id="Label1" class="display-1 text-white titulo" Text="Hola "/>
        <asp:Label runat="server" id="usuario" class="display-1 text-white titulo" Text="Usuario"/>
        <asp:Label runat="server" id="Label2" class="display-1 text-white titulo" Text="!"/>
        </div><br>
        <div class="row py-4">
            <div class="col-sm-12 col-md-6 col-lg-6 text-center mb-2 border-right border-secondary">
                <h1>Cargar partida</h1>
                <form name="formulario" method="post" action="/send.php" enctype="multipart/form-data">
                    <asp:FileUpload runat="server" id="upload" accept=".xml" AllowMultiple="false" CssClass="btn btn-dark btn-lg"/><br><br>
                    <asp:Button runat="server" id="cargar" CssClass="btn btn-dark btn-lg" Text="Cargar" OnClick="Redireccionar" />
                    <%--<input type="file" class="btn btn-dark btn-lg" name="adjunto" accept=".pdf,.jpg,.png"/><br><br>--%>
<%--                    <input type="button" class="btn btn-outline-dark btn-lg" value="Cargar">--%>
                  </form>
                  
            </div>
            <div class="col-sm-12 col-md-6 col-lg-6 text-center mb-2">
                <h1>Juego nuevo</h1>
                    <asp:Button runat="server" id="newGame" class="btn btn-warning btn-lg" Text="Uno contra uno" OnClick="newGame_Click"/><br><br>
                    <asp:Button runat="server" id="juegoSolo" class="btn btn-warning btn-lg" Text="Contra la máquina" OnClick="newGame_Click"/>
            </div>
        </div>
        <div class="row py-4">

            <div class="col-sm-12 col-md-6 col-lg-6 border-right border-secondary text-center mb-2">
                <h1>Torneos:</h1>
                <input type="button" class="btn btn-outline-dark btn-lg" value="Crear"><br><br>
                <input type="button" class="btn btn-outline-dark btn-lg" value="Unirse">
            </div>
            <div class="col-sm-12 col-md-6 col-lg-6  text-center reportes mb-2">
                <h1>Reportes:</h1>
                <div class="row">
                    <div class="col-sm-12 col-lg-6">
                        <input type="button" class="btn btn-outline-dark btn-lg" value="Partidas ganadas"><br><br>
                        <input type="button" class="btn btn-outline-dark btn-lg" value="Partidas empatadas"><br><br>
                    </div>
                    <div class="col-sm-12 col-lg-6">
                        <input type="button" class="btn btn-outline-dark btn-lg" value="Partidas perdidas"><br><br>
                        <input type="button" class="btn btn-outline-dark btn-lg" value="Reporte de torneos">
                    </div>
                </div>
            </div>
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