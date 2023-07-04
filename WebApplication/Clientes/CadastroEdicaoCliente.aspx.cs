using ClassLibraryBLL.Autenticacao;
using ClassLibraryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Clientes
{
    public partial class CadastroEdicaoCliente : System.Web.UI.Page
    {
        private ClienteBo _clientesBo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) {
                CarregarTipo();
            }
        }

        protected void BtnGravas_Click(object sender, EventArgs e)
        {
            _clientesBo = new ClienteBo();

            var cliente = new Cliente();


            cliente.Nome = Nome.Text;
            cliente.Tipo = Type.Text.ToString();
            cliente.Cpf_Cnpj = Cpf_cnpj.Text;
            cliente.Data_Nascimento = DataNascimento.Text;
            cliente.Data_Cadastro = DataCadastro.Text;
            cliente.Id_usuario = 1;

            try
            {
                _clientesBo.InserirNovoCliente(cliente);
                LblMessage.ForeColor = System.Drawing.Color.Green;
                LblMessage.Text = "Informações do Cliente Inseridas Com Sucesso!!!";
                BtnGravas.Enabled = false;
            }
            catch 
            {
                LblMessage.ForeColor = System.Drawing.Color.Red;
                LblMessage.Text = "Ocorreu um erro ao Tentar Salvar Informações do Cliente";
            }
            
        }

        private void CarregarTipo ()
        {
            List<string> types = new List<string> { "CPF", "CNPJ" };
            Type.DataSource = types;
            Type.DataBind();
        }
    }
}