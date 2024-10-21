using BugRanking.Core.Enums;

namespace BugRanking.Core.ValueObjects;

public class SolvedBugs(List<BugResolution> resolutions) : ValueObject
{
  public List<BugResolution> Resolutions { get; init; } = resolutions;

  public int GetTotalScore()
  {
    return Resolutions.Sum(resolution => resolution.GetResolutionScore());
  }
}