using Agilite.DataTransferObject.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Agilite.UI.Services;

internal class ContactServices
{
    public async Task<IEnumerable<ContactDto>> GetContacts()
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(HttpClientService.ApiAddress);
        var result = await client.GetAsync("api/Contact/GetAllContacts");
        var content = await result.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IEnumerable<ContactDto>>(content)!;
    }
}