using System.Linq;
using VoteCounter.Elections.FirstPastThePost;
using VoteCounter.Test.Unit.Elections.Builders;
using VoteCounter.Voting;
using Xunit;

namespace VoteCounter.Test.Unit.Elections.FirstPastThePost;

public class GivenAFirstPastThePostBallotWithTwoPreferencesPreference
{
    private FirstPastThePostBallot _ballot;

    public GivenAFirstPastThePostBallotWithTwoPreferencesPreference()
    {
        var candidates = Enumerable.Range(0, 5).Select(i => new CandidateBuilder().Build()).ToList();
        _ballot = FirstPastThePostBallot.IssueBallot(candidates);
        var preferences = candidates.Take(2).Select((candidate, index) => new Preference(candidate, index + 1))
            .ToList();
        _ballot.AddPreferences(preferences);
    }

    [Fact]
    public void ThenItIsInformal()
    {
        Assert.True(_ballot.IsInformal());
    }
}