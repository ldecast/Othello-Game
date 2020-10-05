using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Othello
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Registrar(object sender, EventArgs e)
        {
            try
            {
                if (uname.Text.Length!=0 && password.Text.Length != 0) {
                //codigo de Tutoriales Ya.com
                string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                SqlConnection conexion = new SqlConnection(a);
                conexion.Open();
                SqlCommand script = new SqlCommand("insert into Usuario(nombre,apellido,fecha_nac,pais,correo,username,contraseña) values('" +
                      fname.Text + "','" + sname.Text + "','" + fnac.Text + "','" + pais.Text + "','" + correo.Text + "','" + uname.Text + "','" + password.Text + "')", conexion);
                script.ExecuteNonQuery();
                conexion.Close();
                ClientScript.RegisterStartupScript(GetType(), "hwa", "registrado()", true);
            }
            else
                ClientScript.RegisterStartupScript(GetType(), "hwa", "invalid()", true);
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert(\"Error: valide que no registre un usuario ya existente.\")", true);
            }
        }

        protected void Logear(object sender, EventArgs e)
        {
            //Codigo de Asp Ya.com
            string a = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            SqlConnection conexion = new SqlConnection(a);
            conexion.Open();
            SqlCommand script = new SqlCommand("SELECT username, contraseña FROM Usuario " +
                  "WHERE username=\'" + loginname.Text + "\' AND contraseña=\'"+loginpassword.Text+"\'", conexion);
            SqlDataReader registro = script.ExecuteReader();
            if (registro.Read())
                Response.Redirect("Menu.aspx?Parametro=" + loginname.Text);
            else
                ClientScript.RegisterStartupScript(GetType(), "hwa", "notMatch()", true);
            conexion.Close();
        }
    }
}