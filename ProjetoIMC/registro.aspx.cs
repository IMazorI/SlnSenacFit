using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; //colocar
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography; //criptografia biblio DLL
using System.Text; //dll para trabalhar com textos

namespace ProjetoIMC
{
    public partial class registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

      

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void btnCadastrar_Click1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao = new SqlConnection
               (ConfigurationManager.ConnectionStrings["ProjetoIMC.Properties.Settings.strConexao"].ToString());  //web config

                SqlCommand cmd = new SqlCommand();

                if (ddlPerfil.Text == "Cliente")
                {

                    cmd.CommandText = "pi_Usuario";  //banco de dados SQL procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conexao;

                    //inicio criptografia
                    MD5 criaCripto = MD5.Create(); // classe abstrata
                    byte[] vetorByte = Encoding.ASCII.GetBytes(txtSenha.Text);  // transforma texto em numeros BYTES
                    byte[] vetorHash = criaCripto.ComputeHash(vetorByte); //transforma byte em HASH  "HY4T"

                    StringBuilder senhaCriptografada = new StringBuilder();  // juntar os pedaços quebrados

                    for (int i = 0; i < vetorHash.Length; i++) // começa em 0 e termina ao acabar o codigo HASH
                    {
                        senhaCriptografada.Append(vetorHash[i].ToString("x2")); // acrescentar os pedaços do hash da senha
                    }

                    //fim criptografia

                    cmd.Parameters.Clear(); //resetar pra nao da erro
                    cmd.Parameters.AddWithValue("nomeUsu", txtNome.Text);
                    cmd.Parameters.AddWithValue("loginUsu", txtLogin.Text);
                    cmd.Parameters.AddWithValue("senhaUsu", senhaCriptografada.ToString());
                    cmd.Parameters.AddWithValue("dataNascimentoUsu", txtData.Text);
                    cmd.Parameters.AddWithValue("perfilUsu", ddlPerfil.Text);
                    cmd.Parameters.AddWithValue("telefoneUsu", txtTelefone.Text);


                    if (txtNome.Text == "" || txtSenha.Text == "" || txtLogin.Text == "" | txtTelefone.Text == "")  // == compara  = atribui
                    {
                        throw new FormatException();
                    }


                }
                else
                {

                    cmd.CommandText = "pi_Profissional";  //banco de dados SQL procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conexao;

                    //inicio criptografia
                    MD5 criaCripto = MD5.Create(); // classe abstrata
                    byte[] vetorByte = Encoding.ASCII.GetBytes(txtSenha.Text);  // transforma texto em numeros BYTES
                    byte[] vetorHash = criaCripto.ComputeHash(vetorByte); //transforma byte em HASH  "HY4T"

                    StringBuilder senhaCriptografada = new StringBuilder();  // juntar os pedaços quebrados

                    for (int i = 0; i < vetorHash.Length; i++) // começa em 0 e termina ao acabar o codigo HASH
                    {
                        senhaCriptografada.Append(vetorHash[i].ToString("x2")); // acrescentar os pedaços do hash da senha
                    }

                    //fim criptografia

                    cmd.Parameters.Clear(); //resetar pra nao da erro
                    cmd.Parameters.AddWithValue("credencial", txtCredencial.Text);
                    cmd.Parameters.AddWithValue("nomePro", txtNome.Text);
                    cmd.Parameters.AddWithValue("loginPro", txtLogin.Text);
                    cmd.Parameters.AddWithValue("senhaPro", senhaCriptografada.ToString());
                    cmd.Parameters.AddWithValue("dataNascimentoPro", txtData.Text);
                    cmd.Parameters.AddWithValue("perfilPro", ddlPerfil.Text);
                    cmd.Parameters.AddWithValue("telefonePro", txtTelefone.Text);
                    


                    if (txtNome.Text == "" || txtSenha.Text == "" || txtLogin.Text == "" | txtTelefone.Text == "")  // == compara  = atribui
                    {
                        throw new FormatException();
                    }
                }

                conexao.Open();
                cmd.ExecuteNonQuery();  //inset, delete e update
                conexao.Close();

                lblMensagem.Text = "Profissional Cadastrado";

            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message + " ERRO: " + ex.HResult;


            }
        }

        protected void ddlPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {

           
            if (ddlPerfil.SelectedValue == "Cliente")
            {
               
                txtCredencial.Style.Add("display", "none");
                lblCredencial.Style.Add("display", "none");
            }
            else if (ddlPerfil.SelectedValue == "Profissional")
            {
                
                txtCredencial.Style.Add("display", "block");
                lblCredencial.Style.Add("display", "block");

            }


        }

        protected void txtCredencial_TextChanged(object sender, EventArgs e)
        {

        }
    }
}