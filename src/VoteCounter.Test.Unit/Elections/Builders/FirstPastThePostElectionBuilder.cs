using VoteCounter.Elections;
using VoteCounter.Elections.FirstPastThePost;

namespace VoteCounter.Test.Unit.Elections.Builders;

public class FirstPastThePostElectionBuilder
{
    private readonly Candidate[] _candidates = {new CandidateBuilder().Build()};

    public FirstPastThePostElection Build()
    {
        var election = new FirstPastThePostElection();
        foreach (var candidate in _candidates)
        {
            election.NominateCandidate(candidate);
        }

        return election;
    }
}