﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DHL_clone.Model;
using Newtonsoft.Json;

namespace DHL_clone.Persistency
{
    class PersistencyWebApi
    {
        //All orders for one user
        public static async Task<ObservableCollection<Order>> GetOrdersForUser(int userId)
        {
            ObservableCollection<Order> allOrders = new ObservableCollection<Order>();
            const string ServerUrl = "http://localhost:6738";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync($"api/Orders/{userId}/OrdersUser").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string OrdersData = response.Content.ReadAsStringAsync().Result;

                        allOrders = (ObservableCollection<Order>)JsonConvert.DeserializeObject(OrdersData, typeof(ObservableCollection<Order>));
                    }
                    return allOrders;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        //Login
        public static async Task<User> Login(User User)
        {
            const string ServerUrl = "http://localhost:6738";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            User user = new User();

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                StringContent content = new StringContent(JsonConvert.SerializeObject(User), Encoding.UTF8, "application/json");
                try
                {
                    var response = client.PostAsync($"api/Users/login", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string Data = response.Content.ReadAsStringAsync().Result;

                        user = (User)JsonConvert.DeserializeObject(Data, typeof(User));
                        return user;
                    }
                    return user;

                }
                catch (Exception ex)
                {
                    return user;
                }
            }
        }
    }
}