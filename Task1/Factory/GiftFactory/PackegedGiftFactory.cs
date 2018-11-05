using Task1.Model.Gift;

namespace Task1.Factory.GiftFactory
{
    class PackegedGiftFactory : GiftFactory

    {
        public override Gift Create(string name)
        {
            return new PackagedGift(name);
        }
    }
}
