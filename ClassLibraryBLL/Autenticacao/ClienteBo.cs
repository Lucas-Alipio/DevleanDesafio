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
    }
}
