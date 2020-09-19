<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OthelloLoaded.aspx.cs" Inherits="Othello.OthelloLoaded" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
<title>Othello game</title>
  
  <style>body{background-color: #2e86c1;} #guardar{margin-top: 260px;}#iniciar{margin-left: 520px; margin-bottom: 30px; width:115px;}</style>
  </head>
  <body>
      <form id="tablero" runat="server">
    <div class="container">
        <h1 class="display-1 text-center my-3 text-white">OTHELLO GAME</h1>
        <br>
    </div>
        <div class="container">
            <asp:Button runat="server" id="iniciar" CssClass="text-center btn btn-warning btn-lg" Text="INICIAR" OnClick="Leer_xml"/>
            <div class="row mb-5">
                <div class="col-sm-12 col-lg-2 text-right border-left border-dark">
                    <h3>Turno de:</h3><hr>
                    <asp:Label runat="server" id="turno" CssClass="display-4" text="Negro" />
                    <%--<a href="#" id="turno" class="letra btn btn-lg disabled">Blanco</a>--%>
                    <asp:Button runat="server" type="button" id="guardar" CssClass="btn btn-outline-dark btn-lg" text="Guardar partida" OnClick="generarXml"/>
                </div>
                <asp:Panel runat="server" id="resultados" Cssclass="col-sm-12 col-lg-8 text-center" Visible="false">
                    <asp:Label runat="server" id="ganador" CssClass="display-2"/>
                </asp:Panel>
                <asp:Panel runat="server" id="gameBoard" Cssclass="col-sm-12 col-lg-8 text-center">
                    <%--<form id="tablero" runat="server">--%>
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
                        <asp:Button runat="server" type="button" id="a1" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="a1_Click"/>
                        <asp:Button runat="server" type="button" id="b1" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="b1_Click"/>
                        <asp:Button runat="server" type="button" id="c1" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="c1_Click"/>
                        <asp:Button runat="server" type="button" id="d1" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="d1_Click"/>
                        <asp:Button runat="server" type="button" id="e1" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="e1_Click"/>
                        <asp:Button runat="server" type="button" id="f1" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="f1_Click"/>
                        <asp:Button runat="server" type="button" id="g1" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="g1_Click"/>
                        <asp:Button runat="server" type="button" id="h1" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="h1_Click"/>
                    </div>
                    <div class="btn-group">
                        <a href="#" class="numero btn btn-lg disabled text-left">2</a>
                        <asp:Button runat="server" type="button" id="a2" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="a2_Click"/>
                        <asp:Button runat="server" type="button" id="b2" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="b2_Click"/>
                        <asp:Button runat="server" type="button" id="c2" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="c2_Click"/>
                        <asp:Button runat="server" type="button" id="d2" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="d2_Click"/>
                        <asp:Button runat="server" type="button" id="e2" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="e2_Click"/>
                        <asp:Button runat="server" type="button" id="f2" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="f2_Click"/>
                        <asp:Button runat="server" type="button" id="g2" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="g2_Click"/>
                        <asp:Button runat="server" type="button" id="h2" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="h2_Click"/>
                    </div>
                    <div class="btn-group">
                        <a href="#" class="numero btn btn-lg disabled text-left">3</a>
                        <asp:Button runat="server" type="button" id="a3" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="a3_Click"/>
                        <asp:Button runat="server" type="button" id="b3" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="b3_Click"/>
                        <asp:Button runat="server" type="button" id="c3" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="c3_Click"/>
                        <asp:Button runat="server" type="button" id="d3" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="d3_Click"/>
                        <asp:Button runat="server" type="button" id="e3" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="e3_Click"/>
                        <asp:Button runat="server" type="button" id="f3" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="f3_Click"/>
                        <asp:Button runat="server" type="button" id="g3" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="g3_Click"/>
                        <asp:Button runat="server" type="button" id="h3" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="h3_Click"/>
                    </div>
                    <div class="btn-group">
                        <a href="#" class="numero btn btn-lg disabled text-left">4</a>
                        <asp:Button runat="server" type="button" id="a4" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="a4_Click"/>
                        <asp:Button runat="server" type="button" id="b4" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="b4_Click"/>
                        <asp:Button runat="server" type="button" id="c4" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="c4_Click"/>
                        <asp:Button runat="server" type="button" id="d4" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="d4_Click"/>
                        <asp:Button runat="server" type="button" id="e4" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="e4_Click"/>
                        <asp:Button runat="server" type="button" id="f4" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="f4_Click"/>
                        <asp:Button runat="server" type="button" id="g4" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="g4_Click"/>
                        <asp:Button runat="server" type="button" id="h4" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="h4_Click"/>
                    </div>
                    <div class="btn-group">
                        <a href="#" class="numero btn btn-lg disabled text-left">5</a>
                        <asp:Button runat="server" type="button" id="a5" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="a5_Click"/>
                        <asp:Button runat="server" type="button" id="b5" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="b5_Click"/>
                        <asp:Button runat="server" type="button" id="c5" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="c5_Click"/>
                        <asp:Button runat="server" type="button" id="d5" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="d5_Click"/>
                        <asp:Button runat="server" type="button" id="e5" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="e5_Click"/>
                        <asp:Button runat="server" type="button" id="f5" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="f5_Click"/>
                        <asp:Button runat="server" type="button" id="g5" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="g5_Click"/>
                        <asp:Button runat="server" type="button" id="h5" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="h5_Click"/>
                    </div>
                    <div class="btn-group">
                        <a href="#" class="numero btn btn-lg disabled text-left">6</a>
                        <asp:Button runat="server" type="button" id="a6" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="a6_Click"/>
                        <asp:Button runat="server" type="button" id="b6" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="b6_Click"/>
                        <asp:Button runat="server" type="button" id="c6" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="c6_Click"/>
                        <asp:Button runat="server" type="button" id="d6" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="d6_Click"/>
                        <asp:Button runat="server" type="button" id="e6" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="e6_Click"/>
                        <asp:Button runat="server" type="button" id="f6" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="f6_Click"/>
                        <asp:Button runat="server" type="button" id="g6" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="g6_Click"/>
                        <asp:Button runat="server" type="button" id="h6" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="h6_Click"/>
                    </div>
                    <div class="btn-group">
                        <a href="#" class="numero btn btn-lg disabled text-left">7</a>
                        <asp:Button runat="server" type="button" id="a7" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="a7_Click"/>
                        <asp:Button runat="server" type="button" id="b7" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="b7_Click"/>
                        <asp:Button runat="server" type="button" id="c7" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="c7_Click"/>
                        <asp:Button runat="server" type="button" id="d7" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="d7_Click"/>
                        <asp:Button runat="server" type="button" id="e7" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="e7_Click"/>
                        <asp:Button runat="server" type="button" id="f7" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="f7_Click"/>
                        <asp:Button runat="server" type="button" id="g7" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="g7_Click"/>
                        <asp:Button runat="server" type="button" id="h7" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="h7_Click"/>
                    </div>
                    <div class="btn-group">
                        <a href="#" class="numero btn btn-lg disabled text-left">8</a>
                        <asp:Button runat="server" type="button" id="a8" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="a8_Click"/>
                        <asp:Button runat="server" type="button" id="b8" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="b8_Click"/>
                        <asp:Button runat="server" type="button" id="c8" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="c8_Click"/>
                        <asp:Button runat="server" type="button" id="d8" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="d8_Click"/>
                        <asp:Button runat="server" type="button" id="e8" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="e8_Click"/>
                        <asp:Button runat="server" type="button" id="f8" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="f8_Click"/>
                        <asp:Button runat="server" type="button" id="g8" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="g8_Click"/>
                        <asp:Button runat="server" type="button" id="h8" CssClass="btn btn-success btn-lg border-dark rounded-0" text="     " OnClick="h8_Click"/>
                    </div>
                   <%--</form>--%> 
                </asp:Panel>
                
                <div class="col-sm-12 col-lg-2 text-left border-right border-dark">
                    <h3>SCORE</h3><hr><br>
                    <h4 class="text-white">Blanco</h4>
                    <asp:Label runat="server" id="score1" CssClass="display-4 text-white" text="0" />
                    <br><br>
                    <h4>Negro</h4>
                    <asp:Label runat="server" id="score2" CssClass="display-4" text="0" />
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