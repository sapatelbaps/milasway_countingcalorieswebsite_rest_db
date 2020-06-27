﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CountingCalories.UI.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace CountingCalories.UI.Services
{
    public class FoodService
    {
        [Inject]
        public HttpClient _HttpClient { get; set; }

        private List<Food> allFood;

        public FoodService(HttpClient httpClient)
        {
            allFood = new List<Food>();
            _HttpClient = httpClient;
        }

        public void SaveFood(Food food)
        {
            allFood.Add(food);
            try
            {
                var json = JsonConvert.SerializeObject(food);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                _HttpClient.PostAsync("/api/food", data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task<List<Food>> GetAllFood()
        {
            try
            {
                var response = await _HttpClient.GetAsync("/api/food");
                var content = await response.Content.ReadAsStringAsync();
                var allFood = JsonConvert.DeserializeObject<List<Food>>(content);
                return allFood;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task Delete(Food food)
        {
            try
            {
                var response = await _HttpClient.DeleteAsync($"api/food/{food.Id}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Update(List<Food> allFood)
        {
            try
            {
                var json = JsonConvert.SerializeObject(allFood);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                _HttpClient.PutAsync("api/food", data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}