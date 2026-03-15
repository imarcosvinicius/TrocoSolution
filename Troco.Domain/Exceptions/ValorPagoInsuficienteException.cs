namespace Troco.Domain.Exceptions;

public class ValorPagoInsuficienteException : ArgumentException
{
    public ValorPagoInsuficienteException(decimal valorCompra, decimal valorPago) 
        : base($"O valor pago (R$ {valorPago}) é insuficiente para cobrir a compra de (R$ {valorCompra}).")
    {
    }
}