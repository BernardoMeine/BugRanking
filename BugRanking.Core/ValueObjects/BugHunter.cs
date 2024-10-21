namespace BugRanking.Core.ValueObjects;

public class BugHunter(int id, string name, Email email, SolvedBugs solvedBugs) : ValueObject
{
  public int Id { get; init; } = id;
  public string Name { get; init; } = name;
  public Email Email { get; init; } = email;
  public SolvedBugs SolvedBugs { get; init; } = solvedBugs;

  public int GetSolvedBugsScore()
  {
    return SolvedBugs.GetTotalScore();
  }
}

/*
  Criar uma classe chamada "BugHunter" que irá receber alguns ValueObjects, como por exemplo:
      - ID (pode ser int eu acho)
      - Name (string)
      - Email (ValueObject, vai ser adicionada uma validação de RegEx no campo Address)
      - SolvedBugs (ValueObject, vai ser adicionada um campo int com BugQuantity e um Enum com BugDifficulty )
    A Classe "BugHunter" fará parte da classe "Ranking" no formato de uma List.
 */