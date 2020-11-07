using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Othello
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["Parametro"] != null)
            {
                string user = Request.Params["Parametro"];
                usuario.Text = user;
            }
        }

        public void Cerrar_sesion(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        public void Ver_perfil(object sender, EventArgs e)
        {
            Session["usuario"] = usuario.Text;
            Response.Redirect("Profile.aspx?User=" + usuario.Text);
        }

        public void Redireccionar1(object sender, EventArgs e)
        {
            if (upload.HasFile)
            {
                //Session["archivo"] = ""+upload.FileName;
                upload.SaveAs(Server.MapPath(".") + "\\XML\\" + upload.FileName);
                string ruta = Server.MapPath(".") + "\\XML\\" + upload.FileName;

                Session["archivo"] = ruta;
                Response.Redirect("OthelloLoaded.aspx?Parametro=" + usuario.Text+"-Blanco");
            }
            else
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Error: por favor seleccione un archivo\")", true);
        }

        public void Redireccionar2(object sender, EventArgs e)
        {
            if (upload.HasFile)
            {
                upload.SaveAs(Server.MapPath(".") + "\\XML\\" + upload.FileName);
                string ruta = Server.MapPath(".") + "\\XML\\" + upload.FileName;
                Session["archivo"] = ruta;
                Response.Redirect("OthelloLoaded.aspx?Parametro=" + usuario.Text + "-Negro");
            }
            else
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Error: por favor seleccione un archivo\")", true);
        }

        public void Redireccionar3(object sender, EventArgs e)
        {
            if (upload.HasFile)
            {
                upload.SaveAs(Server.MapPath(".") + "\\XML\\" + upload.FileName);
                string ruta = Server.MapPath(".") + "\\XML\\" + upload.FileName;
                Session["archivo"] = ruta;
                Response.Redirect("LoadedOnePlayer.aspx?Parametro=" + usuario.Text + "-Blanco");
            }
            else
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Error: por favor seleccione un archivo\")", true);
        }

        public void Redireccionar4(object sender, EventArgs e)
        {
            if (upload.HasFile)
            {
                upload.SaveAs(Server.MapPath(".") + "\\XML\\" + upload.FileName);
                string ruta = Server.MapPath(".") + "\\XML\\" + upload.FileName;
                Session["archivo"] = ruta;
                Response.Redirect("LoadedOnePlayer.aspx?Parametro=" + usuario.Text + "-Negro");
            }
            else
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Error: por favor seleccione un archivo\")", true);
        }

        public void Redireccionar5(object sender, EventArgs e)
        {
            if (upload.HasFile)
            {
                upload.SaveAs(Server.MapPath(".") + "\\XML\\" + upload.FileName);
                string ruta = Server.MapPath(".") + "\\XML\\" + upload.FileName;

                if (File.ReadAllText(ruta).Contains("<Modalidad>Normal</Modalidad>"))
                {
                    Session["archivo"] = ruta;
                    Session["modalidad"] = "normal";
                    Session["coloresUsuario"] = "Negro";
                    Session["coloresPlayer2"] = "Blanco";
                    Response.Redirect("OthelloXtream.aspx?Parametro=Loaded-" + usuario.Text);
                }

                else if (File.ReadAllText(ruta).Contains("<Modalidad>Inversa</Modalidad>"))
                {
                    Session["archivo"] = ruta;
                    Session["modalidad"] = "inversa";
                    Session["coloresUsuario"] = "Negro";
                    Session["coloresPlayer2"] = "Blanco";
                    Response.Redirect("OthelloXtream.aspx?Parametro=Loaded-" + usuario.Text);
                }
                else Response.Write("No se reconoce la modalidad de la partida. Por favor corrija el archivo de entrada.");
            }
            else
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Error: por favor seleccione un archivo\")", true);
        }

        public void Redireccionar6(object sender, EventArgs e)
        {
            if (uploadTorneo.HasFile)
            {
                uploadTorneo.SaveAs(Server.MapPath(".") + "\\XML\\" + uploadTorneo.FileName);
                string ruta = Server.MapPath(".") + "\\XML\\" + uploadTorneo.FileName;
                Session["archivo"] = ruta;
                Response.Redirect("OthelloTournament.aspx?Parametro=" + usuario.Text);
            }
            else
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Error: por favor seleccione un archivo\")", true);
        }

        protected void NewGame_Click_White(object sender, EventArgs e)
        {
            Response.Redirect("GameBoard.aspx?Parametro=" + usuario.Text+"-Blanco");
        }
        protected void NewGame_Click_Black(object sender, EventArgs e)
        {
            Response.Redirect("GameBoard.aspx?Parametro=" + usuario.Text + "-Negro");
        }

        protected void NewGame_Alone_White(object sender, EventArgs e)
        {
            Response.Redirect("GameOnePlayer.aspx?Parametro=" + usuario.Text + "-Blanco");
        }
        protected void NewGame_Alone_Black(object sender, EventArgs e)
        {
            Response.Redirect("GameOnePlayer.aspx?Parametro=" + usuario.Text + "-Negro");
        }

        protected void CargarElegir1(object sender, EventArgs e)
        {
            cargar1.Visible = false;
            cargar2.Visible = false;
            Panel3.Visible = false;
            Panel1.Visible = true;
            Label3.Text = "Color para " + usuario.Text;
            upload.Visible = true;
        }

        protected void CargarElegir2(object sender, EventArgs e)
        {
            cargar1.Visible = false;
            cargar2.Visible = false;
            Panel2.Visible = true;
            Label3.Text = "Color para " + usuario.Text;
            upload.Visible = true;
        }

        protected void CargarElegir3(object sender, EventArgs e)
        {
            cargar1.Visible = false;
            cargar2.Visible = false;
            Panel3.Visible = true;
            upload.Visible = true;
        }

        protected void ChooseColor1(object sender, EventArgs e)
        {
            newGame.Visible = false;
            juegoSolo.Visible = false;
            selectColor.Visible = true;
            juegoNuevo.Text = "Color para " + usuario.Text;
        }

        protected void ChooseColor2(object sender, EventArgs e)
        {
            newGame.Visible = false;
            juegoSolo.Visible = false;
            selectColor2.Visible = true;
            juegoNuevo.Text = "Color para " + usuario.Text;
        }

        protected void ChooseMod(object sender, EventArgs e)
        {
            xtream.Visible = false;
            torneo.Visible = false;
            selectMod.Visible = true;
            tmod.Text = "Seleccione modalidad";
        }

        protected void ChooseColor3(object sender, EventArgs e)
        {
            selectMod.Visible = false;
            selectColor3.Visible = true;
            tmod.Text = "Colores para " + usuario.Text;
            tmod.CssClass = "h5 h5mod";
            btnNormal.Visible = true;
        }

        protected void ChooseColor4(object sender, EventArgs e)
        {
            selectMod.Visible = false;
            selectColor3.Visible = true;
            tmod.Text = "Colores para " + usuario.Text;
            tmod.CssClass = "h5 h5mod";
            btnInverso.Visible = true;
        }

        public void Subir_torneo(object sender, EventArgs e)
        {
            xtream.Visible = false;
            torneo.Visible = false;
            loadTorneo.Visible = true;
            tmod.Text = "Torneo nuevo";
        }

        public void Xtream_Normal(object sender, EventArgs e)
        {
            string apertura;
            if (modoApertura.Checked)
                apertura = "true";
            else
                apertura = "false";

            if (!SelectedIndexChanged())
            {
                Session["coloresUsuario"] = ColoresUsuario();
                Session["coloresPlayer2"] = ColoresPlayer2();
                Session["modalidad"] = "normal";
                Session["apertura"] = apertura;
                Response.Redirect("OthelloXtream.aspx?Parametro=New-" + usuario.Text);
            }
        }

        protected void Xtream_Inverso(object sender, EventArgs e)
        {
            string apertura;
            if (modoApertura.Checked)
                apertura = "true";
            else
                apertura = "false";

            if (!SelectedIndexChanged())
            {
                Session["coloresUsuario"] = ColoresUsuario();
                Session["coloresPlayer2"] = ColoresPlayer2();
                Session["modalidad"] = "inversa";
                Session["apertura"] = apertura;
                Response.Redirect("OthelloXtream.aspx?Parametro=New-" + usuario.Text);
            }
        }

        protected string ColoresUsuario()
        {
            var items1 = from ListItem li in UserColors.Items
                         where li.Selected == true
                         select li;

            String[] colores1 = new String[items1.Count()];
            for (int i = 0; i < items1.Count(); i++)
            {
                colores1[i] = items1.ToList()[i].ToString().Trim();
            }

            return string.Join(",",colores1);
        }

        protected string ColoresPlayer2()
        {
            var items2 = from ListItem li in playerColors.Items
                         where li.Selected == true
                         select li;

            String[] colores2 = new String[items2.Count()];
            for (int i = 0; i < items2.Count(); i++)
            {
                colores2[i] = items2.ToList()[i].ToString().Trim();
            }

            return string.Join(",", colores2);
        }

        protected bool SelectedIndexChanged()
        {
            //asp-net-example.blogspot.com/2013/12/aspnet-checkboxlist-limit-selection.html
            var items1 = from ListItem li in UserColors.Items
                        where li.Selected == true
                        select li;

            var items2 = from ListItem al in playerColors.Items
                         where al.Selected == true
                         select al;

            if (items1.Count() > 5 || items2.Count() > 5)
            {
                //Response.Write(items1.ToList()[2]);
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"No se pueden seleccionar más de 5 colores por jugador.\")", true);
                return true;
            }

            else if (items1.Count() == 0 || items2.Count() == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Debes seleccionar al menos un color por cada jugador.\")", true);
                return true;
            }

            //social.msdn.microsoft.com/Forums/es-ES/32c69fa9-ee6e-49cb-8b5b-4477458b0815/saber-si-un-elemento-se-encuentra-dentro-de-una-lista?forum=linqes
            bool has = items1.ToList().Any(i => items2.ToList().Contains(i));
            if (has)
            {
                //var list3 = items1.ToList().Where(i => items2.ToList().Contains(i)).ToList();
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Existen colores repetidos entre jugadores, se debe corregir la selección.\")", true);
                return true;
            }
            else return false;
        }
    }
}