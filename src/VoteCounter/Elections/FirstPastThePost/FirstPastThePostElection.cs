using System.Collections.Generic;
using System.Linq;
using VoteCounter.Elections.Results;

namespace VoteCounter.Elections.FirstPastThePost;

public class FirstPastThePostElection : Election<FirstPastThePostBallot>
{
    public FirstPastThePostElection()
    {
        FormalBallots = new List<FirstPastThePostBallot>();
        InformalBallots = new List<FirstPastThePostBallot>();
        Candidates = new List<Candidate>();
    }

    public override ElectionResult CountVotes()
    {
        var results = new ElectionResult();

        results.AddPreferenceRound(new DistributionRound(
            FormalBallots.GroupBy(ballot => ballot.Preference())
                .Select(ballots => new Tally(ballots.Key, FormalBallots.Count))
        ));
        return results;
    }

    public FirstPastThePostBallot IssueBallot()
    {
        return FirstPastThePostBallot.IssueBallot(Candidates);
    }
}