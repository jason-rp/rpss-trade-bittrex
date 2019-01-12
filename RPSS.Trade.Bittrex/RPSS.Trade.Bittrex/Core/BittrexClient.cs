using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RPSS.Trade.Bittrex.Core.Models;

namespace RPSS.Trade.Bittrex.Core
{
    public class BittrexClient
    {
        private ServiceHelper _serviceHelper;
        private const string BaseAddress = "https://bittrex.com/api";
        

        private readonly string _apiKey = "";
        private readonly string _apiSecret = "";

        private readonly string _publicBaseUrl;
        private readonly string _accountBaseUrl;
        private readonly string _marketBaseUrl;

        private readonly string _apiVersion = "v1.1";

        public BittrexClient()
        {
            _serviceHelper = new ServiceHelper();

            _publicBaseUrl = $"{BaseAddress}/{_apiVersion}/public";
            _accountBaseUrl = $"{BaseAddress}/{_apiVersion}/account";
            _marketBaseUrl = $"{BaseAddress}/{_apiVersion}/market";
        }

        public async Task<ApiResult<AccountBalanceModel[]>> GetBalances()
        {
            var nonce = _serviceHelper.GenerateNonce();

            var url = $"{_accountBaseUrl}/getbalances?apikey={_apiKey}&nonce={nonce}";

            var json = await _serviceHelper.GetPrivateAsync(url, _apiSecret).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<ApiResult<AccountBalanceModel[]>>(json);
        }

    }
}
