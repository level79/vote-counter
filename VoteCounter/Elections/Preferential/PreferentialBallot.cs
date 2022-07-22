using System.Collections.Generic;
using System.Linq;

namespace VoteCounter.Elections.Preferential;

public abstract class PreferentialBallot : Ballot
{
    public Candidate Preference(IEnumerable<Candidate> excludingCandidates)
    {
        return Preferences.First(preference => !excludingCandidates.Contains(preference.Candidate)).Candidate;
    }
}