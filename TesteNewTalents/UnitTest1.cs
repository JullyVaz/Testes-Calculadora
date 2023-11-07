using System;
using Xunit;
using NewTalents;

namespace TesteNewTalents
{
    public class UnitTest1
    {

        private string dataAtualString; // Modificação da declaração

        public Calculadora construirClasse()
        {
            DateTime dataAtual = DateTime.Now;
            dataAtualString = dataAtual.ToString("dd/MM/yyyy"); // Atualiza a dataAtualString com a data atual
            Calculadora calc = new Calculadora(dataAtualString);
            return calc;
        }



        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 9)]
        public void TesteSomar(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.somar(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }
        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]
        public void TesteMultiplicar(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.multiplicar(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }
        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(5, 5, 1)]
        public void TesteDividir(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.dividir(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }
        [Theory]
        [InlineData(6, 2, 4)]
        [InlineData(5, 5, 0)]
        public void TesteSubtrair(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.subtrair(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Fact]
        public void TestarDivisaoporZero()
        {
            Calculadora calc = construirClasse();

            Assert.Throws<DivideByZeroException>(
                () => calc.dividir(3, 0)
                );
        }

        [Fact]
        public void TestarHistorico()

        {
            Calculadora calc = construirClasse();

            calc.somar(1, 2);
            calc.somar(2, 8);
            calc.somar(3, 7);
            calc.somar(4, 1);

            var lista = calc.historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);

        }
        [Fact]
        public void TestarSubtracaoResultadoNegativo()
        {
            Calculadora calc = construirClasse();
            int resultadoCalculadora = calc.subtrair(1, 2);
            Assert.Equal(-1, resultadoCalculadora);
        }

        [Fact]
        public void TestarMultiplicacaoPorZero()
        {
            Calculadora calc = construirClasse();
            int resultadoCalculadora = calc.multiplicar(5, 0);
            Assert.Equal(0, resultadoCalculadora);
        }

        [Fact]
        public void TestarLimpezaHistorico()
        {
            Calculadora calc = construirClasse();
            calc.somar(1, 2);
            calc.somar(2, 8);
            calc.somar(3, 7);
            calc.limparHistorico();
            var lista = calc.historico();
            Assert.Empty(lista);

        }

        [Fact]
        public void TestarOrdemHistorico()
        {
            Calculadora calc = construirClasse();
            calc.somar(1, 2);
            calc.subtrair(2, 1);
            calc.multiplicar(2, 3);
            var lista = calc.historico();
            Assert.StartsWith($"Res:6 - data: {dataAtualString}", lista[0]);
            Assert.StartsWith($"Res:1 - data: {dataAtualString}", lista[1]);
            Assert.StartsWith($"Res:3 - data: {dataAtualString}", lista[2]);

        }

        [Fact]
        public void TestarLimiteHistorico()
        {
            Calculadora calc = construirClasse();
            calc.somar(1, 2);
            calc.subtrair(2, 1);
            calc.multiplicar(2, 3);
            calc.dividir(4, 2);
            var lista = calc.historico();
            //Assert.Equal(3, lista.Count);
            Assert.Equal("O", lista.Count.ToString());

        }
    }
}

