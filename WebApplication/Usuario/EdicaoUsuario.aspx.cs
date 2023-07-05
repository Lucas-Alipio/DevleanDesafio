using ClassLibraryBLL.Autenticacao;
using ClassLibraryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Usuario
{
    public partial class EdicaoUsuario : System.Web.UI.Page
    {

        private UsuarioBo _usuarioBo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (EstaEmModoEdicao())
                {
                    CarregarDadosParaEdicao();
                }
            }
        }

        protected void BtnExcluir_Click(object sender, EventArgs e)
        {
            _usuarioBo = new UsuarioBo();

            var usuario = new ClassLibraryEntities.Usuario();

            usuario.Id = ObterIdDoUsuario();
            usuario.Nome = Nome.Text;
            usuario.Email = Email.Text;
            usuario.Senha = Senha.Text;

            try
            {
                _usuarioBo.ExcluirUsuario(usuario);

                LblMessage.ForeColor = System.Drawing.Color.Green;
                LblMessage.Text = "Usuario Excluido Com Sucesso!!!";
                BtnGravas.Enabled = false;

                FormsAuthentication.SignOut();
                Session.Abandon();
                Response.Redirect("~/Autenticacao/Login.aspx");  
            }
            catch
            {
                LblMessage.ForeColor = System.Drawing.Color.Red;
                LblMessage.Text = "Ocorreu um erro ao Tentar Excluir Usuario";
            }
        }

        protected void BtnGravas_Click(object sender, EventArgs e)
        {
            _usuarioBo = new UsuarioBo();

            var usuario = new ClassLibraryEntities.Usuario();

            
            usuario.Nome = Nome.Text;
            usuario.Email = Email.Text;
            usuario.Senha = Senha.Text;

            try
            {
                if (EstaEmModoEdicao())
                {
                    usuario.Id = ObterIdDoUsuario();
                    _usuarioBo.EditarUsuario(usuario);
                }
                else
                {
                    _usuarioBo.InserirNovoUsuario(usuario);
                }
                LblMessage.ForeColor = System.Drawing.Color.Green;
                LblMessage.Text = "Informações do Usuario Salvas Com Sucesso!!!";
                BtnGravas.Enabled = false;
            }
            catch
            {
                LblMessage.ForeColor = System.Drawing.Color.Red;
                LblMessage.Text = "Ocorreu um erro ao Tentar Salvar Informações do Usuario";
            }
        }

        public int ObterIdDoUsuario()
        {
            var id = 0;
            var idQueryString = Request.QueryString["id"];
            if (int.TryParse(idQueryString, out id))
            {
                if (id <= 0)
                {
                    throw new Exception("ID Inválido");
                }

                return id;

            }
            else
            {
                throw new Exception("ID Inválido!!");
            }
        }

        private void CarregarDadosParaEdicao()
        {
            _usuarioBo = new UsuarioBo();

            var id = ObterIdDoUsuario();

            var usuario = _usuarioBo.ObterUsuarioPeloId(id);

            Nome.Text = usuario.Nome;
            Email.Text = usuario.Email;
            Senha.Text = usuario.Senha;
        }

        public bool EstaEmModoEdicao()
        {
            return Request.QueryString.AllKeys.Contains("id");
        }
    }
}