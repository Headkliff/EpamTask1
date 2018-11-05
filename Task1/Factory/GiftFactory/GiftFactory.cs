using Task1.Model.Gift;

namespace Task1.Factory.GiftFactory
{
    public abstract class GiftFactory
    {
        public abstract Gift Create(string name);
    }
}
