using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using ProjetoCidade1.Models;
using ProjetoCidade1.Repositório;
using ProjetoCidade1.Models;
using ProjetoCidade1.Repositório;

namespace ProjetoCidade1.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoRepositório _produtoRepositorio;

        public ProdutoController(ProdutoRepositório produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IActionResult Index()
        {
            return View(_produtoRepositorio.TodosProdutos());
        }

        public IActionResult CadastrarProduto()
        {
            return View();
        }
        [HttpPost]

        public IActionResult CadastrarProduto(Produto produto)
        {

            _produtoRepositorio.CadastrarProduto(produto);

            return RedirectToAction(nameof(CadastrarProduto));
        }

        public IActionResult EditarProduto(int id)
        {

            var produto = _produtoRepositorio.ObterProduto(id);


            if (produto == null)
            {

                return NotFound();
            }


            return View(produto);
        }

        public IActionResult ExcluirProduto(int id)
        {
            _produtoRepositorio.ExcluirProduto(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
