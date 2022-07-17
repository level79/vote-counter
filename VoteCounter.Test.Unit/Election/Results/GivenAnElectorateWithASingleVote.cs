using VoteCounter.Election;
using VoteCounter.Test.Unit.Election.Builders;
using VoteCounter.Test.Unit.Voting.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Election.Results;

public class GivenAnElectorateWithASingleVote
{
    private readonly Electorate _electorate;
    private readonly Candidate _candidate;

    public GivenAnElectorateWithASingleVote()
    {
        var ballot = new BallotBuilder().Build();
        _candidate = ballot.Primary;
        _electorate = new ElectorateBuilder().Build();
        _electorate.AddCandidate(_candidate);
        _electorate.AddBallot(ballot);
    }

    [Fact]
    public void ThenTheBallotCountsWillBe()
    {
        Assert.Equal(1, _electorate.TotalBallots);
        Assert.Equal(0, _electorate.InformalBallots);
        Assert.Equal(1, _electorate.FormalBallots);
    }

    [Fact]
    public void ThenTheCandidateWillWin()
    {
        var electorateResult = _electorate.CountVotes();
        Assert.Equal(_candidate, electorateResult.Winner);
    }
}