using System.Linq;
using VoteCounter.Elections;
using VoteCounter.Elections.Preferential.Full;
using VoteCounter.Test.Unit.Elections.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Elections.Preferential.Full.Results;

public class GivenAFullPreferentialElectionWith1000Votes
{
    private readonly FullPreferentialElection _fullPreferentialElection;
    private readonly Candidate[] _candidates;

    public GivenAFullPreferentialElectionWith1000Votes()
    {
        _candidates = Enumerable.Range(0, 5).Select(i => new CandidateBuilder().Build()).ToArray();
        _fullPreferentialElection = new FullPreferentialElectionBuilder().WithCandidates(_candidates).Build();

        for (var i = 0; i < 1000; i++)
        {
            _fullPreferentialElection.AddBallot(
                new FullPreferentialBallotBuilder()
                    .ForCandidates(_candidates)
                    .WithCandidates(_candidates)
                    .Build());
        }
    }

    [Fact]
    public void RedistributeVotesToFindWinner()
    {
        var electorateResult = _fullPreferentialElection.CountVotes();
        Assert.Equal(_fullPreferentialElection.FormalBallots, electorateResult.TotalBallots);
        Assert.Equal(_candidates.Length - 1, electorateResult.PreferenceRoundsRequired);
        Assert.Equal(2, electorateResult.NumberOfCandidates);
    }
}