namespace Troco.Domain;

public static class TrocoExtensions
{
    public static decimal SomarTotal(this IEnumerable<(int quantidade, decimal valor)> itens)
    {
        return itens.Sum(x => x.quantidade * x.valor);
    }
}
