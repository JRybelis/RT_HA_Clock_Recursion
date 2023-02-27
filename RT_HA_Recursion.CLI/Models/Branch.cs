using RT_HA_Recursion.CLI.Helpers;
using System.Diagnostics;

namespace RT_HA_Recursion.CLI.Models;
public class Branch
{
    public int? Id { get; set; }
    public string Description { get; set; }
    protected List<Branch>? branches;
    protected Branch? stemBranch;

    public Branch()
    {
        Description = string.Empty;
    }
    public Branch StemBranch 
    { 
        get 
        { 
            return stemBranch; 
        } 
    }
    public Branch Root 
    { 
        get
        {
            return stemBranch is null ? this : stemBranch.Root;
        }
    }
    public int Depth 
    { 
        get
        {
            return this.FindStems().Count() - 1;
        }
    }
    public IEnumerable<Branch> Branches 
    {
        get 
        {
            return branches is null ? Enumerable.Empty<Branch>() 
            : branches.ToArray();
        }
    }

    public override string ToString()
    {
        return Description;
    }

    public void AddBranches(Branch branchToAdd)
    {
        if (branchToAdd is null)
            throw new ArgumentNullException();
        if (branchToAdd.stemBranch is not null)
            throw new InvalidOperationException
            ("A branch must be removed from its stem before adding as sub-branch.");
        if (this.FindStems().Contains(branchToAdd))
            throw new InvalidOperationException(
                "The branch structure must be a non-cyclic tree.");
        if (branches is null)
            branches = new List<Branch>();
        
        Debug.Assert(!branches.Contains(branchToAdd), 
        "Branch in question is not a subBranch");

        branchToAdd.stemBranch = this;
        branches.Add(branchToAdd);
    }

    public bool RemoveBranches(Branch branchToRemove)
    {
        if (branchToRemove is null)
            throw new ArgumentNullException();
        if (branchToRemove.stemBranch != this)
            return false;
        
        Debug.Assert(branches.Contains(branchToRemove), 
        "Branch in question is a subBranch.");

        branchToRemove.stemBranch = null;
        branches.Remove(branchToRemove);

        if (!branches.Any())
            branches = null;

        return true;
    }
}