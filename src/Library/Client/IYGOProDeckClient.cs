using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using YGOProDeckWrapper.Library.Models;

namespace YGOProDeckWrapper.Library.Client
{
    public interface IYGOProDeckClient
    {
        Task<IEnumerable<BaseCardResponse>> GetCardsAsync(YGOProDeckRequest request,
            CancellationToken cancellationToken = default);

        Task<IEnumerable<SetResponse>> GetCardSetsAsync(CancellationToken cancellationToken = default);
        Task<CardSetInformationResponse> GetCardSetInfoAsync(string setCode, CancellationToken cancellationToken = default);
        Task<IEnumerable<CardArchetypeResponse>> GetCardArchetypesAsync(CancellationToken cancellationToken = default);
    }
}