using VoteCounter.Test.Unit.Election.Builders;
using VoteCounter.Test.Unit.Voting.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Election.Results;

public class GivenAnElectionWithABallotForANonCandidate
{
    private readonly VoteCounter.Elections.OptionalPreferentialElection _optionalPreferentialElection;

    public GivenAnElectionWithABallotForANonCandidate()
    {
        _optionalPreferentialElection = new ElectionBuilder().Build();
        _optionalPreferentialElection.AddCandidate(new CandidateBuilder().Build());
        _optionalPreferentialElection.AddBallot(new OptionalPreferentialBallotBuilder().Build());
    }
    
    [Fact]
    public void ThenTheBallotCountsWillBe()
    {
        Assert.Equal(1, _optionalPreferentialElection.TotalBallots);
        Assert.Equal(1, _optionalPreferentialElection.InformalBallots);
        Assert.Equal(0, _optionalPreferentialElection.FormalBallots);
    }
}