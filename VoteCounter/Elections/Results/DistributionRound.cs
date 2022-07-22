using System.Collections.Generic;
using System.Linq;

namespace VoteCounter.Elections.Results;

public class DistributionRound
{
    private readonly Tally[] _tallies;

    public DistributionRound(IEnumerable<Tally> tallies)
    {
        _tallies = tallies.OrderByDescending(t => t.Count).ToArray();
    }

    public int TotalVotes => _tallies.Sum(tally => tally.Count);
    public int NumberOfCandidates => _tallies.Length;
    public Candidate Leader => _tallies.First().Candidate;
    public Candidate LastPlaceCandidate => _tallies.Last().Candidate;
}