# Torneo Fútbol 5 - Inscripciones

CRUD en C# Windows Forms (.NET 10) para inscribir participantes a un torneo de fútbol 5, con MySQL (XAMPP).
La categoría se asigna automáticamente según la edad y el sexo del participante.

## Requisitos

- Visual Studio Community con la carga de trabajo "Desarrollo de escritorio de .NET"
- .NET 10 SDK
- XAMPP (MySQL)

## Cómo ejecutarlo

1. Iniciar MySQL desde el panel de XAMPP.
2. En phpMyAdmin: **Importar** → elegir `BaseDeDatos/torneo_futbol5.sql`. Crea la base `torneo_futbol5` con sus tablas y datos de ejemplo.
3. Abrir `2doISFT225_SantiagoVazquez_ProyectoTorneoFutbol5.slnx` en Visual Studio y ejecutar.

La cadena de conexión está en `Conexion.cs` (usuario `root` sin contraseña, el default de XAMPP).

## Base de datos

| Tabla | Contenido |
|---|---|
| `participantes` | Datos personales de cada inscripto |
| `categorias` | Categorías del torneo con rango de edad y sexo |
| `inscripciones` | Une cada participante con su categoría; guarda fecha y si abonó |
