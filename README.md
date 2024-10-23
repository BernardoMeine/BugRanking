# BugRanking

O **BugRanking** é um sistema para classificar desenvolvedores (BugHunters) com base na quantidade e na dificuldade dos bugs que eles solucionam. Ele utiliza uma lógica de pontuação, onde bugs resolvidos de diferentes dificuldades são contabilizados para calcular o desempenho total de cada desenvolvedor.

## Estrutura do Projeto

A aplicação está organizada em duas partes principais:

- **BugRanking.Core**: Contém as classes principais e a lógica do domínio do projeto, como os BugHunters, a resolução de bugs e os rankings.
- **BugRanking.Tests**: Projeto de testes unitários para garantir que as regras de negócio da aplicação funcionem corretamente.

## Funcionalidades

### BugHunter
Um **BugHunter** representa um desenvolvedor que resolve bugs. Cada BugHunter possui um nome, um email, e uma lista de bugs que ele resolveu, com diferentes níveis de dificuldade.

### SolvedBugs
A classe **SolvedBugs** armazena as resoluções de bugs feitas por um BugHunter. Cada resolução inclui a quantidade de bugs resolvidos e a dificuldade (easy, medium, hard ou ultrahard).

### Ranking
A classe **Ranking** organiza os BugHunters de acordo com o total de pontos acumulados, considerando a dificuldade dos bugs resolvidos. Quanto maior a dificuldade, mais pontos são atribuídos ao BugHunter.

## Tecnologias Utilizadas

- **C# (.NET 8)**: Linguagem principal para o desenvolvimento da aplicação.
- **MSTest**: Para testes unitários.

## Como Executar o Projeto

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) instalado na máquina.
- IDE com suporte a .NET, como [Visual Studio](https://visualstudio.microsoft.com/) ou [Rider](https://www.jetbrains.com/rider/).

### Passos para Executar

1. Clone este repositório:
   ```bash
   git clone https://github.com/BernardoMeine/BugRanking.git

2. Navegue até a pasta do projeto:
   ```bash
   cd BugRanking

3. Restaure as dependências:
   ```bash
   dotnet restore

4. Execute os testes para garantir que tudo está funcionando:
   ```bash
   dotnet test

## Exemplos de uso
Aqui está um exemplo de como criar um BugHunter e calcular sua pontuação:

  ```csharp
  var email = new Email("developer@example.com");
  var resolutions = new List<BugResolution>
  {
    new BugResolution(5, EDifficulty.Easy),
    new BugResolution(3, EDifficulty.Hard)
  };

  var bugHunter = new BugHunter(1, "Developer", email, new SolvedBugs(resolutions));
  var totalScore = bugHunter.GetSolvedBugsScore();
  Console.WriteLine($"Total Score: {totalScore}");
