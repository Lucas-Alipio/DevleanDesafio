using ClassLibraryBLL.Exceptions;
using ClassLibraryDAL;
using ClassLibraryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            usuario.Senha = DecryptPassword(usuario.Senha);
            return usuario;
        }

        public Usuario ObterUsuarioPeloEmailESenha(string email, string senha)
        {
            var senhaEncrypted = EncryptPassword(senha);
            _usuarioDao = new UsuarioDao();

            var usuario = _usuarioDao.ObterUsuarioPeloEmailESenha(email, senhaEncrypted);

            if (usuario == null)
            {
                throw new ClienteNaoCadastradoException();
            }
            usuario.Senha = DecryptPassword(senhaEncrypted);
            return usuario;
        }

        public void InserirNovoUsuario(Usuario usuario)
        {
            usuario.Senha = EncryptPassword(usuario.Senha);
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
            usuario.Senha = EncryptPassword(usuario.Senha);
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

        public static string EncryptPassword (string senha)
        {
            string EncryptionKey = "MAKVKKKBNI99212";
            byte[] BytesNormal = Encoding.Unicode.GetBytes(senha);
            using (Aes encryptor = Aes.Create()) 
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(BytesNormal, 0, BytesNormal.Length);
                        cs.Close();
                    }

                    senha = Convert.ToBase64String(ms.ToArray());
                }
            }
            return senha;
        }

        public static string DecryptPassword(string senha)
        {
            string EncryptionKey = "MAKVKKKBNI99212";
            byte[] SenhaBytes = Convert.FromBase64String(senha);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(SenhaBytes, 0, SenhaBytes.Length);
                        cs.Close();
                    }

                    senha = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return senha;
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
