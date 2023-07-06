<%@ Page Title="" Language="C#" MasterPageFile="~/Clientes/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="EdicaoUsuario.aspx.cs" Inherits="WebApplication.Usuario.EdicaoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <div class="row justify-content-center">
            <a class="col-auto justify-content-center btn btn-primary mb-5 p-2" role="button" href="EdicaoUsuario.aspx">Cadastrar Novo Usuario</a>
        </div>
    </div>
    

    <div class="container text-start mt-1">
        <div class="row">
            <label for="exempleInputEmail1" class="col-sm-2 col-form-label"> Nome: </label>
            <div class="col-sm-5">
                <asp:TextBox runat="server" ID="Nome" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RfvNome" runat="server" 
                                            ErrorMessage="Necessário preencher Nome" 
                                            ForeColor="Red" Font-Size="14px"
                                            ControlToValidate="Nome"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <label for="exempleInputEmail1" class="col-sm-2 col-form-label"> Email: </label>
            <div class="col-sm-2">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RfvEmail" runat="server" 
                                            ErrorMessage="Necessário preencher Email"
                                            ForeColor="Red" Font-Size="14px"
                                            ControlToValidate="Email"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <label for="exempleInputEmail1" class="col-sm-2 col-form-label"> Senha: </label>
            <div class="col-sm-2">
                <asp:TextBox runat="server" ID="Senha"  CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RfvSenha" runat="server"
                    ErrorMessage="Necessário preencher Senha"
                    ForeColor="Red" Font-Size="14px"
                    ControlToValidate="Senha"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row mt-4 ">
            <div class="d-grid gap-4 d-md-flex col col-lg-11">
                <asp:Button ID="BtnGravas" Text="Salvar" CssClass="btn btn-success " runat="server" OnClick="BtnGravas_Click"/>
                <asp:Button ID="BtnExcluir" Text="Excluir" CssClass="btn btn-danger " runat="server" OnClick="BtnExcluir_Click"/>
            </div>

            <div class="d-md-flex justify-content-md-end col-md-auto">
                <a href="../Clientes/Clientes.aspx" class="btn btn-primary">Voltar</a>
            </div>
        </div>
        <asp:Label runat="server" ID="LblMessage"></asp:Label>

    </div>
</asp:Content>
