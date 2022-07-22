using System.Collections.Generic;
using System.Linq;

namespace VoteCounter.Elections.Results;

public class ElectionResult
{
    private readonly List<DistributionRound> _preferenceRounds;

    public ElectionResult()
    {
        _preferenceRounds = new List<DistributionRound>();
    }

    public Candidate Winner => _preferenceRounds.Last().Leader;
    public int RemainingCandidates => _preferenceRounds.Last().NumberOfCandidates;
    public int TotalBallots => _preferenceRounds.First().TotalVotes;
    public int NumberOfCandidates => _preferenceRounds.Last().NumberOfCandidates;
    public int PreferenceRoundsRequired => _preferenceRounds.Count;
    public IEnumerable<Candidate> EliminatedCandidates => _preferenceRounds.Select(pr => pr.LastPlaceCandidate);

    public void AddPreferenceRound(DistributionRound round)
    {
        _preferenceRounds.Add(round);
    }
}