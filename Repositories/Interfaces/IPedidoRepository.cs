﻿using LanchesJC.Models;

namespace LanchesJC.Repositories.Interfaces;

public interface IPedidoRepository
{
    void CriarPedido(Pedido pedido);
}