using azure.devops.repo.branch.DataObjects;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace azure.devops.repo.branch.Services;

internal class DevoService
{
    internal static async Task<List<Repository>> GetRepositories(string organization, string project, string pat)
    {
        var repositories = new List<Repository>();

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($":{pat}")));

            string url = $"https://dev.azure.com/{organization}/{project}/_apis/git/repositories?api-version=6.0";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<RepositoriesResult>(responseBody);
                repositories = result.Value;
            }
            else
            {
                Console.WriteLine($"Failed to get repositories: {response.ReasonPhrase}");
            }
        }

        return repositories;
    }
}
