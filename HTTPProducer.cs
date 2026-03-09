namespace KafkaCsharp;

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class HTTPProducer
{
    public static async Task RunAsync()
    {
        var restEndpoint = Environment.GetEnvironmentVariable("REST_ENDPOINT");
        var clusterId    = Environment.GetEnvironmentVariable("CLUSTER_ID");
        var topicName    = Environment.GetEnvironmentVariable("TOPIC_NAME");
        var basicAuth    = Environment.GetEnvironmentVariable("BASIC_AUTH"); // base64(apiKey:secret)

        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic", basicAuth);

        var payload = new
        {
            key = new { type = "STRING", data = "order-1001" },
            value = new
            {
                type = "JSON",
                data = JsonSerializer.Serialize(new
                {
                    orderId   = 1001,
                    customerId = "C-8743",
                    drugCode  = "AMOX500",
                    quantity  = 2,
                    status    = "DISPENSED"
                })
            }
        };

        var json = JsonSerializer.Serialize(payload);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var url = $"{restEndpoint}/kafka/v3/clusters/{clusterId}/topics/{topicName}/records";
        var resp = await client.PostAsync(url, content);
        var body = await resp.Content.ReadAsStringAsync();

        Console.WriteLine($"Status: {(int)resp.StatusCode}");
        Console.WriteLine(body);
    }
}
