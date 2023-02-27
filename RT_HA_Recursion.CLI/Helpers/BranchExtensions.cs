using RT_HA_Recursion.CLI.Models;

namespace RT_HA_Recursion.CLI.Helpers;
public static class BranchExtensions
{
    

    public static IEnumerable<Branch> FindSubBranches(this Branch value)
    {
        // a branch is the branch itself and any branching branch of its branching branches
        if (value is null) 
            yield break;

        yield return value;

        foreach (var branch in value.Branches)
        {
            foreach (var subBranch in value.FindSubBranches())
            {
                yield return subBranch;
            }
        }
    }

    public static IEnumerable<Branch> FindStems(this Branch value) 
    {
        // stem is the branch itself and any stemming branch of its stemming branch
        var stem = value;

        while (stem != null) 
        {
            yield return stem;
            stem = stem.StemBranch;
        }
    }
}