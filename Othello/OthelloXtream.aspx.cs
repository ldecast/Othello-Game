using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Xml;
using System.IO;
using System.Data.SqlClient;

namespace Othello
{
    public partial class ReverseOthello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["Parametro"] != null)
                {
                    string parametro = Request.Params["Parametro"];
                    scoreLabel1.Text = parametro.Substring(parametro.LastIndexOf('-') + 1);
                    if (parametro.Contains("Loaded"))
                    {
                        max.Text = (ColoresUsuario().Count() * 4 + ColoresOponente().Count() * 4 + 8).ToString();
                        iniciar.Visible = true;
                        ceder_turno.Enabled = false;
                        guardar.Enabled = false;
                        end.Enabled = false;
                    }
                    else { iniciar.Visible = false; ClientScript.RegisterStartupScript(GetType(), "hwa", "reloj()", true); }
                }

                Get_Score(null);
                listaColores.Text = Convert.ToString(Session["coloresUsuario"]);
                listaOponente.Text = Convert.ToString(Session["coloresPlayer2"]);
                turno.Text = ColoresUsuario().First().ToString();

            }

            if (Session["modalidad"] != null)
            {
                if (Session["modalidad"].ToString() == "normal")
                {
                    modalidad = "normal";
                }
                else if (Session["modalidad"].ToString() == "inversa")
                {
                    modalidad = "inversa";
                }
            }
            Get_Score(null);
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            switch (turno.Text)
            {
                case "Rojo":
                    turno.ForeColor = ColorTranslator.FromHtml(rojo);
                    movimiento_user.ForeColor = ColorTranslator.FromHtml(rojo);
                    movimiento_oponente.ForeColor = ColorTranslator.FromHtml(rojo);
                    break;
                case "Amarillo":
                    turno.ForeColor = ColorTranslator.FromHtml(amarillo);
                    movimiento_user.ForeColor = ColorTranslator.FromHtml(amarillo);
                    movimiento_oponente.ForeColor = ColorTranslator.FromHtml(amarillo);
                    break;
                case "Azul":
                    turno.ForeColor = ColorTranslator.FromHtml(azul);
                    movimiento_user.ForeColor = ColorTranslator.FromHtml(azul);
                    movimiento_oponente.ForeColor = ColorTranslator.FromHtml(azul);
                    break;
                case "Naranja":
                    turno.ForeColor = ColorTranslator.FromHtml(naranja);
                    movimiento_user.ForeColor = ColorTranslator.FromHtml(naranja);
                    movimiento_oponente.ForeColor = ColorTranslator.FromHtml(naranja);
                    break;
                case "Verde":
                    turno.ForeColor = ColorTranslator.FromHtml(verde);
                    movimiento_user.ForeColor = ColorTranslator.FromHtml(verde);
                    movimiento_oponente.ForeColor = ColorTranslator.FromHtml(verde);
                    break;
                case "Violeta":
                    turno.ForeColor = ColorTranslator.FromHtml(violeta);
                    movimiento_user.ForeColor = ColorTranslator.FromHtml(violeta);
                    movimiento_oponente.ForeColor = ColorTranslator.FromHtml(violeta);
                    break;
                case "Blanco":
                    turno.ForeColor = Color.White;
                    movimiento_user.ForeColor = Color.White;
                    movimiento_oponente.ForeColor = Color.White;
                    break;
                case "Negro":
                    turno.ForeColor = Color.Black;
                    movimiento_user.ForeColor = Color.Black;
                    movimiento_oponente.ForeColor = Color.Black;
                    break;
                case "Celeste":
                    turno.ForeColor = ColorTranslator.FromHtml(celeste);
                    movimiento_user.ForeColor = ColorTranslator.FromHtml(celeste);
                    movimiento_oponente.ForeColor = ColorTranslator.FromHtml(celeste);
                    break;
                case "Gris":
                    turno.ForeColor = ColorTranslator.FromHtml(gris);
                    movimiento_user.ForeColor = ColorTranslator.FromHtml(gris);
                    movimiento_oponente.ForeColor = ColorTranslator.FromHtml(gris);
                    break;
            }
            if (int.Parse(indice1.Text) >= listaColores.Text.Split(',').Length) indice1.Text = "0";
            if (int.Parse(indice2.Text) >= listaOponente.Text.Split(',').Length) indice2.Text = "0";

            if (IsPostBack)
            {
                if (int.Parse(max.Text) >= ColoresUsuario().Count() * 4 + ColoresOponente().Count() * 4 && int.Parse(max.Text) >= 16 && forzado == false)
                {
                    max.Text = "100";
                    int score_user = int.Parse(score1.Text);
                    int score_oponente = int.Parse(score2.Text);
                    if (score_user == 0 && score_oponente > 0) GameOver();
                    else if (score_oponente == 0 && score_user > 0) GameOver();
                    if (score_user + score_oponente == 64) GameOver();
                }
                if (finalizado)
                {
                    turno.Text = "";
                    turno.ForeColor = ColorTranslator.FromHtml("#2e86c1");
                    movimiento_user.ForeColor = ColorTranslator.FromHtml("#2e86c1");
                    movimiento_oponente.Text = "";
                }
            }
        }

        public List<string> ColoresUsuario()
        {
            string coloresUsuario = Convert.ToString(Session["coloresUsuario"]);
            return coloresUsuario.Split(',').ToList();
        }

        public List<string> ColoresOponente()
        {
            string coloresOponente = Convert.ToString(Session["coloresPlayer2"]);
            return coloresOponente.Split(',').ToList();
        }

        private readonly string vacio = "btn btn-success btn-lg border-dark rounded-0";
        private readonly string negro = "btn btn-lg border-dark rounded-0 btn-Negro";
        private readonly string blanco = "btn btn-lg border-dark rounded-0 btn-Blanco";
        private readonly string rojo = "\"#c72b2b\"";
        private readonly string amarillo = "\"#e0bf07\"";
        private readonly string azul = "\"#203ee9\"";
        private readonly string naranja = "\"#f2751c\"";
        private readonly string verde = "\"#00ff22\"";
        private readonly string violeta = "\"#951ec8\"";
        private readonly string celeste = "\"#1d90e4\"";
        private readonly string gris = "\"#807e7e\"";

        private string modalidad = "";
        private bool finalizado = false;
        private bool forzado = false;

        private readonly string rojoCss = "btn btn-lg border-dark rounded-0 btn-Rojo";
        private readonly string amarilloCss = "btn btn-lg border-dark rounded-0 btn-Amarillo";
        private readonly string azulCss = "btn btn-lg border-dark rounded-0 btn-Azul";
        private readonly string naranjaCss = "btn btn-lg border-dark rounded-0 btn-Naranja";
        private readonly string verdeCss = "btn btn-lg border-dark rounded-0 btn-Verde";
        private readonly string violetaCss = "btn btn-lg border-dark rounded-0 btn-Violeta";
        private readonly string celesteCss = "btn btn-lg border-dark rounded-0 btn-Celeste";
        private readonly string grisCss = "btn btn-lg border-dark rounded-0 btn-Gris";


        public void Leer_xml(object sender, EventArgs e)
        {
            if (Session["archivo"] != null)
            {
                ClientScript.RegisterStartupScript(GetType(), "hwa", "reloj()", true); //inicia cronometro

                string ruta = Convert.ToString(Session["archivo"]);
                XmlDocument reader = new XmlDocument();
                reader.Load(ruta);
                WebControl[] botones = { a1, b1, c1, d1, e1, f1, g1, h1, a2, b2, c2, d2, e2, f2, g2, h2, a3, b3, c3, d3, e3, f3, g3, h3, a4, b4, c4, d4, e4, f4, g4, h4, a5, b5, c5, d5, e5, f5, g5, h5, a6, b6, c6, d6, e6, f6, g6, h6, a7, b7, c7, d7, e7, f7, g7, h7, a8, b8, c8, d8, e8, f8, g8, h8, };

                XmlNodeList fichas = reader.GetElementsByTagName("ficha");
                for (int i = 0; i < fichas.Count; i++)
                {
                    if (fichas[i].InnerText.Contains("blanco"))
                    {
                        if (fichas[i].InnerText.Contains("A1")) { botones[0].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("B1")) { botones[1].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("C1")) { botones[2].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("D1")) { botones[3].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("E1")) { botones[4].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("F1")) { botones[5].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("G1")) { botones[6].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("H1")) { botones[7].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("A2")) { botones[8].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("B2")) { botones[9].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("C2")) { botones[10].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("D2")) { botones[11].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("E2")) { botones[12].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("F2")) { botones[13].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("G2")) { botones[14].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("H2")) { botones[15].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("A3")) { botones[16].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("B3")) { botones[17].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("C3")) { botones[18].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("D3")) { botones[19].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("E3")) { botones[20].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("F3")) { botones[21].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("G3")) { botones[22].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("H3")) { botones[23].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("A4")) { botones[24].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("B4")) { botones[25].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("C4")) { botones[26].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("D4")) { botones[27].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("E4")) { botones[28].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("F4")) { botones[29].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("G4")) { botones[30].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("H4")) { botones[31].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("A5")) { botones[32].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("B5")) { botones[33].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("C5")) { botones[34].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("D5")) { botones[35].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("E5")) { botones[36].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("F5")) { botones[37].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("G5")) { botones[38].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("H5")) { botones[39].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("A6")) { botones[40].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("B6")) { botones[41].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("C6")) { botones[42].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("D6")) { botones[43].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("E6")) { botones[44].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("F6")) { botones[45].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("G6")) { botones[46].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("H6")) { botones[47].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("A7")) { botones[48].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("B7")) { botones[49].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("C7")) { botones[50].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("D7")) { botones[51].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("E7")) { botones[52].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("F7")) { botones[53].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("G7")) { botones[54].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("H7")) { botones[55].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("A8")) { botones[56].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("B8")) { botones[57].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("C8")) { botones[58].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("D8")) { botones[59].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("E8")) { botones[60].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("F8")) { botones[61].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("G8")) { botones[62].CssClass = blanco; }
                        if (fichas[i].InnerText.Contains("H8")) { botones[63].CssClass = blanco; }
                    }
                    if (fichas[i].InnerText.Contains("negro"))
                    {
                        if (fichas[i].InnerText.Contains("A1")) { botones[0].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("B1")) { botones[1].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("C1")) { botones[2].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("D1")) { botones[3].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("E1")) { botones[4].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("F1")) { botones[5].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("G1")) { botones[6].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("H1")) { botones[7].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("A2")) { botones[8].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("B2")) { botones[9].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("C2")) { botones[10].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("D2")) { botones[11].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("E2")) { botones[12].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("F2")) { botones[13].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("G2")) { botones[14].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("H2")) { botones[15].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("A3")) { botones[16].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("B3")) { botones[17].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("C3")) { botones[18].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("D3")) { botones[19].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("E3")) { botones[20].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("F3")) { botones[21].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("G3")) { botones[22].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("H3")) { botones[23].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("A4")) { botones[24].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("B4")) { botones[25].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("C4")) { botones[26].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("D4")) { botones[27].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("E4")) { botones[28].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("F4")) { botones[29].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("G4")) { botones[30].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("H4")) { botones[31].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("A5")) { botones[32].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("B5")) { botones[33].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("C5")) { botones[34].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("D5")) { botones[35].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("E5")) { botones[36].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("F5")) { botones[37].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("G5")) { botones[38].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("H5")) { botones[39].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("A6")) { botones[40].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("B6")) { botones[41].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("C6")) { botones[42].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("D6")) { botones[43].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("E6")) { botones[44].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("F6")) { botones[45].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("G6")) { botones[46].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("H6")) { botones[47].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("A7")) { botones[48].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("B7")) { botones[49].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("C7")) { botones[50].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("D7")) { botones[51].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("E7")) { botones[52].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("F7")) { botones[53].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("G7")) { botones[54].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("H7")) { botones[55].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("A8")) { botones[56].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("B8")) { botones[57].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("C8")) { botones[58].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("D8")) { botones[59].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("E8")) { botones[60].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("F8")) { botones[61].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("G8")) { botones[62].CssClass = negro; }
                        if (fichas[i].InnerText.Contains("H8")) { botones[63].CssClass = negro; }
                    }
                }

                XmlNodeList mod = reader.GetElementsByTagName("Modalidad");
                for (int i = 0; i < mod.Count; i++)
                {
                    if (mod[i].InnerText.Contains("Normal"))
                    {
                        modalidad = "normal";
                    }
                    if (mod[i].InnerText.Contains("Inversa"))
                    {
                        modalidad = "inversa";
                    }
                }

                XmlNodeList tiro = reader.GetElementsByTagName("siguienteTiro");
                for (int i = 0; i < tiro.Count; i++)
                {
                    if (tiro[i].InnerText.Contains("blanco"))
                    {
                        turno.Text = "Blanco";
                        movimiento_user.Visible = false;
                        movimiento_oponente.Visible = true;
                    }
                    if (tiro[i].InnerText.Contains("negro"))
                    {
                        turno.Text = "Negro";
                        movimiento_oponente.Visible = false;
                        movimiento_user.Visible = true;
                    }
                }

                XmlNodeList movimientos = reader.GetElementsByTagName("movimientos");
                if (movimientos.Count > 0)
                {
                    XmlNodeList op_moves = ((XmlElement)movimientos[0]).GetElementsByTagName("blanco");
                    foreach (XmlElement Omoves in op_moves)
                    {
                        movimiento_oponente.Text = Omoves.InnerText;
                    }
                    XmlNodeList user_moves = ((XmlElement)movimientos[0]).GetElementsByTagName("negro");
                    foreach (XmlElement Umoves in user_moves)
                    {
                        movimiento_user.Text = Umoves.InnerText;
                    }
                }
                iniciar.Visible = false;
                guardar.Enabled = true;
                ceder_turno.Enabled = true;
                end.Enabled = true;
                Get_Score(null);
            }
        }

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
            string ruta = mdoc + "Partida Xtream " + modalidad + " - " + persona + "(" + id + ").xml";

            while (File.Exists(ruta))
            {
                id++;
                ruta = mdoc + "Partida Xtream " + modalidad + " - " + persona + "(" + id + ").xml";
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
            xmlWriter.WriteStartElement("usuario");
            xmlWriter.WriteString(movimiento_user.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("oponente");
            xmlWriter.WriteString(movimiento_oponente.Text);
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

            Turno_siguiente(turno.Text);

        }

        public void Get_Score(WebControl boton)
        {
            WebControl[] botones = { a1, b1, c1, d1, e1, f1, g1, h1, a2, b2, c2, d2, e2, f2, g2, h2, a3, b3, c3, d3, e3, f3, g3, h3, a4, b4, c4, d4, e4, f4, g4, h4, a5, b5, c5, d5, e5, f5, g5, h5, a6, b6, c6, d6, e6, f6, g6, h6, a7, b7, c7, d7, e7, f7, g7, h7, a8, b8, c8, d8, e8, f8, g8, h8 };
            int white = 0;
            int black = 0;
            int red = 0;
            int yellow = 0;
            int blue = 0;
            int orange = 0;
            int green = 0;
            int purple = 0;
            int sky = 0;
            int grey = 0;

            string aux_turno = turno.Text;
            int aux_usuario = int.Parse(score1.Text);
            int aux_oponente = int.Parse(score2.Text);

            for (int i = 0; i < botones.Length; i++)
            {
                switch (botones[i].CssClass.ToString())
                {
                    case "btn btn-lg border-dark rounded-0 btn-Rojo":
                        red++;
                        break;
                    case "btn btn-lg border-dark rounded-0 btn-Amarillo":
                        yellow++;
                        break;
                    case "btn btn-lg border-dark rounded-0 btn-Azul":
                        blue++;
                        break;
                    case "btn btn-lg border-dark rounded-0 btn-Naranja":
                        orange++;
                        break;
                    case "btn btn-lg border-dark rounded-0 btn-Verde":
                        green++;
                        break;
                    case "btn btn-lg border-dark rounded-0 btn-Violeta":
                        purple++;
                        break;
                    case "btn btn-lg border-dark rounded-0 btn-Celeste":
                        sky++;
                        break;
                    case "btn btn-lg border-dark rounded-0 btn-Gris":
                        grey++;
                        break;
                    case "btn btn-lg border-dark rounded-0 btn-Blanco":
                        white++;
                        break;
                    case "btn btn-lg border-dark rounded-0 btn-Negro":
                        black++;
                        break;
                }
            }

            List<string> aux_user = ColoresUsuario();
            List<string> aux_oponent = ColoresOponente();
            List<int> scores_user = new List<int>();
            List<int> scores_oponente = new List<int>();
            for (int i = 0; i < 1; i++)
            {
                if (aux_user.Contains("Rojo")) scores_user.Add(red);
                if (aux_user.Contains("Amarillo")) scores_user.Add(yellow);
                if (aux_user.Contains("Azul")) scores_user.Add(blue);
                if (aux_user.Contains("Naranja")) scores_user.Add(orange);
                if (aux_user.Contains("Verde")) scores_user.Add(green);
                if (aux_user.Contains("Violeta")) scores_user.Add(purple);
                if (aux_user.Contains("Blanco")) scores_user.Add(white);
                if (aux_user.Contains("Negro")) scores_user.Add(black);
                if (aux_user.Contains("Celeste")) scores_user.Add(sky);
                if (aux_user.Contains("Gris")) scores_user.Add(grey);
            }

            for (int i = 0; i < 1; i++)
            {
                if (aux_oponent.Contains("Rojo")) scores_oponente.Add(red);
                if (aux_oponent.Contains("Amarillo")) scores_oponente.Add(yellow);
                if (aux_oponent.Contains("Azul")) scores_oponente.Add(blue);
                if (aux_oponent.Contains("Naranja")) scores_oponente.Add(orange);
                if (aux_oponent.Contains("Verde")) scores_oponente.Add(green);
                if (aux_oponent.Contains("Violeta")) scores_oponente.Add(purple);
                if (aux_oponent.Contains("Blanco")) scores_oponente.Add(white);
                if (aux_oponent.Contains("Negro")) scores_oponente.Add(black);
                if (aux_oponent.Contains("Celeste")) scores_oponente.Add(sky);
                if (aux_oponent.Contains("Gris")) scores_oponente.Add(grey);
            }

            int score_user_aux = scores_user.Sum();
            int score_oponent_aux = scores_oponente.Sum();

            //edit para que no sea 64
            if (scores_user.Sum() == aux_usuario + 1 && int.Parse(max.Text) > ColoresUsuario().Count() * 4 + ColoresOponente().Count() * 4 && int.Parse(max.Text) > 16) { boton.CssClass = vacio; score_user_aux--; turno.Text = aux_turno; }
            else if (scores_oponente.Sum() == aux_oponente + 1 && int.Parse(max.Text) > ColoresUsuario().Count() * 4 + ColoresOponente().Count() * 4 && int.Parse(max.Text) > 16) { boton.CssClass = vacio; score_oponent_aux--; turno.Text = aux_turno; }

            score1.Text = score_user_aux.ToString();
            score2.Text = score_oponent_aux.ToString();
        }

        public void Get_Move(WebControl boton, string color)
        {
            int user_move = int.Parse(movimiento_user.Text);
            int oponente_move = int.Parse(movimiento_oponente.Text);
            if (boton.CssClass != vacio)
            {
                if (ColoresUsuario().Contains(boton.CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                {
                    user_move++;
                    movimiento_user.Text = user_move.ToString();
                    movimiento_user.Visible = false;
                    movimiento_oponente.Visible = true;
                }
                if (ColoresOponente().Contains(boton.CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                {
                    oponente_move++;
                    movimiento_oponente.Text = oponente_move.ToString();
                    movimiento_oponente.Visible = false;
                    movimiento_user.Visible = true;
                }
                Turno_siguiente(color);
            }
            //edit luego, esta en el complete load
            //int score_white = int.Parse(score1.Text);
            //int score_black = int.Parse(score2.Text);
            //if (score_white == 0 && score_black > 0) GameOver();
            //else if (score_black == 0 && score_white > 0) GameOver();
            //if (score_white + score_black == 64) GameOver();
        }

        public void Terminar_Juego(object sender, EventArgs e)
        {
            finalizado = true;
            forzado = true;
            //edit luego para que no sea 64 si no MxN
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
            finalizado = true;
            gameBoard.Visible = false;
            if (modalidad == "inversa")
            {
                if (int.Parse(score1.Text) < int.Parse(score2.Text))
                {
                    ganador.Text = scoreLabel1.Text + " gana!";
                    Registrar("usuario");
                }
                if (int.Parse(score1.Text) > int.Parse(score2.Text))
                {
                    ganador.Text = "Jugador 2 gana!";
                    Registrar("oponente");
                }
            }

            else if (modalidad == "normal")
            {
                if (int.Parse(score1.Text) > int.Parse(score2.Text))
                {
                    ganador.Text = scoreLabel1.Text + " gana!";
                    Registrar("usuario");
                }
                if (int.Parse(score1.Text) < int.Parse(score2.Text))
                {
                    ganador.Text = "Jugador 2 gana!";
                    Registrar("oponente");
                }
            }

            if (int.Parse(score1.Text) == int.Parse(score2.Text) && int.Parse(score1.Text) > 0)
            {
                ganador.Text = "¡Empate!";
                ganador.CssClass = "display-2 text-warning";
                gameover.CssClass = "display-2 text-warning";
                Registrar("empate");
            }
            resultados.Visible = true;
            guardar.Visible = false;
            ceder_turno.Visible = false;
            end.Visible = false;
            salir.Visible = true;
        }

        public void Registrar(string ganador)
        {
            if (Request.Params["Parametro"] != null)
            {
                #pragma warning disable IDE0059
                string winner = "";
                string loser = "";
                string estado = "";
                #pragma warning restore IDE0059
                string tipo = "Xtream - " + modalidad;
                switch (ganador)
                {
                    case "usuario":
                        estado = "ganada";
                        winner = scoreLabel1.Text.ToString();
                        loser = "invitado";
                        try
                        {
                            string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                            SqlConnection conexion = new SqlConnection(a);
                            conexion.Open();
                            SqlCommand script = new SqlCommand("insert into Partida(tipo,estado,movimientos,jugador1,jugador2,ganador,perdedor,empate) values('"+tipo + "','" +
                                    estado + "'," + movimiento_user.Text + ",'" + winner + "','"+loser+"','" + winner + "','" + loser + "',0)", conexion);
                            script.ExecuteNonQuery();
                            conexion.Close();
                        }
                        catch (Exception)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Error interno: No se pudo guardar el resultado en la base de datos.\")", true);
                        }
                        break;

                    case "oponente":
                        estado = "perdida";
                        winner = "invitado";
                        loser = scoreLabel1.Text.ToString();
                        try
                        {
                            string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                            SqlConnection conexion = new SqlConnection(a);
                            conexion.Open();
                            SqlCommand script = new SqlCommand("insert into Partida(tipo,estado,movimientos,jugador1,jugador2,ganador,perdedor,empate) values('" + tipo + "','" +
                                    estado + "'," + movimiento_user.Text + ",'" + loser + "','" + winner + "','" + winner + "','" + loser + "',0)", conexion);
                            script.ExecuteNonQuery();
                            conexion.Close();
                        }
                        catch (Exception)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Error interno: No se pudo guardar el resultado en la base de datos.\")", true);
                        }
                        break;
                    case "empate":
                        estado = "empate";
                        winner = "";
                        loser = "";
                        string usuario = scoreLabel1.Text.ToString();
                        try
                        {
                            string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                            SqlConnection conexion = new SqlConnection(a);
                            conexion.Open();
                            SqlCommand script = new SqlCommand("insert into Partida(tipo,estado,movimientos,jugador1,jugador2,empate) values('" + tipo + "','empate'," +
                                   movimiento_user.Text + ",'" + usuario + "','invitado',1)", conexion);
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
        }

        public void Salir(object sender, EventArgs e)
        {
            if (Request.Params["Parametro"] != null)
            {
                string parametro = Request.Params["Parametro"];
                string jugador_host = parametro.Substring(parametro.LastIndexOf("-"));
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
                    if (casilla[clic + 1].CssClass == negro && casilla[clic - 1].CssClass == negro && casilla[clic].CssClass == negro)
                        permitido = false;
                }
                if (color == "Blanco")
                {
                    if (casilla[clic + 1].CssClass == blanco && casilla[clic - 1].CssClass == blanco && casilla[clic].CssClass == blanco)
                        permitido = false;
                }
                if (color == "Rojo")
                {
                    if (casilla[clic + 1].CssClass == rojoCss && casilla[clic - 1].CssClass == rojoCss && casilla[clic].CssClass == rojoCss)
                        permitido = false;
                }
                if (color == "Amarillo")
                {
                    if (casilla[clic + 1].CssClass == amarilloCss && casilla[clic - 1].CssClass == amarilloCss && casilla[clic].CssClass == amarilloCss)
                        permitido = false;
                }
                if (color == "Azul")
                {
                    if (casilla[clic + 1].CssClass == azulCss && casilla[clic - 1].CssClass == azulCss && casilla[clic].CssClass == azulCss)
                        permitido = false;
                }
                if (color == "Naranja")
                {
                    if (casilla[clic + 1].CssClass == naranjaCss && casilla[clic - 1].CssClass == naranjaCss && casilla[clic].CssClass == naranjaCss)
                        permitido = false;
                }
                if (color == "Verde")
                {
                    if (casilla[clic + 1].CssClass == verdeCss && casilla[clic - 1].CssClass == verdeCss && casilla[clic].CssClass == verdeCss)
                        permitido = false;
                }
                if (color == "Violeta")
                {
                    if (casilla[clic + 1].CssClass == violetaCss && casilla[clic - 1].CssClass == violetaCss && casilla[clic].CssClass == violetaCss)
                        permitido = false;
                }
                if (color == "Celeste")
                {
                    if (casilla[clic + 1].CssClass == celesteCss && casilla[clic - 1].CssClass == celesteCss && casilla[clic].CssClass == celesteCss)
                        permitido = false;
                }
                if (color == "Gris")
                {
                    if (casilla[clic + 1].CssClass == grisCss && casilla[clic - 1].CssClass == grisCss && casilla[clic].CssClass == grisCss)
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
                if (color == "Rojo" && casilla.Length > 1)
                {
                    if (casilla[clic + 1].CssClass == rojoCss)
                        permitido = false;
                }
                if (color == "Amarillo" && casilla.Length > 1)
                {
                    if (casilla[clic + 1].CssClass == amarilloCss)
                        permitido = false;
                }
                if (color == "Azul" && casilla.Length > 1)
                {
                    if (casilla[clic + 1].CssClass == azulCss)
                        permitido = false;
                }
                if (color == "Naranja" && casilla.Length > 1)
                {
                    if (casilla[clic + 1].CssClass == naranjaCss)
                        permitido = false;
                }
                if (color == "Verde" && casilla.Length > 1)
                {
                    if (casilla[clic + 1].CssClass == verdeCss)
                        permitido = false;
                }
                if (color == "Violeta" && casilla.Length > 1)
                {
                    if (casilla[clic + 1].CssClass == violetaCss)
                        permitido = false;
                }
                if (color == "Celeste" && casilla.Length > 1)
                {
                    if (casilla[clic + 1].CssClass == celesteCss)
                        permitido = false;
                }
                if (color == "Gris" && casilla.Length > 1)
                {
                    if (casilla[clic + 1].CssClass == grisCss)
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
                if (color == "Rojo" && casilla.Length > 1)
                {
                    if (casilla[clic - 1].CssClass == rojoCss)
                        permitido = false;
                }
                if (color == "Amarillo" && casilla.Length > 1)
                {
                    if (casilla[clic - 1].CssClass == amarilloCss)
                        permitido = false;
                }
                if (color == "Azul" && casilla.Length > 1)
                {
                    if (casilla[clic - 1].CssClass == azulCss)
                        permitido = false;
                }
                if (color == "Naranja" && casilla.Length > 1)
                {
                    if (casilla[clic - 1].CssClass == naranjaCss)
                        permitido = false;
                }
                if (color == "Verde" && casilla.Length > 1)
                {
                    if (casilla[clic - 1].CssClass == verdeCss)
                        permitido = false;
                }
                if (color == "Violeta" && casilla.Length > 1)
                {
                    if (casilla[clic - 1].CssClass == violetaCss)
                        permitido = false;
                }
                if (color == "Celeste" && casilla.Length > 1)
                {
                    if (casilla[clic - 1].CssClass == celesteCss)
                        permitido = false;
                }
                if (color == "Gris" && casilla.Length > 1)
                {
                    if (casilla[clic - 1].CssClass == grisCss)
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

            if (ColoresUsuario().Contains(color))
            {
                if (clic < casilla.Length && casilla.Length != 1)
                {
                    if (permitido == false)
                    {
                        for (int i = 0; i < clic; i++)
                        {
                            if (ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                            {
                                if (ColoresUsuario().Count == 1 && ColoresOponente().Count == 1) 
                                {
                                    permitido = true;
                                    aux = i;
                                }
                                else
                                {
                                    permitido = true;
                                    aux = i;
                                    break;
                                }
                            }
                        }
                    }
                    if (true)
                    {
                        for (int i = clic + 1; i < casilla.Length; i++)
                        {
                            if (ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                            {
                                permitido2 = true;
                                aux2 = i;
                                break;
                            }
                        }
                    }
                }
            }

            if (ColoresOponente().Contains(color))
            {
                if (clic < casilla.Length && casilla.Length != 1)
                {
                    if (permitido == false)
                    {
                        for (int i = 0; i < clic; i++)
                        {
                            if (ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                            {
                                if (ColoresUsuario().Count == 1 && ColoresOponente().Count == 1)
                                {
                                    permitido = true;
                                    aux = i;
                                }
                                else
                                {
                                    permitido = true;
                                    aux = i;
                                    break;
                                }
                            }
                        }
                    }
                    if (true)
                    {
                        for (int i = clic + 1; i < casilla.Length; i++)
                        {
                            if (ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
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

        public void Turno_siguiente(string color)
        {
            if (listaColores.Text.Contains(color))
            {
                turno.Text = listaOponente.Text.Split(',')[int.Parse(indice2.Text)];
                indice1.Text = (int.Parse(indice1.Text) + 1).ToString();
            }

            else if (listaOponente.Text.Contains(color))
            {
                turno.Text = listaColores.Text.Split(',')[int.Parse(indice1.Text)];
                indice2.Text = (int.Parse(indice2.Text) + 1).ToString();
            }

            ClientScript.RegisterStartupScript(GetType(), "hwa", "reloj()", true); //inicia cronometro
        }

        public void ComerFicha(WebControl[] casilla, string color, int clic, int index)
        {
            if (int.Parse(max.Text) < ColoresUsuario().Count() * 4 + ColoresOponente().Count() * 4 || int.Parse(max.Text) < 16)
            {
                if (color == "Negro")
                {
                    casilla[clic].CssClass = negro;
                    max.Text = (int.Parse(max.Text) + 1).ToString();
                }
                if (color == "Blanco")
                {
                    casilla[clic].CssClass = blanco;
                    max.Text = (int.Parse(max.Text) + 1).ToString();
                }
                if (color == "Rojo")
                {
                    casilla[clic].CssClass = rojoCss;
                    max.Text = (int.Parse(max.Text) + 1).ToString();
                }
                if (color == "Amarillo")
                {
                    casilla[clic].CssClass = amarilloCss;
                    max.Text = (int.Parse(max.Text) + 1).ToString();
                }
                if (color == "Azul")
                {
                    casilla[clic].CssClass = azulCss;
                    max.Text = (int.Parse(max.Text) + 1).ToString();
                }
                if (color == "Naranja")
                {
                    casilla[clic].CssClass = naranjaCss;
                    max.Text = (int.Parse(max.Text) + 1).ToString();
                }
                if (color == "Verde")
                {
                    casilla[clic].CssClass = verdeCss;
                    max.Text = (int.Parse(max.Text) + 1).ToString();
                }
                if (color == "Violeta")
                {
                    casilla[clic].CssClass = violetaCss;
                    max.Text = (int.Parse(max.Text) + 1).ToString();
                }
                if (color == "Celeste")
                {
                    casilla[clic].CssClass = celesteCss;
                    max.Text = (int.Parse(max.Text) + 1).ToString();
                }
                if (color == "Gris")
                {
                    casilla[clic].CssClass = grisCss;
                    max.Text = (int.Parse(max.Text) + 1).ToString();
                }
            }

            else if (int.Parse(max.Text) >= ColoresUsuario().Count() * 4 + ColoresOponente().Count() * 4 && int.Parse(max.Text) >= 16)
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
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = negro;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = negro;
                                            }
                                        }
                                    }
                                    if (index > clic)
                                    {
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = negro;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = negro;
                                            }
                                        }
                                    }
                                }
                                if (color == "Blanco")
                                {
                                    if (index < clic)
                                    {
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = blanco;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = blanco;
                                            }
                                        }
                                    }
                                    if (index > clic)
                                    {
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = blanco;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = blanco;
                                            }
                                        }
                                    }
                                }
                                if (color == "Rojo")
                                {
                                    if (index < clic)
                                    {
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = rojoCss;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = rojoCss;
                                            }
                                        }
                                    }
                                    if (index > clic)
                                    {
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = rojoCss;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = rojoCss;
                                            }
                                        }
                                    }
                                }
                                if (color == "Amarillo")
                                {
                                    if (index < clic)
                                    {
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = amarilloCss;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = amarilloCss;
                                            }
                                        }
                                    }
                                    if (index > clic)
                                    {
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = amarilloCss;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = amarilloCss;
                                            }
                                        }
                                    }
                                }
                                if (color == "Azul")
                                {
                                    if (index < clic)
                                    {
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = azulCss;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = azulCss;
                                            }
                                        }
                                    }
                                    if (index > clic)
                                    {
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = azulCss;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = azulCss;
                                            }
                                        }
                                    }
                                }
                                if (color == "Naranja")
                                {
                                    if (index < clic)
                                    {
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = naranjaCss;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = naranjaCss;
                                            }
                                        }
                                    }
                                    if (index > clic)
                                    {
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = naranjaCss;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = naranjaCss;
                                            }
                                        }
                                    }
                                }
                                if (color == "Verde")
                                {
                                    if (index < clic)
                                    {
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = verdeCss;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = verdeCss;
                                            }
                                        }
                                    }
                                    if (index > clic)
                                    {
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = verdeCss;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = verdeCss;
                                            }
                                        }
                                    }
                                }
                                if (color == "Violeta")
                                {
                                    if (index < clic)
                                    {
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = violetaCss;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = violetaCss;
                                            }
                                        }
                                    }
                                    if (index > clic)
                                    {
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = violetaCss;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = violetaCss;
                                            }
                                        }
                                    }
                                }
                                if (color == "Celeste")
                                {
                                    if (index < clic)
                                    {
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = celesteCss;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = celesteCss;
                                            }
                                        }
                                    }
                                    if (index > clic)
                                    {
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = celesteCss;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = celesteCss;
                                            }
                                        }
                                    }
                                }
                                if (color == "Gris")
                                {
                                    if (index < clic)
                                    {
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = grisCss;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = index; i <= clic; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = grisCss;
                                            }
                                        }
                                    }
                                    if (index > clic)
                                    {
                                        if (ColoresUsuario().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresUsuario().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = grisCss;
                                            }
                                        }
                                        if (ColoresOponente().Contains(color))
                                        {
                                            for (int i = clic; i <= index; i++)
                                            {
                                                if (!ColoresOponente().Contains(casilla[i].CssClass.ToString().Replace("btn btn-lg border-dark rounded-0 btn-", "")))
                                                    casilla[i].CssClass = grisCss;
                                            }
                                        }
                                    }
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
                            if (casilla[i].CssClass == vacio) { permitido = false; break; }
                        }
                    }
                    if (index > clic)
                    {
                        for (int i = clic + 1; i <= index; i++)
                        {
                            if (casilla[i].CssClass == vacio) { permitido = false; break; }
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
                    if (casilla[i].CssClass == vacio) { permitido = false; break; }
                }
            }
            if (clic + 1 >= casilla.Length && casilla.Length > 1 && index != -1)
            {
                for (int i = index; i < clic; i++)
                {
                    if (casilla[i].CssClass == vacio) { permitido = false; break; }
                }
            }
            return permitido;
        }

        public void A1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a1.CssClass == vacio)
            {
                ComerFicha(Tipo("colA"), color, 0, Verificar(Tipo("colA"), color, 0));
                ComerFicha(Tipo("fila1"), color, 0, Verificar(Tipo("fila1"), color, 0));
                ComerFicha(Tipo("diagPos1"), color, 0, Verificar(Tipo("diagPos1"), color, 0));
                ComerFicha(Tipo("diagNeg8"), color, 0, Verificar(Tipo("diagNeg8"), color, 0));

                Get_Score(a1);
                Get_Move(a1, color);

            }
        }

        public void B1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b1.CssClass == vacio)
            {
                ComerFicha(Tipo("colB"), color, 0, Verificar(Tipo("colB"), color, 0));
                ComerFicha(Tipo("fila1"), color, 1, Verificar(Tipo("fila1"), color, 1));
                ComerFicha(Tipo("diagPos2"), color, 1, Verificar(Tipo("diagPos2"), color, 1));
                ComerFicha(Tipo("diagNeg7"), color, 0, Verificar(Tipo("diagNeg7"), color, 0));

                Get_Score(b1);
                Get_Move(b1, color);

            }
        }

        protected void C1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c1.CssClass == vacio)
            {
                ComerFicha(Tipo("colC"), color, 0, Verificar(Tipo("colC"), color, 0));
                ComerFicha(Tipo("fila1"), color, 2, Verificar(Tipo("fila1"), color, 2));
                ComerFicha(Tipo("diagPos3"), color, 2, Verificar(Tipo("diagPos3"), color, 2));
                ComerFicha(Tipo("diagNeg6"), color, 0, Verificar(Tipo("diagNeg6"), color, 0));

                Get_Score(c1);
                Get_Move(c1, color);

            }
        }

        protected void D1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d1.CssClass == vacio)
            {
                ComerFicha(Tipo("colD"), color, 0, Verificar(Tipo("colD"), color, 0));
                ComerFicha(Tipo("fila1"), color, 3, Verificar(Tipo("fila1"), color, 3));
                ComerFicha(Tipo("diagPos4"), color, 3, Verificar(Tipo("diagPos4"), color, 3));
                ComerFicha(Tipo("diagNeg5"), color, 0, Verificar(Tipo("diagNeg5"), color, 0));

                Get_Score(d1);
                Get_Move(d1, color);

            }
        }

        protected void E1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e1.CssClass == vacio)
            {
                ComerFicha(Tipo("colE"), color, 0, Verificar(Tipo("colE"), color, 0));
                ComerFicha(Tipo("fila1"), color, 4, Verificar(Tipo("fila1"), color, 4));
                ComerFicha(Tipo("diagPos5"), color, 4, Verificar(Tipo("diagPos5"), color, 4));
                ComerFicha(Tipo("diagNeg4"), color, 0, Verificar(Tipo("diagNeg4"), color, 0));

                Get_Score(e1);
                Get_Move(e1, color);

            }
        }

        protected void F1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f1.CssClass == vacio)
            {
                ComerFicha(Tipo("colF"), color, 0, Verificar(Tipo("colF"), color, 0));
                ComerFicha(Tipo("fila1"), color, 5, Verificar(Tipo("fila1"), color, 5));
                ComerFicha(Tipo("diagPos6"), color, 5, Verificar(Tipo("diagPos6"), color, 5));
                ComerFicha(Tipo("diagNeg3"), color, 0, Verificar(Tipo("diagNeg3"), color, 0));

                Get_Score(f1);
                Get_Move(f1, color);

            }
        }

        protected void G1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g1.CssClass == vacio)
            {
                ComerFicha(Tipo("colG"), color, 0, Verificar(Tipo("colG"), color, 0));
                ComerFicha(Tipo("fila1"), color, 6, Verificar(Tipo("fila1"), color, 6));
                ComerFicha(Tipo("diagPos7"), color, 6, Verificar(Tipo("diagPos7"), color, 6));
                ComerFicha(Tipo("diagNeg2"), color, 0, Verificar(Tipo("diagNeg2"), color, 0));

                Get_Score(g1);
                Get_Move(g1, color);
            }
        }

        protected void H1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h1.CssClass == vacio)
            {
                ComerFicha(Tipo("colH"), color, 0, Verificar(Tipo("colH"), color, 0));
                ComerFicha(Tipo("fila1"), color, 7, Verificar(Tipo("fila1"), color, 7));
                ComerFicha(Tipo("diagPos8"), color, 7, Verificar(Tipo("diagPos8"), color, 7));
                ComerFicha(Tipo("diagNeg1"), color, 0, Verificar(Tipo("diagNeg1"), color, 0));

                Get_Score(h1);
                Get_Move(h1, color);

            }
        }

        protected void A2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a2.CssClass == vacio)
            {
                ComerFicha(Tipo("colA"), color, 1, Verificar(Tipo("colA"), color, 1));
                ComerFicha(Tipo("fila2"), color, 0, Verificar(Tipo("fila2"), color, 0));
                ComerFicha(Tipo("diagPos2"), color, 0, Verificar(Tipo("diagPos2"), color, 0));
                ComerFicha(Tipo("diagNeg9"), color, 0, Verificar(Tipo("diagNeg9"), color, 0));

                Get_Score(a2);
                Get_Move(a2, color);

            }
        }

        protected void B2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b2.CssClass == vacio)
            {
                ComerFicha(Tipo("colB"), color, 1, Verificar(Tipo("colB"), color, 1));
                ComerFicha(Tipo("fila2"), color, 1, Verificar(Tipo("fila2"), color, 1));
                ComerFicha(Tipo("diagPos3"), color, 1, Verificar(Tipo("diagPos3"), color, 1));
                ComerFicha(Tipo("diagNeg8"), color, 1, Verificar(Tipo("diagNeg8"), color, 1));

                Get_Score(b2);
                Get_Move(b2, color);

            }
        }

        protected void C2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c2.CssClass == vacio)
            {
                ComerFicha(Tipo("colC"), color, 1, Verificar(Tipo("colC"), color, 1));
                ComerFicha(Tipo("fila2"), color, 2, Verificar(Tipo("fila2"), color, 2));
                ComerFicha(Tipo("diagPos4"), color, 2, Verificar(Tipo("diagPos4"), color, 2));
                ComerFicha(Tipo("diagNeg7"), color, 1, Verificar(Tipo("diagNeg7"), color, 1));

                Get_Score(c2);
                Get_Move(c2, color);

            }
        }

        protected void D2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d2.CssClass == vacio)
            {
                ComerFicha(Tipo("colD"), color, 1, Verificar(Tipo("colD"), color, 1));
                ComerFicha(Tipo("fila2"), color, 3, Verificar(Tipo("fila2"), color, 3));
                ComerFicha(Tipo("diagPos5"), color, 3, Verificar(Tipo("diagPos5"), color, 3));
                ComerFicha(Tipo("diagNeg6"), color, 1, Verificar(Tipo("diagNeg6"), color, 1));

                Get_Score(d2);
                Get_Move(d2, color);

            }
        }

        protected void E2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e2.CssClass == vacio)
            {
                ComerFicha(Tipo("colE"), color, 1, Verificar(Tipo("colE"), color, 1));
                ComerFicha(Tipo("fila2"), color, 4, Verificar(Tipo("fila2"), color, 4));
                ComerFicha(Tipo("diagPos6"), color, 4, Verificar(Tipo("diagPos6"), color, 4));
                ComerFicha(Tipo("diagNeg5"), color, 1, Verificar(Tipo("diagNeg5"), color, 1));

                Get_Score(e2);
                Get_Move(e2, color);

            }
        }

        protected void F2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f2.CssClass == vacio)
            {
                ComerFicha(Tipo("colF"), color, 1, Verificar(Tipo("colF"), color, 1));
                ComerFicha(Tipo("fila2"), color, 5, Verificar(Tipo("fila2"), color, 5));
                ComerFicha(Tipo("diagPos7"), color, 5, Verificar(Tipo("diagPos7"), color, 5));
                ComerFicha(Tipo("diagNeg4"), color, 1, Verificar(Tipo("diagNeg4"), color, 1));

                Get_Score(f2);
                Get_Move(f2, color);

            }
        }

        protected void G2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g2.CssClass == vacio)
            {
                ComerFicha(Tipo("colG"), color, 1, Verificar(Tipo("colG"), color, 1));
                ComerFicha(Tipo("fila2"), color, 6, Verificar(Tipo("fila2"), color, 6));
                ComerFicha(Tipo("diagPos8"), color, 6, Verificar(Tipo("diagPos8"), color, 6));
                ComerFicha(Tipo("diagNeg3"), color, 1, Verificar(Tipo("diagNeg3"), color, 1));

                Get_Score(g2);
                Get_Move(g2, color);

            }
        }

        protected void H2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h2.CssClass == vacio)
            {
                ComerFicha(Tipo("colH"), color, 1, Verificar(Tipo("colH"), color, 1));
                ComerFicha(Tipo("fila2"), color, 7, Verificar(Tipo("fila2"), color, 7));
                ComerFicha(Tipo("diagPos9"), color, 6, Verificar(Tipo("diagPos9"), color, 6));
                ComerFicha(Tipo("diagNeg2"), color, 1, Verificar(Tipo("diagNeg2"), color, 1));

                Get_Score(h2);
                Get_Move(h2, color);

            }
        }

        protected void A3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a3.CssClass == vacio)
            {
                ComerFicha(Tipo("colA"), color, 2, Verificar(Tipo("colA"), color, 2));
                ComerFicha(Tipo("fila3"), color, 0, Verificar(Tipo("fila3"), color, 0));
                ComerFicha(Tipo("diagPos3"), color, 0, Verificar(Tipo("diagPos3"), color, 0));
                ComerFicha(Tipo("diagNeg10"), color, 0, Verificar(Tipo("diagNeg10"), color, 0));

                Get_Score(a3);
                Get_Move(a3, color);

            }
        }

        protected void B3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b3.CssClass == vacio)
            {
                ComerFicha(Tipo("colB"), color, 2, Verificar(Tipo("colB"), color, 2));
                ComerFicha(Tipo("fila3"), color, 1, Verificar(Tipo("fila3"), color, 1));
                ComerFicha(Tipo("diagPos4"), color, 1, Verificar(Tipo("diagPos4"), color, 1));
                ComerFicha(Tipo("diagNeg9"), color, 1, Verificar(Tipo("diagNeg9"), color, 1));

                Get_Score(b3);
                Get_Move(b3, color);

            }
        }

        protected void C3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c3.CssClass == vacio)
            {
                ComerFicha(Tipo("colC"), color, 2, Verificar(Tipo("colC"), color, 2));
                ComerFicha(Tipo("fila3"), color, 2, Verificar(Tipo("fila3"), color, 2));
                ComerFicha(Tipo("diagPos5"), color, 2, Verificar(Tipo("diagPos5"), color, 2));
                ComerFicha(Tipo("diagNeg8"), color, 2, Verificar(Tipo("diagNeg8"), color, 2));

                Get_Score(c3);
                Get_Move(c3, color);

            }
        }

        protected void D3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d3.CssClass == vacio)
            {
                ComerFicha(Tipo("colD"), color, 2, Verificar(Tipo("colD"), color, 2));
                ComerFicha(Tipo("fila3"), color, 3, Verificar(Tipo("fila3"), color, 3));
                ComerFicha(Tipo("diagPos6"), color, 3, Verificar(Tipo("diagPos6"), color, 3));
                ComerFicha(Tipo("diagNeg7"), color, 2, Verificar(Tipo("diagNeg7"), color, 2));

                Get_Score(d3);
                Get_Move(d3, color);

            }
        }

        protected void E3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e3.CssClass == vacio)
            {
                ComerFicha(Tipo("colE"), color, 2, Verificar(Tipo("colE"), color, 2));
                ComerFicha(Tipo("fila3"), color, 4, Verificar(Tipo("fila3"), color, 4));
                ComerFicha(Tipo("diagPos7"), color, 4, Verificar(Tipo("diagPos7"), color, 4));
                ComerFicha(Tipo("diagNeg6"), color, 2, Verificar(Tipo("diagNeg6"), color, 2));

                Get_Score(e3);
                Get_Move(e3, color);

            }
        }

        protected void F3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f3.CssClass == vacio)
            {
                ComerFicha(Tipo("colF"), color, 2, Verificar(Tipo("colF"), color, 2));
                ComerFicha(Tipo("fila3"), color, 5, Verificar(Tipo("fila3"), color, 5));
                ComerFicha(Tipo("diagPos8"), color, 5, Verificar(Tipo("diagPos8"), color, 5));
                ComerFicha(Tipo("diagNeg5"), color, 2, Verificar(Tipo("diagNeg5"), color, 2));

                Get_Score(f3);
                Get_Move(f3, color);

            }
        }

        protected void G3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g3.CssClass == vacio)
            {
                ComerFicha(Tipo("colG"), color, 2, Verificar(Tipo("colG"), color, 2));
                ComerFicha(Tipo("fila3"), color, 6, Verificar(Tipo("fila3"), color, 6));
                ComerFicha(Tipo("diagPos9"), color, 5, Verificar(Tipo("diagPos9"), color, 5));
                ComerFicha(Tipo("diagNeg4"), color, 2, Verificar(Tipo("diagNeg4"), color, 2));

                Get_Score(g3);
                Get_Move(g3, color);

            }
        }

        protected void H3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h3.CssClass == vacio)
            {
                ComerFicha(Tipo("colH"), color, 2, Verificar(Tipo("colH"), color, 2));
                ComerFicha(Tipo("fila3"), color, 7, Verificar(Tipo("fila3"), color, 7));
                ComerFicha(Tipo("diagPos10"), color, 5, Verificar(Tipo("diagPos10"), color, 5));
                ComerFicha(Tipo("diagNeg3"), color, 2, Verificar(Tipo("diagNeg3"), color, 2));

                Get_Score(h3);
                Get_Move(h3, color);

            }
        }

        protected void A4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a4.CssClass == vacio)
            {
                ComerFicha(Tipo("colA"), color, 3, Verificar(Tipo("colA"), color, 3));
                ComerFicha(Tipo("fila4"), color, 0, Verificar(Tipo("fila4"), color, 0));
                ComerFicha(Tipo("diagPos4"), color, 0, Verificar(Tipo("diagPos4"), color, 0));
                ComerFicha(Tipo("diagNeg11"), color, 0, Verificar(Tipo("diagNeg11"), color, 0));

                Get_Score(a4);
                Get_Move(a4, color);

            }
        }
        protected void B4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b4.CssClass == vacio)
            {
                ComerFicha(Tipo("colB"), color, 3, Verificar(Tipo("colB"), color, 3));
                ComerFicha(Tipo("fila4"), color, 1, Verificar(Tipo("fila4"), color, 1));
                ComerFicha(Tipo("diagPos5"), color, 1, Verificar(Tipo("diagPos5"), color, 1));
                ComerFicha(Tipo("diagNeg10"), color, 1, Verificar(Tipo("diagNeg10"), color, 1));

                Get_Score(b4);
                Get_Move(b4, color);

            }
        }

        protected void C4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c4.CssClass == vacio)
            {
                ComerFicha(Tipo("colC"), color, 3, Verificar(Tipo("colC"), color, 3));
                ComerFicha(Tipo("fila4"), color, 2, Verificar(Tipo("fila4"), color, 2));
                ComerFicha(Tipo("diagPos6"), color, 2, Verificar(Tipo("diagPos6"), color, 2));
                ComerFicha(Tipo("diagNeg9"), color, 2, Verificar(Tipo("diagNeg9"), color, 2));

                Get_Score(c4);
                Get_Move(c4, color);

            }
        }

        protected void D4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d4.CssClass == vacio)
            {
                ComerFicha(Tipo("colD"), color, 3, Verificar(Tipo("colD"), color, 3));
                ComerFicha(Tipo("fila4"), color, 3, Verificar(Tipo("fila4"), color, 3));
                ComerFicha(Tipo("diagPos7"), color, 3, Verificar(Tipo("diagPos7"), color, 3));
                ComerFicha(Tipo("diagNeg8"), color, 3, Verificar(Tipo("diagNeg8"), color, 3));

                Get_Score(d4);
                Get_Move(d4, color);

            }
        }

        protected void E4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e4.CssClass == vacio)
            {
                ComerFicha(Tipo("colE"), color, 3, Verificar(Tipo("colE"), color, 3));
                ComerFicha(Tipo("fila4"), color, 4, Verificar(Tipo("fila4"), color, 4));
                ComerFicha(Tipo("diagPos8"), color, 4, Verificar(Tipo("diagPos8"), color, 4));
                ComerFicha(Tipo("diagNeg7"), color, 3, Verificar(Tipo("diagNeg7"), color, 3));

                Get_Score(e4);
                Get_Move(e4, color);

            }
        }

        protected void F4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f4.CssClass == vacio)
            {
                ComerFicha(Tipo("colF"), color, 3, Verificar(Tipo("colF"), color, 3));
                ComerFicha(Tipo("fila4"), color, 5, Verificar(Tipo("fila4"), color, 5));
                ComerFicha(Tipo("diagPos9"), color, 4, Verificar(Tipo("diagPos9"), color, 4));
                ComerFicha(Tipo("diagNeg6"), color, 3, Verificar(Tipo("diagNeg6"), color, 3));

                Get_Score(f4);
                Get_Move(f4, color);

            }
        }

        protected void G4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g4.CssClass == vacio)
            {
                ComerFicha(Tipo("colG"), color, 3, Verificar(Tipo("colG"), color, 3));
                ComerFicha(Tipo("fila4"), color, 6, Verificar(Tipo("fila4"), color, 6));
                ComerFicha(Tipo("diagPos10"), color, 4, Verificar(Tipo("diagPos10"), color, 4));
                ComerFicha(Tipo("diagNeg5"), color, 3, Verificar(Tipo("diagNeg5"), color, 3));

                Get_Score(g4);
                Get_Move(g4, color);

            }
        }

        protected void H4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h4.CssClass == vacio)
            {
                ComerFicha(Tipo("colH"), color, 3, Verificar(Tipo("colH"), color, 3));
                ComerFicha(Tipo("fila4"), color, 7, Verificar(Tipo("fila4"), color, 7));
                ComerFicha(Tipo("diagPos11"), color, 4, Verificar(Tipo("diagPos11"), color, 4));
                ComerFicha(Tipo("diagNeg4"), color, 3, Verificar(Tipo("diagNeg4"), color, 3));

                Get_Score(h4);
                Get_Move(h4, color);

            }
        }

        protected void A5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a5.CssClass == vacio)
            {
                ComerFicha(Tipo("colA"), color, 4, Verificar(Tipo("colA"), color, 4));
                ComerFicha(Tipo("fila5"), color, 0, Verificar(Tipo("fila5"), color, 0));
                ComerFicha(Tipo("diagPos5"), color, 0, Verificar(Tipo("diagPos5"), color, 0));
                ComerFicha(Tipo("diagNeg12"), color, 0, Verificar(Tipo("diagNeg12"), color, 0));

                Get_Score(a5);
                Get_Move(a5, color);

            }
        }

        protected void B5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b5.CssClass == vacio)
            {
                ComerFicha(Tipo("colB"), color, 4, Verificar(Tipo("colB"), color, 4));
                ComerFicha(Tipo("fila5"), color, 1, Verificar(Tipo("fila5"), color, 1));
                ComerFicha(Tipo("diagPos6"), color, 1, Verificar(Tipo("diagPos6"), color, 1));
                ComerFicha(Tipo("diagNeg11"), color, 1, Verificar(Tipo("diagNeg11"), color, 1));

                Get_Score(b5);
                Get_Move(b5, color);

            }
        }

        protected void C5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c5.CssClass == vacio)
            {
                ComerFicha(Tipo("colC"), color, 4, Verificar(Tipo("colC"), color, 4));
                ComerFicha(Tipo("fila5"), color, 2, Verificar(Tipo("fila5"), color, 2));
                ComerFicha(Tipo("diagPos7"), color, 2, Verificar(Tipo("diagPos7"), color, 2));
                ComerFicha(Tipo("diagNeg10"), color, 2, Verificar(Tipo("diagNeg10"), color, 2));

                Get_Score(c5);
                Get_Move(c5, color);

            }
        }

        protected void D5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d5.CssClass == vacio)
            {
                ComerFicha(Tipo("colD"), color, 4, Verificar(Tipo("colD"), color, 4));
                ComerFicha(Tipo("fila5"), color, 3, Verificar(Tipo("fila5"), color, 3));
                ComerFicha(Tipo("diagPos8"), color, 3, Verificar(Tipo("diagPos8"), color, 3));
                ComerFicha(Tipo("diagNeg9"), color, 3, Verificar(Tipo("diagNeg9"), color, 3));

                Get_Score(d5);
                Get_Move(d5, color);

            }
        }

        protected void E5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e5.CssClass == vacio)
            {
                ComerFicha(Tipo("colE"), color, 4, Verificar(Tipo("colE"), color, 4));
                ComerFicha(Tipo("fila5"), color, 4, Verificar(Tipo("fila5"), color, 4));
                ComerFicha(Tipo("diagPos9"), color, 3, Verificar(Tipo("diagPos9"), color, 3));
                ComerFicha(Tipo("diagNeg8"), color, 4, Verificar(Tipo("diagNeg8"), color, 4));

                Get_Score(e5);
                Get_Move(e5, color);

            }
        }

        protected void F5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f5.CssClass == vacio)
            {
                ComerFicha(Tipo("colF"), color, 4, Verificar(Tipo("colF"), color, 4));
                ComerFicha(Tipo("fila5"), color, 5, Verificar(Tipo("fila5"), color, 5));
                ComerFicha(Tipo("diagPos10"), color, 3, Verificar(Tipo("diagPos10"), color, 3));
                ComerFicha(Tipo("diagNeg7"), color, 4, Verificar(Tipo("diagNeg7"), color, 4));

                Get_Score(f5);
                Get_Move(f5, color);

            }
        }

        protected void G5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g5.CssClass == vacio)
            {
                ComerFicha(Tipo("colG"), color, 4, Verificar(Tipo("colG"), color, 4));
                ComerFicha(Tipo("fila5"), color, 6, Verificar(Tipo("fila5"), color, 6));
                ComerFicha(Tipo("diagPos11"), color, 3, Verificar(Tipo("diagPos11"), color, 3));
                ComerFicha(Tipo("diagNeg6"), color, 4, Verificar(Tipo("diagNeg6"), color, 4));

                Get_Score(g5);
                Get_Move(g5, color);

            }
        }

        protected void H5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h5.CssClass == vacio)
            {
                ComerFicha(Tipo("colH"), color, 4, Verificar(Tipo("colH"), color, 4));
                ComerFicha(Tipo("fila5"), color, 7, Verificar(Tipo("fila5"), color, 7));
                ComerFicha(Tipo("diagPos12"), color, 3, Verificar(Tipo("diagPos12"), color, 3));
                ComerFicha(Tipo("diagNeg5"), color, 4, Verificar(Tipo("diagNeg5"), color, 4));

                Get_Score(h5);
                Get_Move(h5, color);

            }
        }

        protected void A6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a6.CssClass == vacio)
            {
                ComerFicha(Tipo("colA"), color, 5, Verificar(Tipo("colA"), color, 5));
                ComerFicha(Tipo("fila6"), color, 0, Verificar(Tipo("fila6"), color, 0));
                ComerFicha(Tipo("diagPos6"), color, 0, Verificar(Tipo("diagPos6"), color, 0));
                ComerFicha(Tipo("diagNeg13"), color, 0, Verificar(Tipo("diagNeg13"), color, 0));

                Get_Score(a6);
                Get_Move(a6, color);

            }
        }

        protected void B6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b6.CssClass == vacio)
            {
                ComerFicha(Tipo("colB"), color, 5, Verificar(Tipo("colB"), color, 5));
                ComerFicha(Tipo("fila6"), color, 1, Verificar(Tipo("fila6"), color, 1));
                ComerFicha(Tipo("diagPos7"), color, 1, Verificar(Tipo("diagPos7"), color, 1));
                ComerFicha(Tipo("diagNeg12"), color, 1, Verificar(Tipo("diagNeg12"), color, 1));

                Get_Score(b6);
                Get_Move(b6, color);

            }
        }

        protected void C6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c6.CssClass == vacio)
            {
                ComerFicha(Tipo("colC"), color, 5, Verificar(Tipo("colC"), color, 5));
                ComerFicha(Tipo("fila6"), color, 2, Verificar(Tipo("fila6"), color, 2));
                ComerFicha(Tipo("diagPos8"), color, 2, Verificar(Tipo("diagPos8"), color, 2));
                ComerFicha(Tipo("diagNeg11"), color, 2, Verificar(Tipo("diagNeg11"), color, 2));

                Get_Score(c6);
                Get_Move(c6, color);

            }
        }

        protected void D6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d6.CssClass == vacio)
            {
                ComerFicha(Tipo("colD"), color, 5, Verificar(Tipo("colD"), color, 5));
                ComerFicha(Tipo("fila6"), color, 3, Verificar(Tipo("fila6"), color, 3));
                ComerFicha(Tipo("diagPos9"), color, 2, Verificar(Tipo("diagPos9"), color, 2));
                ComerFicha(Tipo("diagNeg10"), color, 3, Verificar(Tipo("diagNeg10"), color, 3));

                Get_Score(d6);
                Get_Move(d6, color);

            }
        }

        protected void E6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e6.CssClass == vacio)
            {
                ComerFicha(Tipo("colE"), color, 5, Verificar(Tipo("colE"), color, 5));
                ComerFicha(Tipo("fila6"), color, 4, Verificar(Tipo("fila6"), color, 4));
                ComerFicha(Tipo("diagPos10"), color, 2, Verificar(Tipo("diagPos10"), color, 2));
                ComerFicha(Tipo("diagNeg9"), color, 4, Verificar(Tipo("diagNeg9"), color, 4));

                Get_Score(e6);
                Get_Move(e6, color);

            }
        }

        protected void F6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f6.CssClass == vacio)
            {
                ComerFicha(Tipo("colF"), color, 5, Verificar(Tipo("colF"), color, 5));
                ComerFicha(Tipo("fila6"), color, 5, Verificar(Tipo("fila6"), color, 5));
                ComerFicha(Tipo("diagPos11"), color, 2, Verificar(Tipo("diagPos11"), color, 2));
                ComerFicha(Tipo("diagNeg8"), color, 5, Verificar(Tipo("diagNeg8"), color, 5));

                Get_Score(f6);
                Get_Move(f6, color);

            }
        }

        protected void G6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g6.CssClass == vacio)
            {
                ComerFicha(Tipo("colG"), color, 5, Verificar(Tipo("colG"), color, 5));
                ComerFicha(Tipo("fila6"), color, 6, Verificar(Tipo("fila6"), color, 6));
                ComerFicha(Tipo("diagPos12"), color, 2, Verificar(Tipo("diagPos12"), color, 2));
                ComerFicha(Tipo("diagNeg7"), color, 5, Verificar(Tipo("diagNeg7"), color, 5));

                Get_Score(g6);
                Get_Move(g6, color);

            }
        }

        protected void H6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h6.CssClass == vacio)
            {
                ComerFicha(Tipo("colH"), color, 5, Verificar(Tipo("colH"), color, 5));
                ComerFicha(Tipo("fila6"), color, 7, Verificar(Tipo("fila6"), color, 7));
                ComerFicha(Tipo("diagPos13"), color, 2, Verificar(Tipo("diagPos13"), color, 2));
                ComerFicha(Tipo("diagNeg6"), color, 5, Verificar(Tipo("diagNeg6"), color, 5));

                Get_Score(h6);
                Get_Move(h6, color);

            }
        }

        protected void A7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a7.CssClass == vacio)
            {
                ComerFicha(Tipo("colA"), color, 6, Verificar(Tipo("colA"), color, 6));
                ComerFicha(Tipo("fila7"), color, 0, Verificar(Tipo("fila7"), color, 0));
                ComerFicha(Tipo("diagPos7"), color, 0, Verificar(Tipo("diagPos7"), color, 0));
                ComerFicha(Tipo("diagNeg14"), color, 0, Verificar(Tipo("diagNeg14"), color, 0));

                Get_Score(a7);
                Get_Move(a7, color);

            }
        }

        protected void B7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b7.CssClass == vacio)
            {
                ComerFicha(Tipo("colB"), color, 6, Verificar(Tipo("colB"), color, 6));
                ComerFicha(Tipo("fila7"), color, 1, Verificar(Tipo("fila7"), color, 1));
                ComerFicha(Tipo("diagPos8"), color, 1, Verificar(Tipo("diagPos8"), color, 1));
                ComerFicha(Tipo("diagNeg13"), color, 1, Verificar(Tipo("diagNeg13"), color, 1));

                Get_Score(b7);
                Get_Move(b7, color);

            }
        }

        protected void C7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c7.CssClass == vacio)
            {
                ComerFicha(Tipo("colC"), color, 6, Verificar(Tipo("colC"), color, 6));
                ComerFicha(Tipo("fila7"), color, 2, Verificar(Tipo("fila7"), color, 2));
                ComerFicha(Tipo("diagPos9"), color, 1, Verificar(Tipo("diagPos9"), color, 1));
                ComerFicha(Tipo("diagNeg12"), color, 2, Verificar(Tipo("diagNeg12"), color, 2));

                Get_Score(c7);
                Get_Move(c7, color);

            }
        }

        protected void D7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d7.CssClass == vacio)
            {
                ComerFicha(Tipo("colD"), color, 6, Verificar(Tipo("colD"), color, 6));
                ComerFicha(Tipo("fila7"), color, 3, Verificar(Tipo("fila7"), color, 3));
                ComerFicha(Tipo("diagPos10"), color, 1, Verificar(Tipo("diagPos10"), color, 1));
                ComerFicha(Tipo("diagNeg11"), color, 3, Verificar(Tipo("diagNeg11"), color, 3));

                Get_Score(d7);
                Get_Move(d7, color);

            }
        }

        protected void E7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e7.CssClass == vacio)
            {
                ComerFicha(Tipo("colE"), color, 6, Verificar(Tipo("colE"), color, 6));
                ComerFicha(Tipo("fila7"), color, 4, Verificar(Tipo("fila7"), color, 4));
                ComerFicha(Tipo("diagPos11"), color, 1, Verificar(Tipo("diagPos11"), color, 1));
                ComerFicha(Tipo("diagNeg10"), color, 4, Verificar(Tipo("diagNeg10"), color, 4));

                Get_Score(e7);
                Get_Move(e7, color);

            }
        }

        protected void F7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f7.CssClass == vacio)
            {
                ComerFicha(Tipo("colF"), color, 6, Verificar(Tipo("colF"), color, 6));
                ComerFicha(Tipo("fila7"), color, 5, Verificar(Tipo("fila7"), color, 5));
                ComerFicha(Tipo("diagPos12"), color, 1, Verificar(Tipo("diagPos12"), color, 1));
                ComerFicha(Tipo("diagNeg9"), color, 5, Verificar(Tipo("diagNeg9"), color, 5));

                Get_Score(f7);
                Get_Move(f7, color);

            }
        }

        protected void G7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g7.CssClass == vacio)
            {
                ComerFicha(Tipo("colG"), color, 6, Verificar(Tipo("colG"), color, 6));
                ComerFicha(Tipo("fila7"), color, 6, Verificar(Tipo("fila7"), color, 6));
                ComerFicha(Tipo("diagPos13"), color, 1, Verificar(Tipo("diagPos13"), color, 1));
                ComerFicha(Tipo("diagNeg8"), color, 6, Verificar(Tipo("diagNeg8"), color, 6));

                Get_Score(g7);
                Get_Move(g7, color);

            }
        }

        protected void H7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h7.CssClass == vacio)
            {
                ComerFicha(Tipo("colH"), color, 6, Verificar(Tipo("colH"), color, 6));
                ComerFicha(Tipo("fila7"), color, 7, Verificar(Tipo("fila7"), color, 7));
                ComerFicha(Tipo("diagPos14"), color, 1, Verificar(Tipo("diagPos14"), color, 1));
                ComerFicha(Tipo("diagNeg7"), color, 6, Verificar(Tipo("diagNeg7"), color, 6));

                Get_Score(h7);
                Get_Move(h7, color);

            }
        }

        protected void A8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a8.CssClass == vacio)
            {
                ComerFicha(Tipo("colA"), color, 7, Verificar(Tipo("colA"), color, 7));
                ComerFicha(Tipo("fila8"), color, 0, Verificar(Tipo("fila8"), color, 0));
                ComerFicha(Tipo("diagPos8"), color, 0, Verificar(Tipo("diagPos8"), color, 0));
                ComerFicha(Tipo("diagNeg15"), color, 0, Verificar(Tipo("diagNeg15"), color, 0));

                Get_Score(a8);
                Get_Move(a8, color);

            }
        }

        protected void B8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b8.CssClass == vacio)
            {
                ComerFicha(Tipo("colB"), color, 7, Verificar(Tipo("colB"), color, 7));
                ComerFicha(Tipo("fila8"), color, 1, Verificar(Tipo("fila8"), color, 1));
                ComerFicha(Tipo("diagPos9"), color, 0, Verificar(Tipo("diagPos9"), color, 0));
                ComerFicha(Tipo("diagNeg14"), color, 1, Verificar(Tipo("diagNeg14"), color, 1));

                Get_Score(b8);
                Get_Move(b8, color);

            }
        }

        protected void C8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c8.CssClass == vacio)
            {
                ComerFicha(Tipo("colC"), color, 7, Verificar(Tipo("colC"), color, 7));
                ComerFicha(Tipo("fila8"), color, 2, Verificar(Tipo("fila8"), color, 2));
                ComerFicha(Tipo("diagPos10"), color, 0, Verificar(Tipo("diagPos10"), color, 0));
                ComerFicha(Tipo("diagNeg13"), color, 2, Verificar(Tipo("diagNeg13"), color, 2));

                Get_Score(c8);
                Get_Move(c8, color);

            }
        }

        protected void D8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d8.CssClass == vacio)
            {
                ComerFicha(Tipo("colD"), color, 7, Verificar(Tipo("colD"), color, 7));
                ComerFicha(Tipo("fila8"), color, 3, Verificar(Tipo("fila8"), color, 3));
                ComerFicha(Tipo("diagPos11"), color, 0, Verificar(Tipo("diagPos11"), color, 0));
                ComerFicha(Tipo("diagNeg12"), color, 3, Verificar(Tipo("diagNeg12"), color, 3));

                Get_Score(d8);
                Get_Move(d8, color);

            }
        }

        protected void E8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e8.CssClass == vacio)
            {
                ComerFicha(Tipo("colE"), color, 7, Verificar(Tipo("colE"), color, 7));
                ComerFicha(Tipo("fila8"), color, 4, Verificar(Tipo("fila8"), color, 4));
                ComerFicha(Tipo("diagPos12"), color, 0, Verificar(Tipo("diagPos12"), color, 0));
                ComerFicha(Tipo("diagNeg11"), color, 4, Verificar(Tipo("diagNeg11"), color, 4));

                Get_Score(e8);
                Get_Move(e8, color);

            }
        }

        protected void F8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f8.CssClass == vacio)
            {
                ComerFicha(Tipo("colF"), color, 7, Verificar(Tipo("colF"), color, 7));
                ComerFicha(Tipo("fila8"), color, 5, Verificar(Tipo("fila8"), color, 5));
                ComerFicha(Tipo("diagPos13"), color, 0, Verificar(Tipo("diagPos13"), color, 0));
                ComerFicha(Tipo("diagNeg10"), color, 5, Verificar(Tipo("diagNeg10"), color, 5));

                Get_Score(f8);
                Get_Move(f8, color);

            }
        }

        protected void G8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g8.CssClass == vacio)
            {
                ComerFicha(Tipo("colG"), color, 7, Verificar(Tipo("colG"), color, 7));
                ComerFicha(Tipo("fila8"), color, 6, Verificar(Tipo("fila8"), color, 6));
                ComerFicha(Tipo("diagPos14"), color, 0, Verificar(Tipo("diagPos14"), color, 0));
                ComerFicha(Tipo("diagNeg9"), color, 6, Verificar(Tipo("diagNeg9"), color, 6));

                Get_Score(g8);
                Get_Move(g8, color);

            }
        }

        protected void H8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h8.CssClass == vacio)
            {
                ComerFicha(Tipo("colH"), color, 7, Verificar(Tipo("colH"), color, 7));
                ComerFicha(Tipo("fila8"), color, 7, Verificar(Tipo("fila8"), color, 7));
                ComerFicha(Tipo("diagPos15"), color, 0, Verificar(Tipo("diagPos15"), color, 0));
                ComerFicha(Tipo("diagNeg8"), color, 7, Verificar(Tipo("diagNeg8"), color, 7));

                Get_Score(h8);
                Get_Move(h8, color);
            }
        }
    }
}