using System.Collections.Generic;
using VoteCounter.Election;
using VoteCounter.Test.Unit.Election.Builders;
using VoteCounter.Test.Unit.Voting.Builders;
using VoteCounter.Voting;
using Xunit;

namespace VoteCounter.Test.Unit.Voting;

public class GivenABallotForOneCandidate
{
    private readonly Ballot _ballot;

    public GivenABallotForOneCandidate()
    {
        _ballot = new BallotBuilder().Build();
    }

    [Fact]
    public void WhenItIsCheckedAgainstAnotherCandidate_ThenItWillBeInformal()
    {
        var candidate = new CandidateBuilder().Build();
        Assert.True(_ballot.IsInformal(new List<Candidate> {candidate}));
    }
}