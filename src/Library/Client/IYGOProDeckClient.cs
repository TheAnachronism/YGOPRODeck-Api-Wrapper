using System.Collections.Generic;
using System.Threading.Tasks;
using YGOProDeckWrapper.Library.Models;

namespace YGOProDeckWrapper.Library.Client
{
    public interface IYGOProDeckClient
    {
        Task<List<BaseCardResponse>> GetCards(YGOProDeckRequest request);
    }
}