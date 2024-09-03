namespace azure.devops.repo.branch.DataObjects;

public class Branch
{
    public string Name { get; set; }
    public Creator Creator { get; set; }
    public string ObjectId { get; set; }
}