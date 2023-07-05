using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryEntities;

namespace ClassLibraryDAL
{
    public class UsuarioDao
    {
        public Usuario ObterUsuarioPeloID(int id)
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM USUARIOS where id = @ID";

                command.Parameters.AddWithValue("@ID", id);

                Conexao.Conectar();

                var reader = command.ExecuteReader();

                Usuario usuario = null;

                while (reader.Read())
                {
                    usuario = new Usuario();

                    usuario.Id = Convert.ToInt32(reader["id"]);
                    usuario.Nome = reader["nome"].ToString();
                    usuario.Email = reader["email"].ToString();
                    usuario.Senha = reader["senha"].ToString();
                }

                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
        public Usuario ObterUsuarioPeloEmailESenha(string email, string senha)
        {
			try
			{
				var command = new SqlCommand();
				command.Connection = Conexao.connection;
				command.CommandText = "SELECT * FROM USUARIOS WHERE EMAIL = @EMAIL AND SENHA = @SENHA";
				command.Parameters.AddWithValue("@EMAIL", email);
                command.Parameters.AddWithValue("@SENHA", senha);

                Conexao.Conectar();

                var reader = command.ExecuteReader();

				Usuario usuario = null;

				while (reader.Read())
				{
                    usuario = new Usuario
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nome = Convert.ToString(reader["nome"]),
                        Email = Convert.ToString(reader["email"]),
                        Senha = Convert.ToString(reader["senha"])
                    };
                }

                return usuario;
            }
			catch (Exception)
			{
				throw;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }

        public int InserirUsuario(Usuario usuario)
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = @"INSERT INTO [dbo].[usuarios]
                                               ([nome]
                                               ,[email]
                                               ,[senha])
                                         VALUES
                                               (@NOME
                                               ,@EMAIL
                                               ,@SENHA)";

                command.Parameters.AddWithValue("@NOME", usuario.Nome);
                command.Parameters.AddWithValue("@EMAIL", usuario.Email);
                command.Parameters.AddWithValue("@SENHA", usuario.Senha);

                Conexao.Conectar();

                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }

        public int EditarUsuarioPeloID(Usuario usuario)
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = @"UPDATE [dbo].[usuarios]
                                           SET [nome] = @NOME
                                              ,[email] = @EMAIL
                                              ,[senha] = @SENHA
                                         WHERE id = @ID";

                command.Parameters.AddWithValue("@NOME", usuario.Nome);
                command.Parameters.AddWithValue("@EMAIL", usuario.Email);
                command.Parameters.AddWithValue("@SENHA", usuario.Senha);
                command.Parameters.AddWithValue("@ID", usuario.Id);

                Conexao.Conectar();

                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}
