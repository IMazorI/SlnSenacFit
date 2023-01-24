<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="ProjetoIMC.menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnIMC" runat="server" Text="IMC" OnClick="btnIMC_Click" />
            <asp:Button ID="btnDieta" runat="server" Text="Dieta" />
            <asp:Button ID="btnDeslogar" runat="server" Text="Sair" />
        </div>
    </form>
</body>
</html>
