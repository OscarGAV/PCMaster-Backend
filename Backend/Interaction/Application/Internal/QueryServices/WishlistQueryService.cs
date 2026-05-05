using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Queries;
using Backend.Interaction.Domain.Repositories;
using Backend.Interaction.Domain.Services;

namespace Backend.Interaction.Application.Internal.QueryServices;

public class WishlistQueryService : IWishlistQueryService
{
    private readonly IWishlistRepository _wishlistRepository;

    public WishlistQueryService(IWishlistRepository wishlistRepository)
    {
        _wishlistRepository = wishlistRepository;
    }

    public async Task<IEnumerable<Wishlist>> Handle(GetWishlistByUserId query)
    {
        return await _wishlistRepository.FindWishlistByUserIdAsync(query.UserId.UsrId);
    }
}