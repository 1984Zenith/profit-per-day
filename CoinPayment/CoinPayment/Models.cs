
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

        [JsonProperty("custom")]
        public string Custom { get; set; }

        [JsonProperty("ipn_url")]
        public string CallBackUrl { get; set; }




    }


    public class TransactionException : Exception
    {

        public override string Message => Error;

        [JsonProperty("error")]
        public string Error { get; set; }
    }


    public class ReceiveTransactionResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("result")]
        public ReceiveTransactionResult Result { get; set; }
    }

    public class ReceiveTransactionResult
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("txn_id")]
        public string TransactionId { get; set; }

        [JsonProperty("confirms_needed")]
        public int ConfirmsNeeded { get; set; }

        [JsonProperty("timeout")]
        public int Timeout { get; set; }

        [JsonProperty("status_url")]
        public string StatusUrl { get; set; }

        [JsonProperty("qrcode_url")]
        public string QrCodeUrl { get; set; }
    }


    public class ReceiveInfoTransaction : BaseTransaction
    {
        [JsonProperty("cmd")]
        public override string Cmd { get; set; } = "get_tx_info";

        [JsonProperty("txid")]
        public string TransactionId { get; set; }
    }


    public class SendTransaction : BaseTransaction
    {
        [JsonProperty("cmd")]
        public override string Cmd { get; set; } = "create_withdrawal";

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; } = "BTC";

        [JsonProperty("currency2")]
        public string Currency2 { get; set; } = "BTC";

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("dest_tag")]
        public string DestTag { get; set; }

        [JsonProperty("ipn_url")]
        public string CallbackUrl { get; set; }

        [JsonProperty("auto_confirm")]
        public int AutoConfirm { get; set; } = 1;

        [JsonProperty("note")]
        public string Note { get; set; }


    }

    public class SendTransactionResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("result")]
        public SendTransactionResult Result { get; set; }
    }


    public class SendTransactionResult
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }
    }



    public class IPN
    {
        [JsonProperty("ipn_version")]
        public float Version { get; set; }

        [JsonProperty("ipn_mode")]
        public string Mode { get; set; }

        [JsonProperty("ipn_type")]
        public string Type { get; set; }

        [JsonProperty("ipn_id")]
        public string Id { get; set; }

        [JsonProperty("merchant")]
        public string MerchantId { get; set; }
    }

    public class IPNWithdrawal : IPN
    {

        [JsonProperty("id")]
        public string WithdrawalID { get; set; }

        [JsonProperty("status")]