using BugRanking.Core;
using BugRanking.Core.Enums;
using BugRanking.Core.ValueObjects;

namespace BugRanking.Tests;

[TestClass]
public class RankingTest
{

  [TestMethod]
  public void Should_rank_bughunters_correctly()
  {
    var hunter1 = new BugHunter(1, "Hunter 1", new Email("hunter1@example.com"), new SolvedBugs(
    [
        new(10, EDifficulty.Easy)
    ]));

    var hunter2 = new BugHunter(2, "Hunter 2", new Email("hunter2@example.com"), new SolvedBugs(
    [
        new(5, EDifficulty.Hard)
    ]));

    var ranking = new Ranking();
    ranking.AddBugHunter(hunter1);
    ranking.AddBugHunter(hunter2);

    var rankedHunters = ranking.GetRankedBugHunters();

    Assert.AreEqual("Hunter 2", rankedHunters[0].Name);
    Assert.AreEqual("Hunter 1", rankedHunters[1].Name);
  }

}