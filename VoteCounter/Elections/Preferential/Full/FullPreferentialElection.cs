using System.Collections.Generic;
using System.Linq;
using VoteCounter.Elections.Preferential.Results;
using VoteCounter.Elections.Results;

namespace VoteCounter.Elections.Preferential.Full;

public class FullPreferentialElection : Election<FullPreferentialBallot>
{
    public FullPreferentialElection()
    {
        _ballots = new List<FullPreferentialBallot>();
        _informalBallots = new List<FullPreferentialBallot>();
        Candidates = new List<Candidate>();
    }

    public override ElectionResult CountVotes()
    {
        var results = new ElectionResult();
        while (true)
        {
            var eliminatedCandidates = results.EliminatedCandidates;
            var ballotGrouping = _ballots.GroupBy(vote => vote.Preference(eliminatedCandidates));
            var preferenceRound =
                new DistributionRound(ballotGrouping.Select(group => new Tally(group.Key, group.Count())));

            results.AddPreferenceRound(preferenceRound);

            if (results.RemainingCandidates <= 2) return results;
        }
    }
}