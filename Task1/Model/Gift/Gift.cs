using System;
using System.Collections.Generic;
using System.Linq;
using Task1.Factory.CandyFactory;
using Task1.Model.Candy;

namespace Task1.Model.Gift
{
    public abstract class Gift
    {
        public string Name { get; }
        public int Weight { get; }
        public bool Opened { get; set; }

        protected IList<ICandy> Candies;

        private Random _random = new Random(); 

        protected Gift(string name)
        {
            Name = name;
            Opened = false;
            Candies = new List<ICandy>();
            int currentWeight = 0;
            int times = _random.Next(15, 40);

            for (int i = 0; i < times; i++)
            {
                ICandy candy = RandomCandy();
                Candies.Add(candy);
                currentWeight = currentWeight +candy.Weight;
            }
            Weight = currentWeight;
        }

        public abstract void Open();

        public IList<ICandy> FindCandies(int minValue,int maxValue)
        {
            Open();
           
            var candy = Candies.Where(item => item.Sugar > minValue && item.Sugar < maxValue);

            return candy.ToList();
        }

        public IList<TCandy> SortByParam<TCandy>(Func<TCandy, object> func,int param) where TCandy : ICandy
        {
            Console.Clear();
            Open();

            IOrderedEnumerable<TCandy> query;
            switch (param)
            {
                case 1:
                    query = Candies.OfType<TCandy>().OrderBy(func);
                    return query.ToList();
                case 2:
                    query = Candies.OfType<TCandy>().OrderByDescending(func);
                    return query.ToList();
                default:
                    return null;
                    
            }
        }

        private ICandy RandomCandy()
        {
            int param = _random.Next(1,3);
            ICandy candy;

            switch (param)
            {
                case 1:
                    LollipopFactory lollipopFactory = new LollipopFactory();
                    candy = lollipopFactory.Create();

                    return candy;
                default:
                    ChocolateFactory chocolateFactory = new ChocolateFactory();
                    candy = chocolateFactory.Create();

                    return candy;
            }
        }
    }
}