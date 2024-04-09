<p align="center">
    <img width="300" alt="Galileo logo" src="./assets/5b-icon.jpeg" />
</p>

<h3 align="center">WebApi Assignments - 5B🚀</h3>

# Pre requisitos

- [Instalar .NET Core v6](https://dotnet.microsoft.com/es-es/download/dotnet/6.0)
- [Instalar Docker Desktop](https://www.docker.com/get-started/)
- [Instalar Docker Compose](https://docs.docker.com/compose/install/)
- [Instalar Gestor de base de datos](https://tableplus.com/download)

# Documentación
El webApi consiste un gestor de tareas, en donde se podrá definir la categoría de dicha tarea y el usuario asignado a la misma.

## Pruebas

### 1. Descargar la imagen de postgres 14

```bash
docker pull postgres:14.3
```

### 2. Levantar la base de datos mediante docker compose
Esto se debe realizar en una terminal a parte, en la raiz del proyecto, para que se mantenga la instancia corriendo mientras se realizan las pruebas.

```bash
docker-compose up
```

### 3. Compilar el proyecto

```bash
dotnet build
```

### 4. Ejecutar las migraciones

```bash
dotnet ef database update
```

### 5. Ejecutar el proyecto

```bash
dotnet run
```

El webapi se levantara en la URL:

```bash
http://localhost:5065/
```

## Datos de Contacto

- Nombre: Christian Osorio
- Email: ccdosorio11@gmail.com
- Tel: +502 40962591