using System.Collections.Generic;
using System.Linq;
using VoteCounter.Elections.Results;

namespace VoteCounter.Elections.Preferential.Optional.Results
{
    public class PreferentialElectionResult
    {
        private readonly List<PreferenceRound> _preferenceRounds;

        public PreferentialElectionResult()
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