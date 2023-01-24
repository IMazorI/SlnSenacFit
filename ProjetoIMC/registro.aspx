<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="ProjetoIMC.registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="CSS\reset.css" rel="stylesheet" />
   <%-- <link href="CSS\Estilo.css" rel="stylesheet" />--%>
</head>
<body>
    <form id="TelaCadastro" runat="server">
        <div>
            <div id="logoSenac">
                <img src="Imagens\senacFitLogo2.png" alt="Alternate Text" width="250px"/>
            </div>
            <h1 id="Cadastrar">Cadastrar</h1>
            <p>
                <asp:Label ID="Label3" runat="server" Text="Nome:"></asp:Label>
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Login:"></asp:Label>
                <asp:TextBox ID="txtLogin" runat="server" placerholder="Login de acesso"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Senha:"></asp:Label>
                <asp:TextBox ID="txtSenha" runat="server" placerholder="Digite sua senha" TextMode="Password"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label4" runat="server" Text="Data Nascimento:"></asp:Label>
                <asp:TextBox ID="txtData" type="date" value="0000-00-00" runat="server"></asp:TextBox>

            </p>
            <p>
                <asp:Label ID="Label6" runat="server" Text="Telefone:"></asp:Label>
                <asp:TextBox ID="txtTelefone" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label5" runat="server" Text="Perfil:"></asp:Label>
                <asp:DropDownList ID="ddlPerfil" runat="server" OnSelectedIndexChanged="ddlPerfil_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Selected="True">Cliente</asp:ListItem>
                    <asp:ListItem>Profissional</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="lblCredencial" runat="server" Text="Credencial"></asp:Label>
                <asp:TextBox ID="txtCredencial" runat="server"   Visible="True"></asp:TextBox>
            </p>

            <p>                
                <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click1" />
                <asp:Button ID="btnVoltar" runat="server" OnClick="btnVoltar_Click" Text="Voltar" />
            </p>
            <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>

        </div>
    </form>
</body>
</html>
