using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace Clockwork.Web.Helpers
{
    public class APIHelper
    {
        public APIHelper()
        {
            this._settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Auto,
                ObjectCreationHandling = ObjectCreationHandling.Replace,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            };

            this._httpClient = new HttpClient();
        }

        private readonly HttpClient _httpClient;
        private readonly JsonSerializerSettings _settings;

        public T GetFromURL<T>(string url)
        {
            try
            {
                var response = _httpClient.GetAsync(url).Result; // GetRequestAsync(url).Result;
                return ValidateAndDeserialize<T>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default(T);
            }
        }

        private T ValidateAndDeserialize<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;
                var objectToReturn = JsonConvert.DeserializeObject<T>(jsonString, _settings);

                return objectToReturn;
            }
            else
            {
                return default(T);
            }
        }
    }
}