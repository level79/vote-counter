using VoteCounter.Elections;
using VoteCounter.Elections.Preferential.Optional;

namespace VoteCounter.Test.Unit.Elections.Builders;

public class OptionalPreferentialElectionBuilder
{
    public OptionalPreferentialElectionBuilder()
    {
    }

    public OptionalPreferentialElection Build()
    {
        return new OptionalPreferentialElection();
    }
}