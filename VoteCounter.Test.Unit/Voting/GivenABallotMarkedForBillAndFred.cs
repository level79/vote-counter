using System;
using System.Collections.Generic;
using VoteCounter.Election;
using VoteCounter.Test.Unit.Election.Builders;
using VoteCounter.Test.Unit.Voting.Builders;
using VoteCounter.Voting;
using Xunit;

namespace VoteCounter.Test.Unit.Voting;

public class GivenABallotForOnceCandidate
{
    private readonly Ballot _ballot;

    public GivenABallotForOnceCandidate()
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
public class GivenABallotMarkedForBillAndFred
{
    private readonly Candidate _candidateBill;
    private readonly Candidate _candidateFred;
    private readonly Ballot _ballot;

    public GivenABallotMarkedForBillAndFred()
    {
        _candidateBill = new Candidate("Bill Gates");
        _candidateFred = new Candidate("Fred Flinstone");
        _ballot = new Ballot(new []
        {
            new Preference(_candidateBill, 1),
            new Preference(_candidateFred, 2)
        });
    }

    [Fact]
    public void ThenTheFirstPreferenceIsForBill()
    {
        Assert.Equal(_candidateBill, _ballot.Primary);
    }

    [Fact]
    public void WhenBillIsEliminated_ThenTheBallotWillBeForFred()
    {
        var preference = _ballot.Preference(new []{ _candidateBill,});
        Assert.Equal(_candidateFred, preference);
    }

    [Fact]
    public void WhenBillAndFredAreEliminated_ThenTheBallotWillBeExhausted()
    {
        Assert.False(_ballot.IsExhausted(Array.Empty<Candidate>()));
        Assert.True(_ballot.IsExhausted(new []{_candidateBill, _candidateFred}));
    }

    [Fact]
    public void ThenTheBallotWillBeFormal()
    {
        Assert.False(_ballot.IsInformal(new []{_candidateBill, _candidateFred}));
    }
}