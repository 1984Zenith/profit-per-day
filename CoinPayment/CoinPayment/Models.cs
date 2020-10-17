
﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinPayment
{
    public abstract class BaseTransaction
    {



        [JsonProperty("version")]
        public int Version { get; set; } = 1;

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("cmd")]
        public virtual string Cmd { get; set; }
    }




    public class ReceiveTransaction : BaseTransaction
    {
        [JsonProperty("cmd")]
        public override string Cmd { get; set; } = "create_transaction";

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("currency1")]
        public string Currency1 { get; set; } = "BTC";

        [JsonProperty("currency2")]
        public string Currency2 { get; set; } = "BTC";


        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("buyer_email")]
        public string BuyerEmail { get; set; }

        [JsonProperty("buyer_name")]
        public string BuyerName { get; set; }

        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [JsonProperty("item_number")]
        public string ItemNumber { get; set; }

        [JsonProperty("invoice")]
        public string Invoice { get; set; }
