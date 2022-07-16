using VoteCounter.Election;

namespace VoteCounter.Test.Unit.Election.Builders;

public class CandidateBuilder
{
    public CandidateBuilder()
    {
        var candidate = Build();
    }

    public Candidate Build()
    {
        return new Candidate("Mad Katter");
    }
}