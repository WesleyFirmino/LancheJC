using LanchesJC.Repositories.Interfaces;
using LanchesJC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace LanchesJC.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILanchesRepository _lanchesRepository;

        public LancheController(ILanchesRepository lanchesRepository)
        {
            _lanchesRepository = lanchesRepository;
        }

        public IActionResult List()
        {
            //var lanches = _lanchesRepository.Lanches;
            //return View(lanches);
            var lancheListViewModel = new LancheListViewModel();
            lancheListViewModel.Lanches = _lanchesRepository.Lanches;
            lancheListViewModel.CategoriaAtual = "Categoria Atual";

            return View(lancheListViewModel);
        }
    }
}
