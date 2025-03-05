using LanchesJC.Models;
using LanchesJC.Repositories.Interfaces;
using LanchesJC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesJC.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILanchesRepository _lanchesRepository;

        public LancheController(ILanchesRepository lanchesRepository)
        {
            _lanchesRepository = lanchesRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if(string.IsNullOrEmpty(categoria))
            {
                lanches = _lanchesRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                //if(string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                //{
                //    lanches = _lanchesRepository.Lanches.Where(l => l.Categorias.Nome.Equals("Normal")).OrderBy(l => l.Nome);
                //}
                //else
                //{
                //    lanches = _lanchesRepository.Lanches.Where(l => l.Categorias.Nome.Equals(categoria)).OrderBy(l => l.Nome);
                //}

                lanches = _lanchesRepository.Lanches.Where(l => l.Categorias.Nome.Equals(categoria)).OrderBy(c => c.Nome);
                categoriaAtual = categoria;
            }

            var lancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lancheListViewModel);
        }
    }
}
