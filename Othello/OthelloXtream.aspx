<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OthelloXtream.aspx.cs" Inherits="Othello.ReverseOthello" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- Bootstrap CSS -->
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>
<title>Othello Xtream</title>
  
<style>body{background-color: #2e86c1;} #guardar{margin-top: 52px; width:170px; height:50px;} #cronometro{position:absolute; top:65px; left:85px;} #salir{margin-top: 20px; margin-bottom:20px; width:170px; height:50px;} #end{margin-top: 20px; margin-bottom:20px; width:170px; height:50px;} #iniciar{margin-left: 520px; margin-bottom: 30px; width:115px;} #ceder_turno{position:absolute; top:59px; right:60px;} .aux{position:absolute; top:0px; left:0px;} .aux2{position:absolute; top:0px; right:0px;} .aux3{position:absolute; top:0px; right:400px; color: #2e86c1;} .aux4{position:absolute; top:0px; right:300px; color: #2e86c1;} .aux5{position:absolute; top:0px; right:750px; color: #2e86c1;}
.btn-Rojo{ background-color: #c72b2b !important; } .btn-Amarillo{ background-color: #e0bf07 !important; } .btn-Azul{ background-color: #203ee9 !important; } .btn-Naranja{ background-color: #f2751c !important; } .btn-Verde{ background-color: #00ff22 !important; } .btn-Violeta{ background-color: #951ec8 !important; } .btn-Celeste{ background-color: #1d90e4 !important; } .btn-Gris{ background-color: gray !important; } .btn-Negro{ background-color: black !important; } .btn-Blanco{ background-color: ghostwhite !important; } .aux6{position:absolute; top:0px; right:850px; color: #2e86c1;}
.tablero { position:absolute; right: 500px; } .panel{ position:absolute; left: 50px; } .letras{ width:50px; text-align:center;} .none{width:40px;} .resultados{ position:absolute; top:210px; left:250px;} .time{position:absolute; top:65px; left:85px;}
</style>

 <script type="text/javascript">
     function reloj1() {
         var tiempo = document.getElementById('<%= cronometro1.ClientID %>').innerHTML;
         var h = parseInt(tiempo.substring(0, tiempo.indexOf(':'))); var m = parseInt(tiempo.substring(tiempo.indexOf(':', 0) + 1)); var s = parseInt(tiempo.substring(tiempo.indexOf(':', 3) + 1));
         document.getElementById('cronometro1').style.cssText = document.getElementById('turno').style.cssText;
         window.setInterval(function () {
            s++;
            if (s > 59) { s = 0; m++; }
            if (m > 59) { m = 0; h++; }
            document.getElementById('cronometro1').innerHTML = digitocero(h) + ":" + digitocero(m) + ":" + digitocero(s);
            document.getElementById('<%= estado1.ClientID %>').value = digitocero(h) + ":" + digitocero(m) + ":" + digitocero(s);
        }, 1000);
     }

     function reloj2() {
         var tiempo = document.getElementById('<%= cronometro2.ClientID %>').innerHTML;
         var h = parseInt(tiempo.substring(0, tiempo.indexOf(':'))); var m = parseInt(tiempo.substring(tiempo.indexOf(':', 0) + 1)); var s = parseInt(tiempo.substring(tiempo.indexOf(':', 3) + 1));
         document.getElementById('cronometro2').style.cssText = document.getElementById('turno').style.cssText;
         window.setInterval(function () {
             s++;
             if (s > 59) { s = 0; m++; }
             if (m > 59) { m = 0; h++; }
             document.getElementById('cronometro2').innerHTML = digitocero(h) + ":" + digitocero(m) + ":" + digitocero(s);
             document.getElementById('<%= estado2.ClientID %>').value = digitocero(h) + ":" + digitocero(m) + ":" + digitocero(s);
         }, 1000);

     }
    function digitocero(i) {
        if (i<10) {i = "0" + i};
        return i;
     }

     function Tamaño_tablero() {
         var tamaño = prompt("Ingrese la dimensión del tablero separada por una coma (filas, columnas):");
         document.getElementById('dimension').textContent = tamaño;
         var filas = parseInt(tamaño.substring(0, tamaño.indexOf(',')));
         var col = parseInt(tamaño.substring(tamaño.indexOf(',')+1));
         if (filas >= 6 && filas <= 20 && col >= 6 && col <= 20) {
             __doPostBack("dimensionar", tamaño);
         }
         else {
             alert("El tablero debe ser como mínimo de 6x6 y un máximo de 20x20");
             Tamaño_tablero();
         }
     }
 </script>

</head>
  <body>
      <form id="tablero" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
          <asp:Label runat="server" ID="listaColores" CssClass="aux"></asp:Label>
          <asp:Label runat="server" ID="listaOponente" CssClass="aux2"></asp:Label>
          <asp:Label runat="server" ID="indice1" CssClass="aux3">0</asp:Label>
          <asp:Label runat="server" ID="indice2" CssClass="aux4">0</asp:Label>
          <asp:Label runat="server" ID="max" CssClass="aux5">0</asp:Label>
          <asp:Label runat="server" ID="dimension" Text="" CssClass="aux6"></asp:Label>
    <div class="container">
        <input id="estado1" value="00:00:00" type="hidden" runat="server"/>
        <input id="estado2" value="00:00:00" type="hidden" runat="server"/>
        <div runat="server" id="cronometro1" class="h3 time">00:00:00</div>
        <div runat="server" id="cronometro2" visible="false" class="h3 time">00:00:00</div>
        <h1 class="display-1 text-center my-3 text-white">OTHELLO GAME</h1>
        <asp:Button runat="server" id="ceder_turno" CssClass="text-center btn btn-outline-dark btn-lg" Text="Ceder turno" OnClick="Ceder_turno"/>
        <br/>
    </div>
        <div class="container">
            <asp:Button runat="server" id="iniciar" CssClass="text-center btn btn-warning btn-lg" Text="INICIAR" Visible="false" />
            <div class="row mb-5">
                <div class="col-sm-12 col-lg-2 pr-5 mt-5 text-right panel border-left border-dark">
                    <h3>Turno de:</h3><hr>
                    <asp:Label runat="server" id="turno" CssClass="display-4" text="" /><br /><br /><br /><br />
                    <h3>Movimientos:</h3><hr>
                    <asp:Label runat="server" id="movimiento_user" CssClass="display-4" text="0" />
                    <asp:Label runat="server" id="movimiento_oponente" CssClass="display-4" text="0" Visible="false"  />
                    <br /><br /><br /><br />
                    <h3>SCORE</h3><hr/><br/>
                    <asp:Label runat="server" CssClass="h4" ID="scoreLabel1"></asp:Label><br />
                    <asp:Label runat="server" id="score1" CssClass="display-4" text="0" />
                    <br/><br/>
                    <asp:Label runat="server" CssClass="h4" ID="scoreLabel2" Text="Oponente"></asp:Label><br />
                    <asp:Label runat="server" id="score2" CssClass="display-4" text="0" />
                    <br/>
                    <asp:Button runat="server" type="button" id="guardar" CssClass="btn btn-outline-dark btn-lg" text="Guardar partida" OnClick="GenerarXml"/>
                    <br />
                    <asp:Button runat="server" type="button" id="end" CssClass="btn btn-outline-dark btn-lg" text="Terminar juego" OnClick="Terminar_Juego"/>
                    <br />
                </div>


                <asp:Panel runat="server" id="resultados" Cssclass="col-sm-12 resultados col-lg-8 text-center" Visible="false">
                    <asp:Label runat="server" id ="gameover" CssClass="display-1" Text="GAME OVER"/><br />
                    <asp:Label runat="server" CssClass="display-1" id="ganador" Visible="true"/><br /><br />
                <asp:Button runat="server" type="button" id="salir" CssClass="btn btn-warning btn-lg" text="SALIR" OnClick="Salir"/>
                </asp:Panel>


                <asp:Panel runat="server" id="gameBoard">

                    <div class=" tablero col-sm-12 pr-5 mb-5 col-lg-5">

                        <div class="btn-group text-center">
                    <asp:HyperLink runat="server" href="#" Visible="true" ID="none" CssClass="btn btn-lg disabled none"></asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="ca" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;A</asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="cb" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;B</asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="cc" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;C</asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="cd" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D</asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="ce" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;E</asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="cf" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;F</asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="cg" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;G</asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="ch" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;H</asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="ci" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;I</asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="cj" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;J</asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="ck" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;K</asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="cl" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;L</asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="cm" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;M</asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="cn" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;N</asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="co" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;O</asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="cp" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;P</asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="cq" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Q</asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="cr" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;R</asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="cs" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;S</asp:HyperLink>
                    <asp:HyperLink runat="server" href="#" Visible="false" ID="ct" CssClass="btn btn-lg disabled letras">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;T</asp:HyperLink>
                        </div>


                    <asp:Panel runat="server" ID="fila1" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="funo" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;&nbsp;&nbsp;1</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A1_Click"/>
                        <asp:Button runat="server" type="button" id="b1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B1_Click"/>
                        <asp:Button runat="server" type="button" id="c1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C1_Click"/>
                        <asp:Button runat="server" type="button" id="d1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D1_Click"/>
                        <asp:Button runat="server" type="button" id="e1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E1_Click"/>
                        <asp:Button runat="server" type="button" id="f1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F1_Click"/>
                        <asp:Button runat="server" type="button" id="g1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G1_Click"/>
                        <asp:Button runat="server" type="button" id="h1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H1_Click"/>
                        <asp:Button runat="server" type="button" id="i1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I1_Click"/>
                        <asp:Button runat="server" type="button" id="j1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J1_Click"/>
                        <asp:Button runat="server" type="button" id="k1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K1_Click"/>
                        <asp:Button runat="server" type="button" id="l1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L1_Click"/>
                        <asp:Button runat="server" type="button" id="m1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M1_Click"/>
                        <asp:Button runat="server" type="button" id="n1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N1_Click"/>
                        <asp:Button runat="server" type="button" id="o1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O1_Click"/>
                        <asp:Button runat="server" type="button" id="p1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P1_Click"/>
                        <asp:Button runat="server" type="button" id="q1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q1_Click"/>
                        <asp:Button runat="server" type="button" id="r1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R1_Click"/>
                        <asp:Button runat="server" type="button" id="s1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S1_Click"/>
                        <asp:Button runat="server" type="button" id="t1" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T1_Click"/>
                        <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink1" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="fila2" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="fdos" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;&nbsp;&nbsp;2</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A2_Click"/>
                        <asp:Button runat="server" type="button" id="b2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B2_Click"/>
                        <asp:Button runat="server" type="button" id="c2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C2_Click"/>
                        <asp:Button runat="server" type="button" id="d2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D2_Click"/>
                        <asp:Button runat="server" type="button" id="e2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E2_Click"/>
                        <asp:Button runat="server" type="button" id="f2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F2_Click"/>
                        <asp:Button runat="server" type="button" id="g2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G2_Click"/>
                        <asp:Button runat="server" type="button" id="h2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H2_Click"/>
                        <asp:Button runat="server" type="button" id="i2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I2_Click"/>
                        <asp:Button runat="server" type="button" id="j2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J2_Click"/>
                        <asp:Button runat="server" type="button" id="k2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K2_Click"/>
                        <asp:Button runat="server" type="button" id="l2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L2_Click"/>
                        <asp:Button runat="server" type="button" id="m2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M2_Click"/>
                        <asp:Button runat="server" type="button" id="n2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N2_Click"/>
                        <asp:Button runat="server" type="button" id="o2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O2_Click"/>
                        <asp:Button runat="server" type="button" id="p2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P2_Click"/>
                        <asp:Button runat="server" type="button" id="q2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q2_Click"/>
                        <asp:Button runat="server" type="button" id="r2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R2_Click"/>
                        <asp:Button runat="server" type="button" id="s2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S2_Click"/>
                        <asp:Button runat="server" type="button" id="t2" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T2_Click"/>
                        <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink2" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="fila3" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="ftres" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;&nbsp;&nbsp;3</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A3_Click"/>
                        <asp:Button runat="server" type="button" id="b3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B3_Click"/>
                        <asp:Button runat="server" type="button" id="c3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C3_Click"/>
                        <asp:Button runat="server" type="button" id="d3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D3_Click"/>
                        <asp:Button runat="server" type="button" id="e3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E3_Click"/>
                        <asp:Button runat="server" type="button" id="f3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F3_Click"/>
                        <asp:Button runat="server" type="button" id="g3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G3_Click"/>
                        <asp:Button runat="server" type="button" id="h3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H3_Click"/>
                        <asp:Button runat="server" type="button" id="i3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I3_Click"/>
                        <asp:Button runat="server" type="button" id="j3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J3_Click"/>
                        <asp:Button runat="server" type="button" id="k3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K3_Click"/>
                        <asp:Button runat="server" type="button" id="l3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L3_Click"/>
                        <asp:Button runat="server" type="button" id="m3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M3_Click"/>
                        <asp:Button runat="server" type="button" id="n3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N3_Click"/>
                        <asp:Button runat="server" type="button" id="o3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O3_Click"/>
                        <asp:Button runat="server" type="button" id="p3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P3_Click"/>
                        <asp:Button runat="server" type="button" id="q3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q3_Click"/>
                        <asp:Button runat="server" type="button" id="r3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R3_Click"/>
                        <asp:Button runat="server" type="button" id="s3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S3_Click"/>
                        <asp:Button runat="server" type="button" id="t3" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T3_Click"/>
                        <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink3" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="fila4" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="fcuatro" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;&nbsp;&nbsp;4</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A4_Click"/>
                        <asp:Button runat="server" type="button" id="b4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B4_Click"/>
                        <asp:Button runat="server" type="button" id="c4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C4_Click"/>
                        <asp:Button runat="server" type="button" id="d4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D4_Click"/>
                        <asp:Button runat="server" type="button" id="e4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E4_Click"/>
                        <asp:Button runat="server" type="button" id="f4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F4_Click"/>
                        <asp:Button runat="server" type="button" id="g4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G4_Click"/>
                        <asp:Button runat="server" type="button" id="h4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H4_Click"/>
                        <asp:Button runat="server" type="button" id="i4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I4_Click"/>
                        <asp:Button runat="server" type="button" id="j4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J4_Click"/>
                        <asp:Button runat="server" type="button" id="k4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K4_Click"/>
                        <asp:Button runat="server" type="button" id="l4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L4_Click"/>
                        <asp:Button runat="server" type="button" id="m4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M4_Click"/>
                        <asp:Button runat="server" type="button" id="n4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N4_Click"/>
                        <asp:Button runat="server" type="button" id="o4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O4_Click"/>
                        <asp:Button runat="server" type="button" id="p4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P4_Click"/>
                        <asp:Button runat="server" type="button" id="q4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q4_Click"/>
                        <asp:Button runat="server" type="button" id="r4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R4_Click"/>
                        <asp:Button runat="server" type="button" id="s4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S4_Click"/>
                        <asp:Button runat="server" type="button" id="t4" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T4_Click"/>
                        <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink4" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="fila5" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="fcinco" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;&nbsp;&nbsp;5</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A5_Click"/>
                        <asp:Button runat="server" type="button" id="b5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B5_Click"/>
                        <asp:Button runat="server" type="button" id="c5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C5_Click"/>
                        <asp:Button runat="server" type="button" id="d5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D5_Click"/>
                        <asp:Button runat="server" type="button" id="e5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E5_Click"/>
                        <asp:Button runat="server" type="button" id="f5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F5_Click"/>
                        <asp:Button runat="server" type="button" id="g5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G5_Click"/>
                        <asp:Button runat="server" type="button" id="h5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H5_Click"/>
                        <asp:Button runat="server" type="button" id="i5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I5_Click"/>
                        <asp:Button runat="server" type="button" id="j5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J5_Click"/>
                        <asp:Button runat="server" type="button" id="k5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K5_Click"/>
                        <asp:Button runat="server" type="button" id="l5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L5_Click"/>
                        <asp:Button runat="server" type="button" id="m5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M5_Click"/>
                        <asp:Button runat="server" type="button" id="n5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N5_Click"/>
                        <asp:Button runat="server" type="button" id="o5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O5_Click"/>
                        <asp:Button runat="server" type="button" id="p5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P5_Click"/>
                        <asp:Button runat="server" type="button" id="q5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q5_Click"/>
                        <asp:Button runat="server" type="button" id="r5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R5_Click"/>
                        <asp:Button runat="server" type="button" id="s5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S5_Click"/>
                        <asp:Button runat="server" type="button" id="t5" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T5_Click"/>
                        <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink5" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="fila6" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="fseis" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;&nbsp;&nbsp;6</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A6_Click"/>
                        <asp:Button runat="server" type="button" id="b6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B6_Click"/>
                        <asp:Button runat="server" type="button" id="c6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C6_Click"/>
                        <asp:Button runat="server" type="button" id="d6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D6_Click"/>
                        <asp:Button runat="server" type="button" id="e6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E6_Click"/>
                        <asp:Button runat="server" type="button" id="f6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F6_Click"/>
                        <asp:Button runat="server" type="button" id="g6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G6_Click"/>
                        <asp:Button runat="server" type="button" id="h6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H6_Click"/>
                        <asp:Button runat="server" type="button" id="i6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I6_Click"/>
                        <asp:Button runat="server" type="button" id="j6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J6_Click"/>
                        <asp:Button runat="server" type="button" id="k6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K6_Click"/>
                        <asp:Button runat="server" type="button" id="l6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L6_Click"/>
                        <asp:Button runat="server" type="button" id="m6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M6_Click"/>
                        <asp:Button runat="server" type="button" id="n6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N6_Click"/>
                        <asp:Button runat="server" type="button" id="o6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O6_Click"/>
                        <asp:Button runat="server" type="button" id="p6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P6_Click"/>
                        <asp:Button runat="server" type="button" id="q6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q6_Click"/>
                        <asp:Button runat="server" type="button" id="r6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R6_Click"/>
                        <asp:Button runat="server" type="button" id="s6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S6_Click"/>
                        <asp:Button runat="server" type="button" id="t6" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T6_Click"/>
                        <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink6" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="fila7" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="fsiete" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;&nbsp;&nbsp;7</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A7_Click"/>
                        <asp:Button runat="server" type="button" id="b7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B7_Click"/>
                        <asp:Button runat="server" type="button" id="c7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C7_Click"/>
                        <asp:Button runat="server" type="button" id="d7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D7_Click"/>
                        <asp:Button runat="server" type="button" id="e7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E7_Click"/>
                        <asp:Button runat="server" type="button" id="f7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F7_Click"/>
                        <asp:Button runat="server" type="button" id="g7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G7_Click"/>
                        <asp:Button runat="server" type="button" id="h7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H7_Click"/>
                        <asp:Button runat="server" type="button" id="i7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I7_Click"/>
                        <asp:Button runat="server" type="button" id="j7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J7_Click"/>
                        <asp:Button runat="server" type="button" id="k7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K7_Click"/>
                        <asp:Button runat="server" type="button" id="l7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L7_Click"/>
                        <asp:Button runat="server" type="button" id="m7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M7_Click"/>
                        <asp:Button runat="server" type="button" id="n7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N7_Click"/>
                        <asp:Button runat="server" type="button" id="o7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O7_Click"/>
                        <asp:Button runat="server" type="button" id="p7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P7_Click"/>
                        <asp:Button runat="server" type="button" id="q7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q7_Click"/>
                        <asp:Button runat="server" type="button" id="r7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R7_Click"/>
                        <asp:Button runat="server" type="button" id="s7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S7_Click"/>
                        <asp:Button runat="server" type="button" id="t7" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T7_Click"/>
                        <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink7" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="fila8" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="focho" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;&nbsp;&nbsp;8</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A8_Click"/>
                        <asp:Button runat="server" type="button" id="b8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B8_Click"/>
                        <asp:Button runat="server" type="button" id="c8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C8_Click"/>
                        <asp:Button runat="server" type="button" id="d8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D8_Click"/>
                        <asp:Button runat="server" type="button" id="e8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E8_Click"/>
                        <asp:Button runat="server" type="button" id="f8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F8_Click"/>
                        <asp:Button runat="server" type="button" id="g8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G8_Click"/>
                        <asp:Button runat="server" type="button" id="h8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H8_Click"/>
                        <asp:Button runat="server" type="button" id="i8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I8_Click"/>
                        <asp:Button runat="server" type="button" id="j8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J8_Click"/>
                        <asp:Button runat="server" type="button" id="k8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K8_Click"/>
                        <asp:Button runat="server" type="button" id="l8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L8_Click"/>
                        <asp:Button runat="server" type="button" id="m8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M8_Click"/>
                        <asp:Button runat="server" type="button" id="n8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N8_Click"/>
                        <asp:Button runat="server" type="button" id="o8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O8_Click"/>
                        <asp:Button runat="server" type="button" id="p8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P8_Click"/>
                        <asp:Button runat="server" type="button" id="q8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q8_Click"/>
                        <asp:Button runat="server" type="button" id="r8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R8_Click"/>
                        <asp:Button runat="server" type="button" id="s8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S8_Click"/>
                        <asp:Button runat="server" type="button" id="t8" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T8_Click"/>
                        <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink8" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                     <asp:Panel runat="server" ID="fila9" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="fnueve" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;&nbsp;&nbsp;9</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A9_Click"/>
                        <asp:Button runat="server" type="button" id="b9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B9_Click"/>
                        <asp:Button runat="server" type="button" id="c9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C9_Click"/>
                        <asp:Button runat="server" type="button" id="d9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D9_Click"/>
                        <asp:Button runat="server" type="button" id="e9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E9_Click"/>
                        <asp:Button runat="server" type="button" id="f9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F9_Click"/>
                        <asp:Button runat="server" type="button" id="g9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G9_Click"/>
                        <asp:Button runat="server" type="button" id="h9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H9_Click"/>
                        <asp:Button runat="server" type="button" id="i9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I9_Click"/>
                        <asp:Button runat="server" type="button" id="j9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J9_Click"/>
                        <asp:Button runat="server" type="button" id="k9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K9_Click"/>
                        <asp:Button runat="server" type="button" id="l9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L9_Click"/>
                        <asp:Button runat="server" type="button" id="m9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M9_Click"/>
                        <asp:Button runat="server" type="button" id="n9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N9_Click"/>
                        <asp:Button runat="server" type="button" id="o9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O9_Click"/>
                        <asp:Button runat="server" type="button" id="p9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P9_Click"/>
                        <asp:Button runat="server" type="button" id="q9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q9_Click"/>
                        <asp:Button runat="server" type="button" id="r9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R9_Click"/>
                        <asp:Button runat="server" type="button" id="s9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S9_Click"/>
                        <asp:Button runat="server" type="button" id="t9" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T9_Click"/>
                         <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink9" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                     <asp:Panel runat="server" ID="fila10" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="fdiez" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;10</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A10_Click"/>
                        <asp:Button runat="server" type="button" id="b10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B10_Click"/>
                        <asp:Button runat="server" type="button" id="c10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C10_Click"/>
                        <asp:Button runat="server" type="button" id="d10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D10_Click"/>
                        <asp:Button runat="server" type="button" id="e10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E10_Click"/>
                        <asp:Button runat="server" type="button" id="f10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F10_Click"/>
                        <asp:Button runat="server" type="button" id="g10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G10_Click"/>
                        <asp:Button runat="server" type="button" id="h10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H10_Click"/>
                        <asp:Button runat="server" type="button" id="i10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I10_Click"/>
                        <asp:Button runat="server" type="button" id="j10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J10_Click"/>
                        <asp:Button runat="server" type="button" id="k10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K10_Click"/>
                        <asp:Button runat="server" type="button" id="l10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L10_Click"/>
                        <asp:Button runat="server" type="button" id="m10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M10_Click"/>
                        <asp:Button runat="server" type="button" id="n10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N10_Click"/>
                        <asp:Button runat="server" type="button" id="o10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O10_Click"/>
                        <asp:Button runat="server" type="button" id="p10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P10_Click"/>
                        <asp:Button runat="server" type="button" id="q10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q10_Click"/>
                        <asp:Button runat="server" type="button" id="r10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R10_Click"/>
                        <asp:Button runat="server" type="button" id="s10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S10_Click"/>
                        <asp:Button runat="server" type="button" id="t10" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T10_Click"/>
                         <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink10" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="fila11" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="fonce" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;11</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A11_Click"/>
                        <asp:Button runat="server" type="button" id="b11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B11_Click"/>
                        <asp:Button runat="server" type="button" id="c11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C11_Click"/>
                        <asp:Button runat="server" type="button" id="d11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D11_Click"/>
                        <asp:Button runat="server" type="button" id="e11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E11_Click"/>
                        <asp:Button runat="server" type="button" id="f11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F11_Click"/>
                        <asp:Button runat="server" type="button" id="g11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G11_Click"/>
                        <asp:Button runat="server" type="button" id="h11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H11_Click"/>
                        <asp:Button runat="server" type="button" id="i11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I11_Click"/>
                        <asp:Button runat="server" type="button" id="j11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J11_Click"/>
                        <asp:Button runat="server" type="button" id="k11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K11_Click"/>
                        <asp:Button runat="server" type="button" id="l11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L11_Click"/>
                        <asp:Button runat="server" type="button" id="m11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M11_Click"/>
                        <asp:Button runat="server" type="button" id="n11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N11_Click"/>
                        <asp:Button runat="server" type="button" id="o11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O11_Click"/>
                        <asp:Button runat="server" type="button" id="p11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P11_Click"/>
                        <asp:Button runat="server" type="button" id="q11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q11_Click"/>
                        <asp:Button runat="server" type="button" id="r11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R11_Click"/>
                        <asp:Button runat="server" type="button" id="s11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S11_Click"/>
                        <asp:Button runat="server" type="button" id="t11" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T11_Click"/>
                        <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink11" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                     <asp:Panel runat="server" ID="fila12" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="fdoce" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;12</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A12_Click"/>
                        <asp:Button runat="server" type="button" id="b12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B12_Click"/>
                        <asp:Button runat="server" type="button" id="c12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C12_Click"/>
                        <asp:Button runat="server" type="button" id="d12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D12_Click"/>
                        <asp:Button runat="server" type="button" id="e12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E12_Click"/>
                        <asp:Button runat="server" type="button" id="f12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F12_Click"/>
                        <asp:Button runat="server" type="button" id="g12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G12_Click"/>
                        <asp:Button runat="server" type="button" id="h12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H12_Click"/>
                        <asp:Button runat="server" type="button" id="i12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I12_Click"/>
                        <asp:Button runat="server" type="button" id="j12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J12_Click"/>
                        <asp:Button runat="server" type="button" id="k12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K12_Click"/>
                        <asp:Button runat="server" type="button" id="l12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L12_Click"/>
                        <asp:Button runat="server" type="button" id="m12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M12_Click"/>
                        <asp:Button runat="server" type="button" id="n12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N12_Click"/>
                        <asp:Button runat="server" type="button" id="o12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O12_Click"/>
                        <asp:Button runat="server" type="button" id="p12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P12_Click"/>
                        <asp:Button runat="server" type="button" id="q12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q12_Click"/>
                        <asp:Button runat="server" type="button" id="r12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R12_Click"/>
                        <asp:Button runat="server" type="button" id="s12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S12_Click"/>
                        <asp:Button runat="server" type="button" id="t12" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T12_Click"/>
                         <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink12" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                     <asp:Panel runat="server" ID="fila13" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="ftrece" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;13</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A13_Click"/>
                        <asp:Button runat="server" type="button" id="b13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B13_Click"/>
                        <asp:Button runat="server" type="button" id="c13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C13_Click"/>
                        <asp:Button runat="server" type="button" id="d13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D13_Click"/>
                        <asp:Button runat="server" type="button" id="e13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E13_Click"/>
                        <asp:Button runat="server" type="button" id="f13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F13_Click"/>
                        <asp:Button runat="server" type="button" id="g13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G13_Click"/>
                        <asp:Button runat="server" type="button" id="h13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H13_Click"/>
                        <asp:Button runat="server" type="button" id="i13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I13_Click"/>
                        <asp:Button runat="server" type="button" id="j13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J13_Click"/>
                        <asp:Button runat="server" type="button" id="k13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K13_Click"/>
                        <asp:Button runat="server" type="button" id="l13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L13_Click"/>
                        <asp:Button runat="server" type="button" id="m13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M13_Click"/>
                        <asp:Button runat="server" type="button" id="n13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N13_Click"/>
                        <asp:Button runat="server" type="button" id="o13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O13_Click"/>
                        <asp:Button runat="server" type="button" id="p13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P13_Click"/>
                        <asp:Button runat="server" type="button" id="q13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q13_Click"/>
                        <asp:Button runat="server" type="button" id="r13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R13_Click"/>
                        <asp:Button runat="server" type="button" id="s13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S13_Click"/>
                        <asp:Button runat="server" type="button" id="t13" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T13_Click"/>
                         <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink13" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="fila14" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="fcatorce" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;14</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A14_Click"/>
                        <asp:Button runat="server" type="button" id="b14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B14_Click"/>
                        <asp:Button runat="server" type="button" id="c14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C14_Click"/>
                        <asp:Button runat="server" type="button" id="d14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D14_Click"/>
                        <asp:Button runat="server" type="button" id="e14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E14_Click"/>
                        <asp:Button runat="server" type="button" id="f14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F14_Click"/>
                        <asp:Button runat="server" type="button" id="g14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G14_Click"/>
                        <asp:Button runat="server" type="button" id="h14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H14_Click"/>
                        <asp:Button runat="server" type="button" id="i14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I14_Click"/>
                        <asp:Button runat="server" type="button" id="j14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J14_Click"/>
                        <asp:Button runat="server" type="button" id="k14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K14_Click"/>
                        <asp:Button runat="server" type="button" id="l14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L14_Click"/>
                        <asp:Button runat="server" type="button" id="m14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M14_Click"/>
                        <asp:Button runat="server" type="button" id="n14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N14_Click"/>
                        <asp:Button runat="server" type="button" id="o14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O14_Click"/>
                        <asp:Button runat="server" type="button" id="p14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P14_Click"/>
                        <asp:Button runat="server" type="button" id="q14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q14_Click"/>
                        <asp:Button runat="server" type="button" id="r14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R14_Click"/>
                        <asp:Button runat="server" type="button" id="s14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S14_Click"/>
                        <asp:Button runat="server" type="button" id="t14" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T14_Click"/>
                        <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink14" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                     <asp:Panel runat="server" ID="fila15" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="fquince" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;15</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A15_Click"/>
                        <asp:Button runat="server" type="button" id="b15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B15_Click"/>
                        <asp:Button runat="server" type="button" id="c15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C15_Click"/>
                        <asp:Button runat="server" type="button" id="d15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D15_Click"/>
                        <asp:Button runat="server" type="button" id="e15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E15_Click"/>
                        <asp:Button runat="server" type="button" id="f15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F15_Click"/>
                        <asp:Button runat="server" type="button" id="g15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G15_Click"/>
                        <asp:Button runat="server" type="button" id="h15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H15_Click"/>
                        <asp:Button runat="server" type="button" id="i15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I15_Click"/>
                        <asp:Button runat="server" type="button" id="j15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J15_Click"/>
                        <asp:Button runat="server" type="button" id="k15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K15_Click"/>
                        <asp:Button runat="server" type="button" id="l15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L15_Click"/>
                        <asp:Button runat="server" type="button" id="m15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M15_Click"/>
                        <asp:Button runat="server" type="button" id="n15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N15_Click"/>
                        <asp:Button runat="server" type="button" id="o15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O15_Click"/>
                        <asp:Button runat="server" type="button" id="p15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P15_Click"/>
                        <asp:Button runat="server" type="button" id="q15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q15_Click"/>
                        <asp:Button runat="server" type="button" id="r15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R15_Click"/>
                        <asp:Button runat="server" type="button" id="s15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S15_Click"/>
                        <asp:Button runat="server" type="button" id="t15" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T15_Click"/>
                         <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink15" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                     <asp:Panel runat="server" ID="fila16" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="fdsies" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;16</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A16_Click"/>
                        <asp:Button runat="server" type="button" id="b16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B16_Click"/>
                        <asp:Button runat="server" type="button" id="c16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C16_Click"/>
                        <asp:Button runat="server" type="button" id="d16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D16_Click"/>
                        <asp:Button runat="server" type="button" id="e16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E16_Click"/>
                        <asp:Button runat="server" type="button" id="f16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F16_Click"/>
                        <asp:Button runat="server" type="button" id="g16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G16_Click"/>
                        <asp:Button runat="server" type="button" id="h16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H16_Click"/>
                        <asp:Button runat="server" type="button" id="i16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I16_Click"/>
                        <asp:Button runat="server" type="button" id="j16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J16_Click"/>
                        <asp:Button runat="server" type="button" id="k16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K16_Click"/>
                        <asp:Button runat="server" type="button" id="l16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L16_Click"/>
                        <asp:Button runat="server" type="button" id="m16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M16_Click"/>
                        <asp:Button runat="server" type="button" id="n16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N16_Click"/>
                        <asp:Button runat="server" type="button" id="o16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O16_Click"/>
                        <asp:Button runat="server" type="button" id="p16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P16_Click"/>
                        <asp:Button runat="server" type="button" id="q16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q16_Click"/>
                        <asp:Button runat="server" type="button" id="r16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R16_Click"/>
                        <asp:Button runat="server" type="button" id="s16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S16_Click"/>
                        <asp:Button runat="server" type="button" id="t16" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T16_Click"/>
                         <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink16" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                     <asp:Panel runat="server" ID="fila17" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="fdsiete" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;17</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A17_Click"/>
                        <asp:Button runat="server" type="button" id="b17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B17_Click"/>
                        <asp:Button runat="server" type="button" id="c17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C17_Click"/>
                        <asp:Button runat="server" type="button" id="d17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D17_Click"/>
                        <asp:Button runat="server" type="button" id="e17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E17_Click"/>
                        <asp:Button runat="server" type="button" id="f17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F17_Click"/>
                        <asp:Button runat="server" type="button" id="g17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G17_Click"/>
                        <asp:Button runat="server" type="button" id="h17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H17_Click"/>
                        <asp:Button runat="server" type="button" id="i17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I17_Click"/>
                        <asp:Button runat="server" type="button" id="j17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J17_Click"/>
                        <asp:Button runat="server" type="button" id="k17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K17_Click"/>
                        <asp:Button runat="server" type="button" id="l17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L17_Click"/>
                        <asp:Button runat="server" type="button" id="m17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M17_Click"/>
                        <asp:Button runat="server" type="button" id="n17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N17_Click"/>
                        <asp:Button runat="server" type="button" id="o17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O17_Click"/>
                        <asp:Button runat="server" type="button" id="p17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P17_Click"/>
                        <asp:Button runat="server" type="button" id="q17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q17_Click"/>
                        <asp:Button runat="server" type="button" id="r17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R17_Click"/>
                        <asp:Button runat="server" type="button" id="s17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S17_Click"/>
                        <asp:Button runat="server" type="button" id="t17" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T17_Click"/>
                         <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink17" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                     <asp:Panel runat="server" ID="fila18" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="fdocho" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;18</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A18_Click"/>
                        <asp:Button runat="server" type="button" id="b18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B18_Click"/>
                        <asp:Button runat="server" type="button" id="c18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C18_Click"/>
                        <asp:Button runat="server" type="button" id="d18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D18_Click"/>
                        <asp:Button runat="server" type="button" id="e18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E18_Click"/>
                        <asp:Button runat="server" type="button" id="f18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F18_Click"/>
                        <asp:Button runat="server" type="button" id="g18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G18_Click"/>
                        <asp:Button runat="server" type="button" id="h18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H18_Click"/>
                        <asp:Button runat="server" type="button" id="i18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I18_Click"/>
                        <asp:Button runat="server" type="button" id="j18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J18_Click"/>
                        <asp:Button runat="server" type="button" id="k18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K18_Click"/>
                        <asp:Button runat="server" type="button" id="l18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L18_Click"/>
                        <asp:Button runat="server" type="button" id="m18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M18_Click"/>
                        <asp:Button runat="server" type="button" id="n18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N18_Click"/>
                        <asp:Button runat="server" type="button" id="o18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O18_Click"/>
                        <asp:Button runat="server" type="button" id="p18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P18_Click"/>
                        <asp:Button runat="server" type="button" id="q18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q18_Click"/>
                        <asp:Button runat="server" type="button" id="r18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R18_Click"/>
                        <asp:Button runat="server" type="button" id="s18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S18_Click"/>
                        <asp:Button runat="server" type="button" id="t18" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T18_Click"/>
                         <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink18" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                     <asp:Panel runat="server" ID="fila19" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="fdnueve" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;19</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A19_Click"/>
                        <asp:Button runat="server" type="button" id="b19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B19_Click"/>
                        <asp:Button runat="server" type="button" id="c19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C19_Click"/>
                        <asp:Button runat="server" type="button" id="d19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D19_Click"/>
                        <asp:Button runat="server" type="button" id="e19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E19_Click"/>
                        <asp:Button runat="server" type="button" id="f19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F19_Click"/>
                        <asp:Button runat="server" type="button" id="g19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G19_Click"/>
                        <asp:Button runat="server" type="button" id="h19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H19_Click"/>
                        <asp:Button runat="server" type="button" id="i19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I19_Click"/>
                        <asp:Button runat="server" type="button" id="j19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J19_Click"/>
                        <asp:Button runat="server" type="button" id="k19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K19_Click"/>
                        <asp:Button runat="server" type="button" id="l19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L19_Click"/>
                        <asp:Button runat="server" type="button" id="m19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M19_Click"/>
                        <asp:Button runat="server" type="button" id="n19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N19_Click"/>
                        <asp:Button runat="server" type="button" id="o19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O19_Click"/>
                        <asp:Button runat="server" type="button" id="p19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P19_Click"/>
                        <asp:Button runat="server" type="button" id="q19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q19_Click"/>
                        <asp:Button runat="server" type="button" id="r19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R19_Click"/>
                        <asp:Button runat="server" type="button" id="s19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S19_Click"/>
                        <asp:Button runat="server" type="button" id="t19" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T19_Click"/>
                         <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink19" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                     <asp:Panel runat="server" ID="fila20" class="btn-group">
                        <asp:HyperLink runat="server" href="#" Visible="false" ID="fveinte" CssClass="numero btn btn-lg disabled text-left">&nbsp;&nbsp;20</asp:HyperLink>
                        <asp:Button runat="server" type="button" id="a20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="A20_Click"/>
                        <asp:Button runat="server" type="button" id="b20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="B20_Click"/>
                        <asp:Button runat="server" type="button" id="c20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="C20_Click"/>
                        <asp:Button runat="server" type="button" id="d20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="D20_Click"/>
                        <asp:Button runat="server" type="button" id="e20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="E20_Click"/>
                        <asp:Button runat="server" type="button" id="f20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="F20_Click"/>
                        <asp:Button runat="server" type="button" id="g20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="G20_Click"/>
                        <asp:Button runat="server" type="button" id="h20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="H20_Click"/>
                        <asp:Button runat="server" type="button" id="i20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="I20_Click"/>
                        <asp:Button runat="server" type="button" id="j20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="J20_Click"/>
                        <asp:Button runat="server" type="button" id="k20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="K20_Click"/>
                        <asp:Button runat="server" type="button" id="l20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="L20_Click"/>
                        <asp:Button runat="server" type="button" id="m20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="M20_Click"/>
                        <asp:Button runat="server" type="button" id="n20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="N20_Click"/>
                        <asp:Button runat="server" type="button" id="o20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="O20_Click"/>
                        <asp:Button runat="server" type="button" id="p20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="P20_Click"/>
                        <asp:Button runat="server" type="button" id="q20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="Q20_Click"/>
                        <asp:Button runat="server" type="button" id="r20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="R20_Click"/>
                        <asp:Button runat="server" type="button" id="s20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="S20_Click"/>
                        <asp:Button runat="server" type="button" id="t20" Visible="false" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="T20_Click"/>
                         <asp:HyperLink runat="server" href="#" Visible="true" ID="HyperLink20" CssClass="none btn btn-lg disabled text-left"></asp:HyperLink>
                    </asp:Panel>

                        <br /><br /><br />
                    </div>
                </asp:Panel>
                
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