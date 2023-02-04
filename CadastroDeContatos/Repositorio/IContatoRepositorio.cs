using CadastroDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel Adicionar(ContatoModel contato);

        List<ContatoModel> ListarContato();

        ContatoModel ListarContatoPorId(int id);

        ContatoModel EditarContato(ContatoModel contato);
    }
}
