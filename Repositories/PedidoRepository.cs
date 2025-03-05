using LanchesJC.Context;
using LanchesJC.Models;
using LanchesJC.Repositories.Interfaces;

namespace LanchesJC.Repositories;
public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;
    private readonly CarrinhoCompra _carrinhoCompra;

    public PedidoRepository(AppDbContext context, CarrinhoCompra carrinhoCompra)
    {
        _context = context;
        _carrinhoCompra = carrinhoCompra;
    }

    public void CriarPedido(Pedido pedido)
    {
        pedido.PedidoEnviado = DateTime.Now;
        _context.Pedidos.Add(pedido);
        _context.SaveChanges();
        //É necessario persistir o pedido no banco para que o ID do pedido seja criado

        var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItems;

        foreach(var carrinhoItem in carrinhoCompraItens)
        {
            var pedidoDetail = new PedidoDetalhe()
            {
                Quantidade = carrinhoItem.Quantidade,
                LancheId = carrinhoItem.Lanche.LancheId,
                PedidoId = pedido.PedidoId,
                Preco = carrinhoItem.Lanche.Preco
            };
            _context.PedidoDetalhes.Add(pedidoDetail);
        }
        _context.SaveChanges();
    }
}