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

            if (!IsPostBack && Request.Params["Parametro"].Contains("New"))
                ClientScript.RegisterStartupScript(GetType(), "hwa", "Tamaño_tablero()", true);

            if (!IsPostBack && Request.Params["Parametro"].Contains("Loaded"))
            {
                string parametro = Request.Params["Parametro"];
                scoreLabel1.Text = parametro.Substring(parametro.LastIndexOf('-') + 1);
                ClientScript.RegisterStartupScript(GetType(), "hwa", "reloj1()", true);
                max.Text = "100";
                Leer_xml();
            }

            if (Request.Params["__EVENTTARGET"] == "dimensionar")
            {
                dimension.Text = Request["__EVENTARGUMENT"];
                int filas = int.Parse(dimension.Text.Substring(0, dimension.Text.IndexOf(',')));
                int columnas = int.Parse(dimension.Text.Substring(dimension.Text.IndexOf(',') + 1));
                WebControl[][] fila = { Tipo("fila1"), Tipo("fila2"), Tipo("fila3"), Tipo("fila4"), Tipo("fila5"), Tipo("fila6"), Tipo("fila7"), Tipo("fila8"), Tipo("fila9"), Tipo("fila10"), Tipo("fila11"), Tipo("fila12"), Tipo("fila13"), Tipo("fila14"), Tipo("fila15"), Tipo("fila16"), Tipo("fila17"), Tipo("fila18"), Tipo("fila19"), Tipo("fila20") };

                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        fila[i][j].Visible = true;
                    }
                }

                WebControl[] letras = { ca, cb, cc, cd, ce, cf, cg, ch, ci, cj, ck, cl, cm, cn, co, cp, cq, cr, cs, ct };
                for (int i = 0; i < columnas; i++)
                {
                    letras[i].Visible = true;
                }

                WebControl[] numeros = { funo, fdos, ftres, fcuatro, fcinco, fseis, fsiete, focho, fnueve, fdiez, fonce, fdoce, ftrece, fcatorce, fquince, fdsies, fdsiete, fdocho, fdnueve, fveinte };
                for (int i = 0; i < filas; i++)
                {
                    numeros[i].Visible = true;
                }

                if (Request.Params["Parametro"] != null)
                {
                    string parametro = Request.Params["Parametro"];
                    scoreLabel1.Text = parametro.Substring(parametro.LastIndexOf('-') + 1);
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "reloj1()", true);
                }

                listaColores.Text = Convert.ToString(Session["coloresUsuario"]);
                listaOponente.Text = Convert.ToString(Session["coloresPlayer2"]);
                turno.Text = ColoresUsuario().First().ToString();
                ColocarColores();
            }

            if (Session["modalidad"] != null)
            {
                if (Session["modalidad"].ToString() == "normal")
                    modalidad = "normal";
                else if (Session["modalidad"].ToString() == "inversa")
                    modalidad = "inversa";
            }

            Get_Score(null);
            //Fuente: stackoverflow.com/questions/20907112/how-to-maintain-the-value-of-label-after-postback-in-asp-net
            cronometro1.InnerText = estado1.Value;
            cronometro2.InnerText = estado2.Value;
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
                if (int.Parse(max.Text) >= 16 && forzado == false)
                {
                    max.Text = "100";
                    int filas = int.Parse(dimension.Text.Substring(0, dimension.Text.IndexOf(',')));
                    int columnas = int.Parse(dimension.Text.Substring(dimension.Text.IndexOf(',') + 1));
                    int score_user = int.Parse(score1.Text);
                    int score_oponente = int.Parse(score2.Text);
                    if (score_user == 0 && score_oponente > 0) GameOver();
                    else if (score_oponente == 0 && score_user > 0) GameOver();
                    if (score_user + score_oponente == filas*columnas) GameOver();
                }
                if (finalizado)
                {
                    turno.Text = "";
                    turno.ForeColor = ColorTranslator.FromHtml("#2e86c1");
                    movimiento_user.ForeColor = ColorTranslator.FromHtml("#2e86c1");
                    movimiento_oponente.Text = "";
                    resultados.Visible = true;
                    cronometro1.Visible = false;
                    cronometro2.Visible = false;
                    guardar.Visible = false;
                    ceder_turno.Visible = false;
                    end.Visible = false;
                    salir.Visible = true;
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

        public void ColocarColores()
        {
            if (Session["apertura"] != null)
            {
                string apertura = Convert.ToString(Session["apertura"]);
                if (apertura == "false")
                {
                    string colorUser = ColoresUsuario()[0];
                    string colorOponent = ColoresOponente()[0];
                    int filas = (int)Math.Round(double.Parse(dimension.Text.Substring(0, dimension.Text.IndexOf(','))) / 2) - 1;
                    int columnas = (int)Math.Round(double.Parse(dimension.Text.Substring(dimension.Text.IndexOf(',') + 1)) / 2) - 1;
                    WebControl[][] fila = { Tipo("fila1"), Tipo("fila2"), Tipo("fila3"), Tipo("fila4"), Tipo("fila5"), Tipo("fila6"), Tipo("fila7"), Tipo("fila8"), Tipo("fila9"), Tipo("fila10"), Tipo("fila11"), Tipo("fila12"), Tipo("fila13"), Tipo("fila14"), Tipo("fila15"), Tipo("fila16"), Tipo("fila17"), Tipo("fila18"), Tipo("fila19"), Tipo("fila20") };
                    for (int i = 0; i < 2; i++)
                    {
                        fila[i+filas][i+columnas].CssClass = Colorear(colorUser);
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        fila[filas + i][columnas+1 - i].CssClass = Colorear(colorOponent);
                    }
                    max.Text = "100";
                }
            }
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


        public void Leer_xml()
        {
            if (Session["archivo"] != null)
            {
                ClientScript.RegisterStartupScript(GetType(), "hwa", "reloj()", true); //inicia cronometro

                string ruta = Convert.ToString(Session["archivo"]);
                XmlDocument reader = new XmlDocument();
                reader.Load(ruta);

                XmlNodeList fil = reader.GetElementsByTagName("filas");
                for (int i = 0; i < fil.Count; i++)
                {
                    dimension.Text = fil[i].InnerText;
                }

                XmlNodeList col = reader.GetElementsByTagName("columnas");
                for (int i = 0; i < col.Count; i++)
                {
                    dimension.Text = dimension.Text + "," + col[i].InnerText;
                }

                int filas = int.Parse(dimension.Text.Substring(0, dimension.Text.IndexOf(',')));
                int columnas = int.Parse(dimension.Text.Substring(dimension.Text.IndexOf(',') + 1));
                WebControl[][] fila = { Tipo("fila1"), Tipo("fila2"), Tipo("fila3"), Tipo("fila4"), Tipo("fila5"), Tipo("fila6"), Tipo("fila7"), Tipo("fila8"), Tipo("fila9"), Tipo("fila10"), Tipo("fila11"), Tipo("fila12"), Tipo("fila13"), Tipo("fila14"), Tipo("fila15"), Tipo("fila16"), Tipo("fila17"), Tipo("fila18"), Tipo("fila19"), Tipo("fila20") };

                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        fila[i][j].Visible = true;
                    }
                }

                WebControl[] letras = { ca, cb, cc, cd, ce, cf, cg, ch, ci, cj, ck, cl, cm, cn, co, cp, cq, cr, cs, ct };
                for (int i = 0; i < columnas; i++)
                {
                    letras[i].Visible = true;
                }

                WebControl[] numeros = { funo, fdos, ftres, fcuatro, fcinco, fseis, fsiete, focho, fnueve, fdiez, fonce, fdoce, ftrece, fcatorce, fquince, fdsies, fdsiete, fdocho, fdnueve, fveinte };
                for (int i = 0; i < filas; i++)
                {
                    numeros[i].Visible = true;
                }


                XmlNodeList jugador1 = reader.GetElementsByTagName("Jugador1");
                if (jugador1.Count > 0)
                {
                    XmlNodeList J1colors = ((XmlElement)jugador1[0]).GetElementsByTagName("color");
                    foreach (XmlElement colors in J1colors)
                    {
                        listaColores.Text = listaColores.Text + "," + char.ToUpper(colors.InnerText[0]) + colors.InnerText.Substring(1);
                    }
                    listaColores.Text = listaColores.Text.Substring(1);
                    Session["coloresUsuario"] = listaColores.Text;
                }

                XmlNodeList jugador2 = reader.GetElementsByTagName("Jugador2");
                if (jugador2.Count > 0)
                {
                    XmlNodeList J2colors = ((XmlElement)jugador2[0]).GetElementsByTagName("color");
                    foreach (XmlElement colors in J2colors)
                    {
                        listaOponente.Text = listaOponente.Text + "," + char.ToUpper(colors.InnerText[0]) + colors.InnerText.Substring(1);
                    }
                    listaOponente.Text = listaOponente.Text.Substring(1);
                    Session["coloresPlayer2"] = listaOponente.Text;
                }

                XmlNodeList mod = reader.GetElementsByTagName("Modalidad");
                for (int i = 0; i < mod.Count; i++)
                {
                    if (mod[i].InnerText.Contains("ormal"))
                    {
                        modalidad = "normal";
                    }
                    if (mod[i].InnerText.Contains("nversa"))
                    {
                        modalidad = "inversa";
                    }
                }

                WebControl[] botones = { a1, b1, c1, d1, e1, f1, g1, h1, i1, j1, k1, l1, m1, n1, o1, p1, q1, r1, s1, t1, a2, b2, c2, d2, e2, f2, g2, h2, i2, j2, k2, l2, m2, n2, o2, p2, q2, r2, s2, t2, a3, b3, c3, d3, e3, f3, g3, h3, i3, j3, k3, l3, m3, n3, o3, p3, q3, r3, s3, t3, a4, b4, c4, d4, e4, f4, g4, h4, i4, j4, k4, l4, m4, n4, o4, p4, q4, r4, s4, t4, a5, b5, c5, d5, e5, f5, g5, h5, i5, j5, k5, l5, m5, n5, o5, p5, q5, r5, s5, t5, a6, b6, c6, d6, e6, f6, g6, h6, i6, j6, k6, l6, m6, n6, o6, p6, q6, r6, s6, t6, a7, b7, c7, d7, e7, f7, g7, h7, i7, j7, k7, l7, m7, n7, o7, p7, q7, r7, s7, t7, a8, b8, c8, d8, e8, f8, g8, h8, i8, j8, k8, l8, m8, n8, o8, p8, q8, r8, s8, t8, a9, b9, c9, d9, e9, f9, g9, h9, i9, j9, k9, l9, m9, n9, o9, p9, q9, r9, s9, t9, a10, b10, c10, d10, e10, f10, g10, h10, i10, j10, k10, l10, m10, n10, o10, p10, q10, r10, s10, t10, a11, b11, c11, d11, e11, f11, g11, h11, i11, j11, k11, l11, m11, n11, o11, p11, q11, r11, s11, t11, a12, b12, c12, d12, e12, f12, g12, h12, i12, j12, k12, l12, m12, n12, o12, p12, q12, r12, s12, t12, a13, b13, c13, d13, e13, f13, g13, h13, i13, j13, k13, l13, m13, n13, o13, p13, q13, r13, s13, t13, a14, b14, c14, d14, e14, f14, g14, h14, i14, j14, k14, l14, m14, n14, o14, p14, q14, r14, s14, t14, a15, b15, c15, d15, e15, f15, g15, h15, i15, j15, k15, l15, m15, n15, o15, p15, q15, r15, s15, t15, a16, b16, c16, d16, e16, f16, g16, h16, i16, j16, k16, l16, m16, n16, o16, p16, q16, r16, s16, t16, a17, b17, c17, d17, e17, f17, g17, h17, i17, j17, k17, l17, m17, n17, o17, p17, q17, r17, s17, t17, a18, b18, c18, d18, e18, f18, g18, h18, i18, j18, k18, l18, m18, n18, o18, p18, q18, r18, s18, t18, a19, b19, c19, d19, e19, f19, g19, h19, i19, j19, k19, l19, m19, n19, o19, p19, q19, r19, s19, t19, a20, b20, c20, d20, e20, f20, g20, h20, i20, j20, k20, l20, m20, n20, o20, p20, q20, r20, s20, t20, };
                string color = "";
                XmlNodeList fichas = reader.GetElementsByTagName("ficha");
                for (int i = 0; i < fichas.Count; i++)
                {
                    if (fichas[i].InnerText.Contains("blanco"))
                        color = blanco;
                    if (fichas[i].InnerText.Contains("negro"))
                        color = negro;
                    if (fichas[i].InnerText.Contains("rojo"))
                        color = rojoCss;
                    if (fichas[i].InnerText.Contains("amarillo"))
                        color = amarilloCss;
                    if (fichas[i].InnerText.Contains("azul"))
                        color = azulCss;
                    if (fichas[i].InnerText.Contains("verde"))
                        color = verdeCss;
                    if (fichas[i].InnerText.Contains("naranja"))
                        color = naranjaCss;
                    if (fichas[i].InnerText.Contains("violeta"))
                        color = violetaCss;
                    if (fichas[i].InnerText.Contains("gris"))
                        color = grisCss;
                    if (fichas[i].InnerText.Contains("celeste"))
                        color = celesteCss;

                    if (fichas[i].InnerText.Contains("A1")) { botones[0].CssClass = color; } if (fichas[i].InnerText.Contains("B1")) { botones[1].CssClass = color; } if (fichas[i].InnerText.Contains("C1")) { botones[2].CssClass = color; } if (fichas[i].InnerText.Contains("D1")) { botones[3].CssClass = color; } if (fichas[i].InnerText.Contains("E1")) { botones[4].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F1")) { botones[5].CssClass = color; } if (fichas[i].InnerText.Contains("G1")) { botones[6].CssClass = color; } if (fichas[i].InnerText.Contains("H1")) { botones[7].CssClass = color; } if (fichas[i].InnerText.Contains("I1")) { botones[8].CssClass = color; } if (fichas[i].InnerText.Contains("J1")) { botones[9].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K1")) { botones[10].CssClass = color; } if (fichas[i].InnerText.Contains("L1")) { botones[11].CssClass = color; } if (fichas[i].InnerText.Contains("M1")) { botones[12].CssClass = color; } if (fichas[i].InnerText.Contains("N1")) { botones[13].CssClass = color; } if (fichas[i].InnerText.Contains("O1")) { botones[14].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P1")) { botones[15].CssClass = color; } if (fichas[i].InnerText.Contains("Q1")) { botones[16].CssClass = color; } if (fichas[i].InnerText.Contains("R1")) { botones[17].CssClass = color; } if (fichas[i].InnerText.Contains("S1")) { botones[18].CssClass = color; } if (fichas[i].InnerText.Contains("T1")) { botones[19].CssClass = color; }

                    if (fichas[i].InnerText.Contains("A2")) { botones[20].CssClass = color; } if (fichas[i].InnerText.Contains("B2")) { botones[21].CssClass = color; } if (fichas[i].InnerText.Contains("C2")) { botones[22].CssClass = color; } if (fichas[i].InnerText.Contains("D2")) { botones[23].CssClass = color; } if (fichas[i].InnerText.Contains("E2")) { botones[24].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F2")) { botones[25].CssClass = color; } if (fichas[i].InnerText.Contains("G2")) { botones[26].CssClass = color; } if (fichas[i].InnerText.Contains("H2")) { botones[27].CssClass = color; } if (fichas[i].InnerText.Contains("I2")) { botones[28].CssClass = color; } if (fichas[i].InnerText.Contains("J2")) { botones[29].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K2")) { botones[30].CssClass = color; } if (fichas[i].InnerText.Contains("L2")) { botones[31].CssClass = color; } if (fichas[i].InnerText.Contains("M2")) { botones[32].CssClass = color; } if (fichas[i].InnerText.Contains("N2")) { botones[33].CssClass = color; } if (fichas[i].InnerText.Contains("O2")) { botones[34].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P2")) { botones[35].CssClass = color; } if (fichas[i].InnerText.Contains("Q2")) { botones[36].CssClass = color; } if (fichas[i].InnerText.Contains("R2")) { botones[37].CssClass = color; } if (fichas[i].InnerText.Contains("S2")) { botones[38].CssClass = color; } if (fichas[i].InnerText.Contains("T2")) { botones[39].CssClass = color; }

                    if (fichas[i].InnerText.Contains("A3")) { botones[40].CssClass = color; } if (fichas[i].InnerText.Contains("B3")) { botones[41].CssClass = color; } if (fichas[i].InnerText.Contains("C3")) { botones[42].CssClass = color; } if (fichas[i].InnerText.Contains("D3")) { botones[43].CssClass = color; } if (fichas[i].InnerText.Contains("E3")) { botones[44].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F3")) { botones[45].CssClass = color; } if (fichas[i].InnerText.Contains("G3")) { botones[46].CssClass = color; } if (fichas[i].InnerText.Contains("H3")) { botones[47].CssClass = color; } if (fichas[i].InnerText.Contains("I3")) { botones[48].CssClass = color; } if (fichas[i].InnerText.Contains("J3")) { botones[49].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K3")) { botones[50].CssClass = color; } if (fichas[i].InnerText.Contains("L3")) { botones[51].CssClass = color; } if (fichas[i].InnerText.Contains("M3")) { botones[52].CssClass = color; } if (fichas[i].InnerText.Contains("N3")) { botones[53].CssClass = color; } if (fichas[i].InnerText.Contains("O3")) { botones[54].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P3")) { botones[55].CssClass = color; } if (fichas[i].InnerText.Contains("Q3")) { botones[56].CssClass = color; } if (fichas[i].InnerText.Contains("R3")) { botones[57].CssClass = color; } if (fichas[i].InnerText.Contains("S3")) { botones[58].CssClass = color; } if (fichas[i].InnerText.Contains("T3")) { botones[59].CssClass = color; }

                    if (fichas[i].InnerText.Contains("A4")) { botones[60].CssClass = color; } if (fichas[i].InnerText.Contains("B4")) { botones[61].CssClass = color; } if (fichas[i].InnerText.Contains("C4")) { botones[62].CssClass = color; } if (fichas[i].InnerText.Contains("D4")) { botones[63].CssClass = color; } if (fichas[i].InnerText.Contains("E4")) { botones[64].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F4")) { botones[65].CssClass = color; } if (fichas[i].InnerText.Contains("G4")) { botones[66].CssClass = color; } if (fichas[i].InnerText.Contains("H4")) { botones[67].CssClass = color; } if (fichas[i].InnerText.Contains("I4")) { botones[68].CssClass = color; } if (fichas[i].InnerText.Contains("J4")) { botones[69].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K4")) { botones[70].CssClass = color; } if (fichas[i].InnerText.Contains("L4")) { botones[71].CssClass = color; } if (fichas[i].InnerText.Contains("M4")) { botones[72].CssClass = color; } if (fichas[i].InnerText.Contains("N4")) { botones[73].CssClass = color; } if (fichas[i].InnerText.Contains("O4")) { botones[74].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P4")) { botones[75].CssClass = color; } if (fichas[i].InnerText.Contains("Q4")) { botones[76].CssClass = color; } if (fichas[i].InnerText.Contains("R4")) { botones[77].CssClass = color; } if (fichas[i].InnerText.Contains("S4")) { botones[78].CssClass = color; } if (fichas[i].InnerText.Contains("T4")) { botones[79].CssClass = color; }

                    if (fichas[i].InnerText.Contains("A5")) { botones[80].CssClass = color; } if (fichas[i].InnerText.Contains("B5")) { botones[81].CssClass = color; } if (fichas[i].InnerText.Contains("C5")) { botones[82].CssClass = color; } if (fichas[i].InnerText.Contains("D5")) { botones[83].CssClass = color; } if (fichas[i].InnerText.Contains("E5")) { botones[84].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F5")) { botones[85].CssClass = color; } if (fichas[i].InnerText.Contains("G5")) { botones[86].CssClass = color; } if (fichas[i].InnerText.Contains("H5")) { botones[87].CssClass = color; } if (fichas[i].InnerText.Contains("I5")) { botones[88].CssClass = color; } if (fichas[i].InnerText.Contains("J5")) { botones[89].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K5")) { botones[90].CssClass = color; } if (fichas[i].InnerText.Contains("L5")) { botones[91].CssClass = color; } if (fichas[i].InnerText.Contains("M5")) { botones[92].CssClass = color; } if (fichas[i].InnerText.Contains("N5")) { botones[93].CssClass = color; } if (fichas[i].InnerText.Contains("O5")) { botones[94].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P5")) { botones[95].CssClass = color; } if (fichas[i].InnerText.Contains("Q5")) { botones[96].CssClass = color; } if (fichas[i].InnerText.Contains("R5")) { botones[97].CssClass = color; } if (fichas[i].InnerText.Contains("S5")) { botones[98].CssClass = color; } if (fichas[i].InnerText.Contains("T5")) { botones[99].CssClass = color; }

                    if (fichas[i].InnerText.Contains("A6")) { botones[100].CssClass = color; } if (fichas[i].InnerText.Contains("B6")) { botones[101].CssClass = color; } if (fichas[i].InnerText.Contains("C6")) { botones[102].CssClass = color; } if (fichas[i].InnerText.Contains("D6")) { botones[103].CssClass = color; } if (fichas[i].InnerText.Contains("E6")) { botones[104].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F6")) { botones[105].CssClass = color; } if (fichas[i].InnerText.Contains("G6")) { botones[106].CssClass = color; } if (fichas[i].InnerText.Contains("H6")) { botones[107].CssClass = color; } if (fichas[i].InnerText.Contains("I6")) { botones[108].CssClass = color; } if (fichas[i].InnerText.Contains("J6")) { botones[109].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K6")) { botones[110].CssClass = color; } if (fichas[i].InnerText.Contains("L6")) { botones[111].CssClass = color; } if (fichas[i].InnerText.Contains("M6")) { botones[112].CssClass = color; } if (fichas[i].InnerText.Contains("N6")) { botones[113].CssClass = color; } if (fichas[i].InnerText.Contains("O6")) { botones[114].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P6")) { botones[115].CssClass = color; } if (fichas[i].InnerText.Contains("Q6")) { botones[116].CssClass = color; } if (fichas[i].InnerText.Contains("R6")) { botones[117].CssClass = color; } if (fichas[i].InnerText.Contains("S6")) { botones[118].CssClass = color; } if (fichas[i].InnerText.Contains("T6")) { botones[119].CssClass = color; }

                    if (fichas[i].InnerText.Contains("A7")) { botones[120].CssClass = color; } if (fichas[i].InnerText.Contains("B7")) { botones[121].CssClass = color; } if (fichas[i].InnerText.Contains("C7")) { botones[122].CssClass = color; } if (fichas[i].InnerText.Contains("D7")) { botones[123].CssClass = color; } if (fichas[i].InnerText.Contains("E7")) { botones[124].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F7")) { botones[125].CssClass = color; } if (fichas[i].InnerText.Contains("G7")) { botones[126].CssClass = color; } if (fichas[i].InnerText.Contains("H7")) { botones[127].CssClass = color; } if (fichas[i].InnerText.Contains("I7")) { botones[128].CssClass = color; } if (fichas[i].InnerText.Contains("J7")) { botones[129].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K7")) { botones[130].CssClass = color; } if (fichas[i].InnerText.Contains("L7")) { botones[131].CssClass = color; } if (fichas[i].InnerText.Contains("M7")) { botones[132].CssClass = color; } if (fichas[i].InnerText.Contains("N7")) { botones[133].CssClass = color; } if (fichas[i].InnerText.Contains("O7")) { botones[134].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P7")) { botones[135].CssClass = color; } if (fichas[i].InnerText.Contains("Q7")) { botones[136].CssClass = color; } if (fichas[i].InnerText.Contains("R7")) { botones[137].CssClass = color; } if (fichas[i].InnerText.Contains("S7")) { botones[138].CssClass = color; } if (fichas[i].InnerText.Contains("T7")) { botones[139].CssClass = color; }

                    if (fichas[i].InnerText.Contains("A8")) { botones[140].CssClass = color; } if (fichas[i].InnerText.Contains("B8")) { botones[141].CssClass = color; } if (fichas[i].InnerText.Contains("C8")) { botones[142].CssClass = color; } if (fichas[i].InnerText.Contains("D8")) { botones[143].CssClass = color; } if (fichas[i].InnerText.Contains("E8")) { botones[144].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F8")) { botones[145].CssClass = color; } if (fichas[i].InnerText.Contains("G8")) { botones[146].CssClass = color; } if (fichas[i].InnerText.Contains("H8")) { botones[147].CssClass = color; } if (fichas[i].InnerText.Contains("I8")) { botones[148].CssClass = color; } if (fichas[i].InnerText.Contains("J8")) { botones[149].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K8")) { botones[150].CssClass = color; } if (fichas[i].InnerText.Contains("L8")) { botones[151].CssClass = color; } if (fichas[i].InnerText.Contains("M8")) { botones[152].CssClass = color; } if (fichas[i].InnerText.Contains("N8")) { botones[153].CssClass = color; } if (fichas[i].InnerText.Contains("O8")) { botones[154].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P8")) { botones[155].CssClass = color; } if (fichas[i].InnerText.Contains("Q8")) { botones[156].CssClass = color; } if (fichas[i].InnerText.Contains("R8")) { botones[157].CssClass = color; } if (fichas[i].InnerText.Contains("S8")) { botones[158].CssClass = color; } if (fichas[i].InnerText.Contains("T8")) { botones[159].CssClass = color; }

                    if (fichas[i].InnerText.Contains("A9")) { botones[160].CssClass = color; } if (fichas[i].InnerText.Contains("B9")) { botones[161].CssClass = color; } if (fichas[i].InnerText.Contains("C9")) { botones[162].CssClass = color; } if (fichas[i].InnerText.Contains("D9")) { botones[163].CssClass = color; } if (fichas[i].InnerText.Contains("E9")) { botones[164].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F9")) { botones[165].CssClass = color; } if (fichas[i].InnerText.Contains("G9")) { botones[166].CssClass = color; } if (fichas[i].InnerText.Contains("H9")) { botones[167].CssClass = color; } if (fichas[i].InnerText.Contains("I9")) { botones[168].CssClass = color; } if (fichas[i].InnerText.Contains("J9")) { botones[169].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K9")) { botones[170].CssClass = color; } if (fichas[i].InnerText.Contains("L9")) { botones[171].CssClass = color; } if (fichas[i].InnerText.Contains("M9")) { botones[172].CssClass = color; } if (fichas[i].InnerText.Contains("N9")) { botones[173].CssClass = color; } if (fichas[i].InnerText.Contains("O9")) { botones[174].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P9")) { botones[175].CssClass = color; } if (fichas[i].InnerText.Contains("Q9")) { botones[176].CssClass = color; } if (fichas[i].InnerText.Contains("R9")) { botones[177].CssClass = color; } if (fichas[i].InnerText.Contains("S9")) { botones[178].CssClass = color; } if (fichas[i].InnerText.Contains("T9")) { botones[179].CssClass = color; }

                    if (fichas[i].InnerText.Contains("A10")) { botones[180].CssClass = color; } if (fichas[i].InnerText.Contains("B10")) { botones[181].CssClass = color; } if (fichas[i].InnerText.Contains("C10")) { botones[182].CssClass = color; } if (fichas[i].InnerText.Contains("D10")) { botones[183].CssClass = color; } if (fichas[i].InnerText.Contains("E10")) { botones[184].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F10")) { botones[185].CssClass = color; } if (fichas[i].InnerText.Contains("G10")) { botones[186].CssClass = color; } if (fichas[i].InnerText.Contains("H10")) { botones[187].CssClass = color; } if (fichas[i].InnerText.Contains("I10")) { botones[188].CssClass = color; } if (fichas[i].InnerText.Contains("J10")) { botones[189].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K10")) { botones[190].CssClass = color; } if (fichas[i].InnerText.Contains("L10")) { botones[191].CssClass = color; } if (fichas[i].InnerText.Contains("M10")) { botones[192].CssClass = color; } if (fichas[i].InnerText.Contains("N10")) { botones[193].CssClass = color; } if (fichas[i].InnerText.Contains("O10")) { botones[194].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P10")) { botones[195].CssClass = color; } if (fichas[i].InnerText.Contains("Q10")) { botones[196].CssClass = color; } if (fichas[i].InnerText.Contains("R10")) { botones[197].CssClass = color; } if (fichas[i].InnerText.Contains("S10")) { botones[198].CssClass = color; } if (fichas[i].InnerText.Contains("T10")) { botones[199].CssClass = color; }

                    if (fichas[i].InnerText.Contains("A11")) { botones[200].CssClass = color; } if (fichas[i].InnerText.Contains("B11")) { botones[201].CssClass = color; } if (fichas[i].InnerText.Contains("C11")) { botones[202].CssClass = color; } if (fichas[i].InnerText.Contains("D11")) { botones[203].CssClass = color; } if (fichas[i].InnerText.Contains("E11")) { botones[204].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F11")) { botones[205].CssClass = color; } if (fichas[i].InnerText.Contains("G11")) { botones[206].CssClass = color; } if (fichas[i].InnerText.Contains("H11")) { botones[207].CssClass = color; } if (fichas[i].InnerText.Contains("I11")) { botones[208].CssClass = color; } if (fichas[i].InnerText.Contains("J11")) { botones[209].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K11")) { botones[210].CssClass = color; } if (fichas[i].InnerText.Contains("L11")) { botones[211].CssClass = color; } if (fichas[i].InnerText.Contains("M11")) { botones[212].CssClass = color; } if (fichas[i].InnerText.Contains("N11")) { botones[213].CssClass = color; } if (fichas[i].InnerText.Contains("O11")) { botones[214].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P11")) { botones[215].CssClass = color; } if (fichas[i].InnerText.Contains("Q11")) { botones[216].CssClass = color; } if (fichas[i].InnerText.Contains("R11")) { botones[217].CssClass = color; } if (fichas[i].InnerText.Contains("S11")) { botones[218].CssClass = color; } if (fichas[i].InnerText.Contains("T11")) { botones[219].CssClass = color; }

                    if (fichas[i].InnerText.Contains("A12")) { botones[220].CssClass = color; } if (fichas[i].InnerText.Contains("B12")) { botones[221].CssClass = color; } if (fichas[i].InnerText.Contains("C12")) { botones[222].CssClass = color; } if (fichas[i].InnerText.Contains("D12")) { botones[223].CssClass = color; } if (fichas[i].InnerText.Contains("E12")) { botones[224].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F12")) { botones[225].CssClass = color; } if (fichas[i].InnerText.Contains("G12")) { botones[226].CssClass = color; } if (fichas[i].InnerText.Contains("H12")) { botones[227].CssClass = color; } if (fichas[i].InnerText.Contains("I12")) { botones[228].CssClass = color; } if (fichas[i].InnerText.Contains("J12")) { botones[229].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K12")) { botones[230].CssClass = color; } if (fichas[i].InnerText.Contains("L12")) { botones[231].CssClass = color; } if (fichas[i].InnerText.Contains("M12")) { botones[232].CssClass = color; } if (fichas[i].InnerText.Contains("N12")) { botones[233].CssClass = color; } if (fichas[i].InnerText.Contains("O12")) { botones[234].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P12")) { botones[235].CssClass = color; } if (fichas[i].InnerText.Contains("Q12")) { botones[236].CssClass = color; } if (fichas[i].InnerText.Contains("R12")) { botones[237].CssClass = color; } if (fichas[i].InnerText.Contains("S12")) { botones[238].CssClass = color; } if (fichas[i].InnerText.Contains("T12")) { botones[239].CssClass = color; }

                    if (fichas[i].InnerText.Contains("A13")) { botones[240].CssClass = color; } if (fichas[i].InnerText.Contains("B13")) { botones[241].CssClass = color; } if (fichas[i].InnerText.Contains("C13")) { botones[242].CssClass = color; } if (fichas[i].InnerText.Contains("D13")) { botones[243].CssClass = color; } if (fichas[i].InnerText.Contains("E13")) { botones[244].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F13")) { botones[245].CssClass = color; } if (fichas[i].InnerText.Contains("G13")) { botones[246].CssClass = color; } if (fichas[i].InnerText.Contains("H13")) { botones[247].CssClass = color; } if (fichas[i].InnerText.Contains("I13")) { botones[248].CssClass = color; } if (fichas[i].InnerText.Contains("J13")) { botones[249].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K13")) { botones[250].CssClass = color; } if (fichas[i].InnerText.Contains("L13")) { botones[251].CssClass = color; } if (fichas[i].InnerText.Contains("M13")) { botones[252].CssClass = color; } if (fichas[i].InnerText.Contains("N13")) { botones[253].CssClass = color; } if (fichas[i].InnerText.Contains("O13")) { botones[254].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P13")) { botones[255].CssClass = color; } if (fichas[i].InnerText.Contains("Q13")) { botones[256].CssClass = color; } if (fichas[i].InnerText.Contains("R13")) { botones[257].CssClass = color; } if (fichas[i].InnerText.Contains("S13")) { botones[258].CssClass = color; } if (fichas[i].InnerText.Contains("T13")) { botones[259].CssClass = color; }

                    if (fichas[i].InnerText.Contains("A14")) { botones[260].CssClass = color; } if (fichas[i].InnerText.Contains("B14")) { botones[261].CssClass = color; } if (fichas[i].InnerText.Contains("C14")) { botones[262].CssClass = color; } if (fichas[i].InnerText.Contains("D14")) { botones[263].CssClass = color; } if (fichas[i].InnerText.Contains("E14")) { botones[264].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F14")) { botones[265].CssClass = color; } if (fichas[i].InnerText.Contains("G14")) { botones[266].CssClass = color; } if (fichas[i].InnerText.Contains("H14")) { botones[267].CssClass = color; } if (fichas[i].InnerText.Contains("I14")) { botones[268].CssClass = color; } if (fichas[i].InnerText.Contains("J14")) { botones[269].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K14")) { botones[270].CssClass = color; } if (fichas[i].InnerText.Contains("L14")) { botones[271].CssClass = color; } if (fichas[i].InnerText.Contains("M14")) { botones[272].CssClass = color; } if (fichas[i].InnerText.Contains("N14")) { botones[273].CssClass = color; } if (fichas[i].InnerText.Contains("O14")) { botones[274].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P14")) { botones[275].CssClass = color; } if (fichas[i].InnerText.Contains("Q14")) { botones[276].CssClass = color; } if (fichas[i].InnerText.Contains("R14")) { botones[277].CssClass = color; } if (fichas[i].InnerText.Contains("S14")) { botones[278].CssClass = color; } if (fichas[i].InnerText.Contains("T14")) { botones[279].CssClass = color; }

                    if (fichas[i].InnerText.Contains("A15")) { botones[280].CssClass = color; } if (fichas[i].InnerText.Contains("B15")) { botones[281].CssClass = color; } if (fichas[i].InnerText.Contains("C15")) { botones[282].CssClass = color; } if (fichas[i].InnerText.Contains("D15")) { botones[283].CssClass = color; } if (fichas[i].InnerText.Contains("E15")) { botones[284].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F15")) { botones[285].CssClass = color; } if (fichas[i].InnerText.Contains("G15")) { botones[286].CssClass = color; } if (fichas[i].InnerText.Contains("H15")) { botones[287].CssClass = color; } if (fichas[i].InnerText.Contains("I15")) { botones[288].CssClass = color; } if (fichas[i].InnerText.Contains("J15")) { botones[289].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K15")) { botones[290].CssClass = color; } if (fichas[i].InnerText.Contains("L15")) { botones[291].CssClass = color; } if (fichas[i].InnerText.Contains("M15")) { botones[292].CssClass = color; } if (fichas[i].InnerText.Contains("N15")) { botones[293].CssClass = color; } if (fichas[i].InnerText.Contains("O15")) { botones[294].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P15")) { botones[295].CssClass = color; } if (fichas[i].InnerText.Contains("Q15")) { botones[296].CssClass = color; } if (fichas[i].InnerText.Contains("R15")) { botones[297].CssClass = color; } if (fichas[i].InnerText.Contains("S15")) { botones[298].CssClass = color; } if (fichas[i].InnerText.Contains("T15")) { botones[299].CssClass = color; }

                    if (fichas[i].InnerText.Contains("A16")) { botones[300].CssClass = color; } if (fichas[i].InnerText.Contains("B16")) { botones[301].CssClass = color; } if (fichas[i].InnerText.Contains("C16")) { botones[302].CssClass = color; } if (fichas[i].InnerText.Contains("D16")) { botones[303].CssClass = color; } if (fichas[i].InnerText.Contains("E16")) { botones[304].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F16")) { botones[305].CssClass = color; } if (fichas[i].InnerText.Contains("G16")) { botones[306].CssClass = color; } if (fichas[i].InnerText.Contains("H16")) { botones[307].CssClass = color; } if (fichas[i].InnerText.Contains("I16")) { botones[308].CssClass = color; } if (fichas[i].InnerText.Contains("J16")) { botones[309].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K16")) { botones[310].CssClass = color; } if (fichas[i].InnerText.Contains("L16")) { botones[311].CssClass = color; } if (fichas[i].InnerText.Contains("M16")) { botones[312].CssClass = color; } if (fichas[i].InnerText.Contains("N16")) { botones[313].CssClass = color; } if (fichas[i].InnerText.Contains("O16")) { botones[314].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P16")) { botones[315].CssClass = color; } if (fichas[i].InnerText.Contains("Q16")) { botones[316].CssClass = color; } if (fichas[i].InnerText.Contains("R16")) { botones[317].CssClass = color; } if (fichas[i].InnerText.Contains("S16")) { botones[318].CssClass = color; } if (fichas[i].InnerText.Contains("T16")) { botones[319].CssClass = color; }

                    if (fichas[i].InnerText.Contains("A17")) { botones[320].CssClass = color; } if (fichas[i].InnerText.Contains("B17")) { botones[321].CssClass = color; } if (fichas[i].InnerText.Contains("C17")) { botones[322].CssClass = color; } if (fichas[i].InnerText.Contains("D17")) { botones[323].CssClass = color; } if (fichas[i].InnerText.Contains("E17")) { botones[324].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F17")) { botones[325].CssClass = color; } if (fichas[i].InnerText.Contains("G17")) { botones[326].CssClass = color; } if (fichas[i].InnerText.Contains("H17")) { botones[327].CssClass = color; } if (fichas[i].InnerText.Contains("I17")) { botones[328].CssClass = color; } if (fichas[i].InnerText.Contains("J17")) { botones[329].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K17")) { botones[330].CssClass = color; } if (fichas[i].InnerText.Contains("L17")) { botones[331].CssClass = color; } if (fichas[i].InnerText.Contains("M17")) { botones[332].CssClass = color; } if (fichas[i].InnerText.Contains("N17")) { botones[333].CssClass = color; } if (fichas[i].InnerText.Contains("O17")) { botones[334].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P17")) { botones[335].CssClass = color; } if (fichas[i].InnerText.Contains("Q17")) { botones[336].CssClass = color; } if (fichas[i].InnerText.Contains("R17")) { botones[337].CssClass = color; } if (fichas[i].InnerText.Contains("S17")) { botones[338].CssClass = color; } if (fichas[i].InnerText.Contains("T17")) { botones[339].CssClass = color; }

                    if (fichas[i].InnerText.Contains("A18")) { botones[340].CssClass = color; } if (fichas[i].InnerText.Contains("B18")) { botones[341].CssClass = color; } if (fichas[i].InnerText.Contains("C18")) { botones[342].CssClass = color; } if (fichas[i].InnerText.Contains("D18")) { botones[343].CssClass = color; } if (fichas[i].InnerText.Contains("E18")) { botones[344].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F18")) { botones[345].CssClass = color; } if (fichas[i].InnerText.Contains("G18")) { botones[346].CssClass = color; } if (fichas[i].InnerText.Contains("H18")) { botones[347].CssClass = color; } if (fichas[i].InnerText.Contains("I18")) { botones[348].CssClass = color; } if (fichas[i].InnerText.Contains("J18")) { botones[349].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K18")) { botones[350].CssClass = color; } if (fichas[i].InnerText.Contains("L18")) { botones[351].CssClass = color; } if (fichas[i].InnerText.Contains("M18")) { botones[352].CssClass = color; } if (fichas[i].InnerText.Contains("N18")) { botones[353].CssClass = color; } if (fichas[i].InnerText.Contains("O18")) { botones[354].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P18")) { botones[355].CssClass = color; } if (fichas[i].InnerText.Contains("Q18")) { botones[356].CssClass = color; } if (fichas[i].InnerText.Contains("R18")) { botones[357].CssClass = color; } if (fichas[i].InnerText.Contains("S18")) { botones[358].CssClass = color; } if (fichas[i].InnerText.Contains("T18")) { botones[359].CssClass = color; }

                    if (fichas[i].InnerText.Contains("A19")) { botones[360].CssClass = color; } if (fichas[i].InnerText.Contains("B19")) { botones[361].CssClass = color; } if (fichas[i].InnerText.Contains("C19")) { botones[362].CssClass = color; } if (fichas[i].InnerText.Contains("D19")) { botones[363].CssClass = color; } if (fichas[i].InnerText.Contains("E19")) { botones[364].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F19")) { botones[365].CssClass = color; } if (fichas[i].InnerText.Contains("G19")) { botones[366].CssClass = color; } if (fichas[i].InnerText.Contains("H19")) { botones[367].CssClass = color; } if (fichas[i].InnerText.Contains("I19")) { botones[368].CssClass = color; } if (fichas[i].InnerText.Contains("J19")) { botones[369].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K19")) { botones[370].CssClass = color; } if (fichas[i].InnerText.Contains("L19")) { botones[371].CssClass = color; } if (fichas[i].InnerText.Contains("M19")) { botones[372].CssClass = color; } if (fichas[i].InnerText.Contains("N19")) { botones[373].CssClass = color; } if (fichas[i].InnerText.Contains("O19")) { botones[374].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P19")) { botones[375].CssClass = color; } if (fichas[i].InnerText.Contains("Q19")) { botones[376].CssClass = color; } if (fichas[i].InnerText.Contains("R19")) { botones[377].CssClass = color; } if (fichas[i].InnerText.Contains("S19")) { botones[378].CssClass = color; } if (fichas[i].InnerText.Contains("T19")) { botones[379].CssClass = color; }

                    if (fichas[i].InnerText.Contains("A20")) { botones[380].CssClass = color; } if (fichas[i].InnerText.Contains("B20")) { botones[381].CssClass = color; } if (fichas[i].InnerText.Contains("C20")) { botones[382].CssClass = color; } if (fichas[i].InnerText.Contains("D20")) { botones[383].CssClass = color; } if (fichas[i].InnerText.Contains("E20")) { botones[384].CssClass = color; }
                    if (fichas[i].InnerText.Contains("F20")) { botones[385].CssClass = color; } if (fichas[i].InnerText.Contains("G20")) { botones[386].CssClass = color; } if (fichas[i].InnerText.Contains("H20")) { botones[387].CssClass = color; } if (fichas[i].InnerText.Contains("I20")) { botones[388].CssClass = color; } if (fichas[i].InnerText.Contains("J20")) { botones[389].CssClass = color; }
                    if (fichas[i].InnerText.Contains("K20")) { botones[390].CssClass = color; } if (fichas[i].InnerText.Contains("L20")) { botones[391].CssClass = color; } if (fichas[i].InnerText.Contains("M20")) { botones[392].CssClass = color; } if (fichas[i].InnerText.Contains("N20")) { botones[393].CssClass = color; } if (fichas[i].InnerText.Contains("O20")) { botones[394].CssClass = color; }
                    if (fichas[i].InnerText.Contains("P20")) { botones[395].CssClass = color; } if (fichas[i].InnerText.Contains("Q20")) { botones[396].CssClass = color; } if (fichas[i].InnerText.Contains("R20")) { botones[397].CssClass = color; } if (fichas[i].InnerText.Contains("S20")) { botones[398].CssClass = color; } if (fichas[i].InnerText.Contains("T20")) { botones[399].CssClass = color; }

                }

                XmlNodeList tiro = reader.GetElementsByTagName("siguienteTiro");
                for (int i = 0; i < tiro.Count; i++)
                {
                    turno.Text = char.ToUpper(tiro[i].InnerText[0]) + tiro[i].InnerText.Substring(1);
                }

                XmlNodeList movimientos = reader.GetElementsByTagName("movimientos");
                if (movimientos.Count > 0)
                {
                    XmlNodeList op_moves = ((XmlElement)movimientos[0]).GetElementsByTagName("Jugador1");
                    foreach (XmlElement Omoves in op_moves)
                    {
                        movimiento_user.Text = Omoves.InnerText;
                    }
                    XmlNodeList user_moves = ((XmlElement)movimientos[0]).GetElementsByTagName("Jugador2");
                    foreach (XmlElement Umoves in user_moves)
                    {
                        movimiento_oponente.Text = Umoves.InnerText;
                    }
                }
                Get_Score(null);
            }
        }


        public string Colorear(string color)
        {
            switch (color)
            {
                case "Rojo":
                    return rojoCss;
                case "Amarillo":
                    return amarilloCss;
                case "Azul":
                    return azulCss;
                case "Verde":
                    return verdeCss;
                case "Naranja":
                    return naranjaCss;
                case "Violeta":
                    return violetaCss;
                case "Blanco":
                    return blanco;
                case "Negro":
                    return negro;
                case "Celeste":
                    return celesteCss;
                case "Gris":
                    return grisCss;
                default:
                    return "";
            }
        }

        protected string Ver_ficha(int boton)
        {

            WebControl[] botones = { a1, b1, c1, d1, e1, f1, g1, h1, i1, j1, k1, l1, m1, n1, o1, p1, q1, r1, s1, t1, a2, b2, c2, d2, e2, f2, g2, h2, i2, j2, k2, l2, m2, n2, o2, p2, q2, r2, s2, t2, a3, b3, c3, d3, e3, f3, g3, h3, i3, j3, k3, l3, m3, n3, o3, p3, q3, r3, s3, t3, a4, b4, c4, d4, e4, f4, g4, h4, i4, j4, k4, l4, m4, n4, o4, p4, q4, r4, s4, t4, a5, b5, c5, d5, e5, f5, g5, h5, i5, j5, k5, l5, m5, n5, o5, p5, q5, r5, s5, t5, a6, b6, c6, d6, e6, f6, g6, h6, i6, j6, k6, l6, m6, n6, o6, p6, q6, r6, s6, t6, a7, b7, c7, d7, e7, f7, g7, h7, i7, j7, k7, l7, m7, n7, o7, p7, q7, r7, s7, t7, a8, b8, c8, d8, e8, f8, g8, h8, i8, j8, k8, l8, m8, n8, o8, p8, q8, r8, s8, t8, a9, b9, c9, d9, e9, f9, g9, h9, i9, j9, k9, l9, m9, n9, o9, p9, q9, r9, s9, t9, a10, b10, c10, d10, e10, f10, g10, h10, i10, j10, k10, l10, m10, n10, o10, p10, q10, r10, s10, t10, a11, b11, c11, d11, e11, f11, g11, h11, i11, j11, k11, l11, m11, n11, o11, p11, q11, r11, s11, t11, a12, b12, c12, d12, e12, f12, g12, h12, i12, j12, k12, l12, m12, n12, o12, p12, q12, r12, s12, t12, a13, b13, c13, d13, e13, f13, g13, h13, i13, j13, k13, l13, m13, n13, o13, p13, q13, r13, s13, t13, a14, b14, c14, d14, e14, f14, g14, h14, i14, j14, k14, l14, m14, n14, o14, p14, q14, r14, s14, t14, a15, b15, c15, d15, e15, f15, g15, h15, i15, j15, k15, l15, m15, n15, o15, p15, q15, r15, s15, t15, a16, b16, c16, d16, e16, f16, g16, h16, i16, j16, k16, l16, m16, n16, o16, p16, q16, r16, s16, t16, a17, b17, c17, d17, e17, f17, g17, h17, i17, j17, k17, l17, m17, n17, o17, p17, q17, r17, s17, t17, a18, b18, c18, d18, e18, f18, g18, h18, i18, j18, k18, l18, m18, n18, o18, p18, q18, r18, s18, t18, a19, b19, c19, d19, e19, f19, g19, h19, i19, j19, k19, l19, m19, n19, o19, p19, q19, r19, s19, t19, a20, b20, c20, d20, e20, f20, g20, h20, i20, j20, k20, l20, m20, n20, o20, p20, q20, r20, s20, t20, };

            switch (botones[boton].CssClass.ToString())
            {
                case "btn btn-lg border-dark rounded-0 btn-Rojo":
                    return "rojo";
                case "btn btn-lg border-dark rounded-0 btn-Amarillo":
                    return "amarillo";
                case "btn btn-lg border-dark rounded-0 btn-Azul":
                    return "azul";
                case "btn btn-lg border-dark rounded-0 btn-Naranja":
                    return "naranja";
                case "btn btn-lg border-dark rounded-0 btn-Verde":
                    return "verde";
                case "btn btn-lg border-dark rounded-0 btn-Violeta":
                    return "violeta";
                case "btn btn-lg border-dark rounded-0 btn-Celeste":
                    return "celeste";
                case "btn btn-lg border-dark rounded-0 btn-Gris":
                    return "gris";
                case "btn btn-lg border-dark rounded-0 btn-Blanco":
                    return "blanco";
                case "btn btn-lg border-dark rounded-0 btn-Negro":
                    return "negro";
                default:
                    return "vacio";
            }
        }

        protected void GenerarXml(object sender, EventArgs e)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t"
            };

            string[] col = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T" };
            string[] fila = { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "7", "7", "7", "7", "7", "7", "7", "7", "7", "7", "7", "7", "7", "7", "7", "7", "7", "7", "7", "7", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "9", "9", "9", "9", "9", "9", "9", "9", "9", "9", "9", "9", "9", "9", "9", "9", "9", "9", "9", "9", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "12", "13", "13", "13", "13", "13", "13", "13", "13", "13", "13", "13", "13", "13", "13", "13", "13", "13", "13", "13", "13", "14", "14", "14", "14", "14", "14", "14", "14", "14", "14", "14", "14", "14", "14", "14", "14", "14", "14", "14", "14", "15", "15", "15", "15", "15", "15", "15", "15", "15", "15", "15", "15", "15", "15", "15", "15", "15", "15", "15", "15", "16", "16", "16", "16", "16", "16", "16", "16", "16", "16", "16", "16", "16", "16", "16", "16", "16", "16", "16", "16", "17", "17", "17", "17", "17", "17", "17", "17", "17", "17", "17", "17", "17", "17", "17", "17", "17", "17", "17", "17", "18", "18", "18", "18", "18", "18", "18", "18", "18", "18", "18", "18", "18", "18", "18", "18", "18", "18", "18", "18", "19", "19", "19", "19", "19", "19", "19", "19", "19", "19", "19", "19", "19", "19", "19", "19", "19", "19", "19", "19", "20", "20", "20", "20", "20", "20", "20", "20", "20", "20", "20", "20", "20", "20", "20", "20", "20", "20", "20", "20" };
            int filas = int.Parse(dimension.Text.Substring(0, dimension.Text.IndexOf(',')));
            int columnas = int.Parse(dimension.Text.Substring(dimension.Text.IndexOf(',') + 1));

            string ruta = Server.MapPath(".") + "\\XML\\" + "Partida Xtream.xml";

            XmlWriter xmlWriter = XmlWriter.Create(ruta, settings);

            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("partida");

            xmlWriter.WriteStartElement("filas");
            xmlWriter.WriteString(filas.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("columnas");
            xmlWriter.WriteString(columnas.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Jugador1");
            for (int i = 0; i < ColoresUsuario().Count; i++)
            {
                xmlWriter.WriteStartElement("color");
                xmlWriter.WriteString(ColoresUsuario()[i].ToLower());
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Jugador2");
            for (int j = 0; j < ColoresOponente().Count; j++)
            {
                xmlWriter.WriteStartElement("color");
                xmlWriter.WriteString(ColoresOponente()[j].ToLower());
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Modalidad");
            xmlWriter.WriteString(char.ToUpper(Session["modalidad"].ToString()[0]) + Session["modalidad"].ToString().Substring(1));
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("tablero");

            for (int i = 0; i < 400; i++)
            {
                string color = Ver_ficha(i);
                if (color != "vacio")
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
            }

            xmlWriter.WriteStartElement("siguienteTiro");
            xmlWriter.WriteStartElement("color");
                xmlWriter.WriteString(turno.Text.ToLower());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("movimientos");
            xmlWriter.WriteStartElement("Jugador1");
            xmlWriter.WriteString(movimiento_user.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Jugador2");
            xmlWriter.WriteString(movimiento_oponente.Text);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

            Response.Clear();
            Response.ClearHeaders();
            Response.ContentType = "text/xml";
            Response.AppendHeader("Content-Disposition", "attachment; filename=\"Partida Xtream.xml\"");
            Response.TransmitFile(ruta);
            Response.End();
        }

        public WebControl[] Tipo(string a)
        {
            WebControl[] fila1 = { a1, b1, c1, d1, e1, f1, g1, h1, i1, j1, k1, l1, m1, n1, o1, p1, q1, r1, s1, t1 };
            WebControl[] fila2 = { a2, b2, c2, d2, e2, f2, g2, h2, i2, j2, k2, l2, m2, n2, o2, p2, q2, r2, s2, t2 };
            WebControl[] fila3 = { a3, b3, c3, d3, e3, f3, g3, h3, i3, j3, k3, l3, m3, n3, o3, p3, q3, r3, s3, t3 };
            WebControl[] fila4 = { a4, b4, c4, d4, e4, f4, g4, h4, i4, j4, k4, l4, m4, n4, o4, p4, q4, r4, s4, t4 };
            WebControl[] fila5 = { a5, b5, c5, d5, e5, f5, g5, h5, i5, j5, k5, l5, m5, n5, o5, p5, q5, r5, s5, t5 };
            WebControl[] fila6 = { a6, b6, c6, d6, e6, f6, g6, h6, i6, j6, k6, l6, m6, n6, o6, p6, q6, r6, s6, t6 };
            WebControl[] fila7 = { a7, b7, c7, d7, e7, f7, g7, h7, i7, j7, k7, l7, m7, n7, o7, p7, q7, r7, s7, t7 };
            WebControl[] fila8 = { a8, b8, c8, d8, e8, f8, g8, h8, i8, j8, k8, l8, m8, n8, o8, p8, q8, r8, s8, t8 };
            WebControl[] fila9 = { a9, b9, c9, d9, e9, f9, g9, h9, i9, j9, k9, l9, m9, n9, o9, p9, q9, r9, s9, t9 };
            WebControl[] fila10 = { a10, b10, c10, d10, e10, f10, g10, h10, i10, j10, k10, l10, m10, n10, o10, p10, q10, r10, s10, t10 };
            WebControl[] fila11 = { a11, b11, c11, d11, e11, f11, g11, h11, i11, j11, k11, l11, m11, n11, o11, p11, q11, r11, s11, t11 };
            WebControl[] fila12 = { a12, b12, c12, d12, e12, f12, g12, h12, i12, j12, k12, l12, m12, n12, o12, p12, q12, r12, s12, t12 };
            WebControl[] fila13 = { a13, b13, c13, d13, e13, f13, g13, h13, i13, j13, k13, l13, m13, n13, o13, p13, q13, r13, s13, t13 };
            WebControl[] fila14 = { a14, b14, c14, d14, e14, f14, g14, h14, i14, j14, k14, l14, m14, n14, o14, p14, q14, r14, s14, t14 };
            WebControl[] fila15 = { a15, b15, c15, d15, e15, f15, g15, h15, i15, j15, k15, l15, m15, n15, o15, p15, q15, r15, s15, t15 };
            WebControl[] fila16 = { a16, b16, c16, d16, e16, f16, g16, h16, i16, j16, k16, l16, m16, n16, o16, p16, q16, r16, s16, t16 };
            WebControl[] fila17 = { a17, b17, c17, d17, e17, f17, g17, h17, i17, j17, k17, l17, m17, n17, o17, p17, q17, r17, s17, t17 };
            WebControl[] fila18 = { a18, b18, c18, d18, e18, f18, g18, h18, i18, j18, k18, l18, m18, n18, o18, p18, q18, r18, s18, t18 };
            WebControl[] fila19 = { a19, b19, c19, d19, e19, f19, g19, h19, i19, j19, k19, l19, m19, n19, o19, p19, q19, r19, s19, t19 };
            WebControl[] fila20 = { a20, b20, c20, d20, e20, f20, g20, h20, i20, j20, k20, l20, m20, n20, o20, p20, q20, r20, s20, t20 };

            WebControl[] colA = { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20 };
            WebControl[] colB = { b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, b14, b15, b16, b17, b18, b19, b20 };
            WebControl[] colC = { c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20 };
            WebControl[] colD = { d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, d13, d14, d15, d16, d17, d18, d19, d20 };
            WebControl[] colE = { e1, e2, e3, e4, e5, e6, e7, e8, e9, e10, e11, e12, e13, e14, e15, e16, e17, e18, e19, e20 };
            WebControl[] colF = { f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16, f17, f18, f19, f20 };
            WebControl[] colG = { g1, g2, g3, g4, g5, g6, g7, g8, g9, g10, g11, g12, g13, g14, g15, g16, g17, g18, g19, g20 };
            WebControl[] colH = { h1, h2, h3, h4, h5, h6, h7, h8, h9, h10, h11, h12, h13, h14, h15, h16, h17, h18, h19, h20 };
            WebControl[] colI = { i1, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11, i12, i13, i14, i15, i16, i17, i18, i19, i20 };
            WebControl[] colJ = { j1, j2, j3, j4, j5, j6, j7, j8, j9, j10, j11, j12, j13, j14, j15, j16, j17, j18, j19, j20 };
            WebControl[] colK = { k1, k2, k3, k4, k5, k6, k7, k8, k9, k10, k11, k12, k13, k14, k15, k16, k17, k18, k19, k20 };
            WebControl[] colL = { l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15, l16, l17, l18, l19, l20 };
            WebControl[] colM = { m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16, m17, m18, m19, m20 };
            WebControl[] colN = { n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, n11, n12, n13, n14, n15, n16, n17, n18, n19, n20 };
            WebControl[] colO = { o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16, o17, o18, o19, o20 };
            WebControl[] colP = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20 };
            WebControl[] colQ = { q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, q12, q13, q14, q15, q16, q17, q18, q19, q20 };
            WebControl[] colR = { r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17, r18, r19, r20 };
            WebControl[] colS = { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17, s18, s19, s20 };
            WebControl[] colT = { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20 };

            WebControl[] diagPositiva1 = { a1 };
            WebControl[] diagPositiva2 = { a2, b1 };
            WebControl[] diagPositiva3 = { a3, b2, c1 };
            WebControl[] diagPositiva4 = { a4, b3, c2, d1 };
            WebControl[] diagPositiva5 = { a5, b4, c3, d2, e1 };
            WebControl[] diagPositiva6 = { a6, b5, c4, d3, e2, f1 };
            WebControl[] diagPositiva7 = { a7, b6, c5, d4, e3, f2, g1 };
            WebControl[] diagPositiva8 = { a8, b7, c6, d5, e4, f3, g2, h1 };
            WebControl[] diagPositiva9 = { a9, b8, c7, d6, e5, f4, g3, h2, i1 };
            WebControl[] diagPositiva10 = { a10, b9, c8, d7, e6, f5, g4, h3, i2, j1 };
            WebControl[] diagPositiva11 = { a11, b10, c9, d8, e7, f6, g5, h4, i3, j2, k1 };
            WebControl[] diagPositiva12 = { a12, b11, c10, d9, e8, f7, g6, h5, i4, j3, k2, l1 };
            WebControl[] diagPositiva13 = { a13, b12, c11, d10, e9, f8, g7, h6, i5, j4, k3, l2, m1 };
            WebControl[] diagPositiva14 = { a14, b13, c12, d11, e10, f9, g8, h7, i6, j5, k4, l3, m2, n1 };
            WebControl[] diagPositiva15 = { a15, b14, c13, d12, e11, f10, g9, h8, i7, j6, k5, l4, m3, n2, o1 };
            WebControl[] diagPositiva16 = { a16, b15, c14, d13, e12, f11, g10, h9, i8, j7, k6, l5, m4, n3, o2, p1 };
            WebControl[] diagPositiva17 = { a17, b16, c15, d14, e13, f12, g11, h10, i9, j8, k7, l6, m5, n4, o3, p2, q1 };
            WebControl[] diagPositiva18 = { a18, b17, c16, d15, e14, f13, g12, h11, i10, j9, k8, l7, m6, n5, o4, p3, q2, r1 };
            WebControl[] diagPositiva19 = { a19, b18, c17, d16, e15, f14, g13, h12, i11, j10, k9, l8, m7, n6, o5, p4, q3, r2, s1 };
            WebControl[] diagPositiva20 = { a20, b19, c18, d17, e16, f15, g14, h13, i12, j11, k10, l9, m8, n7, o6, p5, q4, r3, s2, t1 };
            WebControl[] diagPositiva21 = { b20, c19, d18, e17, f16, g15, h14, i13, j12, k11, l10, m9, n8, o7, p6, q5, r4, s3, t2 };
            WebControl[] diagPositiva22 = { c20, d19, e18, f17, g16, h15, i14, j13, k12, l11, m10, n9, o8, p7, q6, r5, s4, t3 };
            WebControl[] diagPositiva23 = { d20, e19, f18, g17, h16, i15, j14, k13, l12, m11, n10, o9, p8, q7, r6, s5, t4 };
            WebControl[] diagPositiva24 = { e20, f19, g18, h17, i16, j15, k14, l13, m12, n11, o10, p9, q8, r7, s6, t5 };
            WebControl[] diagPositiva25 = { f20, g19, h18, i17, j16, k15, l14, m13, n12, o11, p10, q9, r8, s7, t6 };
            WebControl[] diagPositiva26 = { g20, h19, i18, j17, k16, l15, m14, n13, o12, p11, q10, r9, s8, t7 };
            WebControl[] diagPositiva27 = { h20, i19, j18, k17, l16, m15, n14, o13, p12, q11, r10, s9, t8 };
            WebControl[] diagPositiva28 = { i20, j19, k18, l17, m16, n15, o14, p13, q12, r11, s10, t9 };
            WebControl[] diagPositiva29 = { j20, k19, l18, m17, n16, o15, p14, q13, r12, s11, t10 };
            WebControl[] diagPositiva30 = { k20, l19, m18, n17, o16, p15, q14, r13, s12, t11 };
            WebControl[] diagPositiva31 = { l20, m19, n18, o17, p16, q15, r14, s13, t12 };
            WebControl[] diagPositiva32 = { m20, n19, o18, p17, q16, r15, s14, t13 };
            WebControl[] diagPositiva33 = { n20, o19, p18, q17, r16, s15, t14 };
            WebControl[] diagPositiva34 = { o20, p19, q18, r17, s16, t15 };
            WebControl[] diagPositiva35 = { p20, q19, r18, s17, t16 };
            WebControl[] diagPositiva36 = { q20, r19, s18, t17 };
            WebControl[] diagPositiva37 = { r20, s19, t18 };
            WebControl[] diagPositiva38 = { s20, t19 };
            WebControl[] diagPositiva39 = { t20 };

            WebControl[] diagNegativa1 = { t1 };
            WebControl[] diagNegativa2 = { s1, t2 };
            WebControl[] diagNegativa3 = { r1, s2, t3 };
            WebControl[] diagNegativa4 = { q1, r2, s3, t4 };
            WebControl[] diagNegativa5 = { p1, q2, r3, s4, t5 };
            WebControl[] diagNegativa6 = { o1, p2, q3, r4, s5, t6 };
            WebControl[] diagNegativa7 = { n1, o2, p3, q4, r5, s6, t7 };
            WebControl[] diagNegativa8 = { m1, n2, o3, p4, q5, r6, s7, t8 };
            WebControl[] diagNegativa9 = { l1, m2, n3, o4, p5, q6, r7, s8, t9 };
            WebControl[] diagNegativa10 = { k1, l2, m3, n4, o5, p6, q7, r8, s9, t10 };
            WebControl[] diagNegativa11 = { j1, k2, l3, m4, n5, o6, p7, q8, r9, s10, t11 };
            WebControl[] diagNegativa12 = { i1, j2, k3, l4, m5, n6, o7, p8, q9, r10, s11, t12 };
            WebControl[] diagNegativa13 = { h1, i2, j3, k4, l5, m6, n7, o8, p9, q10, r11, s12, t13 };
            WebControl[] diagNegativa14 = { g1, h2, i3, j4, k5, l6, m7, n8, o9, p10, q11, r12, s13, t14 };
            WebControl[] diagNegativa15 = { f1, g2, h3, i4, j5, k6, l7, m8, n9, o10, p11, q12, r13, s14, t15 };
            WebControl[] diagNegativa16 = { e1, f2, g3, h4, i5, j6, k7, l8, m9, n10, o11, p12, q13, r14, s15, t16 };
            WebControl[] diagNegativa17 = { d1, e2, f3, g4, h5, i6, j7, k8, l9, m10, n11, o12, p13, q14, r15, s16, t17 };
            WebControl[] diagNegativa18 = { c1, d2, e3, f4, g5, h6, i7, j8, k9, l10, m11, n12, o13, p14, q15, r16, s17, t18 };
            WebControl[] diagNegativa19 = { b1, c2, d3, e4, f5, g6, h7, i8, j9, k10, l11, m12, n13, o14, p15, q16, r17, s18, t19 };
            WebControl[] diagNegativa20 = { a1, b2, c3, d4, e5, f6, g7, h8, i9, j10, k11, l12, m13, n14, o15, p16, q17, r18, s19, t20 };
            WebControl[] diagNegativa21 = { a2, b3, c4, d5, e6, f7, g8, h9, i10, j11, k12, l13, m14, n15, o16, p17, q18, r19, s20 };
            WebControl[] diagNegativa22 = { a3, b4, c5, d6, e7, f8, g9, h10, i11, j12, k13, l14, m15, n16, o17, p18, q19, r20 };
            WebControl[] diagNegativa23 = { a4, b5, c6, d7, e8, f9, g10, h11, i12, j13, k14, l15, m16, n17, o18, p19, q20 };
            WebControl[] diagNegativa24 = { a5, b6, c7, d8, e9, f10, g11, h12, i13, j14, k15, l16, m17, n18, o19, p20 };
            WebControl[] diagNegativa25 = { a6, b7, c8, d9, e10, f11, g12, h13, i14, j15, k16, l17, m18, n19, o20 };
            WebControl[] diagNegativa26 = { a7, b8, c9, d10, e11, f12, g13, h14, i15, j16, k17, l18, m19, n20 };
            WebControl[] diagNegativa27 = { a8, b9, c10, d11, e12, f13, g14, h15, i16, j17, k18, l19, m20 };
            WebControl[] diagNegativa28 = { a9, b10, c11, d12, e13, f14, g15, h16, i17, j18, k19, l20 };
            WebControl[] diagNegativa29 = { a10, b11, c12, d13, e14, f15, g16, h17, i18, j19, k20 };
            WebControl[] diagNegativa30 = { a11, b12, c13, d14, e15, f16, g17, h18, i19, j20 };
            WebControl[] diagNegativa31 = { a12, b13, c14, d15, e16, f17, g18, h19, i20 };
            WebControl[] diagNegativa32 = { a13, b14, c15, d16, e17, f18, g19, h20 };
            WebControl[] diagNegativa33 = { a14, b15, c16, d17, e18, f19, g20 };
            WebControl[] diagNegativa34 = { a15, b16, c17, d18, e19, f20 };
            WebControl[] diagNegativa35 = { a16, b17, c18, d19, e20 };
            WebControl[] diagNegativa36 = { a17, b18, c19, d20 };
            WebControl[] diagNegativa37 = { a18, b19, c20 };
            WebControl[] diagNegativa38 = { a19, b20 };
            WebControl[] diagNegativa39 = { a20 };

            if (a == "fila1") return fila1;
            if (a == "fila2") return fila2;
            if (a == "fila3") return fila3;
            if (a == "fila4") return fila4;
            if (a == "fila5") return fila5;
            if (a == "fila6") return fila6;
            if (a == "fila7") return fila7;
            if (a == "fila8") return fila8;
            if (a == "fila9") return fila9;
            if (a == "fila10") return fila10;
            if (a == "fila11") return fila11;
            if (a == "fila12") return fila12;
            if (a == "fila13") return fila13;
            if (a == "fila14") return fila14;
            if (a == "fila15") return fila15;
            if (a == "fila16") return fila16;
            if (a == "fila17") return fila17;
            if (a == "fila18") return fila18;
            if (a == "fila19") return fila19;
            if (a == "fila20") return fila20;

            if (a == "colA") return colA;
            if (a == "colB") return colB;
            if (a == "colC") return colC;
            if (a == "colD") return colD;
            if (a == "colE") return colE;
            if (a == "colF") return colF;
            if (a == "colG") return colG;
            if (a == "colH") return colH;
            if (a == "colI") return colI;
            if (a == "colJ") return colJ;
            if (a == "colK") return colK;
            if (a == "colL") return colL;
            if (a == "colM") return colM;
            if (a == "colN") return colN;
            if (a == "colO") return colO;
            if (a == "colP") return colP;
            if (a == "colQ") return colQ;
            if (a == "colR") return colR;
            if (a == "colS") return colS;
            if (a == "colT") return colT;

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
            if (a == "diagPos16") return diagPositiva16;
            if (a == "diagPos17") return diagPositiva17;
            if (a == "diagPos18") return diagPositiva18;
            if (a == "diagPos19") return diagPositiva19;
            if (a == "diagPos20") return diagPositiva20;
            if (a == "diagPos21") return diagPositiva21;
            if (a == "diagPos22") return diagPositiva22;
            if (a == "diagPos23") return diagPositiva23;
            if (a == "diagPos24") return diagPositiva24;
            if (a == "diagPos25") return diagPositiva25;
            if (a == "diagPos26") return diagPositiva26;
            if (a == "diagPos27") return diagPositiva27;
            if (a == "diagPos28") return diagPositiva28;
            if (a == "diagPos29") return diagPositiva29;
            if (a == "diagPos30") return diagPositiva30;
            if (a == "diagPos31") return diagPositiva31;
            if (a == "diagPos32") return diagPositiva32;
            if (a == "diagPos33") return diagPositiva33;
            if (a == "diagPos34") return diagPositiva34;
            if (a == "diagPos35") return diagPositiva35;
            if (a == "diagPos36") return diagPositiva36;
            if (a == "diagPos37") return diagPositiva37;
            if (a == "diagPos38") return diagPositiva38;
            if (a == "diagPos39") return diagPositiva39;

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
            if (a == "diagNeg16") return diagNegativa16;
            if (a == "diagNeg17") return diagNegativa17;
            if (a == "diagNeg18") return diagNegativa18;
            if (a == "diagNeg19") return diagNegativa19;
            if (a == "diagNeg20") return diagNegativa20;
            if (a == "diagNeg21") return diagNegativa21;
            if (a == "diagNeg22") return diagNegativa22;
            if (a == "diagNeg23") return diagNegativa23;
            if (a == "diagNeg24") return diagNegativa24;
            if (a == "diagNeg25") return diagNegativa25;
            if (a == "diagNeg26") return diagNegativa26;
            if (a == "diagNeg27") return diagNegativa27;
            if (a == "diagNeg28") return diagNegativa28;
            if (a == "diagNeg29") return diagNegativa29;
            if (a == "diagNeg30") return diagNegativa30;
            if (a == "diagNeg31") return diagNegativa31;
            if (a == "diagNeg32") return diagNegativa32;
            if (a == "diagNeg33") return diagNegativa33;
            if (a == "diagNeg34") return diagNegativa34;
            if (a == "diagNeg35") return diagNegativa35;
            if (a == "diagNeg36") return diagNegativa36;
            if (a == "diagNeg37") return diagNegativa37;
            if (a == "diagNeg38") return diagNegativa38;
            if (a == "diagNeg39") return diagNegativa39;

            else return null;
        }

        public void Ceder_turno(object sender, EventArgs e)
        {

            Turno_siguiente(turno.Text);

        }

        public void Get_Score(WebControl boton)
        {
            WebControl[] botones = { a1, b1, c1, d1, e1, f1, g1, h1, i1, j1, k1, l1, m1, n1, o1, p1, q1, r1, s1, t1, a2, b2, c2, d2, e2, f2, g2, h2, i2, j2, k2, l2, m2, n2, o2, p2, q2, r2, s2, t2, a3, b3, c3, d3, e3, f3, g3, h3, i3, j3, k3, l3, m3, n3, o3, p3, q3, r3, s3, t3, a4, b4, c4, d4, e4, f4, g4, h4, i4, j4, k4, l4, m4, n4, o4, p4, q4, r4, s4, t4, a5, b5, c5, d5, e5, f5, g5, h5, i5, j5, k5, l5, m5, n5, o5, p5, q5, r5, s5, t5, a6, b6, c6, d6, e6, f6, g6, h6, i6, j6, k6, l6, m6, n6, o6, p6, q6, r6, s6, t6, a7, b7, c7, d7, e7, f7, g7, h7, i7, j7, k7, l7, m7, n7, o7, p7, q7, r7, s7, t7, a8, b8, c8, d8, e8, f8, g8, h8, i8, j8, k8, l8, m8, n8, o8, p8, q8, r8, s8, t8, a9, b9, c9, d9, e9, f9, g9, h9, i9, j9, k9, l9, m9, n9, o9, p9, q9, r9, s9, t9, a10, b10, c10, d10, e10, f10, g10, h10, i10, j10, k10, l10, m10, n10, o10, p10, q10, r10, s10, t10, a11, b11, c11, d11, e11, f11, g11, h11, i11, j11, k11, l11, m11, n11, o11, p11, q11, r11, s11, t11, a12, b12, c12, d12, e12, f12, g12, h12, i12, j12, k12, l12, m12, n12, o12, p12, q12, r12, s12, t12, a13, b13, c13, d13, e13, f13, g13, h13, i13, j13, k13, l13, m13, n13, o13, p13, q13, r13, s13, t13, a14, b14, c14, d14, e14, f14, g14, h14, i14, j14, k14, l14, m14, n14, o14, p14, q14, r14, s14, t14, a15, b15, c15, d15, e15, f15, g15, h15, i15, j15, k15, l15, m15, n15, o15, p15, q15, r15, s15, t15, a16, b16, c16, d16, e16, f16, g16, h16, i16, j16, k16, l16, m16, n16, o16, p16, q16, r16, s16, t16, a17, b17, c17, d17, e17, f17, g17, h17, i17, j17, k17, l17, m17, n17, o17, p17, q17, r17, s17, t17, a18, b18, c18, d18, e18, f18, g18, h18, i18, j18, k18, l18, m18, n18, o18, p18, q18, r18, s18, t18, a19, b19, c19, d19, e19, f19, g19, h19, i19, j19, k19, l19, m19, n19, o19, p19, q19, r19, s19, t19, a20, b20, c20, d20, e20, f20, g20, h20, i20, j20, k20, l20, m20, n20, o20, p20, q20, r20, s20, t20, };
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

            if (scores_user.Sum() == aux_usuario + 1 && int.Parse(max.Text) == 100) { boton.CssClass = vacio; score_user_aux--; turno.Text = aux_turno; }
            else if (scores_oponente.Sum() == aux_oponente + 1 && int.Parse(max.Text) == 100) { boton.CssClass = vacio; score_oponent_aux--; turno.Text = aux_turno; }

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
        }

        public void Terminar_Juego(object sender, EventArgs e)
        {
            finalizado = true;
            forzado = true;
            //edit luego para que no sea 64 si no MxN
            int filas = int.Parse(dimension.Text.Substring(0, dimension.Text.IndexOf(',')));
            int columnas = int.Parse(dimension.Text.Substring(dimension.Text.IndexOf(',') + 1));
            int total = filas * columnas;
            if (int.Parse(score1.Text) > int.Parse(score2.Text))
            {
                score1.Text = (total - int.Parse(score2.Text)).ToString();
                GameOver();
            }
            else if (int.Parse(score1.Text) < int.Parse(score2.Text))
            {
                score2.Text = (total - int.Parse(score1.Text)).ToString();
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
                string jugador_host = parametro.Substring(parametro.LastIndexOf("-")+1);
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
                                //if (ColoresUsuario().Count == 1 && ColoresOponente().Count == 1) 
                                //{
                                    permitido = true;
                                    aux = i;
                                //}
                                //else
                                //{
                                //    permitido = true;
                                //    aux = i;
                                //    break;
                                //}
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
                                //if (ColoresUsuario().Count == 1 && ColoresOponente().Count == 1)
                                //{
                                    permitido = true;
                                    aux = i;
                                //}
                                //else
                                //{
                                //    permitido = true;
                                //    aux = i;
                                //    break;
                                //}
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
                if (VerVacio(casilla, clic, aux))
                {
                    Comer(casilla, color, clic, aux);
                }

                if (VerVacio(casilla, clic, aux2))
                {
                    Comer(casilla, color, clic, aux2);
                }
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
                cronometro1.Visible = false;
                cronometro2.Visible = true;
                ClientScript.RegisterStartupScript(GetType(), "hwa", "reloj2()", true);//inicia cronometro
            }

            else if (listaOponente.Text.Contains(color))
            {
                turno.Text = listaColores.Text.Split(',')[int.Parse(indice1.Text)];
                indice2.Text = (int.Parse(indice2.Text) + 1).ToString();
                cronometro2.Visible = false;
                cronometro1.Visible = true;
                ClientScript.RegisterStartupScript(GetType(), "hwa", "reloj1()", true);
            }
        }

        public void ComerFicha(WebControl[] casilla, string color, WebControl boton)
        {
            int clic = Posicion(casilla, boton);
            int index = Verificar(casilla, color, clic);

            if (int.Parse(max.Text) < 16)
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

            else if (int.Parse(max.Text) >= 16)
            {
                if (FichaAlApar(casilla, color, clic))
                {
                    if (index != -1)
                    {
                        if (VerVacio(casilla, clic, index) == true)
                        {
                            Comer(casilla, color, clic, index);                            
                        }
                    }
                }
            }
        }

        public void Comer(WebControl[] casilla, string color, int clic, int index)
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

        public int Posicion(WebControl[] botones, WebControl boton)
        {
            return Array.IndexOf(botones, boton);
        }

        public WebControl[] Arreglo(WebControl boton, string tipo)
        {
            WebControl[][] fila = { Tipo("fila1"), Tipo("fila2"), Tipo("fila3"), Tipo("fila4"), Tipo("fila5"), Tipo("fila6"), Tipo("fila7"), Tipo("fila8"), Tipo("fila9"), Tipo("fila10"), Tipo("fila11"), Tipo("fila12"), Tipo("fila13"), Tipo("fila14"), Tipo("fila15"), Tipo("fila16"), Tipo("fila17"), Tipo("fila18"), Tipo("fila19"), Tipo("fila20") };
            WebControl[][] columna = { Tipo("colA"), Tipo("colB"), Tipo("colC"), Tipo("colD"), Tipo("colE"), Tipo("colF"), Tipo("colG"), Tipo("colH"), Tipo("colI"), Tipo("colJ"), Tipo("colK"), Tipo("colL"), Tipo("colM"), Tipo("colN"), Tipo("colO"), Tipo("colP"), Tipo("colQ"), Tipo("colR"), Tipo("colS"), Tipo("colT") };
            WebControl[][] diagonalPositiva = { Tipo("diagPos1"), Tipo("diagPos2"), Tipo("diagPos3"), Tipo("diagPos4"), Tipo("diagPos5"), Tipo("diagPos6"), Tipo("diagPos7"), Tipo("diagPos8"), Tipo("diagPos9"), Tipo("diagPos10"), Tipo("diagPos11"), Tipo("diagPos12"), Tipo("diagPos13"), Tipo("diagPos14"), Tipo("diagPos15"), Tipo("diagPos16"), Tipo("diagPos17"), Tipo("diagPos18"), Tipo("diagPos19"), Tipo("diagPos20"), Tipo("diagPos21"), Tipo("diagPos22"), Tipo("diagPos23"), Tipo("diagPos24"), Tipo("diagPos25"), Tipo("diagPos26"), Tipo("diagPos27"), Tipo("diagPos28"), Tipo("diagPos29"), Tipo("diagPos30"), Tipo("diagPos31"), Tipo("diagPos32"), Tipo("diagPos33"), Tipo("diagPos34"), Tipo("diagPos35"), Tipo("diagPos36"), Tipo("diagPos37"), Tipo("diagPos38"), Tipo("diagPos39") };
            WebControl[][] diagonalNegativa = { Tipo("diagNeg1"), Tipo("diagNeg2"), Tipo("diagNeg3"), Tipo("diagNeg4"), Tipo("diagNeg5"), Tipo("diagNeg6"), Tipo("diagNeg7"), Tipo("diagNeg8"), Tipo("diagNeg9"), Tipo("diagNeg10"), Tipo("diagNeg11"), Tipo("diagNeg12"), Tipo("diagNeg13"), Tipo("diagNeg14"), Tipo("diagNeg15"), Tipo("diagNeg16"), Tipo("diagNeg17"), Tipo("diagNeg18"), Tipo("diagNeg19"), Tipo("diagNeg20"), Tipo("diagNeg21"), Tipo("diagNeg22"), Tipo("diagNeg23"), Tipo("diagNeg24"), Tipo("diagNeg25"), Tipo("diagNeg26"), Tipo("diagNeg27"), Tipo("diagNeg28"), Tipo("diagNeg29"), Tipo("diagNeg30"), Tipo("diagNeg31"), Tipo("diagNeg32"), Tipo("diagNeg33"), Tipo("diagNeg34"), Tipo("diagNeg35"), Tipo("diagNeg36"), Tipo("diagNeg37"), Tipo("diagNeg38"), Tipo("diagNeg39") };

            switch (tipo)
            {
                case "fila":
                    for (int i = 0; i < fila.Length; i++)
                    {
                        for (int j = 0; j < fila[i].Length; j++)
                        {
                            if (fila[i][j] == boton)
                            {
                                return fila[i];
                            }
                        }
                    }
                    break;

                case "columna":
                    for (int i = 0; i < columna.Length; i++)
                    {
                        for (int j = 0; j < columna[i].Length; j++)
                        {
                            if (columna[i][j] == boton)
                            {
                                return columna[i];
                            }
                        }
                    }
                    break;

                case "positiva":
                    for (int i = 0; i < diagonalPositiva.Length; i++)
                    {
                        for (int j = 0; j < diagonalPositiva[i].Length; j++)
                        {
                            if (diagonalPositiva[i][j] == boton)
                            {
                                return diagonalPositiva[i];
                            }
                        }
                    }
                    break;

                case "negativa":
                    for (int i = 0; i < diagonalNegativa.Length; i++)
                    {
                        for (int j = 0; j < diagonalNegativa[i].Length; j++)
                        {
                            if (diagonalNegativa[i][j] == boton)
                            {
                                return diagonalNegativa[i];
                            }
                        }
                    }
                    break;
            }
            return null;
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
                ComerFicha(Arreglo(a1, "fila"), color, a1);
                ComerFicha(Arreglo(a1, "columna"), color, a1);
                ComerFicha(Arreglo(a1, "positiva"), color, a1);
                ComerFicha(Arreglo(a1, "negativa"), color, a1);

                Get_Score(a1);
                Get_Move(a1, color);
            }
        }

        public void B1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b1.CssClass == vacio)
            {
                ComerFicha(Arreglo(b1, "fila"), color, b1);
                ComerFicha(Arreglo(b1, "columna"), color, b1);
                ComerFicha(Arreglo(b1, "positiva"), color, b1);
                ComerFicha(Arreglo(b1, "negativa"), color, b1);

                Get_Score(b1);
                Get_Move(b1, color);
            }
        }

        protected void C1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c1.CssClass == vacio)
            {
                ComerFicha(Arreglo(c1, "fila"), color, c1);
                ComerFicha(Arreglo(c1, "columna"), color, c1);
                ComerFicha(Arreglo(c1, "positiva"), color, c1);
                ComerFicha(Arreglo(c1, "negativa"), color, c1);

                Get_Score(c1);
                Get_Move(c1, color);

            }
        }

        protected void D1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d1.CssClass == vacio)
            {
                ComerFicha(Arreglo(d1, "fila"), color, d1);
                ComerFicha(Arreglo(d1, "columna"), color, d1);
                ComerFicha(Arreglo(d1, "positiva"), color, d1);
                ComerFicha(Arreglo(d1, "negativa"), color, d1);

                Get_Score(d1);
                Get_Move(d1, color);
            }
        }

        protected void E1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e1.CssClass == vacio)
            {
                ComerFicha(Arreglo(e1, "fila"), color, e1);
                ComerFicha(Arreglo(e1, "columna"), color, e1);
                ComerFicha(Arreglo(e1, "positiva"), color, e1);
                ComerFicha(Arreglo(e1, "negativa"), color, e1);

                Get_Score(e1);
                Get_Move(e1, color);
            }
        }

        protected void F1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f1.CssClass == vacio)
            {
                ComerFicha(Arreglo(f1, "fila"), color, f1);
                ComerFicha(Arreglo(f1, "columna"), color, f1);
                ComerFicha(Arreglo(f1, "positiva"), color, f1);
                ComerFicha(Arreglo(f1, "negativa"), color, f1);

                Get_Score(f1);
                Get_Move(f1, color);

            }
        }

        protected void G1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g1.CssClass == vacio)
            {
                ComerFicha(Arreglo(g1, "fila"), color, g1);
                ComerFicha(Arreglo(g1, "columna"), color, g1);
                ComerFicha(Arreglo(g1, "positiva"), color, g1);
                ComerFicha(Arreglo(g1, "negativa"), color, g1);

                Get_Score(g1);
                Get_Move(g1, color);
            }
        }

        protected void H1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h1.CssClass == vacio)
            {
                ComerFicha(Arreglo(h1, "fila"), color, h1);
                ComerFicha(Arreglo(h1, "columna"), color, h1);
                ComerFicha(Arreglo(h1, "positiva"), color, h1);
                ComerFicha(Arreglo(h1, "negativa"), color, h1);

                Get_Score(h1);
                Get_Move(h1, color);
            }
        }

        protected void I1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i1.CssClass == vacio)
            {
                ComerFicha(Arreglo(i1, "fila"), color, i1);
                ComerFicha(Arreglo(i1, "columna"), color, i1);
                ComerFicha(Arreglo(i1, "positiva"), color, i1);
                ComerFicha(Arreglo(i1, "negativa"), color, i1);

                Get_Score(i1);
                Get_Move(i1, color);
            }
        }

        protected void J1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j1.CssClass == vacio)
            {
                ComerFicha(Arreglo(j1, "fila"), color, j1);
                ComerFicha(Arreglo(j1, "columna"), color, j1);
                ComerFicha(Arreglo(j1, "positiva"), color, j1);
                ComerFicha(Arreglo(j1, "negativa"), color, j1);

                Get_Score(j1);
                Get_Move(j1, color);
            }
        }

        protected void K1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k1.CssClass == vacio)
            {
                ComerFicha(Arreglo(k1, "fila"), color, k1);
                ComerFicha(Arreglo(k1, "columna"), color, k1);
                ComerFicha(Arreglo(k1, "positiva"), color, k1);
                ComerFicha(Arreglo(k1, "negativa"), color, k1);

                Get_Score(k1);
                Get_Move(k1, color);
            }
        }

        protected void L1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l1.CssClass == vacio)
            {
                ComerFicha(Arreglo(l1, "fila"), color, l1);
                ComerFicha(Arreglo(l1, "columna"), color, l1);
                ComerFicha(Arreglo(l1, "positiva"), color, l1);
                ComerFicha(Arreglo(l1, "negativa"), color, l1);

                Get_Score(l1);
                Get_Move(l1, color);
            }
        }

        protected void M1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m1.CssClass == vacio)
            {
                ComerFicha(Arreglo(m1, "fila"), color, m1);
                ComerFicha(Arreglo(m1, "columna"), color, m1);
                ComerFicha(Arreglo(m1, "positiva"), color, m1);
                ComerFicha(Arreglo(m1, "negativa"), color, m1);

                Get_Score(m1);
                Get_Move(m1, color);
            }
        }

        protected void N1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n1.CssClass == vacio)
            {
                ComerFicha(Arreglo(n1, "fila"), color, n1);
                ComerFicha(Arreglo(n1, "columna"), color, n1);
                ComerFicha(Arreglo(n1, "positiva"), color, n1);
                ComerFicha(Arreglo(n1, "negativa"), color, n1);

                Get_Score(n1);
                Get_Move(n1, color);
            }
        }

        protected void O1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o1.CssClass == vacio)
            {
                ComerFicha(Arreglo(o1, "fila"), color, o1);
                ComerFicha(Arreglo(o1, "columna"), color, o1);
                ComerFicha(Arreglo(o1, "positiva"), color, o1);
                ComerFicha(Arreglo(o1, "negativa"), color, o1);

                Get_Score(o1);
                Get_Move(o1, color);
            }
        }

        protected void P1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p1.CssClass == vacio)
            {
                ComerFicha(Arreglo(p1, "fila"), color, p1);
                ComerFicha(Arreglo(p1, "columna"), color, p1);
                ComerFicha(Arreglo(p1, "positiva"), color, p1);
                ComerFicha(Arreglo(p1, "negativa"), color, p1);

                Get_Score(p1);
                Get_Move(p1, color);
            }
        }

        protected void Q1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q1.CssClass == vacio)
            {
                ComerFicha(Arreglo(q1, "fila"), color, q1);
                ComerFicha(Arreglo(q1, "columna"), color, q1);
                ComerFicha(Arreglo(q1, "positiva"), color, q1);
                ComerFicha(Arreglo(q1, "negativa"), color, q1);

                Get_Score(q1);
                Get_Move(q1, color);
            }
        }

        protected void R1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r1.CssClass == vacio)
            {
                ComerFicha(Arreglo(r1, "fila"), color, r1);
                ComerFicha(Arreglo(r1, "columna"), color, r1);
                ComerFicha(Arreglo(r1, "positiva"), color, r1);
                ComerFicha(Arreglo(r1, "negativa"), color, r1);

                Get_Score(r1);
                Get_Move(r1, color);
            }
        }

        protected void S1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s1.CssClass == vacio)
            {
                ComerFicha(Arreglo(s1, "fila"), color, s1);
                ComerFicha(Arreglo(s1, "columna"), color, s1);
                ComerFicha(Arreglo(s1, "positiva"), color, s1);
                ComerFicha(Arreglo(s1, "negativa"), color, s1);

                Get_Score(s1);
                Get_Move(s1, color);
            }
        }

        protected void T1_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t1.CssClass == vacio)
            {
                ComerFicha(Arreglo(t1, "fila"), color, t1);
                ComerFicha(Arreglo(t1, "columna"), color, t1);
                ComerFicha(Arreglo(t1, "positiva"), color, t1);
                ComerFicha(Arreglo(t1, "negativa"), color, t1);

                Get_Score(t1);
                Get_Move(t1, color);
            }
        }

        protected void A2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a2.CssClass == vacio)
            {
                ComerFicha(Arreglo(a2, "fila"), color, a2);
                ComerFicha(Arreglo(a2, "columna"), color, a2);
                ComerFicha(Arreglo(a2, "positiva"), color, a2);
                ComerFicha(Arreglo(a2, "negativa"), color, a2);

                Get_Score(a2);
                Get_Move(a2, color);

            }
        }

        protected void B2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b2.CssClass == vacio)
            {
                ComerFicha(Arreglo(b2, "fila"), color, b2);
                ComerFicha(Arreglo(b2, "columna"), color, b2);
                ComerFicha(Arreglo(b2, "positiva"), color, b2);
                ComerFicha(Arreglo(b2, "negativa"), color, b2);

                Get_Score(b2);
                Get_Move(b2, color);
            }
        }

        protected void C2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c2.CssClass == vacio)
            {
                ComerFicha(Arreglo(c2, "fila"), color, c2);
                ComerFicha(Arreglo(c2, "columna"), color, c2);
                ComerFicha(Arreglo(c2, "positiva"), color, c2);
                ComerFicha(Arreglo(c2, "negativa"), color, c2);

                Get_Score(c2);
                Get_Move(c2, color);
            }
        }

        protected void D2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d2.CssClass == vacio)
            {
                ComerFicha(Arreglo(d2, "fila"), color, d2);
                ComerFicha(Arreglo(d2, "columna"), color, d2);
                ComerFicha(Arreglo(d2, "positiva"), color, d2);
                ComerFicha(Arreglo(d2, "negativa"), color, d2);

                Get_Score(d2);
                Get_Move(d2, color);
            }
        }

        protected void E2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e2.CssClass == vacio)
            {
                ComerFicha(Arreglo(e2, "fila"), color, e2);
                ComerFicha(Arreglo(e2, "columna"), color, e2);
                ComerFicha(Arreglo(e2, "positiva"), color, e2);
                ComerFicha(Arreglo(e2, "negativa"), color, e2);

                Get_Score(e2);
                Get_Move(e2, color);
            }
        }

        protected void F2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f2.CssClass == vacio)
            {
                ComerFicha(Arreglo(f2, "fila"), color, f2);
                ComerFicha(Arreglo(f2, "columna"), color, f2);
                ComerFicha(Arreglo(f2, "positiva"), color, f2);
                ComerFicha(Arreglo(f2, "negativa"), color, f2);

                Get_Score(f2);
                Get_Move(f2, color);
            }
        }

        protected void G2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g2.CssClass == vacio)
            {
                ComerFicha(Arreglo(g2, "fila"), color, g2);
                ComerFicha(Arreglo(g2, "columna"), color, g2);
                ComerFicha(Arreglo(g2, "positiva"), color, g2);
                ComerFicha(Arreglo(g2, "negativa"), color, g2);

                Get_Score(g2);
                Get_Move(g2, color);
            }
        }

        protected void H2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h2.CssClass == vacio)
            {
                ComerFicha(Arreglo(h2, "fila"), color, h2);
                ComerFicha(Arreglo(h2, "columna"), color, h2);
                ComerFicha(Arreglo(h2, "positiva"), color, h2);
                ComerFicha(Arreglo(h2, "negativa"), color, h2);

                Get_Score(h2);
                Get_Move(h2, color);
            }
        }

        protected void I2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i2.CssClass == vacio)
            {
                ComerFicha(Arreglo(i2, "fila"), color, i2);
                ComerFicha(Arreglo(i2, "columna"), color, i2);
                ComerFicha(Arreglo(i2, "positiva"), color, i2);
                ComerFicha(Arreglo(i2, "negativa"), color, i2);

                Get_Score(i2);
                Get_Move(i2, color);
            }
        }

        protected void J2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j2.CssClass == vacio)
            {
                ComerFicha(Arreglo(j2, "fila"), color, j2);
                ComerFicha(Arreglo(j2, "columna"), color, j2);
                ComerFicha(Arreglo(j2, "positiva"), color, j2);
                ComerFicha(Arreglo(j2, "negativa"), color, j2);

                Get_Score(j2);
                Get_Move(j2, color);
            }
        }

        protected void K2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k2.CssClass == vacio)
            {
                ComerFicha(Arreglo(k2, "fila"), color, k2);
                ComerFicha(Arreglo(k2, "columna"), color, k2);
                ComerFicha(Arreglo(k2, "positiva"), color, k2);
                ComerFicha(Arreglo(k2, "negativa"), color, k2);

                Get_Score(k2);
                Get_Move(k2, color);
            }
        }

        protected void L2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l2.CssClass == vacio)
            {
                ComerFicha(Arreglo(l2, "fila"), color, l2);
                ComerFicha(Arreglo(l2, "columna"), color, l2);
                ComerFicha(Arreglo(l2, "positiva"), color, l2);
                ComerFicha(Arreglo(l2, "negativa"), color, l2);

                Get_Score(l2);
                Get_Move(l2, color);
            }
        }

        protected void M2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m2.CssClass == vacio)
            {
                ComerFicha(Arreglo(m2, "fila"), color, m2);
                ComerFicha(Arreglo(m2, "columna"), color, m2);
                ComerFicha(Arreglo(m2, "positiva"), color, m2);
                ComerFicha(Arreglo(m2, "negativa"), color, m2);

                Get_Score(m2);
                Get_Move(m2, color);
            }
        }

        protected void N2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n2.CssClass == vacio)
            {
                ComerFicha(Arreglo(n2, "fila"), color, n2);
                ComerFicha(Arreglo(n2, "columna"), color, n2);
                ComerFicha(Arreglo(n2, "positiva"), color, n2);
                ComerFicha(Arreglo(n2, "negativa"), color, n2);

                Get_Score(n2);
                Get_Move(n2, color);
            }
        }

        protected void O2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o2.CssClass == vacio)
            {
                ComerFicha(Arreglo(o2, "fila"), color, o2);
                ComerFicha(Arreglo(o2, "columna"), color, o2);
                ComerFicha(Arreglo(o2, "positiva"), color, o2);
                ComerFicha(Arreglo(o2, "negativa"), color, o2);

                Get_Score(o2);
                Get_Move(o2, color);
            }
        }

        protected void P2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p2.CssClass == vacio)
            {
                ComerFicha(Arreglo(p2, "fila"), color, p2);
                ComerFicha(Arreglo(p2, "columna"), color, p2);
                ComerFicha(Arreglo(p2, "positiva"), color, p2);
                ComerFicha(Arreglo(p2, "negativa"), color, p2);

                Get_Score(p2);
                Get_Move(p2, color);
            }
        }

        protected void Q2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q2.CssClass == vacio)
            {
                ComerFicha(Arreglo(q2, "fila"), color, q2);
                ComerFicha(Arreglo(q2, "columna"), color, q2);
                ComerFicha(Arreglo(q2, "positiva"), color, q2);
                ComerFicha(Arreglo(q2, "negativa"), color, q2);

                Get_Score(q2);
                Get_Move(q2, color);
            }
        }

        protected void R2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r2.CssClass == vacio)
            {
                ComerFicha(Arreglo(r2, "fila"), color, r2);
                ComerFicha(Arreglo(r2, "columna"), color, r2);
                ComerFicha(Arreglo(r2, "positiva"), color, r2);
                ComerFicha(Arreglo(r2, "negativa"), color, r2);

                Get_Score(r2);
                Get_Move(r2, color);
            }
        }

        protected void S2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s2.CssClass == vacio)
            {
                ComerFicha(Arreglo(s2, "fila"), color, s2);
                ComerFicha(Arreglo(s2, "columna"), color, s2);
                ComerFicha(Arreglo(s2, "positiva"), color, s2);
                ComerFicha(Arreglo(s2, "negativa"), color, s2);

                Get_Score(s2);
                Get_Move(s2, color);
            }
        }

        protected void T2_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t2.CssClass == vacio)
            {
                ComerFicha(Arreglo(t2, "fila"), color, t2);
                ComerFicha(Arreglo(t2, "columna"), color, t2);
                ComerFicha(Arreglo(t2, "positiva"), color, t2);
                ComerFicha(Arreglo(t2, "negativa"), color, t2);

                Get_Score(t2);
                Get_Move(t2, color);
            }
        }

        protected void A3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a3.CssClass == vacio)
            {
                ComerFicha(Arreglo(a3, "fila"), color, a3);
                ComerFicha(Arreglo(a3, "columna"), color, a3);
                ComerFicha(Arreglo(a3, "positiva"), color, a3);
                ComerFicha(Arreglo(a3, "negativa"), color, a3);

                Get_Score(a3);
                Get_Move(a3, color);
            }
        }

        protected void B3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b3.CssClass == vacio)
            {
                ComerFicha(Arreglo(b3, "fila"), color, b3);
                ComerFicha(Arreglo(b3, "columna"), color, b3);
                ComerFicha(Arreglo(b3, "positiva"), color, b3);
                ComerFicha(Arreglo(b3, "negativa"), color, b3);

                Get_Score(b3);
                Get_Move(b3, color);
            }
        }

        protected void C3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c3.CssClass == vacio)
            {
                ComerFicha(Arreglo(c3, "fila"), color, c3);
                ComerFicha(Arreglo(c3, "columna"), color, c3);
                ComerFicha(Arreglo(c3, "positiva"), color, c3);
                ComerFicha(Arreglo(c3, "negativa"), color, c3);

                Get_Score(c3);
                Get_Move(c3, color);
            }
        }

        protected void D3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d3.CssClass == vacio)
            {
                ComerFicha(Arreglo(d3, "fila"), color, d3);
                ComerFicha(Arreglo(d3, "columna"), color, d3);
                ComerFicha(Arreglo(d3, "positiva"), color, d3);
                ComerFicha(Arreglo(d3, "negativa"), color, d3);

                Get_Score(d3);
                Get_Move(d3, color);
            }
        }

        protected void E3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e3.CssClass == vacio)
            {
                ComerFicha(Arreglo(e3, "fila"), color, e3);
                ComerFicha(Arreglo(e3, "columna"), color, e3);
                ComerFicha(Arreglo(e3, "positiva"), color, e3);
                ComerFicha(Arreglo(e3, "negativa"), color, e3);

                Get_Score(e3);
                Get_Move(e3, color);
            }
        }

        protected void F3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f3.CssClass == vacio)
            {
                ComerFicha(Arreglo(f3, "fila"), color, f3);
                ComerFicha(Arreglo(f3, "columna"), color, f3);
                ComerFicha(Arreglo(f3, "positiva"), color, f3);
                ComerFicha(Arreglo(f3, "negativa"), color, f3);

                Get_Score(f3);
                Get_Move(f3, color);
            }
        }

        protected void G3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g3.CssClass == vacio)
            {
                ComerFicha(Arreglo(g3, "fila"), color, g3);
                ComerFicha(Arreglo(g3, "columna"), color, g3);
                ComerFicha(Arreglo(g3, "positiva"), color, g3);
                ComerFicha(Arreglo(g3, "negativa"), color, g3);

                Get_Score(g3);
                Get_Move(g3, color);
            }
        }

        protected void H3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h3.CssClass == vacio)
            {
                ComerFicha(Arreglo(h3, "fila"), color, h3);
                ComerFicha(Arreglo(h3, "columna"), color, h3);
                ComerFicha(Arreglo(h3, "positiva"), color, h3);
                ComerFicha(Arreglo(h3, "negativa"), color, h3);

                Get_Score(h3);
                Get_Move(h3, color);
            }
        }

        protected void I3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i3.CssClass == vacio)
            {
                ComerFicha(Arreglo(i3, "fila"), color, i3);
                ComerFicha(Arreglo(i3, "columna"), color, i3);
                ComerFicha(Arreglo(i3, "positiva"), color, i3);
                ComerFicha(Arreglo(i3, "negativa"), color, i3);

                Get_Score(i3);
                Get_Move(i3, color);
            }
        }

        protected void J3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j3.CssClass == vacio)
            {
                ComerFicha(Arreglo(j3, "fila"), color, j3);
                ComerFicha(Arreglo(j3, "columna"), color, j3);
                ComerFicha(Arreglo(j3, "positiva"), color, j3);
                ComerFicha(Arreglo(j3, "negativa"), color, j3);

                Get_Score(j3);
                Get_Move(j3, color);
            }
        }

        protected void K3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k3.CssClass == vacio)
            {
                ComerFicha(Arreglo(k3, "fila"), color, k3);
                ComerFicha(Arreglo(k3, "columna"), color, k3);
                ComerFicha(Arreglo(k3, "positiva"), color, k3);
                ComerFicha(Arreglo(k3, "negativa"), color, k3);

                Get_Score(k3);
                Get_Move(k3, color);
            }
        }

        protected void L3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l3.CssClass == vacio)
            {
                ComerFicha(Arreglo(l3, "fila"), color, l3);
                ComerFicha(Arreglo(l3, "columna"), color, l3);
                ComerFicha(Arreglo(l3, "positiva"), color, l3);
                ComerFicha(Arreglo(l3, "negativa"), color, l3);

                Get_Score(l3);
                Get_Move(l3, color);
            }
        }

        protected void M3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m3.CssClass == vacio)
            {
                ComerFicha(Arreglo(m3, "fila"), color, m3);
                ComerFicha(Arreglo(m3, "columna"), color, m3);
                ComerFicha(Arreglo(m3, "positiva"), color, m3);
                ComerFicha(Arreglo(m3, "negativa"), color, m3);

                Get_Score(m3);
                Get_Move(m3, color);
            }
        }

        protected void N3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n3.CssClass == vacio)
            {
                ComerFicha(Arreglo(n3, "fila"), color, n3);
                ComerFicha(Arreglo(n3, "columna"), color, n3);
                ComerFicha(Arreglo(n3, "positiva"), color, n3);
                ComerFicha(Arreglo(n3, "negativa"), color, n3);

                Get_Score(n3);
                Get_Move(n3, color);
            }
        }

        protected void O3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o3.CssClass == vacio)
            {
                ComerFicha(Arreglo(o3, "fila"), color, o3);
                ComerFicha(Arreglo(o3, "columna"), color, o3);
                ComerFicha(Arreglo(o3, "positiva"), color, o3);
                ComerFicha(Arreglo(o3, "negativa"), color, o3);

                Get_Score(o3);
                Get_Move(o3, color);
            }
        }

        protected void P3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p3.CssClass == vacio)
            {
                ComerFicha(Arreglo(p3, "fila"), color, p3);
                ComerFicha(Arreglo(p3, "columna"), color, p3);
                ComerFicha(Arreglo(p3, "positiva"), color, p3);
                ComerFicha(Arreglo(p3, "negativa"), color, p3);

                Get_Score(p3);
                Get_Move(p3, color);
            }
        }

        protected void Q3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q3.CssClass == vacio)
            {
                ComerFicha(Arreglo(q3, "fila"), color, q3);
                ComerFicha(Arreglo(q3, "columna"), color, q3);
                ComerFicha(Arreglo(q3, "positiva"), color, q3);
                ComerFicha(Arreglo(q3, "negativa"), color, q3);

                Get_Score(q3);
                Get_Move(q3, color);
            }
        }

        protected void R3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r3.CssClass == vacio)
            {
                ComerFicha(Arreglo(r3, "fila"), color, r3);
                ComerFicha(Arreglo(r3, "columna"), color, r3);
                ComerFicha(Arreglo(r3, "positiva"), color, r3);
                ComerFicha(Arreglo(r3, "negativa"), color, r3);

                Get_Score(r3);
                Get_Move(r3, color);
            }
        }

        protected void S3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s3.CssClass == vacio)
            {
                ComerFicha(Arreglo(s3, "fila"), color, s3);
                ComerFicha(Arreglo(s3, "columna"), color, s3);
                ComerFicha(Arreglo(s3, "positiva"), color, s3);
                ComerFicha(Arreglo(s3, "negativa"), color, s3);

                Get_Score(s3);
                Get_Move(s3, color);
            }
        }

        protected void T3_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t3.CssClass == vacio)
            {
                ComerFicha(Arreglo(t3, "fila"), color, t3);
                ComerFicha(Arreglo(t3, "columna"), color, t3);
                ComerFicha(Arreglo(t3, "positiva"), color, t3);
                ComerFicha(Arreglo(t3, "negativa"), color, t3);

                Get_Score(t3);
                Get_Move(t3, color);
            }
        }

        protected void A4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a4.CssClass == vacio)
            {
                ComerFicha(Arreglo(a4, "fila"), color, a4);
                ComerFicha(Arreglo(a4, "columna"), color, a4);
                ComerFicha(Arreglo(a4, "positiva"), color, a4);
                ComerFicha(Arreglo(a4, "negativa"), color, a4);

                Get_Score(a4);
                Get_Move(a4, color);
            }
        }

        protected void B4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b4.CssClass == vacio)
            {
                ComerFicha(Arreglo(b4, "fila"), color, b4);
                ComerFicha(Arreglo(b4, "columna"), color, b4);
                ComerFicha(Arreglo(b4, "positiva"), color, b4);
                ComerFicha(Arreglo(b4, "negativa"), color, b4);

                Get_Score(b4);
                Get_Move(b4, color);
            }
        }

        protected void C4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c4.CssClass == vacio)
            {
                ComerFicha(Arreglo(c4, "fila"), color, c4);
                ComerFicha(Arreglo(c4, "columna"), color, c4);
                ComerFicha(Arreglo(c4, "positiva"), color, c4);
                ComerFicha(Arreglo(c4, "negativa"), color, c4);

                Get_Score(c4);
                Get_Move(c4, color);
            }
        }

        protected void D4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d4.CssClass == vacio)
            {
                ComerFicha(Arreglo(d4, "fila"), color, d4);
                ComerFicha(Arreglo(d4, "columna"), color, d4);
                ComerFicha(Arreglo(d4, "positiva"), color, d4);
                ComerFicha(Arreglo(d4, "negativa"), color, d4);

                Get_Score(d4);
                Get_Move(d4, color);
            }
        }

        protected void E4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e4.CssClass == vacio)
            {
                ComerFicha(Arreglo(e4, "fila"), color, e4);
                ComerFicha(Arreglo(e4, "columna"), color, e4);
                ComerFicha(Arreglo(e4, "positiva"), color, e4);
                ComerFicha(Arreglo(e4, "negativa"), color, e4);

                Get_Score(e4);
                Get_Move(e4, color);
            }
        }

        protected void F4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f4.CssClass == vacio)
            {
                ComerFicha(Arreglo(f4, "fila"), color, f4);
                ComerFicha(Arreglo(f4, "columna"), color, f4);
                ComerFicha(Arreglo(f4, "positiva"), color, f4);
                ComerFicha(Arreglo(f4, "negativa"), color, f4);

                Get_Score(f4);
                Get_Move(f4, color);
            }
        }

        protected void G4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g4.CssClass == vacio)
            {
                ComerFicha(Arreglo(g4, "fila"), color, g4);
                ComerFicha(Arreglo(g4, "columna"), color, g4);
                ComerFicha(Arreglo(g4, "positiva"), color, g4);
                ComerFicha(Arreglo(g4, "negativa"), color, g4);

                Get_Score(g4);
                Get_Move(g4, color);
            }
        }

        protected void H4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h4.CssClass == vacio)
            {
                ComerFicha(Arreglo(h4, "fila"), color, h4);
                ComerFicha(Arreglo(h4, "columna"), color, h4);
                ComerFicha(Arreglo(h4, "positiva"), color, h4);
                ComerFicha(Arreglo(h4, "negativa"), color, h4);

                Get_Score(h4);
                Get_Move(h4, color);
            }
        }

        protected void I4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i4.CssClass == vacio)
            {
                ComerFicha(Arreglo(i4, "fila"), color, i4);
                ComerFicha(Arreglo(i4, "columna"), color, i4);
                ComerFicha(Arreglo(i4, "positiva"), color, i4);
                ComerFicha(Arreglo(i4, "negativa"), color, i4);

                Get_Score(i4);
                Get_Move(i4, color);
            }
        }

        protected void J4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j4.CssClass == vacio)
            {
                ComerFicha(Arreglo(j4, "fila"), color, j4);
                ComerFicha(Arreglo(j4, "columna"), color, j4);
                ComerFicha(Arreglo(j4, "positiva"), color, j4);
                ComerFicha(Arreglo(j4, "negativa"), color, j4);

                Get_Score(j4);
                Get_Move(j4, color);
            }
        }

        protected void K4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k4.CssClass == vacio)
            {
                ComerFicha(Arreglo(k4, "fila"), color, k4);
                ComerFicha(Arreglo(k4, "columna"), color, k4);
                ComerFicha(Arreglo(k4, "positiva"), color, k4);
                ComerFicha(Arreglo(k4, "negativa"), color, k4);

                Get_Score(k4);
                Get_Move(k4, color);
            }
        }

        protected void L4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l4.CssClass == vacio)
            {
                ComerFicha(Arreglo(l4, "fila"), color, l4);
                ComerFicha(Arreglo(l4, "columna"), color, l4);
                ComerFicha(Arreglo(l4, "positiva"), color, l4);
                ComerFicha(Arreglo(l4, "negativa"), color, l4);

                Get_Score(l4);
                Get_Move(l4, color);
            }
        }

        protected void M4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m4.CssClass == vacio)
            {
                ComerFicha(Arreglo(m4, "fila"), color, m4);
                ComerFicha(Arreglo(m4, "columna"), color, m4);
                ComerFicha(Arreglo(m4, "positiva"), color, m4);
                ComerFicha(Arreglo(m4, "negativa"), color, m4);

                Get_Score(m4);
                Get_Move(m4, color);
            }
        }

        protected void N4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n4.CssClass == vacio)
            {
                ComerFicha(Arreglo(n4, "fila"), color, n4);
                ComerFicha(Arreglo(n4, "columna"), color, n4);
                ComerFicha(Arreglo(n4, "positiva"), color, n4);
                ComerFicha(Arreglo(n4, "negativa"), color, n4);

                Get_Score(n4);
                Get_Move(n4, color);
            }
        }

        protected void O4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o4.CssClass == vacio)
            {
                ComerFicha(Arreglo(o4, "fila"), color, o4);
                ComerFicha(Arreglo(o4, "columna"), color, o4);
                ComerFicha(Arreglo(o4, "positiva"), color, o4);
                ComerFicha(Arreglo(o4, "negativa"), color, o4);

                Get_Score(o4);
                Get_Move(o4, color);
            }
        }

        protected void P4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p4.CssClass == vacio)
            {
                ComerFicha(Arreglo(p4, "fila"), color, p4);
                ComerFicha(Arreglo(p4, "columna"), color, p4);
                ComerFicha(Arreglo(p4, "positiva"), color, p4);
                ComerFicha(Arreglo(p4, "negativa"), color, p4);

                Get_Score(p4);
                Get_Move(p4, color);
            }
        }

        protected void Q4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q4.CssClass == vacio)
            {
                ComerFicha(Arreglo(q4, "fila"), color, q4);
                ComerFicha(Arreglo(q4, "columna"), color, q4);
                ComerFicha(Arreglo(q4, "positiva"), color, q4);
                ComerFicha(Arreglo(q4, "negativa"), color, q4);

                Get_Score(q4);
                Get_Move(q4, color);
            }
        }

        protected void R4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r4.CssClass == vacio)
            {
                ComerFicha(Arreglo(r4, "fila"), color, r4);
                ComerFicha(Arreglo(r4, "columna"), color, r4);
                ComerFicha(Arreglo(r4, "positiva"), color, r4);
                ComerFicha(Arreglo(r4, "negativa"), color, r4);

                Get_Score(r4);
                Get_Move(r4, color);
            }
        }

        protected void S4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s4.CssClass == vacio)
            {
                ComerFicha(Arreglo(s4, "fila"), color, s4);
                ComerFicha(Arreglo(s4, "columna"), color, s4);
                ComerFicha(Arreglo(s4, "positiva"), color, s4);
                ComerFicha(Arreglo(s4, "negativa"), color, s4);

                Get_Score(s4);
                Get_Move(s4, color);
            }
        }

        protected void T4_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t4.CssClass == vacio)
            {
                ComerFicha(Arreglo(t4, "fila"), color, t4);
                ComerFicha(Arreglo(t4, "columna"), color, t4);
                ComerFicha(Arreglo(t4, "positiva"), color, t4);
                ComerFicha(Arreglo(t4, "negativa"), color, t4);

                Get_Score(t4);
                Get_Move(t4, color);
            }
        }

        protected void A5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a5.CssClass == vacio)
            {
                ComerFicha(Arreglo(a5, "fila"), color, a5);
                ComerFicha(Arreglo(a5, "columna"), color, a5);
                ComerFicha(Arreglo(a5, "positiva"), color, a5);
                ComerFicha(Arreglo(a5, "negativa"), color, a5);

                Get_Score(a5);
                Get_Move(a5, color);
            }
        }

        protected void B5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b5.CssClass == vacio)
            {
                ComerFicha(Arreglo(b5, "fila"), color, b5);
                ComerFicha(Arreglo(b5, "columna"), color, b5);
                ComerFicha(Arreglo(b5, "positiva"), color, b5);
                ComerFicha(Arreglo(b5, "negativa"), color, b5);

                Get_Score(b5);
                Get_Move(b5, color);
            }
        }

        protected void C5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c5.CssClass == vacio)
            {
                ComerFicha(Arreglo(c5, "fila"), color, c5);
                ComerFicha(Arreglo(c5, "columna"), color, c5);
                ComerFicha(Arreglo(c5, "positiva"), color, c5);
                ComerFicha(Arreglo(c5, "negativa"), color, c5);

                Get_Score(c5);
                Get_Move(c5, color);
            }
        }

        protected void D5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d5.CssClass == vacio)
            {
                ComerFicha(Arreglo(d5, "fila"), color, d5);
                ComerFicha(Arreglo(d5, "columna"), color, d5);
                ComerFicha(Arreglo(d5, "positiva"), color, d5);
                ComerFicha(Arreglo(d5, "negativa"), color, d5);

                Get_Score(d5);
                Get_Move(d5, color);
            }
        }

        protected void E5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e5.CssClass == vacio)
            {
                ComerFicha(Arreglo(e5, "fila"), color, e5);
                ComerFicha(Arreglo(e5, "columna"), color, e5);
                ComerFicha(Arreglo(e5, "positiva"), color, e5);
                ComerFicha(Arreglo(e5, "negativa"), color, e5);

                Get_Score(e5);
                Get_Move(e5, color);
            }
        }

        protected void F5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f5.CssClass == vacio)
            {
                ComerFicha(Arreglo(f5, "fila"), color, f5);
                ComerFicha(Arreglo(f5, "columna"), color, f5);
                ComerFicha(Arreglo(f5, "positiva"), color, f5);
                ComerFicha(Arreglo(f5, "negativa"), color, f5);

                Get_Score(f5);
                Get_Move(f5, color);
            }
        }

        protected void G5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g5.CssClass == vacio)
            {
                ComerFicha(Arreglo(g5, "fila"), color, g5);
                ComerFicha(Arreglo(g5, "columna"), color, g5);
                ComerFicha(Arreglo(g5, "positiva"), color, g5);
                ComerFicha(Arreglo(g5, "negativa"), color, g5);

                Get_Score(g5);
                Get_Move(g5, color);
            }
        }

        protected void H5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h5.CssClass == vacio)
            {
                ComerFicha(Arreglo(h5, "fila"), color, h5);
                ComerFicha(Arreglo(h5, "columna"), color, h5);
                ComerFicha(Arreglo(h5, "positiva"), color, h5);
                ComerFicha(Arreglo(h5, "negativa"), color, h5);

                Get_Score(h5);
                Get_Move(h5, color);
            }
        }

        protected void I5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i5.CssClass == vacio)
            {
                ComerFicha(Arreglo(i5, "fila"), color, i5);
                ComerFicha(Arreglo(i5, "columna"), color, i5);
                ComerFicha(Arreglo(i5, "positiva"), color, i5);
                ComerFicha(Arreglo(i5, "negativa"), color, i5);

                Get_Score(i5);
                Get_Move(i5, color);
            }
        }

        protected void J5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j5.CssClass == vacio)
            {
                ComerFicha(Arreglo(j5, "fila"), color, j5);
                ComerFicha(Arreglo(j5, "columna"), color, j5);
                ComerFicha(Arreglo(j5, "positiva"), color, j5);
                ComerFicha(Arreglo(j5, "negativa"), color, j5);

                Get_Score(j5);
                Get_Move(j5, color);
            }
        }

        protected void K5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k5.CssClass == vacio)
            {
                ComerFicha(Arreglo(k5, "fila"), color, k5);
                ComerFicha(Arreglo(k5, "columna"), color, k5);
                ComerFicha(Arreglo(k5, "positiva"), color, k5);
                ComerFicha(Arreglo(k5, "negativa"), color, k5);

                Get_Score(k5);
                Get_Move(k5, color);
            }
        }

        protected void L5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l5.CssClass == vacio)
            {
                ComerFicha(Arreglo(l5, "fila"), color, l5);
                ComerFicha(Arreglo(l5, "columna"), color, l5);
                ComerFicha(Arreglo(l5, "positiva"), color, l5);
                ComerFicha(Arreglo(l5, "negativa"), color, l5);

                Get_Score(l5);
                Get_Move(l5, color);
            }
        }

        protected void M5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m5.CssClass == vacio)
            {
                ComerFicha(Arreglo(m5, "fila"), color, m5);
                ComerFicha(Arreglo(m5, "columna"), color, m5);
                ComerFicha(Arreglo(m5, "positiva"), color, m5);
                ComerFicha(Arreglo(m5, "negativa"), color, m5);

                Get_Score(m5);
                Get_Move(m5, color);
            }
        }

        protected void N5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n5.CssClass == vacio)
            {
                ComerFicha(Arreglo(n5, "fila"), color, n5);
                ComerFicha(Arreglo(n5, "columna"), color, n5);
                ComerFicha(Arreglo(n5, "positiva"), color, n5);
                ComerFicha(Arreglo(n5, "negativa"), color, n5);

                Get_Score(n5);
                Get_Move(n5, color);
            }
        }

        protected void O5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o5.CssClass == vacio)
            {
                ComerFicha(Arreglo(o5, "fila"), color, o5);
                ComerFicha(Arreglo(o5, "columna"), color, o5);
                ComerFicha(Arreglo(o5, "positiva"), color, o5);
                ComerFicha(Arreglo(o5, "negativa"), color, o5);

                Get_Score(o5);
                Get_Move(o5, color);
            }
        }

        protected void P5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p5.CssClass == vacio)
            {
                ComerFicha(Arreglo(p5, "fila"), color, p5);
                ComerFicha(Arreglo(p5, "columna"), color, p5);
                ComerFicha(Arreglo(p5, "positiva"), color, p5);
                ComerFicha(Arreglo(p5, "negativa"), color, p5);

                Get_Score(p5);
                Get_Move(p5, color);
            }
        }

        protected void Q5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q5.CssClass == vacio)
            {
                ComerFicha(Arreglo(q5, "fila"), color, q5);
                ComerFicha(Arreglo(q5, "columna"), color, q5);
                ComerFicha(Arreglo(q5, "positiva"), color, q5);
                ComerFicha(Arreglo(q5, "negativa"), color, q5);

                Get_Score(q5);
                Get_Move(q5, color);
            }
        }

        protected void R5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r5.CssClass == vacio)
            {
                ComerFicha(Arreglo(r5, "fila"), color, r5);
                ComerFicha(Arreglo(r5, "columna"), color, r5);
                ComerFicha(Arreglo(r5, "positiva"), color, r5);
                ComerFicha(Arreglo(r5, "negativa"), color, r5);

                Get_Score(r5);
                Get_Move(r5, color);
            }
        }

        protected void S5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s5.CssClass == vacio)
            {
                ComerFicha(Arreglo(s5, "fila"), color, s5);
                ComerFicha(Arreglo(s5, "columna"), color, s5);
                ComerFicha(Arreglo(s5, "positiva"), color, s5);
                ComerFicha(Arreglo(s5, "negativa"), color, s5);

                Get_Score(s5);
                Get_Move(s5, color);
            }
        }

        protected void T5_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t5.CssClass == vacio)
            {
                ComerFicha(Arreglo(t5, "fila"), color, t5);
                ComerFicha(Arreglo(t5, "columna"), color, t5);
                ComerFicha(Arreglo(t5, "positiva"), color, t5);
                ComerFicha(Arreglo(t5, "negativa"), color, t5);

                Get_Score(t5);
                Get_Move(t5, color);
            }
        }

        protected void A6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a6.CssClass == vacio)
            {
                ComerFicha(Arreglo(a6, "fila"), color, a6);
                ComerFicha(Arreglo(a6, "columna"), color, a6);
                ComerFicha(Arreglo(a6, "positiva"), color, a6);
                ComerFicha(Arreglo(a6, "negativa"), color, a6);

                Get_Score(a6);
                Get_Move(a6, color);
            }
        }

        protected void B6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b6.CssClass == vacio)
            {
                ComerFicha(Arreglo(b6, "fila"), color, b6);
                ComerFicha(Arreglo(b6, "columna"), color, b6);
                ComerFicha(Arreglo(b6, "positiva"), color, b6);
                ComerFicha(Arreglo(b6, "negativa"), color, b6);

                Get_Score(b6);
                Get_Move(b6, color);
            }
        }

        protected void C6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c6.CssClass == vacio)
            {
                ComerFicha(Arreglo(c6, "fila"), color, c6);
                ComerFicha(Arreglo(c6, "columna"), color, c6);
                ComerFicha(Arreglo(c6, "positiva"), color, c6);
                ComerFicha(Arreglo(c6, "negativa"), color, c6);

                Get_Score(c6);
                Get_Move(c6, color);
            }
        }

        protected void D6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d6.CssClass == vacio)
            {
                ComerFicha(Arreglo(d6, "fila"), color, d6);
                ComerFicha(Arreglo(d6, "columna"), color, d6);
                ComerFicha(Arreglo(d6, "positiva"), color, d6);
                ComerFicha(Arreglo(d6, "negativa"), color, d6);

                Get_Score(d6);
                Get_Move(d6, color);
            }
        }

        protected void E6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e6.CssClass == vacio)
            {
                ComerFicha(Arreglo(e6, "fila"), color, e6);
                ComerFicha(Arreglo(e6, "columna"), color, e6);
                ComerFicha(Arreglo(e6, "positiva"), color, e6);
                ComerFicha(Arreglo(e6, "negativa"), color, e6);

                Get_Score(e6);
                Get_Move(e6, color);
            }
        }

        protected void F6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f6.CssClass == vacio)
            {
                ComerFicha(Arreglo(f6, "fila"), color, f6);
                ComerFicha(Arreglo(f6, "columna"), color, f6);
                ComerFicha(Arreglo(f6, "positiva"), color, f6);
                ComerFicha(Arreglo(f6, "negativa"), color, f6);

                Get_Score(f6);
                Get_Move(f6, color);
            }
        }

        protected void G6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g6.CssClass == vacio)
            {
                ComerFicha(Arreglo(g6, "fila"), color, g6);
                ComerFicha(Arreglo(g6, "columna"), color, g6);
                ComerFicha(Arreglo(g6, "positiva"), color, g6);
                ComerFicha(Arreglo(g6, "negativa"), color, g6);

                Get_Score(g6);
                Get_Move(g6, color);
            }
        }

        protected void H6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h6.CssClass == vacio)
            {
                ComerFicha(Arreglo(h6, "fila"), color, h6);
                ComerFicha(Arreglo(h6, "columna"), color, h6);
                ComerFicha(Arreglo(h6, "positiva"), color, h6);
                ComerFicha(Arreglo(h6, "negativa"), color, h6);

                Get_Score(h6);
                Get_Move(h6, color);
            }
        }

        protected void I6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i6.CssClass == vacio)
            {
                ComerFicha(Arreglo(i6, "fila"), color, i6);
                ComerFicha(Arreglo(i6, "columna"), color, i6);
                ComerFicha(Arreglo(i6, "positiva"), color, i6);
                ComerFicha(Arreglo(i6, "negativa"), color, i6);

                Get_Score(i6);
                Get_Move(i6, color);
            }
        }

        protected void J6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j6.CssClass == vacio)
            {
                ComerFicha(Arreglo(j6, "fila"), color, j6);
                ComerFicha(Arreglo(j6, "columna"), color, j6);
                ComerFicha(Arreglo(j6, "positiva"), color, j6);
                ComerFicha(Arreglo(j6, "negativa"), color, j6);

                Get_Score(j6);
                Get_Move(j6, color);
            }
        }

        protected void K6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k6.CssClass == vacio)
            {
                ComerFicha(Arreglo(k6, "fila"), color, k6);
                ComerFicha(Arreglo(k6, "columna"), color, k6);
                ComerFicha(Arreglo(k6, "positiva"), color, k6);
                ComerFicha(Arreglo(k6, "negativa"), color, k6);

                Get_Score(k6);
                Get_Move(k6, color);
            }
        }

        protected void L6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l6.CssClass == vacio)
            {
                ComerFicha(Arreglo(l6, "fila"), color, l6);
                ComerFicha(Arreglo(l6, "columna"), color, l6);
                ComerFicha(Arreglo(l6, "positiva"), color, l6);
                ComerFicha(Arreglo(l6, "negativa"), color, l6);

                Get_Score(l6);
                Get_Move(l6, color);
            }
        }

        protected void M6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m6.CssClass == vacio)
            {
                ComerFicha(Arreglo(m6, "fila"), color, m6);
                ComerFicha(Arreglo(m6, "columna"), color, m6);
                ComerFicha(Arreglo(m6, "positiva"), color, m6);
                ComerFicha(Arreglo(m6, "negativa"), color, m6);

                Get_Score(m6);
                Get_Move(m6, color);
            }
        }

        protected void N6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n6.CssClass == vacio)
            {
                ComerFicha(Arreglo(n6, "fila"), color, n6);
                ComerFicha(Arreglo(n6, "columna"), color, n6);
                ComerFicha(Arreglo(n6, "positiva"), color, n6);
                ComerFicha(Arreglo(n6, "negativa"), color, n6);

                Get_Score(n6);
                Get_Move(n6, color);
            }
        }

        protected void O6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o6.CssClass == vacio)
            {
                ComerFicha(Arreglo(o6, "fila"), color, o6);
                ComerFicha(Arreglo(o6, "columna"), color, o6);
                ComerFicha(Arreglo(o6, "positiva"), color, o6);
                ComerFicha(Arreglo(o6, "negativa"), color, o6);

                Get_Score(o6);
                Get_Move(o6, color);
            }
        }

        protected void P6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p6.CssClass == vacio)
            {
                ComerFicha(Arreglo(p6, "fila"), color, p6);
                ComerFicha(Arreglo(p6, "columna"), color, p6);
                ComerFicha(Arreglo(p6, "positiva"), color, p6);
                ComerFicha(Arreglo(p6, "negativa"), color, p6);

                Get_Score(p6);
                Get_Move(p6, color);
            }
        }

        protected void Q6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q6.CssClass == vacio)
            {
                ComerFicha(Arreglo(q6, "fila"), color, q6);
                ComerFicha(Arreglo(q6, "columna"), color, q6);
                ComerFicha(Arreglo(q6, "positiva"), color, q6);
                ComerFicha(Arreglo(q6, "negativa"), color, q6);

                Get_Score(q6);
                Get_Move(q6, color);
            }
        }

        protected void R6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r6.CssClass == vacio)
            {
                ComerFicha(Arreglo(r6, "fila"), color, r6);
                ComerFicha(Arreglo(r6, "columna"), color, r6);
                ComerFicha(Arreglo(r6, "positiva"), color, r6);
                ComerFicha(Arreglo(r6, "negativa"), color, r6);

                Get_Score(r6);
                Get_Move(r6, color);
            }
        }

        protected void S6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s6.CssClass == vacio)
            {
                ComerFicha(Arreglo(s6, "fila"), color, s6);
                ComerFicha(Arreglo(s6, "columna"), color, s6);
                ComerFicha(Arreglo(s6, "positiva"), color, s6);
                ComerFicha(Arreglo(s6, "negativa"), color, s6);

                Get_Score(s6);
                Get_Move(s6, color);
            }
        }

        protected void T6_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t6.CssClass == vacio)
            {
                ComerFicha(Arreglo(t6, "fila"), color, t6);
                ComerFicha(Arreglo(t6, "columna"), color, t6);
                ComerFicha(Arreglo(t6, "positiva"), color, t6);
                ComerFicha(Arreglo(t6, "negativa"), color, t6);

                Get_Score(t6);
                Get_Move(t6, color);
            }
        }

        protected void A7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a7.CssClass == vacio)
            {
                ComerFicha(Arreglo(a7, "fila"), color, a7);
                ComerFicha(Arreglo(a7, "columna"), color, a7);
                ComerFicha(Arreglo(a7, "positiva"), color, a7);
                ComerFicha(Arreglo(a7, "negativa"), color, a7);

                Get_Score(a7);
                Get_Move(a7, color);
            }
        }

        protected void B7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b7.CssClass == vacio)
            {
                ComerFicha(Arreglo(b7, "fila"), color, b7);
                ComerFicha(Arreglo(b7, "columna"), color, b7);
                ComerFicha(Arreglo(b7, "positiva"), color, b7);
                ComerFicha(Arreglo(b7, "negativa"), color, b7);

                Get_Score(b7);
                Get_Move(b7, color);
            }
        }

        protected void C7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c7.CssClass == vacio)
            {
                ComerFicha(Arreglo(c7, "fila"), color, c7);
                ComerFicha(Arreglo(c7, "columna"), color, c7);
                ComerFicha(Arreglo(c7, "positiva"), color, c7);
                ComerFicha(Arreglo(c7, "negativa"), color, c7);

                Get_Score(c7);
                Get_Move(c7, color);
            }
        }

        protected void D7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d7.CssClass == vacio)
            {
                ComerFicha(Arreglo(d7, "fila"), color, d7);
                ComerFicha(Arreglo(d7, "columna"), color, d7);
                ComerFicha(Arreglo(d7, "positiva"), color, d7);
                ComerFicha(Arreglo(d7, "negativa"), color, d7);

                Get_Score(d7);
                Get_Move(d7, color);
            }
        }

        protected void E7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e7.CssClass == vacio)
            {
                ComerFicha(Arreglo(e7, "fila"), color, e7);
                ComerFicha(Arreglo(e7, "columna"), color, e7);
                ComerFicha(Arreglo(e7, "positiva"), color, e7);
                ComerFicha(Arreglo(e7, "negativa"), color, e7);

                Get_Score(e7);
                Get_Move(e7, color);
            }
        }

        protected void F7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f7.CssClass == vacio)
            {
                ComerFicha(Arreglo(f7, "fila"), color, f7);
                ComerFicha(Arreglo(f7, "columna"), color, f7);
                ComerFicha(Arreglo(f7, "positiva"), color, f7);
                ComerFicha(Arreglo(f7, "negativa"), color, f7);

                Get_Score(f7);
                Get_Move(f7, color);
            }
        }

        protected void G7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g7.CssClass == vacio)
            {
                ComerFicha(Arreglo(g7, "fila"), color, g7);
                ComerFicha(Arreglo(g7, "columna"), color, g7);
                ComerFicha(Arreglo(g7, "positiva"), color, g7);
                ComerFicha(Arreglo(g7, "negativa"), color, g7);

                Get_Score(g7);
                Get_Move(g7, color);
            }
        }

        protected void H7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h7.CssClass == vacio)
            {
                ComerFicha(Arreglo(h7, "fila"), color, h7);
                ComerFicha(Arreglo(h7, "columna"), color, h7);
                ComerFicha(Arreglo(h7, "positiva"), color, h7);
                ComerFicha(Arreglo(h7, "negativa"), color, h7);

                Get_Score(h7);
                Get_Move(h7, color);
            }
        }

        protected void I7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i7.CssClass == vacio)
            {
                ComerFicha(Arreglo(i7, "fila"), color, i7);
                ComerFicha(Arreglo(i7, "columna"), color, i7);
                ComerFicha(Arreglo(i7, "positiva"), color, i7);
                ComerFicha(Arreglo(i7, "negativa"), color, i7);

                Get_Score(i7);
                Get_Move(i7, color);
            }
        }

        protected void J7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j7.CssClass == vacio)
            {
                ComerFicha(Arreglo(j7, "fila"), color, j7);
                ComerFicha(Arreglo(j7, "columna"), color, j7);
                ComerFicha(Arreglo(j7, "positiva"), color, j7);
                ComerFicha(Arreglo(j7, "negativa"), color, j7);

                Get_Score(j7);
                Get_Move(j7, color);
            }
        }

        protected void K7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k7.CssClass == vacio)
            {
                ComerFicha(Arreglo(k7, "fila"), color, k7);
                ComerFicha(Arreglo(k7, "columna"), color, k7);
                ComerFicha(Arreglo(k7, "positiva"), color, k7);
                ComerFicha(Arreglo(k7, "negativa"), color, k7);

                Get_Score(k7);
                Get_Move(k7, color);
            }
        }

        protected void L7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l7.CssClass == vacio)
            {
                ComerFicha(Arreglo(l7, "fila"), color, l7);
                ComerFicha(Arreglo(l7, "columna"), color, l7);
                ComerFicha(Arreglo(l7, "positiva"), color, l7);
                ComerFicha(Arreglo(l7, "negativa"), color, l7);

                Get_Score(l7);
                Get_Move(l7, color);
            }
        }

        protected void M7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m7.CssClass == vacio)
            {
                ComerFicha(Arreglo(m7, "fila"), color, m7);
                ComerFicha(Arreglo(m7, "columna"), color, m7);
                ComerFicha(Arreglo(m7, "positiva"), color, m7);
                ComerFicha(Arreglo(m7, "negativa"), color, m7);

                Get_Score(m7);
                Get_Move(m7, color);
            }
        }

        protected void N7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n7.CssClass == vacio)
            {
                ComerFicha(Arreglo(n7, "fila"), color, n7);
                ComerFicha(Arreglo(n7, "columna"), color, n7);
                ComerFicha(Arreglo(n7, "positiva"), color, n7);
                ComerFicha(Arreglo(n7, "negativa"), color, n7);

                Get_Score(n7);
                Get_Move(n7, color);
            }
        }

        protected void O7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o7.CssClass == vacio)
            {
                ComerFicha(Arreglo(o7, "fila"), color, o7);
                ComerFicha(Arreglo(o7, "columna"), color, o7);
                ComerFicha(Arreglo(o7, "positiva"), color, o7);
                ComerFicha(Arreglo(o7, "negativa"), color, o7);

                Get_Score(o7);
                Get_Move(o7, color);
            }
        }

        protected void P7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p7.CssClass == vacio)
            {
                ComerFicha(Arreglo(p7, "fila"), color, p7);
                ComerFicha(Arreglo(p7, "columna"), color, p7);
                ComerFicha(Arreglo(p7, "positiva"), color, p7);
                ComerFicha(Arreglo(p7, "negativa"), color, p7);

                Get_Score(p7);
                Get_Move(p7, color);
            }
        }

        protected void Q7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q7.CssClass == vacio)
            {
                ComerFicha(Arreglo(q7, "fila"), color, q7);
                ComerFicha(Arreglo(q7, "columna"), color, q7);
                ComerFicha(Arreglo(q7, "positiva"), color, q7);
                ComerFicha(Arreglo(q7, "negativa"), color, q7);

                Get_Score(q7);
                Get_Move(q7, color);
            }
        }

        protected void R7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r7.CssClass == vacio)
            {
                ComerFicha(Arreglo(r7, "fila"), color, r7);
                ComerFicha(Arreglo(r7, "columna"), color, r7);
                ComerFicha(Arreglo(r7, "positiva"), color, r7);
                ComerFicha(Arreglo(r7, "negativa"), color, r7);

                Get_Score(r7);
                Get_Move(r7, color);
            }
        }

        protected void S7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s7.CssClass == vacio)
            {
                ComerFicha(Arreglo(s7, "fila"), color, s7);
                ComerFicha(Arreglo(s7, "columna"), color, s7);
                ComerFicha(Arreglo(s7, "positiva"), color, s7);
                ComerFicha(Arreglo(s7, "negativa"), color, s7);

                Get_Score(s7);
                Get_Move(s7, color);
            }
        }

        protected void T7_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t7.CssClass == vacio)
            {
                ComerFicha(Arreglo(t7, "fila"), color, t7);
                ComerFicha(Arreglo(t7, "columna"), color, t7);
                ComerFicha(Arreglo(t7, "positiva"), color, t7);
                ComerFicha(Arreglo(t7, "negativa"), color, t7);

                Get_Score(t7);
                Get_Move(t7, color);
            }
        }

        protected void A8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a8.CssClass == vacio)
            {
                ComerFicha(Arreglo(a8, "fila"), color, a8);
                ComerFicha(Arreglo(a8, "columna"), color, a8);
                ComerFicha(Arreglo(a8, "positiva"), color, a8);
                ComerFicha(Arreglo(a8, "negativa"), color, a8);

                Get_Score(a8);
                Get_Move(a8, color);
            }
        }

        protected void B8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b8.CssClass == vacio)
            {
                ComerFicha(Arreglo(b8, "fila"), color, b8);
                ComerFicha(Arreglo(b8, "columna"), color, b8);
                ComerFicha(Arreglo(b8, "positiva"), color, b8);
                ComerFicha(Arreglo(b8, "negativa"), color, b8);

                Get_Score(b8);
                Get_Move(b8, color);
            }
        }

        protected void C8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c8.CssClass == vacio)
            {
                ComerFicha(Arreglo(c8, "fila"), color, c8);
                ComerFicha(Arreglo(c8, "columna"), color, c8);
                ComerFicha(Arreglo(c8, "positiva"), color, c8);
                ComerFicha(Arreglo(c8, "negativa"), color, c8);

                Get_Score(c8);
                Get_Move(c8, color);
            }
        }

        protected void D8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d8.CssClass == vacio)
            {
                ComerFicha(Arreglo(d8, "fila"), color, d8);
                ComerFicha(Arreglo(d8, "columna"), color, d8);
                ComerFicha(Arreglo(d8, "positiva"), color, d8);
                ComerFicha(Arreglo(d8, "negativa"), color, d8);

                Get_Score(d8);
                Get_Move(d8, color);
            }
        }

        protected void E8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e8.CssClass == vacio)
            {
                ComerFicha(Arreglo(e8, "fila"), color, e8);
                ComerFicha(Arreglo(e8, "columna"), color, e8);
                ComerFicha(Arreglo(e8, "positiva"), color, e8);
                ComerFicha(Arreglo(e8, "negativa"), color, e8);

                Get_Score(e8);
                Get_Move(e8, color);
            }
        }

        protected void F8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f8.CssClass == vacio)
            {
                ComerFicha(Arreglo(f8, "fila"), color, f8);
                ComerFicha(Arreglo(f8, "columna"), color, f8);
                ComerFicha(Arreglo(f8, "positiva"), color, f8);
                ComerFicha(Arreglo(f8, "negativa"), color, f8);

                Get_Score(f8);
                Get_Move(f8, color);
            }
        }

        protected void G8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g8.CssClass == vacio)
            {
                ComerFicha(Arreglo(g8, "fila"), color, g8);
                ComerFicha(Arreglo(g8, "columna"), color, g8);
                ComerFicha(Arreglo(g8, "positiva"), color, g8);
                ComerFicha(Arreglo(g8, "negativa"), color, g8);

                Get_Score(g8);
                Get_Move(g8, color);
            }
        }

        protected void H8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h8.CssClass == vacio)
            {
                ComerFicha(Arreglo(h8, "fila"), color, h8);
                ComerFicha(Arreglo(h8, "columna"), color, h8);
                ComerFicha(Arreglo(h8, "positiva"), color, h8);
                ComerFicha(Arreglo(h8, "negativa"), color, h8);

                Get_Score(h8);
                Get_Move(h8, color);
            }
        }

        protected void I8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i8.CssClass == vacio)
            {
                ComerFicha(Arreglo(i8, "fila"), color, i8);
                ComerFicha(Arreglo(i8, "columna"), color, i8);
                ComerFicha(Arreglo(i8, "positiva"), color, i8);
                ComerFicha(Arreglo(i8, "negativa"), color, i8);

                Get_Score(i8);
                Get_Move(i8, color);
            }
        }

        protected void J8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j8.CssClass == vacio)
            {
                ComerFicha(Arreglo(j8, "fila"), color, j8);
                ComerFicha(Arreglo(j8, "columna"), color, j8);
                ComerFicha(Arreglo(j8, "positiva"), color, j8);
                ComerFicha(Arreglo(j8, "negativa"), color, j8);

                Get_Score(j8);
                Get_Move(j8, color);
            }
        }

        protected void K8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k8.CssClass == vacio)
            {
                ComerFicha(Arreglo(k8, "fila"), color, k8);
                ComerFicha(Arreglo(k8, "columna"), color, k8);
                ComerFicha(Arreglo(k8, "positiva"), color, k8);
                ComerFicha(Arreglo(k8, "negativa"), color, k8);

                Get_Score(k8);
                Get_Move(k8, color);
            }
        }

        protected void L8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l8.CssClass == vacio)
            {
                ComerFicha(Arreglo(l8, "fila"), color, l8);
                ComerFicha(Arreglo(l8, "columna"), color, l8);
                ComerFicha(Arreglo(l8, "positiva"), color, l8);
                ComerFicha(Arreglo(l8, "negativa"), color, l8);

                Get_Score(l8);
                Get_Move(l8, color);
            }
        }

        protected void M8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m8.CssClass == vacio)
            {
                ComerFicha(Arreglo(m8, "fila"), color, m8);
                ComerFicha(Arreglo(m8, "columna"), color, m8);
                ComerFicha(Arreglo(m8, "positiva"), color, m8);
                ComerFicha(Arreglo(m8, "negativa"), color, m8);

                Get_Score(m8);
                Get_Move(m8, color);
            }
        }

        protected void N8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n8.CssClass == vacio)
            {
                ComerFicha(Arreglo(n8, "fila"), color, n8);
                ComerFicha(Arreglo(n8, "columna"), color, n8);
                ComerFicha(Arreglo(n8, "positiva"), color, n8);
                ComerFicha(Arreglo(n8, "negativa"), color, n8);

                Get_Score(n8);
                Get_Move(n8, color);
            }
        }

        protected void O8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o8.CssClass == vacio)
            {
                ComerFicha(Arreglo(o8, "fila"), color, o8);
                ComerFicha(Arreglo(o8, "columna"), color, o8);
                ComerFicha(Arreglo(o8, "positiva"), color, o8);
                ComerFicha(Arreglo(o8, "negativa"), color, o8);

                Get_Score(o8);
                Get_Move(o8, color);
            }
        }

        protected void P8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p8.CssClass == vacio)
            {
                ComerFicha(Arreglo(p8, "fila"), color, p8);
                ComerFicha(Arreglo(p8, "columna"), color, p8);
                ComerFicha(Arreglo(p8, "positiva"), color, p8);
                ComerFicha(Arreglo(p8, "negativa"), color, p8);

                Get_Score(p8);
                Get_Move(p8, color);
            }
        }

        protected void Q8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q8.CssClass == vacio)
            {
                ComerFicha(Arreglo(q8, "fila"), color, q8);
                ComerFicha(Arreglo(q8, "columna"), color, q8);
                ComerFicha(Arreglo(q8, "positiva"), color, q8);
                ComerFicha(Arreglo(q8, "negativa"), color, q8);

                Get_Score(q8);
                Get_Move(q8, color);
            }
        }

        protected void R8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r8.CssClass == vacio)
            {
                ComerFicha(Arreglo(r8, "fila"), color, r8);
                ComerFicha(Arreglo(r8, "columna"), color, r8);
                ComerFicha(Arreglo(r8, "positiva"), color, r8);
                ComerFicha(Arreglo(r8, "negativa"), color, r8);

                Get_Score(r8);
                Get_Move(r8, color);
            }
        }

        protected void S8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s8.CssClass == vacio)
            {
                ComerFicha(Arreglo(s8, "fila"), color, s8);
                ComerFicha(Arreglo(s8, "columna"), color, s8);
                ComerFicha(Arreglo(s8, "positiva"), color, s8);
                ComerFicha(Arreglo(s8, "negativa"), color, s8);

                Get_Score(s8);
                Get_Move(s8, color);
            }
        }

        protected void T8_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t8.CssClass == vacio)
            {
                ComerFicha(Arreglo(t8, "fila"), color, t8);
                ComerFicha(Arreglo(t8, "columna"), color, t8);
                ComerFicha(Arreglo(t8, "positiva"), color, t8);
                ComerFicha(Arreglo(t8, "negativa"), color, t8);

                Get_Score(t8);
                Get_Move(t8, color);
            }
        }

        protected void A9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a9.CssClass == vacio)
            {
                ComerFicha(Arreglo(a9, "fila"), color, a9);
                ComerFicha(Arreglo(a9, "columna"), color, a9);
                ComerFicha(Arreglo(a9, "positiva"), color, a9);
                ComerFicha(Arreglo(a9, "negativa"), color, a9);

                Get_Score(a9);
                Get_Move(a9, color);
            }
        }

        protected void B9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b9.CssClass == vacio)
            {
                ComerFicha(Arreglo(b9, "fila"), color, b9);
                ComerFicha(Arreglo(b9, "columna"), color, b9);
                ComerFicha(Arreglo(b9, "positiva"), color, b9);
                ComerFicha(Arreglo(b9, "negativa"), color, b9);

                Get_Score(b9);
                Get_Move(b9, color);
            }
        }

        protected void C9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c9.CssClass == vacio)
            {
                ComerFicha(Arreglo(c9, "fila"), color, c9);
                ComerFicha(Arreglo(c9, "columna"), color, c9);
                ComerFicha(Arreglo(c9, "positiva"), color, c9);
                ComerFicha(Arreglo(c9, "negativa"), color, c9);

                Get_Score(c9);
                Get_Move(c9, color);
            }
        }

        protected void D9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d9.CssClass == vacio)
            {
                ComerFicha(Arreglo(d9, "fila"), color, d9);
                ComerFicha(Arreglo(d9, "columna"), color, d9);
                ComerFicha(Arreglo(d9, "positiva"), color, d9);
                ComerFicha(Arreglo(d9, "negativa"), color, d9);

                Get_Score(d9);
                Get_Move(d9, color);
            }
        }

        protected void E9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e9.CssClass == vacio)
            {
                ComerFicha(Arreglo(e9, "fila"), color, e9);
                ComerFicha(Arreglo(e9, "columna"), color, e9);
                ComerFicha(Arreglo(e9, "positiva"), color, e9);
                ComerFicha(Arreglo(e9, "negativa"), color, e9);

                Get_Score(e9);
                Get_Move(e9, color);
            }
        }

        protected void F9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f9.CssClass == vacio)
            {
                ComerFicha(Arreglo(f9, "fila"), color, f9);
                ComerFicha(Arreglo(f9, "columna"), color, f9);
                ComerFicha(Arreglo(f9, "positiva"), color, f9);
                ComerFicha(Arreglo(f9, "negativa"), color, f9);

                Get_Score(f9);
                Get_Move(f9, color);
            }
        }

        protected void G9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g9.CssClass == vacio)
            {
                ComerFicha(Arreglo(g9, "fila"), color, g9);
                ComerFicha(Arreglo(g9, "columna"), color, g9);
                ComerFicha(Arreglo(g9, "positiva"), color, g9);
                ComerFicha(Arreglo(g9, "negativa"), color, g9);

                Get_Score(g9);
                Get_Move(g9, color);
            }
        }

        protected void H9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h9.CssClass == vacio)
            {
                ComerFicha(Arreglo(h9, "fila"), color, h9);
                ComerFicha(Arreglo(h9, "columna"), color, h9);
                ComerFicha(Arreglo(h9, "positiva"), color, h9);
                ComerFicha(Arreglo(h9, "negativa"), color, h9);

                Get_Score(h9);
                Get_Move(h9, color);
            }
        }

        protected void I9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i9.CssClass == vacio)
            {
                ComerFicha(Arreglo(i9, "fila"), color, i9);
                ComerFicha(Arreglo(i9, "columna"), color, i9);
                ComerFicha(Arreglo(i9, "positiva"), color, i9);
                ComerFicha(Arreglo(i9, "negativa"), color, i9);

                Get_Score(i9);
                Get_Move(i9, color);
            }
        }

        protected void J9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j9.CssClass == vacio)
            {
                ComerFicha(Arreglo(j9, "fila"), color, j9);
                ComerFicha(Arreglo(j9, "columna"), color, j9);
                ComerFicha(Arreglo(j9, "positiva"), color, j9);
                ComerFicha(Arreglo(j9, "negativa"), color, j9);

                Get_Score(j9);
                Get_Move(j9, color);
            }
        }

        protected void K9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k9.CssClass == vacio)
            {
                ComerFicha(Arreglo(k9, "fila"), color, k9);
                ComerFicha(Arreglo(k9, "columna"), color, k9);
                ComerFicha(Arreglo(k9, "positiva"), color, k9);
                ComerFicha(Arreglo(k9, "negativa"), color, k9);

                Get_Score(k9);
                Get_Move(k9, color);
            }
        }

        protected void L9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l9.CssClass == vacio)
            {
                ComerFicha(Arreglo(l9, "fila"), color, l9);
                ComerFicha(Arreglo(l9, "columna"), color, l9);
                ComerFicha(Arreglo(l9, "positiva"), color, l9);
                ComerFicha(Arreglo(l9, "negativa"), color, l9);

                Get_Score(l9);
                Get_Move(l9, color);
            }
        }

        protected void M9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m9.CssClass == vacio)
            {
                ComerFicha(Arreglo(m9, "fila"), color, m9);
                ComerFicha(Arreglo(m9, "columna"), color, m9);
                ComerFicha(Arreglo(m9, "positiva"), color, m9);
                ComerFicha(Arreglo(m9, "negativa"), color, m9);

                Get_Score(m9);
                Get_Move(m9, color);
            }
        }

        protected void N9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n9.CssClass == vacio)
            {
                ComerFicha(Arreglo(n9, "fila"), color, n9);
                ComerFicha(Arreglo(n9, "columna"), color, n9);
                ComerFicha(Arreglo(n9, "positiva"), color, n9);
                ComerFicha(Arreglo(n9, "negativa"), color, n9);

                Get_Score(n9);
                Get_Move(n9, color);
            }
        }

        protected void O9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o9.CssClass == vacio)
            {
                ComerFicha(Arreglo(o9, "fila"), color, o9);
                ComerFicha(Arreglo(o9, "columna"), color, o9);
                ComerFicha(Arreglo(o9, "positiva"), color, o9);
                ComerFicha(Arreglo(o9, "negativa"), color, o9);

                Get_Score(o9);
                Get_Move(o9, color);
            }
        }

        protected void P9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p9.CssClass == vacio)
            {
                ComerFicha(Arreglo(p9, "fila"), color, p9);
                ComerFicha(Arreglo(p9, "columna"), color, p9);
                ComerFicha(Arreglo(p9, "positiva"), color, p9);
                ComerFicha(Arreglo(p9, "negativa"), color, p9);

                Get_Score(p9);
                Get_Move(p9, color);
            }
        }

        protected void Q9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q9.CssClass == vacio)
            {
                ComerFicha(Arreglo(q9, "fila"), color, q9);
                ComerFicha(Arreglo(q9, "columna"), color, q9);
                ComerFicha(Arreglo(q9, "positiva"), color, q9);
                ComerFicha(Arreglo(q9, "negativa"), color, q9);

                Get_Score(q9);
                Get_Move(q9, color);
            }
        }

        protected void R9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r9.CssClass == vacio)
            {
                ComerFicha(Arreglo(r9, "fila"), color, r9);
                ComerFicha(Arreglo(r9, "columna"), color, r9);
                ComerFicha(Arreglo(r9, "positiva"), color, r9);
                ComerFicha(Arreglo(r9, "negativa"), color, r9);

                Get_Score(r9);
                Get_Move(r9, color);
            }
        }

        protected void S9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s9.CssClass == vacio)
            {
                ComerFicha(Arreglo(s9, "fila"), color, s9);
                ComerFicha(Arreglo(s9, "columna"), color, s9);
                ComerFicha(Arreglo(s9, "positiva"), color, s9);
                ComerFicha(Arreglo(s9, "negativa"), color, s9);

                Get_Score(s9);
                Get_Move(s9, color);
            }
        }

        protected void T9_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t9.CssClass == vacio)
            {
                ComerFicha(Arreglo(t9, "fila"), color, t9);
                ComerFicha(Arreglo(t9, "columna"), color, t9);
                ComerFicha(Arreglo(t9, "positiva"), color, t9);
                ComerFicha(Arreglo(t9, "negativa"), color, t9);

                Get_Score(t9);
                Get_Move(t9, color);
            }
        }

        protected void A10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a10.CssClass == vacio)
            {
                ComerFicha(Arreglo(a10, "fila"), color, a10);
                ComerFicha(Arreglo(a10, "columna"), color, a10);
                ComerFicha(Arreglo(a10, "positiva"), color, a10);
                ComerFicha(Arreglo(a10, "negativa"), color, a10);

                Get_Score(a10);
                Get_Move(a10, color);
            }
        }

        protected void B10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b10.CssClass == vacio)
            {
                ComerFicha(Arreglo(b10, "fila"), color, b10);
                ComerFicha(Arreglo(b10, "columna"), color, b10);
                ComerFicha(Arreglo(b10, "positiva"), color, b10);
                ComerFicha(Arreglo(b10, "negativa"), color, b10);

                Get_Score(b10);
                Get_Move(b10, color);
            }
        }

        protected void C10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c10.CssClass == vacio)
            {
                ComerFicha(Arreglo(c10, "fila"), color, c10);
                ComerFicha(Arreglo(c10, "columna"), color, c10);
                ComerFicha(Arreglo(c10, "positiva"), color, c10);
                ComerFicha(Arreglo(c10, "negativa"), color, c10);

                Get_Score(c10);
                Get_Move(c10, color);
            }
        }

        protected void D10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d10.CssClass == vacio)
            {
                ComerFicha(Arreglo(d10, "fila"), color, d10);
                ComerFicha(Arreglo(d10, "columna"), color, d10);
                ComerFicha(Arreglo(d10, "positiva"), color, d10);
                ComerFicha(Arreglo(d10, "negativa"), color, d10);

                Get_Score(d10);
                Get_Move(d10, color);
            }
        }

        protected void E10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e10.CssClass == vacio)
            {
                ComerFicha(Arreglo(e10, "fila"), color, e10);
                ComerFicha(Arreglo(e10, "columna"), color, e10);
                ComerFicha(Arreglo(e10, "positiva"), color, e10);
                ComerFicha(Arreglo(e10, "negativa"), color, e10);

                Get_Score(e10);
                Get_Move(e10, color);
            }
        }

        protected void F10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f10.CssClass == vacio)
            {
                ComerFicha(Arreglo(f10, "fila"), color, f10);
                ComerFicha(Arreglo(f10, "columna"), color, f10);
                ComerFicha(Arreglo(f10, "positiva"), color, f10);
                ComerFicha(Arreglo(f10, "negativa"), color, f10);

                Get_Score(f10);
                Get_Move(f10, color);
            }
        }

        protected void G10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g10.CssClass == vacio)
            {
                ComerFicha(Arreglo(g10, "fila"), color, g10);
                ComerFicha(Arreglo(g10, "columna"), color, g10);
                ComerFicha(Arreglo(g10, "positiva"), color, g10);
                ComerFicha(Arreglo(g10, "negativa"), color, g10);

                Get_Score(g10);
                Get_Move(g10, color);
            }
        }

        protected void H10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h10.CssClass == vacio)
            {
                ComerFicha(Arreglo(h10, "fila"), color, h10);
                ComerFicha(Arreglo(h10, "columna"), color, h10);
                ComerFicha(Arreglo(h10, "positiva"), color, h10);
                ComerFicha(Arreglo(h10, "negativa"), color, h10);

                Get_Score(h10);
                Get_Move(h10, color);
            }
        }

        protected void I10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i10.CssClass == vacio)
            {
                ComerFicha(Arreglo(i10, "fila"), color, i10);
                ComerFicha(Arreglo(i10, "columna"), color, i10);
                ComerFicha(Arreglo(i10, "positiva"), color, i10);
                ComerFicha(Arreglo(i10, "negativa"), color, i10);

                Get_Score(i10);
                Get_Move(i10, color);
            }
        }

        protected void J10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j10.CssClass == vacio)
            {
                ComerFicha(Arreglo(j10, "fila"), color, j10);
                ComerFicha(Arreglo(j10, "columna"), color, j10);
                ComerFicha(Arreglo(j10, "positiva"), color, j10);
                ComerFicha(Arreglo(j10, "negativa"), color, j10);

                Get_Score(j10);
                Get_Move(j10, color);
            }
        }

        protected void K10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k10.CssClass == vacio)
            {
                ComerFicha(Arreglo(k10, "fila"), color, k10);
                ComerFicha(Arreglo(k10, "columna"), color, k10);
                ComerFicha(Arreglo(k10, "positiva"), color, k10);
                ComerFicha(Arreglo(k10, "negativa"), color, k10);

                Get_Score(k10);
                Get_Move(k10, color);
            }
        }

        protected void L10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l10.CssClass == vacio)
            {
                ComerFicha(Arreglo(l10, "fila"), color, l10);
                ComerFicha(Arreglo(l10, "columna"), color, l10);
                ComerFicha(Arreglo(l10, "positiva"), color, l10);
                ComerFicha(Arreglo(l10, "negativa"), color, l10);

                Get_Score(l10);
                Get_Move(l10, color);
            }
        }

        protected void M10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m10.CssClass == vacio)
            {
                ComerFicha(Arreglo(m10, "fila"), color, m10);
                ComerFicha(Arreglo(m10, "columna"), color, m10);
                ComerFicha(Arreglo(m10, "positiva"), color, m10);
                ComerFicha(Arreglo(m10, "negativa"), color, m10);

                Get_Score(m10);
                Get_Move(m10, color);
            }
        }

        protected void N10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n10.CssClass == vacio)
            {
                ComerFicha(Arreglo(n10, "fila"), color, n10);
                ComerFicha(Arreglo(n10, "columna"), color, n10);
                ComerFicha(Arreglo(n10, "positiva"), color, n10);
                ComerFicha(Arreglo(n10, "negativa"), color, n10);

                Get_Score(n10);
                Get_Move(n10, color);
            }
        }

        protected void O10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o10.CssClass == vacio)
            {
                ComerFicha(Arreglo(o10, "fila"), color, o10);
                ComerFicha(Arreglo(o10, "columna"), color, o10);
                ComerFicha(Arreglo(o10, "positiva"), color, o10);
                ComerFicha(Arreglo(o10, "negativa"), color, o10);

                Get_Score(o10);
                Get_Move(o10, color);
            }
        }

        protected void P10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p10.CssClass == vacio)
            {
                ComerFicha(Arreglo(p10, "fila"), color, p10);
                ComerFicha(Arreglo(p10, "columna"), color, p10);
                ComerFicha(Arreglo(p10, "positiva"), color, p10);
                ComerFicha(Arreglo(p10, "negativa"), color, p10);

                Get_Score(p10);
                Get_Move(p10, color);
            }
        }

        protected void Q10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q10.CssClass == vacio)
            {
                ComerFicha(Arreglo(q10, "fila"), color, q10);
                ComerFicha(Arreglo(q10, "columna"), color, q10);
                ComerFicha(Arreglo(q10, "positiva"), color, q10);
                ComerFicha(Arreglo(q10, "negativa"), color, q10);

                Get_Score(q10);
                Get_Move(q10, color);
            }
        }

        protected void R10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r10.CssClass == vacio)
            {
                ComerFicha(Arreglo(r10, "fila"), color, r10);
                ComerFicha(Arreglo(r10, "columna"), color, r10);
                ComerFicha(Arreglo(r10, "positiva"), color, r10);
                ComerFicha(Arreglo(r10, "negativa"), color, r10);

                Get_Score(r10);
                Get_Move(r10, color);
            }
        }

        protected void S10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s10.CssClass == vacio)
            {
                ComerFicha(Arreglo(s10, "fila"), color, s10);
                ComerFicha(Arreglo(s10, "columna"), color, s10);
                ComerFicha(Arreglo(s10, "positiva"), color, s10);
                ComerFicha(Arreglo(s10, "negativa"), color, s10);

                Get_Score(s10);
                Get_Move(s10, color);
            }
        }

        protected void T10_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t10.CssClass == vacio)
            {
                ComerFicha(Arreglo(t10, "fila"), color, t10);
                ComerFicha(Arreglo(t10, "columna"), color, t10);
                ComerFicha(Arreglo(t10, "positiva"), color, t10);
                ComerFicha(Arreglo(t10, "negativa"), color, t10);

                Get_Score(t10);
                Get_Move(t10, color);
            }
        }

        protected void A11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a11.CssClass == vacio)
            {
                ComerFicha(Arreglo(a11, "fila"), color, a11);
                ComerFicha(Arreglo(a11, "columna"), color, a11);
                ComerFicha(Arreglo(a11, "positiva"), color, a11);
                ComerFicha(Arreglo(a11, "negativa"), color, a11);

                Get_Score(a11);
                Get_Move(a11, color);
            }
        }

        protected void B11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b11.CssClass == vacio)
            {
                ComerFicha(Arreglo(b11, "fila"), color, b11);
                ComerFicha(Arreglo(b11, "columna"), color, b11);
                ComerFicha(Arreglo(b11, "positiva"), color, b11);
                ComerFicha(Arreglo(b11, "negativa"), color, b11);

                Get_Score(b11);
                Get_Move(b11, color);
            }
        }

        protected void C11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c11.CssClass == vacio)
            {
                ComerFicha(Arreglo(c11, "fila"), color, c11);
                ComerFicha(Arreglo(c11, "columna"), color, c11);
                ComerFicha(Arreglo(c11, "positiva"), color, c11);
                ComerFicha(Arreglo(c11, "negativa"), color, c11);

                Get_Score(c11);
                Get_Move(c11, color);
            }
        }

        protected void D11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d11.CssClass == vacio)
            {
                ComerFicha(Arreglo(d11, "fila"), color, d11);
                ComerFicha(Arreglo(d11, "columna"), color, d11);
                ComerFicha(Arreglo(d11, "positiva"), color, d11);
                ComerFicha(Arreglo(d11, "negativa"), color, d11);

                Get_Score(d11);
                Get_Move(d11, color);
            }
        }

        protected void E11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e11.CssClass == vacio)
            {
                ComerFicha(Arreglo(e11, "fila"), color, e11);
                ComerFicha(Arreglo(e11, "columna"), color, e11);
                ComerFicha(Arreglo(e11, "positiva"), color, e11);
                ComerFicha(Arreglo(e11, "negativa"), color, e11);

                Get_Score(e11);
                Get_Move(e11, color);
            }
        }

        protected void F11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f11.CssClass == vacio)
            {
                ComerFicha(Arreglo(f11, "fila"), color, f11);
                ComerFicha(Arreglo(f11, "columna"), color, f11);
                ComerFicha(Arreglo(f11, "positiva"), color, f11);
                ComerFicha(Arreglo(f11, "negativa"), color, f11);

                Get_Score(f11);
                Get_Move(f11, color);
            }
        }

        protected void G11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g11.CssClass == vacio)
            {
                ComerFicha(Arreglo(g11, "fila"), color, g11);
                ComerFicha(Arreglo(g11, "columna"), color, g11);
                ComerFicha(Arreglo(g11, "positiva"), color, g11);
                ComerFicha(Arreglo(g11, "negativa"), color, g11);

                Get_Score(g11);
                Get_Move(g11, color);
            }
        }

        protected void H11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h11.CssClass == vacio)
            {
                ComerFicha(Arreglo(h11, "fila"), color, h11);
                ComerFicha(Arreglo(h11, "columna"), color, h11);
                ComerFicha(Arreglo(h11, "positiva"), color, h11);
                ComerFicha(Arreglo(h11, "negativa"), color, h11);

                Get_Score(h11);
                Get_Move(h11, color);
            }
        }

        protected void I11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i11.CssClass == vacio)
            {
                ComerFicha(Arreglo(i11, "fila"), color, i11);
                ComerFicha(Arreglo(i11, "columna"), color, i11);
                ComerFicha(Arreglo(i11, "positiva"), color, i11);
                ComerFicha(Arreglo(i11, "negativa"), color, i11);

                Get_Score(i11);
                Get_Move(i11, color);
            }
        }

        protected void J11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j11.CssClass == vacio)
            {
                ComerFicha(Arreglo(j11, "fila"), color, j11);
                ComerFicha(Arreglo(j11, "columna"), color, j11);
                ComerFicha(Arreglo(j11, "positiva"), color, j11);
                ComerFicha(Arreglo(j11, "negativa"), color, j11);

                Get_Score(j11);
                Get_Move(j11, color);
            }
        }

        protected void K11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k11.CssClass == vacio)
            {
                ComerFicha(Arreglo(k11, "fila"), color, k11);
                ComerFicha(Arreglo(k11, "columna"), color, k11);
                ComerFicha(Arreglo(k11, "positiva"), color, k11);
                ComerFicha(Arreglo(k11, "negativa"), color, k11);

                Get_Score(k11);
                Get_Move(k11, color);
            }
        }

        protected void L11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l11.CssClass == vacio)
            {
                ComerFicha(Arreglo(l11, "fila"), color, l11);
                ComerFicha(Arreglo(l11, "columna"), color, l11);
                ComerFicha(Arreglo(l11, "positiva"), color, l11);
                ComerFicha(Arreglo(l11, "negativa"), color, l11);

                Get_Score(l11);
                Get_Move(l11, color);
            }
        }

        protected void M11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m11.CssClass == vacio)
            {
                ComerFicha(Arreglo(m11, "fila"), color, m11);
                ComerFicha(Arreglo(m11, "columna"), color, m11);
                ComerFicha(Arreglo(m11, "positiva"), color, m11);
                ComerFicha(Arreglo(m11, "negativa"), color, m11);

                Get_Score(m11);
                Get_Move(m11, color);
            }
        }

        protected void N11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n11.CssClass == vacio)
            {
                ComerFicha(Arreglo(n11, "fila"), color, n11);
                ComerFicha(Arreglo(n11, "columna"), color, n11);
                ComerFicha(Arreglo(n11, "positiva"), color, n11);
                ComerFicha(Arreglo(n11, "negativa"), color, n11);

                Get_Score(n11);
                Get_Move(n11, color);
            }
        }

        protected void O11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o11.CssClass == vacio)
            {
                ComerFicha(Arreglo(o11, "fila"), color, o11);
                ComerFicha(Arreglo(o11, "columna"), color, o11);
                ComerFicha(Arreglo(o11, "positiva"), color, o11);
                ComerFicha(Arreglo(o11, "negativa"), color, o11);

                Get_Score(o11);
                Get_Move(o11, color);
            }
        }

        protected void P11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p11.CssClass == vacio)
            {
                ComerFicha(Arreglo(p11, "fila"), color, p11);
                ComerFicha(Arreglo(p11, "columna"), color, p11);
                ComerFicha(Arreglo(p11, "positiva"), color, p11);
                ComerFicha(Arreglo(p11, "negativa"), color, p11);

                Get_Score(p11);
                Get_Move(p11, color);
            }
        }

        protected void Q11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q11.CssClass == vacio)
            {
                ComerFicha(Arreglo(q11, "fila"), color, q11);
                ComerFicha(Arreglo(q11, "columna"), color, q11);
                ComerFicha(Arreglo(q11, "positiva"), color, q11);
                ComerFicha(Arreglo(q11, "negativa"), color, q11);

                Get_Score(q11);
                Get_Move(q11, color);
            }
        }

        protected void R11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r11.CssClass == vacio)
            {
                ComerFicha(Arreglo(r11, "fila"), color, r11);
                ComerFicha(Arreglo(r11, "columna"), color, r11);
                ComerFicha(Arreglo(r11, "positiva"), color, r11);
                ComerFicha(Arreglo(r11, "negativa"), color, r11);

                Get_Score(r11);
                Get_Move(r11, color);
            }
        }

        protected void S11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s11.CssClass == vacio)
            {
                ComerFicha(Arreglo(s11, "fila"), color, s11);
                ComerFicha(Arreglo(s11, "columna"), color, s11);
                ComerFicha(Arreglo(s11, "positiva"), color, s11);
                ComerFicha(Arreglo(s11, "negativa"), color, s11);

                Get_Score(s11);
                Get_Move(s11, color);
            }
        }

        protected void T11_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t11.CssClass == vacio)
            {
                ComerFicha(Arreglo(t11, "fila"), color, t11);
                ComerFicha(Arreglo(t11, "columna"), color, t11);
                ComerFicha(Arreglo(t11, "positiva"), color, t11);
                ComerFicha(Arreglo(t11, "negativa"), color, t11);

                Get_Score(t11);
                Get_Move(t11, color);
            }
        }

        protected void A12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a12.CssClass == vacio)
            {
                ComerFicha(Arreglo(a12, "fila"), color, a12);
                ComerFicha(Arreglo(a12, "columna"), color, a12);
                ComerFicha(Arreglo(a12, "positiva"), color, a12);
                ComerFicha(Arreglo(a12, "negativa"), color, a12);

                Get_Score(a12);
                Get_Move(a12, color);
            }
        }

        protected void B12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b12.CssClass == vacio)
            {
                ComerFicha(Arreglo(b12, "fila"), color, b12);
                ComerFicha(Arreglo(b12, "columna"), color, b12);
                ComerFicha(Arreglo(b12, "positiva"), color, b12);
                ComerFicha(Arreglo(b12, "negativa"), color, b12);

                Get_Score(b12);
                Get_Move(b12, color);
            }
        }

        protected void C12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c12.CssClass == vacio)
            {
                ComerFicha(Arreglo(c12, "fila"), color, c12);
                ComerFicha(Arreglo(c12, "columna"), color, c12);
                ComerFicha(Arreglo(c12, "positiva"), color, c12);
                ComerFicha(Arreglo(c12, "negativa"), color, c12);

                Get_Score(c12);
                Get_Move(c12, color);
            }
        }

        protected void D12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d12.CssClass == vacio)
            {
                ComerFicha(Arreglo(d12, "fila"), color, d12);
                ComerFicha(Arreglo(d12, "columna"), color, d12);
                ComerFicha(Arreglo(d12, "positiva"), color, d12);
                ComerFicha(Arreglo(d12, "negativa"), color, d12);

                Get_Score(d12);
                Get_Move(d12, color);
            }
        }

        protected void E12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e12.CssClass == vacio)
            {
                ComerFicha(Arreglo(e12, "fila"), color, e12);
                ComerFicha(Arreglo(e12, "columna"), color, e12);
                ComerFicha(Arreglo(e12, "positiva"), color, e12);
                ComerFicha(Arreglo(e12, "negativa"), color, e12);

                Get_Score(e12);
                Get_Move(e12, color);
            }
        }

        protected void F12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f12.CssClass == vacio)
            {
                ComerFicha(Arreglo(f12, "fila"), color, f12);
                ComerFicha(Arreglo(f12, "columna"), color, f12);
                ComerFicha(Arreglo(f12, "positiva"), color, f12);
                ComerFicha(Arreglo(f12, "negativa"), color, f12);

                Get_Score(f12);
                Get_Move(f12, color);
            }
        }

        protected void G12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g12.CssClass == vacio)
            {
                ComerFicha(Arreglo(g12, "fila"), color, g12);
                ComerFicha(Arreglo(g12, "columna"), color, g12);
                ComerFicha(Arreglo(g12, "positiva"), color, g12);
                ComerFicha(Arreglo(g12, "negativa"), color, g12);

                Get_Score(g12);
                Get_Move(g12, color);
            }
        }

        protected void H12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h12.CssClass == vacio)
            {
                ComerFicha(Arreglo(h12, "fila"), color, h12);
                ComerFicha(Arreglo(h12, "columna"), color, h12);
                ComerFicha(Arreglo(h12, "positiva"), color, h12);
                ComerFicha(Arreglo(h12, "negativa"), color, h12);

                Get_Score(h12);
                Get_Move(h12, color);
            }
        }

        protected void I12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i12.CssClass == vacio)
            {
                ComerFicha(Arreglo(i12, "fila"), color, i12);
                ComerFicha(Arreglo(i12, "columna"), color, i12);
                ComerFicha(Arreglo(i12, "positiva"), color, i12);
                ComerFicha(Arreglo(i12, "negativa"), color, i12);

                Get_Score(i12);
                Get_Move(i12, color);
            }
        }

        protected void J12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j12.CssClass == vacio)
            {
                ComerFicha(Arreglo(j12, "fila"), color, j12);
                ComerFicha(Arreglo(j12, "columna"), color, j12);
                ComerFicha(Arreglo(j12, "positiva"), color, j12);
                ComerFicha(Arreglo(j12, "negativa"), color, j12);

                Get_Score(j12);
                Get_Move(j12, color);
            }
        }

        protected void K12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k12.CssClass == vacio)
            {
                ComerFicha(Arreglo(k12, "fila"), color, k12);
                ComerFicha(Arreglo(k12, "columna"), color, k12);
                ComerFicha(Arreglo(k12, "positiva"), color, k12);
                ComerFicha(Arreglo(k12, "negativa"), color, k12);

                Get_Score(k12);
                Get_Move(k12, color);
            }
        }

        protected void L12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l12.CssClass == vacio)
            {
                ComerFicha(Arreglo(l12, "fila"), color, l12);
                ComerFicha(Arreglo(l12, "columna"), color, l12);
                ComerFicha(Arreglo(l12, "positiva"), color, l12);
                ComerFicha(Arreglo(l12, "negativa"), color, l12);

                Get_Score(l12);
                Get_Move(l12, color);
            }
        }

        protected void M12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m12.CssClass == vacio)
            {
                ComerFicha(Arreglo(m12, "fila"), color, m12);
                ComerFicha(Arreglo(m12, "columna"), color, m12);
                ComerFicha(Arreglo(m12, "positiva"), color, m12);
                ComerFicha(Arreglo(m12, "negativa"), color, m12);

                Get_Score(m12);
                Get_Move(m12, color);
            }
        }

        protected void N12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n12.CssClass == vacio)
            {
                ComerFicha(Arreglo(n12, "fila"), color, n12);
                ComerFicha(Arreglo(n12, "columna"), color, n12);
                ComerFicha(Arreglo(n12, "positiva"), color, n12);
                ComerFicha(Arreglo(n12, "negativa"), color, n12);

                Get_Score(n12);
                Get_Move(n12, color);
            }
        }

        protected void O12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o12.CssClass == vacio)
            {
                ComerFicha(Arreglo(o12, "fila"), color, o12);
                ComerFicha(Arreglo(o12, "columna"), color, o12);
                ComerFicha(Arreglo(o12, "positiva"), color, o12);
                ComerFicha(Arreglo(o12, "negativa"), color, o12);

                Get_Score(o12);
                Get_Move(o12, color);
            }
        }

        protected void P12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p12.CssClass == vacio)
            {
                ComerFicha(Arreglo(p12, "fila"), color, p12);
                ComerFicha(Arreglo(p12, "columna"), color, p12);
                ComerFicha(Arreglo(p12, "positiva"), color, p12);
                ComerFicha(Arreglo(p12, "negativa"), color, p12);

                Get_Score(p12);
                Get_Move(p12, color);
            }
        }

        protected void Q12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q12.CssClass == vacio)
            {
                ComerFicha(Arreglo(q12, "fila"), color, q12);
                ComerFicha(Arreglo(q12, "columna"), color, q12);
                ComerFicha(Arreglo(q12, "positiva"), color, q12);
                ComerFicha(Arreglo(q12, "negativa"), color, q12);

                Get_Score(q12);
                Get_Move(q12, color);
            }
        }

        protected void R12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r12.CssClass == vacio)
            {
                ComerFicha(Arreglo(r12, "fila"), color, r12);
                ComerFicha(Arreglo(r12, "columna"), color, r12);
                ComerFicha(Arreglo(r12, "positiva"), color, r12);
                ComerFicha(Arreglo(r12, "negativa"), color, r12);

                Get_Score(r12);
                Get_Move(r12, color);
            }
        }

        protected void S12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s12.CssClass == vacio)
            {
                ComerFicha(Arreglo(s12, "fila"), color, s12);
                ComerFicha(Arreglo(s12, "columna"), color, s12);
                ComerFicha(Arreglo(s12, "positiva"), color, s12);
                ComerFicha(Arreglo(s12, "negativa"), color, s12);

                Get_Score(s12);
                Get_Move(s12, color);
            }
        }

        protected void T12_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t12.CssClass == vacio)
            {
                ComerFicha(Arreglo(t12, "fila"), color, t12);
                ComerFicha(Arreglo(t12, "columna"), color, t12);
                ComerFicha(Arreglo(t12, "positiva"), color, t12);
                ComerFicha(Arreglo(t12, "negativa"), color, t12);

                Get_Score(t12);
                Get_Move(t12, color);
            }
        }

        protected void A13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a13.CssClass == vacio)
            {
                ComerFicha(Arreglo(a13, "fila"), color, a13);
                ComerFicha(Arreglo(a13, "columna"), color, a13);
                ComerFicha(Arreglo(a13, "positiva"), color, a13);
                ComerFicha(Arreglo(a13, "negativa"), color, a13);

                Get_Score(a13);
                Get_Move(a13, color);
            }
        }

        protected void B13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b13.CssClass == vacio)
            {
                ComerFicha(Arreglo(b13, "fila"), color, b13);
                ComerFicha(Arreglo(b13, "columna"), color, b13);
                ComerFicha(Arreglo(b13, "positiva"), color, b13);
                ComerFicha(Arreglo(b13, "negativa"), color, b13);

                Get_Score(b13);
                Get_Move(b13, color);
            }
        }

        protected void C13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c13.CssClass == vacio)
            {
                ComerFicha(Arreglo(c13, "fila"), color, c13);
                ComerFicha(Arreglo(c13, "columna"), color, c13);
                ComerFicha(Arreglo(c13, "positiva"), color, c13);
                ComerFicha(Arreglo(c13, "negativa"), color, c13);

                Get_Score(c13);
                Get_Move(c13, color);
            }
        }

        protected void D13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d13.CssClass == vacio)
            {
                ComerFicha(Arreglo(d13, "fila"), color, d13);
                ComerFicha(Arreglo(d13, "columna"), color, d13);
                ComerFicha(Arreglo(d13, "positiva"), color, d13);
                ComerFicha(Arreglo(d13, "negativa"), color, d13);

                Get_Score(d13);
                Get_Move(d13, color);
            }
        }

        protected void E13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e13.CssClass == vacio)
            {
                ComerFicha(Arreglo(e13, "fila"), color, e13);
                ComerFicha(Arreglo(e13, "columna"), color, e13);
                ComerFicha(Arreglo(e13, "positiva"), color, e13);
                ComerFicha(Arreglo(e13, "negativa"), color, e13);

                Get_Score(e13);
                Get_Move(e13, color);
            }
        }

        protected void F13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f13.CssClass == vacio)
            {
                ComerFicha(Arreglo(f13, "fila"), color, f13);
                ComerFicha(Arreglo(f13, "columna"), color, f13);
                ComerFicha(Arreglo(f13, "positiva"), color, f13);
                ComerFicha(Arreglo(f13, "negativa"), color, f13);

                Get_Score(f13);
                Get_Move(f13, color);
            }
        }

        protected void G13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g13.CssClass == vacio)
            {
                ComerFicha(Arreglo(g13, "fila"), color, g13);
                ComerFicha(Arreglo(g13, "columna"), color, g13);
                ComerFicha(Arreglo(g13, "positiva"), color, g13);
                ComerFicha(Arreglo(g13, "negativa"), color, g13);

                Get_Score(g13);
                Get_Move(g13, color);
            }
        }

        protected void H13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h13.CssClass == vacio)
            {
                ComerFicha(Arreglo(h13, "fila"), color, h13);
                ComerFicha(Arreglo(h13, "columna"), color, h13);
                ComerFicha(Arreglo(h13, "positiva"), color, h13);
                ComerFicha(Arreglo(h13, "negativa"), color, h13);

                Get_Score(h13);
                Get_Move(h13, color);
            }
        }

        protected void I13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i13.CssClass == vacio)
            {
                ComerFicha(Arreglo(i13, "fila"), color, i13);
                ComerFicha(Arreglo(i13, "columna"), color, i13);
                ComerFicha(Arreglo(i13, "positiva"), color, i13);
                ComerFicha(Arreglo(i13, "negativa"), color, i13);

                Get_Score(i13);
                Get_Move(i13, color);
            }
        }

        protected void J13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j13.CssClass == vacio)
            {
                ComerFicha(Arreglo(j13, "fila"), color, j13);
                ComerFicha(Arreglo(j13, "columna"), color, j13);
                ComerFicha(Arreglo(j13, "positiva"), color, j13);
                ComerFicha(Arreglo(j13, "negativa"), color, j13);

                Get_Score(j13);
                Get_Move(j13, color);
            }
        }

        protected void K13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k13.CssClass == vacio)
            {
                ComerFicha(Arreglo(k13, "fila"), color, k13);
                ComerFicha(Arreglo(k13, "columna"), color, k13);
                ComerFicha(Arreglo(k13, "positiva"), color, k13);
                ComerFicha(Arreglo(k13, "negativa"), color, k13);

                Get_Score(k13);
                Get_Move(k13, color);
            }
        }

        protected void L13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l13.CssClass == vacio)
            {
                ComerFicha(Arreglo(l13, "fila"), color, l13);
                ComerFicha(Arreglo(l13, "columna"), color, l13);
                ComerFicha(Arreglo(l13, "positiva"), color, l13);
                ComerFicha(Arreglo(l13, "negativa"), color, l13);

                Get_Score(l13);
                Get_Move(l13, color);
            }
        }

        protected void M13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m13.CssClass == vacio)
            {
                ComerFicha(Arreglo(m13, "fila"), color, m13);
                ComerFicha(Arreglo(m13, "columna"), color, m13);
                ComerFicha(Arreglo(m13, "positiva"), color, m13);
                ComerFicha(Arreglo(m13, "negativa"), color, m13);

                Get_Score(m13);
                Get_Move(m13, color);
            }
        }

        protected void N13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n13.CssClass == vacio)
            {
                ComerFicha(Arreglo(n13, "fila"), color, n13);
                ComerFicha(Arreglo(n13, "columna"), color, n13);
                ComerFicha(Arreglo(n13, "positiva"), color, n13);
                ComerFicha(Arreglo(n13, "negativa"), color, n13);

                Get_Score(n13);
                Get_Move(n13, color);
            }
        }

        protected void O13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o13.CssClass == vacio)
            {
                ComerFicha(Arreglo(o13, "fila"), color, o13);
                ComerFicha(Arreglo(o13, "columna"), color, o13);
                ComerFicha(Arreglo(o13, "positiva"), color, o13);
                ComerFicha(Arreglo(o13, "negativa"), color, o13);

                Get_Score(o13);
                Get_Move(o13, color);
            }
        }

        protected void P13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p13.CssClass == vacio)
            {
                ComerFicha(Arreglo(p13, "fila"), color, p13);
                ComerFicha(Arreglo(p13, "columna"), color, p13);
                ComerFicha(Arreglo(p13, "positiva"), color, p13);
                ComerFicha(Arreglo(p13, "negativa"), color, p13);

                Get_Score(p13);
                Get_Move(p13, color);
            }
        }

        protected void Q13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q13.CssClass == vacio)
            {
                ComerFicha(Arreglo(q13, "fila"), color, q13);
                ComerFicha(Arreglo(q13, "columna"), color, q13);
                ComerFicha(Arreglo(q13, "positiva"), color, q13);
                ComerFicha(Arreglo(q13, "negativa"), color, q13);

                Get_Score(q13);
                Get_Move(q13, color);
            }
        }

        protected void R13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r13.CssClass == vacio)
            {
                ComerFicha(Arreglo(r13, "fila"), color, r13);
                ComerFicha(Arreglo(r13, "columna"), color, r13);
                ComerFicha(Arreglo(r13, "positiva"), color, r13);
                ComerFicha(Arreglo(r13, "negativa"), color, r13);

                Get_Score(r13);
                Get_Move(r13, color);
            }
        }

        protected void S13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s13.CssClass == vacio)
            {
                ComerFicha(Arreglo(s13, "fila"), color, s13);
                ComerFicha(Arreglo(s13, "columna"), color, s13);
                ComerFicha(Arreglo(s13, "positiva"), color, s13);
                ComerFicha(Arreglo(s13, "negativa"), color, s13);

                Get_Score(s13);
                Get_Move(s13, color);
            }
        }

        protected void T13_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t13.CssClass == vacio)
            {
                ComerFicha(Arreglo(t13, "fila"), color, t13);
                ComerFicha(Arreglo(t13, "columna"), color, t13);
                ComerFicha(Arreglo(t13, "positiva"), color, t13);
                ComerFicha(Arreglo(t13, "negativa"), color, t13);

                Get_Score(t13);
                Get_Move(t13, color);
            }
        }

        protected void A14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a14.CssClass == vacio)
            {
                ComerFicha(Arreglo(a14, "fila"), color, a14);
                ComerFicha(Arreglo(a14, "columna"), color, a14);
                ComerFicha(Arreglo(a14, "positiva"), color, a14);
                ComerFicha(Arreglo(a14, "negativa"), color, a14);

                Get_Score(a14);
                Get_Move(a14, color);
            }
        }

        protected void B14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b14.CssClass == vacio)
            {
                ComerFicha(Arreglo(b14, "fila"), color, b14);
                ComerFicha(Arreglo(b14, "columna"), color, b14);
                ComerFicha(Arreglo(b14, "positiva"), color, b14);
                ComerFicha(Arreglo(b14, "negativa"), color, b14);

                Get_Score(b14);
                Get_Move(b14, color);
            }
        }

        protected void C14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c14.CssClass == vacio)
            {
                ComerFicha(Arreglo(c14, "fila"), color, c14);
                ComerFicha(Arreglo(c14, "columna"), color, c14);
                ComerFicha(Arreglo(c14, "positiva"), color, c14);
                ComerFicha(Arreglo(c14, "negativa"), color, c14);

                Get_Score(c14);
                Get_Move(c14, color);
            }
        }

        protected void D14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d14.CssClass == vacio)
            {
                ComerFicha(Arreglo(d14, "fila"), color, d14);
                ComerFicha(Arreglo(d14, "columna"), color, d14);
                ComerFicha(Arreglo(d14, "positiva"), color, d14);
                ComerFicha(Arreglo(d14, "negativa"), color, d14);

                Get_Score(d14);
                Get_Move(d14, color);
            }
        }

        protected void E14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e14.CssClass == vacio)
            {
                ComerFicha(Arreglo(e14, "fila"), color, e14);
                ComerFicha(Arreglo(e14, "columna"), color, e14);
                ComerFicha(Arreglo(e14, "positiva"), color, e14);
                ComerFicha(Arreglo(e14, "negativa"), color, e14);

                Get_Score(e14);
                Get_Move(e14, color);
            }
        }

        protected void F14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f14.CssClass == vacio)
            {
                ComerFicha(Arreglo(f14, "fila"), color, f14);
                ComerFicha(Arreglo(f14, "columna"), color, f14);
                ComerFicha(Arreglo(f14, "positiva"), color, f14);
                ComerFicha(Arreglo(f14, "negativa"), color, f14);

                Get_Score(f14);
                Get_Move(f14, color);
            }
        }

        protected void G14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g14.CssClass == vacio)
            {
                ComerFicha(Arreglo(g14, "fila"), color, g14);
                ComerFicha(Arreglo(g14, "columna"), color, g14);
                ComerFicha(Arreglo(g14, "positiva"), color, g14);
                ComerFicha(Arreglo(g14, "negativa"), color, g14);

                Get_Score(g14);
                Get_Move(g14, color);
            }
        }

        protected void H14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h14.CssClass == vacio)
            {
                ComerFicha(Arreglo(h14, "fila"), color, h14);
                ComerFicha(Arreglo(h14, "columna"), color, h14);
                ComerFicha(Arreglo(h14, "positiva"), color, h14);
                ComerFicha(Arreglo(h14, "negativa"), color, h14);

                Get_Score(h14);
                Get_Move(h14, color);
            }
        }

        protected void I14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i14.CssClass == vacio)
            {
                ComerFicha(Arreglo(i14, "fila"), color, i14);
                ComerFicha(Arreglo(i14, "columna"), color, i14);
                ComerFicha(Arreglo(i14, "positiva"), color, i14);
                ComerFicha(Arreglo(i14, "negativa"), color, i14);

                Get_Score(i14);
                Get_Move(i14, color);
            }
        }

        protected void J14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j14.CssClass == vacio)
            {
                ComerFicha(Arreglo(j14, "fila"), color, j14);
                ComerFicha(Arreglo(j14, "columna"), color, j14);
                ComerFicha(Arreglo(j14, "positiva"), color, j14);
                ComerFicha(Arreglo(j14, "negativa"), color, j14);

                Get_Score(j14);
                Get_Move(j14, color);
            }
        }

        protected void K14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k14.CssClass == vacio)
            {
                ComerFicha(Arreglo(k14, "fila"), color, k14);
                ComerFicha(Arreglo(k14, "columna"), color, k14);
                ComerFicha(Arreglo(k14, "positiva"), color, k14);
                ComerFicha(Arreglo(k14, "negativa"), color, k14);

                Get_Score(k14);
                Get_Move(k14, color);
            }
        }

        protected void L14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l14.CssClass == vacio)
            {
                ComerFicha(Arreglo(l14, "fila"), color, l14);
                ComerFicha(Arreglo(l14, "columna"), color, l14);
                ComerFicha(Arreglo(l14, "positiva"), color, l14);
                ComerFicha(Arreglo(l14, "negativa"), color, l14);

                Get_Score(l14);
                Get_Move(l14, color);
            }
        }

        protected void M14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m14.CssClass == vacio)
            {
                ComerFicha(Arreglo(m14, "fila"), color, m14);
                ComerFicha(Arreglo(m14, "columna"), color, m14);
                ComerFicha(Arreglo(m14, "positiva"), color, m14);
                ComerFicha(Arreglo(m14, "negativa"), color, m14);

                Get_Score(m14);
                Get_Move(m14, color);
            }
        }

        protected void N14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n14.CssClass == vacio)
            {
                ComerFicha(Arreglo(n14, "fila"), color, n14);
                ComerFicha(Arreglo(n14, "columna"), color, n14);
                ComerFicha(Arreglo(n14, "positiva"), color, n14);
                ComerFicha(Arreglo(n14, "negativa"), color, n14);

                Get_Score(n14);
                Get_Move(n14, color);
            }
        }

        protected void O14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o14.CssClass == vacio)
            {
                ComerFicha(Arreglo(o14, "fila"), color, o14);
                ComerFicha(Arreglo(o14, "columna"), color, o14);
                ComerFicha(Arreglo(o14, "positiva"), color, o14);
                ComerFicha(Arreglo(o14, "negativa"), color, o14);

                Get_Score(o14);
                Get_Move(o14, color);
            }
        }

        protected void P14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p14.CssClass == vacio)
            {
                ComerFicha(Arreglo(p14, "fila"), color, p14);
                ComerFicha(Arreglo(p14, "columna"), color, p14);
                ComerFicha(Arreglo(p14, "positiva"), color, p14);
                ComerFicha(Arreglo(p14, "negativa"), color, p14);

                Get_Score(p14);
                Get_Move(p14, color);
            }
        }

        protected void Q14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q14.CssClass == vacio)
            {
                ComerFicha(Arreglo(q14, "fila"), color, q14);
                ComerFicha(Arreglo(q14, "columna"), color, q14);
                ComerFicha(Arreglo(q14, "positiva"), color, q14);
                ComerFicha(Arreglo(q14, "negativa"), color, q14);

                Get_Score(q14);
                Get_Move(q14, color);
            }
        }

        protected void R14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r14.CssClass == vacio)
            {
                ComerFicha(Arreglo(r14, "fila"), color, r14);
                ComerFicha(Arreglo(r14, "columna"), color, r14);
                ComerFicha(Arreglo(r14, "positiva"), color, r14);
                ComerFicha(Arreglo(r14, "negativa"), color, r14);

                Get_Score(r14);
                Get_Move(r14, color);
            }
        }

        protected void S14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s14.CssClass == vacio)
            {
                ComerFicha(Arreglo(s14, "fila"), color, s14);
                ComerFicha(Arreglo(s14, "columna"), color, s14);
                ComerFicha(Arreglo(s14, "positiva"), color, s14);
                ComerFicha(Arreglo(s14, "negativa"), color, s14);

                Get_Score(s14);
                Get_Move(s14, color);
            }
        }

        protected void T14_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t14.CssClass == vacio)
            {
                ComerFicha(Arreglo(t14, "fila"), color, t14);
                ComerFicha(Arreglo(t14, "columna"), color, t14);
                ComerFicha(Arreglo(t14, "positiva"), color, t14);
                ComerFicha(Arreglo(t14, "negativa"), color, t14);

                Get_Score(t14);
                Get_Move(t14, color);
            }
        }

        protected void A15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a15.CssClass == vacio)
            {
                ComerFicha(Arreglo(a15, "fila"), color, a15);
                ComerFicha(Arreglo(a15, "columna"), color, a15);
                ComerFicha(Arreglo(a15, "positiva"), color, a15);
                ComerFicha(Arreglo(a15, "negativa"), color, a15);

                Get_Score(a15);
                Get_Move(a15, color);
            }
        }

        protected void B15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b15.CssClass == vacio)
            {
                ComerFicha(Arreglo(b15, "fila"), color, b15);
                ComerFicha(Arreglo(b15, "columna"), color, b15);
                ComerFicha(Arreglo(b15, "positiva"), color, b15);
                ComerFicha(Arreglo(b15, "negativa"), color, b15);

                Get_Score(b15);
                Get_Move(b15, color);
            }
        }

        protected void C15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c15.CssClass == vacio)
            {
                ComerFicha(Arreglo(c15, "fila"), color, c15);
                ComerFicha(Arreglo(c15, "columna"), color, c15);
                ComerFicha(Arreglo(c15, "positiva"), color, c15);
                ComerFicha(Arreglo(c15, "negativa"), color, c15);

                Get_Score(c15);
                Get_Move(c15, color);
            }
        }

        protected void D15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d15.CssClass == vacio)
            {
                ComerFicha(Arreglo(d15, "fila"), color, d15);
                ComerFicha(Arreglo(d15, "columna"), color, d15);
                ComerFicha(Arreglo(d15, "positiva"), color, d15);
                ComerFicha(Arreglo(d15, "negativa"), color, d15);

                Get_Score(d15);
                Get_Move(d15, color);
            }
        }

        protected void E15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e15.CssClass == vacio)
            {
                ComerFicha(Arreglo(e15, "fila"), color, e15);
                ComerFicha(Arreglo(e15, "columna"), color, e15);
                ComerFicha(Arreglo(e15, "positiva"), color, e15);
                ComerFicha(Arreglo(e15, "negativa"), color, e15);

                Get_Score(e15);
                Get_Move(e15, color);
            }
        }

        protected void F15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f15.CssClass == vacio)
            {
                ComerFicha(Arreglo(f15, "fila"), color, f15);
                ComerFicha(Arreglo(f15, "columna"), color, f15);
                ComerFicha(Arreglo(f15, "positiva"), color, f15);
                ComerFicha(Arreglo(f15, "negativa"), color, f15);

                Get_Score(f15);
                Get_Move(f15, color);
            }
        }

        protected void G15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g15.CssClass == vacio)
            {
                ComerFicha(Arreglo(g15, "fila"), color, g15);
                ComerFicha(Arreglo(g15, "columna"), color, g15);
                ComerFicha(Arreglo(g15, "positiva"), color, g15);
                ComerFicha(Arreglo(g15, "negativa"), color, g15);

                Get_Score(g15);
                Get_Move(g15, color);
            }
        }

        protected void H15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h15.CssClass == vacio)
            {
                ComerFicha(Arreglo(h15, "fila"), color, h15);
                ComerFicha(Arreglo(h15, "columna"), color, h15);
                ComerFicha(Arreglo(h15, "positiva"), color, h15);
                ComerFicha(Arreglo(h15, "negativa"), color, h15);

                Get_Score(h15);
                Get_Move(h15, color);
            }
        }

        protected void I15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i15.CssClass == vacio)
            {
                ComerFicha(Arreglo(i15, "fila"), color, i15);
                ComerFicha(Arreglo(i15, "columna"), color, i15);
                ComerFicha(Arreglo(i15, "positiva"), color, i15);
                ComerFicha(Arreglo(i15, "negativa"), color, i15);

                Get_Score(i15);
                Get_Move(i15, color);
            }
        }

        protected void J15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j15.CssClass == vacio)
            {
                ComerFicha(Arreglo(j15, "fila"), color, j15);
                ComerFicha(Arreglo(j15, "columna"), color, j15);
                ComerFicha(Arreglo(j15, "positiva"), color, j15);
                ComerFicha(Arreglo(j15, "negativa"), color, j15);

                Get_Score(j15);
                Get_Move(j15, color);
            }
        }

        protected void K15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k15.CssClass == vacio)
            {
                ComerFicha(Arreglo(k15, "fila"), color, k15);
                ComerFicha(Arreglo(k15, "columna"), color, k15);
                ComerFicha(Arreglo(k15, "positiva"), color, k15);
                ComerFicha(Arreglo(k15, "negativa"), color, k15);

                Get_Score(k15);
                Get_Move(k15, color);
            }
        }

        protected void L15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l15.CssClass == vacio)
            {
                ComerFicha(Arreglo(l15, "fila"), color, l15);
                ComerFicha(Arreglo(l15, "columna"), color, l15);
                ComerFicha(Arreglo(l15, "positiva"), color, l15);
                ComerFicha(Arreglo(l15, "negativa"), color, l15);

                Get_Score(l15);
                Get_Move(l15, color);
            }
        }

        protected void M15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m15.CssClass == vacio)
            {
                ComerFicha(Arreglo(m15, "fila"), color, m15);
                ComerFicha(Arreglo(m15, "columna"), color, m15);
                ComerFicha(Arreglo(m15, "positiva"), color, m15);
                ComerFicha(Arreglo(m15, "negativa"), color, m15);

                Get_Score(m15);
                Get_Move(m15, color);
            }
        }

        protected void N15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n15.CssClass == vacio)
            {
                ComerFicha(Arreglo(n15, "fila"), color, n15);
                ComerFicha(Arreglo(n15, "columna"), color, n15);
                ComerFicha(Arreglo(n15, "positiva"), color, n15);
                ComerFicha(Arreglo(n15, "negativa"), color, n15);

                Get_Score(n15);
                Get_Move(n15, color);
            }
        }

        protected void O15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o15.CssClass == vacio)
            {
                ComerFicha(Arreglo(o15, "fila"), color, o15);
                ComerFicha(Arreglo(o15, "columna"), color, o15);
                ComerFicha(Arreglo(o15, "positiva"), color, o15);
                ComerFicha(Arreglo(o15, "negativa"), color, o15);

                Get_Score(o15);
                Get_Move(o15, color);
            }
        }

        protected void P15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p15.CssClass == vacio)
            {
                ComerFicha(Arreglo(p15, "fila"), color, p15);
                ComerFicha(Arreglo(p15, "columna"), color, p15);
                ComerFicha(Arreglo(p15, "positiva"), color, p15);
                ComerFicha(Arreglo(p15, "negativa"), color, p15);

                Get_Score(p15);
                Get_Move(p15, color);
            }
        }

        protected void Q15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q15.CssClass == vacio)
            {
                ComerFicha(Arreglo(q15, "fila"), color, q15);
                ComerFicha(Arreglo(q15, "columna"), color, q15);
                ComerFicha(Arreglo(q15, "positiva"), color, q15);
                ComerFicha(Arreglo(q15, "negativa"), color, q15);

                Get_Score(q15);
                Get_Move(q15, color);
            }
        }

        protected void R15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r15.CssClass == vacio)
            {
                ComerFicha(Arreglo(r15, "fila"), color, r15);
                ComerFicha(Arreglo(r15, "columna"), color, r15);
                ComerFicha(Arreglo(r15, "positiva"), color, r15);
                ComerFicha(Arreglo(r15, "negativa"), color, r15);

                Get_Score(r15);
                Get_Move(r15, color);
            }
        }

        protected void S15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s15.CssClass == vacio)
            {
                ComerFicha(Arreglo(s15, "fila"), color, s15);
                ComerFicha(Arreglo(s15, "columna"), color, s15);
                ComerFicha(Arreglo(s15, "positiva"), color, s15);
                ComerFicha(Arreglo(s15, "negativa"), color, s15);

                Get_Score(s15);
                Get_Move(s15, color);
            }
        }

        protected void T15_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t15.CssClass == vacio)
            {
                ComerFicha(Arreglo(t15, "fila"), color, t15);
                ComerFicha(Arreglo(t15, "columna"), color, t15);
                ComerFicha(Arreglo(t15, "positiva"), color, t15);
                ComerFicha(Arreglo(t15, "negativa"), color, t15);

                Get_Score(t15);
                Get_Move(t15, color);
            }
        }

        protected void A16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a16.CssClass == vacio)
            {
                ComerFicha(Arreglo(a16, "fila"), color, a16);
                ComerFicha(Arreglo(a16, "columna"), color, a16);
                ComerFicha(Arreglo(a16, "positiva"), color, a16);
                ComerFicha(Arreglo(a16, "negativa"), color, a16);

                Get_Score(a16);
                Get_Move(a16, color);
            }
        }

        protected void B16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b16.CssClass == vacio)
            {
                ComerFicha(Arreglo(b16, "fila"), color, b16);
                ComerFicha(Arreglo(b16, "columna"), color, b16);
                ComerFicha(Arreglo(b16, "positiva"), color, b16);
                ComerFicha(Arreglo(b16, "negativa"), color, b16);

                Get_Score(b16);
                Get_Move(b16, color);
            }
        }

        protected void C16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c16.CssClass == vacio)
            {
                ComerFicha(Arreglo(c16, "fila"), color, c16);
                ComerFicha(Arreglo(c16, "columna"), color, c16);
                ComerFicha(Arreglo(c16, "positiva"), color, c16);
                ComerFicha(Arreglo(c16, "negativa"), color, c16);

                Get_Score(c16);
                Get_Move(c16, color);
            }
        }

        protected void D16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d16.CssClass == vacio)
            {
                ComerFicha(Arreglo(d16, "fila"), color, d16);
                ComerFicha(Arreglo(d16, "columna"), color, d16);
                ComerFicha(Arreglo(d16, "positiva"), color, d16);
                ComerFicha(Arreglo(d16, "negativa"), color, d16);

                Get_Score(d16);
                Get_Move(d16, color);
            }
        }

        protected void E16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e16.CssClass == vacio)
            {
                ComerFicha(Arreglo(e16, "fila"), color, e16);
                ComerFicha(Arreglo(e16, "columna"), color, e16);
                ComerFicha(Arreglo(e16, "positiva"), color, e16);
                ComerFicha(Arreglo(e16, "negativa"), color, e16);

                Get_Score(e16);
                Get_Move(e16, color);
            }
        }

        protected void F16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f16.CssClass == vacio)
            {
                ComerFicha(Arreglo(f16, "fila"), color, f16);
                ComerFicha(Arreglo(f16, "columna"), color, f16);
                ComerFicha(Arreglo(f16, "positiva"), color, f16);
                ComerFicha(Arreglo(f16, "negativa"), color, f16);

                Get_Score(f16);
                Get_Move(f16, color);
            }
        }

        protected void G16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g16.CssClass == vacio)
            {
                ComerFicha(Arreglo(g16, "fila"), color, g16);
                ComerFicha(Arreglo(g16, "columna"), color, g16);
                ComerFicha(Arreglo(g16, "positiva"), color, g16);
                ComerFicha(Arreglo(g16, "negativa"), color, g16);

                Get_Score(g16);
                Get_Move(g16, color);
            }
        }

        protected void H16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h16.CssClass == vacio)
            {
                ComerFicha(Arreglo(h16, "fila"), color, h16);
                ComerFicha(Arreglo(h16, "columna"), color, h16);
                ComerFicha(Arreglo(h16, "positiva"), color, h16);
                ComerFicha(Arreglo(h16, "negativa"), color, h16);

                Get_Score(h16);
                Get_Move(h16, color);
            }
        }

        protected void I16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i16.CssClass == vacio)
            {
                ComerFicha(Arreglo(i16, "fila"), color, i16);
                ComerFicha(Arreglo(i16, "columna"), color, i16);
                ComerFicha(Arreglo(i16, "positiva"), color, i16);
                ComerFicha(Arreglo(i16, "negativa"), color, i16);

                Get_Score(i16);
                Get_Move(i16, color);
            }
        }

        protected void J16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j16.CssClass == vacio)
            {
                ComerFicha(Arreglo(j16, "fila"), color, j16);
                ComerFicha(Arreglo(j16, "columna"), color, j16);
                ComerFicha(Arreglo(j16, "positiva"), color, j16);
                ComerFicha(Arreglo(j16, "negativa"), color, j16);

                Get_Score(j16);
                Get_Move(j16, color);
            }
        }

        protected void K16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k16.CssClass == vacio)
            {
                ComerFicha(Arreglo(k16, "fila"), color, k16);
                ComerFicha(Arreglo(k16, "columna"), color, k16);
                ComerFicha(Arreglo(k16, "positiva"), color, k16);
                ComerFicha(Arreglo(k16, "negativa"), color, k16);

                Get_Score(k16);
                Get_Move(k16, color);
            }
        }

        protected void L16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l16.CssClass == vacio)
            {
                ComerFicha(Arreglo(l16, "fila"), color, l16);
                ComerFicha(Arreglo(l16, "columna"), color, l16);
                ComerFicha(Arreglo(l16, "positiva"), color, l16);
                ComerFicha(Arreglo(l16, "negativa"), color, l16);

                Get_Score(l16);
                Get_Move(l16, color);
            }
        }

        protected void M16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m16.CssClass == vacio)
            {
                ComerFicha(Arreglo(m16, "fila"), color, m16);
                ComerFicha(Arreglo(m16, "columna"), color, m16);
                ComerFicha(Arreglo(m16, "positiva"), color, m16);
                ComerFicha(Arreglo(m16, "negativa"), color, m16);

                Get_Score(m16);
                Get_Move(m16, color);
            }
        }

        protected void N16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n16.CssClass == vacio)
            {
                ComerFicha(Arreglo(n16, "fila"), color, n16);
                ComerFicha(Arreglo(n16, "columna"), color, n16);
                ComerFicha(Arreglo(n16, "positiva"), color, n16);
                ComerFicha(Arreglo(n16, "negativa"), color, n16);

                Get_Score(n16);
                Get_Move(n16, color);
            }
        }

        protected void O16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o16.CssClass == vacio)
            {
                ComerFicha(Arreglo(o16, "fila"), color, o16);
                ComerFicha(Arreglo(o16, "columna"), color, o16);
                ComerFicha(Arreglo(o16, "positiva"), color, o16);
                ComerFicha(Arreglo(o16, "negativa"), color, o16);

                Get_Score(o16);
                Get_Move(o16, color);
            }
        }

        protected void P16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p16.CssClass == vacio)
            {
                ComerFicha(Arreglo(p16, "fila"), color, p16);
                ComerFicha(Arreglo(p16, "columna"), color, p16);
                ComerFicha(Arreglo(p16, "positiva"), color, p16);
                ComerFicha(Arreglo(p16, "negativa"), color, p16);

                Get_Score(p16);
                Get_Move(p16, color);
            }
        }

        protected void Q16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q16.CssClass == vacio)
            {
                ComerFicha(Arreglo(q16, "fila"), color, q16);
                ComerFicha(Arreglo(q16, "columna"), color, q16);
                ComerFicha(Arreglo(q16, "positiva"), color, q16);
                ComerFicha(Arreglo(q16, "negativa"), color, q16);

                Get_Score(q16);
                Get_Move(q16, color);
            }
        }

        protected void R16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r16.CssClass == vacio)
            {
                ComerFicha(Arreglo(r16, "fila"), color, r16);
                ComerFicha(Arreglo(r16, "columna"), color, r16);
                ComerFicha(Arreglo(r16, "positiva"), color, r16);
                ComerFicha(Arreglo(r16, "negativa"), color, r16);

                Get_Score(r16);
                Get_Move(r16, color);
            }
        }

        protected void S16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s16.CssClass == vacio)
            {
                ComerFicha(Arreglo(s16, "fila"), color, s16);
                ComerFicha(Arreglo(s16, "columna"), color, s16);
                ComerFicha(Arreglo(s16, "positiva"), color, s16);
                ComerFicha(Arreglo(s16, "negativa"), color, s16);

                Get_Score(s16);
                Get_Move(s16, color);
            }
        }

        protected void T16_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t16.CssClass == vacio)
            {
                ComerFicha(Arreglo(t16, "fila"), color, t16);
                ComerFicha(Arreglo(t16, "columna"), color, t16);
                ComerFicha(Arreglo(t16, "positiva"), color, t16);
                ComerFicha(Arreglo(t16, "negativa"), color, t16);

                Get_Score(t16);
                Get_Move(t16, color);
            }
        }

        protected void A17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a17.CssClass == vacio)
            {
                ComerFicha(Arreglo(a17, "fila"), color, a17);
                ComerFicha(Arreglo(a17, "columna"), color, a17);
                ComerFicha(Arreglo(a17, "positiva"), color, a17);
                ComerFicha(Arreglo(a17, "negativa"), color, a17);

                Get_Score(a17);
                Get_Move(a17, color);
            }
        }

        protected void B17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b17.CssClass == vacio)
            {
                ComerFicha(Arreglo(b17, "fila"), color, b17);
                ComerFicha(Arreglo(b17, "columna"), color, b17);
                ComerFicha(Arreglo(b17, "positiva"), color, b17);
                ComerFicha(Arreglo(b17, "negativa"), color, b17);

                Get_Score(b17);
                Get_Move(b17, color);
            }
        }

        protected void C17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c17.CssClass == vacio)
            {
                ComerFicha(Arreglo(c17, "fila"), color, c17);
                ComerFicha(Arreglo(c17, "columna"), color, c17);
                ComerFicha(Arreglo(c17, "positiva"), color, c17);
                ComerFicha(Arreglo(c17, "negativa"), color, c17);

                Get_Score(c17);
                Get_Move(c17, color);
            }
        }

        protected void D17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d17.CssClass == vacio)
            {
                ComerFicha(Arreglo(d17, "fila"), color, d17);
                ComerFicha(Arreglo(d17, "columna"), color, d17);
                ComerFicha(Arreglo(d17, "positiva"), color, d17);
                ComerFicha(Arreglo(d17, "negativa"), color, d17);

                Get_Score(d17);
                Get_Move(d17, color);
            }
        }

        protected void E17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e17.CssClass == vacio)
            {
                ComerFicha(Arreglo(e17, "fila"), color, e17);
                ComerFicha(Arreglo(e17, "columna"), color, e17);
                ComerFicha(Arreglo(e17, "positiva"), color, e17);
                ComerFicha(Arreglo(e17, "negativa"), color, e17);

                Get_Score(e17);
                Get_Move(e17, color);
            }
        }

        protected void F17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f17.CssClass == vacio)
            {
                ComerFicha(Arreglo(f17, "fila"), color, f17);
                ComerFicha(Arreglo(f17, "columna"), color, f17);
                ComerFicha(Arreglo(f17, "positiva"), color, f17);
                ComerFicha(Arreglo(f17, "negativa"), color, f17);

                Get_Score(f17);
                Get_Move(f17, color);
            }
        }

        protected void G17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g17.CssClass == vacio)
            {
                ComerFicha(Arreglo(g17, "fila"), color, g17);
                ComerFicha(Arreglo(g17, "columna"), color, g17);
                ComerFicha(Arreglo(g17, "positiva"), color, g17);
                ComerFicha(Arreglo(g17, "negativa"), color, g17);

                Get_Score(g17);
                Get_Move(g17, color);
            }
        }

        protected void H17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h17.CssClass == vacio)
            {
                ComerFicha(Arreglo(h17, "fila"), color, h17);
                ComerFicha(Arreglo(h17, "columna"), color, h17);
                ComerFicha(Arreglo(h17, "positiva"), color, h17);
                ComerFicha(Arreglo(h17, "negativa"), color, h17);

                Get_Score(h17);
                Get_Move(h17, color);
            }
        }

        protected void I17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i17.CssClass == vacio)
            {
                ComerFicha(Arreglo(i17, "fila"), color, i17);
                ComerFicha(Arreglo(i17, "columna"), color, i17);
                ComerFicha(Arreglo(i17, "positiva"), color, i17);
                ComerFicha(Arreglo(i17, "negativa"), color, i17);

                Get_Score(i17);
                Get_Move(i17, color);
            }
        }

        protected void J17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j17.CssClass == vacio)
            {
                ComerFicha(Arreglo(j17, "fila"), color, j17);
                ComerFicha(Arreglo(j17, "columna"), color, j17);
                ComerFicha(Arreglo(j17, "positiva"), color, j17);
                ComerFicha(Arreglo(j17, "negativa"), color, j17);

                Get_Score(j17);
                Get_Move(j17, color);
            }
        }

        protected void K17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k17.CssClass == vacio)
            {
                ComerFicha(Arreglo(k17, "fila"), color, k17);
                ComerFicha(Arreglo(k17, "columna"), color, k17);
                ComerFicha(Arreglo(k17, "positiva"), color, k17);
                ComerFicha(Arreglo(k17, "negativa"), color, k17);

                Get_Score(k17);
                Get_Move(k17, color);
            }
        }

        protected void L17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l17.CssClass == vacio)
            {
                ComerFicha(Arreglo(l17, "fila"), color, l17);
                ComerFicha(Arreglo(l17, "columna"), color, l17);
                ComerFicha(Arreglo(l17, "positiva"), color, l17);
                ComerFicha(Arreglo(l17, "negativa"), color, l17);

                Get_Score(l17);
                Get_Move(l17, color);
            }
        }

        protected void M17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m17.CssClass == vacio)
            {
                ComerFicha(Arreglo(m17, "fila"), color, m17);
                ComerFicha(Arreglo(m17, "columna"), color, m17);
                ComerFicha(Arreglo(m17, "positiva"), color, m17);
                ComerFicha(Arreglo(m17, "negativa"), color, m17);

                Get_Score(m17);
                Get_Move(m17, color);
            }
        }

        protected void N17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n17.CssClass == vacio)
            {
                ComerFicha(Arreglo(n17, "fila"), color, n17);
                ComerFicha(Arreglo(n17, "columna"), color, n17);
                ComerFicha(Arreglo(n17, "positiva"), color, n17);
                ComerFicha(Arreglo(n17, "negativa"), color, n17);

                Get_Score(n17);
                Get_Move(n17, color);
            }
        }

        protected void O17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o17.CssClass == vacio)
            {
                ComerFicha(Arreglo(o17, "fila"), color, o17);
                ComerFicha(Arreglo(o17, "columna"), color, o17);
                ComerFicha(Arreglo(o17, "positiva"), color, o17);
                ComerFicha(Arreglo(o17, "negativa"), color, o17);

                Get_Score(o17);
                Get_Move(o17, color);
            }
        }

        protected void P17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p17.CssClass == vacio)
            {
                ComerFicha(Arreglo(p17, "fila"), color, p17);
                ComerFicha(Arreglo(p17, "columna"), color, p17);
                ComerFicha(Arreglo(p17, "positiva"), color, p17);
                ComerFicha(Arreglo(p17, "negativa"), color, p17);

                Get_Score(p17);
                Get_Move(p17, color);
            }
        }

        protected void Q17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q17.CssClass == vacio)
            {
                ComerFicha(Arreglo(q17, "fila"), color, q17);
                ComerFicha(Arreglo(q17, "columna"), color, q17);
                ComerFicha(Arreglo(q17, "positiva"), color, q17);
                ComerFicha(Arreglo(q17, "negativa"), color, q17);

                Get_Score(q17);
                Get_Move(q17, color);
            }
        }

        protected void R17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r17.CssClass == vacio)
            {
                ComerFicha(Arreglo(r17, "fila"), color, r17);
                ComerFicha(Arreglo(r17, "columna"), color, r17);
                ComerFicha(Arreglo(r17, "positiva"), color, r17);
                ComerFicha(Arreglo(r17, "negativa"), color, r17);

                Get_Score(r17);
                Get_Move(r17, color);
            }
        }

        protected void S17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s17.CssClass == vacio)
            {
                ComerFicha(Arreglo(s17, "fila"), color, s17);
                ComerFicha(Arreglo(s17, "columna"), color, s17);
                ComerFicha(Arreglo(s17, "positiva"), color, s17);
                ComerFicha(Arreglo(s17, "negativa"), color, s17);

                Get_Score(s17);
                Get_Move(s17, color);
            }
        }

        protected void T17_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t17.CssClass == vacio)
            {
                ComerFicha(Arreglo(t17, "fila"), color, t17);
                ComerFicha(Arreglo(t17, "columna"), color, t17);
                ComerFicha(Arreglo(t17, "positiva"), color, t17);
                ComerFicha(Arreglo(t17, "negativa"), color, t17);

                Get_Score(t17);
                Get_Move(t17, color);
            }
        }

        protected void A18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a18.CssClass == vacio)
            {
                ComerFicha(Arreglo(a18, "fila"), color, a18);
                ComerFicha(Arreglo(a18, "columna"), color, a18);
                ComerFicha(Arreglo(a18, "positiva"), color, a18);
                ComerFicha(Arreglo(a18, "negativa"), color, a18);

                Get_Score(a18);
                Get_Move(a18, color);
            }
        }

        protected void B18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b18.CssClass == vacio)
            {
                ComerFicha(Arreglo(b18, "fila"), color, b18);
                ComerFicha(Arreglo(b18, "columna"), color, b18);
                ComerFicha(Arreglo(b18, "positiva"), color, b18);
                ComerFicha(Arreglo(b18, "negativa"), color, b18);

                Get_Score(b18);
                Get_Move(b18, color);
            }
        }

        protected void C18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c18.CssClass == vacio)
            {
                ComerFicha(Arreglo(c18, "fila"), color, c18);
                ComerFicha(Arreglo(c18, "columna"), color, c18);
                ComerFicha(Arreglo(c18, "positiva"), color, c18);
                ComerFicha(Arreglo(c18, "negativa"), color, c18);

                Get_Score(c18);
                Get_Move(c18, color);
            }
        }

        protected void D18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d18.CssClass == vacio)
            {
                ComerFicha(Arreglo(d18, "fila"), color, d18);
                ComerFicha(Arreglo(d18, "columna"), color, d18);
                ComerFicha(Arreglo(d18, "positiva"), color, d18);
                ComerFicha(Arreglo(d18, "negativa"), color, d18);

                Get_Score(d18);
                Get_Move(d18, color);
            }
        }

        protected void E18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e18.CssClass == vacio)
            {
                ComerFicha(Arreglo(e18, "fila"), color, e18);
                ComerFicha(Arreglo(e18, "columna"), color, e18);
                ComerFicha(Arreglo(e18, "positiva"), color, e18);
                ComerFicha(Arreglo(e18, "negativa"), color, e18);

                Get_Score(e18);
                Get_Move(e18, color);
            }
        }

        protected void F18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f18.CssClass == vacio)
            {
                ComerFicha(Arreglo(f18, "fila"), color, f18);
                ComerFicha(Arreglo(f18, "columna"), color, f18);
                ComerFicha(Arreglo(f18, "positiva"), color, f18);
                ComerFicha(Arreglo(f18, "negativa"), color, f18);

                Get_Score(f18);
                Get_Move(f18, color);
            }
        }

        protected void G18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g18.CssClass == vacio)
            {
                ComerFicha(Arreglo(g18, "fila"), color, g18);
                ComerFicha(Arreglo(g18, "columna"), color, g18);
                ComerFicha(Arreglo(g18, "positiva"), color, g18);
                ComerFicha(Arreglo(g18, "negativa"), color, g18);

                Get_Score(g18);
                Get_Move(g18, color);
            }
        }

        protected void H18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h18.CssClass == vacio)
            {
                ComerFicha(Arreglo(h18, "fila"), color, h18);
                ComerFicha(Arreglo(h18, "columna"), color, h18);
                ComerFicha(Arreglo(h18, "positiva"), color, h18);
                ComerFicha(Arreglo(h18, "negativa"), color, h18);

                Get_Score(h18);
                Get_Move(h18, color);
            }
        }

        protected void I18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i18.CssClass == vacio)
            {
                ComerFicha(Arreglo(i18, "fila"), color, i18);
                ComerFicha(Arreglo(i18, "columna"), color, i18);
                ComerFicha(Arreglo(i18, "positiva"), color, i18);
                ComerFicha(Arreglo(i18, "negativa"), color, i18);

                Get_Score(i18);
                Get_Move(i18, color);
            }
        }

        protected void J18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j18.CssClass == vacio)
            {
                ComerFicha(Arreglo(j18, "fila"), color, j18);
                ComerFicha(Arreglo(j18, "columna"), color, j18);
                ComerFicha(Arreglo(j18, "positiva"), color, j18);
                ComerFicha(Arreglo(j18, "negativa"), color, j18);

                Get_Score(j18);
                Get_Move(j18, color);
            }
        }

        protected void K18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k18.CssClass == vacio)
            {
                ComerFicha(Arreglo(k18, "fila"), color, k18);
                ComerFicha(Arreglo(k18, "columna"), color, k18);
                ComerFicha(Arreglo(k18, "positiva"), color, k18);
                ComerFicha(Arreglo(k18, "negativa"), color, k18);

                Get_Score(k18);
                Get_Move(k18, color);
            }
        }

        protected void L18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l18.CssClass == vacio)
            {
                ComerFicha(Arreglo(l18, "fila"), color, l18);
                ComerFicha(Arreglo(l18, "columna"), color, l18);
                ComerFicha(Arreglo(l18, "positiva"), color, l18);
                ComerFicha(Arreglo(l18, "negativa"), color, l18);

                Get_Score(l18);
                Get_Move(l18, color);
            }
        }

        protected void M18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m18.CssClass == vacio)
            {
                ComerFicha(Arreglo(m18, "fila"), color, m18);
                ComerFicha(Arreglo(m18, "columna"), color, m18);
                ComerFicha(Arreglo(m18, "positiva"), color, m18);
                ComerFicha(Arreglo(m18, "negativa"), color, m18);

                Get_Score(m18);
                Get_Move(m18, color);
            }
        }

        protected void N18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n18.CssClass == vacio)
            {
                ComerFicha(Arreglo(n18, "fila"), color, n18);
                ComerFicha(Arreglo(n18, "columna"), color, n18);
                ComerFicha(Arreglo(n18, "positiva"), color, n18);
                ComerFicha(Arreglo(n18, "negativa"), color, n18);

                Get_Score(n18);
                Get_Move(n18, color);
            }
        }

        protected void O18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o18.CssClass == vacio)
            {
                ComerFicha(Arreglo(o18, "fila"), color, o18);
                ComerFicha(Arreglo(o18, "columna"), color, o18);
                ComerFicha(Arreglo(o18, "positiva"), color, o18);
                ComerFicha(Arreglo(o18, "negativa"), color, o18);

                Get_Score(o18);
                Get_Move(o18, color);
            }
        }

        protected void P18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p18.CssClass == vacio)
            {
                ComerFicha(Arreglo(p18, "fila"), color, p18);
                ComerFicha(Arreglo(p18, "columna"), color, p18);
                ComerFicha(Arreglo(p18, "positiva"), color, p18);
                ComerFicha(Arreglo(p18, "negativa"), color, p18);

                Get_Score(p18);
                Get_Move(p18, color);
            }
        }

        protected void Q18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q18.CssClass == vacio)
            {
                ComerFicha(Arreglo(q18, "fila"), color, q18);
                ComerFicha(Arreglo(q18, "columna"), color, q18);
                ComerFicha(Arreglo(q18, "positiva"), color, q18);
                ComerFicha(Arreglo(q18, "negativa"), color, q18);

                Get_Score(q18);
                Get_Move(q18, color);
            }
        }

        protected void R18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r18.CssClass == vacio)
            {
                ComerFicha(Arreglo(r18, "fila"), color, r18);
                ComerFicha(Arreglo(r18, "columna"), color, r18);
                ComerFicha(Arreglo(r18, "positiva"), color, r18);
                ComerFicha(Arreglo(r18, "negativa"), color, r18);

                Get_Score(r18);
                Get_Move(r18, color);
            }
        }

        protected void S18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s18.CssClass == vacio)
            {
                ComerFicha(Arreglo(s18, "fila"), color, s18);
                ComerFicha(Arreglo(s18, "columna"), color, s18);
                ComerFicha(Arreglo(s18, "positiva"), color, s18);
                ComerFicha(Arreglo(s18, "negativa"), color, s18);

                Get_Score(s18);
                Get_Move(s18, color);
            }
        }

        protected void T18_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t18.CssClass == vacio)
            {
                ComerFicha(Arreglo(t18, "fila"), color, t18);
                ComerFicha(Arreglo(t18, "columna"), color, t18);
                ComerFicha(Arreglo(t18, "positiva"), color, t18);
                ComerFicha(Arreglo(t18, "negativa"), color, t18);

                Get_Score(t18);
                Get_Move(t18, color);
            }
        }

        protected void A19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a19.CssClass == vacio)
            {
                ComerFicha(Arreglo(a19, "fila"), color, a19);
                ComerFicha(Arreglo(a19, "columna"), color, a19);
                ComerFicha(Arreglo(a19, "positiva"), color, a19);
                ComerFicha(Arreglo(a19, "negativa"), color, a19);

                Get_Score(a19);
                Get_Move(a19, color);
            }
        }

        protected void B19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b19.CssClass == vacio)
            {
                ComerFicha(Arreglo(b19, "fila"), color, b19);
                ComerFicha(Arreglo(b19, "columna"), color, b19);
                ComerFicha(Arreglo(b19, "positiva"), color, b19);
                ComerFicha(Arreglo(b19, "negativa"), color, b19);

                Get_Score(b19);
                Get_Move(b19, color);
            }
        }

        protected void C19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c19.CssClass == vacio)
            {
                ComerFicha(Arreglo(c19, "fila"), color, c19);
                ComerFicha(Arreglo(c19, "columna"), color, c19);
                ComerFicha(Arreglo(c19, "positiva"), color, c19);
                ComerFicha(Arreglo(c19, "negativa"), color, c19);

                Get_Score(c19);
                Get_Move(c19, color);
            }
        }

        protected void D19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d19.CssClass == vacio)
            {
                ComerFicha(Arreglo(d19, "fila"), color, d19);
                ComerFicha(Arreglo(d19, "columna"), color, d19);
                ComerFicha(Arreglo(d19, "positiva"), color, d19);
                ComerFicha(Arreglo(d19, "negativa"), color, d19);

                Get_Score(d19);
                Get_Move(d19, color);
            }
        }

        protected void E19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e19.CssClass == vacio)
            {
                ComerFicha(Arreglo(e19, "fila"), color, e19);
                ComerFicha(Arreglo(e19, "columna"), color, e19);
                ComerFicha(Arreglo(e19, "positiva"), color, e19);
                ComerFicha(Arreglo(e19, "negativa"), color, e19);

                Get_Score(e19);
                Get_Move(e19, color);
            }
        }

        protected void F19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f19.CssClass == vacio)
            {
                ComerFicha(Arreglo(f19, "fila"), color, f19);
                ComerFicha(Arreglo(f19, "columna"), color, f19);
                ComerFicha(Arreglo(f19, "positiva"), color, f19);
                ComerFicha(Arreglo(f19, "negativa"), color, f19);

                Get_Score(f19);
                Get_Move(f19, color);
            }
        }

        protected void G19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g19.CssClass == vacio)
            {
                ComerFicha(Arreglo(g19, "fila"), color, g19);
                ComerFicha(Arreglo(g19, "columna"), color, g19);
                ComerFicha(Arreglo(g19, "positiva"), color, g19);
                ComerFicha(Arreglo(g19, "negativa"), color, g19);

                Get_Score(g19);
                Get_Move(g19, color);
            }
        }

        protected void H19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h19.CssClass == vacio)
            {
                ComerFicha(Arreglo(h19, "fila"), color, h19);
                ComerFicha(Arreglo(h19, "columna"), color, h19);
                ComerFicha(Arreglo(h19, "positiva"), color, h19);
                ComerFicha(Arreglo(h19, "negativa"), color, h19);

                Get_Score(h19);
                Get_Move(h19, color);
            }
        }

        protected void I19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i19.CssClass == vacio)
            {
                ComerFicha(Arreglo(i19, "fila"), color, i19);
                ComerFicha(Arreglo(i19, "columna"), color, i19);
                ComerFicha(Arreglo(i19, "positiva"), color, i19);
                ComerFicha(Arreglo(i19, "negativa"), color, i19);

                Get_Score(i19);
                Get_Move(i19, color);
            }
        }

        protected void J19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j19.CssClass == vacio)
            {
                ComerFicha(Arreglo(j19, "fila"), color, j19);
                ComerFicha(Arreglo(j19, "columna"), color, j19);
                ComerFicha(Arreglo(j19, "positiva"), color, j19);
                ComerFicha(Arreglo(j19, "negativa"), color, j19);

                Get_Score(j19);
                Get_Move(j19, color);
            }
        }

        protected void K19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k19.CssClass == vacio)
            {
                ComerFicha(Arreglo(k19, "fila"), color, k19);
                ComerFicha(Arreglo(k19, "columna"), color, k19);
                ComerFicha(Arreglo(k19, "positiva"), color, k19);
                ComerFicha(Arreglo(k19, "negativa"), color, k19);

                Get_Score(k19);
                Get_Move(k19, color);
            }
        }

        protected void L19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l19.CssClass == vacio)
            {
                ComerFicha(Arreglo(l19, "fila"), color, l19);
                ComerFicha(Arreglo(l19, "columna"), color, l19);
                ComerFicha(Arreglo(l19, "positiva"), color, l19);
                ComerFicha(Arreglo(l19, "negativa"), color, l19);

                Get_Score(l19);
                Get_Move(l19, color);
            }
        }

        protected void M19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m19.CssClass == vacio)
            {
                ComerFicha(Arreglo(m19, "fila"), color, m19);
                ComerFicha(Arreglo(m19, "columna"), color, m19);
                ComerFicha(Arreglo(m19, "positiva"), color, m19);
                ComerFicha(Arreglo(m19, "negativa"), color, m19);

                Get_Score(m19);
                Get_Move(m19, color);
            }
        }

        protected void N19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n19.CssClass == vacio)
            {
                ComerFicha(Arreglo(n19, "fila"), color, n19);
                ComerFicha(Arreglo(n19, "columna"), color, n19);
                ComerFicha(Arreglo(n19, "positiva"), color, n19);
                ComerFicha(Arreglo(n19, "negativa"), color, n19);

                Get_Score(n19);
                Get_Move(n19, color);
            }
        }

        protected void O19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o19.CssClass == vacio)
            {
                ComerFicha(Arreglo(o19, "fila"), color, o19);
                ComerFicha(Arreglo(o19, "columna"), color, o19);
                ComerFicha(Arreglo(o19, "positiva"), color, o19);
                ComerFicha(Arreglo(o19, "negativa"), color, o19);

                Get_Score(o19);
                Get_Move(o19, color);
            }
        }

        protected void P19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p19.CssClass == vacio)
            {
                ComerFicha(Arreglo(p19, "fila"), color, p19);
                ComerFicha(Arreglo(p19, "columna"), color, p19);
                ComerFicha(Arreglo(p19, "positiva"), color, p19);
                ComerFicha(Arreglo(p19, "negativa"), color, p19);

                Get_Score(p19);
                Get_Move(p19, color);
            }
        }

        protected void Q19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q19.CssClass == vacio)
            {
                ComerFicha(Arreglo(q19, "fila"), color, q19);
                ComerFicha(Arreglo(q19, "columna"), color, q19);
                ComerFicha(Arreglo(q19, "positiva"), color, q19);
                ComerFicha(Arreglo(q19, "negativa"), color, q19);

                Get_Score(q19);
                Get_Move(q19, color);
            }
        }

        protected void R19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r19.CssClass == vacio)
            {
                ComerFicha(Arreglo(r19, "fila"), color, r19);
                ComerFicha(Arreglo(r19, "columna"), color, r19);
                ComerFicha(Arreglo(r19, "positiva"), color, r19);
                ComerFicha(Arreglo(r19, "negativa"), color, r19);

                Get_Score(r19);
                Get_Move(r19, color);
            }
        }

        protected void S19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s19.CssClass == vacio)
            {
                ComerFicha(Arreglo(s19, "fila"), color, s19);
                ComerFicha(Arreglo(s19, "columna"), color, s19);
                ComerFicha(Arreglo(s19, "positiva"), color, s19);
                ComerFicha(Arreglo(s19, "negativa"), color, s19);

                Get_Score(s19);
                Get_Move(s19, color);
            }
        }

        protected void T19_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t19.CssClass == vacio)
            {
                ComerFicha(Arreglo(t19, "fila"), color, t19);
                ComerFicha(Arreglo(t19, "columna"), color, t19);
                ComerFicha(Arreglo(t19, "positiva"), color, t19);
                ComerFicha(Arreglo(t19, "negativa"), color, t19);

                Get_Score(t19);
                Get_Move(t19, color);
            }
        }

        protected void A20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (a20.CssClass == vacio)
            {
                ComerFicha(Arreglo(a20, "fila"), color, a20);
                ComerFicha(Arreglo(a20, "columna"), color, a20);
                ComerFicha(Arreglo(a20, "positiva"), color, a20);
                ComerFicha(Arreglo(a20, "negativa"), color, a20);

                Get_Score(a20);
                Get_Move(a20, color);
            }
        }

        protected void B20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (b20.CssClass == vacio)
            {
                ComerFicha(Arreglo(b20, "fila"), color, b20);
                ComerFicha(Arreglo(b20, "columna"), color, b20);
                ComerFicha(Arreglo(b20, "positiva"), color, b20);
                ComerFicha(Arreglo(b20, "negativa"), color, b20);

                Get_Score(b20);
                Get_Move(b20, color);
            }
        }

        protected void C20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (c20.CssClass == vacio)
            {
                ComerFicha(Arreglo(c20, "fila"), color, c20);
                ComerFicha(Arreglo(c20, "columna"), color, c20);
                ComerFicha(Arreglo(c20, "positiva"), color, c20);
                ComerFicha(Arreglo(c20, "negativa"), color, c20);

                Get_Score(c20);
                Get_Move(c20, color);
            }
        }

        protected void D20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (d20.CssClass == vacio)
            {
                ComerFicha(Arreglo(d20, "fila"), color, d20);
                ComerFicha(Arreglo(d20, "columna"), color, d20);
                ComerFicha(Arreglo(d20, "positiva"), color, d20);
                ComerFicha(Arreglo(d20, "negativa"), color, d20);

                Get_Score(d20);
                Get_Move(d20, color);
            }
        }

        protected void E20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (e20.CssClass == vacio)
            {
                ComerFicha(Arreglo(e20, "fila"), color, e20);
                ComerFicha(Arreglo(e20, "columna"), color, e20);
                ComerFicha(Arreglo(e20, "positiva"), color, e20);
                ComerFicha(Arreglo(e20, "negativa"), color, e20);

                Get_Score(e20);
                Get_Move(e20, color);
            }
        }

        protected void F20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (f20.CssClass == vacio)
            {
                ComerFicha(Arreglo(f20, "fila"), color, f20);
                ComerFicha(Arreglo(f20, "columna"), color, f20);
                ComerFicha(Arreglo(f20, "positiva"), color, f20);
                ComerFicha(Arreglo(f20, "negativa"), color, f20);

                Get_Score(f20);
                Get_Move(f20, color);
            }
        }

        protected void G20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (g20.CssClass == vacio)
            {
                ComerFicha(Arreglo(g20, "fila"), color, g20);
                ComerFicha(Arreglo(g20, "columna"), color, g20);
                ComerFicha(Arreglo(g20, "positiva"), color, g20);
                ComerFicha(Arreglo(g20, "negativa"), color, g20);

                Get_Score(g20);
                Get_Move(g20, color);
            }
        }

        protected void H20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (h20.CssClass == vacio)
            {
                ComerFicha(Arreglo(h20, "fila"), color, h20);
                ComerFicha(Arreglo(h20, "columna"), color, h20);
                ComerFicha(Arreglo(h20, "positiva"), color, h20);
                ComerFicha(Arreglo(h20, "negativa"), color, h20);

                Get_Score(h20);
                Get_Move(h20, color);
            }
        }

        protected void I20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (i20.CssClass == vacio)
            {
                ComerFicha(Arreglo(i20, "fila"), color, i20);
                ComerFicha(Arreglo(i20, "columna"), color, i20);
                ComerFicha(Arreglo(i20, "positiva"), color, i20);
                ComerFicha(Arreglo(i20, "negativa"), color, i20);

                Get_Score(i20);
                Get_Move(i20, color);
            }
        }

        protected void J20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (j20.CssClass == vacio)
            {
                ComerFicha(Arreglo(j20, "fila"), color, j20);
                ComerFicha(Arreglo(j20, "columna"), color, j20);
                ComerFicha(Arreglo(j20, "positiva"), color, j20);
                ComerFicha(Arreglo(j20, "negativa"), color, j20);

                Get_Score(j20);
                Get_Move(j20, color);
            }
        }

        protected void K20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (k20.CssClass == vacio)
            {
                ComerFicha(Arreglo(k20, "fila"), color, k20);
                ComerFicha(Arreglo(k20, "columna"), color, k20);
                ComerFicha(Arreglo(k20, "positiva"), color, k20);
                ComerFicha(Arreglo(k20, "negativa"), color, k20);

                Get_Score(k20);
                Get_Move(k20, color);
            }
        }

        protected void L20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (l20.CssClass == vacio)
            {
                ComerFicha(Arreglo(l20, "fila"), color, l20);
                ComerFicha(Arreglo(l20, "columna"), color, l20);
                ComerFicha(Arreglo(l20, "positiva"), color, l20);
                ComerFicha(Arreglo(l20, "negativa"), color, l20);

                Get_Score(l20);
                Get_Move(l20, color);
            }
        }

        protected void M20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (m20.CssClass == vacio)
            {
                ComerFicha(Arreglo(m20, "fila"), color, m20);
                ComerFicha(Arreglo(m20, "columna"), color, m20);
                ComerFicha(Arreglo(m20, "positiva"), color, m20);
                ComerFicha(Arreglo(m20, "negativa"), color, m20);

                Get_Score(m20);
                Get_Move(m20, color);
            }
        }

        protected void N20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (n20.CssClass == vacio)
            {
                ComerFicha(Arreglo(n20, "fila"), color, n20);
                ComerFicha(Arreglo(n20, "columna"), color, n20);
                ComerFicha(Arreglo(n20, "positiva"), color, n20);
                ComerFicha(Arreglo(n20, "negativa"), color, n20);

                Get_Score(n20);
                Get_Move(n20, color);
            }
        }

        protected void O20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (o20.CssClass == vacio)
            {
                ComerFicha(Arreglo(o20, "fila"), color, o20);
                ComerFicha(Arreglo(o20, "columna"), color, o20);
                ComerFicha(Arreglo(o20, "positiva"), color, o20);
                ComerFicha(Arreglo(o20, "negativa"), color, o20);

                Get_Score(o20);
                Get_Move(o20, color);
            }
        }

        protected void P20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (p20.CssClass == vacio)
            {
                ComerFicha(Arreglo(p20, "fila"), color, p20);
                ComerFicha(Arreglo(p20, "columna"), color, p20);
                ComerFicha(Arreglo(p20, "positiva"), color, p20);
                ComerFicha(Arreglo(p20, "negativa"), color, p20);

                Get_Score(p20);
                Get_Move(p20, color);
            }
        }

        protected void Q20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (q20.CssClass == vacio)
            {
                ComerFicha(Arreglo(q20, "fila"), color, q20);
                ComerFicha(Arreglo(q20, "columna"), color, q20);
                ComerFicha(Arreglo(q20, "positiva"), color, q20);
                ComerFicha(Arreglo(q20, "negativa"), color, q20);

                Get_Score(q20);
                Get_Move(q20, color);
            }
        }

        protected void R20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (r20.CssClass == vacio)
            {
                ComerFicha(Arreglo(r20, "fila"), color, r20);
                ComerFicha(Arreglo(r20, "columna"), color, r20);
                ComerFicha(Arreglo(r20, "positiva"), color, r20);
                ComerFicha(Arreglo(r20, "negativa"), color, r20);

                Get_Score(r20);
                Get_Move(r20, color);
            }
        }

        protected void S20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (s20.CssClass == vacio)
            {
                ComerFicha(Arreglo(s20, "fila"), color, s20);
                ComerFicha(Arreglo(s20, "columna"), color, s20);
                ComerFicha(Arreglo(s20, "positiva"), color, s20);
                ComerFicha(Arreglo(s20, "negativa"), color, s20);

                Get_Score(s20);
                Get_Move(s20, color);
            }
        }

        protected void T20_Click(object sender, EventArgs e)
        {
            string color = turno.Text;
            if (t20.CssClass == vacio)
            {
                ComerFicha(Arreglo(t20, "fila"), color, t20);
                ComerFicha(Arreglo(t20, "columna"), color, t20);
                ComerFicha(Arreglo(t20, "positiva"), color, t20);
                ComerFicha(Arreglo(t20, "negativa"), color, t20);

                Get_Score(t20);
                Get_Move(t20, color);
            }
        }
    }
}