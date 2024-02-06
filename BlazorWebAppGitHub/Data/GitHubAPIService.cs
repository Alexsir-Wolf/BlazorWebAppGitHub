using System.Text.Json;

namespace BlazorWebAppGitHub.Data
{
    public class GitHubAPIService
    {
        public async Task<List<GitHubAPI>> ListarUsuarios()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/users");
            request.Headers.Add("User-Agent", "'request'");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var users = await response.Content.ReadAsStringAsync();

            var gitHubApi = JsonSerializer.Deserialize<List<GitHubAPI>>(users);
            return gitHubApi;

        }

        public async Task<GitHubAPI> ObterUsuario(string? login)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.github.com/users/{login}");
            request.Headers.Add("User-Agent", "'request'");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var users = await response.Content.ReadAsStringAsync();

            var gitHubApi = JsonSerializer.Deserialize<GitHubAPI>(users);
            return gitHubApi;
        }

        public async Task<List<GitHubAPIRepos>> ListarRepoUsuario(string login)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.github.com/users/{login}/repos");
            request.Headers.Add("User-Agent", "'request'");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var users = await response.Content.ReadAsStringAsync();

            var gitHubApi = JsonSerializer.Deserialize<List<GitHubAPIRepos>>(users);
            return gitHubApi;
        }
    }
}
