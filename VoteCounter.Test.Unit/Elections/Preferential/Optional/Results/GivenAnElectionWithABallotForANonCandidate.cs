using VoteCounter.Elections.Preferential.Optional;
using VoteCounter.Test.Unit.Elections.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Elections.Preferential.Optional.Results;

public class GivenAnElectionWithABallotForANonCandidate
{
    private readonly OptionalPreferentialElection _optionalPreferentialElection;

    public GivenAnElectionWithABallotForANonCandidate()
    {
        _optionalPreferentialElection = new OptionalPreferentialElectionBuilder().Build();
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