﻿namespace Task1.Model
{
    public class Candy
    {
        public string Name { get; }
        public int Calories { get; }
        public int Weight { get;}
        public int Sugar { get;}

        public Candy(string name, int calories, int weight, int sugar)
        {
            Name = name;
            Calories = calories;
            Weight = weight;
            Sugar = sugar;
        }
    }
}
