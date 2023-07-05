<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication.Autenticacao.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <h1 class="display-1 text-center  p-5"> Devlean </h1>
    <div class="d-flex justify-content-center vh-100 p-4">
        <form id="form1" runat="server">
            <div>
                <div class="row justify-content-center">
                    <label for="exempleInputEmail1" class="col-sm-2 col-form-label mb-5"> Email: </label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" ID="Email" CssClass="form-control"></asp:TextBox>
                    </div> 
                </div>

                <div class="row justify-content-center">
                    <label for="exempleInputEmail1" class="col-sm-2 col-form-label mb-3"> Senha: </label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" ID="Senha" CssClass="form-control"></asp:TextBox>
                    </div> 
                </div>

                <div class="d-flex justify-content-center"> 
                    <asp:Label runat="server" ID="LblStatus" CssClass="m-2 text-danger"></asp:Label>
                </div>

                <div class="row mt-4  m-1">
                    <div class="d-grid gap-4 d-md-flex col col-lg-11 justify-content-center">
                        <asp:Button ID="BtnLogin" Text="Entrar" CssClass="btn btn-success " runat="server" OnClick="BtnLogin_Click"/>
                    </div>
                </div>

                <!--<asp:Button ID="BtnCadastrar" Text="Cadastrar" runat="server" OnClick="BtnCadastrar_Click"/>-->
            </div>
        </form>

    </div>
</body>
</html>
