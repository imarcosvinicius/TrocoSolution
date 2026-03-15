using Troco.Domain;
using Troco.Domain.Exceptions;
using Troco.Domain.Extensions;
using Troco.Domain.Services;
using Troco.Domain.Strategies;

namespace Troco.Tests;

public class CalculadoraTrocoTest
{
    private readonly CalculadoraTrocoService _calculadoraTroco;

    public CalculadoraTrocoTest()
    {
        var estrategy = new EstrategiaGreedy();
        _calculadoraTroco = new CalculadoraTrocoService(estrategy);
    }

    [Fact]
    public void Calcular_DeveRetornarValorTotalCorreto_QuandoValoresValidos()
    {
        decimal valorCompra = 17.35m;
        decimal valorPago = 50.00m;
        decimal trocoEsperado = 32.65m;

        var resultado = _calculadoraTroco.Calcular(valorCompra, valorPago);

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
        decimal valorCompra = 50.00m;
        decimal valorPago = 50.00m;
        decimal trocoEsperado = 00.00m;

        var resultado = _calculadoraTroco.Calcular(valorCompra, valorPago);

        Assert.Equal(trocoEsperado, resultado.SomarTotal());
        Assert.Empty(resultado);
    }

    [Fact]
    public void Calcular_DeveLancarExecao_QuandoValorPagoInsuficiente()
    {
        decimal valorCompra = 75.35m;
        decimal valorPago = 50.00m;
        
        var exception = Assert.Throws<ValorPagoInsuficienteException>(() => _calculadoraTroco.Calcular(valorCompra, valorPago));
        Assert.Equal($"O valor pago (R$ {valorPago}) é insuficiente para cobrir a compra de (R$ {valorCompra}).", exception.Message);
    }

    [Fact]
    public void CalcularDeveFuncionarCorretamente_ParaValoresElevados()
    {
        decimal valorCompra = 1_000_000.00m;
        decimal valorPago = 1_000_187.35m;
        decimal trocoEsperado = 187.35m;

        var resultado = _calculadoraTroco.Calcular(valorCompra, valorPago);
        Assert.Equal(trocoEsperado, resultado.SomarTotal());
        Assert.Contains((1, 100.00m), resultado);
        Assert.Contains((1, 50.00m), resultado);
        Assert.Contains((3, 10.00m), resultado);
        Assert.Contains((1, 5.00m), resultado);
        Assert.Contains((2, 1.00m), resultado);
        Assert.Contains((3, 0.10m), resultado);
        Assert.Contains((1, 0.05m), resultado);
    }
}