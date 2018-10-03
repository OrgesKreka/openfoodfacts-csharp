﻿using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenFoodFacts.Models;

namespace OpenFoodFactsTester
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            var uri = new Uri("https://world.openfoodfacts.org/api/v0/");
            var task = client.GetStringAsync(new Uri(uri, "product/3222475893421.json"));
            task.Wait();
            var body = task.Result;
            var json = JObject.Parse(body);
            var product = json["product"].ToObject<Product>();
            Console.WriteLine(JsonConvert.SerializeObject(product,Formatting.Indented));

            Console.ReadLine();
        }
    }
}