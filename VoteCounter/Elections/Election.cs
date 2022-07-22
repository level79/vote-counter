using System.Collections.Generic;
using VoteCounter.Elections.Results;

namespace VoteCounter.Elections;

public abstract class Election<T> where T : IBallot
{
    protected List<T> _ballots;
    protected List<T> _informalBallots;
    public List<Candidate> Candidates { get; init; }
    public int TotalBallots => FormalBallots + InformalBallots;
    public int InformalBallots => _informalBallots.Count;
    public int FormalBallots => _ballots.Count;
    public abstract ElectionResult CountVotes();

    public void NominateCandidate(Candidate candidate)
    {
        Candidates.Add(candidate);
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