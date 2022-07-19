using VoteCounter.Elections;
using VoteCounter.Elections.Preferential.Optional;

namespace VoteCounter.Test.Unit.Elections.Builders;

public class OptionalPreferentialElectionBuilder
{
    private Candidate[] _candidates = {new CandidateBuilder().Build()};

    public OptionalPreferentialElectionBuilder()
    {
    }

    public OptionalPreferentialElection Build()
    {
        var election = new OptionalPreferentialElection();
        foreach (var candidate in _candidates)
        {
            election.NominateCandidate(candidate);
        }

        return election;
    }

    public OptionalPreferentialElectionBuilder WithCandidates(params Candidate[] candidates)
    {
        _candidates = candidates;
        return this;
    }
}