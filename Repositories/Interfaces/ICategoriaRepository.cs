using LanchesJC.Models;

namespace LanchesJC.Repositories.Interfaces;

public interface ICategoriaRepository
{
    IEnumerable<Categoria> Categorias { get; }
}