using System.Collections.Generic;
using System.Linq;

namespace VoteCounter.Election.Results
{
    public class ElectorateResult
    {
        public ElectorateResult(IEnumerable<Tally> count)
        {
            Count = count.OrderBy(tally => tally.Count).Reverse().ToArray();
        }
        private IEnumerable<Tally> Count { get; }

        public Candidate Winner => Count.First().Candidate;
        public Candidate Last => Count.Last().Candidate;
        
        public bool IsRedistributionRequired => Count.First().Count <= (double)Count.Sum(tally => tally.Count) / 2;
    }
}