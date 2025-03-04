﻿using LanchesJC.Models;
using LanchesJC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesJC.Controllers;
public class PedidoController : Controller
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly CarrinhoCompra _carrinhoCompra;

    public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
    {
        _pedidoRepository = pedidoRepository;
        _carrinhoCompra = carrinhoCompra;
    }

    public IActionResult Checkout()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Checkout(Pedido pedido)
    {
        int totalItensPedido = 0;
        decimal precoTotalPedido = 0.0m;

        //Obtem os itens do carrinhos de compra do cliente
        List<CarrinhoCompraItem> items = _carrinhoCompra.GetCarrinhoCompraItems();
        _carrinhoCompra.CarrinhoCompraItems = items;

        //Verifica se existem itens de pedido
        if(_carrinhoCompra.CarrinhoCompraItems.Count == 0)
        {
            ModelState.AddModelError("", "Seu carrinho esta vazio, que tal incluir um lanche...");
        }

        //Calcular o total de itens e o total do pedido
        foreach (var item in items)
        {
            totalItensPedido += item.Quantidade;
            precoTotalPedido += (item.Lanche.Preco * item.Quantidade);
        }

        //Atribui os valores obtidos ao pedido
        pedido.TotalItensPedido = totalItensPedido;
        pedido.PedidoTotal = precoTotalPedido;

        //Valida os dados do pedido
        if(ModelState.IsValid)
        {
            //Cria o pedido e os detalhes
            _pedidoRepository.CriarPedido(pedido);

            //Define mensagem ao cliente
            ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido :)";
            ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();

            //Limpa o carrinho do Cliente
            _carrinhoCompra.LimparCarrinho();

            //Exibe a view com dados do cliente e do pedido
            return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
        }

        return View(pedido);
    }
}