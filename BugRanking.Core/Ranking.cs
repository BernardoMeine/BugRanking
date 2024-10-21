using BugRanking.Core.ValueObjects;

namespace BugRanking.Core;

public class Ranking
{
  public List<BugHunter> BugHunters { get; set; } = [];

  public List<BugHunter> GetRankedBugHunters()
  {
    return BugHunters
        .OrderByDescending(bugHunter => bugHunter.GetSolvedBugsScore()) // Classifica pela pontuação total
        .ToList(); // Retorna a lista ordenada
  }

  public void AddBugHunter(BugHunter bugHunter)
  {
    BugHunters.Add(bugHunter);
  }
}

/* O que eu deveria colocar nessa classe? 
  - IDEIAS:

    Criar uma classe chamada "BugHunter" que irá receber alguns ValueObjects, como por exemplo:
      - ID (pode ser int eu acho)
      - Name (string)
      - Email (ValueObject, vai ser adicionada uma validação de RegEx no campo Address)
      - SolvedBugs (ValueObject, vai ser adicionada um campo int com BugQuantity e um Enum com BugDifficulty )
    A Classe "BugHunter" fará parte da classe "Ranking" no formato de uma List.

    Deverá possuir um método que irá calcular qual foi o "melhor" bugHunter, baseado no campo SolvedBugs, que irá fazer uma conta da quantidade de bugs solucionados somados pela sua dificuldade, ex: 10 bugs nível Easy valem menos que 4 bugs nível Hard
    



*/