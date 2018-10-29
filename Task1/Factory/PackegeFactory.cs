using Task1.Model;

namespace Task1.Factory
{
    class PackegeFactory : Factory

    {
        public override Gift Create(string name)
        {
            return new PackagedGift(name);
        }
    }
}
