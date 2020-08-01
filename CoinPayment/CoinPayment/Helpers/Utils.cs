
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoinPayment.Helpers
{
    public static class Utils
    {
        public static List<KeyValuePair<string, string>> ToKeyValuePair(this object obj)
        {

            List<KeyValuePair<string, string>> ksv = new List<KeyValuePair<string, string>>();

            foreach (var item in obj.GetType().GetProperties())
            {
                string name = string.Empty;
                var atm = item.GetCustomAttributes(typeof(Newtonsoft.Json.JsonPropertyAttribute), false).FirstOrDefault();
                if (atm != null)
                {
                    name = ((Newtonsoft.Json.JsonPropertyAttribute)atm).PropertyName;
                }
                else name = item.Name;