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
    class CustomerPersistency
    {
        private const string ServerUrl = "http://localhost:51992/";

        public static async void SaveCustomersAsJsonAsync(Customer customers)
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
                    await client.PostAsJsonAsync("api/Customers", customers);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public static async Task<List<Customer>> UpdateCustomersFromJsonAsync(Customer customer)
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
                    var responce = client.PutAsJsonAsync(ServerUrl + "api/Customers/"+customer.Customer_Id, customer).Result;
                    if (responce.IsSuccessStatusCode)
                    {
                        var customerData = responce.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                        return customerData.ToList();
                    }
                    return null;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static async void DeleteCustomersAsync(Customer customers)
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
                    await client.DeleteAsync("api/Customers/" + customers.Customer_Id);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public static async Task<List<Customer>> LoadCustomersFromJsonAsync()
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
                    var responce = client.GetAsync("api/Customers").Result;
                    if (responce.IsSuccessStatusCode)
                    {
                        var customerData = responce.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                        return customerData.ToList();
                    }
                    return null;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
