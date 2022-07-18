using System;
using VoteCounter.Elections;
using VoteCounter.Elections.Preferential.Optional;
using VoteCounter.Voting;
using Xunit;

namespace VoteCounter.Test.Unit.Elections.Preferential.Optional;

public class GivenABallotMarkedForBillAndFred
{
    private readonly Candidate _candidateBill;
    private readonly Candidate _candidateFred;
    private readonly OptionalPreferentialBallot _optionalPreferentialBallot;

    public GivenABallotMarkedForBillAndFred()
    {
        _candidateBill = new Candidate("Bill Gates");
        _candidateFred = new Candidate("Fred Flinstone");
        _optionalPreferentialBallot = new OptionalPreferentialBallot(
            new[] {_candidateBill, _candidateFred},
            new[]
            {
                new Preference(_candidateBill, 1),
                new Preference(_candidateFred, 2)
            });
    }

    [Fact]
    public void ThenTheFirstPreferenceIsForBill()
    {
        Assert.Equal(_candidateBill, _optionalPreferentialBallot.Primary);
    }

    [Fact]
    public void WhenBillIsEliminated_ThenTheBallotWillBeForFred()
    {
        var preference = _optionalPreferentialBallot.Preference(new[] {_candidateBill,});
        Assert.Equal(_candidateFred, preference);
    }

    [Fact]
    public void WhenBillAndFredAreEliminated_ThenTheBallotWillBeExhausted()
    {
        Assert.False(_optionalPreferentialBallot.IsExhausted(Array.Empty<Candidate>()));
        Assert.True(_optionalPreferentialBallot.IsExhausted(new[] {_candidateBill, _candidateFred}));
    }

    [Fact]
    public void ThenTheBallotWillBeFormal()
    {
        Assert.False(_optionalPreferentialBallot.IsInformal());
    }
}