# PC Master Platform

## Backend
API REST para la plataforma PC Master, construida con ASP.NET Core 8 y MySQL.

## Frontend (Blazor WebAssembly)
Aplicación frontend que consume todos los endpoints del backend.

### Requisitos
- .NET 8 SDK
- Backend corriendo en `http://localhost:5175`

### Ejecución
```bash
cd Frontend
dotnet run
```

El frontend se levanta en `https://localhost:7001` (o `http://localhost:5001`).

### Estructura del Frontend
```
Frontend/
├── Models/          # DTOs para requests y responses
├── Services/        # Interfaces e implementaciones para cada área de la API
├── Infrastructure/  # HttpClient, Auth, Constants
├── Shared/          # Layout, NavMenu, Footer
├── Pages/           # Páginas Blazor organizadas por dominio
└── wwwroot/         # CSS, JS, index.html
```

### API Base URL
`http://localhost:5175/api/v1/`

### Paleta de Colores
- **Azul Noche** (#001014): Solidez y confiabilidad
- **Light grayish violet** (#f6f3f9): Frescura y descanso visual
- **Very pale blue** (#d1f2ff): Limpieza y ligereza
- **Light blue** (#45caff): Énfasis y simplicidad
- **Very light pink** (#ff6b9f): Dimensión apasionada
- **Bright pink** (#e8317e): Energía
- **Vivid pink** (#ff1b6b): Llamados a la acción
