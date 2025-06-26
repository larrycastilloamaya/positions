# 🧭 Hikru Positions Backend

Este proyecto es una API REST desarrollada con **.NET 8** usando Clean Architecture para gestionar posiciones, reclutadores y departamentos.

---

## 🚀 Tecnologías Utilizadas

- .NET 8 (ASP.NET Core Web API)
- C# 12
- Clean Architecture (Domain, Application, Infrastructure, API)
- CQRS con MediatR
- Consumo de APIS mediante HttpClient
- xUnit + Moq (para testing)

---

## 📁 Estructura de Carpetas

```
Hikru.Positions/
├── Api/                # Controladores y configuración Web API
├── Application/        # Lógica de negocio (CQRS, DTOs, interfaces)
├── Domain/             # Entidades del dominio
├── Infrastructure/     # Implementaciones de acceso a datos (ApiGateway)
└── Tests/              # Pruebas unitarias
```

---

## 🔧 Configuración inicial

1. Asegúrate de tener acceso al endpoint de Oracle.

---

## 🧪 Ejecución y pruebas

### Ejecutar localmente

```bash
dotnet build
dotnet run --project Hikru.Positions.Api
```

### Pruebas unitarias

```bash
dotnet test
```

---

## 📡 Endpoints principales

- `GET /api/positions`
- `GET /api/positions/{id}`
- `PUT /api/positions/{id}`
- `POST /api/positions`
- `DELETE /api/positions/{id}`
- `GET /api/recruiters`
- `GET /api/departments`

> Todos siguen buenas prácticas RESTful.

---

## 🧰 Características destacadas

- Arquitectura limpia basada en capas desacopladas.
- MediatR para comandos y queries con CQRS.
- Inyección de dependencias mediante `Program.cs`.
