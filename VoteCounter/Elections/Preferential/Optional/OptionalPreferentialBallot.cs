using System.Collections.Generic;
using System.Linq;
using VoteCounter.Voting;

namespace VoteCounter.Elections.Preferential.Optional
{
    public class OptionalPreferentialBallot : PreferentialBallotBase
    {
        public OptionalPreferentialBallot(IEnumerable<Candidate> candidates, IEnumerable<Preference> preferences) : base(candidates, preferences)
        {
        }

        public bool IsExhausted(IEnumerable<Candidate> eliminatedCandidates)
        {
            return _preferences.All(preference => eliminatedCandidates.Contains(preference.Candidate));
        }

        public override bool IsInformal()
        {
            var ballotIsEmpty = _preferences.Length == 0;
            var ballotIsForOtherCandidates = !_preferences
                .Select(p => p.Candidate)
                .All(_candidates.Contains);
            var ballotPreferencesNotContiguous = _preferences
                .Select((preference, index) => (preference.Rank, index + 1)).Any(tuple => tuple.Item1 != tuple.Item2);
            return ballotIsEmpty || ballotPreferencesNotContiguous || ballotIsForOtherCandidates;
        }

        
    }
}