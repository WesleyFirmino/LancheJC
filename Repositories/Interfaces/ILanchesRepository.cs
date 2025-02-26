using LanchesJC.Models;

namespace LanchesJC.Repositories.Interfaces;

public interface ILanchesRepository
{
    IEnumerable<Lanche> Lanches { get; }
    IEnumerable<Lanche> LanchesPreferidos { get; }
    Lanche GetLancheById(int lancheId);
}