using System.Threading.Tasks;

namespace YGOProDeckWrapper.Library.Client
{
    public interface IYGOProDeckClient
    {
        Task GetCards(YGOProDeckRequest request);
    }
}