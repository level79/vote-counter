using VoteCounter.Test.Unit.Election.Builders;
using VoteCounter.Test.Unit.Voting.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Election.Results;

public class GivenAnElectionWithASingleInformalVote
{
    private readonly VoteCounter.Elections.OptionalPreferentialElection _optionalPreferentialElection;

    public GivenAnElectionWithASingleInformalVote()
    {
        _optionalPreferentialElection = new ElectionBuilder().Build();
        _optionalPreferentialElection.AddBallot(new OptionalPreferentialBallotBuilder().AsInformal().Build());
    }

    [Fact]
    public void ThenTheBallotCountsWillBe()
    {
        Assert.Equal(1, _optionalPreferentialElection.TotalBallots);
        Assert.Equal(0, _optionalPreferentialElection.FormalBallots);
        Assert.Equal(1, _optionalPreferentialElection.InformalBallots);
    }
}