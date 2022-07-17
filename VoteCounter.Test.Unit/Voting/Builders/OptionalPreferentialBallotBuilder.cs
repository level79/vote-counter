using System;
using System.Collections.Generic;
using System.Linq;
using VoteCounter.Elections;
using VoteCounter.Test.Unit.Elections.Builders;
using VoteCounter.Voting;

namespace VoteCounter.Test.Unit.Voting.Builders;

public class OptionalPreferentialBallotBuilder
{
    private static readonly Random RandomNumberGenerator;
    private List<Preference> _preferences = new()
    {
        new Preference(new CandidateBuilder().Build(), 1)
    };
    
    static OptionalPreferentialBallotBuilder()
    {
        RandomNumberGenerator = new Random();
    }

    public OptionalPreferentialBallot Build()
    {
        return new OptionalPreferentialBallot(_preferences);
    }

    public OptionalPreferentialBallotBuilder AsInformal()
    {
        _preferences = new List<Preference>
        {
            new(new CandidateBuilder().Build(), int.MaxValue)
        };
        return this;
    }
    
    public OptionalPreferentialBallotBuilder WithCandidates(params Candidate[] candidates)
    {
        var candidatesToTake = Math.Max(1,RandomNumberGenerator.Next(candidates.Length - 1));
        _preferences = candidates
            .Shuffle()
            .Take(Range.EndAt(candidatesToTake))
            .Select((c, index) => 
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