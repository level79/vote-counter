using VoteCounter.Elections;
using VoteCounter.Test.Unit.Election.Builders;
using VoteCounter.Test.Unit.Voting.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Election.Results;

public class GivenAnElectionWithASingleVote
{
    private readonly VoteCounter.Elections.OptionalPreferentialElection _optionalPreferentialElection;
    private readonly Candidate _candidate;

    public GivenAnElectionWithASingleVote()
    {
        var ballot = new OptionalPreferentialBallotBuilder().Build();
        _candidate = ballot.Primary;
        _optionalPreferentialElection = new ElectionBuilder().Build();
        _optionalPreferentialElection.AddCandidate(_candidate);
        _optionalPreferentialElection.AddBallot(ballot);
    }

    [Fact]
    public void ThenTheBallotCountsWillBe()
    {
        Assert.Equal(1, _optionalPreferentialElection.TotalBallots);
        Assert.Equal(0, _optionalPreferentialElection.InformalBallots);
        Assert.Equal(1, _optionalPreferentialElection.FormalBallots);
    }

    [Fact]
    public void ThenTheCandidateWillWin()
    {
        var electorateResult = _optionalPreferentialElection.CountVotes();
        Assert.Equal(_candidate, electorateResult.Winner);
    }
}