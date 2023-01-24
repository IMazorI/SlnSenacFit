<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ProjetoIMC._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="CSS\reset.css" rel="stylesheet" />
    <%--<link href="CSS\Estilo.css" rel="stylesheet" />--%>
</head>
<body>
    <form id="TelaLogin" runat="server">
        <div>
            <div id="logoSenac">
                <img src="Imagens\senacFitLogo2.png" alt="Alternate Text" width="250px" /> 
            </div>
            <asp:Label ID="lblNome" runat="server" Text="Nome:"></asp:Label>
            <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblSenha" runat="server" Text="Senha:"></asp:Label>
            <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:CheckBox ID="chkPro" runat="server" Text="Profissional" />
            <br />
            <asp:Button ID="btnLogar" runat="server" Text="Entrar" OnClick="btnLogar_Click" />
            <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />           
            <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>

        </div>
    </form>
</body>
</html>
