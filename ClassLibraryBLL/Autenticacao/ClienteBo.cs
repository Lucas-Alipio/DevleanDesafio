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
    public class ClienteBo
    {
        private ClienteDao _clienteDao;

        public List<Cliente> ObterTodosClientes()
        {
            _clienteDao = new ClienteDao();

            return _clienteDao.ObterTodosClientes();
        }

        public Cliente ObterClientePeloId(int id)
        {
            _clienteDao = new ClienteDao();

            var cliente = _clienteDao.ObterClientePeloID(id);

            if (cliente == null)
            {
                throw new ClienteNaoCadastradoException();
            }

            return cliente;
        }

        public void InserirNovoCliente(Cliente cliente)
        {
            _clienteDao = new ClienteDao();

            ValidarCliente(cliente);

            var linhasAfetadas = _clienteDao.InserirCliente(cliente);
            
            if(linhasAfetadas == 0)
            {
                throw new ClienteNaoCadastradoException();
            }
        }

        public void EditarCliente(Cliente cliente)
        {
            _clienteDao = new ClienteDao();

            ValidarCliente(cliente);

            var linhasAfetadas = _clienteDao.EditarClientePeloID(cliente);

            if (linhasAfetadas == 0)
            {
                throw new ClienteNaoCadastradoException();
            }
        }

        public void ExcluirCliente(int id)
        {
            _clienteDao = new ClienteDao();

            var linhasAfetadas = _clienteDao.ExcluirClientePeloID(id);

            if (linhasAfetadas == 0)
            {
                throw new ClienteNaoCadastradoException();
            }
        }

        public void ValidarCliente(Cliente cliente)
        {
            if(string.IsNullOrWhiteSpace(cliente.Nome) || 
                string.IsNullOrWhiteSpace(cliente.Tipo) ||
                string.IsNullOrWhiteSpace(cliente.Cpf_Cnpj) ||
                string.IsNullOrWhiteSpace(cliente.Data_Nascimento) ||
                string.IsNullOrWhiteSpace(cliente.Data_Cadastro) || 
                cliente.Id_usuario.ToString() == null )
            {
                throw new ClienteInvalidoException();
            }
        }
    }
}
