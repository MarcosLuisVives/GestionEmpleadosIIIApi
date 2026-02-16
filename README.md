# GestionEmpleadosIII

Aplicación cliente .NET MAUI (interfaz) para gestión de empleados, departamentos y sedes. Consume una API REST (por defecto en `http://localhost:8080/`) y muestra listados, detalles y operaciones CRUD básicas.

Resumen rápido
- Plataforma: .NET MAUI (proyecto en la carpeta `GestionEmpleadosIII`)
- TFM objetivo: .NET 10 (usar Visual Studio 2026 con workload MAUI)
- API esperada: REST JSON en `http://localhost:8080/` (endpoints como `/empleados/`, `/departamentos/`, `/sedes/`)
- Serialización: las llamadas usan una convención snake_case (ver `JsonSerializerOptions` en los servicios).

<img width="1919" height="1004" alt="image" src="https://github.com/user-attachments/assets/94c0f18b-f949-48e6-bbc2-7a4a82453223" />


<img width="1903" height="819" alt="image" src="https://github.com/user-attachments/assets/8cab4ee1-c9fe-437b-b92c-185234d9c382" />

Requisitos
- Visual Studio 2026 con el workload de .NET MAUI instalado.
- SDK .NET correspondiente (net10).
- Backend REST accesible (por defecto: `http://localhost:8080/`).
- Emuladores / dispositivos (Android/iOS) correctamente configurados si no se ejecuta en Windows.

Estructura principal del proyecto
- `GestionEmpleadosIII` (proyecto MAUI)
  - `Pages/` — páginas XAML (por ejemplo: `MainPage.xaml`, `DepartPage.xaml`, `DetalleEmpleadoPage.xaml`)
  - `PageModels/` — viewmodels / page models
  - `Services/` — servicios REST: `EmpleService.cs`, `DeparService.cs`, `SedeService.cs`
  - `Resources/Styles/` — colores, estilos y templates XAML (`Colors.xaml`, `Styles.xaml`, `Templates.xaml`)
  - `MauiProgram.cs` — configuración de DI y registro de páginas/servicios

Servicios y configuración de la API
- Los servicios REST usan `HttpClient` y `JsonSerializerOptions` con `PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower`.
- Base URI por defecto definida en:
  - `GestionEmpleadosIII/Services/EmpleService.cs`
  - `GestionEmpleadosIII/Services/DeparService.cs`
  - `GestionEmpleadosIII/Services/SedeService.cs`
  - Busca la línea que declara `baseUri = new(string.Format("http://localhost:8080/"));` y cámbiala por tu URL si es necesario.

Registro de dependencias
- En `MauiProgram.cs` se registran los servicios y las páginas con `builder.Services.AddTransient<...>()`. El contenedor DI proporciona los page models y páginas que usa la app.

Cómo ejecutar (recomendado)
1. Abrir la solución en Visual Studio 2026.
2. Seleccionar plataforma destino (Windows, Android, iOS) y ejecutar (F5).
   - Asegúrate que el backend esté corriendo en la URL configurada.
3. Alternativa CLI mínima:
   - Instala workloads si hace falta: __dotnet workload install maui__
   - Restaurar y compilar: __dotnet restore__ y __dotnet build__
   - Ejecuta desde Visual Studio para aprovechar emuladores y despliegue.

Notas importantes / Troubleshooting
- Si usas un emulador Android y el backend corre en la máquina host (localhost), reemplaza `http://localhost:8080/` por `http://10.0.2.2:8080/` (emulador Android estándar). Para Genymotion u otros emuladores la IP puede variar.
- CORS: la API debe permitir peticiones desde la app si se usan políticas de seguridad.
- Serialización: la app espera nombres en snake_case. Si la API devuelve camelCase u otra convención, ajusta `JsonSerializerOptions` o adapta el backend.
- Errores de compilación: revisar modelos en `Models/` (por ejemplo, inicializadores de listas) y dependencias registradas en `MauiProgram.cs`.

Rutas / endpoints usados (ejemplos)
- `GET /empleados/` — lista empleados (`EmpleService.GetAllAsync`)
- `GET /empleados/{id}` — obtener empleado
- `POST /empleados/` — crear empleado
- `PATCH /empleados/{id}` — actualizar empleado
- `DELETE /empleados/{id}` — eliminar empleado
- Similar para `/departamentos/` y `/sedes/` (ver `DeparService` y `SedeService`)

Cómo cambiar la URL de la API
1. Abrir `GestionEmpleadosIII/Services/EmpleService.cs` y `DeparService.cs` (y `SedeService.cs`).
2. Actualizar la declaración:
   - Ejemplo: `Uri baseUri = new(string.Format("https://api.miempresa.com/"));`
3. Para emuladores Android, sustituir por `http://10.0.2.2:8080/` si el backend está en la máquina host.

Estilos y recursos
- Los estilos y templates están en `Resources/Styles/` y se cargan desde `App.xaml` mediante `MergedDictionaries`.
- Plantillas visuales están en `Templates.xaml` (por ejemplo `CardEmple`, `CardDepart`).

Contribuir
- Abrir un issue o pull request en el repositorio remoto.
- Mantener la convención de inyección de dependencias en `MauiProgram.cs` y la convención de serialización (snake_case) a menos que se acuerde cambiarla en todo el proyecto.

Contacto / notas finales
- El proyecto depende del backend; pruebas end-to-end requieren la API activa y accesible desde el dispositivo/emulador seleccionado.

