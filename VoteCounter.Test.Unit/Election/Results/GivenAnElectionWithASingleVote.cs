using VoteCounter.Election;
using VoteCounter.Test.Unit.Election.Builders;
using VoteCounter.Test.Unit.Voting.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Election.Results;

public class GivenAnElectionWithASingleVote
{
    private readonly VoteCounter.Election.Election _election;
    private readonly Candidate _candidate;

    public GivenAnElectionWithASingleVote()
    {
        var ballot = new BallotBuilder().Build();
        _candidate = ballot.Primary;
        _election = new ElectionBuilder().Build();
        _election.AddCandidate(_candidate);
        _election.AddBallot(ballot);
    }

    [Fact]
    public void ThenTheBallotCountsWillBe()
    {
        Assert.Equal(1, _election.TotalBallots);
        Assert.Equal(0, _election.InformalBallots);
        Assert.Equal(1, _election.FormalBallots);
    }

    [Fact]
    public void ThenTheCandidateWillWin()
    {
        var electorateResult = _election.CountVotes();
        Assert.Equal(_candidate, electorateResult.Winner);
    }
}