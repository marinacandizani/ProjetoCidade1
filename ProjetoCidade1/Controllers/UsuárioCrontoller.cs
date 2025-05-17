using Microsoft.AspNetCore.Mvc;
using ProjetoCidade1.Repositório;
using ProjetoCidade1.Repositório;

namespace ProjetoCidade1.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly LoginRepositório _loginRepositorio;

        public UsuarioController(LoginRepositório loginRepositorio)
        {
            _loginRepositorio = loginRepositorio;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(string email, string senha)
        {
            var usuario = _loginRepositorio.ObterUsuario(email);

            if (usuario != null && usuario.Senha == senha)
            {
                return RedirectToAction("Index", "Cliente");
            }


            ModelState.AddModelError("", "Email ou senha inválidos.");

            return View();
        }
    }
}
