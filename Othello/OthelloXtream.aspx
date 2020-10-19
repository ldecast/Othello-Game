<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OthelloXtream.aspx.cs" Inherits="Othello.OthelloXtream" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- Bootstrap CSS -->
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>
<title>Othello game</title>
  
<style>body{background-color: #2e86c1;} #guardar{margin-top: 47px; height:50px; margin-bottom:12px;} #cronometro{position:absolute; top:65px; left:85px;} #salir{margin-top: 60px; height:50px; margin-bottom:90px; width:120px;} #end{margin-top: 39px; height:50px; padding-left:10px; padding-right:10px; margin-bottom:7px;} #iniciar{margin-left: 520px; margin-bottom: 30px; width:115px;} #ceder_turno{position:absolute; top:59px; right:60px;} .aux{position:absolute; top:0px; left:0px;} .aux2{position:absolute; top:0px; right:0px;} .aux3{position:absolute; top:0px; right:400px;} .aux4{position:absolute; top:0px; right:300px;} .aux5{position:absolute; top:0px; right:950px;}
.btn-Rojo{ background-color: #c72b2b !important; } .btn-Amarillo{ background-color: #e0bf07 !important; } .btn-Azul{ background-color: #203ee9 !important; } .btn-Naranja{ background-color: #f2751c !important; } .btn-Verde{ background-color: #00ff22 !important; } .btn-Violeta{ background-color: #951ec8 !important; } .btn-Celeste{ background-color: #1d90e4 !important; } .btn-Gris{ background-color: gray !important; } .btn-Negro{ background-color: black !important; } .btn-Blanco{ background-color: ghostwhite !important; }
</style>

 <script type="text/javascript">
    //script de www.aprenderaprogramar.com/index.php?option=com_content&view=article&id=847:ejemplo-reloj-javascript
    function reloj() {
        var h = 0; var m = 0; var s = 0;
        document.getElementById('cronometro').style.cssText = document.getElementById('turno').style.cssText;
        window.setInterval(function () {
            s++;
            if (s > 59) { s = 0; m++; }
            if (m > 59) { m = 0; h++; }
            document.getElementById('cronometro').innerHTML = digitocero(h) + ":" + digitocero(m) + ":" + digitocero(s);
        }, 1000);
    }
    function digitocero(i) {
        if (i<10) {i = "0" + i};
        return i;
    }
 </script>

</head>
  <body>
      <form id="tablero" runat="server">
          <asp:Label runat="server" ID="listaColores" CssClass="aux"></asp:Label>
          <asp:Label runat="server" ID="listaOponente" CssClass="aux2"></asp:Label>
          <asp:Label runat="server" ID="indice1" CssClass="aux3">0</asp:Label>
          <asp:Label runat="server" ID="indice2" CssClass="aux4">0</asp:Label>
          <asp:Label runat="server" ID="max" CssClass="aux5">0</asp:Label>
    <div class="container">
        <div id="cronometro" class="h3 ">&nbsp;</div>
        <h1 class="display-1 text-center my-3 text-white">OTHELLO GAME</h1>
        <asp:Button runat="server" id="ceder_turno" CssClass="text-center btn btn-outline-dark btn-lg" Text="Ceder turno" OnClick="Ceder_turno"/>
        <br/>
    </div>
        <div class="container">
            <asp:Button runat="server" id="iniciar" CssClass="text-center btn btn-warning btn-lg" Visible="false" Text="INICIAR" OnClick="Leer_xml"/>
            <div class="row mb-5">
                <div class="col-sm-12 col-lg-2 text-right border-left border-dark">
                    <h3>Turno de:</h3><hr/>
                    <asp:Label runat="server" id="turno" CssClass="display-4" text="" /><br /><br /><br /><br />
                    <h3>Movimientos:</h3><hr/>
                    <asp:Label runat="server" id="movimiento_negro" CssClass="display-4 text" text="0" />
                    <asp:Label runat="server" id="movimiento_blanco" CssClass="display-4 text-white" text="0" Visible="false"  />
                    <asp:Button runat="server" type="button" id="guardar" CssClass="btn btn-outline-dark btn-lg" text="Guardar partida" OnClick="GenerarXml"/>
                </div>
                <asp:Panel runat="server" id="resultados" Cssclass="col-sm-12 col-lg-8 text-center" Visible="false">
                    <asp:Label runat="server" id ="gameover" Text="GAME OVER"/><br />
                    <asp:Label runat="server" id="ganador"/><br /><br />
                    <asp:Button runat="server" type="button" id="salir" CssClass="btn btn-warning btn-lg" text="SALIR" OnClick="Salir"/>
                </asp:Panel>
                <asp:Panel runat="server" id="gameBoard" Cssclass="col-sm-12 col-lg-8 text-center">
                    <a href="#" class="numero btn btn-lg disabled"></a>
                    <a href="#" class="letra btn btn-lg disabled">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;A</a>
                    <a href="#" class="letra btn btn-lg disabled">B</a>
                    <a href="#" class="letra btn btn-lg disabled">C</a>
                    <a href="#" class="letra btn btn-lg disabled">D&ThickSpace;</a>
                    <a href="#" class="letra btn btn-lg disabled">E&ThickSpace;</a>
                    <a href="#" class="letra btn btn-lg disabled">F&ThickSpace;</a>
                    <a href="#" class="letra btn btn-lg disabled">G</a>
                    <a href="#" class="letras btn btn-lg disabled">H&nbsp;&nbsp&nbsp;&nbsp&nbsp;&nbsp</a>

                    <div class="btn-group">
                        <a href="#" class="numero btn btn-lg disabled text-left">1</a>
                        <asp:Button runat="server" type="button" id="a1" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A1_Click"/>
                        <asp:Button runat="server" type="button" id="b1" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B1_Click"/>
                        <asp:Button runat="server" type="button" id="c1" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C1_Click"/>
                        <asp:Button runat="server" type="button" id="d1" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D1_Click"/>
                        <asp:Button runat="server" type="button" id="e1" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E1_Click"/>
                        <asp:Button runat="server" type="button" id="f1" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F1_Click"/>
                        <asp:Button runat="server" type="button" id="g1" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G1_Click"/>
                        <asp:Button runat="server" type="button" id="h1" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H1_Click"/>
                    </div>
                    <div class="btn-group">
                        <a href="#" class="numero btn btn-lg disabled text-left">2</a>
                        <asp:Button runat="server" type="button" id="a2" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A2_Click"/>
                        <asp:Button runat="server" type="button" id="b2" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B2_Click"/>
                        <asp:Button runat="server" type="button" id="c2" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C2_Click"/>
                        <asp:Button runat="server" type="button" id="d2" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D2_Click"/>
                        <asp:Button runat="server" type="button" id="e2" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E2_Click"/>
                        <asp:Button runat="server" type="button" id="f2" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F2_Click"/>
                        <asp:Button runat="server" type="button" id="g2" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G2_Click"/>
                        <asp:Button runat="server" type="button" id="h2" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H2_Click"/>
                    </div>
                    <div class="btn-group">
                        <a href="#" class="numero btn btn-lg disabled text-left">3</a>
                        <asp:Button runat="server" type="button" id="a3" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A3_Click"/>
                        <asp:Button runat="server" type="button" id="b3" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B3_Click"/>
                        <asp:Button runat="server" type="button" id="c3" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C3_Click"/>
                        <asp:Button runat="server" type="button" id="d3" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D3_Click"/>
                        <asp:Button runat="server" type="button" id="e3" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E3_Click"/>
                        <asp:Button runat="server" type="button" id="f3" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F3_Click"/>
                        <asp:Button runat="server" type="button" id="g3" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G3_Click"/>
                        <asp:Button runat="server" type="button" id="h3" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H3_Click"/>
                    </div>
                    <div class="btn-group">
                        <a href="#" class="numero btn btn-lg disabled text-left">4</a>
                        <asp:Button runat="server" type="button" id="a4" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A4_Click"/>
                        <asp:Button runat="server" type="button" id="b4" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B4_Click"/>
                        <asp:Button runat="server" type="button" id="c4" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C4_Click"/>
                        <asp:Button runat="server" type="button" id="d4" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D4_Click"/>
                        <asp:Button runat="server" type="button" id="e4" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E4_Click"/>
                        <asp:Button runat="server" type="button" id="f4" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F4_Click"/>
                        <asp:Button runat="server" type="button" id="g4" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G4_Click"/>
                        <asp:Button runat="server" type="button" id="h4" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H4_Click"/>
                    </div>
                    <div class="btn-group">
                        <a href="#" class="numero btn btn-lg disabled text-left">5</a>
                        <asp:Button runat="server" type="button" id="a5" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A5_Click"/>
                        <asp:Button runat="server" type="button" id="b5" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B5_Click"/>
                        <asp:Button runat="server" type="button" id="c5" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C5_Click"/>
                        <asp:Button runat="server" type="button" id="d5" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D5_Click"/>
                        <asp:Button runat="server" type="button" id="e5" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E5_Click"/>
                        <asp:Button runat="server" type="button" id="f5" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F5_Click"/>
                        <asp:Button runat="server" type="button" id="g5" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G5_Click"/>
                        <asp:Button runat="server" type="button" id="h5" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H5_Click"/>
                    </div>
                    <div class="btn-group">
                        <a href="#" class="numero btn btn-lg disabled text-left">6</a>
                        <asp:Button runat="server" type="button" id="a6" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A6_Click"/>
                        <asp:Button runat="server" type="button" id="b6" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B6_Click"/>
                        <asp:Button runat="server" type="button" id="c6" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C6_Click"/>
                        <asp:Button runat="server" type="button" id="d6" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D6_Click"/>
                        <asp:Button runat="server" type="button" id="e6" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E6_Click"/>
                        <asp:Button runat="server" type="button" id="f6" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F6_Click"/>
                        <asp:Button runat="server" type="button" id="g6" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G6_Click"/>
                        <asp:Button runat="server" type="button" id="h6" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H6_Click"/>
                    </div>
                    <div class="btn-group">
                        <a href="#" class="numero btn btn-lg disabled text-left">7</a>
                        <asp:Button runat="server" type="button" id="a7" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A7_Click"/>
                        <asp:Button runat="server" type="button" id="b7" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B7_Click"/>
                        <asp:Button runat="server" type="button" id="c7" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C7_Click"/>
                        <asp:Button runat="server" type="button" id="d7" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D7_Click"/>
                        <asp:Button runat="server" type="button" id="e7" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E7_Click"/>
                        <asp:Button runat="server" type="button" id="f7" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F7_Click"/>
                        <asp:Button runat="server" type="button" id="g7" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G7_Click"/>
                        <asp:Button runat="server" type="button" id="h7" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H7_Click"/>
                    </div>
                    <div class="btn-group">
                        <a href="#" class="numero btn btn-lg disabled text-left">8</a>
                        <asp:Button runat="server" type="button" id="a8" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A8_Click"/>
                        <asp:Button runat="server" type="button" id="b8" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B8_Click"/>
                        <asp:Button runat="server" type="button" id="c8" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C8_Click"/>
                        <asp:Button runat="server" type="button" id="d8" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D8_Click"/>
                        <asp:Button runat="server" type="button" id="e8" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E8_Click"/>
                        <asp:Button runat="server" type="button" id="f8" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F8_Click"/>
                        <asp:Button runat="server" type="button" id="g8" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G8_Click"/>
                        <asp:Button runat="server" type="button" id="h8" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H8_Click"/>
                    </div>
                </asp:Panel>
                
                <div class="col-sm-12 col-lg-2 text-left border-right border-dark">
                    <h3>SCORE</h3><hr/><br/>
                    <asp:Label runat="server" CssClass="h4" ID="scoreLabel1"></asp:Label><br />
                    <asp:Label runat="server" id="score1" CssClass="display-4" text="0" />
                    <br/><br/>
                    <asp:Label runat="server" CssClass="h4" ID="scoreLabel2" Text="Jugador #2"></asp:Label><br />
                    <asp:Label runat="server" id="score2" CssClass="display-4" text="0" />
                    <br/><br/>
                    <asp:Button runat="server" type="button" id="end" CssClass="btn btn-outline-dark btn-lg" text="Terminar juego" OnClick="Terminar_Juego"/>
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