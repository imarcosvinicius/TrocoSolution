namespace Troco.Domain.Interfaces;

public interface ICalculadoraTroco
{
    public List<(int quantidade, decimal valor)> Calcular(decimal valorCompra, decimal valorPago);
}