using LanchesJC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesJC.Components;

public class CategoriaMenu : ViewComponent
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaMenu(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public IViewComponentResult Invoke()
    {
        var categorias = _categoriaRepository.Categorias.OrderBy(p => p.Nome);
        return View(categorias);
    }
}