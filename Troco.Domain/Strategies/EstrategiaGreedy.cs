using Troco.Domain.Interfaces;
using Troco.Domain.Models;

namespace Troco.Domain.Strategies;

public class EstrategiaGreedy : ICalculadoraTroco
{
    private static readonly (int Centavos, decimal Valor)[] ValoresDenominacoes = [
        ( 10000, 100.00m ), ( 5000, 50.00m ), ( 1000, 10.00m ),
        ( 500, 5.00m ), ( 100, 1.00m ), ( 50, 0.50m ),
        ( 10, 0.10m ), ( 5, 0.05m ), ( 1, 0.01m )
    ];
    
    public IReadOnlyList<ItemTroco> Calcular(decimal valorCompra, decimal valorPago)
    {
        var troco = (int)Math.Round((valorPago - valorCompra) * 100);
        var resultado = new List<ItemTroco>();

        foreach (var valores in ValoresDenominacoes)
        {
            var quantidade = troco / valores.Centavos;
            if (quantidade <= 0) continue;
            resultado.Add(new ItemTroco(quantidade, valores.Valor));
            troco %= valores.Centavos;
        }
        
        return resultado;
    }
}