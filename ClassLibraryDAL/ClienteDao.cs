using ClassLibraryEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
    public class ClienteDao
    {
        public List<Cliente> ObterTodosClientes()
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM CLIENTE";

                Conexao.Conectar();

                var reader = command.ExecuteReader();

                var clientes = new List<Cliente>();

                while (reader.Read())
                {
                    var cliente = new Cliente();

                    cliente.Id = Convert.ToInt32(reader["Id"]);
                    cliente.Nome = reader["nome"].ToString();
                    cliente.Tipo = reader["tipo"].ToString();
                    cliente.Cpf_Cnpj = reader["cpf_cnpj"].ToString();
                    cliente.Data_Nascimento = Convert.ToDateTime(reader["data_nascimento"]).ToString("yyyy-MM-dd");
                    cliente.Data_Cadastro = Convert.ToDateTime(reader["data_cadastro"]).ToString("yyyy-MM-dd");

                    clientes.Add(cliente);
                }

                return clientes;
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

        public int InserirCliente(Cliente cliente)
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = @"INSERT INTO [dbo].[cliente]
                                               ([nome]
                                               ,[tipo]
                                               ,[cpf_cnpj]
                                               ,[data_nascimento]
                                               ,[data_cadastro]
                                               ,[id_usuario])
                                         VALUES
                                               (@NOME
                                               ,@TIPO
                                               ,@CPF_CNPJ
                                               ,@DATA_NASCIMENTO
                                               ,@DATA_CADASTRO
                                               ,@ID_USUARIO)";

                command.Parameters.AddWithValue("@NOME",cliente.Nome);
                command.Parameters.AddWithValue("@TIPO", cliente.Tipo);
                command.Parameters.AddWithValue("@CPF_CNPJ", cliente.Cpf_Cnpj);
                command.Parameters.AddWithValue("@DATA_NASCIMENTO", Convert.ToDateTime(cliente.Data_Nascimento));
                command.Parameters.AddWithValue("@DATA_CADASTRO", Convert.ToDateTime(cliente.Data_Cadastro));
                command.Parameters.AddWithValue("@ID_USUARIO", cliente.Id_usuario);

                Conexao.Conectar();

                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }finally { 
                Conexao.Desconectar();
            }
        }
    }
}
