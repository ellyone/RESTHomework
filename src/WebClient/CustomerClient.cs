using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace WebClient;

public class CustomerClient
{
    private static HttpClient Client = new HttpClient();

    public static async Task<Customer> GetCustomer(long id)
    {
        var response = await Client.GetAsync($"https://localhost:5001/api/customers/{id}");
        var result = await response.Content.ReadAsStringAsync();
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return JsonSerializer.Deserialize<Customer>(result);
        }
        else if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return new Customer();
        }
        else
        {
            throw new UnreachableException();
        }
    }

    public static async Task<long> AddCustomer(Customer customer)
    {
        StringContent content = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");
        var response = await Client.PostAsync($"https://localhost:5001/api/customers", content);
        var result = await response.Content.ReadAsStringAsync();
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return JsonSerializer.Deserialize<Customer>(result).ID ?? -1;
        }
        else if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return -1;
        }
        else
        {
            throw new UnreachableException();
        }
    }
}