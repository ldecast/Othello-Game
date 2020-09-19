using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Xml;

namespace Othello
{
    public partial class OthelloLoaded : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (tableroLleno() == true)
                gameOver();
        }

        public void Leer_xml(object sender, EventArgs e)
        {
            string ruta = "";
            if (Session["archivo"] != null)
            {
                ruta = Convert.ToString(Session["archivo"]);
                Response.Write("Partida desde: "+ruta);
            }

            XmlDocument reader = new XmlDocument();
            reader.Load(ruta);
            WebControl[] botones = { a1, b1, c1, d1, e1, f1, g1, h1, a2, b2, c2, d2, e2, f2, g2, h2, a3, b3, c3, d3, e3, f3, g3, h3, a4, b4, c4, d4, e4, f4, g4, h4, a5, b5, c5, d5, e5, f5, g5, h5, a6, b6, c6, d6, e6, f6, g6, h6, a7, b7, c7, d7, e7, f7, g7, h7, a8, b8, c8, d8, e8, f8, g8, h8, };

            XmlNodeList fichas = reader.GetElementsByTagName("ficha");
            for (int i = 0; i < fichas.Count; i++)
            {
                if (fichas[i].InnerText.Contains("blanco"))
                {
                    if (fichas[i].InnerText.Contains("A1")){botones[0].CssClass = "btn btn-light btn-lg border-dark rounded-0";}
                    if (fichas[i].InnerText.Contains("B1")){botones[1].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("C1")){botones[2].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("D1")){botones[3].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("E1")){botones[4].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("F1")){botones[5].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("G1")){botones[6].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("H1")){botones[7].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("A2")){botones[8].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("B2")){botones[9].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("C2")){botones[10].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("D2")){botones[11].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("E2")){botones[12].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("F2")){botones[13].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("G2")){botones[14].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("H2")){botones[15].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("A3")){botones[16].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("B3")){botones[17].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("C3")){botones[18].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("D3")){botones[19].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("E3")){botones[20].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("F3")){botones[21].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("G3")){botones[22].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("H3")){botones[23].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("A4")){botones[24].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("B4")){botones[25].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("C4")){botones[26].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("D4")){botones[27].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("E4")){botones[28].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("F4")){botones[29].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("G4")){botones[30].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("H4")){botones[31].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("A5")){botones[32].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("B5")){botones[33].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("C5")){botones[34].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("D5")){botones[35].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("E5")){botones[36].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("F5")){botones[37].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("G5")){botones[38].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("H5")){botones[39].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("A6")) { botones[40].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("B6")) { botones[41].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("C6")) { botones[42].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("D6")) { botones[43].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("E6")) { botones[44].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("F6")) { botones[45].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("G6")) { botones[46].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("H6")) { botones[47].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("A7")) { botones[48].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("B7")) { botones[49].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("C7")) { botones[50].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("D7")) { botones[51].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("E7")) { botones[52].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("F7")) { botones[53].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("G7")) { botones[54].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("H7")) { botones[55].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("A8")) { botones[56].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("B8")) { botones[57].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("C8")) { botones[58].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("D8")) { botones[59].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("E8")) { botones[60].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("F8")) { botones[61].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("G8")) { botones[62].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("H8")) { botones[63].CssClass = "btn btn-light btn-lg border-dark rounded-0"; }
                }
                if (fichas[i].InnerText.Contains("negro"))
                {
                    if (fichas[i].InnerText.Contains("A1")) { botones[0].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("B1")) { botones[1].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("C1")) { botones[2].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("D1")) { botones[3].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("E1")) { botones[4].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("F1")) { botones[5].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("G1")) { botones[6].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("H1")) { botones[7].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("A2")) { botones[8].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("B2")) { botones[9].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("C2")) { botones[10].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("D2")) { botones[11].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("E2")) { botones[12].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("F2")) { botones[13].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("G2")) { botones[14].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("H2")) { botones[15].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("A3")) { botones[16].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("B3")) { botones[17].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("C3")) { botones[18].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("D3")) { botones[19].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("E3")) { botones[20].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("F3")) { botones[21].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("G3")) { botones[22].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("H3")) { botones[23].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("A4")) { botones[24].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("B4")) { botones[25].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("C4")) { botones[26].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("D4")) { botones[27].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("E4")) { botones[28].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("F4")) { botones[29].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("G4")) { botones[30].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("H4")) { botones[31].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("A5")) { botones[32].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("B5")) { botones[33].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("C5")) { botones[34].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("D5")) { botones[35].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("E5")) { botones[36].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("F5")) { botones[37].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("G5")) { botones[38].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("H5")) { botones[39].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("A6")) { botones[40].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("B6")) { botones[41].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("C6")) { botones[42].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("D6")) { botones[43].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("E6")) { botones[44].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("F6")) { botones[45].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("G6")) { botones[46].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("H6")) { botones[47].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("A7")) { botones[48].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("B7")) { botones[49].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("C7")) { botones[50].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("D7")) { botones[51].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("E7")) { botones[52].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("F7")) { botones[53].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("G7")) { botones[54].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("H7")) { botones[55].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("A8")) { botones[56].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("B8")) { botones[57].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("C8")) { botones[58].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("D8")) { botones[59].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("E8")) { botones[60].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("F8")) { botones[61].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("G8")) { botones[62].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                    if (fichas[i].InnerText.Contains("H8")) { botones[63].CssClass = "btn btn-dark btn-lg border-dark rounded-0"; }
                }
                //Response.Write(fichas[i].InnerXml + "\n");
            }

            XmlNodeList tiro = reader.GetElementsByTagName("siguienteTiro");
            for (int i = 0; i < tiro.Count; i++)
            {
                if (tiro[i].InnerText.Contains("blanco"))
                    turno.Text = "Blanco";
                if (tiro[i].InnerText.Contains("negro"))
                    turno.Text = "Negro";
                //Response.Write(tiro[i].InnerXml);
            }

            iniciar.Visible = false;
            Get_Score();
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

        public WebControl[] tipo(string a)
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

        protected void generarXml(object sender, EventArgs e)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

            string[] col = { "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H" };
            string[] fila = { "1", "1", "1", "1", "1", "1", "1", "1", "2", "2", "2", "2", "2", "2", "2", "2", "3", "3", "3", "3", "3", "3", "3", "3", "4", "4", "4", "4", "4", "4", "4", "4", "5", "5", "5", "5", "5", "5", "5", "5", "6", "6", "6", "6", "6", "6", "6", "6", "7", "7", "7", "7", "7", "7", "7", "7", "8", "8", "8", "8", "8", "8", "8", "8" };

            DateTime dateTime = DateTime.UtcNow.Date;
            string date = dateTime.ToString("dd-MM-yyyy");
            string hms = DateTime.Now.ToString("HH-mm");

            string persona = "";
            if (Request.Params["Parametro"] != null)
            {
                persona = Request.Params["Parametro"] + " ";
            }

            string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";

            string ruta = mdoc + "Partida nueva " + persona + date + " " + hms + ".xml";

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

            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            Response.Write("Partida guardada en: " + ruta);
        }

        public bool fichaAlApar(WebControl[] casilla, string color, int clic)
        {
            
                bool permitido = true;
                //Response.Write(casilla.Length);
                if (clic + 1 < casilla.Length && clic !=0)
                {
                if (color == "negro")
                {
                    if (casilla[clic].CssClass != "btn btn-light btn-lg border-dark rounded-0")
                    {
                        if (casilla[clic + 1].CssClass == "btn btn-dark btn-lg border-dark rounded-0" && casilla[clic - 1].CssClass == "btn btn-dark btn-lg border-dark rounded-0" && casilla[clic].CssClass == "btn btn-dark btn-lg border-dark rounded-0")
                            permitido = false;
                    }
                    else
                        permitido = false;
                }
                if (color == "blanco")
                {
                    if (casilla[clic].CssClass != "btn btn-dark btn-lg border-dark rounded-0")
                    {
                        if (casilla[clic + 1].CssClass == "btn btn-light btn-lg border-dark rounded-0" && casilla[clic - 1].CssClass == "btn btn-light btn-lg border-dark rounded-0" && casilla[clic].CssClass == "btn btn-light btn-lg border-dark rounded-0")
                            permitido = false;
                    }
                    else
                        permitido = false;
                }
                }
                if (clic - 1 == -1)
                {
                    if (color == "negro" && casilla.Length > 1)
                    {
                    //if (casilla[clic].CssClass != "btn btn-light btn-lg border-dark rounded-0")
                    //{
                        if (casilla[clic + 1].CssClass == "btn btn-dark btn-lg border-dark rounded-0")// || casilla[clic].CssClass == "btn btn-dark btn-lg border-dark rounded-0")
                            permitido = false;
                    //}
                    //else
                    //    permitido = false;
                }
                    if (color == "blanco" && casilla.Length > 1)
                    {
                    //if (casilla[clic].CssClass != "btn btn-dark btn-lg border-dark rounded-0")
                    //{
                        if (casilla[clic + 1].CssClass == "btn btn-light btn-lg border-dark rounded-0")// || casilla[clic].CssClass == "btn btn-light btn-lg border-dark rounded-0")
                            permitido = false;
                    //}
                    //else
                    //    permitido = false;
                }
                }
                if (clic + 1 >= casilla.Length)
                {
                    if (color == "negro" && casilla.Length > 1)
                    {
                    //if (casilla[clic].CssClass != "btn btn-light btn-lg border-dark rounded-0")
                    //{
                        if (casilla[clic - 1].CssClass == "btn btn-dark btn-lg border-dark rounded-0")// || casilla[clic].CssClass == "btn btn-dark btn-lg border-dark rounded-0")
                            permitido = false;
                    //}
                    //else
                    //    permitido = false;
                }
                    if (color == "blanco"&& casilla.Length > 1)
                    {
                    //if (casilla[clic].CssClass != "btn btn-dark btn-lg border-dark rounded-0")
                    //{
                        if (casilla[clic - 1].CssClass == "btn btn-light btn-lg border-dark rounded-0") //|| casilla[clic].CssClass == "btn btn-light btn-lg border-dark rounded-0")
                            permitido = false;
                    //}
                    //else
                    //    permitido = false;
                }
                }
                //Response.Write(permitido);
                return permitido;
        }

        public bool tableroLleno()
        {
            WebControl[] botones = { a1, b1, c1, d1, e1, f1, g1, h1, a2, b2, c2, d2, e2, f2, g2, h2, a3, b3, c3, d3, e3, f3, g3, h3, a4, b4, c4, d4, e4, f4, g4, h4, a5, b5, c5, d5, e5, f5, g5, h5, a6, b6, c6, d6, e6, f6, g6, h6, a7, b7, c7, d7, e7, f7, g7, h7, a8, b8, c8, d8, e8, f8, g8, h8, };
            bool lleno = false;
            int colocado = 0;
            for (int i = 0; i < botones.Length; i++)
            {
                if (botones[i].CssClass == "btn btn-light btn-lg border-dark rounded-0" || botones[i].CssClass == "btn btn-dark btn-lg border-dark rounded-0")
                    colocado++;
                else
                    lleno = false;
            }
            if (colocado >= 63)
                lleno = true;
            return lleno;
        }

        public void gameOver()
        {
            gameBoard.Visible = false;
            if (int.Parse(score1.Text) > int.Parse(score2.Text))
                ganador.Text = "GAME OVER\nBlanco wins!";
            if (int.Parse(score1.Text) < int.Parse(score2.Text))
                ganador.Text = "GAME OVER\nNegro wins!";
            resultados.Visible = true;
        }

        public int verificar(WebControl[] casilla, string color)
        {
            //bool permitido = false;
            //int indice = -1;
            //if (color == "negro")
            //{
            //    if (clic != casilla.Length-1 && fichaAlApar(casilla, color, clic))
            //    {
            //        for (int i = 0; i < clic; i++)
            //        {
            //            if (casilla[i].CssClass == "btn btn-dark btn-lg border-dark rounded-0")
            //            {
            //                permitido = true;
            //                indice = i;
            //                //break;
            //            }
            //        }
            //        for (int i = clic; i < casilla.Length; i++)
            //        {
            //            if (casilla[i].CssClass == "btn btn-dark btn-lg border-dark rounded-0")
            //            {
            //                permitido = true;
            //                indice = i;
            //                break;
            //            }
            //        }
            //    }
            //}
            //if (color == "blanco")
            //{
            //    for (int i = 0; i < casilla.Length; i++)
            //    {
            //        if (casilla[i].CssClass == "btn btn-light btn-lg border-dark rounded-0")
            //        {
            //            permitido = true;
            //            indice = i;
            //            break;
            //        }
            //    }
            //}
            //if (permitido == true)
            //    return indice;
            //else
            return -1;
        }

        public int verificar2(WebControl[] casilla, string color, int clic)
        {
            bool permitido = false;
            int indice = -1;
            if (color == "negro")
            {
                if (clic < casilla.Length && casilla.Length != 1)
                {
                    if (permitido == false)
                    {
                        for (int i = 0; i < clic; i++)
                        {
                            if (casilla[i].CssClass == "btn btn-dark btn-lg border-dark rounded-0")
                            {
                                permitido = true;
                                indice = i;
                                //break;
                            }
                        }
                }
                    if (permitido == false || verVacio(casilla, clic, indice) == false) 
                    { 
                        for (int i = clic+1; i < casilla.Length; i++)
                        {
                            if (casilla[i].CssClass == "btn btn-dark btn-lg border-dark rounded-0")
                            {
                                permitido = true;
                                indice = i;
                                //Response.Write(indice+"indice");
                                break;
                            }
                        }
                    }
                }
            }
            if (color == "blanco")
            {
                if (clic < casilla.Length && casilla.Length != 1)
                {
                    if (permitido == false && clic != 1)
                    {
                        for (int i = 0; i < clic; i++)
                        {
                            if (casilla[i].CssClass == "btn btn-light btn-lg border-dark rounded-0")
                            {
                                permitido = true;
                                indice = i;
                                //break;
                            }
                        }
                    }
                    if (permitido == false || verVacio(casilla, clic, indice) == false)
                    {
                        for (int i = clic+1; i < casilla.Length; i++)
                        {
                            if (casilla[i].CssClass == "btn btn-light btn-lg border-dark rounded-0")
                            {
                                permitido = true;
                                indice = i;
                                break;
                            }
                        }
                    }
                }
            }
            if (permitido == true)
            {
                Response.Write(indice + "indice de verif2");
                return indice;
            }
            else
                return -1;
        }

        public void comerFicha(WebControl[] casilla, string color, int clic, int index)
        {
            if (index == -1)
            {
                //turno.BackColor = System.Drawing.Color.Red;
            }
            //Response.Write(fichaAlApar(casilla, color, index));
            //Response.Write(clic);
            if (fichaAlApar(casilla, color, clic))
            {
                if (index != -1)
                {
                    if (verVacio(casilla, clic, index) == true ) //|| verVacio(casilla, clic, index) == true)
                    {
                        try
                        {
                            if (color == "negro")
                            {
                                if (index < clic)
                                {
                                    for (int i = index; i <= clic; i++)
                                    {
                                        casilla[i].CssClass = "btn btn-dark btn-lg border-dark rounded-0";
                                    }
                                }
                                if (index > clic)
                                {
                                    for (int i = clic; i <= index; i++)
                                    {
                                        casilla[i].CssClass = "btn btn-dark btn-lg border-dark rounded-0";
                                    }
                                }
                                turno.Text = "Blanco";
                                turno.ForeColor = Color.White;
                            }
                            if (color == "blanco")
                            {

                                if (index < clic)
                                {
                                    for (int i = index; i <= clic; i++)
                                    {
                                        casilla[i].CssClass = "btn btn-light btn-lg border-dark rounded-0";
                                    }
                                }
                                if (index > clic)
                                {
                                    //Response.Write(clic + "hasta" + index+"en"+casilla);
                                    for (int i = clic; i <= index; i++)
                                    {
                                        Response.Write(i + "hasta" +casilla[i]);
                                        casilla[i].CssClass = "btn btn-light btn-lg border-dark rounded-0";
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

        public void comerFicha2(WebControl[] columna, string colorCol, int clicCol, int indexCol, WebControl[] fila, string colorFil, int clicFil, int indexFil, WebControl[] diagPos, string colorDiagPos, int clicDiagPos, int indexDiagPos, WebControl[] diagNeg, string colorDiagNeg, int clicDiagNeg, int indexDiagNeg)
        {
            WebControl[][] recta = { columna, fila, diagPos, diagNeg };
            String[] colores = { colorCol, colorFil, colorDiagPos, colorDiagNeg };
            int[] clics = { clicCol, clicFil, clicDiagPos, clicDiagNeg };
            int[] indeces = { indexCol, indexFil, indexDiagPos, indexDiagNeg };
            for (int a = 0; a < recta.Length; a++)
            {
                for (int j = 0; j < recta[a].Length; j++)
                {
                    if (fichaAlApar(recta[a], colores[a], clics[a]))
                    {
                        if (indeces[a] != -1)
                        {
                            if (verVacio(recta[a], clics[a] + 1, indeces[a]) == true || verVacio(recta[a], clics[a] - 1, indeces[a]) == true)
                            {
                                try
                                {

                                    if (colores[a] == "negro" && recta[a][clics[a]].CssClass != "btn btn-dark btn-lg border-dark rounded-0")
                                    {
                                        if (indeces[a] < clics[a])
                                        {
                                            for (int i = indeces[a]; i <= clics[a]; i++)
                                            {
                                                recta[a][i].CssClass = "btn btn-dark btn-lg border-dark rounded-0";
                                            }
                                        }
                                        if (indeces[a] > clics[a])
                                        {
                                            for (int i = clics[a]; i <= indeces[a]; i++)
                                            {
                                                recta[a][i].CssClass = "btn btn-dark btn-lg border-dark rounded-0";
                                            }
                                        }
                                        turno.Text = "Blanco";
                                        turno.ForeColor = Color.White;
                                    }
                                    if (colores[a] == "blanco" && recta[a][clics[a]].CssClass != "btn btn-light btn-lg border-dark rounded-0")
                                    {

                                        if (indeces[a] < clics[a])
                                        {
                                            for (int i = indeces[a]; i <= clics[a]; i++)
                                            {
                                                recta[a][i].CssClass = "btn btn-light btn-lg border-dark rounded-0";
                                            }
                                        }
                                        if (indeces[a] > clics[a])
                                        {
                                            for (int i = clics[a]; i <= indeces[a]; i++)
                                            {
                                                recta[a][i].CssClass = "btn btn-light btn-lg border-dark rounded-0";
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
            }
        }

        public bool verVacio(WebControl[] casilla, int clic, int index)
        {
            bool permitido = true;
            if (index != -1 && clic != 0 && clic <casilla.Length)
            {
                try
                {
                    if (index < clic)
                    {
                        for (int i = index; i < clic; i++)
                        {
                            if (casilla[i].CssClass == "btn btn-success btn-lg border-dark rounded-0") { permitido = false; break; }
                        }
                    }
                    if (index > clic)
                    {
                        Response.Write(index + "index");
                        for (int i = clic+1; i <= index; i++)
                        {
                            if (casilla[i].CssClass == "btn btn-success btn-lg border-dark rounded-0") { permitido = false; break; }
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    permitido = false;
                }
            }
            if (clic == 0 && casilla.Length>1)
            {
                Response.Write("hola"+index);
                for (int i = clic+1; i <= index; i++)
                {
                    if (casilla[i].CssClass == "btn btn-success btn-lg border-dark rounded-0") { permitido = false; break; }
                }
            }
            if (clic +1 >= casilla.Length && casilla.Length > 1)//mmm
            {
                for (int i = index; i < clic; i++)
                {
                    if (casilla[i].CssClass == "btn btn-success btn-lg border-dark rounded-0") { permitido = false; break; }
                }
            }
            Response.Write(permitido + "permitido por espacio verde");
            return permitido;
        }

        public void a1_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colA"), "negro", 0, verificar2(tipo("colB"), "negro",0));
                comerFicha(tipo("fila1"), "negro", 0, verificar2(tipo("fila1"), "negro",0));
                comerFicha(tipo("diagPos1"), "negro", 0, verificar2(tipo("diagPos2"), "negro",0));
                comerFicha(tipo("diagNeg8"), "negro", 0, verificar2(tipo("diagNeg7"), "negro",0));
            }
            else
            {
                comerFicha(tipo("colA"), "blanco", 0, verificar2(tipo("colB"), "blanco", 0));
                comerFicha(tipo("fila1"), "blanco", 0, verificar2(tipo("fila1"), "blanco", 0));
                comerFicha(tipo("diagPos1"), "blanco", 0, verificar2(tipo("diagPos2"), "blanco", 0));
                comerFicha(tipo("diagNeg8"), "blanco", 0, verificar2(tipo("diagNeg7"), "blanco", 0));
            }
            Get_Score();
        }

        public void b1_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colB"), "negro", 0, verificar2(tipo("colB"), "negro", 1));
                comerFicha(tipo("fila1"), "negro", 1, verificar2(tipo("fila1"), "negro", 1));
                comerFicha(tipo("diagPos2"), "negro", 1, verificar2(tipo("diagPos2"), "negro", 1));
                comerFicha(tipo("diagNeg7"), "negro", 0, verificar2(tipo("diagNeg7"), "negro", 0));
            }
            else
            {
                comerFicha(tipo("colB"), "blanco", 0, verificar2(tipo("colB"), "blanco", 0));
                comerFicha(tipo("fila1"), "blanco", 1, verificar2(tipo("fila1"), "blanco", 1));
                comerFicha(tipo("diagPos2"), "blanco", 1, verificar2(tipo("diagPos2"), "blanco", 1));
                comerFicha(tipo("diagNeg7"), "blanco", 0, verificar2(tipo("diagNeg7"), "blanco", 0));
            }
            Get_Score();
        }

        protected void c1_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colC"), "negro", 0, verificar2(tipo("colC"), "negro", 0));
                comerFicha(tipo("fila1"), "negro", 2, verificar2(tipo("fila1"), "negro", 2));
                comerFicha(tipo("diagPos3"), "negro", 2, verificar2(tipo("diagPos3"), "negro", 2));
                comerFicha(tipo("diagNeg6"), "negro", 0, verificar2(tipo("diagNeg6"), "negro", 0));
            }
            else
            {
                comerFicha(tipo("colC"), "blanco", 0, verificar2(tipo("colC"), "blanco", 0));
                comerFicha(tipo("fila1"), "blanco", 2, verificar2(tipo("fila1"), "blanco", 2));
                comerFicha(tipo("diagPos3"), "blanco", 2, verificar2(tipo("diagPos3"), "blanco", 2));
                comerFicha(tipo("diagNeg6"), "blanco", 0, verificar2(tipo("diagNeg6"), "blanco", 0));
            }
            Get_Score();
        }

        protected void d1_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colD"), "negro", 0, verificar2(tipo("colD"), "negro", 0));
                comerFicha(tipo("fila1"), "negro", 3, verificar2(tipo("fila1"), "negro", 3));
                comerFicha(tipo("diagPos4"), "negro", 3, verificar2(tipo("diagPos4"), "negro", 3));
                comerFicha(tipo("diagNeg5"), "negro", 0, verificar2(tipo("diagNeg5"), "negro", 0));
            }
            else
            {
                comerFicha(tipo("colD"), "blanco", 0, verificar2(tipo("colD"), "blanco", 0));
                comerFicha(tipo("fila1"), "blanco", 3, verificar2(tipo("fila1"), "blanco", 3));
                comerFicha(tipo("diagPos4"), "blanco", 3, verificar2(tipo("diagPos4"), "blanco", 3));
                comerFicha(tipo("diagNeg5"), "blanco", 0, verificar2(tipo("diagNeg5"), "blanco", 0));
            }
            Get_Score();
        }

        protected void e1_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colE"), "negro", 0, verificar2(tipo("colE"), "negro", 0));
                comerFicha(tipo("fila1"), "negro", 4, verificar2(tipo("fila1"), "negro", 4));
                comerFicha(tipo("diagPos5"), "negro", 4, verificar2(tipo("diagPos5"), "negro", 4));
                comerFicha(tipo("diagNeg4"), "negro", 0, verificar2(tipo("diagNeg4"), "negro", 0));
            }
            else
            {
                comerFicha(tipo("colE"), "blanco", 0, verificar2(tipo("colE"), "blanco", 0));
                comerFicha(tipo("fila1"), "blanco", 4, verificar2(tipo("fila1"), "blanco", 4));
                comerFicha(tipo("diagPos5"), "blanco", 4, verificar2(tipo("diagPos5"), "blanco", 4));
                comerFicha(tipo("diagNeg4"), "blanco", 0, verificar2(tipo("diagNeg4"), "blanco", 0));
            }
            Get_Score();
        }

        protected void f1_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colF"), "negro", 0, verificar2(tipo("colF"), "negro", 0));
                comerFicha(tipo("fila1"), "negro", 5, verificar2(tipo("fila1"), "negro", 5));
                comerFicha(tipo("diagPos6"), "negro", 5, verificar2(tipo("diagPos6"), "negro", 5));
                comerFicha(tipo("diagNeg3"), "negro", 0, verificar2(tipo("diagNeg3"), "negro", 0));
            }
            else
            {
                comerFicha(tipo("colF"), "blanco", 0, verificar2(tipo("colF"), "blanco", 0));
                comerFicha(tipo("fila1"), "blanco", 5, verificar2(tipo("fila1"), "blanco", 5));
                comerFicha(tipo("diagPos6"), "blanco", 5, verificar2(tipo("diagPos6"), "blanco", 5));
                comerFicha(tipo("diagNeg3"), "blanco", 0, verificar2(tipo("diagNeg3"), "blanco", 0));
            }
            Get_Score();
        }

        protected void g1_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colG"), "negro", 0, verificar2(tipo("colG"), "negro", 0));
                comerFicha(tipo("fila1"), "negro", 6, verificar2(tipo("fila1"), "negro", 6));
                comerFicha(tipo("diagPos7"), "negro", 6, verificar2(tipo("diagPos7"), "negro", 6));
                comerFicha(tipo("diagNeg2"), "negro", 0, verificar2(tipo("diagNeg2"), "negro", 0));
            }
            else
            {
                comerFicha(tipo("colG"), "blanco", 0, verificar2(tipo("colG"), "blanco", 0));
                comerFicha(tipo("fila1"), "blanco", 6, verificar2(tipo("fila1"), "blanco", 6));
                comerFicha(tipo("diagPos7"), "blanco", 6, verificar2(tipo("diagPos7"), "blanco", 6));
                comerFicha(tipo("diagNeg2"), "blanco", 0, verificar2(tipo("diagNeg2"), "blanco", 0));
            }
            Get_Score();
        }

        protected void h1_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colH"), "negro", 0, verificar2(tipo("colH"), "negro", 0));
                comerFicha(tipo("fila1"), "negro", 7, verificar2(tipo("fila1"), "negro", 7));
                comerFicha(tipo("diagPos8"), "negro", 7, verificar2(tipo("diagPos8"), "negro", 7));
                comerFicha(tipo("diagNeg1"), "negro", 0, verificar2(tipo("diagNeg1"), "negro", 0));
            }
            else
            {
                comerFicha(tipo("colH"), "blanco", 0, verificar2(tipo("colH"), "blanco", 0));
                comerFicha(tipo("fila1"), "blanco", 7, verificar2(tipo("fila1"), "blanco", 7));
                comerFicha(tipo("diagPos8"), "blanco", 7, verificar2(tipo("diagPos8"), "blanco", 7));
                comerFicha(tipo("diagNeg1"), "blanco", 0, verificar2(tipo("diagNeg1"), "blanco", 0));
            }
            Get_Score();
        }

        protected void a2_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colA"), "negro", 1, verificar2(tipo("colA"), "negro", 1));
                comerFicha(tipo("fila2"), "negro", 0, verificar2(tipo("fila2"), "negro", 0));
                comerFicha(tipo("diagPos2"), "negro", 0, verificar2(tipo("diagPos2"), "negro", 0));
                comerFicha(tipo("diagNeg9"), "negro", 0, verificar2(tipo("diagNeg9"), "negro", 0));
            }
            else
            {
                comerFicha(tipo("colA"), "blanco", 1, verificar2(tipo("colA"), "blanco", 1));
                comerFicha(tipo("fila2"), "blanco", 0, verificar2(tipo("fila2"), "blanco", 0));
                comerFicha(tipo("diagPos2"), "blanco", 0, verificar2(tipo("diagPos2"), "blanco", 0));
                comerFicha(tipo("diagNeg9"), "blanco", 0, verificar2(tipo("diagNeg9"), "blanco", 0));
            }
            Get_Score();
        }

        protected void b2_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colB"), "negro", 1, verificar2(tipo("colB"), "negro", 1));
                comerFicha(tipo("fila2"), "negro", 1, verificar2(tipo("fila2"), "negro", 1));
                comerFicha(tipo("diagPos3"), "negro", 1, verificar2(tipo("diagPos3"), "negro", 1));
                comerFicha(tipo("diagNeg8"), "negro", 1, verificar2(tipo("diagNeg8"), "negro", 1));
            }
            else
            {
                comerFicha(tipo("colB"), "blanco", 1, verificar2(tipo("colB"), "blanco", 1));
                comerFicha(tipo("fila2"), "blanco", 1, verificar2(tipo("fila2"), "blanco", 1));
                comerFicha(tipo("diagPos3"), "blanco", 1, verificar2(tipo("diagPos3"), "blanco", 1));
                comerFicha(tipo("diagNeg8"), "blanco", 1, verificar2(tipo("diagNeg8"), "blanco", 1));
            }
            Get_Score();
        }

        protected void c2_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colC"), "negro", 1, verificar2(tipo("colC"), "negro", 1));
                comerFicha(tipo("fila2"), "negro", 2, verificar2(tipo("fila2"), "negro", 2));
                comerFicha(tipo("diagPos4"), "negro", 2, verificar2(tipo("diagPos4"), "negro", 2));
                comerFicha(tipo("diagNeg7"), "negro", 1, verificar2(tipo("diagNeg7"), "negro", 1));
            }
            else
            {
                comerFicha(tipo("colC"), "blanco", 1, verificar2(tipo("colC"), "blanco", 1));
                comerFicha(tipo("fila2"), "blanco", 2, verificar2(tipo("fila2"), "blanco", 2));
                comerFicha(tipo("diagPos4"), "blanco", 2, verificar2(tipo("diagPos4"), "blanco", 2));
                comerFicha(tipo("diagNeg7"), "blanco", 1, verificar2(tipo("diagNeg7"), "blanco", 1));
            }
            Get_Score();
        }

        protected void d2_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colD"), "negro", 1, verificar2(tipo("colD"), "negro", 1));
                comerFicha(tipo("fila2"), "negro", 3, verificar2(tipo("fila2"), "negro", 3));
                comerFicha(tipo("diagPos5"), "negro", 3, verificar2(tipo("diagPos5"), "negro", 3));
                comerFicha(tipo("diagNeg6"), "negro", 1, verificar2(tipo("diagNeg6"), "negro", 1));
            }
            else
            {
                comerFicha(tipo("colD"), "blanco", 1, verificar2(tipo("colD"), "blanco", 1));
                comerFicha(tipo("fila2"), "blanco", 3, verificar2(tipo("fila2"), "blanco", 3));
                comerFicha(tipo("diagPos5"), "blanco", 3, verificar2(tipo("diagPos5"), "blanco", 3));
                comerFicha(tipo("diagNeg6"), "blanco", 1, verificar2(tipo("diagNeg6"), "blanco", 1));
            }
            Get_Score();
        }

        protected void e2_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colE"), "negro", 1, verificar2(tipo("colE"), "negro", 1));
                comerFicha(tipo("fila2"), "negro", 4, verificar2(tipo("fila2"), "negro", 4));
                comerFicha(tipo("diagPos6"), "negro", 4, verificar2(tipo("diagPos6"), "negro", 4));
                comerFicha(tipo("diagNeg5"), "negro", 1, verificar2(tipo("diagNeg5"), "negro", 1));
            }
            else
            {
                comerFicha(tipo("colE"), "blanco", 1, verificar2(tipo("colE"), "blanco", 1));
                comerFicha(tipo("fila2"), "blanco", 4, verificar2(tipo("fila2"), "blanco", 4));
                comerFicha(tipo("diagPos6"), "blanco", 4, verificar2(tipo("diagPos6"), "blanco", 4));
                comerFicha(tipo("diagNeg5"), "blanco", 1, verificar2(tipo("diagNeg5"), "blanco", 1));
            }
            Get_Score();
        }

        protected void f2_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colF"), "negro", 1, verificar2(tipo("colF"), "negro", 1));
                comerFicha(tipo("fila2"), "negro", 5, verificar2(tipo("fila2"), "negro", 5));
                comerFicha(tipo("diagPos7"), "negro", 5, verificar2(tipo("diagPos7"), "negro", 5));
                comerFicha(tipo("diagNeg4"), "negro", 1, verificar2(tipo("diagNeg4"), "negro", 1));
            }
            else
            {
                comerFicha(tipo("colF"), "blanco", 1, verificar2(tipo("colF"), "blanco", 1));
                comerFicha(tipo("fila2"), "blanco", 5, verificar2(tipo("fila2"), "blanco", 5));
                comerFicha(tipo("diagPos7"), "blanco", 5, verificar2(tipo("diagPos7"), "blanco", 5));
                comerFicha(tipo("diagNeg4"), "blanco", 1, verificar2(tipo("diagNeg4"), "blanco", 1));
            }
            Get_Score();
        }

        protected void g2_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colG"), "negro", 1, verificar2(tipo("colG"), "negro", 1));
                comerFicha(tipo("fila2"), "negro", 6, verificar2(tipo("fila2"), "negro", 6));
                comerFicha(tipo("diagPos8"), "negro", 6, verificar2(tipo("diagPos8"), "negro", 6));
                comerFicha(tipo("diagNeg3"), "negro", 1, verificar2(tipo("diagNeg3"), "negro", 1));
            }
            else
            {
                comerFicha(tipo("colG"), "blanco", 1, verificar2(tipo("colG"), "blanco", 1));
                comerFicha(tipo("fila2"), "blanco", 6, verificar2(tipo("fila2"), "blanco", 6));
                comerFicha(tipo("diagPos8"), "blanco", 6, verificar2(tipo("diagPos8"), "blanco", 6));
                comerFicha(tipo("diagNeg3"), "blanco", 1, verificar2(tipo("diagNeg3"), "blanco", 1));
            }
            Get_Score();
        }

        protected void h2_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colH"), "negro", 1, verificar2(tipo("colH"), "negro", 1));
                comerFicha(tipo("fila2"), "negro", 7, verificar2(tipo("fila2"), "negro", 7));
                comerFicha(tipo("diagPos9"), "negro", 6, verificar2(tipo("diagPos9"), "negro", 6));
                comerFicha(tipo("diagNeg2"), "negro", 1, verificar2(tipo("diagNeg2"), "negro", 1));
            }
            else
            {
                comerFicha(tipo("colH"), "blanco", 1, verificar2(tipo("colH"), "blanco", 1));
                comerFicha(tipo("fila2"), "blanco", 7, verificar2(tipo("fila2"), "blanco", 7));
                comerFicha(tipo("diagPos9"), "blanco", 6, verificar2(tipo("diagPos9"), "blanco", 6));
                comerFicha(tipo("diagNeg2"), "blanco", 1, verificar2(tipo("diagNeg2"), "blanco", 1));
            }
            Get_Score();
        }

        protected void a3_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colA"), "negro", 2, verificar2(tipo("colA"), "negro", 2));
                comerFicha(tipo("fila3"), "negro", 0, verificar2(tipo("fila3"), "negro", 0));
                comerFicha(tipo("diagPos3"), "negro", 0, verificar2(tipo("diagPos3"), "negro", 0));
                comerFicha(tipo("diagNeg10"), "negro", 0, verificar2(tipo("diagNeg10"), "negro", 0));
            }
            else
            {
                comerFicha(tipo("colA"), "blanco", 2, verificar2(tipo("colA"), "blanco", 2));
                comerFicha(tipo("fila3"), "blanco", 0, verificar2(tipo("fila3"), "blanco", 0));
                comerFicha(tipo("diagPos3"), "blanco", 0, verificar2(tipo("diagPos3"), "blanco", 0));
                comerFicha(tipo("diagNeg10"), "blanco", 0, verificar2(tipo("diagNeg10"), "blanco", 0));
            }
            Get_Score();
        }

        protected void b3_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colB"), "negro", 2, verificar2(tipo("colB"), "negro", 2));
                comerFicha(tipo("fila3"), "negro", 1, verificar2(tipo("fila3"), "negro", 1));
                comerFicha(tipo("diagPos4"), "negro", 1, verificar2(tipo("diagPos4"), "negro", 1));
                comerFicha(tipo("diagNeg9"), "negro", 1, verificar2(tipo("diagNeg9"), "negro", 1));
            }
            else
            {
                comerFicha(tipo("colB"), "blanco", 2, verificar2(tipo("colB"), "blanco", 2));
                comerFicha(tipo("fila3"), "blanco", 1, verificar2(tipo("fila3"), "blanco", 1));
                comerFicha(tipo("diagPos4"), "blanco", 1, verificar2(tipo("diagPos4"), "blanco", 1));
                comerFicha(tipo("diagNeg9"), "blanco", 1, verificar2(tipo("diagNeg9"), "blanco", 1));
            }
            Get_Score();
        }

        protected void c3_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colC"), "negro", 2, verificar2(tipo("colC"), "negro", 2));
                comerFicha(tipo("fila3"), "negro", 2, verificar2(tipo("fila3"), "negro", 2));
                comerFicha(tipo("diagPos5"), "negro", 2, verificar2(tipo("diagPos5"), "negro", 2));
                comerFicha(tipo("diagNeg8"), "negro", 2, verificar2(tipo("diagNeg8"), "negro", 2));
            }
            else
            {
                comerFicha(tipo("colC"), "blanco", 2, verificar2(tipo("colC"), "blanco", 2));
                comerFicha(tipo("fila3"), "blanco", 2, verificar2(tipo("fila3"), "blanco", 2));
                comerFicha(tipo("diagPos5"), "blanco", 2, verificar2(tipo("diagPos5"), "blanco", 2));
                comerFicha(tipo("diagNeg8"), "blanco", 2, verificar2(tipo("diagNeg8"), "blanco", 2));
            }
            Get_Score();
        }

        protected void d3_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colD"), "negro", 2, verificar2(tipo("colD"), "negro", 2));
                comerFicha(tipo("fila3"), "negro", 3, verificar2(tipo("fila3"), "negro", 3));
                comerFicha(tipo("diagPos6"), "negro", 3, verificar2(tipo("diagPos6"), "negro", 3));
                comerFicha(tipo("diagNeg7"), "negro", 2, verificar2(tipo("diagNeg7"), "negro", 2));
            }
            else
            {
                comerFicha(tipo("colD"), "blanco", 2, verificar2(tipo("colD"), "blanco", 2));
                comerFicha(tipo("fila3"), "blanco", 3, verificar2(tipo("fila3"), "blanco", 3));
                comerFicha(tipo("diagPos6"), "blanco", 3, verificar2(tipo("diagPos6"), "blanco", 3));
                comerFicha(tipo("diagNeg7"), "blanco", 2, verificar2(tipo("diagNeg7"), "blanco", 2));
            }
            Get_Score();
        }

        protected void e3_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colE"), "negro", 2, verificar2(tipo("colE"), "negro", 2));
                comerFicha(tipo("fila3"), "negro", 4, verificar2(tipo("fila3"), "negro", 4));
                comerFicha(tipo("diagPos7"), "negro", 4, verificar2(tipo("diagPos7"), "negro", 4));
                comerFicha(tipo("diagNeg6"), "negro", 2, verificar2(tipo("diagNeg6"), "negro", 2));
            }
            else
            {
                comerFicha(tipo("colE"), "blanco", 2, verificar2(tipo("colE"), "blanco", 2));
                comerFicha(tipo("fila3"), "blanco", 4, verificar2(tipo("fila3"), "blanco", 4));
                comerFicha(tipo("diagPos7"), "blanco", 4, verificar2(tipo("diagPos7"), "blanco", 4));
                comerFicha(tipo("diagNeg6"), "blanco", 2, verificar2(tipo("diagNeg6"), "blanco", 2));
            }
            Get_Score();
        }

        protected void f3_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colF"), "negro", 2, verificar2(tipo("colF"), "negro", 2));
                comerFicha(tipo("fila3"), "negro", 5, verificar2(tipo("fila3"), "negro", 5));
                comerFicha(tipo("diagPos8"), "negro", 5, verificar2(tipo("diagPos8"), "negro", 5));
                comerFicha(tipo("diagNeg5"), "negro", 2, verificar2(tipo("diagNeg5"), "negro", 2));
            }
            else
            {
                comerFicha(tipo("colF"), "blanco", 2, verificar2(tipo("colF"), "blanco", 2));
                comerFicha(tipo("fila3"), "blanco", 5, verificar2(tipo("fila3"), "blanco", 5));
                comerFicha(tipo("diagPos8"), "blanco", 5, verificar2(tipo("diagPos8"), "blanco", 5));
                comerFicha(tipo("diagNeg5"), "blanco", 2, verificar2(tipo("diagNeg5"), "blanco", 2));
            }
            Get_Score();
        }

        protected void g3_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colG"), "negro", 2, verificar2(tipo("colG"), "negro", 2));
                comerFicha(tipo("fila3"), "negro", 6, verificar2(tipo("fila3"), "negro", 6));
                comerFicha(tipo("diagPos9"), "negro", 5, verificar2(tipo("diagPos9"), "negro", 5));
                comerFicha(tipo("diagNeg4"), "negro", 2, verificar2(tipo("diagNeg4"), "negro", 2));
            }
            else
            {
                comerFicha(tipo("colG"), "blanco", 2, verificar2(tipo("colG"), "blanco", 2));
                comerFicha(tipo("fila3"), "blanco", 6, verificar2(tipo("fila3"), "blanco", 6));
                comerFicha(tipo("diagPos9"), "blanco", 5, verificar2(tipo("diagPos9"), "blanco", 5));
                comerFicha(tipo("diagNeg4"), "blanco", 2, verificar2(tipo("diagNeg4"), "blanco", 2));
            }
            Get_Score();
        }

        protected void h3_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colH"), "negro", 2, verificar2(tipo("colH"), "negro", 2));
                comerFicha(tipo("fila3"), "negro", 7, verificar2(tipo("fila3"), "negro", 7));
                comerFicha(tipo("diagPos10"), "negro", 5, verificar2(tipo("diagPos10"), "negro", 5));
                comerFicha(tipo("diagNeg3"), "negro", 2, verificar2(tipo("diagNeg3"), "negro", 2));
            }
            else
            {
                comerFicha(tipo("colH"), "blanco", 2, verificar2(tipo("colH"), "blanco", 2));
                comerFicha(tipo("fila3"), "blanco", 7, verificar2(tipo("fila3"), "blanco", 7));
                comerFicha(tipo("diagPos10"), "blanco", 5, verificar2(tipo("diagPos10"), "blanco", 5));
                comerFicha(tipo("diagNeg3"), "blanco", 2, verificar2(tipo("diagNeg3"), "blanco", 2));
            }
            Get_Score();
        }

        protected void a4_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colA"), "negro", 3, verificar2(tipo("colA"), "negro", 3));
                comerFicha(tipo("fila4"), "negro", 0, verificar2(tipo("fila4"), "negro", 0));
                comerFicha(tipo("diagPos4"), "negro", 0, verificar2(tipo("diagPos4"), "negro", 0));
                comerFicha(tipo("diagNeg11"), "negro", 0, verificar2(tipo("diagNeg11"), "negro", 0));
            }
            else
            {
                comerFicha(tipo("colA"), "blanco", 3, verificar2(tipo("colA"), "blanco", 3));
                comerFicha(tipo("fila4"), "blanco", 0, verificar2(tipo("fila4"), "blanco", 0));
                comerFicha(tipo("diagPos4"), "blanco", 0, verificar2(tipo("diagPos4"), "blanco", 0));
                comerFicha(tipo("diagNeg11"), "blanco", 0, verificar2(tipo("diagNeg11"), "blanco", 0));
            }
            Get_Score();
        }
        protected void b4_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colB"), "negro", 3, verificar2(tipo("colB"), "negro", 3));
                comerFicha(tipo("fila4"), "negro", 1, verificar2(tipo("fila4"), "negro", 1));
                comerFicha(tipo("diagPos5"), "negro", 1, verificar2(tipo("diagPos5"), "negro", 1));
                comerFicha(tipo("diagNeg10"), "negro", 1, verificar2(tipo("diagNeg10"), "negro", 1));
            }
            else
            {
                comerFicha(tipo("colB"), "blanco", 3, verificar2(tipo("colB"), "blanco", 3));
                comerFicha(tipo("fila4"), "blanco", 1, verificar2(tipo("fila4"), "blanco", 1));
                comerFicha(tipo("diagPos5"), "blanco", 1, verificar2(tipo("diagPos5"), "blanco", 1));
                comerFicha(tipo("diagNeg10"), "blanco", 1, verificar2(tipo("diagNeg10"), "blanco", 1));
            }
            Get_Score();
        }

        protected void c4_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colC"), "negro", 3, verificar2(tipo("colC"), "negro", 3));
                comerFicha(tipo("fila4"), "negro", 2, verificar2(tipo("fila4"), "negro", 2));
                comerFicha(tipo("diagPos6"), "negro", 2, verificar2(tipo("diagPos6"), "negro", 2));
                comerFicha(tipo("diagNeg9"), "negro", 2, verificar2(tipo("diagNeg9"), "negro", 2));
            }
            else
            {
                comerFicha(tipo("colC"), "blanco", 3, verificar2(tipo("colC"), "blanco", 3));
                comerFicha(tipo("fila4"), "blanco", 2, verificar2(tipo("fila4"), "blanco", 2));
                comerFicha(tipo("diagPos6"), "blanco", 2, verificar2(tipo("diagPos6"), "blanco", 2));
                comerFicha(tipo("diagNeg9"), "blanco", 2, verificar2(tipo("diagNeg9"), "blanco", 2));
            }
            Get_Score();
        }

        protected void d4_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colD"), "negro", 3, verificar2(tipo("colD"), "negro", 3));
                comerFicha(tipo("fila4"), "negro", 3, verificar2(tipo("fila4"), "negro", 3));
                comerFicha(tipo("diagPos7"), "negro", 3, verificar2(tipo("diagPos7"), "negro", 3));
                comerFicha(tipo("diagNeg8"), "negro", 3, verificar2(tipo("diagNeg8"), "negro", 3));
            }
            else
            {
                comerFicha(tipo("colD"), "blanco", 3, verificar2(tipo("colD"), "blanco", 3));
                comerFicha(tipo("fila4"), "blanco", 3, verificar2(tipo("fila4"), "blanco", 3));
                comerFicha(tipo("diagPos7"), "blanco", 3, verificar2(tipo("diagPos7"), "blanco", 3));
                comerFicha(tipo("diagNeg8"), "blanco", 3, verificar2(tipo("diagNeg8"), "blanco", 3));
            }
            Get_Score();
        }

        protected void e4_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colE"), "negro", 3, verificar2(tipo("colE"), "negro", 3));
                comerFicha(tipo("fila4"), "negro", 4, verificar2(tipo("fila4"), "negro", 4));
                comerFicha(tipo("diagPos8"), "negro", 4, verificar2(tipo("diagPos8"), "negro", 4));
                comerFicha(tipo("diagNeg7"), "negro", 3, verificar2(tipo("diagNeg7"), "negro", 3));
            }
            else
            {
                comerFicha(tipo("colE"), "blanco", 3, verificar2(tipo("colE"), "blanco", 3));
                comerFicha(tipo("fila4"), "blanco", 4, verificar2(tipo("fila4"), "blanco", 4));
                comerFicha(tipo("diagPos8"), "blanco", 4, verificar2(tipo("diagPos8"), "blanco", 4));
                comerFicha(tipo("diagNeg7"), "blanco", 3, verificar2(tipo("diagNeg7"), "blanco", 3));
            }
            Get_Score();
        }

        protected void f4_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colF"), "negro", 3, verificar2(tipo("colF"), "negro", 3));
                comerFicha(tipo("fila4"), "negro", 5, verificar2(tipo("fila4"), "negro", 5));
                comerFicha(tipo("diagPos9"), "negro", 4, verificar2(tipo("diagPos9"), "negro", 4));
                comerFicha(tipo("diagNeg6"), "negro", 3, verificar2(tipo("diagNeg6"), "negro", 3));
            }
            else
            {
                comerFicha(tipo("colF"), "blanco", 3, verificar2(tipo("colF"), "blanco", 3));
                comerFicha(tipo("fila4"), "blanco", 5, verificar2(tipo("fila4"), "blanco", 5));
                comerFicha(tipo("diagPos9"), "blanco", 4, verificar2(tipo("diagPos9"), "blanco", 4));
                comerFicha(tipo("diagNeg6"), "blanco", 3, verificar2(tipo("diagNeg6"), "blanco", 3));
            }
            Get_Score();
        }

        protected void g4_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colG"), "negro", 3, verificar2(tipo("colG"), "negro", 3));
                comerFicha(tipo("fila4"), "negro", 6, verificar2(tipo("fila4"), "negro", 6));
                comerFicha(tipo("diagPos10"), "negro", 4, verificar2(tipo("diagPos10"), "negro", 4));
                comerFicha(tipo("diagNeg5"), "negro", 3, verificar2(tipo("diagNeg5"), "negro", 3));
            }
            else
            {
                comerFicha(tipo("colG"), "blanco", 3, verificar2(tipo("colG"), "blanco", 3));
                comerFicha(tipo("fila4"), "blanco", 6, verificar2(tipo("fila4"), "blanco", 6));
                comerFicha(tipo("diagPos10"), "blanco", 4, verificar2(tipo("diagPos10"), "blanco", 4));
                comerFicha(tipo("diagNeg5"), "blanco", 3, verificar2(tipo("diagNeg5"), "blanco", 3));
            }
            Get_Score();
        }

        protected void h4_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colH"), "negro", 3, verificar2(tipo("colH"), "negro", 3));
                comerFicha(tipo("fila4"), "negro", 7, verificar2(tipo("fila4"), "negro", 7));
                comerFicha(tipo("diagPos11"), "negro", 4, verificar2(tipo("diagPos11"), "negro", 4));
                comerFicha(tipo("diagNeg4"), "negro", 3, verificar2(tipo("diagNeg4"), "negro", 3));
            }
            else
            {
                comerFicha(tipo("colH"), "blanco", 3, verificar2(tipo("colH"), "blanco", 3));
                comerFicha(tipo("fila4"), "blanco", 7, verificar2(tipo("fila4"), "blanco", 7));
                comerFicha(tipo("diagPos11"), "blanco", 4, verificar2(tipo("diagPos11"), "blanco", 4));
                comerFicha(tipo("diagNeg4"), "blanco", 3, verificar2(tipo("diagNeg4"), "blanco", 3));
            }
            Get_Score();
        }

        protected void a5_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colA"), "negro", 4, verificar2(tipo("colA"), "negro", 4));
                comerFicha(tipo("fila5"), "negro", 0, verificar2(tipo("fila5"), "negro", 0));
                comerFicha(tipo("diagPos5"), "negro", 0, verificar2(tipo("diagPos5"), "negro", 0));
                comerFicha(tipo("diagNeg12"), "negro", 0, verificar2(tipo("diagNeg12"), "negro", 0));
            }
            else
            {
                comerFicha(tipo("colA"), "blanco", 4, verificar2(tipo("colA"), "blanco", 4));
                comerFicha(tipo("fila5"), "blanco", 0, verificar2(tipo("fila5"), "blanco", 0));
                comerFicha(tipo("diagPos5"), "blanco", 0, verificar2(tipo("diagPos5"), "blanco", 0));
                comerFicha(tipo("diagNeg12"), "blanco", 0, verificar2(tipo("diagNeg12"), "blanco", 0));
            }
            Get_Score();
        }

        protected void b5_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colB"), "negro", 4, verificar2(tipo("colB"), "negro", 4));
                comerFicha(tipo("fila5"), "negro", 1, verificar2(tipo("fila5"), "negro", 1));
                comerFicha(tipo("diagPos6"), "negro", 1, verificar2(tipo("diagPos6"), "negro", 1));
                comerFicha(tipo("diagNeg11"), "negro", 1, verificar2(tipo("diagNeg11"), "negro", 1));
            }
            else
            {
                comerFicha(tipo("colB"), "blanco", 4, verificar2(tipo("colB"), "blanco", 4));
                comerFicha(tipo("fila5"), "blanco", 1, verificar2(tipo("fila5"), "blanco", 1));
                comerFicha(tipo("diagPos6"), "blanco", 1, verificar2(tipo("diagPos6"), "blanco", 1));
                comerFicha(tipo("diagNeg11"), "blanco", 1, verificar2(tipo("diagNeg11"), "blanco", 1));
            }
            Get_Score();
        }

        protected void c5_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colC"), "negro", 4, verificar2(tipo("colC"), "negro", 4));
                comerFicha(tipo("fila5"), "negro", 2, verificar2(tipo("fila5"), "negro", 2));
                comerFicha(tipo("diagPos7"), "negro", 2, verificar2(tipo("diagPos7"), "negro", 2));
                comerFicha(tipo("diagNeg10"), "negro", 2, verificar2(tipo("diagNeg10"), "negro", 2));
            }
            else
            {
                comerFicha(tipo("colC"), "blanco", 4, verificar2(tipo("colC"), "blanco", 4));
                comerFicha(tipo("fila5"), "blanco", 2, verificar2(tipo("fila5"), "blanco", 2));
                comerFicha(tipo("diagPos7"), "blanco", 2, verificar2(tipo("diagPos7"), "blanco", 2));
                comerFicha(tipo("diagNeg10"), "blanco", 2, verificar2(tipo("diagNeg10"), "blanco", 2));
            }
            Get_Score();
        }

        protected void d5_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colD"), "negro", 4, verificar2(tipo("colD"), "negro", 4));
                comerFicha(tipo("fila5"), "negro", 3, verificar2(tipo("fila5"), "negro", 3));
                comerFicha(tipo("diagPos8"), "negro", 3, verificar2(tipo("diagPos8"), "negro", 3));
                comerFicha(tipo("diagNeg9"), "negro", 3, verificar2(tipo("diagNeg9"), "negro", 3));
            }
            else
            {
                comerFicha(tipo("colD"), "blanco", 4, verificar2(tipo("colD"), "blanco", 4));
                comerFicha(tipo("fila5"), "blanco", 3, verificar2(tipo("fila5"), "blanco", 3));
                comerFicha(tipo("diagPos8"), "blanco", 3, verificar2(tipo("diagPos8"), "blanco", 3));
                comerFicha(tipo("diagNeg9"), "blanco", 3, verificar2(tipo("diagNeg9"), "blanco", 3));
            }
            Get_Score();
        }

        protected void e5_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colE"), "negro", 4, verificar2(tipo("colE"), "negro", 4));
                comerFicha(tipo("fila5"), "negro", 4, verificar2(tipo("fila5"), "negro", 4));
                comerFicha(tipo("diagPos9"), "negro", 3, verificar2(tipo("diagPos9"), "negro", 3));
                comerFicha(tipo("diagNeg8"), "negro", 4, verificar2(tipo("diagNeg8"), "negro", 4));
            }
            else
            {
                comerFicha(tipo("colE"), "blanco", 4, verificar2(tipo("colE"), "blanco", 4));
                comerFicha(tipo("fila5"), "blanco", 4, verificar2(tipo("fila5"), "blanco", 4));
                comerFicha(tipo("diagPos9"), "blanco", 3, verificar2(tipo("diagPos9"), "blanco", 3));
                comerFicha(tipo("diagNeg8"), "blanco", 4, verificar2(tipo("diagNeg8"), "blanco", 4));
            }
            Get_Score();
        }

        protected void f5_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colF"), "negro", 4, verificar2(tipo("colF"), "negro", 4));
                comerFicha(tipo("fila5"), "negro", 5, verificar2(tipo("fila5"), "negro", 5));
                comerFicha(tipo("diagPos10"), "negro", 3, verificar2(tipo("diagPos10"), "negro", 3));
                comerFicha(tipo("diagNeg7"), "negro", 4, verificar2(tipo("diagNeg7"), "negro", 4));
            }
            else
            {
                comerFicha(tipo("colF"), "blanco", 4, verificar2(tipo("colF"), "blanco", 4));
                comerFicha(tipo("fila5"), "blanco", 5, verificar2(tipo("fila5"), "blanco", 5));
                comerFicha(tipo("diagPos10"), "blanco", 3, verificar2(tipo("diagPos10"), "blanco", 3));
                comerFicha(tipo("diagNeg7"), "blanco", 4, verificar2(tipo("diagNeg7"), "blanco", 4));
            }
            Get_Score();
        }

        protected void g5_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colG"), "negro", 4, verificar2(tipo("colG"), "negro", 4));
                comerFicha(tipo("fila5"), "negro", 6, verificar2(tipo("fila5"), "negro", 6));
                comerFicha(tipo("diagPos11"), "negro", 3, verificar2(tipo("diagPos11"), "negro", 3));
                comerFicha(tipo("diagNeg6"), "negro", 4, verificar2(tipo("diagNeg6"), "negro", 4));
            }
            else
            {
                comerFicha(tipo("colG"), "blanco", 4, verificar2(tipo("colG"), "blanco", 4));
                comerFicha(tipo("fila5"), "blanco", 6, verificar2(tipo("fila5"), "blanco", 6));
                comerFicha(tipo("diagPos11"), "blanco", 3, verificar2(tipo("diagPos11"), "blanco", 3));
                comerFicha(tipo("diagNeg6"), "blanco", 4, verificar2(tipo("diagNeg6"), "blanco", 4));
            }
            Get_Score();
        }

        protected void h5_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colH"), "negro", 4, verificar2(tipo("colH"), "negro", 4));
                comerFicha(tipo("fila5"), "negro", 7, verificar2(tipo("fila5"), "negro", 7));
                comerFicha(tipo("diagPos12"), "negro", 3, verificar2(tipo("diagPos12"), "negro", 3));
                comerFicha(tipo("diagNeg5"), "negro", 4, verificar2(tipo("diagNeg5"), "negro", 4));
            }
            else
            {
                comerFicha(tipo("colH"), "blanco", 4, verificar2(tipo("colH"), "blanco", 4));
                comerFicha(tipo("fila5"), "blanco", 7, verificar2(tipo("fila5"), "blanco", 7));
                comerFicha(tipo("diagPos12"), "blanco", 3, verificar2(tipo("diagPos12"), "blanco", 3));
                comerFicha(tipo("diagNeg5"), "blanco", 4, verificar2(tipo("diagNeg5"), "blanco", 4));
            }
            Get_Score();
        }

        protected void a6_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colA"), "negro", 5, verificar2(tipo("colA"), "negro", 5));
                comerFicha(tipo("fila6"), "negro", 0, verificar2(tipo("fila6"), "negro", 0));
                comerFicha(tipo("diagPos6"), "negro", 0, verificar2(tipo("diagPos6"), "negro", 0));
                comerFicha(tipo("diagNeg13"), "negro", 0, verificar2(tipo("diagNeg13"), "negro", 0));
            }
            else
            {
                comerFicha(tipo("colA"), "blanco", 5, verificar2(tipo("colA"), "blanco", 5));
                comerFicha(tipo("fila6"), "blanco", 0, verificar2(tipo("fila6"), "blanco", 0));
                comerFicha(tipo("diagPos6"), "blanco", 0, verificar2(tipo("diagPos6"), "blanco", 0));
                comerFicha(tipo("diagNeg13"), "blanco", 0, verificar2(tipo("diagNeg13"), "blanco", 0));
            }
            Get_Score();
        }

        protected void b6_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colB"), "negro", 5, verificar2(tipo("colB"), "negro", 5));
                comerFicha(tipo("fila6"), "negro", 1, verificar2(tipo("fila6"), "negro", 1));
                comerFicha(tipo("diagPos7"), "negro", 1, verificar2(tipo("diagPos7"), "negro", 1));
                comerFicha(tipo("diagNeg12"), "negro", 1, verificar2(tipo("diagNeg12"), "negro", 1));
            }
            else
            {
                comerFicha(tipo("colB"), "blanco", 5, verificar2(tipo("colB"), "blanco", 5));
                comerFicha(tipo("fila6"), "blanco", 1, verificar2(tipo("fila6"), "blanco", 1));
                comerFicha(tipo("diagPos7"), "blanco", 1, verificar2(tipo("diagPos7"), "blanco", 1));
                comerFicha(tipo("diagNeg12"), "blanco", 1, verificar2(tipo("diagNeg12"), "blanco", 1));
            }
            Get_Score();
        }

        protected void c6_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colC"), "negro", 5, verificar2(tipo("colC"), "negro",5));
                comerFicha(tipo("fila6"), "negro", 2, verificar2(tipo("fila6"), "negro",2));
                comerFicha(tipo("diagPos8"), "negro", 2, verificar2(tipo("diagPos8"), "negro",2));
                comerFicha(tipo("diagNeg11"), "negro", 2, verificar2(tipo("diagNeg11"), "negro",2));
            }
            else
            {
                comerFicha(tipo("colC"), "blanco", 5, verificar2(tipo("colC"), "blanco",5));
                comerFicha(tipo("fila6"), "blanco", 2, verificar2(tipo("fila6"), "blanco",2));
                comerFicha(tipo("diagPos8"), "blanco", 2, verificar2(tipo("diagPos8"), "blanco",2));
                comerFicha(tipo("diagNeg11"), "blanco", 2, verificar2(tipo("diagNeg11"), "blanco",2));
            }
            Get_Score();
        }

        protected void d6_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colD"), "negro", 5, verificar2(tipo("colD"), "negro", 5));
                comerFicha(tipo("fila6"), "negro", 3, verificar2(tipo("fila6"), "negro", 3));
                comerFicha(tipo("diagPos9"), "negro", 2, verificar2(tipo("diagPos9"), "negro", 2));
                comerFicha(tipo("diagNeg10"), "negro", 3, verificar2(tipo("diagNeg10"), "negro", 3));
            }
            else
            {
                comerFicha(tipo("colD"), "blanco", 5, verificar2(tipo("colD"), "blanco", 5));
                comerFicha(tipo("fila6"), "blanco", 3, verificar2(tipo("fila6"), "blanco", 3));
                comerFicha(tipo("diagPos9"), "blanco", 2, verificar2(tipo("diagPos9"), "blanco", 2));
                comerFicha(tipo("diagNeg10"), "blanco", 3, verificar2(tipo("diagNeg10"), "blanco", 3));
            }
            Get_Score();
        }

        protected void e6_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colE"), "negro", 5, verificar2(tipo("colE"), "negro", 5));
                comerFicha(tipo("fila6"), "negro", 4, verificar2(tipo("fila6"), "negro", 4));
                comerFicha(tipo("diagPos10"), "negro", 2, verificar2(tipo("diagPos10"), "negro", 2));
                comerFicha(tipo("diagNeg9"), "negro", 4, verificar2(tipo("diagNeg9"), "negro", 4));
            }
            else
            {
                comerFicha(tipo("colE"), "blanco", 5, verificar2(tipo("colE"), "blanco", 5));
                comerFicha(tipo("fila6"), "blanco", 4, verificar2(tipo("fila6"), "blanco", 4));
                comerFicha(tipo("diagPos10"), "blanco", 2, verificar2(tipo("diagPos10"), "blanco", 2));
                comerFicha(tipo("diagNeg9"), "blanco", 4, verificar2(tipo("diagNeg9"), "blanco", 4));
            }
            Get_Score();
        }

        protected void f6_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colF"), "negro", 5, verificar2(tipo("colF"), "negro", 5));
                comerFicha(tipo("fila6"), "negro", 5, verificar2(tipo("fila6"), "negro", 5));
                comerFicha(tipo("diagPos11"), "negro", 2, verificar2(tipo("diagPos11"), "negro", 2));
                comerFicha(tipo("diagNeg8"), "negro", 5, verificar2(tipo("diagNeg8"), "negro", 5));
            }
            else
            {
                comerFicha(tipo("colF"), "blanco", 5, verificar2(tipo("colF"), "blanco", 5));
                comerFicha(tipo("fila6"), "blanco", 5, verificar2(tipo("fila6"), "blanco", 5));
                comerFicha(tipo("diagPos11"), "blanco", 2, verificar2(tipo("diagPos11"), "blanco", 2));
                comerFicha(tipo("diagNeg8"), "blanco", 5, verificar2(tipo("diagNeg8"), "blanco", 5));
            }
            Get_Score();
        }

        protected void g6_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colG"), "negro", 5, verificar2(tipo("colG"), "negro", 5));
                comerFicha(tipo("fila6"), "negro", 6, verificar2(tipo("fila6"), "negro", 6));
                comerFicha(tipo("diagPos12"), "negro", 2, verificar2(tipo("diagPos12"), "negro", 2));
                comerFicha(tipo("diagNeg7"), "negro", 5, verificar2(tipo("diagNeg7"), "negro", 5));
            }
            else
            {
                comerFicha(tipo("colG"), "blanco", 5, verificar2(tipo("colG"), "blanco", 5));
                comerFicha(tipo("fila6"), "blanco", 6, verificar2(tipo("fila6"), "blanco", 6));
                comerFicha(tipo("diagPos12"), "blanco", 2, verificar2(tipo("diagPos12"), "blanco", 2));
                comerFicha(tipo("diagNeg7"), "blanco", 5, verificar2(tipo("diagNeg7"), "blanco", 5));
            }
            Get_Score();
        }

        protected void h6_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colH"), "negro", 5, verificar2(tipo("colH"), "negro", 5));
                comerFicha(tipo("fila6"), "negro", 7, verificar2(tipo("fila6"), "negro", 7));
                comerFicha(tipo("diagPos13"), "negro", 2, verificar2(tipo("diagPos13"), "negro", 2));
                comerFicha(tipo("diagNeg6"), "negro", 5, verificar2(tipo("diagNeg6"), "negro", 5));
            }
            else
            {
                comerFicha(tipo("colH"), "blanco", 5, verificar2(tipo("colH"), "blanco", 5));
                comerFicha(tipo("fila6"), "blanco", 7, verificar2(tipo("fila6"), "blanco", 7));
                comerFicha(tipo("diagPos13"), "blanco", 2, verificar2(tipo("diagPos13"), "blanco", 2));
                comerFicha(tipo("diagNeg6"), "blanco", 5, verificar2(tipo("diagNeg6"), "blanco", 5));
            }
            Get_Score();
        }

        protected void a7_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colA"), "negro", 6, verificar2(tipo("colA"), "negro", 6));
                comerFicha(tipo("fila7"), "negro", 0, verificar2(tipo("fila7"), "negro", 0));
                comerFicha(tipo("diagPos7"), "negro", 0, verificar2(tipo("diagPos7"), "negro", 0));
                comerFicha(tipo("diagNeg14"), "negro", 0, verificar2(tipo("diagNeg14"), "negro", 0));
            }
            else
            {
                comerFicha(tipo("colA"), "blanco", 6, verificar2(tipo("colA"), "blanco", 6));
                comerFicha(tipo("fila7"), "blanco", 0, verificar2(tipo("fila7"), "blanco", 0));
                comerFicha(tipo("diagPos7"), "blanco", 0, verificar2(tipo("diagPos7"), "blanco", 0));
                comerFicha(tipo("diagNeg14"), "blanco", 0, verificar2(tipo("diagNeg14"), "blanco", 0));
            }
            Get_Score();
        }

        protected void b7_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colB"), "negro", 6, verificar2(tipo("colB"), "negro", 6));
                comerFicha(tipo("fila7"), "negro", 1, verificar2(tipo("fila7"), "negro", 1));
                comerFicha(tipo("diagPos8"), "negro", 1, verificar2(tipo("diagPos8"), "negro", 1));
                comerFicha(tipo("diagNeg13"), "negro", 1, verificar2(tipo("diagNeg13"), "negro", 1));
            }
            else
            {
                comerFicha(tipo("colB"), "blanco", 6, verificar2(tipo("colB"), "blanco", 6));
                comerFicha(tipo("fila7"), "blanco", 1, verificar2(tipo("fila7"), "blanco", 1));
                comerFicha(tipo("diagPos8"), "blanco", 1, verificar2(tipo("diagPos8"), "blanco", 1));
                comerFicha(tipo("diagNeg13"), "blanco", 1, verificar2(tipo("diagNeg13"), "blanco", 1));
            }
            Get_Score();
        }

        protected void c7_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colC"), "negro", 6, verificar2(tipo("colC"), "negro", 6));
                comerFicha(tipo("fila7"), "negro", 2, verificar2(tipo("fila7"), "negro", 2));
                comerFicha(tipo("diagPos9"), "negro", 1, verificar2(tipo("diagPos9"), "negro", 1));
                comerFicha(tipo("diagNeg12"), "negro", 2, verificar2(tipo("diagNeg12"), "negro", 2));
            }
            else
            {
                comerFicha(tipo("colC"), "blanco", 6, verificar2(tipo("colC"), "blanco", 6));
                comerFicha(tipo("fila7"), "blanco", 2, verificar2(tipo("fila7"), "blanco", 2));
                comerFicha(tipo("diagPos9"), "blanco", 1, verificar2(tipo("diagPos9"), "blanco", 1));
                comerFicha(tipo("diagNeg12"), "blanco", 2, verificar2(tipo("diagNeg12"), "blanco", 2));
            }
            Get_Score();
        }

        protected void d7_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colD"), "negro", 6, verificar2(tipo("colD"), "negro", 6));
                comerFicha(tipo("fila7"), "negro", 3, verificar2(tipo("fila7"), "negro", 3));
                comerFicha(tipo("diagPos10"), "negro", 1, verificar2(tipo("diagPos10"), "negro", 1));
                comerFicha(tipo("diagNeg11"), "negro", 3, verificar2(tipo("diagNeg11"), "negro", 3));
            }
            else
            {
                comerFicha(tipo("colD"), "blanco", 6, verificar2(tipo("colD"), "blanco", 6));
                comerFicha(tipo("fila7"), "blanco", 3, verificar2(tipo("fila7"), "blanco", 3));
                comerFicha(tipo("diagPos10"), "blanco", 1, verificar2(tipo("diagPos10"), "blanco", 1));
                comerFicha(tipo("diagNeg11"), "blanco", 3, verificar2(tipo("diagNeg11"), "blanco", 3));
            }
            Get_Score();
        }

        protected void e7_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colE"), "negro", 6, verificar2(tipo("colE"), "negro", 6));
                comerFicha(tipo("fila7"), "negro", 4, verificar2(tipo("fila7"), "negro", 4));
                comerFicha(tipo("diagPos11"), "negro", 1, verificar2(tipo("diagPos11"), "negro", 1));
                comerFicha(tipo("diagNeg10"), "negro", 4, verificar2(tipo("diagNeg10"), "negro", 4));
            }
            else
            {
                comerFicha(tipo("colE"), "blanco", 6, verificar2(tipo("colE"), "blanco", 6));
                comerFicha(tipo("fila7"), "blanco", 4, verificar2(tipo("fila7"), "blanco", 4));
                comerFicha(tipo("diagPos11"), "blanco", 1, verificar2(tipo("diagPos11"), "blanco", 1));
                comerFicha(tipo("diagNeg10"), "blanco", 4, verificar2(tipo("diagNeg10"), "blanco", 4));
            }
            Get_Score();
        }

        protected void f7_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colF"), "negro", 6, verificar2(tipo("colF"), "negro", 6));
                comerFicha(tipo("fila7"), "negro", 5, verificar2(tipo("fila7"), "negro", 5));
                comerFicha(tipo("diagPos12"), "negro", 1, verificar2(tipo("diagPos12"), "negro", 1));
                comerFicha(tipo("diagNeg9"), "negro", 5, verificar2(tipo("diagNeg9"), "negro", 5));
            }
            else
            {
                comerFicha(tipo("colF"), "blanco", 6, verificar2(tipo("colF"), "blanco", 6));
                comerFicha(tipo("fila7"), "blanco", 5, verificar2(tipo("fila7"), "blanco", 5));
                comerFicha(tipo("diagPos12"), "blanco", 1, verificar2(tipo("diagPos12"), "blanco", 1));
                comerFicha(tipo("diagNeg9"), "blanco", 5, verificar2(tipo("diagNeg9"), "blanco", 5));
            }
            Get_Score();
        }

        protected void g7_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colG"), "negro", 6, verificar2(tipo("colG"), "negro", 6));
                comerFicha(tipo("fila7"), "negro", 6, verificar2(tipo("fila7"), "negro", 6));
                comerFicha(tipo("diagPos13"), "negro", 1, verificar2(tipo("diagPos13"), "negro", 1));
                comerFicha(tipo("diagNeg8"), "negro", 6, verificar2(tipo("diagNeg8"), "negro", 6));
            }
            else
            {
                comerFicha(tipo("colG"), "blanco", 6, verificar2(tipo("colG"), "blanco", 6));
                comerFicha(tipo("fila7"), "blanco", 6, verificar2(tipo("fila7"), "blanco", 6));
                comerFicha(tipo("diagPos13"), "blanco", 1, verificar2(tipo("diagPos13"), "blanco", 1));
                comerFicha(tipo("diagNeg8"), "blanco", 6, verificar2(tipo("diagNeg8"), "blanco", 6));
            }
            Get_Score();
        }

        protected void h7_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colH"), "negro", 6, verificar2(tipo("colH"), "negro", 6));
                comerFicha(tipo("fila7"), "negro", 7, verificar2(tipo("fila7"), "negro", 7));
                comerFicha(tipo("diagPos14"), "negro", 1, verificar2(tipo("diagPos14"), "negro", 1));
                comerFicha(tipo("diagNeg7"), "negro", 6, verificar2(tipo("diagNeg7"), "negro", 6));
            }
            else
            {
                comerFicha(tipo("colH"), "blanco", 6, verificar2(tipo("colH"), "blanco", 6));
                comerFicha(tipo("fila7"), "blanco", 7, verificar2(tipo("fila7"), "blanco", 7));
                comerFicha(tipo("diagPos14"), "blanco", 1, verificar2(tipo("diagPos14"), "blanco", 1));
                comerFicha(tipo("diagNeg7"), "blanco", 6, verificar2(tipo("diagNeg7"), "blanco", 6));
            }
            Get_Score();
        }

        protected void a8_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colA"), "negro", 7, verificar2(tipo("colA"), "negro", 7));
                comerFicha(tipo("fila8"), "negro", 0, verificar2(tipo("fila8"), "negro", 0));
                comerFicha(tipo("diagPos8"), "negro", 0, verificar2(tipo("diagPos8"), "negro", 0));
                comerFicha(tipo("diagNeg15"), "negro", 0, verificar2(tipo("diagNeg15"), "negro", 0));
            }
            else
            {
                comerFicha(tipo("colA"), "blanco", 7, verificar2(tipo("colA"), "blanco", 7));
                comerFicha(tipo("fila8"), "blanco", 0, verificar2(tipo("fila8"), "blanco", 0));
                comerFicha(tipo("diagPos8"), "blanco", 0, verificar2(tipo("diagPos8"), "blanco", 0));
                comerFicha(tipo("diagNeg15"), "blanco", 0, verificar2(tipo("diagNeg15"), "blanco", 0));
            }
            Get_Score();
        }

        protected void b8_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colB"), "negro", 7, verificar2(tipo("colB"), "negro", 7));
                comerFicha(tipo("fila8"), "negro", 1, verificar2(tipo("fila8"), "negro", 1));
                comerFicha(tipo("diagPos9"), "negro", 0, verificar2(tipo("diagPos9"), "negro", 0));
                comerFicha(tipo("diagNeg14"), "negro", 1, verificar2(tipo("diagNeg14"), "negro", 1));
            }
            else
            {
                comerFicha(tipo("colB"), "blanco", 7, verificar2(tipo("colB"), "blanco", 7));
                comerFicha(tipo("fila8"), "blanco", 1, verificar2(tipo("fila8"), "blanco", 1));
                comerFicha(tipo("diagPos9"), "blanco", 0, verificar2(tipo("diagPos9"), "blanco", 0));
                comerFicha(tipo("diagNeg14"), "blanco", 1, verificar2(tipo("diagNeg14"), "blanco", 1));
            }
            Get_Score();
        }

        protected void c8_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colC"), "negro", 7, verificar2(tipo("colC"), "negro", 7));
                comerFicha(tipo("fila8"), "negro", 2, verificar2(tipo("fila8"), "negro", 2));
                comerFicha(tipo("diagPos10"), "negro", 0, verificar2(tipo("diagPos10"), "negro", 0));
                comerFicha(tipo("diagNeg13"), "negro", 2, verificar2(tipo("diagNeg13"), "negro", 2));
            }
            else
            {
                comerFicha(tipo("colC"), "blanco", 7, verificar2(tipo("colC"), "blanco", 7));
                comerFicha(tipo("fila8"), "blanco", 2, verificar2(tipo("fila8"), "blanco", 2));
                comerFicha(tipo("diagPos10"), "blanco", 0, verificar2(tipo("diagPos10"), "blanco", 0));
                comerFicha(tipo("diagNeg13"), "blanco", 2, verificar2(tipo("diagNeg13"), "blanco", 2));
            }
            Get_Score();
        }

        protected void d8_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colD"), "negro", 7, verificar2(tipo("colD"), "negro", 7));
                comerFicha(tipo("fila8"), "negro", 3, verificar2(tipo("fila8"), "negro", 3));
                comerFicha(tipo("diagPos11"), "negro", 0, verificar2(tipo("diagPos11"), "negro", 0));
                comerFicha(tipo("diagNeg12"), "negro", 3, verificar2(tipo("diagNeg12"), "negro", 3));
            }
            else
            {
                comerFicha(tipo("colD"), "blanco", 7, verificar2(tipo("colD"), "blanco", 7));
                comerFicha(tipo("fila8"), "blanco", 3, verificar2(tipo("fila8"), "blanco", 3));
                comerFicha(tipo("diagPos11"), "blanco", 0, verificar2(tipo("diagPos11"), "blanco", 0));
                comerFicha(tipo("diagNeg12"), "blanco", 3, verificar2(tipo("diagNeg12"), "blanco", 3));
            }
            Get_Score();
        }

        protected void e8_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colE"), "negro", 7, verificar2(tipo("colE"), "negro", 7));
                comerFicha(tipo("fila8"), "negro", 4, verificar2(tipo("fila8"), "negro", 4));
                comerFicha(tipo("diagPos12"), "negro", 0, verificar2(tipo("diagPos12"), "negro", 0));
                comerFicha(tipo("diagNeg11"), "negro", 4, verificar2(tipo("diagNeg11"), "negro", 4));
            }
            else
            {
                comerFicha(tipo("colE"), "blanco", 7, verificar2(tipo("colE"), "blanco", 7));
                comerFicha(tipo("fila8"), "blanco", 4, verificar2(tipo("fila8"), "blanco", 4));
                comerFicha(tipo("diagPos12"), "blanco", 0, verificar2(tipo("diagPos12"), "blanco", 0));
                comerFicha(tipo("diagNeg11"), "blanco", 4, verificar2(tipo("diagNeg11"), "blanco", 4));
            }
            Get_Score();
        }

        protected void f8_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colF"), "negro", 7, verificar2(tipo("colF"), "negro", 7));
                comerFicha(tipo("fila8"), "negro", 5, verificar2(tipo("fila8"), "negro", 5));
                comerFicha(tipo("diagPos13"), "negro", 0, verificar2(tipo("diagPos13"), "negro", 0));
                comerFicha(tipo("diagNeg10"), "negro", 5, verificar2(tipo("diagNeg10"), "negro", 5));
            }
            else
            {
                comerFicha(tipo("colF"), "blanco", 7, verificar2(tipo("colF"), "blanco", 7));
                comerFicha(tipo("fila8"), "blanco", 5, verificar2(tipo("fila8"), "blanco", 5));
                comerFicha(tipo("diagPos13"), "blanco", 0, verificar2(tipo("diagPos13"), "blanco", 0));
                comerFicha(tipo("diagNeg10"), "blanco", 5, verificar2(tipo("diagNeg10"), "blanco",5));
            }
            Get_Score();
        }

        protected void g8_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colG"), "negro", 7, verificar2(tipo("colG"), "negro",7));
                comerFicha(tipo("fila8"), "negro", 6, verificar2(tipo("fila8"), "negro",6));
                comerFicha(tipo("diagPos14"), "negro", 0, verificar2(tipo("diagPos14"), "negro",0));
                comerFicha(tipo("diagNeg9"), "negro", 6, verificar2(tipo("diagNeg9"), "negro",6));
            }
            else
            {
                comerFicha(tipo("colG"), "blanco", 7, verificar2(tipo("colG"), "blanco",7));
                comerFicha(tipo("fila8"), "blanco", 6, verificar2(tipo("fila8"), "blanco",6));
                comerFicha(tipo("diagPos14"), "blanco", 0, verificar2(tipo("diagPos14"), "blanco",0));
                comerFicha(tipo("diagNeg9"), "blanco", 6, verificar2(tipo("diagNeg9"), "blanco",6));
            }
            Get_Score();
        }

        protected void h8_Click(object sender, EventArgs e)
        {
            if (turno.Text == "Negro")
            {
                comerFicha(tipo("colH"), "negro", 7, verificar2(tipo("colH"), "negro",7));
                comerFicha(tipo("fila8"), "negro", 7, verificar2(tipo("fila8"), "negro",7));
                comerFicha(tipo("diagPos15"), "negro", 0, verificar2(tipo("diagPos15"), "negro",0));
                comerFicha(tipo("diagNeg8"), "negro", 7, verificar2(tipo("diagNeg8"), "negro",7));
            }
            else
            {
                comerFicha(tipo("colH"), "blanco", 7, verificar2(tipo("colH"), "blanco",7));
                comerFicha(tipo("fila8"), "blanco", 7, verificar2(tipo("fila8"), "blanco",7));
                comerFicha(tipo("diagPos15"), "blanco", 0, verificar2(tipo("diagPos15"), "blanco",0));
                comerFicha(tipo("diagNeg8"), "blanco", 7, verificar2(tipo("diagNeg8"), "blanco",7));
            }
            Get_Score();
        }
    }
}