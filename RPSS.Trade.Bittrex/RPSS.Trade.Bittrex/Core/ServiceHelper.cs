using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RPSS.Trade.Bittrex.Core
{
    public class ServiceHelper
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private readonly HttpClient _httpClient;

        public ServiceHelper()
        {
            _httpClient = new HttpClient();
        }

        public string GenerateNonce()
        {
            var nonce = (long)(DateTime.UtcNow - Epoch).TotalSeconds;

            return nonce.ToString();
        }

        public async Task<string> GetPrivateAsync(string url, string secret)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url));
            var apiSign = GenerateApiSign(url, secret);

            request.Headers.Add("apisign", apiSign);

            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        private string GenerateApiSign(string url, string secret)
        {
            var secretBytes = Encoding.ASCII.GetBytes(secret);

            using (var hmacsha512 = new HMACSHA512(secretBytes))
            {
                var hashBytes = hmacsha512.ComputeHash(Encoding.ASCII.GetBytes(url));

                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }
    }
}
