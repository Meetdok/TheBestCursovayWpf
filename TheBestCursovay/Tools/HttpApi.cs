﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace TheBestCursovay.Tools
{
    internal class HttpApi
    {
        HttpClient client = new HttpClient();
        string host = "https://localhost:7247/api/";
        JsonSerializerOptions jsonOpt = new JsonSerializerOptions { 
            PropertyNameCaseInsensitive = true, 
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve };

        public async Task<string> Post(string controller, string method, object body)
        {
            string url = host + controller;
            if (!string.IsNullOrEmpty(method))
                url += $"/{method}";

            Type type = body.GetType();
            string json = JsonSerializer.Serialize(body, type, jsonOpt);
            var response = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
            return await response.Content.ReadAsStringAsync();
        }

        internal T Deserialize<T>(string json) where T : class
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json, jsonOpt);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        static HttpApi instance;

        public static HttpApi GetInstance()
        {
            if (instance == null)
                instance = new HttpApi();
            return instance;
        }
    }
}
