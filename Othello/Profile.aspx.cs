using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Othello
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    user.Text = Convert.ToString(Session["usuario"]);
                }

                DesplegarData();
            }
        }


        protected void Regresar(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx?Parametro=" + user.Text);
        }


        public void DesplegarData()
        {
            PartidasGanadas();
            PartidasEmpatadas();
            PartidasPerdidas();
            TorneosJugados();
            TorneosGanados();
            PuntosTorneo();
        }


        public void PartidasGanadas()
        {

        }

        public void PartidasEmpatadas()
        {

        }

        public void PartidasPerdidas()
        {

        }

        public void TorneosJugados()
        {

        }

        public void TorneosGanados()
        {

        }

        public void PuntosTorneo()
        {

        }

    }
}