using System;

namespace Task1.Model.Gift
{
    class PackagedGift : Gift
    {
        public override void Open()
        {
            if (!Opened)
            {
                Opened = true;
                Console.WriteLine("Package open");
            }
        }

        public PackagedGift(string name) : base(name)
        {
        }
    }
}
