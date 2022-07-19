using VoteCounter.Elections;
using VoteCounter.Elections.Preferential.Full;

namespace VoteCounter.Test.Unit.Elections.Builders;

public class FullPreferentialElectionBuilder
{
    private Candidate[] _candidates = {new CandidateBuilder().Build()};
    
    public FullPreferentialElection Build()
    {
        var election = new FullPreferentialElection();
        foreach (var candidate in _candidates)
        {
            election.NominateCandidate(candidate);
        }

        return election;
    }

    public FullPreferentialElectionBuilder WithCandidates(Candidate[] candidates)
    {
        _candidates = candidates;
        return this;
    }
}