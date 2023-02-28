using RT_HA_Recursion.CLI.Models;
using RT_HA_Recursion.CLI.Helpers;

var singleBranches = new List<IndividualBranch> { 
    new IndividualBranch { Id =   0, Description =   "Root level branch",  Stem = null },
    new IndividualBranch { Id =   1, Description =   "Level 1 branch 1",   Stem = 0 },
    new IndividualBranch { Id =   2, Description =   "Level 1 branch 2",   Stem = 0 },
    new IndividualBranch { Id =  11, Description =   "Level 2 branch 1-1", Stem = 1 },
    new IndividualBranch { Id =  12, Description =   "Level 2 branch 1-2", Stem = 1 },
    new IndividualBranch { Id =  13, Description =   "Level 2 branch 1-3", Stem = 1 },
    new IndividualBranch { Id =  21, Description =   "Level 2 branch 2-1", Stem = 2 },
    new IndividualBranch { Id =  22, Description =   "Level 2 branch 2-2", Stem = 2 },
    new IndividualBranch { Id = 111, Description =  "Level 3 branch 1-1-1", Stem = 11 },
    new IndividualBranch { Id = 121, Description =   "Level 3 branch 1-2-1", Stem = 12 },
    new IndividualBranch { Id = 122, Description =   "Level 3 branch 1-2-2", Stem = 12 },
    new IndividualBranch { Id = 211, Description =   "Level 3 branch 2-1-1", Stem = 21 },
    new IndividualBranch { Id = 212, Description =   "Level 3 branch 2-1-2", Stem = 21 },
    new IndividualBranch { Id = 221, Description =   "Level 3 branch 2-2-1", Stem = 22 },
    new IndividualBranch { Id = 1111, Description =   "Level 4 branch 1-1-1-1", Stem = 111 },
    new IndividualBranch { Id = 1112, Description =   "Level 4 branch 1-1-1-2", Stem = 111 },
    new IndividualBranch { Id = 2111, Description =   "Level 4 branch 2-1-1-1", Stem = 211 },
    new IndividualBranch { Id = 2111, Description =   "Level 4 branch 2-1-1-2", Stem = 211 },
    new IndividualBranch { Id = 2121, Description =   "Level 4 branch 2-1-2-1", Stem = 212 },
    new IndividualBranch { Id = 2211, Description =   "Level 4 branch 2-2-1-1", Stem = 221 },
    new IndividualBranch { Id = 2212, Description =   "Level 4 branch 2-2-1-2", Stem = 221 },
    new IndividualBranch { Id = 11121, Description =   "Level 5 branch 1-1-1-2-1", Stem = 1112 },
    new IndividualBranch { Id = 11122, Description =   "Level 5 branch 1-1-1-2-2", Stem = 1112 },
    new IndividualBranch { Id = 111221, Description =   "Level 6 branch 1-1-1-2-2-1", Stem = 11122 },
    new IndividualBranch { Id = 111222, Description =   "Level 6 branch 1-1-1-2-2-2", Stem = 11122 },
    new IndividualBranch { Id = 111223, Description =   "Level 6 branch 1-1-1-2-2-3", Stem = 11122 }
};

var branchStructure = BranchBuilder.BuildBranchStructure(singleBranches);

Console.Write(branchStructure.Depth);

Console.ReadKey();