using System.Linq;
using VoteCounter.Elections.FirstPastThePost.MultiCandidate;
using VoteCounter.Test.Unit.Elections.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Elections.FirstPastThePost.MultiCandidate;

public class GivenAMultiCandidateFirstPastThePostBallotWithMultipleCandidates
{
    private readonly MultiCandidateFirstPastThePostBallot _ballot;

    public GivenAMultiCandidateFirstPastThePostBallotWithMultipleCandidates()
    {
        var candidates = Enumerable.Range(0, 5).Select(i => new CandidateBuilder().Build()).ToList();
        _ballot = MultiCandidateFirstPastThePostBallot.IssueBallot(candidates, 3);
        new BallotFiller()
            .FromCandidates(candidates.ToArray())
            .PickCandidates(3)
            .Fill(_ballot);
    }

    [Fact]
    public void ItIsFormal()
    {
        Assert.False(_ballot.IsInformal());
    }
}