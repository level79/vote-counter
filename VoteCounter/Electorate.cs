using System.Collections.Generic;
using System.Linq;

namespace VoteCounter
{
    public class Electorate
    {
        private readonly List<Vote> _votes;

        public Electorate()
        {
            _votes = new List<Vote>();
        }

        public void AddVote(Vote vote)
        {
            _votes.Add(vote);
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