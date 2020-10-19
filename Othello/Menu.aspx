<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Othello.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
<link rel="stylesheet" href="css\StyleSheet2.css" type="text/css">
<link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">

<title>Menú de juego</title>

  </head>
  <body>
    <form id="menu" runat="server">
    <div class="container">
        <div class="container-fluid text-center mt-4 mb-3">
        <asp:Label runat="server" id="Label1" CssClass="display-1 text-white titulo" Text="Hola "/>
        <asp:Label runat="server" id="usuario" CssClass="display-1 text-white titulo" Text="Usuario"/>
        <asp:Label runat="server" id="Label2" CssClass="display-1 text-white titulo" Text="!"/>
        </div><br/>
        <div class="row py-4">
            <div class="col-sm-12 col-md-6 col-lg-6 text-center mb-2 border-right border-secondary">
                <asp:Label runat="server" id="Label3" CssClass="h1 text-center" Text="Cargar partida" /><br/>

                    <asp:FileUpload runat="server" id="upload" accept=".xml" AllowMultiple="false" CssClass="btn btn-dark btn-lg mt-4" Visible="false"/><br/><br/>
                    <asp:Button runat="server" id="cargar1" CssClass="btn btn-dark btn-lg m-1" Text="2 jugadores" OnClick="CargarElegir1"/>
                    <asp:Button runat="server" id="cargar2" CssClass="btn btn-dark btn-lg m-1" Text="Individual" OnClick="CargarElegir2"/>

                <asp:Panel runat="server" id="Panel1" CssClass="mt-0 pt-0" Visible="false">
                    <asp:Button runat="server" id="Button1" CssClass="btn btn-outline-light btn-lg mr-3" Text="Blanco" OnClick="Redireccionar1"/>
                    <asp:Button runat="server" id="Button2" CssClass="btn btn-outline-dark btn-lg block" Text="Negro" OnClick="Redireccionar2"/>
                </asp:Panel>

                <asp:Panel runat="server" id="Panel2" CssClass="mt-0 pt-0" Visible="false">
                    <asp:Button runat="server" id="Button3" CssClass="btn btn-outline-light btn-lg mr-3" Text="Blanco" OnClick="Redireccionar3"/>
                    <asp:Button runat="server" id="Button4" CssClass="btn btn-outline-dark btn-lg block" Text="Negro" OnClick="Redireccionar4"/>
                </asp:Panel>
                  
            </div>
            <div class="col-sm-12 col-md-6 col-lg-6 text-center mb-2">
                <asp:Label runat="server" id="juegoNuevo" CssClass="h1" Text="Othello Clásico" /><br/>

                    <asp:Button runat="server" id="newGame" CssClass="btn btn-warning btn-lg mt-4 clasic" Text="Uno contra uno" OnClick="ChooseColor1"/><br/><br/>
                    <asp:Button runat="server" id="juegoSolo" CssClass="btn btn-warning btn-lg clasic" Text="Contra la máquina" OnClick="ChooseColor2"/>

                <asp:Panel runat="server" id="selectColor" CssClass="mt-0 pt-0" Visible="false">
                    <asp:Button runat="server" id="BlancoSelect" CssClass="btn btn-outline-light btn-lg mr-3" Text="Blanco" OnClick="NewGame_Click_White"/>
                    <asp:Button runat="server" id="NegroSelect" CssClass="btn btn-outline-dark btn-lg block" Text="Negro" OnClick="NewGame_Click_Black"/>
                </asp:Panel>

                <asp:Panel runat="server" id="selectColor2" CssClass="mt-0 pt-0" Visible="false">
                    <asp:Button runat="server" id="BlancoSelect2" CssClass="btn btn-outline-light btn-lg mr-3" Text="Blanco" OnClick="NewGame_Alone_White"/>
                    <asp:Button runat="server" id="NegroSelect2" CssClass="btn btn-outline-dark btn-lg block" Text="Negro" OnClick="NewGame_Alone_Black"/>
                </asp:Panel>
            </div>
        </div>
        <div class="row py-4">

            <div class="col-sm-12 col-md-6 col-lg-6 border-right border-secondary text-center mb-2">
                <asp:Label runat="server" id="Label4" CssClass="h1" Text="Perfil de usuario" /><br/><br/>
                <asp:LinkButton runat="server" ID="perfil" OnClick="Ver_perfil" CssClass="btn btn-success btn-lg mt-2 text-body prof"><i class="fa fa-user" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;Ver perfil</asp:LinkButton><br/><br/>
                <asp:LinkButton runat="server" ID="cerrar" OnClick="Cerrar_sesion" CssClass="btn btn-danger btn-lg text-body prof"><i class="fa fa-sign-out" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;Cerrar sesión</asp:LinkButton><br/><br/>
            </div>

            <div class="col-sm-12 col-md-6 col-lg-6  text-center mb-2">
                <asp:Label runat="server" id="tmod" CssClass="h1" Text="Funcionalidades" /><br /><br />

                <asp:Panel runat="server" id="selectMod" CssClass="mt-0 pt-0" Visible="false">
                    <br />
                    <asp:Button runat="server" id="Button9" CssClass="btn btn-info btn-lg text-body mr-3" OnClick="ChooseColor3" Text="Juego normal"/>
                    <asp:Button runat="server" id="Button10" CssClass="btn btn-info btn-lg text-body block" OnClick="ChooseColor4" Text="Reto inverso"/>
                </asp:Panel>

                <asp:Panel runat="server" id="selectColor3" CssClass="mt-0 pt-0" Visible="false">
                    <div class="row justify-content-md-center mb-4">
                    <asp:CheckBoxList ID="UserColors" RepeatDirection="Horizontal" RepeatColumns="5" CellPadding="4" runat="server">
                        <asp:ListItem class="h6 rojo px-2" Value="rojo">&nbsp;Rojo</asp:ListItem>
                        <asp:ListItem class="h6 amarillo px-1" Value="amarillo">&nbsp;Amarillo</asp:ListItem>
                        <asp:ListItem class="h6 azul" Value="azul">&nbsp;Azul</asp:ListItem>
                        <asp:ListItem class="h6 naranja px-1" Value="naranja">&nbsp;Naranja</asp:ListItem>
                        <asp:ListItem class="h6 verde px-1" Value="verde">&nbsp;Verde</asp:ListItem>
                        <asp:ListItem class="h6 violeta px-1" Value="violeta">&nbsp;Violeta</asp:ListItem>
                        <asp:ListItem class="h6 blanco" Value="blanco">&nbsp;Blanco</asp:ListItem>
                        <asp:ListItem class="h6 negro" Value="negro">&nbsp;Negro</asp:ListItem>
                        <asp:ListItem class="h6 celeste" Value="celeste">&nbsp;Celeste</asp:ListItem>
                        <asp:ListItem class="h6 gris px-2" Value="gris">&nbsp;Gris</asp:ListItem>
                    </asp:CheckBoxList>
                    </div>
                    <br />
                    <asp:Label runat="server" id="Jugador2Colors" Text="Colores para jugador 2" CssClass="h5 h5mod"/><br/><br/>
                   <div class="row justify-content-md-center mb-0">
                    <asp:CheckBoxList ID="playerColors" RepeatDirection="Horizontal" RepeatColumns="5" CellPadding="4" runat="server">
                        <asp:ListItem class="h6 rojo px-2" Value="rojo">&nbsp;Rojo</asp:ListItem>
                        <asp:ListItem class="h6 amarillo px-1" Value="amarillo">&nbsp;Amarillo</asp:ListItem>
                        <asp:ListItem class="h6 azul" Value="azul">&nbsp;Azul</asp:ListItem>
                        <asp:ListItem class="h6 naranja px-1" Value="naranja">&nbsp;Naranja</asp:ListItem>
                        <asp:ListItem class="h6 verde px-1" Value="verde">&nbsp;Verde</asp:ListItem>
                        <asp:ListItem class="h6 violeta px-1" Value="violeta">&nbsp;Violeta</asp:ListItem>
                        <asp:ListItem class="h6 blanco" Value="blanco">&nbsp;Blanco</asp:ListItem>
                        <asp:ListItem class="h6 negro" Value="negro">&nbsp;Negro</asp:ListItem>
                        <asp:ListItem class="h6 celeste" Value="celeste">&nbsp;Celeste</asp:ListItem>
                        <asp:ListItem class="h6 gris px-2" Value="gris">&nbsp;Gris</asp:ListItem>
                    </asp:CheckBoxList>
                    </div>
                    <br /><br />
                    <asp:LinkButton runat="server" ID="btnNormal" CssClass="btn btn-primary btn-lg text-body mt-4 mb-0" Visible="false" OnClick="Xtream_Normal"><i class="fa fa-check-circle" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;Comenzar!</asp:LinkButton><br /><br />
                    <asp:LinkButton runat="server" ID="btnInverso" CssClass="btn btn-primary btn-lg text-body mt-0 mb-0" Visible="false" OnClick="Xtream_Inverso"><i class="fa fa-check-circle" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;Comenzar!</asp:LinkButton><br /><br />
                </asp:Panel>

                    <asp:LinkButton runat="server" ID="xtream" CssClass="btn btn-primary btn-lg text-body mt-2 mod" OnClick="ChooseMod"><i class="fa fa-gamepad" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;Othello Xtream</asp:LinkButton><br /><br />
                    <asp:LinkButton runat="server" ID="torneo" CssClass="btn btn-primary btn-lg text-body mod"><i class="fa fa-trophy" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;Campeonato</asp:LinkButton>
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