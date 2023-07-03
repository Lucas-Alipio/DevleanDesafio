using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntities
{
    public class Usuario:IntId
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

    }
}
