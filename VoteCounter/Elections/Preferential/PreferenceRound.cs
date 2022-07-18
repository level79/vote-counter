using System;
using System.Collections.Generic;
using System.Linq;
using VoteCounter.Elections.Results;

namespace VoteCounter.Elections.Preferential;

public class PreferenceRound
{
    private readonly Tally[] _tallies;

    public PreferenceRound(IEnumerable<Tally> tallies)
    {
        _tallies = tallies.OrderByDescending(t => t.Count).ToArray();
    }

    public int TotalVotes => _tallies.Sum(tally => tally.Count);
    public int NumberOfCandidates => _tallies.Length;
    public Candidate Leader => _tallies.First().Candidate;

    public bool IsFinalRound => NumberOfCandidates <= 2;
    public Candidate EliminatedCandidate =>
        NumberOfCandidates > 2 ? _tallies.Last().Candidate : throw new InvalidOperationException();
}