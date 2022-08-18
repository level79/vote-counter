using System;
using System.Collections.Generic;
using System.Linq;
using VoteCounter.Elections;
using VoteCounter.Elections.Preferential.Optional;
using VoteCounter.Utilities;
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
        var ballot = OptionalPreferentialBallot.IssueBallot(_candidates);
        ballot.AddPreferences(_preferences);
        return ballot;
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
        var candidatesToTake = Math.Max(1, RandomNumberGenerator.Next(candidates.Length - 1));
        _preferences = candidates
            .Shuffle()
            .Take(Range.EndAt(candidatesToTake))
            .Select((c, index) =>
                new Preference(c, index + 1)
            ).ToList();
        return this;
    }

    public OptionalPreferentialBallotBuilder WithCandidates(params Candidate[] candidates)
    {
        _candidates = candidates;
        return this;
    }
}