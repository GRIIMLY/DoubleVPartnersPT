# Proyecto de Autenticación y Consulta de Personas

Este proyecto es una aplicación web desarrollada en .NET Core 7, Angular 15, y SQL Server, que permite a los usuarios iniciar sesión y consultar información de personas. 

## Tecnologías utilizadas

- .NET Core 7
- Angular 15
- Node.js 18.14.0
- SQL Server

## Requisitos previos

Asegúrate de tener instalados los siguientes programas:

- [Visual Studio 2022](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/)
- [.NET SDK 7.0](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Node.js 18.14.0](https://nodejs.org/download/release/v18.14.0/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Angular CLI](https://cli.angular.io/)

## Configuración del backend

1. **Clonar el repositorio**:

    ```bash
    git clone https://github.com/GRIIMLY/DoubleVPartnersPT.git
    cd DoubleVPartnersPT
    ```

2. **Configuración de la base de datos**:

    - Restaura la base de datos utilizando el script proporcionado en `\DoubleVPartnersPT\ScriptsDB`.

    - Actualiza la cadena de conexión en `appsettings.json` con los detalles de tu base de datos:

    ```json
    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*",
      "ConnectionStrings": {
        "Connectionkey": "Server=NICOLAS\\SQLEXPRESS01;Database=PTDoublePartners;User Id=AdminPartner;password=21sadf2342;TrustServerCertificate=True;MultipleActiveResultSets=true;"
      }
    }
    ```

3. **Aplicar migraciones y actualizar la base de datos**:

    ```bash
    dotnet ef database update
    ```

4. **Ejecutar el proyecto**:

    ```bash
    dotnet run
    ```

    El backend debería estar ejecutándose en `https://localhost:5001` o `http://localhost:5000`.

## Configuración del frontend

1. **Ir al directorio del frontend**:

    ```bash
    cd DoubleVPartnersFrontEnd
    ```

2. **Instalar dependencias**:

    ```bash
    npm install
    ```

3. **Configurar el entorno**:

    Actualiza `src/environments/environment.ts` con la URL de tu API:

    ```typescript
    export const environment = {
      production: false,
      APIBackend: 'http://localhost:5129/'
    };
    ```

4. **Ejecutar la aplicación Angular**:

    ```bash
    ng serve
    ```

    La aplicación debería estar ejecutándose en `http://localhost:4200`.

## Uso de la aplicación

### Inicio de sesión

1. Ve a `http://localhost:4200/home`.
2. Registrate en "Registrarse".
2. Ingresa tus credenciales y haz clic en "Iniciar sesión".

### Consultar personas

1. Después de iniciar sesión, serás redirigido a la página de consulta de personas o tu perfil.
2. Verás una tabla con las propiedades `NumeroIdentificacionConcatenado` y `NombresApellidosConcatenados` de las personas.
2. Si estas en tu perfil encontrarás un formulario para datos personales.


## Scripts útiles

- **Ejecutar el backend**:

    ```bash
    dotnet run
    ```

- **Ejecutar el frontend**:

    ```bash
    cd DoubleVPartnersFrontEnd
    ng serve
    ```

- **Aplicar migraciones**:

    ```bash
    dotnet ef database update
    ```



## Licencia

Este proyecto está licenciado bajo la [MIT License](LICENSE).


