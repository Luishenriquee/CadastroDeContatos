using CadastroDeContatos.Data;
using CadastroDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

        public ContatoModel EditarContato(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarContatoPorId(contato.Id);

            if (contatoDB is null) 
                throw new Exception("Houve um erro ao edição do contato!");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }

        public bool ExcluirContato(int id)
        {
            ContatoModel contatoDB = ListarContatoPorId(id);

            if (contatoDB is null)
                throw new Exception("Houve um erro ao excluir o contato!");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public List<ContatoModel> ListarContato()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel ListarContatoPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }
    }
}
