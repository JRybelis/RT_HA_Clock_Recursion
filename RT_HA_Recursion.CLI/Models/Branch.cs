using RT_HA_Recursion.CLI.Helpers;
using System.Diagnostics;

namespace RT_HA_Recursion.CLI.Models;
public class Branch
{
    public int? Id { get; init; }
    
    public string? Description { get; init; }
    
    public Branch? StemBranch { get; private set; }

    public int Depth { get; set; }
    
    private List<Branch>? _branches;
    
    public IEnumerable<Branch> Branches =>
        _branches?.ToArray() ?? Enumerable.Empty<Branch>();

    public Branch()
    {
        Description = string.Empty;
    }
    
    
    public override string? ToString()
    {
        return Description;
    }

    public void AddBranches(Branch branchToAdd)
    {
        if (branchToAdd is null)
            throw new ArgumentNullException();
        if (branchToAdd.StemBranch is not null)
            throw new InvalidOperationException
            ("A branch must be removed from its stem before adding as sub-branch.");
        if (this.FindStems().Contains(branchToAdd))
            throw new InvalidOperationException(
                "The branch structure must be a non-cyclic tree.");
        
        _branches ??= new List<Branch>();
        
        Debug.Assert(!_branches.Contains(branchToAdd), 
        "Branch in question is not a subBranch");

        branchToAdd.StemBranch = this;
        _branches.Add(branchToAdd);
    }
}