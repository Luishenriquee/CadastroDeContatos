using Microsoft.AspNetCore.Mvc;

namespace CadastroDeContatos.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
