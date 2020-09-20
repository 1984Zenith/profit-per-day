
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
