using CadastroDeContatos.Models;
using CadastroDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            _contatoRepositorio.EditarContato(contato);
            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            _contatoRepositorio.ExcluirContato(id);
            return RedirectToAction("Index");
        }
    }
}
