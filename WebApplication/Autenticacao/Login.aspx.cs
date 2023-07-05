using ClassLibraryBLL.Autenticacao;
using ClassLibraryBLL.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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
            LblStatus.Text = "";
            if (!IsPostBack)
            {
                Deslogar();

                if (Session["Perfil"] !=null)
                {
                    Response.Redirect("~/Clientes/Clientes.aspx");
                }
                //Response.Redirect("~/Clientes/Clientes.aspx");
            }
        }

        private void Deslogar()
        {
            string aux = Page.Request.Url.ToString();
            string var = Page.Request.QueryString["logout"];
            if (!string.IsNullOrEmpty(var))
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                //FormsAuthentication.RedirectToLoginPage();
                Response.Redirect("/Autenticacao/Login.aspx");
            }
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
                Session["Perfil"] = usuario.Id;


                string value = Session["Perfil"].ToString();
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

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Usuario/EdicaoUsuario.aspx");
        }
    }
}