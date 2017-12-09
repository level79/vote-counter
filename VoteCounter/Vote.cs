using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Resolvers;

namespace VoteCounter
{
    public class Vote
    {
        private readonly Preference[] _preferences;

        public Vote(IEnumerable<Preference> preferences)
        {
            _preferences = preferences.OrderBy(preference => preference.Rank).ToArray();
        }

        public Vote(IEnumerable<string> names)
        {
            _preferences = names.Select((name, index) => new Preference(new Candidate(name), index + 1)).ToArray();
        }

        public Candidate Primary => _preferences.First().Candidate;

        public bool IsFormal => _preferences
            .Select((preference, index) => (preference.Rank, index + 1))
            .All(tuple => tuple.Item1 == tuple.Item2);

        public Candidate Preference(IEnumerable<Candidate> eliminatedCandidates)
        {
            return _preferences.First(preference => !eliminatedCandidates.Contains(preference.Candidate)).Candidate;
        }
        
        public bool IsExhausted(IEnumerable<Candidate> eliminatedCandidates)
        {
            return _preferences.All(preference => eliminatedCandidates.Contains(preference.Candidate));
        }
    }
}