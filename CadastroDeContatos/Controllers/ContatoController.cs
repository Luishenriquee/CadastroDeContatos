using CadastroDeContatos.Models;
using CadastroDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CadastroDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.ListarContato();

            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarContatoPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarContatoPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(contato);

                _contatoRepositorio.Adicionar(contato);
                TempData["MensagemSucesso"] = Mensagens.Mensagens.MSG0001;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = string.Format(Mensagens.Mensagens.MSG0002, ex);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Editar", contato);

                _contatoRepositorio.EditarContato(contato);
                TempData["MensagemSucesso"] = Mensagens.Mensagens.MSG0003;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = string.Format(Mensagens.Mensagens.MSG0004, ex);
                return RedirectToAction("Index");
            }
        }

        public IActionResult Excluir(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.ExcluirContato(id);

                if (apagado)
                    TempData["MensagemSucesso"] = Mensagens.Mensagens.MSG0005;
                else
                    TempData["MensagemErro"] = Mensagens.Mensagens.MSG0006;

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = string.Format(Mensagens.Mensagens.MSG0006, ex);
                return RedirectToAction("Index");
            }
        }
    }
}
