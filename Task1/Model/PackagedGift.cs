using System;

namespace Task1.Model
{
    class PackagedGift : Gift
    {
        protected override void Open()
        {
            Console.WriteLine("Package open");
        }

        public PackagedGift(string name) : base(name)
        {
        }
    }
}
