using VoteCounter.Elections.FirstPastThePost;
using VoteCounter.Test.Unit.Elections.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Elections.FirstPastThePost;

public class GivenAFirstPastThePostElection
{
    private readonly FirstPastThePostElection _election;

    public GivenAFirstPastThePostElection()
    {
        _election = new FirstPastThePostElectionBuilder().Build();

        for (var i = 0; i < 1000; i++)
        {
            var issueBallot = _election.IssueBallot();
            _election.AddBallot(
                new FirstPastThePostBallotFiller(issueBallot)
                    .FromCandidates(_election.Candidates)
                    .Fill());
        }
    }

    [Fact]
    public void ThenTheResultsWillBeCounted()
    {
        var electionResult = _election.CountVotes();
        Assert.Equal(1, electionResult.PreferenceRoundsRequired);
        Assert.Contains(electionResult.Winner, _election.Candidates);
        Assert.Equal(1000, electionResult.TotalBallots);
        Assert.Equal(_election.Candidates.Count, electionResult.NumberOfCandidates);
    }
}