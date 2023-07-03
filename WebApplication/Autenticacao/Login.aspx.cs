using ClassLibraryBLL.Autenticacao;
using ClassLibraryBLL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Autenticacao
{
    public partial class Login : System.Web.UI.Page
    {
        private LoginBo _longinBo;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            _longinBo = new LoginBo();

            var emailUsuario = Email.Text;
            var senhaUsuario = Senha.Text;

            try
            {
                var usuario = _longinBo.ObterUsuarioParaLogar(emailUsuario, senhaUsuario);
                FormsAuthentication.RedirectFromLoginPage(emailUsuario, false);
            }
            catch (UsuarioNaoCadastradoException)
            {
                LblStatus.Text = "Usuario não Cadastrado!!";
            }
            catch (Exception)
            {

                LblStatus.Text = "Ocorreu um erro inesperado!!";
            }
        }
    }
}