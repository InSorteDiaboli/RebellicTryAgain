using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using WebService;
using Newtonsoft.Json;

namespace Rebellic.Persistency
{
    class ProductCategoryPersistency
    {
        private const string ServerUrl = "http://localhost:51992/";

        public static async void SaveProductCategoriesAsJsonAsync(ProductCategory productCategories)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    await client.PostAsJsonAsync("api/ProductCategories", productCategories);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public static async void DeleteProductCategoriesAsync(ProductCategory productCategories)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    await client.DeleteAsync("api/ProductCategories/" + productCategories.Category_Id);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public static async Task<List<ProductCategory>> LoadProductCategoriesFromJsonAsync()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var responce = client.GetAsync("api/ProductCategories").Result;
                    if (responce.IsSuccessStatusCode)
                    {
                        var productCategoryData = responce.Content.ReadAsAsync<IEnumerable<ProductCategory>>().Result;
                        return productCategoryData.ToList();
                    }
                    return null;
                }
                catch (NullReferenceException)
                {

                    throw;
                }
            }
        }
    }
}
