<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication.Autenticacao.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div >
            <div> Usuário: </div>
            <div> <asp:TextBox ID="Email" runat="server" Width="124px"></asp:TextBox> </div> 

            <br />
            
            <div> Senha: </div>
            <div> <asp:TextBox ID="Senha" runat="server" TextMode="Password" Width="126px"></asp:TextBox> </div>
        
            <div> 
                <asp:Label runat="server" ID="LblStatus"></asp:Label>
            </div>
            <asp:Button ID="BtnLogin" Text="Entrar" runat="server" OnClick="BtnLogin_Click"/>
        </div>
    </form>
</body>
</html>
