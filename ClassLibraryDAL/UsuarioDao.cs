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
    }
}
