using VoteCounter.Election;
using VoteCounter.Test.Unit.Election.Builders;
using VoteCounter.Test.Unit.Voting.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Election.Results;

public class GivenAnElectorateWithABallotForANonCandidate
{
    private readonly Electorate _electorate;

    public GivenAnElectorateWithABallotForANonCandidate()
    {
        _electorate = new ElectorateBuilder().Build();
        _electorate.AddCandidate(new CandidateBuilder().Build());
        _electorate.AddBallot(new BallotBuilder().Build());
    }
    
    [Fact]
    public void ThenTheBallotCountsWillBe()
    {
        Assert.Equal(1, _electorate.TotalBallots);
        Assert.Equal(1, _electorate.InformalBallots);
        Assert.Equal(0, _electorate.FormalBallots);
    }
}