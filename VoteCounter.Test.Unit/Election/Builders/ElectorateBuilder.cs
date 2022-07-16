using VoteCounter.Election;

namespace VoteCounter.Test.Unit.Election.Builders;

public class ElectorateBuilder
{
    public ElectorateBuilder()
    {
    }

    public Electorate Build()
    {
        return new Electorate();
    }
}