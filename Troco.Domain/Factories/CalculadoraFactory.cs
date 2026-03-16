using Troco.Domain.Enums;
using Troco.Domain.Interfaces;
using Troco.Domain.Strategies;

namespace Troco.Domain.Factories;

public static class CalculadoraFactory
{
    public static ICalculadoraTroco CriarCalculadoraTroco(TipoAlgoritmo tipo)
    {
        return tipo switch
        {
            TipoAlgoritmo.Greedy => new EstrategiaGreedy(),
            _ => throw new ArgumentException("Algoritmo não suportado")
        };
    }
}