using azure.devops.repo.branch.DataObjects;
using azure.devops.repo.branch.Helpers;
using azure.devops.repo.branch.Services;

namespace azure.devops.repo.branch;
class program
{
    static async Task Main(string[] args)
    {
        // Replace these with your Azure DevOps details
        string organization = "replace-with-your-organization";
        string project = "replace-with-your-project";
        string pat = "replace-with-your-personal-access-token";
        string outputFilePath = "replace-with-file-path";

        await ExtractRepoBranches(organization, project, pat, outputFilePath);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
    private static async Task ExtractRepoBranches(string organization, string project, string pat, string outputFilePath)
    {
        // Get repositories
        List<Repository> repositories = await DevoService.GetRepositories(organization, project, pat);

        var allBranches = new List<Result>();

        // Get branches for each repository
        foreach (var repo in repositories)
        {
            List<Branch> branches = await DevoService.GetBranches(organization, project, repo.Id, pat);

            Console.WriteLine($"Branches in Repository '{repo.Name}':");

            foreach (var branch in branches)
            {
                allBranches.Add(new Result
                {
                    RepoId = repo.Id,
                    RepoName = repo.Name,
                    RepoWebUrl = repo.WebUrl,
                    BranchName = branch.Name,
                    BranchCreator = branch.Creator.DisplayName,
                    BranchObjectId = branch.ObjectId
                });
                Console.WriteLine($"- {branch.Name}");
            }
            Console.WriteLine();
        }

        HelperMethods.SaveToCsv(allBranches, $"{outputFilePath}\\repoBranches.csv");
    }
}