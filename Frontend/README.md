# 🚀 PCMasterFrontend

Frontend desarrollado con **Blazor WebAssembly (.NET 8)** para la aplicación PC Master.

---

## 📦 Tecnologías

* [.NET 8](https://dotnet.microsoft.com/)
* Blazor WebAssembly
* C#
* HTML / CSS
* HTTP Client

---

## ⚙️ Requisitos

Antes de ejecutar el proyecto, asegúrate de tener instalado:

* [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download)

Verifica con:

```bash
dotnet --version
```

---

## ▶️ Ejecución del proyecto

1. Clona el repositorio:

```bash
git clone https://github.com/tu-usuario/pcmaster-frontend.git
cd pcmaster-frontend
```

2. Navega a la carpeta del proyecto (donde está el `.csproj`):

```bash
cd PCMasterFrontend
```

3. Ejecuta la aplicación:

```bash
dotnet run
```

4. Abre el navegador en:

```
https://localhost:5001
```

---

## 🔥 Desarrollo con Hot Reload

Para recargar automáticamente al guardar cambios:

```bash
dotnet watch run
```

---

## 📁 Estructura del proyecto

```
PCMasterFrontend/
│── wwwroot/        # Archivos estáticos
│── Pages/          # Páginas Razor
│── Shared/         # Componentes reutilizables
│── Program.cs      # Configuración principal
│── PCMasterFrontend.csproj
```

---

## 🔐 Autenticación

El proyecto incluye soporte para autenticación usando:

* `Microsoft.AspNetCore.Components.WebAssembly.Authentication`

Configura los endpoints en `Program.cs` según tu backend.

---

## 🌐 Consumo de APIs

Se utiliza `HttpClient` para comunicarse con el backend.

---