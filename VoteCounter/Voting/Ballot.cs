using System.Collections.Generic;
using System.Linq;
using VoteCounter.Elections;

namespace VoteCounter.Voting;

public abstract class Ballot
{
    protected Preference[] Preferences { get; set; }
    protected IEnumerable<Candidate> Candidates { get; init; }
    public abstract bool IsInformal();

    public Candidate Preference()
    {
        return Preferences.First().Candidate;
    }

    public void AddPreferences(IEnumerable<Preference> preferences)
    {
        Preferences = preferences.OrderBy(preference => preference.Rank).ToArray();
    }
}