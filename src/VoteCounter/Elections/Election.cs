using System.Collections.Generic;
using VoteCounter.Elections.Results;
using VoteCounter.Voting;

namespace VoteCounter.Elections;

public abstract class Election<T> where T : Ballot
{
    protected List<T> FormalBallots;
    protected List<T> InformalBallots;
    public List<Candidate> Candidates { get; protected init; }
    public int TotalBallots => TotalFormalBallots + TotalInformalBallots;
    public int TotalInformalBallots => InformalBallots.Count;
    public int TotalFormalBallots => FormalBallots.Count;
    public abstract ElectionResult CountVotes();

    public void NominateCandidate(Candidate candidate)
    {
        Candidates.Add(candidate);
    }

    public void AddBallot(T ballot)
    {
        if (ballot.IsInformal())
        {
            InformalBallots.Add(ballot);
        }
        else
        {
            FormalBallots.Add(ballot);
        }
    }
}