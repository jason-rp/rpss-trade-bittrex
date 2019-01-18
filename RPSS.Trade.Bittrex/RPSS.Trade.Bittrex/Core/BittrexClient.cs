using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RPSS.Trade.Bittrex.Core.Models;

namespace RPSS.Trade.Bittrex.Core
{
    public class BittrexClient
    {
        private readonly ServiceHelper _serviceHelper;
        private const string BaseAddress = "https://bittrex.com/api";
        

        private readonly string _apiKey = "39a7db483b0c44268ddc0000bf58c800";
        private readonly string _apiSecret = "ed71e7a6166841e2ae7f953db453761c";

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

        public async Task<ApiResult<AccountBalanceModel>> GetBalance(string currencyName)
        {
            var nonce = _serviceHelper.GenerateNonce();

            var url = $"{_accountBaseUrl}/getbalance?apiKey={_apiKey}&nonce={nonce}&currency={currencyName}";

            var json = await _serviceHelper.GetPrivateAsync(url, _apiSecret).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<ApiResult<AccountBalanceModel>>(json);
        }

    }
}
