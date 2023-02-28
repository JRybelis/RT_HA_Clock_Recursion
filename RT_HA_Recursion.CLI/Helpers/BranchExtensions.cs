using RT_HA_Recursion.CLI.Models;

namespace RT_HA_Recursion.CLI.Helpers;
public static class BranchExtensions
{
    public static int FindBranchStructureDepth(Branch branchStructure, int numberOfBranches)
    {
        const int depthCounter = 0;
        const int iterationNo = 0;
        var depths = new int[numberOfBranches];
        var wasVisited = new bool[numberOfBranches];

        FindBranchStructureDepthInner(branchStructure, wasVisited, depths, iterationNo, depthCounter);

        var maxDepth = depths.Max();

        return maxDepth;
    }

    private static void FindBranchStructureDepthInner(Branch branchStructure, bool[] wasVisited, int[] depths, int iterationNo, int depthCounter)
    {
        if (wasVisited[iterationNo])
        {
            iterationNo = Array.FindIndex(wasVisited, wv => wv == false);
            depthCounter++;
        }
        wasVisited[iterationNo] = true;
        Console.WriteLine($"Traversing the {branchStructure.Description}.");
        
        if (branchStructure.StemBranch is null)
        {
            iterationNo = 0;
            depths[iterationNo] = depthCounter;
        }
        else
        {
            var adjacentBranches = branchStructure.StemBranch.Branches.ToList();
            var currentBranch = adjacentBranches.FirstOrDefault(cb => cb.Id == branchStructure.Id);
            
            if (currentBranch.Depth == 0)
            {
                depthCounter++;
                foreach (var adjacentBranch in adjacentBranches)
                    adjacentBranch.Depth = depthCounter;
            }
        }

        depths[iterationNo] = depthCounter;
        iterationNo++;
        
        foreach (var subBranch in branchStructure.Branches)
        {
            FindBranchStructureDepthInner(subBranch, wasVisited, depths, iterationNo, depthCounter);
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