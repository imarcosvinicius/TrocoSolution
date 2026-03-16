using Troco.Domain.Enums;
using Troco.Domain.Exceptions;
using Troco.Domain.Factories;
using Troco.Domain.Interfaces;

namespace Troco.Domain.Services;

public class CalculadoraTrocoService(TipoAlgoritmo tipoAlgoritmo)
{
    private readonly ICalculadoraTroco _calculadoraTroco = CalculadoraFactory.CriarCalculadoraTroco(tipoAlgoritmo);

    public List<(int quantidade, decimal valor)> Calcular(decimal valorCompra, decimal valorPago)
    {
        if (valorCompra < 0 || valorPago < 0) throw new ValoresNegativosException(valorCompra, valorPago);
        if (valorCompra > valorPago) throw new ValorPagoInsuficienteException(valorCompra, valorPago);
        return _calculadoraTroco.Calcular(valorCompra, valorPago);
    }
}