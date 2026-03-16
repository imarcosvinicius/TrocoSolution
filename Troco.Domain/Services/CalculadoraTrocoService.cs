using Troco.Domain.Exceptions;
using Troco.Domain.Interfaces;
using Troco.Domain.Models;

namespace Troco.Domain.Services;

public class CalculadoraTrocoService(ICalculadoraTroco calculadoraTroco)
{
    public IReadOnlyList<ItemTroco> Calcular(decimal valorCompra, decimal valorPago)
    {
        ValidarEntradas(valorCompra, valorPago);
        return calculadoraTroco.Calcular(valorCompra, valorPago);
    }

    private static void ValidarEntradas(decimal valorCompra, decimal valorPago)
    {
        if (valorCompra < 0 || valorPago < 0) throw new ValoresNegativosException(valorCompra, valorPago);
        if (valorCompra > valorPago) throw new ValorPagoInsuficienteException(valorCompra, valorPago);
    }
}