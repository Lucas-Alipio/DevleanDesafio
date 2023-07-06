<%@ Page Title="" Language="C#" MasterPageFile="~/Clientes/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="WebApplication.Clientes.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Content/Clientes/Cliente.css" rel="stylesheet" />
    
    <div class="row justify-content-center">
        <div class="col-auto p-2 mb-1 justify-content-center">
            <h2>Lista de Clientes</h2>
        </div>
    </div>

    <div class="row justify-content-center">
        <div class="col-auto p-2 mb-1 justify-content-center">
            <a class="btn btn-primary" role="button" href="CadastroEdicaoCliente.aspx">Cadastrar Novo Cliente</a>
        </div>
    </div>

    <div class="principal">
        <asp:Repeater ID="RepeaterClientes" runat="server">
            <ItemTemplate>
                <div class="cliente" onclick="redirecionarParaPaginaDoCliente('<%= Session["Perfil"].ToString() %>', <%#DataBinder.Eval(Container.DataItem, "Id") %>)">

                    <div class="cliente-info">ID: <%# DataBinder.Eval(Container.DataItem, "Id") %></div>
                    <div class="cliente-info">Nome: <%# DataBinder.Eval(Container.DataItem, "Nome") %></div>
                    <div class="cliente-info">Tipo: <%# DataBinder.Eval(Container.DataItem, "Tipo") %></div>
                    <div class="cliente-info">CPF/CNPJ: <%# DataBinder.Eval(Container.DataItem, "Cpf_Cnpj") %></div>
                    <div class="cliente-info">Data de Nascimento: <%# DataBinder.Eval(Container.DataItem, "Data_Nascimento") %></div>
                    <div class="cliente-info">Data de Cadastro: <%# DataBinder.Eval(Container.DataItem, "Data_Cadastro") %></div>

                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <script>
        function redirecionarParaPaginaDoCliente(perfil, id) {
            if (perfil != null) {
                top.location.href = "CadastroEdicaoCliente.aspx?id=" + id;
            } else {
                top.location.href = "/Autenticacao/Login.aspx"
            }
        }
    </script>

</asp:Content>
