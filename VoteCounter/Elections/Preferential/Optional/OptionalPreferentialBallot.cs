using System.Collections.Generic;
using System.Linq;

namespace VoteCounter.Elections.Preferential.Optional
{
    public class OptionalPreferentialBallot : PreferentialBallot
    {
        private OptionalPreferentialBallot()
        {
        }

        public static OptionalPreferentialBallot IssueBallot(IEnumerable<Candidate> candidates)
        {
            return new OptionalPreferentialBallot
            {
                Candidates = candidates
            };
        }

        public bool IsExhausted(IEnumerable<Candidate> eliminatedCandidates)
        {
            return Preferences
                .Select(p => p.Candidate)
                .All(eliminatedCandidates.Contains);
        }

        public override bool IsInformal()
        {
            var ballotIsEmpty = Preferences.Length == 0;
            var ballotIsForOtherCandidates = !Preferences
                .Select(p => p.Candidate)
                .All(Candidates.Contains);
            var ballotPreferencesNotContiguous = Preferences
                .Select((preference, index) => (preference.Rank, index + 1))
                .Any(tuple => tuple.Item1 != tuple.Item2);
            return ballotIsEmpty || ballotPreferencesNotContiguous || ballotIsForOtherCandidates;
        }
    }
}