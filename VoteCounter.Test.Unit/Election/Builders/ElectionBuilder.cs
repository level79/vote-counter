namespace VoteCounter.Test.Unit.Election.Builders;

public class ElectionBuilder
{
    public ElectionBuilder()
    {
    }

    public VoteCounter.Elections.OptionalPreferentialElection Build()
    {
        return new VoteCounter.Elections.OptionalPreferentialElection();
    }
}