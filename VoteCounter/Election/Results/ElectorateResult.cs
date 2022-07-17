using System.Collections.Generic;
using System.Linq;

namespace VoteCounter.Election.Results
{
    public class ElectorateResult
    {
        private readonly List<PreferenceRound> _preferenceRounds;

        public ElectorateResult()
        {
            _preferenceRounds = new List<PreferenceRound>();
        }

        public Candidate Winner => _preferenceRounds.Last().Leader;

        public bool CountIsFinalised => _preferenceRounds.Last().IsFinalRound;
        public int TotalVotes => _preferenceRounds.Last().TotalVotes;
        public int Candidates => _preferenceRounds.Last().NumberOfCandidates;

        public IEnumerable<Candidate> EliminatedCandidates => _preferenceRounds.Select(pr => pr.EliminatedCandidate);
        public int PreferenceRoundsRequired => _preferenceRounds.Count;

        public void AddPreferenceRound(PreferenceRound round)
        {
            _preferenceRounds.Add(round);
        }
    }
}