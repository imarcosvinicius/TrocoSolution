using Troco.Domain;
using Troco.Domain.exceptions;

namespace Troco.Tests;

public class CalculadoraTrocoTest
{
    [Fact]
    public void Calcular_DeveRetornarValorTotalCorreto_QuandoValoresValidos()
    {
        var calculadora = new CalculadoraTroco();
        decimal valorCompra = 17.35m;
        decimal valorPago = 50.00m;
        decimal trocoEsperado = 32.65m;

        var resultado = calculadora.Calcular(valorCompra, valorPago);

        Assert.Equal(trocoEsperado, resultado.SomarTotal());
        Assert.Contains((3, 10.00m), resultado);
        Assert.Contains((2, 1.00m), resultado);
        Assert.Contains((1, 0.50m), resultado);
        Assert.Contains((1, 0.10m), resultado);
        Assert.Contains((1, 0.05m), resultado);
    }

    [Fact]
    public void Calcular_DeveRetornarTrocoZero_QuandoValorPagoIgualCompra()
    {
        var calculadora = new CalculadoraTroco();
        decimal valorCompra = 50.00m;
        decimal valorPago = 50.00m;
        decimal trocoEsperado = 00.00m;

        var resultado = calculadora.Calcular(valorCompra, valorPago);

        Assert.Equal(trocoEsperado, resultado.SomarTotal());
        Assert.Empty(resultado);
    }

    [Fact]
    public void Calcular_DeveLancarExecao_QuandoValorPagoInsuficiente()
    {
        var calculadora = new CalculadoraTroco();
        decimal valorCompra = 75.35m;
        decimal valorPago = 50.00m;
        
        var exception = Assert.Throws<ValorPagoInsuficienteException>(() => calculadora.Calcular(valorCompra, valorPago));
        Assert.Equal($"O valor pago (R$ {valorPago}) é insuficiente para cobrir a compra de (R$ {valorCompra}).", exception.Message);
    }
}