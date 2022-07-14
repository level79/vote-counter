using System.Collections.Generic;
using System.Linq;

namespace VoteCounter
{
    public class Electorate
    {
        private readonly List<Ballot> _votes;

        public Electorate()
        {
            _votes = new List<Ballot>();
        }

        public void AddBallot(Ballot ballot)
        {
            _votes.Add(ballot);
        }

        public ElectorateResult DistributeVotes()
        {
            var eliminatedCandidates = new List<Candidate>();
            ElectorateResult results;
            do
            {
                results = new ElectorateResult(_votes
                    .Where(vote => vote.IsFormal)
                    .Where(vote => !vote.IsExhausted(eliminatedCandidates))
                    .GroupBy(vote => vote.Preference(eliminatedCandidates))
                    .Select(group => new Tally(group.Key, group.Count())));
                eliminatedCandidates.Add(results.Last);

            } while (results.IsRedistributionRequired);
            
            return results;
        }
    }
}