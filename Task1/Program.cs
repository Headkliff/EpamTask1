using System;
using System.Collections.Generic;
using Task1.Factory;
using Task1.Factory.GiftFactory;
using Task1.Model;
using Task1.Model.Candy;
using Task1.Model.Gift;

namespace Task1
{
    class Program
    {
        private static List<Gift> _gifts = new List<Gift>();
        private static BoxGiftFactory _boxFactory=new BoxGiftFactory();
        private static PackegedGiftFactory _packageFactory=new PackegedGiftFactory();

        static void Main(string[] args)
        {
            _gifts.Add(_boxFactory.Create("Happy birthday"));
            _gifts.Add(_boxFactory.Create("New Year"));
            _gifts.Add(_packageFactory.Create("Just gift"));

            View();
        }

        private static void View()
        {
            Console.Clear();
            Console.WriteLine("1-Create Gift \n2-Sort candies on gift \n3-Find candy by sugar\n4-Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    CreateGift();
                    break;
                case "2":
                    SortBy();
                    break;
                case "3":
                    Find();
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Error: no such menu item! \nPress any key ...");
                    Console.ReadKey();
                    View();
                    break;

            }
        }

        private static Gift Show()
        {
            Console.Clear();
            int i = 0;
            Console.WriteLine("All Gifts:");
            foreach (var item in _gifts)
            {
                i++;
                Console.WriteLine($"  {i}-{item.Name}");
            }

            Console.WriteLine("Enter gift name");
            string name = Console.ReadLine();

            var q = _gifts.Find(x => x.Name.Equals(name));

            if (q !=null)
            {
                return q;
            }
            else
            {
                Console.WriteLine("Error: Not matches \n Press any key...");
                View();
            }

            return null;
        }

        private static void Find()
        {
            var gift = Show();

            Console.Clear();

            Console.WriteLine("Enter min sugar value: ");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter max sugar value: ");
            int max = Convert.ToInt32(Console.ReadLine());

            var result = gift.FindCandies(min, max);


            foreach (var item in result)
            {
                Console.WriteLine($"Candy name: {item.Name} || Calories: {item.Calories} || Weight: {item.Weight} || Sugar: {item.Sugar}");
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
            View();
        }

        private static void SortBy()
        {
            IList<ICandy> candies = null;
            var gift = Show();
            Console.WriteLine("Choose parameter for sort:\n 1-By Name\n 2-By Weight\n 3-By Calories\n 4-By Sugar");
            var param = Console.ReadLine();
            Console.WriteLine("Choose sort type:\n 1-Ascending\n 2-Descending");
            var type = Convert.ToInt32(Console.ReadLine());

            if (param != null && param.Equals("1"))
            {
                 candies= gift.SortByParam<ICandy>(candy => candy.Name, type);
            }
            if (param != null && param.Equals("2"))
            {
                candies = gift.SortByParam<ICandy>(candy => candy.Weight, type);
            }
            if (param != null && param.Equals("3"))
            {
                candies = gift.SortByParam<ICandy>(candy => candy.Calories, type);
            }
            if (param != null && param.Equals("4"))
            {
                candies = gift.SortByParam<ICandy>(candy => candy.Sugar, type);
            }

            foreach (var item in candies)
            {
                Console.WriteLine($"Name: {item.Name} || Weight: {item.Weight} || Calories: {item.Calories} || Sugar: {item.Sugar}");
            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();
            View();

        }

        private static void CreateGift()
        {
            Console.Clear();
            Console.WriteLine("Chose type of gift:\n 1-Box \n 2-Package\n3-Return");
            Gift item;
            string name;
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Enter the gift name");
                    name= Console.ReadLine();

                    if (!_gifts.Exists(x => x.Name != name))
                    {
                        Console.WriteLine("Error: A gift with the same name already exists\nPress any key...");
                        Console.ReadKey();
                        CreateGift();
                    }
                    else
                    {
                        item = _boxFactory.Create(name);
                        _gifts.Add(item);
                        Console.Clear();
                        Console.WriteLine(
                            $"Gift Info \n Name: {item.Name} \n Weight: {item.Weight} \nPress anu key ...");
                        Console.ReadKey();
                        View();
                    }

                    break;

                case "2":
                    Console.WriteLine("Enter the gift name");
                    name = Console.ReadLine();
                    if (!_gifts.Exists(x => x.Name != name))
                    {
                        Console.WriteLine("Error: A gift with the same name already exists\nPress any key...");
                        Console.ReadKey();
                        CreateGift();
                    }
                    else
                    {
                        item = _packageFactory.Create(name);
                        _gifts.Add(item);
                        Console.Clear();
                        Console.WriteLine(
                            $"Gift Info \n Name: {item.Name} \n Weight: {item.Weight} \nPress anu key ...");
                        Console.ReadKey();
                        View();
                    }

                    break;

                case "3":
                    View();
                    break;
            }

            
        }
    }   
}
