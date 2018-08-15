using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;

namespace ForSprinterra.Models
{
    public static class Token
    {
        public static string clientId { get; set; }
        public static string token { get; set; }
        public static string baseUrl { get; set; }

        public static bool Validate(string _clientId, string _token, string _baseUrl)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Auth-Client", _clientId);
            client.DefaultRequestHeaders.Add("X-Auth-Token", _token);

            string url = String.Format("{0}catalog", _baseUrl);

            HttpResponseMessage response = client.GetAsync(url).Result;
            if ((int)response.StatusCode == 405)
            {
                clientId = _clientId;
                token = _token;
                baseUrl = _baseUrl;
                return true;
            }
            return false;
        }
    }
}