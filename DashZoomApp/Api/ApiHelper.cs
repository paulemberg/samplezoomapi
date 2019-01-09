using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DashZoomApp.Models;
using Jose;

namespace DashZoomApp.Api
{
    public class ApiHelper
    {
     
        /// <summary>
        /// This is a simple way to use key for test application
        /// for production follow the best practices
        /// </summary>
        private static string apiKey = "<YOUR API KEY>";
        private static string apiSecret = "<YOUR API SECRET KEY>";
        private static string uriRooms = "https://api.zoom.us/v2/metrics/zoomrooms";
        private static string baseAddress = "https://api.zoom.us/v2/";
        



        public HttpClient CreatClient()
        {
            var client = new HttpClient();
            SetupClientDefaults(client);
            return client;
        }

        protected virtual void SetupClientDefaults(HttpClient client)
        {
            var payload = new Dictionary<string, object>()
            {
                { "iss",apiKey },
                { "exp", UnixTimeStampUTC().ToString() }
            };

            var secretConverted = Encoding.ASCII.GetBytes(apiSecret);
            string token = Jose.JWT.Encode(payload, secretConverted, JwsAlgorithm.HS256);

            client.Timeout = TimeSpan.FromSeconds(30); //set your own timeout.
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<RoomsViewModel.ZooObject> GetRooms()
        {
            var client = CreatClient();
            using (HttpResponseMessage response = await client.GetAsync(uriRooms))
            {
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsAsync<RoomsViewModel.ZooObject>().Result;
                    return res;
                }

            }

            return null;
        }
        
        private Int32 UnixTimeStampUTC()
        {
            DateTime currentTime = DateTime.Now.AddHours(1);
            DateTime zuluTime = currentTime.ToUniversalTime();
            DateTime unixEpoch = new DateTime(1970, 1, 1);
            var unixTimeStamp = (int)(zuluTime.Subtract(unixEpoch)).TotalSeconds;
            return unixTimeStamp;
        }
    }
}
