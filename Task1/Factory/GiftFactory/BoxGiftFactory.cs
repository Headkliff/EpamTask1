using Task1.Model;
using Task1.Model.Gift;

namespace Task1.Factory.GiftFactory
{
    class BoxGiftFactory : GiftFactory
    {
        public override Gift Create(string name)
        {
            return new BoxedGift(name);
        }
    }
}
