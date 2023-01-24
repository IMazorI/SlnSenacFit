using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoIMC.Classe;

namespace ProjetoIMC
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                PerfilLogado.Text = Session["Login"].ToString() + ", veja se esta Gordinho ou Magrinho" /*" " + Session["Password"].ToString()*/;

            }

            catch (NullReferenceException)
            {
                Response.Redirect("default.aspx");
            }

        }

        protected void BtnCalcular_Click(object sender, EventArgs e)
        {
            //CLASSE ORIENTADA
            //
            try
            {
                double altura, peso, resultado;


                txtPeso.Text = txtPeso.Text.Replace(".", ",");
                txtAltura.Text = txtAltura.Text.Replace(".", ",");

                altura = Convert.ToDouble(txtAltura.Text);
                peso = Convert.ToDouble(txtPeso.Text);               
               

                if (altura == 0)
                {
                    throw new DivideByZeroException();
                }
                else if (peso == 0)
                {
                    throw new DivideByZeroException();
                }
                else if (altura >= 2.5 || altura <= 0)
                {
                    txtAviso.Text = "Altura alienigena";
                    
                }
                else if (peso >= 300 || peso <= 0)
                {
                    txtAviso.Text = "Peso nao-humano";
                    
                }
                else
                {
                    //Transferir
                    resultado = Operacao.Calcular(altura, peso);
                    Response.Redirect("resultado.aspx?resultado=" + resultado);



                }



            }

            catch (FormatException)
            {
                txtAviso.Text = "Insira valores";
            }

            catch (DivideByZeroException)
            {
                txtAviso.Text = "Divisão por zero";
            }


        }
    }
}