namespace PCMasterFrontend.Models.Cart;

public class CartDto
{
    public int Id { get; set; }
    public int ComponentId { get; set; }
    public int UserId { get; set; }
    public int Quantity { get; set; }
}

public class CreateCartRequest
{
    public int ComponentId { get; set; }
    public int UserId { get; set; }
    public int Quantity { get; set; }
}
