using System.Net.Http.Headers;

namespace MVCSkillsShowcaseApp.Services
{    
    public class ApiClient : IApiClient
    {
        public HttpClient Instance { get; private set; }

        public ApiClient()
        {
            Instance = new HttpClient();
            Instance.DefaultRequestHeaders.Accept.Clear();
            Instance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
        }
    }
}
