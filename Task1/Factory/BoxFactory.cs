using Task1.Model;

namespace Task1.Factory
{
    class BoxFactory : Factory
    {
        public override Gift Create(string name)
        {
            return new BoxedGift(name);
        }
    }
}
