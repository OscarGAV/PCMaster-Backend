namespace PCMasterFrontend.Infrastructure.Constants;

public static class ApiRoutes
{
    public const string BaseUrl = "http://localhost:5175/api/v1/";
}

public static class Endpoints
{
    public const string SignIn = "authentication/sign-in";
    public const string SignUp = "authentication/sign-up";

    public const string Users = "users";
    public static string UserById(int id) => $"users/{id}";

    public const string Components = "components";
    public static string ComponentById(int id) => $"components/{id}";

    public const string Technicians = "technicians";
    public const string TechniciansTopRanked = "technicians/top-ranked";
    public static string TechnicianById(int id) => $"technicians/{id}";

    public const string TechnicalSupport = "technical-support";
    public static string TechnicalSupportById(int id) => $"technical-support/{id}";
    public static string TechnicalSupportFiltered(bool supportType, int? technicianId = null)
        => $"technical-support/{supportType}" + (technicianId.HasValue ? $"?technicianId={technicianId}" : "");

    public const string Cart = "cart";
    public static string CartByUser(int userId) => $"cart/user/{userId}";
    public static string CartById(int id) => $"cart/{id}";

    public const string Wishlist = "wishlist";
    public static string WishlistByUser(int userId) => $"wishlist/user/{userId}";
    public static string WishlistById(int id) => $"wishlist/{id}";

    public const string ComponentReview = "component-review";
    public static string ComponentReviewByComponent(int componentId) => $"component-review/{componentId}";
    public static string ComponentReviewById(int id) => $"component-review/{id}";

    public const string TechnicalSupportReview = "technical-support-review";
    public static string TechnicalSupportReviewByTs(int tsId) => $"technical-support-review/{tsId}";
    public static string TechnicalSupportReviewById(int id) => $"technical-support-review/{id}";
}
