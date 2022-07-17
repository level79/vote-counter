using System;
using System.Collections.Generic;
using System.Linq;
using VoteCounter.Election;
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
            new(new CandidateBuilder().Build(), int.MaxValue)
        };
        return this;
    }

    public BallotBuilder ForCandidates(params string[] candidates)
    {
        _preferences = candidates.Select((c, index) => 
            new Preference(new CandidateBuilder().WithName(c).Build(), index + 1)
        ).ToList();
        return this;
    }

    public BallotBuilder WithCandidates(params Candidate[] candidates)
    {
        _preferences = candidates.Shuffle().Select((c, index) => 
            new Preference(c, index + 1)
        ).ToList();
        return this;
    }
    
}

public static class Foo
{
    private static readonly Random Rng = new();  

    public static IList<T> Shuffle<T>(this IList<T> list)  
    {  
        var n = list.Count;  
        while (n > 1) {  
            n--;  
            var k = Rng.Next(n + 1);  
            (list[k], list[n]) = (list[n], list[k]);
        }

        return list;
    }
}