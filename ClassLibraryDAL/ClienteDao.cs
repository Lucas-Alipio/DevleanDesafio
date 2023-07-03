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
                    cliente.Tipo = Convert.ToInt16(reader["tipo"]);
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
    }
}
