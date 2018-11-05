using System;

namespace Task1.Model.Gift
{
    class BoxedGift : Gift
    {
        public override void Open()
        {
            if (!Opened)
            {
                Opened = true;
                Console.WriteLine("Box open");
            }
        }

        public BoxedGift(string name) : base(name)
        {
        }
    }
}
