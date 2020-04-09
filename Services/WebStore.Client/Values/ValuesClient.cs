using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebStore.Client.Base;
using WebStore.Interfaces.Api;

namespace WebStore.Client.Values
{
    public class ValuesClient : BaseClient, IValuesService
    {
        public ValuesClient(IConfiguration configuration) : base(configuration, "api/Values") { }

        public HttpStatusCode Delete(int id) => DeleteAsync(id).Result;

        public async Task<HttpStatusCode> DeleteAsync(int id)
        {
            var response = await _Client.DeleteAsync($"{_ServiceAdress}/delete/{id}");
            return response.StatusCode;
        }

        public IEnumerable<string> Get() => GetAsync().Result;

        public string Get(int id) => GetAsync(id).Result;

        public async Task<IEnumerable<string>> GetAsync()
        {
            var response = await _Client.GetAsync(_ServiceAdress);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<IEnumerable<string>>();
            return Enumerable.Empty<string>();
        }

        public async Task<string> GetAsync(int id)
        {
            var response = await _Client.GetAsync($"{_ServiceAdress}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<string>();
            return string.Empty;
        }

        public Uri Post(string value) => PostAsync(value).Result;

        public async Task<Uri> PostAsync(string value)
        {
            var response = await _Client.PostAsJsonAsync($"{_ServiceAdress}/post", value);
            return response.EnsureSuccessStatusCode().Headers.Location;
        }

        public HttpStatusCode Put(int id, string value) => PutAsync(id, value).Result;

        public async Task<HttpStatusCode> PutAsync(int id, string value)
        {
            var response = await _Client.PutAsJsonAsync($"{_ServiceAdress}/put/{id}", value);
            return response.EnsureSuccessStatusCode().StatusCode;
        }
    }
}
