using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Queries;

namespace Backend.Interaction.Domain.Services;

public interface IWishlistQueryService
{
    Task<IEnumerable<Wishlist>> Handle(GetWishlistByUserId query);
}