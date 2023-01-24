<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="imc.aspx.cs" Inherits="ProjetoIMC.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="CSS\reset.css" rel="stylesheet" />
    <link href="CSS\Estilo.css" rel="stylesheet" />
</head>
<body>
    <form id="Calculadora" runat="server">
        <div>
            <header class="Titulo">
                <div>
                    <img id="logoSenac" src="Imagens\senacFitLogo2.png" alt="Alternate Text" />
                </div>
                <h1>Calculadora I.M.C.</h1>
                <p>
                    Fórmula do IMC=Peso/(altura²) <br />
                    <br/>
                    PESO MAXIMO: 299KG <br /> ALTURA MAXIMA: 2,40M
                    <br />
                    <br />
                </p>
                <asp:Label ID="PerfilLogado" runat="server"></asp:Label>
            </header>

            <div class="Formula">
                <asp:Label ID="Label1" runat="server" Text="PESO"></asp:Label>
                <asp:TextBox ID="txtPeso" runat="server" Placeholder="Quantos kilos voce tem ?"></asp:TextBox><br />
                <asp:Label ID="Label2" runat="server" Text="Altura"></asp:Label>
                <asp:TextBox ID="txtAltura" runat="server" placeholder="Quantos metros você tem ?"></asp:TextBox><br />
                <asp:TextBox ID="txtAviso" runat="server" placeholder="Preencha os campos" Enabled="False"></asp:TextBox><br />
                <asp:Button ID="BtnCalcular" runat="server" Text="Calcular" OnClick="BtnCalcular_Click" />

            </div>


        </div>
    </form>
</body>
</html>
