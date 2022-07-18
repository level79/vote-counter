using System.Collections.Generic;
using System.Linq;
using VoteCounter.Elections.Preferential.Results;
using VoteCounter.Elections.Results;

namespace VoteCounter.Elections.Preferential.Full;

public class FullPreferentialElection : PreferentialElection<FullPreferentialBallot>
{
    public FullPreferentialElection()
    {
        _ballots = new List<FullPreferentialBallot>();
        _informalBallots = new List<FullPreferentialBallot>();
        _candidates = new List<Candidate>();
    }

    public override PreferentialElectionResult CountVotes(PreferentialElectionResult results = null)
    {
        results ??= new PreferentialElectionResult();

        var eliminatedCandidates = results.EliminatedCandidates;
        var ballotGrouping = _ballots
            .GroupBy(vote => vote.Preference(eliminatedCandidates));
        var preferenceRound = new PreferenceRound(ballotGrouping
            .Select(group => new Tally(group.Key, group.Count())));

        results.AddPreferenceRound(preferenceRound);

        return results.CountIsFinalised ? results : CountVotes(results);
    }
}