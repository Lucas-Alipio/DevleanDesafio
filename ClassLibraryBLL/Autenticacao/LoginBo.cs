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
    public class LoginBo
    {
        private UsuarioDao _usuarioDao;

        public Usuario ObterUsuarioParaLogar (string email, string senha)
        {
            _usuarioDao = new UsuarioDao();

            var senhaEncrypted = UsuarioBo.EncryptPassword(senha);

            var usuario = _usuarioDao.ObterUsuarioPeloEmailESenha(email, senhaEncrypted);
            
            if(usuario == null)
            {
                throw new UsuarioNaoCadastradoException();
            }else {
                return usuario;
            }
        }
    }
}
