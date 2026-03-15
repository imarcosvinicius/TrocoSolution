using Troco.Domain.Interfaces;

namespace Troco.Domain.Services;

public class CalculadoraTrocoService(ICalculadoraTroco strategy)
{
    public List<(int quantidade, decimal valor)> Calcular(decimal valorCompra, decimal valorPago)
    {
        return strategy.Calcular(valorCompra, valorPago);
    }
}