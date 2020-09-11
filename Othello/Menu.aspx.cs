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

        }

        public void Redireccionar(object sender, EventArgs e)
        {
            //Session["archivo"] = ""+upload.FileName;
            upload.SaveAs(Server.MapPath(".") + "\\XML\\"+ upload.FileName);
            string ruta = Server.MapPath(".") + "\\XML\\" + upload.FileName;
            

            Session["archivo"] = ruta;
            Response.Redirect("OthelloLoaded.aspx?Parametro="+usuario.Text);
        }

        protected void newGame_Click(object sender, EventArgs e)
        {
            Response.Redirect("GameBoard.aspx?Parametro=" + usuario.Text);
        }

        protected void NewGame_Alone(object sender, EventArgs e)
        {
            Response.Redirect("GameOnePlayer.aspx?Parametro=" + usuario.Text);
        }
    }
}