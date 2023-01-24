using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; // colocar
using System.Data.SqlClient; //colocar
using System.Configuration; //colocar CONEXAO manager
using System.Security.Cryptography; //criptografia biblio DLL
using System.Text; //dll para trabalhar com textos

namespace ProjetoIMC
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            
            try
            {
                HttpCookie cookie2 = new HttpCookie("nome");                          
                HttpCookie cookie = new HttpCookie("id");

                DateTime agora = DateTime.Now;
                TimeSpan tempo = new TimeSpan(0, 20, 0);
                cookie.Expires = agora + tempo;
                cookie2.Expires = agora + tempo;                

                Response.Cookies.Add(cookie);
                Response.Cookies.Add(cookie2);
                


                if (chkPro.Checked == true)
                {
                    SqlConnection conexao = new SqlConnection
                  (ConfigurationManager.ConnectionStrings["ProjetoIMC.Properties.Settings.strConexao"].ToString());
                    SqlCommand cmd = new SqlCommand();
                    SqlDataReader leitor;
                    cmd.CommandText = "ps_LoginPro"; 
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conexao;
                    //inicio criptografia
                    MD5 criaCripto = MD5.Create(); 
                    byte[] vetorByte = Encoding.ASCII.GetBytes(txtSenha.Text);
                    byte[] vetorHash = criaCripto.ComputeHash(vetorByte);
                    StringBuilder senhaCriptografada = new StringBuilder();  
                    for (int i = 0; i < vetorHash.Length; i++) 
                    {
                        senhaCriptografada.Append(vetorHash[i].ToString("x2")); 
                    }
                    //fim criptografia
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("loginPro", txtLogin.Text);
                    cmd.Parameters.AddWithValue("senhaPro", senhaCriptografada.ToString());
                    conexao.Open();
                    leitor = cmd.ExecuteReader();
                    if (leitor.HasRows)
                    {
                        leitor.Read();

                        cookie.Value = leitor.GetInt32(0).ToString();
                        cookie2.Value = leitor.GetString(3);

                        Response.Redirect("menuProfi.aspx");
                    }
                    else
                    {
                        lblMensagem.Text = "Usuario ou senha invalidos";
                    }
                    conexao.Close();
                    leitor.Close();
                    
                }
                else
                {

                    SqlConnection conexao = new SqlConnection
                  (ConfigurationManager.ConnectionStrings["ProjetoIMC.Properties.Settings.strConexao"].ToString());
                    SqlCommand cmd = new SqlCommand();
                    SqlDataReader leitor;
                    cmd.CommandText = "ps_LoginUsu";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conexao;
                    //inicio criptografia
                    MD5 criaCripto = MD5.Create();
                    byte[] vetorByte = Encoding.ASCII.GetBytes(txtSenha.Text);
                    byte[] vetorHash = criaCripto.ComputeHash(vetorByte);
                    StringBuilder senhaCriptografada = new StringBuilder();
                    for (int i = 0; i < vetorHash.Length; i++)
                    {
                        senhaCriptografada.Append(vetorHash[i].ToString("x2"));
                    }
                    //fim criptografia
                    cmd.Parameters.Clear(); 
                    cmd.Parameters.AddWithValue("loginUsu", txtLogin.Text);
                    cmd.Parameters.AddWithValue("senhaUsu", senhaCriptografada.ToString());
                    conexao.Open();
                    leitor = cmd.ExecuteReader();
                    if (leitor.HasRows)
                    {

                        leitor.Read();

                        cookie.Value = leitor.GetInt32(0).ToString();
                        cookie2.Value = leitor.GetString(1);
                        Response.Redirect("menu.aspx");
                    }
                    else
                    {
                        lblMensagem.Text = "Usuario ou senha invalidos";
                    }
                    conexao.Close();
                    leitor.Close();                  
                }                               
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;

            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("registro.aspx");
        }
       
    }
}