<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Othello.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
<link rel="stylesheet" href="css\StyleSheet2.css" type="text/css">
<link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">

<title>Perfil de usuario</title>
    <style>
        .regresar{ position:absolute; left:40px; top:35px; font-size:50px;}
    </style>
  </head>
  <body>
    <form id="menu" runat="server">
        <div class="container-fluid py-4 pl-5 titulo2">
        <asp:LinkButton runat="server" ID="exit" OnClick="Regresar" CssClass="btn"><i class="fa fa-arrow-circle-left regresar" aria-hidden="true"></i></asp:LinkButton>
        <asp:Label runat="server" id="Label11" CssClass="display-4 pl-5" Text="Perfil de "/>
        <asp:Label runat="server" id="user" CssClass="display-4" Text="Usuario"/>
        </div>

    <div class="container py-4 fondo">

        <div class="row pl-3 mr-0">
          <div class="col-sm-12 col-lg-6 mb-5 pb-2 pl-4 border-right border-secondary registro">
          <asp:Label runat="server" id="Label1" CssClass="h1" Text="Partidas ganadas" /><br/><br />
          <asp:Label runat="server" id="partidasGanadas" CssClass="h1 text-center" Text="0" /><br/>

        </div>
          <div class="col-sm-12 col-lg-6 mb-5 pb-2 pl-4 registro">
          <asp:Label runat="server" id="Label2" CssClass="h1" Text="Torneos participados:" /><br/><br />
          <asp:Label runat="server" id="torneosParticipados" CssClass="h1 text-center" Text="0" /><br/>
        </div>
        </div>

          <div class="row pl-3 mr-0">
          <div class="col-sm-12 col-lg-6 mb-5 pb-2 pl-4 border-right border-secondary registro">
          <asp:Label runat="server" id="Label3" CssClass="h1" Text="Partidas empatadas" /><br/><br />
          <asp:Label runat="server" id="partidasEmpatadas" CssClass="h1 text-center" Text="0" /><br/>

        </div>
          <div class="col-sm-12 col-lg-6 mb-5 pb-2 pl-4 registro">
          <asp:Label runat="server" id="Label5" CssClass="h1" Text="Torneos ganados:" /><br/><br />
          <asp:Label runat="server" id="torneosGanados" CssClass="h1 text-center" Text="0" /><br/>
        </div>
        </div>

        <div class="row pl-3 mr-0">
          <div class="col-sm-12 col-lg-6 mb-5 pb-2 pl-4 border-right border-secondary registro">
          <asp:Label runat="server" id="Label7" CssClass="h1" Text="Partidas perdidas" /><br/><br />
          <asp:Label runat="server" id="partidasPerdidas" CssClass="h1 text-center" Text="0" /><br/>

        </div>
          <div class="col-sm-12 col-lg-6 mb-5 pb-2 pl-4 registro">
          <asp:Label runat="server" id="Label9" CssClass="h1" Text="Puntos de torneos:" /><br/><br />
          <asp:Label runat="server" id="puntosTorneos" CssClass="h1 text-center" Text="0" />
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