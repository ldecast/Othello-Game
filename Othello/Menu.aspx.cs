using NHibernate.Mapping;
using System;
using System.Collections.Generic;
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

        protected void newGame_Click_White(object sender, EventArgs e)
        {
            Response.Redirect("GameBoard.aspx?Parametro=" + usuario.Text+"-Blanco");
        }
        protected void newGame_Click_Black(object sender, EventArgs e)
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

        protected void cargarElegir1(object sender, EventArgs e)
        {
            cargar1.Visible = false;
            cargar2.Visible = false;
            Panel1.Visible = true;
            Label3.Text = "Color para " + usuario.Text;
            upload.Visible = true;
        }

        protected void cargarElegir2(object sender, EventArgs e)
        {
            cargar1.Visible = false;
            cargar2.Visible = false;
            Panel2.Visible = true;
            Label3.Text = "Color para " + usuario.Text;
            upload.Visible = true;
        }

        protected void chooseColor1(object sender, EventArgs e)
        {
            newGame.Visible = false;
            juegoSolo.Visible = false;
            selectColor.Visible = true;
            juegoNuevo.Text = "Color para " + usuario.Text;
        }

        protected void chooseColor2(object sender, EventArgs e)
        {
            newGame.Visible = false;
            juegoSolo.Visible = false;
            selectColor2.Visible = true;
            juegoNuevo.Text = "Color para " + usuario.Text;
        }
    }
}