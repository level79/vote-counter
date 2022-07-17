using System.Collections.Generic;
using System.Linq;
using VoteCounter.Election.Results;
using VoteCounter.Voting;

namespace VoteCounter.Election
{
    public class Election
    {
        private readonly List<Ballot> _ballots;
        private readonly List<Ballot> _informalBallots;
        private readonly List<Candidate> _candidates;

        public Election()
        {
            _ballots = new List<Ballot>();
            _informalBallots = new List<Ballot>();
            _candidates = new List<Candidate>();
        }

        public int TotalBallots => FormalBallots + InformalBallots;
        public int InformalBallots => _informalBallots.Count;
        public int FormalBallots => _ballots.Count;

        public void AddBallot(Ballot ballot)
        {
            if (ballot.IsInformal(_candidates))
            {
                _informalBallots.Add(ballot);
            }
            else
            {
                _ballots.Add(ballot);
            }
        }

        public ElectionResult CountVotes(ElectionResult results = null)
        {
            results ??= new ElectionResult();

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