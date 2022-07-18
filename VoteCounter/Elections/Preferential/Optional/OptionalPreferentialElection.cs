using System.Collections.Generic;
using System.Linq;
using VoteCounter.Elections.Preferential.Optional.Results;
using VoteCounter.Elections.Results;
using VoteCounter.Voting;

namespace VoteCounter.Elections.Preferential.Optional
{
    public class OptionalPreferentialElection
    {
        private readonly List<OptionalPreferentialBallot> _ballots;
        private readonly List<OptionalPreferentialBallot> _informalBallots;
        private readonly List<Candidate> _candidates;

        public OptionalPreferentialElection()
        {
            _ballots = new List<OptionalPreferentialBallot>();
            _informalBallots = new List<OptionalPreferentialBallot>();
            _candidates = new List<Candidate>();
        }

        public int TotalBallots => FormalBallots + InformalBallots;
        public int InformalBallots => _informalBallots.Count;
        public int FormalBallots => _ballots.Count;

        public void AddBallot(OptionalPreferentialBallot optionalPreferentialBallot)
        {
            if (optionalPreferentialBallot.IsInformal())
            {
                _informalBallots.Add(optionalPreferentialBallot);
            }
            else
            {
                _ballots.Add(optionalPreferentialBallot);
            }
        }

        public OptionalPreferentialElectionResult CountVotes(OptionalPreferentialElectionResult results = null)
        {
            results ??= new OptionalPreferentialElectionResult();

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

        public void AddCandidate(Candidate candidate)
        {
            _candidates.Add(candidate);
        }
    }
}