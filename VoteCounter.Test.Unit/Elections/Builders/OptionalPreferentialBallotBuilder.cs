using System;
using System.Collections.Generic;
using System.Linq;
using VoteCounter.Elections;
using VoteCounter.Elections.Preferential.Optional;
using VoteCounter.Voting;

namespace VoteCounter.Test.Unit.Elections.Builders;

public class OptionalPreferentialBallotBuilder
{
    private static readonly Candidate DefaultCandidate = new CandidateBuilder().Build();
    private static readonly Random RandomNumberGenerator;
    
    private IEnumerable<Candidate> _candidates = new List<Candidate>() {DefaultCandidate};
    private List<Preference> _preferences = new()
    {
        new Preference(DefaultCandidate, 1)
    };
    
    static OptionalPreferentialBallotBuilder()
    {
        RandomNumberGenerator = new Random();
    }

    public OptionalPreferentialBallot Build()
    {
        return new OptionalPreferentialBallot(_candidates, _preferences);
    }

    public OptionalPreferentialBallotBuilder AsInformal()
    {
        _preferences = new List<Preference>
        {
            new(new CandidateBuilder().Build(), int.MaxValue)
        };
        return this;
    }
    
    public OptionalPreferentialBallotBuilder ForCandidates(params Candidate[] candidates)
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

    public OptionalPreferentialBallotBuilder WithCandidates(params  Candidate[] candidates)
    {
        _candidates = candidates;
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