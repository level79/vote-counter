using System;
using System.Collections.Generic;
using System.Linq;
using VoteCounter.Elections;
using VoteCounter.Elections.Preferential.Full;
using VoteCounter.Utilities;
using VoteCounter.Voting;

namespace VoteCounter.Test.Unit.Elections.Builders;

public class FullPreferentialBallotBuilder
{
    private static readonly Candidate DefaultCandidate = new CandidateBuilder().Build();
    
    private IEnumerable<Candidate> _candidates = new List<Candidate>() {DefaultCandidate};
    private List<Preference> _preferences = new()
    {
        new Preference(DefaultCandidate, 1)
    };

    public FullPreferentialBallot Build()
    {
        var ballot = FullPreferentialBallot.IssueBallot(_candidates);
        ballot.AddPreferences(_preferences);
        return ballot;
    }

    public FullPreferentialBallotBuilder WithCandidates(params Candidate[] candidates)
    {
        _candidates = candidates;
        return this;
    }

    public FullPreferentialBallotBuilder ForCandidates(params Candidate[] candidates)
    {
        _preferences = candidates
            .Shuffle()
            .Select((c, index) => new Preference(c, index + 1))
            .ToList();
        return this;
    }
}