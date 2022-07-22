using VoteCounter.Elections.Results;
using VoteCounter.Voting;

namespace VoteCounter.Elections;

public interface IElection<T> where T : IBallot
{
    int TotalBallots { get; }
    int InformalBallots { get; }
    int FormalBallots { get; }
    ElectionResult CountVotes(ElectionResult results = null);
    void NominateCandidate(Candidate candidate);
    void AddBallot(T ballot);
}