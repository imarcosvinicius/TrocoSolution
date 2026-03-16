using Troco.Domain.Models;

namespace Troco.Domain.Interfaces;

public interface ICalculadoraTroco
{
    IReadOnlyList<ItemTroco> Calcular(decimal valorCompra, decimal valorPago);
}