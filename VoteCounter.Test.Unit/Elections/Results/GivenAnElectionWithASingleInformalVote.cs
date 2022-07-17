using VoteCounter.Elections;
using VoteCounter.Test.Unit.Elections.Builders;
using VoteCounter.Test.Unit.Voting.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Elections.Results;

public class GivenAnElectionWithASingleInformalVote
{
    private readonly OptionalPreferentialElection _optionalPreferentialElection;

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