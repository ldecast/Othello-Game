using NHibernate.Cfg.XmlHbmBinding;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Othello
{
    public partial class OthelloTournament : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Crear_equipos();

        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            RadioButtonList1.ClearSelection();
        }

        public void Crear_equipos()
        {
            if (Session["archivo"] != null)
            {
                string ruta = Convert.ToString(Session["archivo"]);
                XmlDocument reader = new XmlDocument();
                reader.Load(ruta);

                XmlNodeList name = reader.GetElementsByTagName("nombre");
                if (name.Count > 0) 
                {
                    titulo.Text = name[0].InnerText;
                }


                XmlNodeList equipos = reader.GetElementsByTagName("equipo");

                Registrar_Torneo(name[0].InnerText, equipos.Count);

                if (equipos.Count == 16)
                {
                    ListItem[] octavosfinal = { octavo1, octavo2, octavo3, octavo4, octavo5, octavo6, octavo7, octavo8, octavo9, octavo10, octavo11, octavo12, octavo13, octavo14, octavo15, octavo16 };
                    octavosPanel.Visible = true;

                    XmlNodeList equiposOctavos = reader.GetElementsByTagName("nombreEquipo");
                    for (int i = 0; i < equiposOctavos.Count; i++)
                    {
                        octavosfinal[i].Text = equiposOctavos[i].InnerText;
                        Registrar_Equipo(equiposOctavos[i].InnerText);
                    }

                }

                if (equipos.Count == 8)
                {
                    ListItem[] cuartosfinal = { cuartos1, cuartos2, cuartos3, cuartos4, cuartos5, cuartos6, cuartos7, cuartos8 };
                    cuartosPanel.Visible = true;

                    XmlNodeList equiposCuartos = reader.GetElementsByTagName("nombreEquipo");
                    for (int i = 0; i < equiposCuartos.Count; i++)
                    {
                        cuartosfinal[i].Text = equiposCuartos[i].InnerText;
                        Registrar_Equipo(equiposCuartos[i].InnerText);
                    }
                }

                if (equipos.Count == 4)
                {
                    ListItem[] semifinal = { semi1, semi2, semi3, semi4 };
                    semiPanel.Visible = true;

                    XmlNodeList equiposSemi = reader.GetElementsByTagName("nombreEquipo");
                    for (int i = 0; i < equiposSemi.Count; i++)
                    {
                        semifinal[i].Text = equiposSemi[i].InnerText;
                        Registrar_Equipo(equiposSemi[i].InnerText);
                    }
                }
                Registrar_Jugador();
            }
        }


        protected void Octavos_Click(object sender, EventArgs e)
        {
            List<string> ganadores = new List<string>();
            List<string> empatados = new List<string>();

            var oc1 = from ListItem oc in CheckBoxList1.Items
                      where oc.Selected == true
                      select oc;
            var oc2 = from ListItem oc in CheckBoxList2.Items
                      where oc.Selected == true
                      select oc;
            var oc3 = from ListItem oc in CheckBoxList3.Items
                      where oc.Selected == true
                      select oc;
            var oc4 = from ListItem oc in CheckBoxList4.Items
                      where oc.Selected == true
                      select oc;
            var oc5 = from ListItem oc in CheckBoxList5.Items
                      where oc.Selected == true
                      select oc;
            var oc6 = from ListItem oc in CheckBoxList6.Items
                      where oc.Selected == true
                      select oc;
            var oc7 = from ListItem oc in CheckBoxList7.Items
                      where oc.Selected == true
                      select oc;
            var oc8 = from ListItem oc in CheckBoxList8.Items
                      where oc.Selected == true
                      select oc;


            if (oc1.Count() == 1)
            {
                ganadores.Add(oc1.ToList()[0].Text);
                Registrar_Ronda(CheckBoxList1.Items[0].Text, CheckBoxList1.Items[1].Text, oc1.ToList()[0].Text, "Octavos");
            }
            if (oc2.Count() == 1)
            {
                ganadores.Add(oc2.ToList()[0].Text);
                Registrar_Ronda(CheckBoxList2.Items[0].Text, CheckBoxList2.Items[1].Text, oc2.ToList()[0].Text, "Octavos");
            }
            if (oc3.Count() == 1)
            {
                ganadores.Add(oc3.ToList()[0].Text);
                Registrar_Ronda(CheckBoxList3.Items[0].Text, CheckBoxList3.Items[1].Text, oc3.ToList()[0].Text, "Octavos");
            }
            if (oc4.Count() == 1)
            {
                ganadores.Add(oc4.ToList()[0].Text);
                Registrar_Ronda(CheckBoxList4.Items[0].Text, CheckBoxList4.Items[1].Text, oc4.ToList()[0].Text, "Octavos");
            }
            if (oc5.Count() == 1)
            {
                ganadores.Add(oc5.ToList()[0].Text);
                Registrar_Ronda(CheckBoxList5.Items[0].Text, CheckBoxList5.Items[1].Text, oc5.ToList()[0].Text, "Octavos");
            }
            if (oc6.Count() == 1)
            {
                ganadores.Add(oc6.ToList()[0].Text);
                Registrar_Ronda(CheckBoxList6.Items[0].Text, CheckBoxList6.Items[1].Text, oc6.ToList()[0].Text, "Octavos");
            }
            if (oc7.Count() == 1)
            {
                ganadores.Add(oc7.ToList()[0].Text);
                Registrar_Ronda(CheckBoxList7.Items[0].Text, CheckBoxList7.Items[1].Text, oc7.ToList()[0].Text, "Octavos");
            }
            if (oc8.Count() == 1)
            {
                ganadores.Add(oc8.ToList()[0].Text);
                Registrar_Ronda(CheckBoxList8.Items[0].Text, CheckBoxList8.Items[1].Text, oc8.ToList()[0].Text, "Octavos");
            }


            if (oc1.Count() == 2)
            {
                empatados.Add(oc1.ToList()[0].Text);
                empatados.Add(oc1.ToList()[1].Text);
                Registrar_Empate(oc1.ToList()[0].Text, oc1.ToList()[1].Text, "Octavos");
            }
            if (oc2.Count() == 2)
            {
                empatados.Add(oc2.ToList()[0].Text);
                empatados.Add(oc2.ToList()[1].Text);
                Registrar_Empate(oc2.ToList()[0].Text, oc2.ToList()[1].Text, "Octavos");
            }
            if (oc3.Count() == 2)
            {
                empatados.Add(oc3.ToList()[0].Text);
                empatados.Add(oc3.ToList()[1].Text);
                Registrar_Empate(oc3.ToList()[0].Text, oc3.ToList()[1].Text, "Octavos");
            }
            if (oc4.Count() == 2)
            {
                empatados.Add(oc4.ToList()[0].Text);
                empatados.Add(oc4.ToList()[1].Text);
                Registrar_Empate(oc4.ToList()[0].Text, oc4.ToList()[1].Text, "Octavos");
            }
            if (oc5.Count() == 2)
            {
                empatados.Add(oc5.ToList()[0].Text);
                empatados.Add(oc5.ToList()[1].Text);
                Registrar_Empate(oc5.ToList()[0].Text, oc5.ToList()[1].Text, "Octavos");
            }
            if (oc6.Count() == 2)
            {
                empatados.Add(oc6.ToList()[0].Text);
                empatados.Add(oc6.ToList()[1].Text);
                Registrar_Empate(oc6.ToList()[0].Text, oc6.ToList()[1].Text, "Octavos");
            }
            if (oc7.Count() == 2)
            {
                empatados.Add(oc7.ToList()[0].Text);
                empatados.Add(oc7.ToList()[1].Text);
                Registrar_Empate(oc7.ToList()[0].Text, oc7.ToList()[1].Text, "Octavos");
            }
            if (oc8.Count() == 2)
            {
                empatados.Add(oc8.ToList()[0].Text);
                empatados.Add(oc8.ToList()[1].Text);
                Registrar_Empate(oc8.ToList()[0].Text, oc8.ToList()[1].Text, "Octavos");
            }


            if (ganadores.Count == 8)
            {
                octavosPanel.Visible = false;
                AvanzarCuartos(ganadores);
            }

            if (empatados.Count >= 2)
            {
                octavosPanel.Visible = false;
                auxCount.Value = (empatados.Count / 2).ToString();
                Desempate("Octavos", empatados, Leer_jugadores(empatados), ganadores);
            }
        }

        public void Cuartos_Click(object sender, EventArgs e)
        {
            List<string> ganadores = new List<string>();
            List<string> empatados = new List<string>();

            var oc1 = from ListItem cuarto in CheckBoxList9.Items
                      where cuarto.Selected == true
                      select cuarto;
            var oc2 = from ListItem cuarto in CheckBoxList10.Items
                      where cuarto.Selected == true
                      select cuarto;
            var oc3 = from ListItem cuarto in CheckBoxList11.Items
                      where cuarto.Selected == true
                      select cuarto;
            var oc4 = from ListItem cuarto in CheckBoxList12.Items
                      where cuarto.Selected == true
                      select cuarto;
            

            if (oc1.Count() == 1)
            {
                ganadores.Add(oc1.ToList()[0].Text);
                Registrar_Ronda(CheckBoxList9.Items[0].Text, CheckBoxList9.Items[1].Text, oc1.ToList()[0].Text, "Cuartos");
            }
            if (oc2.Count() == 1)
            {
                ganadores.Add(oc2.ToList()[0].Text);
                Registrar_Ronda(CheckBoxList10.Items[0].Text, CheckBoxList10.Items[1].Text, oc2.ToList()[0].Text, "Cuartos");
            }
            if (oc3.Count() == 1)
            {
                ganadores.Add(oc3.ToList()[0].Text);
                Registrar_Ronda(CheckBoxList11.Items[0].Text, CheckBoxList11.Items[1].Text, oc3.ToList()[0].Text, "Cuartos");
            }
            if (oc4.Count() == 1)
            {
                ganadores.Add(oc4.ToList()[0].Text);
                Registrar_Ronda(CheckBoxList12.Items[0].Text, CheckBoxList12.Items[1].Text, oc4.ToList()[0].Text, "Cuartos");
            }


            if (oc1.Count() == 2)
            {
                empatados.Add(oc1.ToList()[0].Text);
                empatados.Add(oc1.ToList()[1].Text);
                Registrar_Empate(oc1.ToList()[0].Text, oc1.ToList()[1].Text, "Cuartos");
            }
            if (oc2.Count() == 2)
            {
                empatados.Add(oc2.ToList()[0].Text);
                empatados.Add(oc2.ToList()[1].Text);
                Registrar_Empate(oc2.ToList()[0].Text, oc2.ToList()[1].Text, "Cuartos");
            }
            if (oc3.Count() == 2)
            {
                empatados.Add(oc3.ToList()[0].Text);
                empatados.Add(oc3.ToList()[1].Text);
                Registrar_Empate(oc3.ToList()[0].Text, oc3.ToList()[1].Text, "Cuartos");
            }
            if (oc4.Count() == 2)
            {
                empatados.Add(oc4.ToList()[0].Text);
                empatados.Add(oc4.ToList()[1].Text);
                Registrar_Empate(oc4.ToList()[0].Text, oc4.ToList()[1].Text, "Cuartos");
            }


            if (ganadores.Count == 4)
            {
                cuartosPanel.Visible = false;
                AvanzarSemi(ganadores);
            }

            if (empatados.Count >= 2)
            {
                cuartosPanel.Visible = false;
                auxCount.Value = (empatados.Count / 2).ToString();
                Desempate("Cuartos", empatados, Leer_jugadores(empatados), ganadores);
            }
        }


        public void Semi_Click(object sender, EventArgs e)
        {
            List<string> ganadores = new List<string>();
            List<string> empatados = new List<string>();

            var oc1 = from ListItem sem in CheckBoxList13.Items
                      where sem.Selected == true
                      select sem;
            var oc2 = from ListItem sem in CheckBoxList14.Items
                      where sem.Selected == true
                      select sem;


            if (oc1.Count() == 1)
            {
                ganadores.Add(oc1.ToList()[0].Text);
                Registrar_Ronda(CheckBoxList13.Items[0].Text, CheckBoxList13.Items[1].Text, oc1.ToList()[0].Text, "Semi");
            }
            if (oc2.Count() == 1)
            {
                ganadores.Add(oc2.ToList()[0].Text);
                Registrar_Ronda(CheckBoxList14.Items[0].Text, CheckBoxList14.Items[1].Text, oc2.ToList()[0].Text, "Semi");
            }


            if (oc1.Count() == 2)
            {
                empatados.Add(oc1.ToList()[0].Text);
                empatados.Add(oc1.ToList()[1].Text);
                Registrar_Empate(oc1.ToList()[0].Text, oc1.ToList()[1].Text, "Semi");
            }
            if (oc2.Count() == 2)
            {
                empatados.Add(oc2.ToList()[0].Text);
                empatados.Add(oc2.ToList()[1].Text);
                Registrar_Empate(oc2.ToList()[0].Text, oc2.ToList()[1].Text, "Semi");
            }


            if (ganadores.Count == 2)
            {
                semiPanel.Visible = false;
                AvanzarFinal(ganadores);
            }

            if (empatados.Count >= 2)
            {
                semiPanel.Visible = false;
                auxCount.Value = (empatados.Count / 2).ToString();
                Desempate("Semi", empatados, Leer_jugadores(empatados),ganadores);
            }
        }


        public void Final_Click(object sender, EventArgs e)
        {
            List<string> ganadores = new List<string>();
            List<string> empatados = new List<string>();

            var oc1 = from ListItem fin in CheckBoxList15.Items
                      where fin.Selected == true
                      select fin;

            if (oc1.Count() == 1)
            {
                ganadores.Add(oc1.ToList()[0].Text);
                Registrar_Ronda(CheckBoxList15.Items[0].Text, CheckBoxList15.Items[1].Text, oc1.ToList()[0].Text, "Final");
            }

            if (oc1.Count() == 2)
            {
                empatados.Add(oc1.ToList()[0].Text);
                empatados.Add(oc1.ToList()[1].Text);
                Registrar_Empate(oc1.ToList()[0].Text, oc1.ToList()[1].Text, "Final");
            }

            if (ganadores.Count == 1)
            {
                finalPanel.Visible = false;
                Display_Winner(ganadores[0]);
            }

            if (empatados.Count >= 2)
            {
                finalPanel.Visible = false;
                auxCount.Value = (empatados.Count / 2).ToString();
                Desempate("Final", empatados, Leer_jugadores(empatados), ganadores);
            }
        }


        public void Display_Winner(string equipo)
        {
            winnerPanel.Visible = true;
            ganador.Text = equipo;
        }

        protected void Salir(object sender, EventArgs e)
        {
            if (Request.Params["Parametro"] != null)
            {
                string parametro = Request.Params["Parametro"];
                Response.Redirect("Menu.aspx?Parametro=" + parametro);
            }
            else Response.Redirect("Login.aspx");
        }

        public void Registrar_Torneo(string nombre, int cantidad)
        {
            if (Request.Params["Parametro"] != null)
            {
                string anfitrion = Request.Params["Parametro"];
                try
                {   //script de www.AspYa.com
                    string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                    SqlConnection conexion = new SqlConnection(a);
                    conexion.Open();

                    SqlCommand script = new SqlCommand("insert into Torneo(nombre,anfitrion,cantidadEquipos) values('" + nombre + "','" + anfitrion + "'," + cantidad + ")", conexion);
                    script.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Error interno: No se pudo guardar el nombre del torneo en la base de datos.\")", true);
                }
            }
        }


        public void Registrar_Equipo(string nombre)
        {
            try
            {   //script de www.AspYa.com
                string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                SqlConnection conexion = new SqlConnection(a);
                conexion.Open();
                SqlCommand script = new SqlCommand("insert into Equipo(nombreEquipo) values('" + nombre + "')", conexion);
                script.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Error interno: No se pudo registrar el equipo en la base de datos.\")", true);
            }
        }

        public void Registrar_Jugador()
        {
            if (Session["archivo"] != null)
            {
                try
                {   //script de www.AspYa.com
                    string nombreEquipo = "";

                    string ruta = Convert.ToString(Session["archivo"]);
                    XmlDocument reader = new XmlDocument();
                    reader.Load(ruta);

                    XmlNodeList equipo = reader.GetElementsByTagName("equipo");
                    for (int i = 0; i < equipo.Count; i++)
                    {
                        XmlNodeList players = equipo.Item(i).ChildNodes;

                        nombreEquipo = players[0].InnerText;

                        for (int j = 1; j < players.Count; j++)
                        {
                            string usuarios = players[j].InnerText;

                            string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                            SqlConnection conexion = new SqlConnection(a);
                            conexion.Open();

                            SqlCommand nuevo = new SqlCommand("insert into Usuario(username,contraseña) values('" + usuarios + "','')", conexion);
                            nuevo.ExecuteNonQuery();

                            SqlCommand script = new SqlCommand("insert into Jugador(usuario,equipo) values('" + usuarios + "','" + nombreEquipo + "')", conexion);
                            script.ExecuteNonQuery();
                            conexion.Close();
                        }
                    }
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Error interno: No se pudo registrar el jugador del equipo en la base de datos.\")", true);
                }
            }
        }

        public void Registrar_Ronda(string equipo1, string equipo2, string ganador, string tipo)
        {
            try
            {   //script de www.AspYa.com
                string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                SqlConnection conexion = new SqlConnection(a);
                conexion.Open();
                SqlCommand script = new SqlCommand("insert into RondaTorneo(campeonato,equipo1,equipo2,ganador,empate,puntos,ronda) values('" + titulo.Text + "','" +
                equipo1 + "','" + equipo2 + "','" + ganador + "',0,3,'" + tipo + "')", conexion);
                script.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Error interno: No se pudo registrar el resultado de la ronda en la base de datos.\")", true);
            }
        }

        public void Registrar_Empate(string equipo1, string equipo2, string tipo)
        {
            try
            {   //script de www.AspYa.com
                string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                SqlConnection conexion = new SqlConnection(a);
                conexion.Open();
                SqlCommand script = new SqlCommand("insert into RondaTorneo(campeonato,equipo1,equipo2,empate,puntos,ronda) values('" + titulo.Text + "','" +
                equipo1 + "','" + equipo2 + "',0,1,'" + tipo + "')", conexion);
                script.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Error interno: No se pudo registrar el resultado de la ronda en la base de datos.\")", true);
            }
        }


        //public List<string> Leer_jugadores(List<string> clasificados)
        //{
        //    List<string> ganadores = new List<string>();
        //    if (Session["archivo"] != null)
        //    {
        //        string ruta = Convert.ToString(Session["archivo"]);
        //        XmlDocument reader = new XmlDocument();
        //        reader.Load(ruta);

        //        XmlNodeList equipo = reader.GetElementsByTagName("equipo");
        //        for (int i = 0; i < equipo.Count; i++)
        //        {
        //            if (clasificados.Contains(equipo.Item(i).FirstChild.InnerText))
        //            {
        //                XmlNodeList players = equipo.Item(i).ChildNodes;
        //                for (int j = 1; j < players.Count; j++)
        //                {
        //                    ganadores.Add(players[j].InnerText);
        //                }
        //            }
        //        }
        //    }
        //    return ganadores;
        //}

        public List<string> Leer_jugadores(string team)
        {
            List<string> ganadores = new List<string>();
            if (Session["archivo"] != null)
            {
                string ruta = Convert.ToString(Session["archivo"]);
                XmlDocument reader = new XmlDocument();
                reader.Load(ruta);

                XmlNodeList equipo = reader.GetElementsByTagName("equipo");
                for (int i = 0; i < equipo.Count; i++)
                {
                    if (team == equipo.Item(i).FirstChild.InnerText)
                    {
                        XmlNodeList players = equipo.Item(i).ChildNodes;
                        for (int j = 1; j < players.Count; j++)
                        {
                            ganadores.Add(players[j].InnerText);
                        }
                    }
                }
            }
            return ganadores;
        }

        public string Leer_equipo(string seleccionado)
        {
            List<string> equipos = new List<string>();
            if (Session["archivo"] != null)
            {
                string ruta = Convert.ToString(Session["archivo"]);
                XmlDocument reader = new XmlDocument();
                reader.Load(ruta);

                XmlNodeList equipo = reader.GetElementsByTagName("equipo");
                for (int i = 0; i < equipo.Count; i++)
                {
                    for (int j = 0; j < equipo.Item(i).ChildNodes.Count; j++)
                    {
                        if (equipo.Item(i).ChildNodes.Item(j).InnerText == seleccionado) //quite el contains
                        {
                            XmlNodeList players = equipo.Item(i).ChildNodes;
                            equipos.Add(players[0].InnerText);
                        }
                    }
                    //if (equipo.Item(i).ChildNodes.Item(i).InnerText.Contains(seleccionado))
                    //{
                    //    XmlNodeList players = equipo.Item(i).ChildNodes;
                    //    equipos.Add(players[0].InnerText);
                    //}
                }
            }
            return equipos[0];
        }

        public void AvanzarCuartos(List<string> clasificados)
        {
            ListItem[] cuartosfinal = { cuartos1, cuartos2, cuartos3, cuartos4, cuartos5, cuartos6, cuartos7, cuartos8 };
            cuartosPanel.Visible = true;
            try
            {
                for (int i = 0; i < cuartosfinal.Length; i++)
                {
                    cuartosfinal[i].Text = clasificados[i];
                }
            }
            catch (Exception)
            {
                Response.Write(clasificados.Count+"hhh");
            }

            playersEmpates.Value = ""; equiposEmpates.Value = ""; auxCount.Value = ""; auxGanados.Value = "";
        }

        public void AvanzarSemi(List<string> clasificados)
        {
            ListItem[] semifinal = { semi1, semi2, semi3, semi4 };
            semiPanel.Visible = true;

            for (int i = 0; i < semifinal.Length; i++)
            {
                semifinal[i].Text = clasificados[i];
            }
            playersEmpates.Value = ""; equiposEmpates.Value = ""; auxCount.Value = ""; auxGanados.Value = "";
        }

        public void AvanzarFinal(List<string> clasificados)
        {
            ListItem[] final = { final1, final2 };
            finalPanel.Visible = true;

            for (int i = 0; i < final.Length; i++)
            {
                final[i].Text = clasificados[i];
            }
            playersEmpates.Value = ""; equiposEmpates.Value = ""; auxCount.Value = ""; auxGanados.Value = "";
        }

        public void Desempate(string tipo, List<string>equiposEmpatados, List<string> jugadoresEmpatados, List<string> equiposGanados)
        {
            //empates.Value = "";
            //equiposEmpates.Value = "";
            //auxGanados.Value = "";
            desempatePanel.Visible = true;
            LabelDesempate.Text = "Desempate " + tipo;

            ListItem[] radio = { empateJ1, empateJ2, empateJ3, empateJ4, empateJ5, empateJ6 };
            //List<string> auxJugadores = Leer_jugadores(equiposEmpatados);
            List<string> auxEquipos = new List<string>();
            for (int i = 0; i < jugadoresEmpatados.Count; i++)
            {
                auxEquipos.Add(Leer_equipo(jugadoresEmpatados[i]));
            }
            try
            {
                for (int i = 0; i < radio.Length; i++)
                {
                    radio[i].Text = jugadoresEmpatados[i];
                }
                //for (int i = 0; i < 6; i++)
                //{
                //    jugadoresEmpatados.RemoveAt(0);
                //}
                //for (int i = 0; i < 2; i++)
                //{
                //    equiposEmpatados.RemoveAt(0);
                //}
            }
            catch (Exception)
            {
                Response.Write(jugadoresEmpatados.Count+"mmmm");
            }


            if (jugadoresEmpatados.Count != 0)
            {
                playersEmpates.Value = "";
                //coloco en el value hidden los jugadores que me faltan poner en los radio button
                for (int i = 0; i < jugadoresEmpatados.Count; i++)//probar  //son los que me quedan pendientes
                {
                    //playersEmpates.Value = playersEmpates.Value + "," + jugadoresEmpatados[i];
                    playersEmpates.Value = playersEmpates.Value + "," + jugadoresEmpatados[i];
                }
                if (playersEmpates.Value.Length != 0)
                {
                    if (playersEmpates.Value[0] == ',')
                        playersEmpates.Value = playersEmpates.Value.Substring(1);
                    else if (playersEmpates.Value[playersEmpates.Value.Length - 1] == ',')
                        playersEmpates.Value = playersEmpates.Value.Substring(0, playersEmpates.Value.Length - 1);
                }


                if (equiposEmpates.Value == "")
                {
                    //equiposEmpates.Value = "";
                    //equiposEmpatados.RemoveAt(0);
                    //equiposEmpatados.RemoveAt(0);
                    for (int i = 0; i < auxEquipos.Count; i++)
                    {
                        equiposEmpates.Value = equiposEmpates.Value + "," + auxEquipos[i];
                    }
                    
                }
                else
                {
                    for (int i = 0; i < auxEquipos.Count; i++)
                    {
                        equiposEmpates.Value = equiposEmpates.Value + "," + auxEquipos[i];
                    }
                }
                if (equiposEmpates.Value[0] == ',')
                {
                    equiposEmpates.Value = equiposEmpates.Value.Substring(1);
                }
            }

            if (equiposGanados.Count > 0)//(auxGanados.Value == "" && equiposGanados.Count>0)
            {
                auxGanados.Value = "";
                for (int i = 0; i < equiposGanados.Count; i++)
                {
                    auxGanados.Value = auxGanados.Value + "," + equiposGanados[i];
                }
                if (auxGanados.Value[0] == ',')
                {
                    auxGanados.Value = auxGanados.Value.Substring(1);

                }
            }
            //else if(auxGanados.Value !="")
            //{
            //    auxGanados.Value = auxGanados.Value + "," + equiposGanados.Last();
            //}


            //if (equiposEmpates.Value == "")
            //{
            //    for (int i = 0; i < equiposEmpatados.Count; i++)
            //    {
            //        equiposEmpates.Value = equiposEmpates.Value + "," + equiposEmpatados[i];
            //    }
            //    equiposEmpates.Value = equiposEmpates.Value.Substring(1);
            //}
            //else
            //{
            //    equiposEmpates.Value = equiposEmpates.Value + "," + equiposEmpatados.Last();
            //}

        }

        protected void Desempate_Click(object sender, EventArgs e)
        {


            auxCount.Value = (int.Parse(auxCount.Value) - 1).ToString();
            string seleccionado = RadioButtonList1.SelectedValue;
            Registrar_Ronda(Leer_equipo(empateJ1.Text), Leer_equipo(empateJ4.Text), Leer_equipo(seleccionado), LabelDesempate.Text); //leer j2.text


            if (auxGanados.Value == "")
            {
                auxGanados.Value = Leer_equipo(seleccionado);
            }
            else
            {
                auxGanados.Value = auxGanados.Value + "," + Leer_equipo(seleccionado);
            }

            List<string> ganadores = auxGanados.Value.Split(',').ToList();
            //ganadores.Add(Leer_equipo(seleccionado));

            string tipo = LabelDesempate.Text.Replace("Desempate ", "");
            if (seleccionado != "" && int.Parse(auxCount.Value) > -0)
            {

                List<string> newEquiposEmpate = equiposEmpates.Value.Split(',').ToList();
                //List<string> newEquiposEmpate2 = new List<string>();
                //newEquiposEmpate2.Add(Leer_equipo(empateJ1.Text));
                //newEquiposEmpate2.Add(Leer_equipo(empateJ4.Text));
                //List<string> newGanados = auxGanados.Value.Split(',').ToList();

                if (playersEmpates.Value != "")
                {
                    List<string> newEmpate = playersEmpates.Value.Split(',').ToList();
                    try
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            newEquiposEmpate.RemoveAt(0);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        newEmpate.RemoveAt(0);
                    }

                    Response.Write(newEquiposEmpate.Count + "ggg");
                    Desempate(tipo, newEquiposEmpate, newEmpate, ganadores);
                }

                else
                {
                    desempatePanel.Visible = false;
                    if (tipo == "Octavos")
                    {
                        AvanzarCuartos(auxGanados.Value.Split(',').ToList());
                    }
                    if (tipo == "Cuartos")
                    {
                        AvanzarSemi(auxGanados.Value.Split(',').ToList());
                    }
                    if (tipo == "Semi")
                    {
                        AvanzarFinal(auxGanados.Value.Split(',').ToList());
                    }
                    if (tipo == "Final")
                    {
                        Display_Winner(Leer_equipo(seleccionado));
                    }
                    desempatePanel.Visible = false;
                }

                if (equiposEmpates.Value != "")
                {

                    List<string> equiposAux = equiposEmpates.Value.Split(',').ToList();
                    try
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            equiposAux.RemoveAt(0);
                        }
                    }
                    catch (Exception)
                    {
                    }


                    for (int i = 0; i < equiposAux.Count; i++)
                    {
                        equiposEmpates.Value = "," + equiposAux[i];//+,
                    }
                    if (equiposEmpates.Value.Last() == ',')
                    {
                        equiposEmpates.Value = equiposEmpates.Value.Substring(0, equiposEmpates.Value.Length - 1);
                    }
                    if (equiposEmpates.Value[0] == ',')
                    {
                        equiposEmpates.Value = equiposEmpates.Value.Substring(1);
                    }
                }

                //string equipo1 = Leer_equipo(empateJ2.Text);
                //string equipo2 = Leer_equipo(empateJ5.Text);
                ////Response.Write(equipo2);

            }
            else if(seleccionado=="")
            {
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Debe seleccionar un jugador para poder avanzar.\")", true);
            }
            else
            {
                if (tipo == "Octavos")
                {
                    AvanzarCuartos(auxGanados.Value.Split(',').ToList());
                }
                if (tipo == "Cuartos")
                {
                    AvanzarSemi(auxGanados.Value.Split(',').ToList());
                }
                if (tipo == "Semi")
                {
                    AvanzarFinal(auxGanados.Value.Split(',').ToList());
                }
                if (tipo == "Final")
                {
                    Display_Winner(Leer_equipo(seleccionado));
                }
                desempatePanel.Visible = false;
            }
        }

    }
}