namespace Troco.Domain;

public class CalculadoraTroco
{
    public List<(int quantidade, decimal valor)> Calcular(decimal valorCompra, decimal valorPago)
    {
        decimal troco = valorPago - valorCompra;

        var trocoCentavos = (int)Math.Round(troco * 100);

        var trocoList = new List<(int quantidade, decimal valor)>();

        int notas100 = trocoCentavos / 10000;
        if (notas100 > 0)
        {
            trocoList.Add((notas100, 100.00m));
            trocoCentavos %= 10000;
        }

        int notas50 = trocoCentavos / 5000;
        if (notas50 > 0)
        {
            trocoList.Add((notas50, 50.00m));
            trocoCentavos %= 5000;
        }

        int notas10 = trocoCentavos / 1000;
        if (notas10 > 0)
        {
            trocoList.Add((notas10, 10.00m));
            trocoCentavos %= 1000;
        }

        int notas5 = trocoCentavos / 500;
        if (notas5 > 0)
        {
            trocoList.Add((notas5, 5.00m));
            trocoCentavos %= 500;
        }

        int moedas1 = trocoCentavos / 100;
        if (moedas1 > 0)
        {
            trocoList.Add((moedas1, 1.00m));
            trocoCentavos %= 100;
        }

        int moedas50 = trocoCentavos / 50;
        if (moedas50 > 0)
        {
            trocoList.Add((moedas50, 0.50m));
            trocoCentavos %= 50;
        }

        int moedas10 = trocoCentavos / 10;
        if (moedas10 > 0)
        {
            trocoList.Add((moedas10, 0.10m));
            trocoCentavos %= 10;
        }

        int moedas05 = trocoCentavos / 5;
        if (moedas05 > 0)
        {
            trocoList.Add((moedas05, 0.05m));
            trocoCentavos %= 5;
        }

        if (trocoCentavos > 0)
        {
            trocoList.Add((trocoCentavos, 0.01m));
        }
        
        return trocoList;
    }
}