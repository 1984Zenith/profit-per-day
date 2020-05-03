
﻿using CoinPayment.Helpers;
using Flurl.Http;
using Flurl.Http.Content;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinPayment
{
    public class CoinApi
    {
        public const string Url = "https://www.coinpayments.net/api.php";
        public readonly string publicApiKey;
        public readonly string privateApiKey;


        public CoinApi(string publicApiKey,string privateApiKey)
        {
            this.publicApiKey = publicApiKey;
            this.privateApiKey = privateApiKey;
        }

        public  async Task<ReceiveTransactionResponse> ReceiveAsync(ReceiveTransaction transaction)
        {

            var result = await SendRequestAsync(transaction);

            if (result.IsSuccessStatusCode)
            {
                var str = await result.Content.ReadAsStringAsync();
                try
                {
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ReceiveTransactionResponse>(str);
                    return data;
                }
                catch
                {
                    var data = JsonConvert.DeserializeObject<TransactionException>(str);
                    throw data;
                }

            }
            else throw new TransactionException { Error = result.StatusCode.ToString() };

        }



        private  async Task<HttpResponseMessage> SendRequestAsync(BaseTransaction transaction)
        {