using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace WebStore.Client.Base
{
    public abstract class BaseClient : IDisposable
    {
        protected readonly string _ServiceAdress;
        protected readonly HttpClient _Client;
        
        protected BaseClient(IConfiguration configuration, string ServiceAdress)
        {
            _ServiceAdress = ServiceAdress;
            _Client = new HttpClient
            {
                BaseAddress = new Uri(configuration["WebApiURL"])
            };
            _Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _Disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (_Disposed || !disposing) return;
            _Disposed = true;
            _Client.Dispose();
        }
    }
}
