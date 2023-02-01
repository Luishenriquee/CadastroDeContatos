using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeContatos.Models
{
    public class ContatoModel
    {
        public int ContatoId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Celular { get; set; }
    }
}
