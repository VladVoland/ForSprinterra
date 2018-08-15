using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using ForSprinterra.Models.ProductModels;

namespace ForSprinterra.Models
{
    public class ProductManagement
    {
        //HttpClientHandler handler;
        static HttpClient client;
        //string baseUrl;

        public List<Product> GetProducts()
        {
            if (!CreateClient())
            {
                return null;
            }
            string url = "catalog/products";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var productsData = response.Content.ReadAsAsync<ProductCollection>().Result.products;
                return productsData;
            }

            return null;
        }


        public Product GetProductById(int id)
        {
            if (!CreateClient())
            {
                return null;
            }
            string url = String.Format("catalog/products/{0}", id);

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var product = response.Content.ReadAsAsync<ProductSingle>().Result;

                return product.data;
            }

            return null;
        }

        public Product GetProductById2(int id)
        {
            if (!CreateClient())
            {
                return null;
            }
            string url = "catalog/products";
            var values = new Dictionary<string, string>
            {
                { "thing1", "hello" },
                { "thing2", "world" }
            };

            var content = new FormUrlEncodedContent(values);

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var product = response.Content.ReadAsAsync<ProductSingle>().Result;

                return product.data;
            }

            return null;
        }

        public List<ProductImage> GetProductImages(int productId)
        {
            if (!CreateClient())
            {
                return null;
            }
            string url = String.Format("catalog/products/{0}/images", productId);

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var productsData = response.Content.ReadAsAsync<ProductImageCollection>().Result.images;
                return productsData;
            }

            return null;
        }

        public List<Product> GetProductsByKeyword(string keyword)
        {
            if (!CreateClient())
            {
                return null;
            }
            string url = String.Format("catalog/products?keyword={0}", keyword);

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var productsData = response.Content.ReadAsAsync<ProductCollection>().Result.products;
                return productsData;
            }

            return null;
        }

        public bool Delete(int id)
        {
            if (!CreateClient())
            {
                return false;
            }
            string url = String.Format("catalog/products?id={0}", id);

            HttpResponseMessage response = client.DeleteAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
        private bool CreateClient()
        {
            //handler = new HttpClientHandler();
            //handler.Credentials = new NetworkCredential(username, api_key);
            try
            {
                client = new HttpClient()
                {
                    BaseAddress = new Uri(Token.baseUrl),
                };
                client.DefaultRequestHeaders.Add("X-Auth-Client", Token.clientId);
                client.DefaultRequestHeaders.Add("X-Auth-Token", Token.token);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}