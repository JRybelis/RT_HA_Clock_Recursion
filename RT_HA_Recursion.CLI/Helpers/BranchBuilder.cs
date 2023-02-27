using RT_HA_Recursion.CLI.Models;

namespace RT_HA_Recursion.CLI.Helpers;
public static class BranchBuilder
{
    public static Branch BuildBranchStructure(IEnumerable<SingleBranch> singleBranches)
    {
        if (singleBranches is null)
            return new Branch();

        var singleBranchList = singleBranches.ToList();
        var branch = FindRootBranch(singleBranchList);

        BuildBranchStructure(branch, singleBranchList);

        return branch;
    }

    private static void BuildBranchStructure(Branch branchStructure, 
    IList<SingleBranch> subBranches)
    {
        var branches = subBranches.Where(singleBranch => 
        singleBranch.Stem == branchStructure.Id).ToArray();

        foreach (var branch in branches)
        {
            var newBranch = Map(branch);
            branchStructure.AddBranches(newBranch);
            subBranches.Remove(branch); // layer already traversed
        }
        
        foreach (var branch in branchStructure.Branches)
            BuildBranchStructure(branch, subBranches);
    }

    private static Branch FindRootBranch(IList<SingleBranch> singleBranches)
    {
        var rootBranches = singleBranches.Where(singleBranch => 
        singleBranch.Stem is null);

        if (rootBranches.Count() != 1)
            return new Branch();

        var rootBranch = rootBranches.Single();
        singleBranches.Remove(rootBranch);

        return Map(rootBranch);
    }

    private static Branch Map(SingleBranch singleBranch)
    {
        return new Branch
        {
            Id = singleBranch.Id,
            Description = singleBranch.Description
        };
    }
}
