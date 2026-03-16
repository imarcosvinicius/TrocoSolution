namespace Troco.Domain.Exceptions;

public class ValoresNegativosException(decimal valorCompra, decimal valorPago) 
    : ArgumentException($"Valores negativos não são permitidos. Valor de compra: R$ {valorCompra}, Valor pago: R$ {valorPago}.");