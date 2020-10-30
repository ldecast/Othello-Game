<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OthelloTournament.aspx.cs" Inherits="Othello.OthelloTournament" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
<link rel="stylesheet" href="css\StyleSheet2.css" type="text/css">
<link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">

<title>Campeonato Othello</title>

    <%--<style> body{ background-image: url(https://png.pngtree.com/thumb_back/fw800/background/20190223/ourmid/pngtree-fresh-gold-trophy-advertising-background-backgroundfreshtrophyfestivechinese-stylegolden-lightribbonshining-image_73504.jpg); } .panel{ height: 600px; }</style>--%>
    <style>
        .panel{ height:400px; } .equipo{ font-size:50px; background-color: #c72b2b; padding: 4px 11px 6px 11px; border-radius: 5px; font-size: 25px; } .cuarto{ position:absolute; left:0px; margin-top:30px; margin-bottom:30px; }
        .partida { margin-left:115px; } .final { margin-left:380px; } .rowFinal{ height:300px; } .radio{ font-size:18px; height:175px; background-color:sienna; border-radius: 5px;} .equipo input[type="checkbox"] { margin-right: 10px; } input[type="radio"] {margin-right: 10px;}
    </style>
  </head>
  <body>
    <form id="menu" runat="server">
        <div class="container-fluid text-center mt-3 mb-4">
        <%--<asp:Label runat="server" id="Label1" CssClass="display-1 text-white titulo" Text=""/>--%>
        <asp:Label runat="server" id="titulo" CssClass="display-1 text-white font-weight-bold titulo" Text="Campeonato"/>
        <%--<asp:Label runat="server" id="Label2" CssClass="display-1 text-white titulo" Text="!"/>--%>
        </div>

        <input id="playersEmpates"  value=""  runat="server"/>
        <input id="auxGanados"  value=""  runat="server"/>
        <input id="equiposEmpates"  value=""  runat="server"/>
        <input id="auxCount"  value=""  runat="server"/>


    <asp:Panel runat="server" ID="octavosPanel" CssClass="container" Visible="false">
   <div class="row mt-3 py-4">
       <div class="col-12 mb-5 text-center"><asp:Label runat="server" id="Label5" CssClass="h1 text-center" Text="Octavos de final" /><br/></div>

            <div class="col-sm-12 col-md-6 col-lg-6 mb-2 border-right border-secondary text-center">
                <asp:Label runat="server" id="Label3" CssClass="h1 text-center" Text="Disputa" /><br/>
                    <asp:CheckBoxList ID="CheckBoxList1" CssClass="my-4 partida text-center" RepeatDirection="Horizontal" RepeatColumns="2" CellPadding="4" runat="server">
                        <asp:ListItem ID="octavo1" class="h6 equipo mr-3 " Value="equipo">&nbsp;Equipo 1</asp:ListItem>
                        <asp:ListItem ID="octavo2" class="h6 equipo" Value="equipo">&nbsp;Equipo 2</asp:ListItem>
                    </asp:CheckBoxList>
            </div>
            <div class="col-sm-12 col-md-6 col-lg-6 text-center mb-2">
                <asp:Label runat="server" id="Label4" CssClass="h1" Text="Disputa" /><br/>

                <asp:CheckBoxList ID="CheckBoxList2" CssClass="my-4 partida text-center" RepeatDirection="Horizontal" RepeatColumns="2" CellPadding="4" runat="server">
                        <asp:ListItem ID="octavo3" class="h6 equipo mr-3 " Value="equipo">&nbsp;Equipo 3</asp:ListItem>
                        <asp:ListItem ID="octavo4" class="h6 equipo" Value="equipo">&nbsp;Equipo 4</asp:ListItem>
                </asp:CheckBoxList>    
            </div>
    </div>

    <div class="row py-4">
            <div class="col-sm-12 col-md-6 col-lg-6 mb-2 border-right border-secondary text-center">
                <asp:Label runat="server" id="Label7" CssClass="h1 text-center" Text="Disputa" /><br/>
                    <asp:CheckBoxList ID="CheckBoxList3" CssClass="my-4 partida text-center" RepeatDirection="Horizontal" RepeatColumns="2" CellPadding="4" runat="server">
                        <asp:ListItem ID="octavo5" class="h6 equipo mr-3 " Value="equipo">&nbsp;Equipo 5</asp:ListItem>
                        <asp:ListItem ID="octavo6" class="h6 equipo" Value="equipo">&nbsp;Equipo 6</asp:ListItem>
                    </asp:CheckBoxList>
            </div>
            <div class="col-sm-12 col-md-6 col-lg-6 text-center mb-2">
                <asp:Label runat="server" id="Label8" CssClass="h1" Text="Disputa" /><br/>

                <asp:CheckBoxList ID="CheckBoxList4" CssClass="my-4 partida text-center" RepeatDirection="Horizontal" RepeatColumns="2" CellPadding="4" runat="server">
                        <asp:ListItem ID="octavo7" class="h6 equipo mr-3 " Value="equipo">&nbsp;Equipo 7</asp:ListItem>
                        <asp:ListItem ID="octavo8" class="h6 equipo" Value="equipo">&nbsp;Equipo 8</asp:ListItem>
                </asp:CheckBoxList>    
            </div>
    </div>

            <div class="row py-4">
            <div class="col-sm-12 col-md-6 col-lg-6 mb-2 border-right border-secondary text-center">
                <asp:Label runat="server" id="Label6" CssClass="h1 text-center" Text="Disputa" /><br/>
                    <asp:CheckBoxList ID="CheckBoxList5" CssClass="my-4 partida text-center" RepeatDirection="Horizontal" RepeatColumns="2" CellPadding="4" runat="server">
                        <asp:ListItem ID="octavo9" class="h6 equipo mr-3 " Value="equipo">&nbsp;Equipo 9</asp:ListItem>
                        <asp:ListItem ID="octavo10" class="h6 equipo" Value="equipo">&nbsp;Equipo 10</asp:ListItem>
                    </asp:CheckBoxList>
            </div>
            <div class="col-sm-12 col-md-6 col-lg-6 text-center mb-2">
                <asp:Label runat="server" id="Label9" CssClass="h1" Text="Disputa" /><br/>

                <asp:CheckBoxList ID="CheckBoxList6" CssClass="my-4 partida text-center" RepeatDirection="Horizontal" RepeatColumns="2" CellPadding="4" runat="server">
                        <asp:ListItem ID="octavo11" class="h6 equipo mr-3 " Value="equipo">&nbsp;Equipo 11</asp:ListItem>
                        <asp:ListItem ID="octavo12" class="h6 equipo" Value="equipo">&nbsp;Equipo 12</asp:ListItem>
                </asp:CheckBoxList>    
            </div>
    </div>

    <div class="row py-4">
            <div class="col-sm-12 col-md-6 col-lg-6 mb-2 border-right border-secondary text-center">
                <asp:Label runat="server" id="Label10" CssClass="h1 text-center" Text="Disputa" /><br/>
                    <asp:CheckBoxList ID="CheckBoxList7" CssClass="my-4 partida text-center" RepeatDirection="Horizontal" RepeatColumns="2" CellPadding="4" runat="server">
                        <asp:ListItem ID="octavo13" class="h6 equipo mr-3 " Value="equipo">&nbsp;Equipo 13</asp:ListItem>
                        <asp:ListItem ID="octavo14" class="h6 equipo" Value="equipo">&nbsp;Equipo 14</asp:ListItem>
                    </asp:CheckBoxList>
            </div>
            <div class="col-sm-12 col-md-6 col-lg-6 text-center mb-2">
                <asp:Label runat="server" id="Label11" CssClass="h1" Text="Disputa" /><br/>

                <asp:CheckBoxList ID="CheckBoxList8" CssClass="my-4 partida text-center" RepeatDirection="Horizontal" RepeatColumns="2" CellPadding="4" runat="server">
                        <asp:ListItem ID="octavo15" class="h6 equipo mr-3 " Value="equipo">&nbsp;Equipo 15</asp:ListItem>
                        <asp:ListItem ID="octavo16" class="h6 equipo" Value="equipo">&nbsp;Equipo 16</asp:ListItem>
                </asp:CheckBoxList>    
            </div>
    </div>

    <div class="row py-5">
            <div class="col-12 text-center">
                <asp:LinkButton runat="server" ID="btnOctavos" OnClick="Octavos_Click" CssClass="btn btn-primary btn-lg text-body"><i class="fa fa-check-circle" aria-hidden="true"></i>&nbsp;&nbsp;Avanzar!&nbsp;</asp:LinkButton><br /><br />
            </div>
    </div>
        
    </asp:Panel>



    <asp:Panel runat="server" ID="cuartosPanel" CssClass="container" Visible="false">
   <div class="row mt-3 py-4">
       <div class="col-12 mb-5 text-center"><asp:Label runat="server" id="Label15" CssClass="h1 text-center" Text="Cuartos de final" /><br/></div>

            <div class="col-sm-12 col-md-6 col-lg-6 mb-2 border-right border-secondary text-center">
                <asp:Label runat="server" id="Label16" CssClass="h1 text-center" Text="Disputa" /><br/>
                    <asp:CheckBoxList ID="CheckBoxList9" CssClass="my-4 partida text-center" RepeatDirection="Horizontal" RepeatColumns="2" CellPadding="4" runat="server">
                        <asp:ListItem ID="cuartos1" class="h6 equipo mr-3 " Value="equipo">&nbsp;Equipo 1</asp:ListItem>
                        <asp:ListItem ID="cuartos2" class="h6 equipo" Value="equipo">&nbsp;Equipo 2</asp:ListItem>
                    </asp:CheckBoxList>
            </div>
            <div class="col-sm-12 col-md-6 col-lg-6 text-center mb-2">
                <asp:Label runat="server" id="Label17" CssClass="h1" Text="Disputa" /><br/>

                <asp:CheckBoxList ID="CheckBoxList10" CssClass="my-4 partida text-center" RepeatDirection="Horizontal" RepeatColumns="2" CellPadding="4" runat="server">
                        <asp:ListItem ID="cuartos3" class="h6 equipo mr-3 " Value="equipo">&nbsp;Equipo 3</asp:ListItem>
                        <asp:ListItem ID="cuartos4" class="h6 equipo" Value="equipo">&nbsp;Equipo 4</asp:ListItem>
                </asp:CheckBoxList>    
            </div>
    </div>

    <div class="row py-4">
            <div class="col-sm-12 col-md-6 col-lg-6 mb-2 border-right border-secondary text-center">
                <asp:Label runat="server" id="Label18" CssClass="h1 text-center" Text="Disputa" /><br/>
                    <asp:CheckBoxList ID="CheckBoxList11" CssClass="my-4 partida text-center" RepeatDirection="Horizontal" RepeatColumns="2" CellPadding="4" runat="server">
                        <asp:ListItem ID="cuartos5" class="h6 equipo mr-3 " Value="equipo">&nbsp;Equipo 5</asp:ListItem>
                        <asp:ListItem ID="cuartos6" class="h6 equipo" Value="equipo">&nbsp;Equipo 6</asp:ListItem>
                    </asp:CheckBoxList>
            </div>
            <div class="col-sm-12 col-md-6 col-lg-6 text-center mb-2">
                <asp:Label runat="server" id="Label19" CssClass="h1" Text="Disputa" /><br/>

                <asp:CheckBoxList ID="CheckBoxList12" CssClass="my-4 partida text-center" RepeatDirection="Horizontal" RepeatColumns="2" CellPadding="4" runat="server">
                        <asp:ListItem ID="cuartos7" class="h6 equipo mr-3 " Value="equipo">&nbsp;Equipo 7</asp:ListItem>
                        <asp:ListItem ID="cuartos8" class="h6 equipo" Value="equipo">&nbsp;Equipo 8</asp:ListItem>
                </asp:CheckBoxList>    
            </div>
    </div>

    <div class="row py-5">
            <div class="col-12 text-center">
                <asp:LinkButton runat="server" ID="btnCuartos" OnClick="Cuartos_Click" CssClass="btn btn-primary btn-lg text-body"><i class="fa fa-check-circle" aria-hidden="true"></i>&nbsp;&nbsp;Avanzar!&nbsp;</asp:LinkButton><br /><br />
            </div>
    </div>
        
    </asp:Panel>






        <asp:Panel runat="server" ID="semiPanel" CssClass="container" Visible="false">
   <div class="row mt-3 py-4">
       <div class="col-12 mb-5 text-center"><asp:Label runat="server" id="Label12" CssClass="h1 text-center" Text="Semifinal" /><br/></div>

            <div class="col-sm-12 col-md-6 col-lg-6 mb-2 border-right border-secondary text-center">
                <asp:Label runat="server" id="Label13" CssClass="h1 text-center" Text="Disputa" /><br/>
                    <asp:CheckBoxList ID="CheckBoxList13" CssClass="my-4 partida text-center" RepeatDirection="Horizontal" RepeatColumns="2" CellPadding="4" runat="server">
                        <asp:ListItem ID="semi1" class="h6 equipo mr-3 " Value="equipo">&nbsp;Equipo 1</asp:ListItem>
                        <asp:ListItem ID="semi2" class="h6 equipo" Value="equipo">&nbsp;Equipo 2</asp:ListItem>
                    </asp:CheckBoxList>
            </div>
            <div class="col-sm-12 col-md-6 col-lg-6 text-center mb-2">
                <asp:Label runat="server" id="Label14" CssClass="h1" Text="Disputa" /><br/>

                <asp:CheckBoxList ID="CheckBoxList14" CssClass="my-4 partida text-center" RepeatDirection="Horizontal" RepeatColumns="2" CellPadding="4" runat="server">
                        <asp:ListItem ID="semi3" class="h6 equipo mr-3 " Value="equipo">&nbsp;Equipo 3</asp:ListItem>
                        <asp:ListItem ID="semi4" class="h6 equipo" Value="equipo">&nbsp;Equipo 4</asp:ListItem>
                </asp:CheckBoxList>    
            </div>
    </div>

    <div class="row py-5">
            <div class="col-12 text-center">
                <asp:LinkButton runat="server" ID="btnSemi" OnClick="Semi_Click" CssClass="btn btn-primary btn-lg text-body"><i class="fa fa-check-circle" aria-hidden="true"></i>&nbsp;&nbsp;Avanzar!&nbsp;</asp:LinkButton><br /><br />
            </div>
    </div>
        
    </asp:Panel>




        <asp:Panel runat="server" ID="finalPanel" CssClass="container" Visible="false">
   <div class="row mt-3 py-4 rowFinal">
       <div class="col-12 mb-5 text-center"><asp:Label runat="server" id="Label20" CssClass="h1 text-center" Text="FINAL" /><hr /></div>

            <div class="col-sm-12 col-md-6 col-lg-12 mb-2 text-center">
                    <asp:CheckBoxList ID="CheckBoxList15" CssClass="my-4 final text-center" RepeatDirection="Horizontal" RepeatColumns="2" CellPadding="4" runat="server">
                        <asp:ListItem ID="final1" class="h6 equipo mr-5 " Value="equipo">&nbsp;Equipo 1</asp:ListItem>
                        <asp:ListItem ID="final2" class="h6 equipo" Value="equipo">&nbsp;Equipo 2</asp:ListItem>
                    </asp:CheckBoxList>
            </div>
            
    </div>

    <div class="row py-5">
            <div class="col-12 text-center">
                <asp:LinkButton runat="server" ID="btnFinal" OnClick="Final_Click" CssClass="btn btn-primary btn-lg text-body"><i class="fa fa-check-circle" aria-hidden="true"></i>&nbsp;&nbsp;Premiar!&nbsp;</asp:LinkButton><br /><br />
            </div>
    </div>
    </asp:Panel>


    <asp:Panel runat="server" ID="winnerPanel" CssClass="container" Visible="false">
    <div class="row mt-3 py-4 resultado">
        <div class="col-12 mb-4 text-center"><asp:Label runat="server" id="Label22" CssClass="h1 text-center" Text="GAME OVER" /><hr /></div>
        <div class="col-sm-12 col-md-6 col-lg-12 my-2 text-center">
            <asp:Label runat="server" CssClass="display-1"  Text="Guatemala" id="ganador" Visible="true"/><br />
            <asp:Label runat="server" CssClass="display-4" id="info" Text="gana el campeonato" Visible="true"/><br />
        </div>
    </div>
    <div class="row py-5">
        <div class="col-12 text-center">
            <asp:LinkButton runat="server" ID="exit" OnClick="Salir" CssClass="btn btn-warning btn-lg"><i class="fa fa-arrow-circle-left" aria-hidden="true"></i>&nbsp;&nbsp;Salir&nbsp;</asp:LinkButton><br /><br />
        </div>
    </div>
    </asp:Panel>



    <asp:Panel runat="server" ID="desempatePanel" CssClass="container" Visible="false">
    <div class="row mt-3 mx-5 py-4 rowFinal">
    <div class="col-12 mb-4 text-center"><asp:Label runat="server" id="LabelDesempate" CssClass="h1 text-center" Text="Desempate" /><hr /></div>
       <div class="col-3"></div>
            <asp:RadioButtonList CssClass="col-sm-12 col-md-6 mt-3 col-lg-6 text-center radio" ToolTip="Seleccion un jugador para definir qué equipo avanza" CellPadding="4" RepeatColumns="2" ID="RadioButtonList1" runat="server">
                    <asp:ListItem ID="empateJ1" runat="server" Text="&nbsp;Jugador 1"/>
                    <asp:ListItem ID="empateJ2" runat="server" Text="&nbsp;Jugador 2"/>
                    <asp:ListItem ID="empateJ3" runat="server" Text="&nbsp;Jugador 3"/>
                    <asp:ListItem ID="empateJ4" runat="server" Text="&nbsp;Jugador 4"/>
                    <asp:ListItem ID="empateJ5" runat="server" Text="&nbsp;Jugador 5"/>
                    <asp:ListItem ID="empateJ6" runat="server" Text="&nbsp;Jugador 6"/>
           </asp:RadioButtonList>
       <div class="col-3"></div>
    </div>
    <div class="row mx-5 py-5">
            <div class="col-12 mt-2 text-center">
                <asp:LinkButton runat="server" ID="btnDesempate" OnClick="Desempate_Click" CssClass="btn btn-primary btn-lg text-body mt-4"><i class="fa fa-check-circle" aria-hidden="true"></i>&nbsp;&nbsp;Avanzar!&nbsp;</asp:LinkButton>
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