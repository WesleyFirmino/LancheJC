﻿using LanchesJC.Repositories.Interfaces;
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

        public IActionResult List()
        {
            var lanches = _lanchesRepository.Lanches;
            return View(lanches);
        }
    }
}
