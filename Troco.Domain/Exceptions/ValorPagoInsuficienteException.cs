namespace Troco.Domain.Exceptions;

public class ValorPagoInsuficienteException(decimal valorCompra, decimal valorPago)
    : ArgumentException($"O valor pago (R$ {valorPago}) é insuficiente para cobrir a compra de (R$ {valorCompra}).");