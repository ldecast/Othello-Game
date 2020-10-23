using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Text;
using System.Diagnostics.Eventing.Reader;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Data.SqlClient;

namespace Othello
{
    public partial class GameBoard : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ClientScript.RegisterStartupScript(GetType(), "hwa", "reloj1()", true);
            
            Get_Score(null);
            cronometro1.InnerText = estado1.Value;
            cronometro2.InnerText = estado2.Value;
        }

        private readonly string verde = "btn btn-success btn-lg border-dark rounded-0";
        private readonly string negro = "btn btn-dark btn-lg border-dark rounded-0";
        private readonly string blanco = "btn btn-light btn-lg border-dark rounded-0";
        private string move_negro = "";
        private string move_blanco = "";

        protected string Ver_ficha(int boton)
        {
            if (boton == 1)
            {
                if (a1.CssClass == blanco)
                    return "blanco";
                if (a1.CssClass == negro)
                    return "negro";
                else
                    return "vacio";
            }
            if (boton == 2)
            { if (b1.CssClass == blanco) return "blanco"; if (b1.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 3)
            { if (c1.CssClass == blanco) return "blanco"; if (c1.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 4)
            { if (d1.CssClass == blanco) return "blanco"; if (d1.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 5)
            { if (e1.CssClass == blanco) return "blanco"; if (e1.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 6)
            { if (f1.CssClass == blanco) return "blanco"; if (f1.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 7)
            { if (g1.CssClass == blanco) return "blanco"; if (g1.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 8)
            { if (h1.CssClass == blanco) return "blanco"; if (h1.CssClass == negro) return "negro"; else return "vacio"; }

            if (boton == 9)
            { if (a2.CssClass == blanco) return "blanco"; if (a2.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 10)
            { if (b2.CssClass == blanco) return "blanco"; if (b2.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 11)
            { if (c2.CssClass == blanco) return "blanco"; if (c2.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 12)
            { if (d2.CssClass == blanco) return "blanco"; if (d2.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 13)
            { if (e2.CssClass == blanco) return "blanco"; if (e2.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 14)
            { if (f2.CssClass == blanco) return "blanco"; if (f2.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 15)
            { if (g2.CssClass == blanco) return "blanco"; if (g2.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 16)
            { if (h2.CssClass == blanco) return "blanco"; if (h2.CssClass == negro) return "negro"; else return "vacio"; }

            if (boton == 17)
            { if (a3.CssClass == blanco) return "blanco"; if (a3.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 18)
            { if (b3.CssClass == blanco) return "blanco"; if (b3.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 19)
            { if (c3.CssClass == blanco) return "blanco"; if (c3.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 20)
            { if (d3.CssClass == blanco) return "blanco"; if (d3.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 21)
            { if (e3.CssClass == blanco) return "blanco"; if (e3.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 22)
            { if (f3.CssClass == blanco) return "blanco"; if (f3.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 23)
            { if (g3.CssClass == blanco) return "blanco"; if (g3.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 24)
            { if (h3.CssClass == blanco) return "blanco"; if (h3.CssClass == negro) return "negro"; else return "vacio"; }

            if (boton == 25)
            { if (a4.CssClass == blanco) return "blanco"; if (a4.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 26)
            { if (b4.CssClass == blanco) return "blanco"; if (b4.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 27)
            { if (c4.CssClass == blanco) return "blanco"; if (c4.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 28)
            { if (d4.CssClass == blanco) return "blanco"; if (d4.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 29)
            { if (e4.CssClass == blanco) return "blanco"; if (e4.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 30)
            { if (f4.CssClass == blanco) return "blanco"; if (f4.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 31)
            { if (g4.CssClass == blanco) return "blanco"; if (g4.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 32)
            { if (h4.CssClass == blanco) return "blanco"; if (h4.CssClass == negro) return "negro"; else return "vacio"; }

            if (boton == 33)
            { if (a5.CssClass == blanco) return "blanco"; if (a5.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 34)
            { if (b5.CssClass == blanco) return "blanco"; if (b5.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 35)
            { if (c5.CssClass == blanco) return "blanco"; if (c5.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 36)
            { if (d5.CssClass == blanco) return "blanco"; if (d5.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 37)
            { if (e5.CssClass == blanco) return "blanco"; if (e5.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 38)
            { if (f5.CssClass == blanco) return "blanco"; if (f5.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 39)
            { if (g5.CssClass == blanco) return "blanco"; if (g5.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 40)
            { if (h5.CssClass == blanco) return "blanco"; if (h5.CssClass == negro) return "negro"; else return "vacio"; }

            if (boton == 41)
            { if (a6.CssClass == blanco) return "blanco"; if (a6.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 42)
            { if (b6.CssClass == blanco) return "blanco"; if (b6.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 43)
            { if (c6.CssClass == blanco) return "blanco"; if (c6.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 44)
            { if (d6.CssClass == blanco) return "blanco"; if (d6.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 45)
            { if (e6.CssClass == blanco) return "blanco"; if (e6.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 46)
            { if (f6.CssClass == blanco) return "blanco"; if (f6.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 47)
            { if (g6.CssClass == blanco) return "blanco"; if (g6.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 48)
            { if (h6.CssClass == blanco) return "blanco"; if (h6.CssClass == negro) return "negro"; else return "vacio"; }

            if (boton == 49)
            { if (a7.CssClass == blanco) return "blanco"; if (a7.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 50)
            { if (b7.CssClass == blanco) return "blanco"; if (b7.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 51)
            { if (c7.CssClass == blanco) return "blanco"; if (c7.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 52)
            { if (d7.CssClass == blanco) return "blanco"; if (d7.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 53)
            { if (e7.CssClass == blanco) return "blanco"; if (e7.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 54)
            { if (f7.CssClass == blanco) return "blanco"; if (f7.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 55)
            { if (g7.CssClass == blanco) return "blanco"; if (g7.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 56)
            { if (h7.CssClass == blanco) return "blanco"; if (h7.CssClass == negro) return "negro"; else return "vacio"; }

            if (boton == 57)
            { if (a8.CssClass == blanco) return "blanco"; if (a8.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 58)
            { if (b8.CssClass == blanco) return "blanco"; if (b8.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 59)
            { if (c8.CssClass == blanco) return "blanco"; if (c8.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 60)
            { if (d8.CssClass == blanco) return "blanco"; if (d8.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 61)
            { if (e8.CssClass == blanco) return "blanco"; if (e8.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 62)
            { if (f8.CssClass == blanco) return "blanco"; if (f8.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 63)
            { if (g8.CssClass == blanco) return "blanco"; if (g8.CssClass == negro) return "negro"; else return "vacio"; }
            if (boton == 64)
            { if (h8.CssClass == blanco) return "blanco"; if (h8.CssClass == negro) return "negro"; else return "vacio"; }
            else return "error";
        }

        protected void GenerarXml(object sender, EventArgs e)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t"
            };

            string[] col = { "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H" };
            string[] fila = { "1", "1", "1", "1", "1", "1", "1", "1", "2", "2", "2", "2", "2", "2", "2", "2", "3", "3", "3", "3", "3", "3", "3", "3", "4", "4", "4", "4", "4", "4", "4", "4", "5", "5", "5", "5", "5", "5", "5", "5", "6", "6", "6", "6", "6", "6", "6", "6", "7", "7", "7", "7", "7", "7", "7", "7", "8", "8", "8", "8", "8", "8", "8", "8" };

            string persona = "";
            if (Request.Params["Parametro"] != null)
            {
                persona = Request.Params["Parametro"] + " ";
            }

            string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";
            int id = 1;
            string ruta = mdoc + "Partida 1vs1 " + persona + "(" + id + ").xml";

            while (File.Exists(ruta))
            {
                id++;
                ruta = mdoc + "Partida 1vs1 " + persona + "(" + id + ").xml";
            }

            XmlWriter xmlWriter = XmlWriter.Create(ruta, settings);

            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("tablero");

            for (int i = 0; i < 64; i++)
            {
                string color = Ver_ficha(i + 1);
                if (color == "blanco")
                {
                    xmlWriter.WriteStartElement("ficha");

                    xmlWriter.WriteStartElement("color");
                    xmlWriter.WriteString(color);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("columna");
                    xmlWriter.WriteString(col[i]);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("fila");
                    xmlWriter.WriteString(fila[i]);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();
                }
                if (color == "negro")
                {
                    xmlWriter.WriteStartElement("ficha");

                    xmlWriter.WriteStartElement("color");
                    xmlWriter.WriteString(color);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("columna");
                    xmlWriter.WriteString(col[i]);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("fila");
                    xmlWriter.WriteString(fila[i]);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();
                }
                else
                    continue;
            }

            xmlWriter.WriteStartElement("siguienteTiro");
            xmlWriter.WriteStartElement("color");
            if (turno.Text == "Blanco")
                xmlWriter.WriteString("blanco");
            else
                xmlWriter.WriteString("negro");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("movimientos");
            xmlWriter.WriteStartElement("negro");
            xmlWriter.WriteString(movimiento_negro.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("blanco");
            xmlWriter.WriteString(movimiento_blanco.Text);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            Response.Write("Partida guardada en: " + ruta);
        }

        public WebControl[] Tipo(string a)
        {
            WebControl[] fila1 = { a1, b1, c1, d1, e1, f1, g1, h1 };
            WebControl[] fila2 = { a2, b2, c2, d2, e2, f2, g2, h2 };
            WebControl[] fila3 = { a3, b3, c3, d3, e3, f3, g3, h3 };
            WebControl[] fila4 = { a4, b4, c4, d4, e4, f4, g4, h4 };
            WebControl[] fila5 = { a5, b5, c5, d5, e5, f5, g5, h5 };
            WebControl[] fila6 = { a6, b6, c6, d6, e6, f6, g6, h6 };
            WebControl[] fila7 = { a7, b7, c7, d7, e7, f7, g7, h7 };
            WebControl[] fila8 = { a8, b8, c8, d8, e8, f8, g8, h8 };

            WebControl[] colA = { a1, a2, a3, a4, a5, a6, a7, a8 };
            WebControl[] colB = { b1, b2, b3, b4, b5, b6, b7, b8 };
            WebControl[] colC = { c1, c2, c3, c4, c5, c6, c7, c8 };
            WebControl[] colD = { d1, d2, d3, d4, d5, d6, d7, d8 };
            WebControl[] colE = { e1, e2, e3, e4, e5, e6, e7, e8 };
            WebControl[] colF = { f1, f2, f3, f4, f5, f6, f7, f8 };
            WebControl[] colG = { g1, g2, g3, g4, g5, g6, g7, g8 };
            WebControl[] colH = { h1, h2, h3, h4, h5, h6, h7, h8 };

            WebControl[] diagPositiva1 = { a1 };
            WebControl[] diagPositiva2 = { a2, b1 };
            WebControl[] diagPositiva3 = { a3, b2, c1 };
            WebControl[] diagPositiva4 = { a4, b3, c2, d1 };
            WebControl[] diagPositiva5 = { a5, b4, c3, d2, e1 };
            WebControl[] diagPositiva6 = { a6, b5, c4, d3, e2, f1 };
            WebControl[] diagPositiva7 = { a7, b6, c5, d4, e3, f2, g1 };
            WebControl[] diagPositiva8 = { a8, b7, c6, d5, e4, f3, g2, h1 };
            WebControl[] diagPositiva9 = { b8, c7, d6, e5, f4, g3, h2 };
            WebControl[] diagPositiva10 = { c8, d7, e6, f5, g4, h3 };
            WebControl[] diagPositiva11 = { d8, e7, f6, g5, h4 };
            WebControl[] diagPositiva12 = { e8, f7, g6, h5 };
            WebControl[] diagPositiva13 = { f8, g7, h6 };
            WebControl[] diagPositiva14 = { g8, h7 };
            WebControl[] diagPositiva15 = { h8 };

            WebControl[] diagNegativa1 = { h1 };
            WebControl[] diagNegativa2 = { g1, h2 };
            WebControl[] diagNegativa3 = { f1, g2, h3 };
            WebControl[] diagNegativa4 = { e1, f2, g3, h4 };
            WebControl[] diagNegativa5 = { d1, e2, f3, g4, h5 };
            WebControl[] diagNegativa6 = { c1, d2, e3, f4, g5, h6 };
            WebControl[] diagNegativa7 = { b1, c2, d3, e4, f5, g6, h7 };
            WebControl[] diagNegativa8 = { a1, b2, c3, d4, e5, f6, g7, h8 };
            WebControl[] diagNegativa9 = { a2, b3, c4, d5, e6, f7, g8 };
            WebControl[] diagNegativa10 = { a3, b4, c5, d6, e7, f8 };
            WebControl[] diagNegativa11 = { a4, b5, c6, d7, e8 };
            WebControl[] diagNegativa12 = { a5, b6, c7, d8 };
            WebControl[] diagNegativa13 = { a6, b7, c8 };
            WebControl[] diagNegativa14 = { a7, b8 };
            WebControl[] diagNegativa15 = { a8 };

            if (a == "fila1") return fila1;
            if (a == "fila2") return fila2;
            if (a == "fila3") return fila3;
            if (a == "fila4") return fila4;
            if (a == "fila5") return fila5;
            if (a == "fila6") return fila6;
            if (a == "fila7") return fila7;
            if (a == "fila8") return fila8;

            if (a == "colA") return colA;
            if (a == "colB") return colB;
            if (a == "colC") return colC;
            if (a == "colD") return colD;
            if (a == "colE") return colE;
            if (a == "colF") return colF;
            if (a == "colG") return colG;
            if (a == "colH") return colH;

            if (a == "diagPos1") return diagPositiva1;
            if (a == "diagPos2") return diagPositiva2;
            if (a == "diagPos3") return diagPositiva3;
            if (a == "diagPos4") return diagPositiva4;
            if (a == "diagPos5") return diagPositiva5;
            if (a == "diagPos6") return diagPositiva6;
            if (a == "diagPos7") return diagPositiva7;
            if (a == "diagPos8") return diagPositiva8;
            if (a == "diagPos9") return diagPositiva9;
            if (a == "diagPos10") return diagPositiva10;
            if (a == "diagPos11") return diagPositiva11;
            if (a == "diagPos12") return diagPositiva12;
            if (a == "diagPos13") return diagPositiva13;
            if (a == "diagPos14") return diagPositiva14;
            if (a == "diagPos15") return diagPositiva15;

            if (a == "diagNeg1") return diagNegativa1;
            if (a == "diagNeg2") return diagNegativa2;
            if (a == "diagNeg3") return diagNegativa3;
            if (a == "diagNeg4") return diagNegativa4;
            if (a == "diagNeg5") return diagNegativa5;
            if (a == "diagNeg6") return diagNegativa6;
            if (a == "diagNeg7") return diagNegativa7;
            if (a == "diagNeg8") return diagNegativa8;
            if (a == "diagNeg9") return diagNegativa9;
            if (a == "diagNeg10") return diagNegativa10;
            if (a == "diagNeg11") return diagNegativa11;
            if (a == "diagNeg12") return diagNegativa12;
            if (a == "diagNeg13") return diagNegativa13;
            if (a == "diagNeg14") return diagNegativa14;
            if (a == "diagNeg15") return diagNegativa15;

            else return null;
        }

        public void Ceder_turno(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            {
                turno.Text = "Negro";
                turno.ForeColor = Color.Black;
                movimiento_blanco.Visible = false;
                movimiento_negro.Visible = true;
            }
            else if (turno.Text == "Negro")
            {
                turno.Text = "Blanco";
                turno.ForeColor = Color.White;
                movimiento_negro.Visible = false;
                movimiento_blanco.Visible = true;
            }
        }

        public void Get_Score(WebControl boton)
        {
            WebControl[] botones = { a1, b1, c1, d1, e1, f1, g1, h1, a2, b2, c2, d2, e2, f2, g2, h2, a3, b3, c3, d3, e3, f3, g3, h3, a4, b4, c4, d4, e4, f4, g4, h4, a5, b5, c5, d5, e5, f5, g5, h5, a6, b6, c6, d6, e6, f6, g6, h6, a7, b7, c7, d7, e7, f7, g7, h7, a8, b8, c8, d8, e8, f8, g8, h8 };
            int score_white = 0;
            int score_black = 0;
            int aux_white = int.Parse(score1.Text);
            int aux_black = int.Parse(score2.Text);
            for (int i = 0; i < botones.Length; i++)
            {
                switch (botones[i].CssClass.ToString())
                {
                    case "btn btn-light btn-lg border-dark rounded-0":
                        score_white++;
                        break;
                    case "btn btn-dark btn-lg border-dark rounded-0":
                        score_black++;
                        break;
                }
            }

            if (score_white == aux_white + 1 && score_white + score_black != 64) { boton.CssClass = verde; score_white--; turno.Text = "Blanco"; turno.ForeColor = Color.White; }
            else if (score_black == aux_black + 1 && score_white + score_black != 64) { boton.CssClass = verde; score_black--; turno.Text = "Negro"; turno.ForeColor = Color.Black; }

            score1.Text = score_white.ToString();
            score2.Text = score_black.ToString();
        }

        public void Get_Move(WebControl boton)
        {
            int black_move = int.Parse(movimiento_negro.Text);
            int white_move = int.Parse(movimiento_blanco.Text);
            if (boton.CssClass != verde)
            {
                if (boton.CssClass == negro)
                {
                    black_move++;
                    movimiento_negro.Text = black_move.ToString();
                    movimiento_negro.Visible = false;
                    movimiento_blanco.Visible = true;
                    cronometro1.Visible = false;
                    cronometro2.Visible = true;
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "reloj2()", true);
                }
                if (boton.CssClass == blanco)
                {
                    white_move++;
                    movimiento_blanco.Text = white_move.ToString();
                    movimiento_blanco.Visible = false;
                    movimiento_negro.Visible = true;
                    cronometro2.Visible = false;
                    cronometro1.Visible = true;
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "reloj1()", true);
                }
            }
            int score_white = int.Parse(score1.Text);
            int score_black = int.Parse(score2.Text);
            if (score_white == 0 && score_black > 0) GameOver();
            else if (score_black == 0 && score_white > 0) GameOver();
            if (score_white + score_black == 64) GameOver();
        }

        public void Terminar_Juego(object sender, EventArgs e)
        {
            if (int.Parse(score1.Text) > int.Parse(score2.Text))
            {
                score1.Text = (64 - int.Parse(score2.Text)).ToString();
                GameOver();
            }
            else if (int.Parse(score1.Text) < int.Parse(score2.Text))
            {
                score2.Text = (64 - int.Parse(score1.Text)).ToString();
                GameOver();
            }
            if (int.Parse(score1.Text) == int.Parse(score2.Text)) GameOver();
        }

        public void GameOver()
        {
            gameBoard.Visible = false;
            if (int.Parse(score1.Text) > int.Parse(score2.Text))
            {
                ganador.Text = "Blanco gana!";
                ganador.CssClass = "display-2 text-white";
                gameover.CssClass = "display-2 text-white";
                turno.Text = "";
                turno.ForeColor = ColorTranslator.FromHtml("#2e86c1");
                move_blanco = movimiento_blanco.Text;
                move_negro = movimiento_negro.Text;
                movimiento_negro.Text = "";
                movimiento_blanco.Text = "";
                Registrar("blanco");
            }
            if (int.Parse(score1.Text) < int.Parse(score2.Text))
            {
                ganador.Text = "Negro gana!";
                ganador.CssClass = "display-2 text-dark";
                gameover.CssClass = "display-2 text-dark";
                turno.Text = "";
                turno.ForeColor = ColorTranslator.FromHtml("#2e86c1");
                move_blanco = movimiento_blanco.Text;
                move_negro = movimiento_negro.Text;
                movimiento_negro.Text = "";
                movimiento_blanco.Text = "";
                Registrar("negro");
            }
            if (int.Parse(score1.Text) == int.Parse(score2.Text) && int.Parse(score1.Text) > 0)
            {
                ganador.Text = "¡Empate!";
                ganador.CssClass = "display-2 text-warning";
                gameover.CssClass = "display-2 text-warning";
                turno.Text = "";
                turno.ForeColor = ColorTranslator.FromHtml("#2e86c1");
                move_blanco = movimiento_blanco.Text;
                move_negro = movimiento_negro.Text;
                movimiento_negro.Text = "";
                movimiento_blanco.Text = "";
                Registrar("empate");
            }
            resultados.Visible = true;
            cronometro1.Visible = false;
            cronometro2.Visible = false;
            guardar.Visible = false;
            ceder_turno.Visible = false;
            end.Visible = false;
            salir.Visible = true;
        }

        public void Registrar(string ganador)
        {
            if (Request.Params["Parametro"] != null && ganador != "empate")
            {
                string parametro = Request.Params["Parametro"];
                string color_host = parametro.Substring(parametro.IndexOf("-") + 1);
                string jugador_host = parametro.Substring(0, parametro.IndexOf("-"));
                string winner = "";
                string loser = "";
                string estado = "";
                switch (color_host)
                {
                    case "Negro":
                        if (ganador == "blanco") estado = "perdida";
                        if (ganador == "negro") estado = "ganada";
                        if (ganador == color_host.ToLower()) { winner = jugador_host; loser = "invitado"; }
                        if (ganador != color_host.ToLower()) { winner = "invitado"; loser = jugador_host; }
                        try
                        {
                            //codigo de Tutoriales Ya.com
                            string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                            SqlConnection conexion = new SqlConnection(a);
                            conexion.Open();
                            SqlCommand script = new SqlCommand("insert into Partida(tipo,estado,movimientos,jugador1,jugador2,ganador,perdedor,empate) values('1vs1','" +
                                    estado + "'," + move_negro + ",'" + jugador_host + "','invitado','" + winner + "','" + loser + "',0)", conexion);
                            script.ExecuteNonQuery();
                            conexion.Close();
                        }
                        catch (Exception)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Error interno: No se pudo guardar el resultado en la base de datos.\")", true);
                        }
                        break;
                    case "Blanco":
                        if (ganador == "blanco") estado = "ganada";
                        if (ganador == "negro") estado = "perdida";
                        if (ganador == "empate") { estado = "empate"; winner = ""; loser = ""; }
                        if (ganador == color_host.ToLower()) { winner = jugador_host; loser = "invitado"; }
                        if (ganador != color_host.ToLower() && ganador != "empate") { winner = "invitado"; loser = jugador_host; }
                        try
                        {
                            //codigo de Tutoriales Ya.com
                            string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                            SqlConnection conexion = new SqlConnection(a);
                            conexion.Open();
                            SqlCommand script = new SqlCommand("insert into Partida(tipo,estado,movimientos,jugador1,jugador2,ganador,perdedor,empate) values('1vs1','" +
                                    estado + "'," + move_blanco + ",'" + jugador_host + "','invitado','" + winner + "','" + loser + "',0)", conexion);
                            script.ExecuteNonQuery();
                            conexion.Close();
                        }
                        catch (Exception)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Error interno: No se pudo guardar el resultado en la base de datos.\")", true);
                        }
                        break;
                }
            }
            if (Request.Params["Parametro"] != null && ganador == "empate")
            {
                string parametro = Request.Params["Parametro"];
                string color_host = parametro.Substring(parametro.IndexOf("-") + 1);
                string jugador_host = parametro.Substring(0, parametro.IndexOf("-"));
                try
                {
                    //codigo de Tutoriales Ya.com
                    if (color_host == "Negro")
                    {
                        string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                        SqlConnection conexion = new SqlConnection(a);
                        conexion.Open();
                        SqlCommand script = new SqlCommand("insert into Partida(tipo,estado,movimientos,jugador1,jugador2,empate) values('1vs1','empate'," +
                               move_negro + ",'" + jugador_host + "','invitado',1)", conexion);
                        script.ExecuteNonQuery();
                        conexion.Close();
                    }
                    if (color_host == "Blanco")
                    {
                        string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                        SqlConnection conexion = new SqlConnection(a);
                        conexion.Open();
                        SqlCommand script = new SqlCommand("insert into Partida(tipo,estado,movimientos,jugador1,jugador2,empate) values('1vs1','empate'," +
                               move_blanco + ",'" + jugador_host + "','invitado',1)", conexion);
                        script.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Error interno: No se pudo guardar el resultado en la base de datos.\")", true);
                }
            }
        }

        public void Salir(object sender, EventArgs e)
        {
            if (Request.Params["Parametro"] != null)
            {
                string parametro = Request.Params["Parametro"];
                string jugador_host = parametro.Substring(0, parametro.IndexOf("-"));
                Response.Redirect("Menu.aspx?Parametro=" + jugador_host);
            }
            else Response.Redirect("Login.aspx");
        }

        public bool FichaAlApar(WebControl[] casilla, string color, int clic)
        {
            bool permitido = true;
            if (clic + 1 < casilla.Length && clic != 0)
            {
                if (color == "Negro")
                {
                    if (casilla[clic].CssClass != blanco)
                    {
                        if (casilla[clic + 1].CssClass == negro && casilla[clic - 1].CssClass == negro && casilla[clic].CssClass == negro)
                            permitido = false;
                    }
                    else
                        permitido = false;
                }
                if (color == "Blanco")
                {
                    if (casilla[clic].CssClass != negro)
                    {
                        if (casilla[clic + 1].CssClass == blanco && casilla[clic - 1].CssClass == blanco && casilla[clic].CssClass == blanco)
                            permitido = false;
                    }
                    else
                        permitido = false;
                }
            }
            if (clic - 1 == -1)
            {
                if (color == "Negro" && casilla.Length > 1)
                {
                    if (casilla[clic + 1].CssClass == negro)
                        permitido = false;
                }
                if (color == "Blanco" && casilla.Length > 1)
                {
                    if (casilla[clic + 1].CssClass == blanco)
                        permitido = false;
                }
            }
            if (clic + 1 >= casilla.Length)
            {
                if (color == "Negro" && casilla.Length > 1)
                {
                    if (casilla[clic - 1].CssClass == negro)
                        permitido = false;
                }
                if (color == "Blanco" && casilla.Length > 1)
                {
                    if (casilla[clic - 1].CssClass == blanco)
                        permitido = false;
                }
            }
            return permitido;
        }

        public int Verificar(WebControl[] casilla, string color, int clic)
        {
            bool permitido = false;
            bool permitido2 = false;
            int aux = 0;
            int aux2 = 0;
            if (color == "Negro")
            {
                if (clic < casilla.Length && casilla.Length != 1)
                {
                    if (permitido == false)
                    {
                        for (int i = 0; i < clic; i++)
                        {
                            if (casilla[i].CssClass == negro)
                            {
                                permitido = true;
                                aux = i;
                            }
                        }
                    }
                    if (true)
                    {
                        for (int i = clic + 1; i < casilla.Length; i++)
                        {
                            if (casilla[i].CssClass == negro)
                            {
                                permitido2 = true;
                                aux2 = i;
                                break;
                            }
                        }
                    }
                }
            }
            if (color == "Blanco")
            {
                if (clic < casilla.Length && casilla.Length != 1)
                {
                    if (permitido == false)
                    {
                        for (int i = 0; i < clic; i++)
                        {
                            if (casilla[i].CssClass == blanco)
                            {
                                permitido = true;
                                aux = i;
                            }
                        }
                    }
                    if (true)
                    {
                        for (int i = clic + 1; i < casilla.Length; i++)
                        {
                            if (casilla[i].CssClass == blanco)
                            {
                                permitido2 = true;
                                aux2 = i;
                                break;
                            }
                        }
                    }
                }
            }
            if (permitido != permitido2)
            {
                if (permitido2) return aux2;
                else return aux;
            }
            if (permitido && permitido2)
            {
                ComerFicha(casilla, color, clic, aux);
                ComerFicha(casilla, color, clic, aux2);
                return -1;
            }
            else
                return -1;
        }

        public void ComerFicha(WebControl[] casilla, string color, int clic, int index)
        {
            if (FichaAlApar(casilla, color, clic))
            {
                if (index != -1)
                {
                    if (VerVacio(casilla, clic, index) == true)
                    {
                        try
                        {
                            if (color == "Negro")
                            {
                                if (index < clic)
                                {
                                    for (int i = index; i <= clic; i++)
                                    {
                                        casilla[i].CssClass = negro;
                                    }
                                }
                                if (index > clic)
                                {
                                    for (int i = clic; i <= index; i++)
                                    {
                                        casilla[i].CssClass = negro;
                                    }
                                }
                                turno.Text = "Blanco";
                                turno.ForeColor = Color.White;
                            }
                            if (color == "Blanco")
                            {

                                if (index < clic)
                                {
                                    for (int i = index; i <= clic; i++)
                                    {
                                        casilla[i].CssClass = blanco;
                                    }
                                }
                                if (index > clic)
                                {
                                    for (int i = clic; i <= index; i++)
                                    {
                                        casilla[i].CssClass = blanco;
                                    }
                                }
                                turno.Text = "Negro";
                                turno.ForeColor = Color.Black;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {

                        }
                    }
                }
            }
        }

        public bool VerVacio(WebControl[] casilla, int clic, int index)
        {
            bool permitido = true;
            if (index != -1 && clic != 0 && clic < casilla.Length)
            {
                try
                {
                    if (index < clic)
                    {
                        for (int i = index; i < clic; i++)
                        {
                            if (casilla[i].CssClass == verde) { permitido = false; break; }
                        }
                    }
                    if (index > clic)
                    {
                        for (int i = clic + 1; i <= index; i++)
                        {
                            if (casilla[i].CssClass == verde) { permitido = false; break; }
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    permitido = false;
                }
            }
            if (clic == 0 && casilla.Length > 1 && index != -1)
            {
                for (int i = clic + 1; i <= index; i++)
                {
                    if (casilla[i].CssClass == verde) { permitido = false; break; }
                }
            }
            if (clic + 1 >= casilla.Length && casilla.Length > 1 && index != -1)
            {
                for (int i = index; i < clic; i++)
                {
                    if (casilla[i].CssClass == verde) { permitido = false; break; }
                }
            }
            return permitido;
        }


        public void A1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a1.CssClass == verde)
            {
                ComerFicha(Tipo("colA"), color, 0, Verificar(Tipo("colA"), color, 0));
                ComerFicha(Tipo("fila1"), color, 0, Verificar(Tipo("fila1"), color, 0));
                ComerFicha(Tipo("diagPos1"), color, 0, Verificar(Tipo("diagPos1"), color, 0));
                ComerFicha(Tipo("diagNeg8"), color, 0, Verificar(Tipo("diagNeg8"), color, 0));

                Get_Score(a1);
                Get_Move(a1);
            }
        }

        public void B1_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (b1.CssClass == verde)
            {
                ComerFicha(Tipo("colB"), color, 0, Verificar(Tipo("colB"), color, 0));
                ComerFicha(Tipo("fila1"), color, 1, Verificar(Tipo("fila1"), color, 1));
                ComerFicha(Tipo("diagPos2"), color, 1, Verificar(Tipo("diagPos2"), color, 1));
                ComerFicha(Tipo("diagNeg7"), color, 0, Verificar(Tipo("diagNeg7"), color, 0));

                Get_Score(b1);
                Get_Move(b1);
            }
        }

        protected void C1_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (c1.CssClass == verde)
            {
                ComerFicha(Tipo("colC"), color, 0, Verificar(Tipo("colC"), color, 0));
                ComerFicha(Tipo("fila1"), color, 2, Verificar(Tipo("fila1"), color, 2));
                ComerFicha(Tipo("diagPos3"), color, 2, Verificar(Tipo("diagPos3"), color, 2));
                ComerFicha(Tipo("diagNeg6"), color, 0, Verificar(Tipo("diagNeg6"), color, 0));
              
                Get_Score(c1);
                Get_Move(c1);
            }
        }

        protected void D1_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (d1.CssClass == verde)
            {
                ComerFicha(Tipo("colD"), color, 0, Verificar(Tipo("colD"), color, 0));
                ComerFicha(Tipo("fila1"), color, 3, Verificar(Tipo("fila1"), color, 3));
                ComerFicha(Tipo("diagPos4"), color, 3, Verificar(Tipo("diagPos4"), color, 3));
                ComerFicha(Tipo("diagNeg5"), color, 0, Verificar(Tipo("diagNeg5"), color, 0));
                
                Get_Score(d1);
                Get_Move(d1);
            }
        }

        protected void E1_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (e1.CssClass == verde)
            {
                ComerFicha(Tipo("colE"), color, 0, Verificar(Tipo("colE"), color, 0));
                ComerFicha(Tipo("fila1"), color, 4, Verificar(Tipo("fila1"), color, 4));
                ComerFicha(Tipo("diagPos5"), color, 4, Verificar(Tipo("diagPos5"), color, 4));
                ComerFicha(Tipo("diagNeg4"), color, 0, Verificar(Tipo("diagNeg4"), color, 0));
              
                Get_Score(e1);
                Get_Move(e1);
            }
        }

        protected void F1_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (f1.CssClass == verde)
            {
                ComerFicha(Tipo("colF"), color, 0, Verificar(Tipo("colF"), color, 0));
                ComerFicha(Tipo("fila1"), color, 5, Verificar(Tipo("fila1"), color, 5));
                ComerFicha(Tipo("diagPos6"), color, 5, Verificar(Tipo("diagPos6"), color, 5));
                ComerFicha(Tipo("diagNeg3"), color, 0, Verificar(Tipo("diagNeg3"), color, 0));
               
                Get_Score(f1);
                Get_Move(f1);
            }
        }

        protected void G1_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (g1.CssClass == verde)
            {
                ComerFicha(Tipo("colG"), color, 0, Verificar(Tipo("colG"), color, 0));
                ComerFicha(Tipo("fila1"), color, 6, Verificar(Tipo("fila1"), color, 6));
                ComerFicha(Tipo("diagPos7"), color, 6, Verificar(Tipo("diagPos7"), color, 6));
                ComerFicha(Tipo("diagNeg2"), color, 0, Verificar(Tipo("diagNeg2"), color, 0));
               
                Get_Score(g1);
                Get_Move(g1);
            }
        }

        protected void H1_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (h1.CssClass == verde)
            {
                ComerFicha(Tipo("colH"), color, 0, Verificar(Tipo("colH"), color, 0));
                ComerFicha(Tipo("fila1"), color, 7, Verificar(Tipo("fila1"), color, 7));
                ComerFicha(Tipo("diagPos8"), color, 7, Verificar(Tipo("diagPos8"), color, 7));
                ComerFicha(Tipo("diagNeg1"), color, 0, Verificar(Tipo("diagNeg1"), color, 0));
              
                Get_Score(h1);
                Get_Move(h1);
            }
        }

        protected void A2_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (a2.CssClass == verde)
            {
                ComerFicha(Tipo("colA"), color, 1, Verificar(Tipo("colA"), color, 1));
                ComerFicha(Tipo("fila2"), color, 0, Verificar(Tipo("fila2"), color, 0));
                ComerFicha(Tipo("diagPos2"), color, 0, Verificar(Tipo("diagPos2"), color, 0));
                ComerFicha(Tipo("diagNeg9"), color, 0, Verificar(Tipo("diagNeg9"), color, 0));
               
                Get_Score(a2);
                Get_Move(a2);
            }
        }

        protected void B2_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (b2.CssClass == verde)
            {
                ComerFicha(Tipo("colB"), color, 1, Verificar(Tipo("colB"), color, 1));
                ComerFicha(Tipo("fila2"), color, 1, Verificar(Tipo("fila2"), color, 1));
                ComerFicha(Tipo("diagPos3"), color, 1, Verificar(Tipo("diagPos3"), color, 1));
                ComerFicha(Tipo("diagNeg8"), color, 1, Verificar(Tipo("diagNeg8"), color, 1));
             
                Get_Score(b2);
                Get_Move(b2);
            }
        }

        protected void C2_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (c2.CssClass == verde)
            {
                ComerFicha(Tipo("colC"), color, 1, Verificar(Tipo("colC"), color, 1));
                ComerFicha(Tipo("fila2"), color, 2, Verificar(Tipo("fila2"), color, 2));
                ComerFicha(Tipo("diagPos4"), color, 2, Verificar(Tipo("diagPos4"), color, 2));
                ComerFicha(Tipo("diagNeg7"), color, 1, Verificar(Tipo("diagNeg7"), color, 1));
               
                Get_Score(c2);
                Get_Move(c2);
            }
        }

        protected void D2_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (d2.CssClass == verde)
            {
                ComerFicha(Tipo("colD"), color, 1, Verificar(Tipo("colD"), color, 1));
                ComerFicha(Tipo("fila2"), color, 3, Verificar(Tipo("fila2"), color, 3));
                ComerFicha(Tipo("diagPos5"), color, 3, Verificar(Tipo("diagPos5"), color, 3));
                ComerFicha(Tipo("diagNeg6"), color, 1, Verificar(Tipo("diagNeg6"), color, 1));

                Get_Score(d2);
                Get_Move(d2);
            }
        }

        protected void E2_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (e2.CssClass == verde)
            {
                ComerFicha(Tipo("colE"), color, 1, Verificar(Tipo("colE"), color, 1));
                ComerFicha(Tipo("fila2"), color, 4, Verificar(Tipo("fila2"), color, 4));
                ComerFicha(Tipo("diagPos6"), color, 4, Verificar(Tipo("diagPos6"), color, 4));
                ComerFicha(Tipo("diagNeg5"), color, 1, Verificar(Tipo("diagNeg5"), color, 1));
               
                Get_Score(e2);
                Get_Move(e2);
            }
        }

        protected void F2_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (f2.CssClass == verde)
            {
                ComerFicha(Tipo("colF"), color, 1, Verificar(Tipo("colF"), color, 1));
                ComerFicha(Tipo("fila2"), color, 5, Verificar(Tipo("fila2"), color, 5));
                ComerFicha(Tipo("diagPos7"), color, 5, Verificar(Tipo("diagPos7"), color, 5));
                ComerFicha(Tipo("diagNeg4"), color, 1, Verificar(Tipo("diagNeg4"), color, 1));

                Get_Score(f2);
                Get_Move(f2);
            }
        }

        protected void G2_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (g2.CssClass == verde)
            {
                ComerFicha(Tipo("colG"), color, 1, Verificar(Tipo("colG"), color, 1));
                ComerFicha(Tipo("fila2"), color, 6, Verificar(Tipo("fila2"), color, 6));
                ComerFicha(Tipo("diagPos8"), color, 6, Verificar(Tipo("diagPos8"), color, 6));
                ComerFicha(Tipo("diagNeg3"), color, 1, Verificar(Tipo("diagNeg3"), color, 1));
              
                Get_Score(g2);
                Get_Move(g2);
            }
        }

        protected void H2_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (h2.CssClass == verde)
            {
                ComerFicha(Tipo("colH"), color, 1, Verificar(Tipo("colH"), color, 1));
                ComerFicha(Tipo("fila2"), color, 7, Verificar(Tipo("fila2"), color, 7));
                ComerFicha(Tipo("diagPos9"), color, 6, Verificar(Tipo("diagPos9"), color, 6));
                ComerFicha(Tipo("diagNeg2"), color, 1, Verificar(Tipo("diagNeg2"), color, 1));
                
                Get_Score(h2);
                Get_Move(h2);
            }
        }

        protected void A3_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (a3.CssClass == verde)
            {
                ComerFicha(Tipo("colA"), color, 2, Verificar(Tipo("colA"), color, 2));
                ComerFicha(Tipo("fila3"), color, 0, Verificar(Tipo("fila3"), color, 0));
                ComerFicha(Tipo("diagPos3"), color, 0, Verificar(Tipo("diagPos3"), color, 0));
                ComerFicha(Tipo("diagNeg10"), color, 0, Verificar(Tipo("diagNeg10"), color, 0));
                
                Get_Score(a3);
                Get_Move(a3);
            }
        }

        protected void B3_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (b3.CssClass == verde)
            {
                ComerFicha(Tipo("colB"), color, 2, Verificar(Tipo("colB"), color, 2));
                ComerFicha(Tipo("fila3"), color, 1, Verificar(Tipo("fila3"), color, 1));
                ComerFicha(Tipo("diagPos4"), color, 1, Verificar(Tipo("diagPos4"), color, 1));
                ComerFicha(Tipo("diagNeg9"), color, 1, Verificar(Tipo("diagNeg9"), color, 1));
                
                Get_Score(b3);
                Get_Move(b3);
            }
        }

        protected void C3_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (c3.CssClass == verde)
            {
                ComerFicha(Tipo("colC"), color, 2, Verificar(Tipo("colC"), color, 2));
                ComerFicha(Tipo("fila3"), color, 2, Verificar(Tipo("fila3"), color, 2));
                ComerFicha(Tipo("diagPos5"), color, 2, Verificar(Tipo("diagPos5"), color, 2));
                ComerFicha(Tipo("diagNeg8"), color, 2, Verificar(Tipo("diagNeg8"), color, 2));
                
                Get_Score(c3);
                Get_Move(c3);
            }
        }

        protected void D3_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (d3.CssClass == verde)
            {
                ComerFicha(Tipo("colD"), color, 2, Verificar(Tipo("colD"), color, 2));
                ComerFicha(Tipo("fila3"), color, 3, Verificar(Tipo("fila3"), color, 3));
                ComerFicha(Tipo("diagPos6"), color, 3, Verificar(Tipo("diagPos6"), color, 3));
                ComerFicha(Tipo("diagNeg7"), color, 2, Verificar(Tipo("diagNeg7"), color, 2));
                
                Get_Score(d3);
                Get_Move(d3);
            }
        }

        protected void E3_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (e3.CssClass == verde)
            {
                ComerFicha(Tipo("colE"), color, 2, Verificar(Tipo("colE"), color, 2));
                ComerFicha(Tipo("fila3"), color, 4, Verificar(Tipo("fila3"), color, 4));
                ComerFicha(Tipo("diagPos7"), color, 4, Verificar(Tipo("diagPos7"), color, 4));
                ComerFicha(Tipo("diagNeg6"), color, 2, Verificar(Tipo("diagNeg6"), color, 2));
                
                Get_Score(e3);
                Get_Move(e3);
            }
        }

        protected void F3_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (f3.CssClass == verde)
            {
                ComerFicha(Tipo("colF"), color, 2, Verificar(Tipo("colF"), color, 2));
                ComerFicha(Tipo("fila3"), color, 5, Verificar(Tipo("fila3"), color, 5));
                ComerFicha(Tipo("diagPos8"), color, 5, Verificar(Tipo("diagPos8"), color, 5));
                ComerFicha(Tipo("diagNeg5"), color, 2, Verificar(Tipo("diagNeg5"), color, 2));
                
                Get_Score(f3);
                Get_Move(f3);
            }
        }

        protected void G3_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (g3.CssClass == verde)
            {
                ComerFicha(Tipo("colG"), color, 2, Verificar(Tipo("colG"), color, 2));
                ComerFicha(Tipo("fila3"), color, 6, Verificar(Tipo("fila3"), color, 6));
                ComerFicha(Tipo("diagPos9"), color, 5, Verificar(Tipo("diagPos9"), color, 5));
                ComerFicha(Tipo("diagNeg4"), color, 2, Verificar(Tipo("diagNeg4"), color, 2));
                
                Get_Score(g3);
                Get_Move(g3);
            }
        }

        protected void H3_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (h3.CssClass == verde)
            {
                ComerFicha(Tipo("colH"), color, 2, Verificar(Tipo("colH"), color, 2));
                ComerFicha(Tipo("fila3"), color, 7, Verificar(Tipo("fila3"), color, 7));
                ComerFicha(Tipo("diagPos10"), color, 5, Verificar(Tipo("diagPos10"), color, 5));
                ComerFicha(Tipo("diagNeg3"), color, 2, Verificar(Tipo("diagNeg3"), color, 2));
               
                Get_Score(h3);
                Get_Move(h3);
            }
        }

        protected void A4_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (a4.CssClass == verde)
            {
                ComerFicha(Tipo("colA"), color, 3, Verificar(Tipo("colA"), color, 3));
                ComerFicha(Tipo("fila4"), color, 0, Verificar(Tipo("fila4"), color, 0));
                ComerFicha(Tipo("diagPos4"), color, 0, Verificar(Tipo("diagPos4"), color, 0));
                ComerFicha(Tipo("diagNeg11"), color, 0, Verificar(Tipo("diagNeg11"), color, 0));
               
                Get_Score(a4);
                Get_Move(a4);
            }
        }
        protected void B4_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (b4.CssClass == verde)
            {
                ComerFicha(Tipo("colB"), color, 3, Verificar(Tipo("colB"), color, 3));
                ComerFicha(Tipo("fila4"), color, 1, Verificar(Tipo("fila4"), color, 1));
                ComerFicha(Tipo("diagPos5"), color, 1, Verificar(Tipo("diagPos5"), color, 1));
                ComerFicha(Tipo("diagNeg10"), color, 1, Verificar(Tipo("diagNeg10"), color, 1));
            
                Get_Score(b4);
                Get_Move(b4);
            }
        }

        protected void C4_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (c4.CssClass == verde)
            {
                ComerFicha(Tipo("colC"), color, 3, Verificar(Tipo("colC"), color, 3));
                ComerFicha(Tipo("fila4"), color, 2, Verificar(Tipo("fila4"), color, 2));
                ComerFicha(Tipo("diagPos6"), color, 2, Verificar(Tipo("diagPos6"), color, 2));
                ComerFicha(Tipo("diagNeg9"), color, 2, Verificar(Tipo("diagNeg9"), color, 2));
          
                Get_Score(c4);
                Get_Move(c4);
            }
        }

        protected void D4_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (d4.CssClass == verde)
            {
                ComerFicha(Tipo("colD"), color, 3, Verificar(Tipo("colD"), color, 3));
                ComerFicha(Tipo("fila4"), color, 3, Verificar(Tipo("fila4"), color, 3));
                ComerFicha(Tipo("diagPos7"), color, 3, Verificar(Tipo("diagPos7"), color, 3));
                ComerFicha(Tipo("diagNeg8"), color, 3, Verificar(Tipo("diagNeg8"), color, 3));
            
                Get_Score(d4);
                Get_Move(d4);
            }
        }

        protected void E4_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (e4.CssClass == verde)
            {
                ComerFicha(Tipo("colE"), color, 3, Verificar(Tipo("colE"), color, 3));
                ComerFicha(Tipo("fila4"), color, 4, Verificar(Tipo("fila4"), color, 4));
                ComerFicha(Tipo("diagPos8"), color, 4, Verificar(Tipo("diagPos8"), color, 4));
                ComerFicha(Tipo("diagNeg7"), color, 3, Verificar(Tipo("diagNeg7"), color, 3));
            
                Get_Score(e4);
                Get_Move(e4);
            }
        }

        protected void F4_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (f4.CssClass == verde)
            {
                ComerFicha(Tipo("colF"), color, 3, Verificar(Tipo("colF"), color, 3));
                ComerFicha(Tipo("fila4"), color, 5, Verificar(Tipo("fila4"), color, 5));
                ComerFicha(Tipo("diagPos9"), color, 4, Verificar(Tipo("diagPos9"), color, 4));
                ComerFicha(Tipo("diagNeg6"), color, 3, Verificar(Tipo("diagNeg6"), color, 3));
            
                Get_Score(f4);
                Get_Move(f4);
            }
        }

        protected void G4_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (g4.CssClass == verde)
            {
                ComerFicha(Tipo("colG"), color, 3, Verificar(Tipo("colG"), color, 3));
                ComerFicha(Tipo("fila4"), color, 6, Verificar(Tipo("fila4"), color, 6));
                ComerFicha(Tipo("diagPos10"), color, 4, Verificar(Tipo("diagPos10"), color, 4));
                ComerFicha(Tipo("diagNeg5"), color, 3, Verificar(Tipo("diagNeg5"), color, 3));
          
                Get_Score(g4);
                Get_Move(g4);
            }
        }

        protected void H4_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (h4.CssClass == verde)
            {
                ComerFicha(Tipo("colH"), color, 3, Verificar(Tipo("colH"), color, 3));
                ComerFicha(Tipo("fila4"), color, 7, Verificar(Tipo("fila4"), color, 7));
                ComerFicha(Tipo("diagPos11"), color, 4, Verificar(Tipo("diagPos11"), color, 4));
                ComerFicha(Tipo("diagNeg4"), color, 3, Verificar(Tipo("diagNeg4"), color, 3));
          
                Get_Score(h4);
                Get_Move(h4);
            }
        }

        protected void A5_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (a5.CssClass == verde)
            {
                ComerFicha(Tipo("colA"), color, 4, Verificar(Tipo("colA"), color, 4));
                ComerFicha(Tipo("fila5"), color, 0, Verificar(Tipo("fila5"), color, 0));
                ComerFicha(Tipo("diagPos5"), color, 0, Verificar(Tipo("diagPos5"), color, 0));
                ComerFicha(Tipo("diagNeg12"), color, 0, Verificar(Tipo("diagNeg12"), color, 0));
          
                Get_Score(a5);
                Get_Move(a5);
            }
        }

        protected void B5_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (b5.CssClass == verde)
            {
                ComerFicha(Tipo("colB"), color, 4, Verificar(Tipo("colB"), color, 4));
                ComerFicha(Tipo("fila5"), color, 1, Verificar(Tipo("fila5"), color, 1));
                ComerFicha(Tipo("diagPos6"), color, 1, Verificar(Tipo("diagPos6"), color, 1));
                ComerFicha(Tipo("diagNeg11"), color, 1, Verificar(Tipo("diagNeg11"), color, 1));
           
                Get_Score(b5);
                Get_Move(b5);
            }
        }

        protected void C5_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (c5.CssClass == verde)
            {
                ComerFicha(Tipo("colC"), color, 4, Verificar(Tipo("colC"), color, 4));
                ComerFicha(Tipo("fila5"), color, 2, Verificar(Tipo("fila5"), color, 2));
                ComerFicha(Tipo("diagPos7"), color, 2, Verificar(Tipo("diagPos7"), color, 2));
                ComerFicha(Tipo("diagNeg10"), color, 2, Verificar(Tipo("diagNeg10"), color, 2));
           
                Get_Score(c5);
                Get_Move(c5);
            }
        }

        protected void D5_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (d5.CssClass == verde)
            {
                ComerFicha(Tipo("colD"), color, 4, Verificar(Tipo("colD"), color, 4));
                ComerFicha(Tipo("fila5"), color, 3, Verificar(Tipo("fila5"), color, 3));
                ComerFicha(Tipo("diagPos8"), color, 3, Verificar(Tipo("diagPos8"), color, 3));
                ComerFicha(Tipo("diagNeg9"), color, 3, Verificar(Tipo("diagNeg9"), color, 3));
           
                Get_Score(d5);
                Get_Move(d5);
            }
        }

        protected void E5_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (e5.CssClass == verde)
            {
                ComerFicha(Tipo("colE"), color, 4, Verificar(Tipo("colE"), color, 4));
                ComerFicha(Tipo("fila5"), color, 4, Verificar(Tipo("fila5"), color, 4));
                ComerFicha(Tipo("diagPos9"), color, 3, Verificar(Tipo("diagPos9"), color, 3));
                ComerFicha(Tipo("diagNeg8"), color, 4, Verificar(Tipo("diagNeg8"), color, 4));
           
                Get_Score(e5);
                Get_Move(e5);
            }
        }

        protected void F5_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (f5.CssClass == verde)
            {
                ComerFicha(Tipo("colF"), color, 4, Verificar(Tipo("colF"), color, 4));
                ComerFicha(Tipo("fila5"), color, 5, Verificar(Tipo("fila5"), color, 5));
                ComerFicha(Tipo("diagPos10"), color, 3, Verificar(Tipo("diagPos10"), color, 3));
                ComerFicha(Tipo("diagNeg7"), color, 4, Verificar(Tipo("diagNeg7"), color, 4));
            
                Get_Score(f5);
                Get_Move(f5);
            }
        }

        protected void G5_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (g5.CssClass == verde)
            {
                ComerFicha(Tipo("colG"), color, 4, Verificar(Tipo("colG"), color, 4));
                ComerFicha(Tipo("fila5"), color, 6, Verificar(Tipo("fila5"), color, 6));
                ComerFicha(Tipo("diagPos11"), color, 3, Verificar(Tipo("diagPos11"), color, 3));
                ComerFicha(Tipo("diagNeg6"), color, 4, Verificar(Tipo("diagNeg6"), color, 4));
            
                Get_Score(g5);
                Get_Move(g5);
            }
        }

        protected void H5_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (h5.CssClass == verde)
            {
                ComerFicha(Tipo("colH"), color, 4, Verificar(Tipo("colH"), color, 4));
                ComerFicha(Tipo("fila5"), color, 7, Verificar(Tipo("fila5"), color, 7));
                ComerFicha(Tipo("diagPos12"), color, 3, Verificar(Tipo("diagPos12"), color, 3));
                ComerFicha(Tipo("diagNeg5"), color, 4, Verificar(Tipo("diagNeg5"), color, 4));
            
                Get_Score(h5);
                Get_Move(h5);
            }
        }

        protected void A6_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (a6.CssClass == verde)
            {
                ComerFicha(Tipo("colA"), color, 5, Verificar(Tipo("colA"), color, 5));
                ComerFicha(Tipo("fila6"), color, 0, Verificar(Tipo("fila6"), color, 0));
                ComerFicha(Tipo("diagPos6"), color, 0, Verificar(Tipo("diagPos6"), color, 0));
                ComerFicha(Tipo("diagNeg13"), color, 0, Verificar(Tipo("diagNeg13"), color, 0));
           
                Get_Score(a6);
                Get_Move(a6);
            }
        }

        protected void B6_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (b6.CssClass == verde)
            {
                ComerFicha(Tipo("colB"), color, 5, Verificar(Tipo("colB"), color, 5));
                ComerFicha(Tipo("fila6"), color, 1, Verificar(Tipo("fila6"), color, 1));
                ComerFicha(Tipo("diagPos7"), color, 1, Verificar(Tipo("diagPos7"), color, 1));
                ComerFicha(Tipo("diagNeg12"), color, 1, Verificar(Tipo("diagNeg12"), color, 1));
           
                Get_Score(b6);
                Get_Move(b6);
            }
        }

        protected void C6_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (c6.CssClass == verde)
            {
                ComerFicha(Tipo("colC"), color, 5, Verificar(Tipo("colC"), color, 5));
                ComerFicha(Tipo("fila6"), color, 2, Verificar(Tipo("fila6"), color, 2));
                ComerFicha(Tipo("diagPos8"), color, 2, Verificar(Tipo("diagPos8"), color, 2));
                ComerFicha(Tipo("diagNeg11"), color, 2, Verificar(Tipo("diagNeg11"), color, 2));
           
                Get_Score(c6);
                Get_Move(c6);
            }
        }

        protected void D6_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (d6.CssClass == verde)
            {
                ComerFicha(Tipo("colD"), color, 5, Verificar(Tipo("colD"), color, 5));
                ComerFicha(Tipo("fila6"), color, 3, Verificar(Tipo("fila6"), color, 3));
                ComerFicha(Tipo("diagPos9"), color, 2, Verificar(Tipo("diagPos9"), color, 2));
                ComerFicha(Tipo("diagNeg10"), color, 3, Verificar(Tipo("diagNeg10"), color, 3));
             
                Get_Score(d6);
                Get_Move(d6);
            }
        }

        protected void E6_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (e6.CssClass == verde)
            {
                ComerFicha(Tipo("colE"), color, 5, Verificar(Tipo("colE"), color, 5));
                ComerFicha(Tipo("fila6"), color, 4, Verificar(Tipo("fila6"), color, 4));
                ComerFicha(Tipo("diagPos10"), color, 2, Verificar(Tipo("diagPos10"), color, 2));
                ComerFicha(Tipo("diagNeg9"), color, 4, Verificar(Tipo("diagNeg9"), color, 4));
            
                Get_Score(e6);
                Get_Move(e6);
            }
        }

        protected void F6_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (f6.CssClass == verde)
            {
                ComerFicha(Tipo("colF"), color, 5, Verificar(Tipo("colF"), color, 5));
                ComerFicha(Tipo("fila6"), color, 5, Verificar(Tipo("fila6"), color, 5));
                ComerFicha(Tipo("diagPos11"), color, 2, Verificar(Tipo("diagPos11"), color, 2));
                ComerFicha(Tipo("diagNeg8"), color, 5, Verificar(Tipo("diagNeg8"), color, 5));
                
                Get_Score(f6);
                Get_Move(f6);
            }
        }

        protected void G6_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (g6.CssClass == verde)
            {
                ComerFicha(Tipo("colG"), color, 5, Verificar(Tipo("colG"), color, 5));
                ComerFicha(Tipo("fila6"), color, 6, Verificar(Tipo("fila6"), color, 6));
                ComerFicha(Tipo("diagPos12"), color, 2, Verificar(Tipo("diagPos12"), color, 2));
                ComerFicha(Tipo("diagNeg7"), color, 5, Verificar(Tipo("diagNeg7"), color, 5));
            
                Get_Score(g6);
                Get_Move(g6);
            }
        }

        protected void H6_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (h6.CssClass == verde)
            {
                ComerFicha(Tipo("colH"), color, 5, Verificar(Tipo("colH"), color, 5));
                ComerFicha(Tipo("fila6"), color, 7, Verificar(Tipo("fila6"), color, 7));
                ComerFicha(Tipo("diagPos13"), color, 2, Verificar(Tipo("diagPos13"), color, 2));
                ComerFicha(Tipo("diagNeg6"), color, 5, Verificar(Tipo("diagNeg6"), color, 5));
            
                Get_Score(h6);
                Get_Move(h6);
            }
        }

        protected void A7_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (a7.CssClass == verde)
            {
                ComerFicha(Tipo("colA"), color, 6, Verificar(Tipo("colA"), color, 6));
                ComerFicha(Tipo("fila7"), color, 0, Verificar(Tipo("fila7"), color, 0));
                ComerFicha(Tipo("diagPos7"), color, 0, Verificar(Tipo("diagPos7"), color, 0));
                ComerFicha(Tipo("diagNeg14"), color, 0, Verificar(Tipo("diagNeg14"), color, 0));
              
                Get_Score(a7);
                Get_Move(a7);
            }
        }

        protected void B7_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (b7.CssClass == verde)
            {
                ComerFicha(Tipo("colB"), color, 6, Verificar(Tipo("colB"), color, 6));
                ComerFicha(Tipo("fila7"), color, 1, Verificar(Tipo("fila7"), color, 1));
                ComerFicha(Tipo("diagPos8"), color, 1, Verificar(Tipo("diagPos8"), color, 1));
                ComerFicha(Tipo("diagNeg13"), color, 1, Verificar(Tipo("diagNeg13"), color, 1));
            
                Get_Score(b7);
                Get_Move(b7);
            }
        }

        protected void C7_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (c7.CssClass == verde)
            {
                ComerFicha(Tipo("colC"), color, 6, Verificar(Tipo("colC"), color, 6));
                ComerFicha(Tipo("fila7"), color, 2, Verificar(Tipo("fila7"), color, 2));
                ComerFicha(Tipo("diagPos9"), color, 1, Verificar(Tipo("diagPos9"), color, 1));
                ComerFicha(Tipo("diagNeg12"), color, 2, Verificar(Tipo("diagNeg12"), color, 2));
               
                Get_Score(c7);
                Get_Move(c7);
            }
        }

        protected void D7_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (d7.CssClass == verde)
            {
                ComerFicha(Tipo("colD"), color, 6, Verificar(Tipo("colD"), color, 6));
                ComerFicha(Tipo("fila7"), color, 3, Verificar(Tipo("fila7"), color, 3));
                ComerFicha(Tipo("diagPos10"), color, 1, Verificar(Tipo("diagPos10"), color, 1));
                ComerFicha(Tipo("diagNeg11"), color, 3, Verificar(Tipo("diagNeg11"), color, 3));
            
                Get_Score(d7);
                Get_Move(d7);
            }
        }

        protected void E7_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (e7.CssClass == verde)
            {
                ComerFicha(Tipo("colE"), color, 6, Verificar(Tipo("colE"), color, 6));
                ComerFicha(Tipo("fila7"), color, 4, Verificar(Tipo("fila7"), color, 4));
                ComerFicha(Tipo("diagPos11"), color, 1, Verificar(Tipo("diagPos11"), color, 1));
                ComerFicha(Tipo("diagNeg10"), color, 4, Verificar(Tipo("diagNeg10"), color, 4));
             
                Get_Score(e7);
                Get_Move(e7);
            }
        }

        protected void F7_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (f7.CssClass == verde)
            {
                ComerFicha(Tipo("colF"), color, 6, Verificar(Tipo("colF"), color, 6));
                ComerFicha(Tipo("fila7"), color, 5, Verificar(Tipo("fila7"), color, 5));
                ComerFicha(Tipo("diagPos12"), color, 1, Verificar(Tipo("diagPos12"), color, 1));
                ComerFicha(Tipo("diagNeg9"), color, 5, Verificar(Tipo("diagNeg9"), color, 5));
                
                Get_Score(f7);
                Get_Move(f7);
            }
        }

        protected void G7_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (g7.CssClass == verde)
            {
                ComerFicha(Tipo("colG"), color, 6, Verificar(Tipo("colG"), color, 6));
                ComerFicha(Tipo("fila7"), color, 6, Verificar(Tipo("fila7"), color, 6));
                ComerFicha(Tipo("diagPos13"), color, 1, Verificar(Tipo("diagPos13"), color, 1));
                ComerFicha(Tipo("diagNeg8"), color, 6, Verificar(Tipo("diagNeg8"), color, 6));
                
                Get_Score(g7);
                Get_Move(g7);
            }
        }

        protected void H7_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (h7.CssClass == verde)
            {
                ComerFicha(Tipo("colH"), color, 6, Verificar(Tipo("colH"), color, 6));
                ComerFicha(Tipo("fila7"), color, 7, Verificar(Tipo("fila7"), color, 7));
                ComerFicha(Tipo("diagPos14"), color, 1, Verificar(Tipo("diagPos14"), color, 1));
                ComerFicha(Tipo("diagNeg7"), color, 6, Verificar(Tipo("diagNeg7"), color, 6));
            
                Get_Score(h7);
                Get_Move(h7);
            }
        }

        protected void A8_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (a8.CssClass == verde)
            {
                ComerFicha(Tipo("colA"), color, 7, Verificar(Tipo("colA"), color, 7));
                ComerFicha(Tipo("fila8"), color, 0, Verificar(Tipo("fila8"), color, 0));
                ComerFicha(Tipo("diagPos8"), color, 0, Verificar(Tipo("diagPos8"), color, 0));
                ComerFicha(Tipo("diagNeg15"), color, 0, Verificar(Tipo("diagNeg15"), color, 0));
            
                Get_Score(a8);
                Get_Move(a8);
            }
        }

        protected void B8_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (b8.CssClass == verde)
            {
                ComerFicha(Tipo("colB"), color, 7, Verificar(Tipo("colB"), color, 7));
                ComerFicha(Tipo("fila8"), color, 1, Verificar(Tipo("fila8"), color, 1));
                ComerFicha(Tipo("diagPos9"), color, 0, Verificar(Tipo("diagPos9"), color, 0));
                ComerFicha(Tipo("diagNeg14"), color, 1, Verificar(Tipo("diagNeg14"), color, 1));
            
                Get_Score(b8);
                Get_Move(b8);
            }
        }

        protected void C8_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (c8.CssClass == verde)
            {
                ComerFicha(Tipo("colC"), color, 7, Verificar(Tipo("colC"), color, 7));
                ComerFicha(Tipo("fila8"), color, 2, Verificar(Tipo("fila8"), color, 2));
                ComerFicha(Tipo("diagPos10"), color, 0, Verificar(Tipo("diagPos10"), color, 0));
                ComerFicha(Tipo("diagNeg13"), color, 2, Verificar(Tipo("diagNeg13"), color, 2));
            
                Get_Score(c8);
                Get_Move(c8);
            }
        }

        protected void D8_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (d8.CssClass == verde)
            {
                ComerFicha(Tipo("colD"), color, 7, Verificar(Tipo("colD"), color, 7));
                ComerFicha(Tipo("fila8"), color, 3, Verificar(Tipo("fila8"), color, 3));
                ComerFicha(Tipo("diagPos11"), color, 0, Verificar(Tipo("diagPos11"), color, 0));
                ComerFicha(Tipo("diagNeg12"), color, 3, Verificar(Tipo("diagNeg12"), color, 3));
               
                Get_Score(d8);
                Get_Move(d8);
            }
        }

        protected void E8_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (e8.CssClass == verde)
            {
                ComerFicha(Tipo("colE"), color, 7, Verificar(Tipo("colE"), color, 7));
                ComerFicha(Tipo("fila8"), color, 4, Verificar(Tipo("fila8"), color, 4));
                ComerFicha(Tipo("diagPos12"), color, 0, Verificar(Tipo("diagPos12"), color, 0));
                ComerFicha(Tipo("diagNeg11"), color, 4, Verificar(Tipo("diagNeg11"), color, 4));
             
                Get_Score(e8);
                Get_Move(e8);
            }
        }

        protected void F8_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (f8.CssClass == verde)
            {
                ComerFicha(Tipo("colF"), color, 7, Verificar(Tipo("colF"), color, 7));
                ComerFicha(Tipo("fila8"), color, 5, Verificar(Tipo("fila8"), color, 5));
                ComerFicha(Tipo("diagPos13"), color, 0, Verificar(Tipo("diagPos13"), color, 0));
                ComerFicha(Tipo("diagNeg10"), color, 5, Verificar(Tipo("diagNeg10"), color, 5));
             
                Get_Score(f8);
                Get_Move(f8);
            }
        }

        protected void G8_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (g8.CssClass == verde)
            {
                ComerFicha(Tipo("colG"), color, 7, Verificar(Tipo("colG"), color, 7));
                ComerFicha(Tipo("fila8"), color, 6, Verificar(Tipo("fila8"), color, 6));
                ComerFicha(Tipo("diagPos14"), color, 0, Verificar(Tipo("diagPos14"), color, 0));
                ComerFicha(Tipo("diagNeg9"), color, 6, Verificar(Tipo("diagNeg9"), color, 6));
             
                Get_Score(g8);
                Get_Move(g8);
            }
        }

        protected void H8_Click(object sender, EventArgs e)
        {
			string color = turno.Text;
            if (h8.CssClass == verde)
            {
                ComerFicha(Tipo("colH"), color, 7, Verificar(Tipo("colH"), color, 7));
                ComerFicha(Tipo("fila8"), color, 7, Verificar(Tipo("fila8"), color, 7));
                ComerFicha(Tipo("diagPos15"), color, 0, Verificar(Tipo("diagPos15"), color, 0));
                ComerFicha(Tipo("diagNeg8"), color, 7, Verificar(Tipo("diagNeg8"), color, 7));
         
                Get_Score(h8);
                Get_Move(h8);
            }
        }
    }
}