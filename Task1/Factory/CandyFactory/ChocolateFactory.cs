using System;
using Task1.Model.Candy;

namespace Task1.Factory.CandyFactory
{
    public class ChocolateFactory : CandyFactory
    {
        private Random _random = new Random();

        public override Candy Create()
        {
            int randomChose = _random.Next(1, 3);
            string name;
            int weight, calories, sugar;

            if (randomChose==1)
            {
                name = "Шоколадка";
                weight = 20;
                calories = 120;
                sugar = 10;
            }
            else
            {
                name = "Шоколадный батончик";
                weight = 10;
                calories = 25;
                sugar = 7;
            }

            return new ChocolateCandy(name, weight, calories, sugar);
        }
    }
}
