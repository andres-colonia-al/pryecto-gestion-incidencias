# Incident Management API

## 📌 Descripción

Este proyecto es una API diseñada para la gestión de incidentes, donde los usuarios pueden registrar problemas y los técnicos se encargan de su resolución. Cuenta con autenticación, manejo de comentarios y filtrado avanzado de incidentes. Se ha desarrollado utilizando **.NET 8, PostgreSQL, JavaScript, AJAX, HTML5 y Bootstrap**.

## 🛠 Tecnologías Utilizadas

- **Backend:** ASP.NET Core (.NET 8), Entity Framework Core
- **Base de Datos:** PostgreSQL
- **Frontend:** HTML5, JavaScript, AJAX, Bootstrap
- **Autenticación:** Validación de usuarios mediante base de datos
- **Arquitectura:** Separación en capas (`Application`, `Domain`, `Infrastructure` y `Web`)

- ## 🚀 Instalación y Ejecución

### 1️⃣ Clonar el Repositorio

```sh
git clone https://github.com/usuario/IncidentManagement.git
cd IncidentManagement
```
### 2️⃣ Configurar la Base de Datos
Abrir el archivo **appsettings.json** y modificar la cadena de conexión con los datos de tu servidor PostgreSQL:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=incidentdb;Username=postgres;Password=tu_contraseña"
}
```
### 3️⃣ Ejecutar Migraciones
Para crear la base de datos y las tablas necesarias, ejecutar:

```sh
dotnet ef database update
```
Una vez creada la base de datos, insertar datos de prueba ejecutando el siguiente script SQL:

```sql
INSERT INTO Users (Name, Email, Password)
VALUES
('Usuario1', 'user1@example.com', '123455');

INSERT INTO Technicians (Name, Email, Password, RoleTechnician)
VALUES
('Tecnico1', 'tech1@example.com','123456','Junior');
```

### 4️⃣ Iniciar la Aplicación
```sh
dotnet run --project IncidentManagement.web
```

### 🔗 Endpoints Disponibles
🔑 Autenticación
- **POST** /api/login → Iniciar sesión

- ## 👤 Usuarios
- **GET** /api/users/{id} → Obtener usuario por ID

- **POST** /api/users → Crear un nuevo usuario

- ## 🔧 Técnicos
- **POST** /api/technician → Registrar un técnico

- ## 📌 Incidentes
- **POST** /api/incidents → Crear un incidente

- **GET** /api/incidents/user/{userId} → Consultar incidentes de un usuario

- **GET** /api/incidents → Filtrar incidentes según criterios

- **PUT** /api/incidents/{id}/state → Modificar estado de un incidente

- **DELETE** /api/incidents/{id}/delete → Eliminar un incidente

- ## 💬 Comentarios
- **POST** /api/comment → Añadir un comentario

- **GET** /api/comment/{incidentId} → Consultar comentarios de un incidente

## Información Adicional

- **Interfaz Dinámica:** Se usa AJAX para actualizar los datos sin necesidad de recargar la
página.
- **Estilos Responsivos:** Se ha implementado Bootstrap para mejorar la apariencia y
usabilidad del sistema.
- **Manejo de Errores:** Respuestas HTTP estructuradas para cada caso (validaciones, errores
de servidor, etc.). también se manejaron errores desde el frontend evitando el envío de
formularios con datos nulos.

## Buenas Prácticas Implementadas

- **Arquitectura en Capas:** Separación entre dominio, aplicación, infraestructura y
presentación.
- **Inyección de Dependencias:** Se utilizan servicios inyectados en los controladores,
repositorios, mapper y servicios para facilitar el mantenimiento y utilización.
- **Entity Framework Core:** EF Core para realizar migraciones y acceder a la base de datos
PostgreSQL, manteniendo el esquema actualizado y gestionando los repositorios de datos.
- **AJAX y JavaScript:** permite solicitudes asíncronas, mejorando la experiencia del usuario
sin recargar la página, como en la creación de incidentes o comentarios.
- **Uso de DTOs:** Se usan DTOs para transferir solo los datos necesarios, mejorando la
seguridad. Los mappers convierten las entidades en DTOs antes de ser devueltos o
almacenados.

## Autor
- **Andres Felipe Colonia Aldana**

