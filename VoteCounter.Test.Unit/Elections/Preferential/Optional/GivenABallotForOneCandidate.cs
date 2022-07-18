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
        var candidate = new CandidateBuilder().Build();
        _optionalPreferentialBallot = new OptionalPreferentialBallotBuilder().WithCandidates(candidate).Build();
    }

    [Fact]
    public void WhenItIsCheckedAgainstAnotherCandidate_ThenItWillBeInformal()
    {
        Assert.True(_optionalPreferentialBallot.IsInformal());
    }
}