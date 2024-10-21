using BugRanking.Core.Enums;

namespace BugRanking.Core.ValueObjects;

public class BugResolution(int quantity, EDifficulty difficulty) : ValueObject
{
  public int Quantity { get; init; } = quantity;
  public EDifficulty Difficulty { get; init; } = difficulty;

  // Calcula a pontuação para essa resolução individual
  public int GetResolutionScore()
  {
    return Quantity * (int)Difficulty;
  }
}