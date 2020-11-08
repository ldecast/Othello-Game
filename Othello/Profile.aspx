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
        .regresar{ position:absolute; left:40px; top:35px; font-size:50px;} .panel{ background-color: #95a5a6; width:1100px; }
    </style>
  </head>
  <body>
    <form id="menu" runat="server">
        <div class="container-fluid border-bottom border-secondary py-4 pl-5 titulo2">
        <asp:LinkButton runat="server" ID="exit" OnClick="Regresar" CssClass="btn"><i class="fa fa-arrow-circle-left regresar" aria-hidden="true"></i></asp:LinkButton>
        <asp:Label runat="server" id="lblInfo" CssClass="display-4 pl-5" Text="Perfil de "/>
        <asp:Label runat="server" id="user" CssClass="display-4" Text="Usuario"/>
        </div>


    <asp:Panel runat="server" ID="panelDatos">
        <div class="container pt-4 panel">

        <div class="row pl-3 pb-4 mr-0">

          <div class="col-sm-12 col-lg-7 pt-3 pb-2 pl-4 border-right border-secondary registro">
              <br />
              <asp:Label runat="server" id="Label4" CssClass="h3" Text="Nombres" /><br />
          <asp:Label runat="server" id="Unombre" CssClass="h5" Text=" -" /><br/><br />
              <asp:Label runat="server" id="Label1" CssClass="h3" Text="Apellidos" /><br />
          <asp:Label runat="server" id="Uapellido" CssClass="h5" Text=" -" /><br/><br />
              <asp:Label runat="server" id="Label11" CssClass="h3" Text="Correo" /><br />
          <asp:Label runat="server" id="Ucorreo" CssClass="h5" Text=" -" /><br/><br />
              <asp:Label runat="server" id="Label13" CssClass="h3" Text="Fecha de nacimiento" /><br />
          <asp:Label runat="server" id="Ufecha" CssClass="h5" Text=" -" /><br/><br />
              <asp:Label runat="server" id="Label15" CssClass="h3" Text="País" /><br />
          <asp:Label runat="server" id="Upais" CssClass="h5" Text=" -" />
          </div>

          <div class="col-sm-12 col-lg-5 py-2 pl-4 registro">
              <asp:Label runat="server" id="Label8" CssClass="h4" Text="Partidas ganadas:" /><br/>
          <asp:Label runat="server" id="Pganadas" CssClass="h4 font-weight-bold" Text="0" /><br/><br />
              <asp:Label runat="server" id="Label16" CssClass="h4" Text="Partidas empatadas:" /><br/>
          <asp:Label runat="server" id="Pempatadas" CssClass="h4 font-weight-bold" Text="0" /><br/><br />
              <asp:Label runat="server" id="Label18" CssClass="h4" Text="Partidas perdidas:" /><br/>
          <asp:Label runat="server" id="Pperdidas" CssClass="h4 font-weight-bold" Text="0" /><br/><br />
              <asp:Label runat="server" id="Label20" CssClass="h4" Text="Torneos participados:" /><br/>
          <asp:Label runat="server" id="Tjugados" CssClass="h4 font-weight-bold" Text="0" /><br/><br />
              <asp:Label runat="server" id="Label22" CssClass="h4" Text="Torneos ganados:" /><br/>
          <asp:Label runat="server" id="Tganados" CssClass="h4 font-weight-bold" Text="0" /><br/><br />
              <asp:Label runat="server" id="Label24" CssClass="h4" Text="Puntos de torneos:" /><br/>
          <asp:Label runat="server" id="Tpuntos" CssClass="h4 font-weight-bold" Text="0" />
          </div>

        </div>

        </div>
    </asp:Panel>

    </form>
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
  </body>
</html>