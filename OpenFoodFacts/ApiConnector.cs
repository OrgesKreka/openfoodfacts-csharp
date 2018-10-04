﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenFoodFacts.Login;
using OpenFoodFacts.Product;
using OpenFoodFacts.Tools;

namespace OpenFoodFacts
{
    public class ApiConnector
    {
        private readonly ILoginApi loginApi;
        private readonly IProductApi productApi;

        private readonly Uri baseUri;
        private readonly HttpClient client;

        public ApiConnector(string country = "world", string locale = "en", bool isTest = false)
        {
            baseUri = Utils.BuildBaseUri(country, locale, isTest);
            client = new HttpClient();

            loginApi = new LoginApi(baseUri, ref client);
            productApi = new ProductApi(baseUri, ref client);
        }

        #region IProductApi Bridge
        public async Task<ProductData> GetProductByCodeAsync(string code)
        {
            return await productApi.GetAsync(code);
        }
        #endregion IProductApi Bridge

        #region ILoginApi Bridge
        public async Task<bool> LoginAsync(string user, string pass)
        {
            return await loginApi.LoginAsync(user, pass);
        }

        public async Task<bool> LogoutAsync()
        {
            return await loginApi.LogoutAsync();
        }
        #endregion ILoginApi Bridge
    }
}
