using System.Collections.Generic;
using VoteCounter.Elections;
using VoteCounter.Elections.Preferential.Optional;
using VoteCounter.Test.Unit.Elections.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Elections.Preferential.Optional;

public class GivenABallotForOneCandidate
{
    private readonly OptionalPreferentialBallot _optionalPreferentialBallot;

    public GivenABallotForOneCandidate()
    {
        _optionalPreferentialBallot = new OptionalPreferentialBallotBuilder().Build();
    }

    [Fact]
    public void WhenItIsCheckedAgainstAnotherCandidate_ThenItWillBeInformal()
    {
        var candidate = new CandidateBuilder().Build();
        Assert.True(_optionalPreferentialBallot.IsInformal(new List<Candidate> {candidate}));
    }
}