using System.Collections.Generic;
using System.Linq;
using VoteCounter.Election.Results;
using VoteCounter.Voting;

namespace VoteCounter.Election
{
    public class Electorate
    {
        private readonly List<Ballot> _ballots;
        private List<Ballot> _informalBallots;

        public Electorate()
        {
            _ballots = new List<Ballot>();
            _informalBallots = new List<Ballot>();
        }

        public int TotalBallots => FormalBallots + InformalBallots;
        public int InformalBallots => _informalBallots.Count;
        public int FormalBallots => _ballots.Count;

        public void AddBallot(Ballot ballot)
        {
            if (ballot.IsFormal)
            {
                _ballots.Add(ballot);
            }
            else
            {
                _informalBallots.Add(ballot);
            }
        }

        public ElectorateResult DistributeVotes(List<Candidate> eliminatedCandidates = null)
        {
            eliminatedCandidates ??= new List<Candidate>();
            
            var results = new ElectorateResult(_ballots
                .Where(vote => !vote.IsExhausted(eliminatedCandidates))
                .GroupBy(vote => vote.Preference(eliminatedCandidates))
                .Select(group => new Tally(group.Key, group.Count())));
            eliminatedCandidates.Add(results.Last);
            
            return results.IsRedistributionRequired ? DistributeVotes(eliminatedCandidates) : results;
        }
    }
}