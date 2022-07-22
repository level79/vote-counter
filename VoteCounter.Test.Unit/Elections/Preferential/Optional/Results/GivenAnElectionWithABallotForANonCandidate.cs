using VoteCounter.Elections.Preferential.Optional;
using VoteCounter.Test.Unit.Elections.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Elections.Preferential.Optional.Results;

public class GivenAnElectionWithABallotForANonCandidate
{
    private readonly OptionalPreferentialElection _optionalPreferentialElection;

    public GivenAnElectionWithABallotForANonCandidate()
    {
        var candidate = new CandidateBuilder().Build();
        _optionalPreferentialElection =
            new OptionalPreferentialElectionBuilder().WithCandidates(new[] {candidate}).Build();
        _optionalPreferentialElection.NominateCandidate(candidate);
        _optionalPreferentialElection.AddBallot(new OptionalPreferentialBallotBuilder().WithCandidates(candidate)
            .Build());
    }

    [Fact]
    public void ThenTheBallotCountsWillBe()
    {
        Assert.Equal(1, _optionalPreferentialElection.TotalBallots);
        Assert.Equal(1, _optionalPreferentialElection.TotalInformalBallots);
        Assert.Equal(0, _optionalPreferentialElection.TotalFormalBallots);
    }
}