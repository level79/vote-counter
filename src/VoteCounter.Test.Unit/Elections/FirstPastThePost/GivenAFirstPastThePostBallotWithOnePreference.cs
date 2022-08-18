using System.Linq;
using VoteCounter.Elections.FirstPastThePost;
using VoteCounter.Test.Unit.Elections.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Elections.FirstPastThePost;

public class GivenAFirstPastThePostBallotWithOnePreference
{
    private readonly FirstPastThePostBallot _ballot;

    public GivenAFirstPastThePostBallotWithOnePreference()
    {
        var candidates = Enumerable.Range(0, 5).Select(i => new CandidateBuilder().Build()).ToList();
        _ballot = FirstPastThePostBallot.IssueBallot(candidates);
        new BallotFiller().FromCandidates(candidates.ToArray()).Fill(_ballot);
    }

    [Fact]
    public void ThenItIsFormal()
    {
        Assert.False(_ballot.IsInformal());
    }
}

public class GivenAFirstPassThePostBallotWithADifferentCandidate
{
    private readonly FirstPastThePostBallot _ballot;

    public GivenAFirstPassThePostBallotWithADifferentCandidate()
    {
        var candidates = Enumerable.Range(0, 5).Select(i => new CandidateBuilder().Build()).ToList();
        _ballot = FirstPastThePostBallot.IssueBallot(candidates);
        new BallotFiller().FromCandidates(new CandidateBuilder().Build()).Fill(_ballot);
    }

    [Fact]
    public void ThenItIsInformal()
    {
        Assert.True(_ballot.IsInformal());
    }
}