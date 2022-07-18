using VoteCounter.Elections.Preferential.Optional;
using VoteCounter.Test.Unit.Elections.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Elections.Preferential.Optional.Results;

public class GivenAnElectionWithASingleInformalVote
{
    private readonly OptionalPreferentialElection _optionalPreferentialElection;

    public GivenAnElectionWithASingleInformalVote()
    {
        _optionalPreferentialElection = new OptionalPreferentialElectionBuilder().Build();
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