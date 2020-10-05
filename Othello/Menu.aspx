<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Othello.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
<link rel="stylesheet" href="css\StyleSheet2.css" type="text/css">

<title>Menú de juego</title>
  </head>
  <body>
    <form id="menu" runat="server">
    <div class="container">
        <div class="container-fluid text-center mt-4 mb-3">
        <asp:Label runat="server" id="Label1" class="display-1 text-white titulo" Text="Hola "/>
        <asp:Label runat="server" id="usuario" class="display-1 text-white titulo" Text="Usuario"/>
        <asp:Label runat="server" id="Label2" class="display-1 text-white titulo" Text="!"/>
        </div><br>
        <div class="row py-4">
            <div class="col-sm-12 col-md-6 col-lg-6 text-center mb-2 border-right border-secondary">
                <asp:Label runat="server" id="Label3" class="h1 text-center" Text="Cargar partida" /><br>

                    <asp:FileUpload runat="server" id="upload" accept=".xml" AllowMultiple="false" CssClass="btn btn-dark btn-lg mt-4" Visible="false"/><br><br>
                    <asp:Button runat="server" id="cargar1" CssClass="btn btn-dark btn-lg m-1" Text="2 jugadores" OnClick="cargarElegir1"/>
                    <asp:Button runat="server" id="cargar2" CssClass="btn btn-dark btn-lg m-1" Text="Individual" OnClick="cargarElegir2"/>

                <asp:Panel runat="server" id="Panel1" class="mt-0 pt-0" Visible="false">
                    <asp:Button runat="server" id="Button1" class="btn btn-outline-light btn-lg mx-3" Text="Blanco" OnClick="Redireccionar1"/>
                    <asp:Button runat="server" id="Button2" class="btn btn-outline-dark btn-lg block" Text="Negro" OnClick="Redireccionar2"/>
                </asp:Panel>

                <asp:Panel runat="server" id="Panel2" class="mt-0 pt-0" Visible="false">
                    <asp:Button runat="server" id="Button3" class="btn btn-outline-light btn-lg mx-3" Text="Blanco" OnClick="Redireccionar3"/>
                    <asp:Button runat="server" id="Button4" class="btn btn-outline-dark btn-lg block" Text="Negro" OnClick="Redireccionar4"/>
                </asp:Panel>
                  
            </div>
            <div class="col-sm-12 col-md-6 col-lg-6 text-center mb-2">
                <asp:Label runat="server" id="juegoNuevo" class="h1" Text="Juego nuevo" /><br>

                    <asp:Button runat="server" id="newGame" class="btn btn-warning btn-lg mt-4" Text="Uno contra uno" OnClick="chooseColor1"/><br><br>
                    <asp:Button runat="server" id="juegoSolo" class="btn btn-warning btn-lg" Text="Contra la máquina" OnClick="chooseColor2"/>

                <asp:Panel runat="server" id="selectColor" class="mt-0 pt-0" Visible="false">
                    <asp:Button runat="server" id="BlancoSelect" class="btn btn-outline-light btn-lg mx-3" Text="Blanco" OnClick="newGame_Click_White"/>
                    <asp:Button runat="server" id="NegroSelect" class="btn btn-outline-dark btn-lg block" Text="Negro" OnClick="newGame_Click_Black"/>
                </asp:Panel>

                <asp:Panel runat="server" id="selectColor2" class="mt-0 pt-0" Visible="false">
                    <asp:Button runat="server" id="BlancoSelect2" class="btn btn-outline-light btn-lg mx-3" Text="Blanco" OnClick="NewGame_Alone_White"/>
                    <asp:Button runat="server" id="NegroSelect2" class="btn btn-outline-dark btn-lg block" Text="Negro" OnClick="NewGame_Alone_Black"/>
                </asp:Panel>
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