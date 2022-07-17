using VoteCounter.Test.Unit.Election.Builders;
using VoteCounter.Test.Unit.Voting.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Election.Results;

public class GivenAnElectionWithABallotForANonCandidate
{
    private readonly VoteCounter.Election.Election _election;

    public GivenAnElectionWithABallotForANonCandidate()
    {
        _election = new ElectionBuilder().Build();
        _election.AddCandidate(new CandidateBuilder().Build());
        _election.AddBallot(new BallotBuilder().Build());
    }
    
    [Fact]
    public void ThenTheBallotCountsWillBe()
    {
        Assert.Equal(1, _election.TotalBallots);
        Assert.Equal(1, _election.InformalBallots);
        Assert.Equal(0, _election.FormalBallots);
    }
}