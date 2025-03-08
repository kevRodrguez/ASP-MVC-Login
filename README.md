## Resumen

Aplicación MVC en .NET 9.0 con Entity Framework Core y SQL Server. Incluye migraciones y configuraciones para desarrollo.

## Dependencias

- .NET 9.0 o superior

## Dependencias Adicionales

- Microsoft.EntityFrameworkCore.Design (9.0.2)
- Microsoft.EntityFrameworkCore.SqlServer (9.0.2)

Para instalarlas:

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.2
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.2
```

## Uso

1. Instalar .NET 9.0 y restaurar paquetes con:

    ```
    dotnet restore
    ```

2. Para correr la aplicación con Hot Reload, instalar la extensión “C#” o “C# Dev Kit” y usar:

    ```
    dotnet watch run
    ```
