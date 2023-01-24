using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoIMC.Classe; //classe operaçao
using System.Data; // colocar
using System.Data.SqlClient; //colocar
using System.Configuration; //colocar CONEXAO manager
using System.Security.Cryptography; //criptografia biblio DLL
using System.Text; //dll para trabalhar com textos
using System.Net;


namespace ProjetoIMC
{
    public partial class menuProfi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id, nome;
            try
            {

                HttpCookie cookie = Request.Cookies["id"];
                id = cookie.Value.ToString();
                HttpCookie cookie2 = Request.Cookies["nome"];
                nome = cookie2.Value.ToString();

                //lblMensagem.Text = login + " " + senha;

            }

            catch (NullReferenceException)
            {
                Response.Redirect("default.aspx");
            }

            btnBuscarGRID_Click(sender, e);




        }

        protected void btnGerenciarDieta_Click(object sender, EventArgs e)
        {
            DivCalculadora.Visible = false;
            DivDieta.Visible = true;

            SqlConnection conexao = new SqlConnection
                          (ConfigurationManager.ConnectionStrings["ProjetoIMC.Properties.Settings.strConexao"].ToString());
            SqlCommand command = new SqlCommand();
            command.CommandText = "ps_InfoDieta";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conexao;
            command.Parameters.AddWithValue("idUsuario", txtIdCliente.Text);
            SqlDataAdapter adaptacao = new SqlDataAdapter(command);
            DataSet mostrarDados = new DataSet();
            adaptacao.Fill(mostrarDados);
            GridDieta.DataSource = mostrarDados;
            GridDieta.DataBind();


        }

        protected void BtnCalcular_Click(object sender, EventArgs e)
        {
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
                    lblCalculadoraErro.Text = "Altura alienigena";

                }
                else if (peso >= 300 || peso <= 0)
                {
                    lblCalculadoraErro.Text = "Peso nao-humano";

                }
                else
                {
                    HttpCookie cookie = Request.Cookies["id"];



                    resultado = Operacao.Calcular(altura, peso);
                    SqlConnection conexao = new SqlConnection
                            (ConfigurationManager.ConnectionStrings["ProjetoIMC.Properties.Settings.strConexao"].ToString());
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "pi_Avaliacao";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conexao;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("idProfissional", Convert.ToInt32(Request.Cookies["id"].Value));
                    cmd.Parameters.AddWithValue("idUsuario", Convert.ToInt32(txtIdCliente.Text));
                    cmd.Parameters.AddWithValue("dataAval", txtData.Text);
                    cmd.Parameters.AddWithValue("peso", Convert.ToDecimal(txtPeso.Text));
                    cmd.Parameters.AddWithValue("altura", Convert.ToDecimal(txtAltura.Text));
                    cmd.Parameters.AddWithValue("resultado", Convert.ToDecimal(resultado));
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                    conexao.Close();

                    lblMensagem.Text = "IMC Cadastrado!";


                }
            }

            catch (FormatException)
            {
                lblCalculadoraErro.Text = "Insira valores";
            }

            catch (DivideByZeroException)
            {
                lblCalculadoraErro.Text = "Divisão por zero";
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message + " ERRO: " + ex.HResult;


            }


        }

        protected void btnDieta_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["id"];

            SqlConnection conexao = new SqlConnection
                              (ConfigurationManager.ConnectionStrings["ProjetoIMC.Properties.Settings.strConexao"].ToString());

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "pi_Dieta";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexao;

            cmd.Parameters.Clear(); //resetar pra nao da erro
            cmd.Parameters.AddWithValue("idUsuario", Convert.ToInt32(txtIdCliente.Text));
            cmd.Parameters.AddWithValue("idProfissional", Convert.ToInt32(Request.Cookies["id"].Value));
            cmd.Parameters.AddWithValue("idAvaliacao", hdIdAvaliacao.Value);
            cmd.Parameters.AddWithValue("dataDieta", txtData.Text);
            cmd.Parameters.AddWithValue("dietaCaloria", txtCaloria.Text);
            cmd.Parameters.AddWithValue("dietaSete", txtSete.Text);
            cmd.Parameters.AddWithValue("dietaNove", txtNove.Text);
            cmd.Parameters.AddWithValue("dietaOnze", txtOnze.Text);
            cmd.Parameters.AddWithValue("dietaDoze", txtDoze.Text);
            cmd.Parameters.AddWithValue("dietaQuinze", txtQuinze.Text);
            cmd.Parameters.AddWithValue("dietaDezoito", txtDezoito.Text);
            cmd.Parameters.AddWithValue("dietaVinte", txtVinte.Text);
            cmd.Parameters.AddWithValue("dietaVinteDois", txtVinteDois.Text);


            conexao.Open();
            cmd.ExecuteNonQuery();
            conexao.Close();

            lblMensagem.Text = "Dieta Cadastrada!";


        }

        protected void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("registro.aspx");
        }

        protected void btnCalcularIMC_Click(object sender, EventArgs e)
        {
            DivCalculadora.Visible = true;
            DivDieta.Visible = false;

            SqlConnection conexao = new SqlConnection
                           (ConfigurationManager.ConnectionStrings["ProjetoIMC.Properties.Settings.strConexao"].ToString());
            SqlCommand command = new SqlCommand();
            command.CommandText = "ps_InfoIMC";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conexao;
            command.Parameters.AddWithValue("idUsuario", txtIdCliente.Text);
            SqlDataAdapter adaptacao = new SqlDataAdapter(command);
            DataSet mostrarDados = new DataSet();
            adaptacao.Fill(mostrarDados);
            GridIMC.DataSource = mostrarDados;
            GridIMC.DataBind();



        }


        protected void BtnFecharC_Click(object sender, EventArgs e)
        {
            DivCalculadora.Visible = false;
        }

        protected void btnFecharD_Click(object sender, EventArgs e)
        {
            DivDieta.Visible = false;
        }

        protected void btnBuscarGRID_Click(object sender, EventArgs e)
        {

            SqlConnection conexao = new SqlConnection
                             (ConfigurationManager.ConnectionStrings["ProjetoIMC.Properties.Settings.strConexao"].ToString());
            SqlCommand command = new SqlCommand();
            command.CommandText = "ps_ListaUsuarios";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conexao;
            command.Parameters.AddWithValue("nomeUsu", txtBuscarGRID.Text);
            SqlDataAdapter adaptacao = new SqlDataAdapter(command);
            DataSet mostrarDados = new DataSet();
            adaptacao.Fill(mostrarDados);
            GridPainel.DataSource = mostrarDados;
            GridPainel.DataBind();


        }

        protected void GridPainel_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdCliente.Text = HttpUtility.HtmlDecode(GridPainel.SelectedRow.Cells[1].Text);
            //txtIdAvaliacao.Text = HttpUtility.HtmlDecode(GridPainel.SelectedRow.Cells[5].Text);            

            if (DivCalculadora.Visible == true)
            {
                idNomeUsuIMC.Text = HttpUtility.HtmlDecode(GridPainel.SelectedRow.Cells[2].Text) + ", suas ultimas avaliacoes:";
                btnCalcularIMC_Click(sender, e);

            }
            else if (DivDieta.Visible == true)
            {
                idNomeUsuDieta.Text = HttpUtility.HtmlDecode(GridPainel.SelectedRow.Cells[2].Text) ;
                txtDataDieta.Text = HttpUtility.HtmlDecode(GridPainel.SelectedRow.Cells[1].Text);

                btnGerenciarDieta_Click(sender, e);
            }




        }

        protected void GridDieta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao = new SqlConnection
                             (ConfigurationManager.ConnectionStrings["ProjetoIMC.Properties.Settings.strConexao"].ToString());

                SqlCommand cmd = new SqlCommand();
                SqlDataReader leitor;

                cmd.CommandText = "ps_Dieta";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conexao;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("nomeUsu", idNomeUsuDieta.Text);
                cmd.Parameters.AddWithValue("dataDieta", txtDataDieta.Text);

                conexao.Open();
                leitor = cmd.ExecuteReader();

                if (leitor.HasRows)
                {
                    leitor.Read();
                    txtCaloria.Text = leitor.GetDecimal(0).ToString();
                    txtSete.Text = leitor.GetString(1);
                    txtNove.Text = leitor.GetString(2);
                    txtOnze.Text = leitor.GetString(3);
                    txtDoze.Text = leitor.GetString(4);
                    txtQuinze.Text = leitor.GetString(5);
                    txtDezoito.Text = leitor.GetString(6);
                    txtVinte.Text = leitor.GetString(7);
                    txtVinteDois.Text = leitor.GetString(8);

                }
                else
                {

                    lblMensagemDieta.Text = "Dieta não encontrado";

                }
                leitor.Close();
                conexao.Close();

            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.HResult + ":" + ex.Message;

            }
        }

        protected void GridIMC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


}
