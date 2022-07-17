using VoteCounter.Test.Unit.Election.Builders;
using VoteCounter.Test.Unit.Voting.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Election.Results;

public class GivenAnElectionWithASingleInformalVote
{
    private readonly VoteCounter.Election.Election _election;

    public GivenAnElectionWithASingleInformalVote()
    {
        _election = new ElectionBuilder().Build();
        _election.AddBallot(new BallotBuilder().AsInformal().Build());
    }

    [Fact]
    public void ThenTheBallotCountsWillBe()
    {
        Assert.Equal(1, _election.TotalBallots);
        Assert.Equal(0, _election.FormalBallots);
        Assert.Equal(1, _election.InformalBallots);
    }
}