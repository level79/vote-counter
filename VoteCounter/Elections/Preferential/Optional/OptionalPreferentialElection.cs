using System.Collections.Generic;
using System.Linq;
using VoteCounter.Elections.Results;

namespace VoteCounter.Elections.Preferential.Optional
{
    public class OptionalPreferentialElection : Election<OptionalPreferentialBallot>
    {
        public OptionalPreferentialElection()
        {
            FormalBallots = new List<OptionalPreferentialBallot>();
            InformalBallots = new List<OptionalPreferentialBallot>();
            Candidates = new List<Candidate>();
        }

        public override ElectionResult CountVotes()
        {
            var results = new ElectionResult();
            while (true)
            {
                var eliminatedCandidates = results.EliminatedCandidates;
                var currentBallots = FormalBallots.Where(vote => !vote.IsExhausted(eliminatedCandidates));
                var ballotGrouping = currentBallots.GroupBy(vote => vote.Preference(eliminatedCandidates));
                var preferenceRound =
                    new DistributionRound(ballotGrouping.Select(group => new Tally(group.Key, group.Count())));

                results.AddPreferenceRound(preferenceRound);

                if (results.RemainingCandidates <= 2) return results;
            }
        }
    }
}