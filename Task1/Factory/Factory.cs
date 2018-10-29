using Task1.Model;

namespace Task1.Factory
{
    public abstract class Factory
    {
        public abstract Gift Create(string name);
    }
}
