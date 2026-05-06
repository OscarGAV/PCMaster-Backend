namespace PCMasterFrontend.Models.Wishlist;

public class WishlistDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ComponentId { get; set; }
    public int Quantity { get; set; }
}

public class CreateWishlistRequest
{
    public int UserId { get; set; }
    public int ComponentId { get; set; }
    public int Quantity { get; set; }
}

public class UpdateWishlistRequest
{
    public int Quantity { get; set; }
}
