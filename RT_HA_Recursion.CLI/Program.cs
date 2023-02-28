using RT_HA_Recursion.CLI.Models;
using RT_HA_Recursion.CLI.Helpers;

var singleBranches = new List<IndividualBranch> { 
    new() { Id =   0, Description =   "Root level branch",  Stem = null },
    new() { Id =   1, Description =   "Level 1 branch 1",   Stem = 0 },
    new() { Id =   2, Description =   "Level 1 branch 2",   Stem = 0 },
    new() { Id =  11, Description =   "Level 2 branch 1-1", Stem = 1 },
    new() { Id =  12, Description =   "Level 2 branch 1-2", Stem = 1 },
    new() { Id =  13, Description =   "Level 2 branch 1-3", Stem = 1 },
    new() { Id =  21, Description =   "Level 2 branch 2-1", Stem = 2 },
    new() { Id =  22, Description =   "Level 2 branch 2-2", Stem = 2 },
    new() { Id = 111, Description =  "Level 3 branch 1-1-1", Stem = 11 },
    new() { Id = 121, Description =   "Level 3 branch 1-2-1", Stem = 12 },
    new() { Id = 122, Description =   "Level 3 branch 1-2-2", Stem = 12 },
    new() { Id = 211, Description =   "Level 3 branch 2-1-1", Stem = 21 },
    new() { Id = 212, Description =   "Level 3 branch 2-1-2", Stem = 21 },
    new() { Id = 221, Description =   "Level 3 branch 2-2-1", Stem = 22 },
    new() { Id = 1111, Description =   "Level 4 branch 1-1-1-1", Stem = 111 },
    new() { Id = 1112, Description =   "Level 4 branch 1-1-1-2", Stem = 111 },
    new() { Id = 2111, Description =   "Level 4 branch 2-1-1-1", Stem = 211 },
    new() { Id = 2111, Description =   "Level 4 branch 2-1-1-2", Stem = 211 },
    new() { Id = 2121, Description =   "Level 4 branch 2-1-2-1", Stem = 212 },
    new() { Id = 2211, Description =   "Level 4 branch 2-2-1-1", Stem = 221 },
    new() { Id = 2212, Description =   "Level 4 branch 2-2-1-2", Stem = 221 },
    new() { Id = 11121, Description =   "Level 5 branch 1-1-1-2-1", Stem = 1112 },
    new() { Id = 11122, Description =   "Level 5 branch 1-1-1-2-2", Stem = 1112 },
    new() { Id = 111221, Description =   "Level 6 branch 1-1-1-2-2-1", Stem = 11122 },
    new() { Id = 111222, Description =   "Level 6 branch 1-1-1-2-2-2", Stem = 11122 },
    new() { Id = 111223, Description =   "Level 6 branch 1-1-1-2-2-3", Stem = 11122 }
};

var branchStructure = BranchBuilder.BuildBranchStructure(singleBranches);
var structureDepth = BranchExtensions.FindBranchStructureDepth(branchStructure, singleBranches.Count);


Console.WriteLine($"The deepest extent the provided branch graph goes to is: {structureDepth}");

Console.ReadKey();