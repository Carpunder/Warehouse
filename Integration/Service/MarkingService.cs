using System.Net.Http;
using Newtonsoft.Json;
using WpfApp1.Integration.Contracts;
using WpfApp1.Integration.Models;

namespace WpfApp1.Integration.Service;

public class MarkingService : IMarkingService
{
    public Marking? GetMission()
    {
        var client = new HttpClient();

        var result = client
            .GetAsync(new Uri("http://promark94.marking.by/client/api/get/task/")).Result;

        return JsonConvert.DeserializeObject<Marking>(result.Content.ReadAsStringAsync().Result);
    }
}