using System.Collections.Generic;
using System.Linq;
using VoteCounter.Voting;

namespace VoteCounter.Elections.Preferential.Full;

public class FullPreferentialBallot : PreferentialBallot
{
    private FullPreferentialBallot()
    {
    }

    public static FullPreferentialBallot IssueBallot(IEnumerable<Candidate> candidates)
    {
        return new FullPreferentialBallot()
        {
            Candidates = candidates
        };
    }
    
    public override bool IsInformal()
    {
        var ballotIsEmpty = Preferences.Length == 0;
        var ballotIsNotForAllCandidates = !Candidates.All(Preferences.Select(p => p.Candidate).Contains);
        var ballotIsForOtherCandidates = !Preferences
            .Select(p => p.Candidate)
            .All(Candidates.Contains);
        var ballotPreferencesNotContiguous = Preferences
            .Select((preference, index) => (preference.Rank, index + 1)).Any(tuple => tuple.Item1 != tuple.Item2);
        return ballotIsEmpty || ballotPreferencesNotContiguous || ballotIsNotForAllCandidates || ballotIsForOtherCandidates;

    }
}