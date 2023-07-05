using ClassLibraryBLL.Exceptions;
using ClassLibraryDAL;
using ClassLibraryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryBLL.Autenticacao
{
    public class UsuarioBo
    {
        private UsuarioDao _usuarioDao;

        public Usuario ObterUsuarioPeloId(int id)
        {
            _usuarioDao = new UsuarioDao();

            var usuario = _usuarioDao.ObterUsuarioPeloID(id);

            if (usuario == null)
            {
                throw new ClienteNaoCadastradoException();
            }

            return usuario;
        }

        public Usuario ObterUsuarioPeloEmailESenha(string email, string senha)
        {
            _usuarioDao = new UsuarioDao();

            var usuario = _usuarioDao.ObterUsuarioPeloEmailESenha(email, senha);

            if (usuario == null)
            {
                throw new ClienteNaoCadastradoException();
            }

            return usuario;
        }

        public void InserirNovoUsuario(Usuario usuario)
        {
            _usuarioDao = new UsuarioDao();

            ValidarUsuario(usuario);

            var linhasAfetadas = _usuarioDao.InserirUsuario(usuario);

            if (linhasAfetadas == 0)
            {
                throw new ClienteNaoCadastradoException();
            }
        }

        public void EditarUsuario(Usuario usuario)
        {
            _usuarioDao = new UsuarioDao();

            ValidarUsuario(usuario);

            var linhasAfetadas = _usuarioDao.EditarUsuarioPeloID(usuario);

            if (linhasAfetadas == 0)
            {
                throw new ClienteNaoCadastradoException();
            }
        }

        public void ExcluirUsuario(Usuario usuario)
        {
            _usuarioDao = new UsuarioDao();

            ValidarUsuario(usuario);

            var linhasAfetadas = _usuarioDao.ExcluirUsuarioPeloID(usuario);

            if (linhasAfetadas == 0)
            {
                throw new ClienteNaoCadastradoException();
            }
        }

        public void ValidarUsuario(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nome) ||
                string.IsNullOrWhiteSpace(usuario.Email) ||
                string.IsNullOrWhiteSpace(usuario.Senha))
            {
                throw new ClienteInvalidoException();
            }
        }
    }
}
