using VoteCounter.Election;
using VoteCounter.Test.Unit.Election.Builders;
using VoteCounter.Test.Unit.Voting.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Election.Results;

public class GivenAnElectorateWithASingleInformalVote
{
    private readonly Electorate _electorate;

    public GivenAnElectorateWithASingleInformalVote()
    {
        _electorate = new ElectorateBuilder().Build();
        _electorate.AddBallot(new BallotBuilder().AsInformal().Build());
    }

    [Fact]
    public void ThenTheBallotCountsWillBe()
    {
        Assert.Equal(1, _electorate.TotalBallots);
        Assert.Equal(1, _electorate.InformalBallots);
        Assert.Equal(0, _electorate.FormalBallots);
    }
}