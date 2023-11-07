# Testes-Calculadora

Testes Unitários usando .NET Core

Neste código, o método AdicionarAoHistorico é chamado em cada método de operação da calculadora para adicionar o resultado ao histórico. O método historico também tem uma lógica para limitar o tamanho do histórico.
Adicionei os testes enumerados abaixo para garantir que a classe Calculadora seja mais robusta e capaz de lidar com uma variedade de cenários possíveis. 
Além dos 10 testes mostrados na aula foram adicionados os seguintes testes:

1.	Teste de subtração com resultado negativo.
2.	Teste de multiplicação por zero.
3.	Teste de histórico vazio após limpeza.
4.	Teste para verificar se o histórico está em ordem correta.
5.	Teste de limite de histórico para garantir que a lista não cresça indefinidamente.

Finalmente, fiz alguns ajustes no método construirClasse() da Calculadora.cs para refletir a data atual.




