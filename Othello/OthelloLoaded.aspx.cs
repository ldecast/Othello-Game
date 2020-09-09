using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Othello
{
    public partial class OthelloLoaded : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Leer_xml();
            Get_Score();
        }

        public void Leer_xml()
        {
            string ruta = "";
            if (Session["archivo"] != null)
            {
                ruta = Convert.ToString(Session["archivo"]);
                Response.Write("Partida desde: "+ruta);
            }

            XmlTextReader reader = new XmlTextReader(ruta);
            int i = 0;
            WebControl[] botones = { a1, b1, c1, d1, e1, f1, g1, h1, a2, b2, c2, d2, e2, f2, g2, h2, a3, b3, c3, d3, e3, f3, g3, h3, a4, b4, c4, d4, e4, f4, g4, h4, a5, b5, c5, d5, e5, f5, g5, h5, a6, b6, c6, d6, e6, f6, g6, h6, a7, b7, c7, d7, e7, f7, g7, h7, a8, b8, c8, d8, e8, f8, g8, h8, };

            while (reader.Read())
            {
                switch (reader.ReadString())
                {
                    case "blanco":
                        botones[i].CssClass = "btn btn-light btn-lg border-dark rounded-0";
                        i++;
                        break;
                    case "negro":
                        botones[i].CssClass = "btn btn-dark btn-lg border-dark rounded-0";
                        i++;
                        break;
                    case "vacio":
                        botones[i].CssClass = "btn btn-success btn-lg border-dark rounded-0";
                        i++;
                        break;
                }
            }
        }

        public void Get_Score()
        {
            WebControl[] botones = { a1, b1, c1, d1, e1, f1, g1, h1, a2, b2, c2, d2, e2, f2, g2, h2, a3, b3, c3, d3, e3, f3, g3, h3, a4, b4, c4, d4, e4, f4, g4, h4, a5, b5, c5, d5, e5, f5, g5, h5, a6, b6, c6, d6, e6, f6, g6, h6, a7, b7, c7, d7, e7, f7, g7, h7, a8, b8, c8, d8, e8, f8, g8, h8 };
            int score_white = 0;
            int score_black = 0;
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
            score1.Text = score_white.ToString();
            score2.Text = score_black.ToString();
        }

        protected string Ver_ficha(int boton)
        {
            if (boton == 1)
            {
                if (a1.CssClass == "btn btn-light btn-lg border-dark rounded-0")
                    return "blanco";
                if (a1.CssClass == "btn btn-dark btn-lg border-dark rounded-0")
                    return "negro";
                else
                    return "vacio";
            }
            if (boton == 2)
            { if (b1.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (b1.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 3)
            { if (c1.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (c1.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 4)
            { if (d1.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (d1.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 5)
            { if (e1.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (e1.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 6)
            { if (f1.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (f1.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 7)
            { if (g1.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (g1.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 8)
            { if (h1.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (h1.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }

            if (boton == 9)
            { if (a2.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (a2.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 10)
            { if (b2.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (b2.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 11)
            { if (c2.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (c2.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 12)
            { if (d2.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (d2.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 13)
            { if (e2.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (e2.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 14)
            { if (f2.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (f2.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 15)
            { if (g2.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (g2.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 16)
            { if (h2.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (h2.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }

            if (boton == 17)
            { if (a3.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (a3.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 18)
            { if (b3.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (b3.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 19)
            { if (c3.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (c3.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 20)
            { if (d3.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (d3.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 21)
            { if (e3.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (e3.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 22)
            { if (f3.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (f3.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 23)
            { if (g3.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (g3.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 24)
            { if (h3.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (h3.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }

            if (boton == 25)
            { if (a4.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (a4.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 26)
            { if (b4.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (b4.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 27)
            { if (c4.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (c4.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 28)
            { if (d4.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (d4.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 29)
            { if (e4.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (e4.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 30)
            { if (f4.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (f4.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 31)
            { if (g4.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (g4.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 32)
            { if (h4.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (h4.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }

            if (boton == 33)
            { if (a5.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (a5.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 34)
            { if (b5.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (b5.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 35)
            { if (c5.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (c5.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 36)
            { if (d5.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (d5.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 37)
            { if (e5.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (e5.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 38)
            { if (f5.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (f5.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 39)
            { if (g5.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (g5.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 40)
            { if (h5.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (h5.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }

            if (boton == 41)
            { if (a6.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (a6.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 42)
            { if (b6.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (b6.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 43)
            { if (c6.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (c6.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 44)
            { if (d6.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (d6.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 45)
            { if (e6.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (e6.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 46)
            { if (f6.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (f6.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 47)
            { if (g6.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (g6.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 48)
            { if (h6.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (h6.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }

            if (boton == 49)
            { if (a7.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (a7.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 50)
            { if (b7.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (b7.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 51)
            { if (c7.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (c7.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 52)
            { if (d7.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (d7.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 53)
            { if (e7.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (e7.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 54)
            { if (f7.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (f7.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 55)
            { if (g7.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (g7.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 56)
            { if (h7.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (h7.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }

            if (boton == 57)
            { if (a8.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (a8.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 58)
            { if (b8.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (b8.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 59)
            { if (c8.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (c8.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 60)
            { if (d8.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (d8.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 61)
            { if (e8.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (e8.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 62)
            { if (f8.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (f8.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 63)
            { if (g8.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (g8.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            if (boton == 64)
            { if (h8.CssClass == "btn btn-light btn-lg border-dark rounded-0") return "blanco"; if (h8.CssClass == "btn btn-dark btn-lg border-dark rounded-0") return "negro"; else return "vacio"; }
            else return "error";
        }

        protected void generarXml(object sender, EventArgs e)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

            string[] col = { "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H" };
            string[] fila = { "1", "1", "1", "1", "1", "1", "1", "1", "2", "2", "2", "2", "2", "2", "2", "2", "3", "3", "3", "3", "3", "3", "3", "3", "4", "4", "4", "4", "4", "4", "4", "4", "5", "5", "5", "5", "5", "5", "5", "5", "6", "6", "6", "6", "6", "6", "6", "6", "7", "7", "7", "7", "7", "7", "7", "7", "8", "8", "8", "8", "8", "8", "8", "8" };

            XmlWriter xmlWriter = XmlWriter.Create(@"C:\Users\luisd\Desktop\XML\archivo.xml", settings);

            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("tablero");

            for (int i = 0; i < 64; i++)
            {
                xmlWriter.WriteStartElement("ficha");
                xmlWriter.WriteStartElement("color");
                xmlWriter.WriteString(Ver_ficha(i + 1));
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("columna");
                xmlWriter.WriteString(col[i]);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("fila");
                xmlWriter.WriteString(fila[i]);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

        }

        public void a1_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            {
                a1.CssClass = "btn btn-light btn-lg border-dark rounded-0";
                turno.Text = "Negro";
            }
            else
            {
                a1.CssClass = "btn btn-dark btn-lg border-dark rounded-0";
                turno.Text = "Blanco";
            }
            Get_Score();
        }

        public void b1_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            {
                b1.CssClass = "btn btn-light btn-lg border-dark rounded-0";
                turno.Text = "Negro";
            }
            else
            {
                b1.CssClass = "btn btn-dark btn-lg border-dark rounded-0";
                turno.Text = "Blanco";
            }
            Get_Score();
        }

        protected void c1_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { c1.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { c1.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void d1_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { d1.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { d1.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void e1_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { e1.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { e1.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void f1_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { f1.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { f1.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void g1_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { g1.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { g1.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void h1_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { h1.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { h1.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void a2_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { a2.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { a2.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void b2_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { b2.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { b2.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void c2_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { c2.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { c2.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void d2_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { d2.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { d2.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void e2_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { e2.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { e2.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void f2_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { f2.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { f2.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void g2_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { g2.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { g2.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void h2_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { h2.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { h2.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void a3_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { a3.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { a3.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void b3_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { b3.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { b3.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void c3_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { c3.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { c3.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void d3_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { d3.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { d3.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void e3_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { e3.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { e3.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void f3_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { f3.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { f3.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void g3_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { g3.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { g3.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void h3_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { h3.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { h3.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void a4_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { a4.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { a4.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }
        protected void b4_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { b4.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { b4.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void c4_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { c4.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { c4.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void d4_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { d4.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { d4.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void e4_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { e4.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { e4.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void f4_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { f4.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { f4.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void g4_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { g4.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { g4.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void h4_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { h4.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { h4.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void a5_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { a5.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { a5.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void b5_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { b5.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { b5.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void c5_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { c5.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { c5.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void d5_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { d5.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { d5.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void e5_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { e5.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { e5.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void f5_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { f5.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { f5.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void g5_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { g5.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { g5.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void h5_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { h5.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { h5.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void a6_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { a6.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { a6.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void b6_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { b6.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { b6.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void c6_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { c6.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { c6.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void d6_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { d6.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { d6.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void e6_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { e6.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { e6.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void f6_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { f6.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { f6.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void g6_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { g6.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { g6.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void h6_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { h6.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { h6.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void a7_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { a7.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { a7.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void b7_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { b7.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { b7.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void c7_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { c7.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { c7.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void d7_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { d7.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { d7.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void e7_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { e7.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { e7.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void f7_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { f7.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { f7.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void g7_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { g7.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { g7.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void h7_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { h7.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { h7.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void a8_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { a8.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { a8.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void b8_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { b8.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { b8.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void c8_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { c8.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { c8.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void d8_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { d8.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { d8.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void e8_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { e8.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { e8.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void f8_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { f8.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { f8.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void g8_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { g8.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { g8.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }

        protected void h8_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Blanco")
            { h8.CssClass = "btn btn-light btn-lg border-dark rounded-0"; turno.Text = "Negro"; }
            else
            { h8.CssClass = "btn btn-dark btn-lg border-dark rounded-0"; turno.Text = "Blanco"; }
            Get_Score();
        }
    }
}