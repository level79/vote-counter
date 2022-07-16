using System;
using System.Collections.Generic;
using VoteCounter.Test.Unit.Election.Builders;
using VoteCounter.Voting;

namespace VoteCounter.Test.Unit.Voting.Builders;

public class BallotBuilder
{
    private List<Preference> _preferences = new()
    {
        new Preference(new CandidateBuilder().Build(), 1)
    };
    public Ballot Build()
    {
        return new Ballot(_preferences);
    }

    public BallotBuilder AsInformal()
    {
        _preferences = new List<Preference>
        {
            new(new CandidateBuilder().Build(), Int32.MaxValue)
        };
        return this;
    }
}