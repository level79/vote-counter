using System.Collections.Generic;
using VoteCounter.Voting;

namespace VoteCounter.Elections.FirstPastThePost.MultiCandidate;

public class MultiCandidateFirstPastThePostBallot : Ballot
{
    private int RequiredCandidates { get; set; }

    public override bool IsInformal()
    {
        var requiredCandidatesPreferences = Preferences.Length == RequiredCandidates;
        return !requiredCandidatesPreferences;
    }

    public static MultiCandidateFirstPastThePostBallot IssueBallot(List<Candidate> candidates,
        int requiredCandidates)
    {
        return new MultiCandidateFirstPastThePostBallot()
        {
            Candidates = candidates,
            RequiredCandidates = requiredCandidates
        };
    }
}