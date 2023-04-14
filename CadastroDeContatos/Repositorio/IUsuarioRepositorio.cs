using CadastroDeContatos.Models;
using System.Collections.Generic;

namespace CadastroDeContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel Adicionar(UsuarioModel usuario);

        List<UsuarioModel> ListarUsuario();

        UsuarioModel ListarUsuarioPorId(int id);

        UsuarioModel EditarUsuario(UsuarioModel usuario);

        bool ExcluirUsuario(int id);
    }
}
