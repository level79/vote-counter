using VoteCounter.Elections;
using VoteCounter.Elections.Preferential.Optional;
using VoteCounter.Test.Unit.Elections.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Elections.Preferential.Optional.Results;

public class GivenAnElectionWithASingleVote
{
    private readonly OptionalPreferentialElection _optionalPreferentialElection;
    private readonly Candidate _candidate;

    public GivenAnElectionWithASingleVote()
    {
        _candidate = new CandidateBuilder().Build();
        var ballot = new OptionalPreferentialBallotBuilder().WithCandidates(_candidate).ForCandidates(_candidate)
            .Build();
        _optionalPreferentialElection = new OptionalPreferentialElectionBuilder().WithCandidates(_candidate).Build();
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