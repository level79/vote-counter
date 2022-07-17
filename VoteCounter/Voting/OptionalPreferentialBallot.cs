﻿using System.Collections.Generic;
using System.Linq;
using VoteCounter.Elections;

namespace VoteCounter.Voting
{
    public class OptionalPreferentialBallot
    {
        private readonly Preference[] _preferences;

        public OptionalPreferentialBallot(IEnumerable<Preference> preferences)
        {
            _preferences = preferences.OrderBy(preference => preference.Rank).ToArray();
        }
        
        public Candidate Primary => _preferences.First().Candidate;
        
        public Candidate Preference(IEnumerable<Candidate> eliminatedCandidates)
        {
            return _preferences.First(preference => !eliminatedCandidates.Contains(preference.Candidate)).Candidate;
        }
        
        public bool IsExhausted(IEnumerable<Candidate> eliminatedCandidates)
        {
            return _preferences.All(preference => eliminatedCandidates.Contains(preference.Candidate));
        }

        public bool IsInformal(IEnumerable<Candidate> candidates)
        {
            var ballotIsForCandidates = _preferences
                .Select(p => p.Candidate)
                .All(candidates.Contains);
            var ballotPreferencesContiguous = _preferences
                .Select((preference, index) => (preference.Rank, index + 1))
                .All(tuple => tuple.Item1 == tuple.Item2);
            return !ballotPreferencesContiguous || !ballotIsForCandidates;
        }
    }
}