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
            try
            {
                _bancoContext.Contatos.Add(contato);
                _bancoContext.SaveChanges();

                return contato;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível adicionar o contato!", ex);
            }
        }

        public ContatoModel EditarContato(ContatoModel contato)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("Não foi possível editar o contato!", ex);
            }
        }

        public bool ExcluirContato(int id)
        {
            try
            {
                ContatoModel contatoDB = ListarContatoPorId(id);

                if (contatoDB is null)
                    throw new Exception("Houve um erro ao excluir o contato!");

                _bancoContext.Contatos.Remove(contatoDB);
                _bancoContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir o contato!", ex);
            }
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
