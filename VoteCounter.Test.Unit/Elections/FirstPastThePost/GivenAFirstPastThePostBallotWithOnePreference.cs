using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using VoteCounter.Elections.FirstPastThePost;
using VoteCounter.Test.Unit.Elections.Builders;
using VoteCounter.Utilities;
using Xunit;

namespace VoteCounter.Test.Unit.Elections.FirstPastThePost;

public class GivenAFirstPastThePostBallotWithOnePreference
{
    private readonly FirstPastThePostBallot _ballot;

    public GivenAFirstPastThePostBallotWithOnePreference()
    {
        var candidates = Enumerable.Range(0, 5).Select(i => new CandidateBuilder().Build()).ToList();
        _ballot = FirstPastThePostBallot.IssueBallot(candidates);
        new FirstPastThePostBallotFiller(_ballot).FromCandidates(candidates.ToArray()).Fill();
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
        new FirstPastThePostBallotFiller(_ballot).FromCandidates(new CandidateBuilder().Build()).Fill();
    }

    [Fact]
    public void ThenItIsInformal()
    {
        Assert.True(_ballot.IsInformal());
    }
}