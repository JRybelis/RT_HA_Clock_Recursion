using RT_HA_Recursion.CLI.Models;

namespace RT_HA_Recursion.CLI.Helpers;
public static class BranchBuilder
{
    public static Branch BuildBranchStructure(IEnumerable<IndividualBranch>? flattenedIndividualBranches)
    {
        if (flattenedIndividualBranches is null)
            return new Branch();

        var flattenedIndividualBranchList = flattenedIndividualBranches.ToList();
        var branchStructure = FindRootBranch(flattenedIndividualBranchList);

        BuildBranchStructure(branchStructure, flattenedIndividualBranchList);

        return branchStructure;
    }

    private static void BuildBranchStructure(Branch branchStructure, 
    ICollection<IndividualBranch> flattenedIndividualBranches)
    {
        var branches = flattenedIndividualBranches.Where(individualBranch => 
        individualBranch.Stem == branchStructure.Id).ToArray();

        foreach (var branch in branches)
        {
            var newBranch = Map(branch);
            branchStructure.AddBranches(newBranch);
            flattenedIndividualBranches.Remove(branch); // node in layer already traversed
        }
            
        foreach (var subBranch in branchStructure.Branches)
            BuildBranchStructure(subBranch, flattenedIndividualBranches);
    }

    private static Branch FindRootBranch(ICollection<IndividualBranch> flattenedIndividualBranches)
    {
        var rootBranches = flattenedIndividualBranches.Where(individualBranch => 
        individualBranch.Stem is null);

        if (rootBranches.Count() != 1)
            return new Branch();

        var rootBranch = rootBranches.Single();
        flattenedIndividualBranches.Remove(rootBranch);

        return Map(rootBranch);
    }

    private static Branch Map(IndividualBranch individualBranch)
    {
        return new Branch
        {
            Id = individualBranch.Id,
            Description = individualBranch.Description
        };
    }
}
