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
                <div class="card text-bg-primary" style="width: 18rem; margin:8px; padding:3px; cursor:pointer;">
                    <div class="card-body" onclick="redirecionarParaPaginaDoCliente('<%= Session["Perfil"].ToString() %>', <%#DataBinder.Eval(Container.DataItem, "Id") %>)">
                        
                        <h4 class="card-title"><%# DataBinder.Eval(Container.DataItem, "Nome") %></h4>
                        <p class="card-text">ID: <%# DataBinder.Eval(Container.DataItem, "Id") %></p>
                        
                        <p class="card-text">Tipo: <%# DataBinder.Eval(Container.DataItem, "Tipo") %></p>
                        <p class="card-text">CPF/CNPJ: <%# DataBinder.Eval(Container.DataItem, "Cpf_Cnpj") %></p>
                        <p class="card-text">Data de Nascimento: <%# DataBinder.Eval(Container.DataItem, "Data_Nascimento") %></p>
                        <p class="card-text">Data de Cadastro: <%# DataBinder.Eval(Container.DataItem, "Data_Cadastro") %></p>

                    </div>
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
