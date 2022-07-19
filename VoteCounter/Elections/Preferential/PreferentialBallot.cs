using System.Collections.Generic;
using System.Linq;
using VoteCounter.Voting;

namespace VoteCounter.Elections.Preferential;

public abstract class PreferentialBallot
{
    protected Preference[] Preferences { get; set; }
    protected IEnumerable<Candidate> Candidates { get; init; }

    public Candidate Primary => Preferences.First().Candidate;
    public abstract bool IsInformal();

    public Candidate Preference(IEnumerable<Candidate> eliminatedCandidates)
    {
        return Preferences.First(preference => !eliminatedCandidates.Contains(preference.Candidate)).Candidate;
    }

    public void AddPreferences(IEnumerable<Preference> preferences)
    {
        Preferences = preferences.OrderBy(preference => preference.Rank).ToArray();
        ;
    }
}