using System.Collections.Generic;
using System.Linq;

namespace VoteCounter.Elections.Results
{
    public class ElectionResult
    {
        private readonly List<PreferenceRound> _preferenceRounds;

        public ElectionResult()
        {
            _preferenceRounds = new List<PreferenceRound>();
        }

        public Candidate Winner => _preferenceRounds.Last().Leader;

        public bool CountIsFinalised => _preferenceRounds.Last().IsFinalRound;
        public int TotalBallots => _preferenceRounds.First().TotalVotes;
        public int Candidates => _preferenceRounds.Last().NumberOfCandidates;

        public IEnumerable<Candidate> EliminatedCandidates => _preferenceRounds.Select(pr => pr.EliminatedCandidate);
        public int PreferenceRoundsRequired => _preferenceRounds.Count;

        public void AddPreferenceRound(PreferenceRound round)
        {
            _preferenceRounds.Add(round);
        }
    }
}