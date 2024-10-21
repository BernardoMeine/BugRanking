using BugRanking.Core.Enums;
using BugRanking.Core.ValueObjects;

namespace BugRanking.Tests.ValueObjects;

[TestClass]
public class BugHunterTest
{
  private readonly List<BugResolution> resolutions = new()
  {
        new BugResolution(8, EDifficulty.Hard),
        new BugResolution(3, EDifficulty.Easy)
  };

  private readonly BugHunter _hunterBob;

  public BugHunterTest()
  {
    _hunterBob = new BugHunter(1, "Bob", new Email("bob@example.com"), new SolvedBugs(resolutions));
  }

  [TestMethod]
  public void Solved_bugs_should_match()
  {
    // Exemplo de teste - verifica se a pontuação total está correta
    int expectedScore = resolutions.Sum(r => r.Quantity * (int)r.Difficulty);
    int actualScore = _hunterBob.GetSolvedBugsScore();

    Assert.AreEqual(expectedScore, actualScore, "A pontuação dos bugs resolvidos não corresponde ao esperado.");
  }

  [TestMethod]
  public void Should_create_bug_hunter_with_valid_data()
  {
    var email = new Email("hunter@example.com");
    var solvedBugs = new SolvedBugs(new List<BugResolution>());
    var bugHunter = new BugHunter(1, "Hunter Name", email, solvedBugs);

    Assert.AreEqual(1, bugHunter.Id);
    Assert.AreEqual("Hunter Name", bugHunter.Name);
    Assert.AreEqual(email, bugHunter.Email);
    Assert.AreEqual(solvedBugs, bugHunter.SolvedBugs);
  }

  [TestMethod]
  public void Should_return_zero_if_no_solved_bugs()
  {
    var bugHunter = new BugHunter(1, "Hunter", new Email("hunter@example.com"), new SolvedBugs(new List<BugResolution>()));

    Assert.AreEqual(0, bugHunter.GetSolvedBugsScore());
  }

  [TestMethod]
  public void Should_update_score_when_bugs_are_added()
  {
    var initialResolutions = new List<BugResolution>
    {
        new(2, EDifficulty.Easy)
    };

    var bugHunter = new BugHunter(1, "Hunter", new Email("hunter@example.com"), new SolvedBugs(initialResolutions));
    Assert.AreEqual(2 * (int)EDifficulty.Easy, bugHunter.GetSolvedBugsScore());

    var newResolutions = new List<BugResolution>
    {
        new(4, EDifficulty.Medium)
    };

    bugHunter.SolvedBugs.Resolutions.AddRange(newResolutions);

    int expectedScore = (2 * (int)EDifficulty.Easy) + (4 * (int)EDifficulty.Medium);
    Assert.AreEqual(expectedScore, bugHunter.GetSolvedBugsScore());
  }

}