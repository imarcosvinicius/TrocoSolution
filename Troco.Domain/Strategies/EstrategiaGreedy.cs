using Troco.Domain.Interfaces;

namespace Troco.Domain.Strategies;

public class EstrategiaGreedy : ICalculadoraTroco
{
    private static readonly int[] Denominacoes = [10000, 5000, 1000, 500, 100, 50, 10, 5, 1];

    private static readonly Dictionary<int, decimal> ValoresDenominacoes = new()
    {
        { 10000, 100.00m }, { 5000, 50.00m }, { 1000, 10.00m },
        { 500, 5.00m }, { 100, 1.00m }, { 50, 0.50m },
        { 10, 0.10m }, { 5, 0.05m }, { 1, 0.01m }
    };
    
    public List<(int quantidade, decimal valor)> Calcular(decimal valorCompra, decimal valorPago)
    {
        var troco = (int)Math.Round((valorPago - valorCompra) * 100);
        var resultado = new List<(int, decimal)>();

        foreach (var denominacao in Denominacoes)
        {
            var quantidade = troco / denominacao;
            if (quantidade <= 0) continue;
            resultado.Add((quantidade, ValoresDenominacoes[denominacao]));
            troco %= denominacao;
        }
        
        return resultado;
    }
}