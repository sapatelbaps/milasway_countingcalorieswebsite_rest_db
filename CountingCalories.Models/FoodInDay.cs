﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountingCalories.UI.Models
{
    public class FoodPerDay
    {
        public int Id { get; set; }
        public List<FoodEntry> AllFoodEntries { get; set; }
        public string Day { get; set; }
    }
}
