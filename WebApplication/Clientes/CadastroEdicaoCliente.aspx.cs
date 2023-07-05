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

                if (EstaEmModoEdicao())
                {
                    CarregarDadosParaEdicao();
                } 
            }
        }

        protected void BtnExcluir_Click(object sender, EventArgs e)
        {

        }

        protected void BtnGravas_Click(object sender, EventArgs e)
        {
            _clientesBo = new ClienteBo();

            var cliente = new Cliente();

            cliente.Id = ObterIdDoCliente();
            cliente.Nome = Nome.Text;
            cliente.Tipo = Type.Text.ToString();
            cliente.Cpf_Cnpj = Cpf_cnpj.Text;
            cliente.Data_Nascimento = DataNascimento.Text;
            cliente.Data_Cadastro = DataCadastro.Text;
            cliente.Id_usuario = 1;

            try
            {
                if(EstaEmModoEdicao())
                {
                    _clientesBo.EditarCliente(cliente);
                }else
                {
                    _clientesBo.InserirNovoCliente(cliente);
                }
                LblMessage.ForeColor = System.Drawing.Color.Green;
                LblMessage.Text = "Informações do Cliente Salvas Com Sucesso!!!";
                BtnGravas.Enabled = false;
            }
            catch 
            {
                LblMessage.ForeColor = System.Drawing.Color.Red;
                LblMessage.Text = "Ocorreu um erro ao Tentar Salvar Informações do Cliente";
            }
        }

        private void CarregarDadosParaEdicao()
        {
            _clientesBo = new ClienteBo();

            var id = ObterIdDoCliente();

            var cliente = _clientesBo.ObterClientePeloId(id); 
            
            Nome.Text = cliente.Nome;
            Type.Text = cliente.Tipo;
            Cpf_cnpj.Text = cliente.Cpf_Cnpj;
            DataNascimento.Text = cliente.Data_Nascimento;
            DataCadastro.Text = cliente.Data_Cadastro;
        }

        public int ObterIdDoCliente()
        {
            var id = 0;
            var idQueryString = Request.QueryString["id"];
            if(int.TryParse(idQueryString, out id))
            {
                if(id <= 0)
                {
                    throw new Exception("ID Inválido");
                }

                return id;

            }else
            {
                throw new Exception("ID Inválido!!");
            }
        }
        private void CarregarTipo ()
        {
            List<string> types = new List<string> { "CPF", "CNPJ" };
            Type.DataSource = types;
            Type.DataBind();
        }

        public bool EstaEmModoEdicao()
        {
            return Request.QueryString.AllKeys.Contains("id");
        }
    }
}