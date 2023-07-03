<%@ Page Title="" Language="C#" MasterPageFile="~/Clientes/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="WebApplication.Clientes.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/Clientes/Cliente.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="principal">
        <asp:Repeater ID="RepeaterClientes" runat="server">
            <ItemTemplate>
                <div class="cliente-info">

                    <div><%# DataBinder.Eval(Container.DataItem, "Id") %></div>
                    <div><%# DataBinder.Eval(Container.DataItem, "Nome") %></div>
                    <div><%# DataBinder.Eval(Container.DataItem, "Tipo") %></div>
                    <div><%# DataBinder.Eval(Container.DataItem, "Cpf_Cnpj") %></div>
                    <div><%# DataBinder.Eval(Container.DataItem, "Data_Nascimento") %></div>
                    <div><%# DataBinder.Eval(Container.DataItem, "Data_Cadastro") %></div>

                </div>
            </ItemTemplate>
        </asp:Repeater>
       </div>

</asp:Content>
