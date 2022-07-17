using VoteCounter.Elections;

namespace VoteCounter.Test.Unit.Elections.Builders;

public class ElectionBuilder
{
    public ElectionBuilder()
    {
    }

    public OptionalPreferentialElection Build()
    {
        return new OptionalPreferentialElection();
    }
}