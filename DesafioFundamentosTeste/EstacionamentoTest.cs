using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace DesafioFundamentosTeste
{
    public class EstacionamentoTest
    {
        [Fact]
        public void TesteAdicionarVeiculo()
        {
            // Arrange
            var estacionamento = new Estacionamento(3,2);
            var input = "ABC123"; // Placa de veículo de exemplo para entrada

            using var consoleInput = new StringReader(input);
            Console.SetIn(consoleInput);

            // Act
            estacionamento.AdicionarVeiculo();

            // Assert
            var veiculoAdicionado = estacionamento.GetVeiculos();
            Assert.Equal(input, veiculoAdicionado[0]);
        }

        [Fact]
        public void TesteRemoverVeiculo()
        {
            // Arrange
            var estacionamento = new Estacionamento(3,2);
            var placa = "ABC123"; // Placa de veículo de exemplo
            var horas = 3; // Horas de exemplo
            var consoleOutput = new StringWriter();

            // Redirecionar a saída do console
            Console.SetOut(consoleOutput);

            using var consoleInput = new StringReader($"{placa}{Environment.NewLine}{placa}{Environment.NewLine}{horas}{Environment.NewLine}");
            Console.SetIn(consoleInput);

            // Adicione o veículo ao estacionamento
            estacionamento.AdicionarVeiculo();

            // Act
            estacionamento.RemoverVeiculo();

            // Assert
            // Verifique se o veículo foi removido
            Assert.DoesNotContain(placa, estacionamento.GetVeiculos());

            // Verifique se a saída contém o preço total
            // Obtenha a saída do console
            var output = consoleOutput.ToString();
            // Restaure a saída padrão
            Console.SetOut(Console.Out);
            decimal valorTotal = estacionamento.GetPrecoInicial() + (estacionamento.GetPrecoPorHora() * horas);
            Assert.Contains($"O veículo \"{placa}\" foi removido e o preço total foi de R$ {valorTotal}", output);
        }

        [Fact]
        public void TesteRemoverVeiculoNaoEstacionado()
        {
            // Arrange
            var estacionamento = new Estacionamento(3,2);
            var placa = "XYZ789"; // Placa de veículo não estacionado
            var consoleOutput = new StringWriter();

            // Redirecionar a saída do console
            Console.SetOut(consoleOutput);

            using var consoleInput = new StringReader(placa);
            Console.SetIn(consoleInput);

            // Act
            estacionamento.RemoverVeiculo();

            // Assert
            // Verifique se a saída indica que o veículo não está estacionado
            // Obtenha a saída do console
            var output = consoleOutput.ToString();
            // Restaure a saída padrão
            Console.SetOut(Console.Out);
            Assert.Contains("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente", output);
        }

    }
}