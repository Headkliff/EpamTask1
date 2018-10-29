using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Task1.Model
{
    public abstract class Gift
    {
        [StringLength(15, MinimumLength = 5)]
        public string Name { get; }
        public int Weight { get; }
        public List<Candy> Candies;

        protected Gift(string name)
        {
            
            Name = name;
            Candies = new List<Candy>();
            int currentWeight = 0;

            Random random = new Random();
            int times = random.Next(5, 15);
            for (int i = 0; i < times; i++)
            {
                int param = random.Next(1, 4);
                Candy candy = null;

                if (param == 1)
                {
                    candy = new Candy("Алёнка", 15, 30, 5);
                }
                if (param == 2)
                {
                    candy = new Candy("Шипучка", 5, 17, 3);
                }
                if (param == 3)
                {
                    candy = new Candy("Шоколадка", 20, 120, 10);
                }
                if (param == 4)
                {
                    candy = new Candy("Шоколадный батончик", 10, 25, 7);
                }

                if (candy != null)
                {
                    currentWeight = candy.Weight;
                    Candies.Add(candy);
                }
            }

            Weight = currentWeight;
        }

        protected abstract void Open();

        public List<Candy> Find(int minValue,int maxValue)
        {
            Open();

            var candy = Candies.Where(item => item.Sugar > minValue && item.Sugar < maxValue);

            return candy.ToList();
        }

        public void SortByParam(int param)
        {

        }
    }
}