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
        _electorate = new ElectorateBuilder().Build();
        var ballot = new BallotBuilder().Build();
        _electorate.AddBallot(ballot);
        _candidate = ballot.Primary;
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
        var electorateResult = _electorate.DistributeVotes();
        Assert.Equal(_candidate, electorateResult.Winner);
    }
}