using System.Collections.Generic;

namespace VoteCounter.Elections.FirstPastThePost;

public class FirstPastThePostBallot : Ballot
{
    public override bool IsInformal()
    {
        return false;
    }

    public static FirstPastThePostBallot IssueBallot(List<Candidate> candidates)
    {
        return new FirstPastThePostBallot
        {
            Candidates = candidates
        };
    }
}