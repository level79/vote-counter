using VoteCounter.Elections.Preferential.Full;
using VoteCounter.Test.Unit.Elections.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Elections.Preferential.Full;

public class GivenAFullPreferentialBallotThatNominatesAllPreferences
{
    private FullPreferentialBallot _fullPreferentialBallot;

    public GivenAFullPreferentialBallotThatNominatesAllPreferences()
    {
        _fullPreferentialBallot = new FullPreferentialBallotBuilder().Build();
    }

    [Fact]
    public void ThenItWillBeValid()
    {
        Assert.Equal(false, _fullPreferentialBallot.IsInformal());
    }
}