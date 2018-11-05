using System;
using Task1.Model.Candy;

namespace Task1.Factory.CandyFactory
{
    public class LollipopFactory : CandyFactory
    {
        private Random _random = new Random();

        public override Candy Create()
        {
            int randomChose = _random.Next(1, 3);
            string name;
            int weight, calories, sugar;

            if (randomChose == 1)
            {
                name = "Чупачупс";
                weight = 30;
                calories = 50;
                sugar = 15;
            }
            else
            {
                name = "Шепучка";
                weight = 10;
                calories = 10;
                sugar = 10;
            }

            return new LollipopCandy(name,weight,calories,sugar);
        }
    }
}
