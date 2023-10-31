namespace MVCSkillsShowcaseApp.Services
{
    public interface IApiClient
    {
        HttpClient Instance { get; }
    }
}
