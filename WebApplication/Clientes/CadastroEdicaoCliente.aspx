﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Clientes/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="CadastroEdicaoCliente.aspx.cs" Inherits="WebApplication.Clientes.CadastroEdicaoCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <div class="row">
            <label for="exempleInputEmail1" class="col-sm-auto col-form-label"> Nome: </label>
            <div class="col-sm-5">
                <asp:TextBox runat="server" ID="Nome" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RfvNome" runat="server" 
                                            ErrorMessage="Necessário preencher Nome" 
                                            ForeColor="Red" Font-Size="14px"
                                            ControlToValidate="Nome"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <label for="exempleInputEmail1" class="col-sm-auto col-form-label"> Tipo: </label>
            <div class="col-sm-2">
                <asp:DropDownList runat="server" ID="Type" 
                              DataValueField="" DataTextField="" 
                              CssClass="form-select"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RfvTipo" runat="server" 
                                        ErrorMessage="Necessário preencher Tipo do Documento"
                                        ForeColor="Red" Font-Size="14px"
                                        ControlToValidate="Type"></asp:RequiredFieldValidator>
            </div>   
        </div>

        <div class="row">
            <label for="exempleInputEmail1" class="col-sm-auto col-form-label"> CPF/CNPJ: </label>
            <div class="col-sm-2">
                <asp:TextBox runat="server" ID="Cpf_cnpj" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RfvCpfCnpj" runat="server" 
                                            ErrorMessage="Necessário preencher CPF/CNPJ"
                                            ForeColor="Red" Font-Size="14px"
                                            ControlToValidate="Cpf_cnpj"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <label for="exempleInputEmail1" class="col-sm-auto col-form-label"> Data de Nascimento: </label>
            <div class="col-sm-2">
                <asp:TextBox runat="server" ID="DataNascimento" TextMode="Date" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RfvDataNascimento" runat="server" 
                                            ErrorMessage="Necessário preencher data de nascimento"
                                            ForeColor="Red" Font-Size="14px"
                                            ControlToValidate="DataNascimento"></asp:RequiredFieldValidator>
            </div>
        </div>        

        <div class="row">
            <label for="exempleInputEmail1" class="col-sm-auto col-form-label"> Data de Cadastro: </label>
            <div class="col-sm-2">
                <asp:TextBox runat="server" ID="DataCadastro" TextMode="Date" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RfvDataCadastro" runat="server" 
                                            ErrorMessage="Necessário preencher data de cadastro"
                                            ForeColor="Red" Font-Size="14px"
                                            ControlToValidate="DataCadastro"></asp:RequiredFieldValidator>
            </div>
        </div>

        <asp:Button ID="BtnGravas" Text="Salvar" CssClass="btn btn-primary mt-4" runat="server" OnClick="BtnGravas_Click"/>

        <asp:Label runat="server" ID="LblMessage"></asp:Label>

        <a href="Clientes.aspx">Voltar</a>

    </div>

</asp:Content>
