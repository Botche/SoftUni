using P02_Composite.Gifts;

namespace P02_Composite.Interfaces
{
    public interface IGiftOperations
    {
        void Add(GiftBase gift);

        void Remove(GiftBase gift);
    }
}
