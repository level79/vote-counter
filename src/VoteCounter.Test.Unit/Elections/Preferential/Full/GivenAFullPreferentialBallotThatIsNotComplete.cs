using VoteCounter.Elections.Preferential.Full;
using VoteCounter.Test.Unit.Elections.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Elections.Preferential.Full;

public class GivenAFullPreferentialBallotThatIsNotComplete
{
    private readonly FullPreferentialBallot _fullPreferentialBallot;

    public GivenAFullPreferentialBallotThatIsNotComplete()
    {
        var candidate1 = new CandidateBuilder().Build();
        var candidate2 = new CandidateBuilder().Build();
        _fullPreferentialBallot = new FullPreferentialBallotBuilder().WithCandidates(candidate1, candidate2)
            .ForCandidates(candidate1).Build();
    }

    [Fact]
    public void ThenItWillBeInformal()
    {
        Assert.Equal(true, _fullPreferentialBallot.IsInformal());
    }
}