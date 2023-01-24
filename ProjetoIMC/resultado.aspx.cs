using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoIMC
{
    public partial class resultado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double resultado;

            //resetar os outros
            magrinho1.Style.Add("color", "");
            magrinho1.Style.Add("background-color", "");
            magrinho2.Style.Add("color", "");
            magrinho2.Style.Add("background-color", "");
            ideal1.Style.Add("color", "");
            ideal1.Style.Add("background-color", "");
            ideal2.Style.Add("color", "");
            ideal2.Style.Add("background-color", "");
            acima1.Style.Add("color", "");
            acima1.Style.Add("background-color", "");
            acima2.Style.Add("color", "");
            acima2.Style.Add("background-color", "");
            obesidade1.Style.Add("color", "");
            obesidade1.Style.Add("background-color", "");
            obesidade2.Style.Add("color", "");
            obesidade2.Style.Add("background-color", "");
            morbida1.Style.Add("color", "");
            morbida1.Style.Add("background-color", "");
            morbida2.Style.Add("color", "");
            morbida2.Style.Add("background-color", "");

            try
            {
                lblPerfil.Text = Session["Login"].ToString() + ", esse é o seu IMC";


                resultado = Convert.ToDouble(Request.QueryString["resultado"]);
                txtResultado.Text = resultado.ToString("n1");

               

                if (resultado <= 20.7) 
                {
                    magrinho1.Style.Add("color", "darkgoldenrod");
                    magrinho1.Style.Add("background-color", "rebeccapurple");
                    magrinho2.Style.Add("color", "darkgoldenrod");
                    magrinho2.Style.Add("background-color", "rebeccapurple");

                }
                else if (resultado > 20.6 && resultado < 26.5)
                {
                    ideal1.Style.Add("color", "darkgoldenrod");
                    ideal1.Style.Add("background-color", "rebeccapurple");
                    ideal2.Style.Add("color", "darkgoldenrod");
                    ideal2.Style.Add("background-color", "rebeccapurple");
                }
                else if (resultado > 26.4 && resultado < 27.9)
                {
                    acima1.Style.Add("color", "darkgoldenrod");
                    acima1.Style.Add("background-color", "rebeccapurple");
                    acima2.Style.Add("color", "darkgoldenrod");
                    acima2.Style.Add("background-color", "rebeccapurple");
                }
                else if (resultado > 27.8 && resultado < 31.2)
                {
                    obesidade1.Style.Add("color", "darkgoldenrod");
                    obesidade1.Style.Add("background-color", "rebeccapurple");
                    obesidade2.Style.Add("color", "darkgoldenrod");
                    obesidade2.Style.Add("background-color", "rebeccapurple");
                }
                else
                {
                    morbida1.Style.Add("color", "darkgoldenrod");
                    morbida1.Style.Add("background-color", "rebeccapurple");
                    morbida2.Style.Add("color", "darkgoldenrod");
                    morbida2.Style.Add("background-color", "rebeccapurple");
                }

            }

            catch (NullReferenceException)
            {
                Response.Redirect("default.aspx");
            }           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            
        }

        protected void Recalcular_Click(object sender, EventArgs e)
        {
            Response.Redirect("imc.aspx");
            
        }

        protected void btnDeslogar_Click(object sender, EventArgs e)
        {
            Session.Abandon();

            Response.Redirect("default.aspx");
        }
    }
}