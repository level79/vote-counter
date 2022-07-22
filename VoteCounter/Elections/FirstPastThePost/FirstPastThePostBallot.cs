using System.Collections.Generic;
using System.Linq;

namespace VoteCounter.Elections.FirstPastThePost;

public class FirstPastThePostBallot : Ballot
{
    public override bool IsInformal()
    {
        var onlyOnePreference = Preferences.Length == 1;
        var preferencesAreForListedCandidates =
            Preferences.All(preference => Candidates.Contains(preference.Candidate));
        var isFormal = onlyOnePreference && preferencesAreForListedCandidates;
        return !isFormal;
    }

    public static FirstPastThePostBallot IssueBallot(List<Candidate> candidates)
    {
        return new FirstPastThePostBallot
        {
            Candidates = candidates
        };
    }
}