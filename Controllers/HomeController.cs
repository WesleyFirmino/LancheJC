﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LanchesJC.Models;
using LanchesJC.Repositories.Interfaces;
using LanchesJC.ViewModels;

namespace LanchesJC.Controllers;

public class HomeController : Controller
{
    private readonly ILanchesRepository _lanchesRepository;

    public HomeController(ILanchesRepository lanchesRepository)
    {
        _lanchesRepository = lanchesRepository;
    }

    public IActionResult Index()
    {
        var homeViewModel = new HomeViewModel
        {
            LanchesPreferidos = _lanchesRepository.LanchesPreferidos
        };

        return View(homeViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
