using ClassLibraryBLL.Autenticacao;
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
        private ClienteBo _clienteBo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                CarregarClientesNoRepeater();
            }
            
        }

        private void CarregarClientesNoRepeater()
        {
            _clienteBo = new ClienteBo();
            RepeaterClientes.DataSource = _clienteBo.ObterTodosClientes();

            RepeaterClientes.DataBind();
        }
    }
}