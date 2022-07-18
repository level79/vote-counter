using System.Collections.Generic;
using VoteCounter.Elections.Preferential.Optional;
using VoteCounter.Elections.Preferential.Optional.Results;

namespace VoteCounter.Elections.Preferential;

public abstract class PreferentialElection<T> where T : PreferentialBallot
{
    protected List<T> _ballots;
    protected List<T> _informalBallots;
    protected List<Candidate> _candidates;
    public int TotalBallots => FormalBallots + InformalBallots;
    public int InformalBallots => _informalBallots.Count;
    public int FormalBallots => _ballots.Count;
    public abstract PreferentialElectionResult CountVotes(PreferentialElectionResult results = null);

    public void AddCandidate(Candidate candidate)
    {
        _candidates.Add(candidate);
    }

    public void AddBallot(T ballot)
    {
        if (ballot.IsInformal())
        {
            _informalBallots.Add(ballot);
        }
        else
        {
            _ballots.Add(ballot);
        }
    }
}