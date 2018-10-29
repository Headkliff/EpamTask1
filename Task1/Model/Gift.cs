using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1.Model
{
    public abstract class Gift
    {
        public string Name { get; }
        public int Weight { get; }
        public List<Candy> Candies;

        protected Gift(string name)
        {
            
            Name = name;
            Candies = new List<Candy>();
            int currentWeight = 0;

            Random random = new Random();
            int times = random.Next(5, 20);

            for (int i = 0; i < times; i++)
            {
                int param = random.Next(1, 4);
                Candy candy = null;

                if (param == 1)
                {
                    candy = new Candy("Алёнка", 15, 30, 5);
                    currentWeight = candy.Weight;
                }
                if (param == 2)
                {
                    candy = new Candy("Шепучка", 5, 17, 3);
                    currentWeight = candy.Weight;
                }
                if (param == 3)
                {
                    candy = new Candy("Шоколадка", 20, 120, 10);
                    currentWeight = candy.Weight;
                }
                if (param == 4)
                {
                    candy = new Candy("Шоколадный батончик", 10, 25, 7);
                    currentWeight = candy.Weight;
                }


                Candies.Add(candy);
                
            }

            Weight = currentWeight;
        }

        public abstract void Open();

        public List<Candy> FindCandies(int minValue,int maxValue)
        {
            Open();

            var candy = Candies.Where(item => item.Sugar > minValue && item.Sugar < maxValue);

            return candy.ToList();
        }

        public List<Candy> SortByParam(List<Candy> candys)
        {
            Console.Clear();

            Open();
            Console.WriteLine("Select the option to sort:\n 1-By Name\n 2-By Weight\n 3-By Calories\n 4-By Sugar");

            IOrderedEnumerable<Candy> query;
            switch (Console.ReadLine())
            {
                case "1":
                    query = candys.OrderBy(item => item.Name);
                    return query.ToList();
                    
                case "2":
                    query = candys.OrderBy(item => item.Weight);
                    return query.ToList();
                    
                case "3":
                    query = candys.OrderBy(item => item.Calories);
                    return query.ToList();
                    
                case "4":
                    query = candys.OrderBy(item => item.Sugar);
                    return query.ToList();

                default:
                    return null;
                    
            }
        }
    }
}