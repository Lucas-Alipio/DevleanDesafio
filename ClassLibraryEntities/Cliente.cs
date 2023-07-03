using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntities
{
    public class Cliente:IntId
    {
        public string Nome { get; set; }

        //True = CPF / False = CNPJ
        public bool Tipo { get; set; }

        public string Cpf_Cnpj { get; set; }

        public DateTime Data_Nascimento { get; set; }

        public DateTime Data_Cadastro { get; set; }



    }
}
