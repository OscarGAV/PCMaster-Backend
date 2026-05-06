namespace PCMasterFrontend.Infrastructure.Exceptions;

public class ForbiddenAccessException : Exception
{
    public string? Endpoint { get; }

    public ForbiddenAccessException(string? endpoint = null)
        : base(ResolveMessage(endpoint))
    {
        Endpoint = endpoint;
    }

    private static string ResolveMessage(string? endpoint)
    {
        if (string.IsNullOrEmpty(endpoint))
            return "No tienes permiso para realizar esta acción.";

        if (endpoint.Contains("users"))
            return "Solo los administradores pueden acceder a la lista de usuarios.";
        if (endpoint.Contains("technicians") && (endpoint.Contains("create") || endpoint.Contains("edit") || endpoint.Contains("delete")))
            return "Solo los administradores pueden gestionar técnicos.";
        if (endpoint.Contains("components") && endpoint.Contains("create"))
            return "Solo los técnicos pueden crear componentes.";
        if (endpoint.Contains("cart") && (endpoint.Contains("create") || endpoint.Contains("delete")))
            return "Solo los clientes pueden gestionar el carrito.";
        if (endpoint.Contains("wishlist"))
            return "Solo los clientes pueden gestionar la wishlist.";
        if (endpoint.Contains("component-review") && (endpoint.Contains("create") || endpoint.Contains("edit") || endpoint.Contains("delete")))
            return "Solo los clientes pueden gestionar reseñas de componentes.";

        return "No tienes permiso para realizar esta acción.";
    }
}

public class UnauthorizedApiAccessException : Exception
{
    public UnauthorizedApiAccessException()
        : base("Tu sesión ha expirado. Por favor, inicia sesión nuevamente.")
    {
    }
}
