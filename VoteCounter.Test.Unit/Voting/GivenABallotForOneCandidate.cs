using System.Collections.Generic;
using VoteCounter.Elections;
using VoteCounter.Test.Unit.Election.Builders;
using VoteCounter.Test.Unit.Voting.Builders;
using VoteCounter.Voting;
using Xunit;

namespace VoteCounter.Test.Unit.Voting;

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