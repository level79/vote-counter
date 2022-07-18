using System.Collections.Generic;
using System.Linq;
using VoteCounter.Elections.Preferential.Results;
using VoteCounter.Elections.Results;
using VoteCounter.Voting;

namespace VoteCounter.Elections.Preferential.Optional
{
    public class OptionalPreferentialElection : PreferentialElection<OptionalPreferentialBallot>
    {
        public OptionalPreferentialElection()
        {
            _ballots = new List<OptionalPreferentialBallot>();
            _informalBallots = new List<OptionalPreferentialBallot>();
            _candidates = new List<Candidate>();
        }

        public override PreferentialElectionResult CountVotes(PreferentialElectionResult results = null)
        {
            results ??= new PreferentialElectionResult();

            var eliminatedCandidates = results.EliminatedCandidates;
            var currentBallots = _ballots
                .Where(vote => !vote.IsExhausted(eliminatedCandidates));
            var ballotGrouping = currentBallots
                .GroupBy(vote => vote.Preference(eliminatedCandidates));
            var preferenceRound = new PreferenceRound(ballotGrouping
                .Select(group => new Tally(group.Key, group.Count())));
            
            results.AddPreferenceRound(preferenceRound);

            return results.CountIsFinalised ? results : CountVotes(results);
        }
    }
}