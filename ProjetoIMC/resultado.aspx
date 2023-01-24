<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resultado.aspx.cs" Inherits="ProjetoIMC.resultado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="CSS\reset.css" rel="stylesheet" />
   <%-- <link href="CSS\Estilo.css" rel="stylesheet" />--%>
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
                    <br />
                    <br />
                </p>
                <asp:Label ID="lblPerfil" runat="server" Text=""></asp:Label>
            </header>

            <div class="Formula">
                <asp:TextBox ID="txtResultado" runat="server" placeholder="Resultado" Enabled="False"></asp:TextBox>

                <br />

            </div>
            <div class="botoes">
                <asp:Button ID="btnRecalcular" runat="server" Text="Recalcular" OnClick="Recalcular_Click" />
                <asp:Button ID="btnDeslogar" runat="server" Text="Deslogar" OnClick="btnDeslogar_Click" />

            </div>



            <div class="Tabela" runat="server">
                <table id="Tabelinha">
                    <thead>
                        <tr>
                            <th>I.M.C</th>
                            <th>Catergoria</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td id="magrinho1" runat="server">Abaixo de 20,7 </td>
                            <td id="magrinho2" runat="server">Abaixo do Peso!</td>
                        </tr>
                        <tr>
                            <td id="ideal1" runat="server">20,7 a 26,4</td>
                            <td id="ideal2" runat="server">Peso ideal</td>
                        </tr>
                        <tr>
                            <td id="acima1" runat="server">26,5 a 27,8</td>
                            <td id="acima2" runat="server">Pouco acima do peso</td>
                        </tr>
                        
                        <tr>
                            <td id="obesidade1" runat="server">27,9 a 31,1</td>
                            <td id="obesidade2" runat="server">Obesidade </td>
                        </tr>
                        <tr>
                            <td id="morbida1" runat="server">31,1 + </td>
                            <td id="morbida2" runat="server">Obesidade Morbida</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
