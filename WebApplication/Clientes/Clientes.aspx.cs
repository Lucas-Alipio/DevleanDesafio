using ClassLibraryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Clientes
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarClientesNoRepeater();
        }

        private void CarregarClientesNoRepeater()
        {
            RepeaterClientes.DataSource = new List<Cliente>
            {
                new Cliente
                {
                    Id = 1,
                    Nome = "lucas",
                    Tipo = false,
                    Cpf_Cnpj ="xxxxxx",
                    Data_Nascimento = new DateTime(2000, 01, 28).ToString("yyyy-MM-dd"),
                    Data_Cadastro = DateTime.Today.ToString("yyyy-MM-dd"),
                },

                new Cliente
                {
                    Id = 1,
                    Nome = "lucas2",
                    Tipo = false,
                    Cpf_Cnpj ="yyyyyy",
                    Data_Nascimento = new DateTime(2000, 01, 29).ToString("yyyy-MM-dd"),
                    Data_Cadastro = DateTime.Today.ToString("yyyy-MM-dd"),
                },

                new Cliente
                {
                    Id = 1,
                    Nome = "lucas3",
                    Tipo = false,
                    Cpf_Cnpj ="zzzzz",
                    Data_Nascimento = new DateTime(2000, 01, 20).ToString("yyyy-MM-dd"),
                    Data_Cadastro = DateTime.Today.ToString("yyyy-MM-dd"),
                },
            };

            RepeaterClientes.DataBind();
        }
    }
}