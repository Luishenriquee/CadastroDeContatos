using CadastroDeContatos.Models;
using CadastroDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CadastroDeContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.ListarUsuario();

            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarUsuarioPorId(id);
            return View(usuario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarUsuarioPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(usuario);

                _usuarioRepositorio.Adicionar(usuario);
                TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar o usuário, {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(UsuarioModel usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Editar", usuario);

                _usuarioRepositorio.EditarUsuario(usuario);
                TempData["MensagemSucesso"] = "Usuário alterado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao alterar o Usuário, {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Excluir(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.ExcluirUsuario(id);

                if (apagado)
                    TempData["MensagemSucesso"] = "Usuário excluido com Usuário!";
                else
                    TempData["MensagemErro"] = $"Erro ao excluir um Usuário";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao excluir um Usuário, {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}