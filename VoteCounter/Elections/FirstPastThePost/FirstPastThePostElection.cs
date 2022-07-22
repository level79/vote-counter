using System;
using System.Collections.Generic;
using System.Linq;
using VoteCounter.Elections.Preferential.Full;
using VoteCounter.Elections.Results;

namespace VoteCounter.Elections.FirstPastThePost;

public class FirstPastThePostElection : Election<FirstPastThePostBallot>
{
    public FirstPastThePostElection()
    {
        _ballots = new List<FirstPastThePostBallot>();
        _informalBallots = new List<FirstPastThePostBallot>();
        Candidates = new List<Candidate>();
    }

    public override ElectionResult CountVotes()
    {
        var results = new ElectionResult();

        results.AddPreferenceRound(new DistributionRound(
            _ballots.GroupBy(ballot => ballot.Preference()).Select(ballots => new Tally(ballots.Key, _ballots.Count))
        ));
        return results;
    }

    public FirstPastThePostBallot IssueBallot()
    {
        return FirstPastThePostBallot.IssueBallot(Candidates);
    }
}