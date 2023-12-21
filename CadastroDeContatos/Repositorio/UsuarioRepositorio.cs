using CadastroDeContatos.Data;
using CadastroDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroDeContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            try
            {
                usuario.DataCadastro = DateTime.Now;
                _bancoContext.Usuarios.Add(usuario);
                _bancoContext.SaveChanges();

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível adicionar o usuário!", ex);
            }
        }

        public UsuarioModel EditarUsuario(UsuarioModel usuario)
        {
            try
            {
                UsuarioModel usuarioDB = ListarUsuarioPorId(usuario.Id);

                if (usuarioDB is null)
                    throw new Exception("Houve um erro ao edição do usuário!");

                usuarioDB.Nome = usuario.Nome;
                usuarioDB.Email = usuario.Email;
                usuarioDB.Login = usuario.Login;
                usuarioDB.Senha = usuario.Senha;
                usuarioDB.PerfilAcesso = usuario.PerfilAcesso;
                usuarioDB.DataAtualizacao = DateTime.Now;

                _bancoContext.Usuarios.Update(usuarioDB);
                _bancoContext.SaveChanges();

                return usuarioDB;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível editar o usuário!", ex);
            }
        }

        public bool ExcluirUsuario(int id)
        {
            try
            {
                UsuarioModel usuarioDB = ListarUsuarioPorId(id);

                if (usuarioDB is null)
                    throw new Exception("Houve um erro ao excluir o usuário!");

                _bancoContext.Usuarios.Remove(usuarioDB);
                _bancoContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir o usuário!", ex);
            }
        }

        public List<UsuarioModel> ListarUsuario()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel ListarUsuarioPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }
    }
}
