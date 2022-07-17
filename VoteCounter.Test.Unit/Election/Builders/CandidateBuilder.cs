using Bogus;
using VoteCounter.Elections;

namespace VoteCounter.Test.Unit.Election.Builders;

public class CandidateBuilder
{
    private string _name = new Faker().Name.FirstName();
    
    public Candidate Build()
    {
        return new Candidate(_name);
    }

    public CandidateBuilder WithName(string name)
    {
        _name = name;
        return this;
    }
}