using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            DatosUsuario();
            PartidasGanadas();
            PartidasEmpatadas();
            PartidasPerdidas();
            TorneosJugados();
            TorneosGanados();
            PuntosTorneo();
        }


        public void DatosUsuario()
        {
            try
            {//Codigo de AspNet Ya.com
                string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                SqlConnection conexion = new SqlConnection(a);
                conexion.Open();
                SqlCommand script = new SqlCommand("SELECT nombre, apellido, correo, fecha_nac, pais FROM Usuario " +
                      "WHERE username=\'" + user.Text + "\'", conexion);
                SqlDataReader registro = script.ExecuteReader();
                if (registro.Read())
                {
                    Unombre.Text = registro.GetString(0);
                    Uapellido.Text = registro.GetString(1);
                    Ucorreo.Text = registro.GetString(2);
                    Ufecha.Text = registro.GetDateTime(3).ToString().Replace("12:00:00 a. m.", "");
                    Upais.Text = registro.GetString(4);
                }
                conexion.Close();
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"No se ha podido reconocer algún campo o bien, se encuentra vacío.\")", true);
            }
        }

        public void PartidasGanadas()
        {
            try
            {//Codigo de AspNet Ya.com
                string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                SqlConnection conexion = new SqlConnection(a);
                conexion.Open();
                SqlCommand script = new SqlCommand("SELECT COUNT(*) FROM Partida WHERE ganador = '" + user.Text + "'", conexion);
                SqlDataReader registro = script.ExecuteReader();
                if (registro.Read())
                {
                    Pganadas.Text = registro.GetValue(0).ToString();
                }
                conexion.Close();
            }
            catch (Exception)
            {
                Pganadas.Text = "0";
            }
        }

        public void PartidasEmpatadas()
        {
            try
            {//Codigo de AspNet Ya.com
                string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                SqlConnection conexion = new SqlConnection(a);
                conexion.Open();
                SqlCommand script = new SqlCommand("SELECT COUNT(*) FROM Partida WHERE jugador1 = '" + user.Text + "' AND empate = 1", conexion);
                SqlDataReader registro = script.ExecuteReader();
                if (registro.Read())
                {
                    Pempatadas.Text = registro.GetValue(0).ToString();
                }
                conexion.Close();
            }
            catch (Exception)
            {
                Pempatadas.Text = "0";
            }
        }

        public void PartidasPerdidas()
        {
            try
            {//Codigo de AspNet Ya.com
                string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                SqlConnection conexion = new SqlConnection(a);
                conexion.Open();
                SqlCommand script = new SqlCommand("SELECT COUNT(*) FROM Partida WHERE perdedor = '" + user.Text + "'", conexion);
                SqlDataReader registro = script.ExecuteReader();
                if (registro.Read())
                {
                    Pperdidas.Text = registro.GetValue(0).ToString();
                }
                conexion.Close();
            }
            catch (Exception)
            {
                Pperdidas.Text = "0";
            }
        }

        public void TorneosJugados()
        {
            try
            {//Codigo de AspNet Ya.com
                string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                SqlConnection conexion = new SqlConnection(a);
                conexion.Open();
                SqlCommand script = new SqlCommand("SELECT COUNT(*) FROM Jugador WHERE usuario = '" + user.Text + "'", conexion);
                SqlDataReader registro = script.ExecuteReader();
                if (registro.Read())
                {
                    Tjugados.Text = registro.GetValue(0).ToString();
                }
                conexion.Close();
            }
            catch (Exception)
            {
                Tjugados.Text = "0";
            }
        }

        public void TorneosGanados()
        {
            try
            {//Codigo de AspNet Ya.com
                string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                SqlConnection conexion = new SqlConnection(a);
                conexion.Open();
                SqlCommand script = new SqlCommand("select count(gan.ganador) as [Ganador], usar.usuario as [Usuario] from RondaTorneo gan inner join " +
                    "Jugador usar on gan.ganador = usar.equipo where usar.usuario = '" + user.Text +"' AND gan.puntos = 3 AND(gan.ronda = 'Desempate Final' " +
                    "OR gan.ronda = 'Final') group by usar.usuario", conexion);
                SqlDataReader registro = script.ExecuteReader();
                if (registro.Read())
                {
                    Tganados.Text = registro.GetValue(0).ToString();
                }
                conexion.Close();
            }
            catch (Exception)
            {
                Tganados.Text = "0";
            }
        }

        public void PuntosTorneo()
        {
            try
            {//Codigo de AspNet Ya.com
                string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                SqlConnection conexion = new SqlConnection(a);
                conexion.Open();
                SqlCommand script = new SqlCommand("SELECT sum(gan.puntos) as [Puntos], usar.usuario as [Usuario] " +
                    "from RondaTorneo gan inner join Jugador usar on gan.equipo1 = usar.equipo OR gan.equipo2 = usar.equipo WHERE usar.usuario = '" + user.Text +
                    "' GROUP BY usar.usuario", conexion);
                SqlDataReader registro = script.ExecuteReader();
                if (registro.Read())
                {
                    Tpuntos.Text = registro.GetValue(0).ToString();
                }
                conexion.Close();
            }
            catch (Exception)
            {
                Tpuntos.Text = "0";
            }
        }

    }
}