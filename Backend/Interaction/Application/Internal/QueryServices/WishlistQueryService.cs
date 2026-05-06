using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Queries;
using Backend.Interaction.Domain.Repositories;
using Backend.Interaction.Domain.Services;

namespace Backend.Interaction.Application.Internal.QueryServices;

public class WishlistQueryService(IWishlistRepository wishlistRepository) : IWishlistQueryService
{
    public async Task<IEnumerable<Wishlist>> Handle(GetWishlistByUserId query)
    {
        return await wishlistRepository.FindWishlistByUserIdAsync(query.UserId.UsrId);
    }
}