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

        HelperMethods.SaveToCsv(repositories, $"{outputFilePath}\\repos.csv");
    }
}