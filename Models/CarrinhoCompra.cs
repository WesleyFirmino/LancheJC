﻿using LanchesJC.Context;
using Microsoft.EntityFrameworkCore;

namespace LanchesJC.Models;
public class CarrinhoCompra
{
    private readonly AppDbContext _context;

    public CarrinhoCompra(AppDbContext context)
    {
        _context = context;
    }

    public string? CarrinhoCompraId { get; set; }
    public List<CarrinhoCompraItem>? CarrinhoCompraItems { get; set; }
    public static CarrinhoCompra GetCarrinho(IServiceProvider services)
    {
        //Define uma Sessão
        ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        //Obtem um serviço do tipo do nosso contexto
        var context = services.GetService<AppDbContext>();

        //Atribui o id do carrinho na Sessão
        string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

        //atribui o id do carrinho na Sessão
        session.SetString("CarrinhoId", carrinhoId);

        //Retorna o carrinho com o contexto e o Id atribuido ou obtido
        return new CarrinhoCompra(context)
        {
            CarrinhoCompraId = carrinhoId
        };
    }

    public void AdicionarAoCarrinho(Lanche lanche)
    {
        var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(
            s => s.Lanche.LancheId == lanche.LancheId &&
            s.CarrinhoCompraId == CarrinhoCompraId);

        if(carrinhoCompraItem == null)
        {
            carrinhoCompraItem = new CarrinhoCompraItem
            {
                CarrinhoCompraId = CarrinhoCompraId,
                Lanche = lanche,
                Quantidade = 1
            };

            _context.CarrinhoCompraItems.Add(carrinhoCompraItem);
        }
        else
        {
            carrinhoCompraItem.Quantidade++;
        }

        _context.SaveChanges();
    }

    public int RemoverDoCarrinho(Lanche lanche)
    {
        var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(
            s => s.Lanche.LancheId == lanche.LancheId &&
            s.CarrinhoCompraId == CarrinhoCompraId);

        int quantidadeLocal = 0;

        if(carrinhoCompraItem != null)
        {
            if(carrinhoCompraItem.Quantidade > 1)
            {
                carrinhoCompraItem.Quantidade--;
                quantidadeLocal = carrinhoCompraItem.Quantidade;
            }
            else
            {
                _context.CarrinhoCompraItems.Remove(carrinhoCompraItem);
            }
        }

        _context.SaveChanges();
        return quantidadeLocal;
    }

    public List<CarrinhoCompraItem> GetCarrinhoCompraItems()
    {
        return CarrinhoCompraItems ?? (CarrinhoCompraItems = _context.CarrinhoCompraItems.Where(c => c.CarrinhoCompraId == CarrinhoCompraId).Include(s => s.Lanche).ToList());
    }

    public void LimparCarrinho()
    {
        var carrinhoiItens = _context.CarrinhoCompraItems.Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

        _context.CarrinhoCompraItems.RemoveRange(carrinhoiItens);

        _context.SaveChanges();
    }

    public decimal GetCarrinhoCompraTotal()
    {
        var total = _context.CarrinhoCompraItems
            .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
            .Select(c => c.Lanche.Preco * c.Quantidade).Sum();

        return total;
    }
}