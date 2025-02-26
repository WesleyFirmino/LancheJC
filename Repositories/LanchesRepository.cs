using LanchesJC.Context;
using LanchesJC.Models;
using LanchesJC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesJC.Repositories;
public class LanchesRepository : ILanchesRepository
{
    private readonly AppDbContext _context;

    public LanchesRepository(AppDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categorias);

    public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.Where(p => p.IsLanchePreferido).Include(c => c.Categorias);

    public Lanche GetLancheById(int lancheId)
    {
        return _context.Lanches.FirstOrDefault(i => i.LancheId == lancheId);
    }
}
