using System;
using System.Collections.Generic;
using VoteCounter.Elections;
using VoteCounter.Elections.Preferential.Full;
using VoteCounter.Voting;

namespace VoteCounter.Test.Unit.Elections.Builders;

public class FullPreferentialBallotBuilder
{
    private static readonly Candidate DefaultCandidate = new CandidateBuilder().Build();
    private static readonly Random RandomNumberGenerator;
    
    private IEnumerable<Candidate> _candidates = new List<Candidate>() {DefaultCandidate};
    private List<Preference> _preferences = new()
    {
        new Preference(DefaultCandidate, 1)
    };

    public FullPreferentialBallot Build()
    {
        return new FullPreferentialBallot(_candidates, _preferences);
    }
}