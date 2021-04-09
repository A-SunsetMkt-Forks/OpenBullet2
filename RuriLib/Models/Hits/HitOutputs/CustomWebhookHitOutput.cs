﻿using Newtonsoft.Json;
using RuriLib.Functions.Time;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RuriLib.Models.Hits.HitOutputs
{
    public class CustomWebhookHitOutput : IHitOutput
    {
        public string Url { get; set; } = "http://mycustomwebhook.com";
        public string User { get; set; } = "Anonymous";

        public CustomWebhookHitOutput(string url, string user)
        {
            Url = url;
            User = user;
        }

        public async Task Store(Hit hit)
        {
            var data = new CustomWebhookData
            {
                Data = hit.Data.Data,
                CapturedData = hit.CapturedDataString,
                ConfigName = hit.Config.Metadata.Name,
                ConfigAuthor = hit.Config.Metadata.Author,
                Timestamp = hit.Date.ToUnixTime(),
                Type = hit.Type,
                User = User
            };

            using var httpClient = new HttpClient();
            await httpClient.PostAsync(Url,
                new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
        }
    }
}