using System;

namespace Task1.Model
{
    class BoxedGift : Gift
    {
        protected override void Open()
        {
            Console.WriteLine("Box open");
        }

        public BoxedGift(string name) : base(name)
        {
        }
    }
}
