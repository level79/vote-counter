namespace VoteCounter.Test.Unit.Election.Builders;

public class ElectionBuilder
{
    public ElectionBuilder()
    {
    }

    public VoteCounter.Election.Election Build()
    {
        return new VoteCounter.Election.Election();
    }
}