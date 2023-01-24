<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menuProfi.aspx.cs" Inherits="ProjetoIMC.menuProfi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="CSS\reset.css" rel="stylesheet" />
</head>
<body>
    <form id="PainelProfissional" runat="server">

        <div>
            <asp:Button ID="btnGerenciarDieta" runat="server" Text="Gerenciar Dieta" OnClick="btnGerenciarDieta_Click" />
            <asp:Button ID="btnCalcularIMC" runat="server" Text="Calcular IMC" OnClick="btnCalcularIMC_Click" />
            <asp:Button ID="btnCadastrarCliente" runat="server" Text="Cadastrar" OnClick="btnCadastrarCliente_Click" />
            <asp:HiddenField ID="hdIdUsuario" runat="server" />
            <asp:HiddenField ID="hdIdPro" runat="server" />
            <asp:HiddenField ID="hdIdAvaliacao" runat="server" />
            <asp:HiddenField ID="hdDataDieta" runat="server" />
        </div>

        <asp:Label ID="lblMensagem" runat="server"></asp:Label>


        <div>
            <asp:Label ID="Label17" runat="server" Text="Buscar Cliente:"></asp:Label>
            <asp:TextBox ID="txtBuscarGRID" runat="server"></asp:TextBox>
            <asp:Button ID="btnBuscarGRID" runat="server" Text="Buscar" OnClick="btnBuscarGRID_Click" /><br />


        </div>

        <div>
            <asp:GridView ID="GridPainel" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridPainel_SelectedIndexChanged"></asp:GridView>

        </div>

        <div class="MenuPainel">
            <div id="DivCalculadora" visible="false" runat="server">
                <asp:Label ID="idNomeUsuIMC" runat="server"></asp:Label>
                <div>
                    <asp:GridView ID="GridIMC" runat="server" OnSelectedIndexChanged="GridIMC_SelectedIndexChanged"></asp:GridView>

                </div>
                <div>
                    <h2>Calculadora I.M.C.</h2>
                    <p>
                        Fórmula do IMC=Peso/(altura²)
                <br />
                        PESO MAXIMO: 299KG        
                <br />
                        ALTURA MAXIMA: 2,40M                 
                    </p>
                    <div class="Calculadora">


                        <asp:Label ID="Label20" runat="server" Text="Cliente:"></asp:Label>
                        <asp:TextBox ID="txtIdCliente" runat="server"></asp:TextBox>

                        <asp:Label ID="Label8" runat="server" Text="Data Avaliaçao:"></asp:Label>
                        <%--<asp:TextBox ID="txtData" type="date" value="0000-00-00" runat="server" TextMode="Date"></asp:TextBox><br />--%>
                        <asp:TextBox ID="txtData" TextMode="Date" runat="server"></asp:TextBox><br />
                        <asp:Label ID="Label6" runat="server" Text="PESO"></asp:Label>
                        <asp:TextBox ID="txtPeso" runat="server" Placeholder="Quantos kilos voce tem ?"></asp:TextBox><br />
                        <asp:Label ID="Label7" runat="server" Text="Altura"></asp:Label>
                        <asp:TextBox ID="txtAltura" runat="server" placeholder="Quantos metros você tem ?"></asp:TextBox><br />
                        <asp:Label ID="Label12" runat="server" Text="IMC:"></asp:Label>
                        <asp:TextBox ID="txtResultado" runat="server" placeholder="Resultado" Enabled="False"></asp:TextBox><br />
                        <asp:Label ID="lblCalculadoraErro" runat="server" Text=""></asp:Label>
                        <asp:Button ID="BtnCalcular" runat="server" Text="Calcular" OnClick="BtnCalcular_Click" />
                        <asp:Button ID="BtnFecharC" runat="server" Text="Fechar" OnClick="BtnFecharC_Click" />
                    </div>
                </div>
            </div>


            <div id="DivDieta" visible="false" runat="server">

                <asp:Label ID="idNomeUsuDieta" runat="server"></asp:Label>
                <div>
                    <asp:GridView ID="GridDieta" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridDieta_SelectedIndexChanged"></asp:GridView>
                    <asp:Label ID="lblMensagemDieta" runat="server" Text=""></asp:Label>
                </div>

                <div>
                    <h2>Dieta Orientada</h2>
                    <p>
                        <asp:TextBox ID="txtDataDieta" runat="server" TextMode="Date" Visible="False"></asp:TextBox>
                    </p>


                    <asp:Label ID="Label9" runat="server" Text="Caloria Diaria:"></asp:Label>
                    <asp:TextBox ID="txtCaloria" runat="server"></asp:TextBox>
                    <div class="manha">
                        <h3>Refeiçao matutina</h3>
                        <asp:Label ID="Label14" runat="server" Text="7:00"></asp:Label>
                        <asp:TextBox ID="txtSete" runat="server"></asp:TextBox>
                        <asp:Label ID="Label11" runat="server" Text="9:00"></asp:Label>
                        <asp:TextBox ID="txtNove" runat="server"></asp:TextBox>
                        <asp:Label ID="Label13" runat="server" Text="11:00"></asp:Label>
                        <asp:TextBox ID="txtOnze" runat="server"></asp:TextBox>
                    </div>
                    <div class="tarde">
                        <h3>Refeiçao Vespertino</h3>
                        <asp:Label ID="Label15" runat="server" Text="12:00"></asp:Label>
                        <asp:TextBox ID="txtDoze" runat="server"></asp:TextBox>
                        <asp:Label ID="Label18" runat="server" Text="15:00"></asp:Label>
                        <asp:TextBox ID="txtQuinze" runat="server"></asp:TextBox>
                        <asp:Label ID="Label19" runat="server" Text="18:00"></asp:Label>
                        <asp:TextBox ID="txtDezoito" runat="server"></asp:TextBox>
                    </div>
                    <div class="noite">
                        <h3>Refeiçao Noturna</h3>
                        <asp:Label ID="Label10" runat="server" Text="20:00"></asp:Label>
                        <asp:TextBox ID="txtVinte" runat="server"></asp:TextBox>
                        <asp:Label ID="Label16" runat="server" Text="22:00"></asp:Label>
                        <asp:TextBox ID="txtVinteDois" runat="server"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnDieta" runat="server" Text="Salvar" OnClick="btnDieta_Click" />
                    <asp:Button ID="btnFecharD" runat="server" Text="Fechar" OnClick="btnFecharD_Click" />
                </div>
            </div>
        </div>



    </form>
</body>
</html>
