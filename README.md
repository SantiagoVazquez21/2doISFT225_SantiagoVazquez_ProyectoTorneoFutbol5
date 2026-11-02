# Torneo Fútbol 5 - Inscripciones

CRUD en C# Windows Forms (.NET 10) para inscribir participantes a un torneo de fútbol 5, con base de datos MySQL en la nube (TiDB Cloud).
La categoría se asigna automáticamente según la edad y el sexo del participante.

## Requisitos

- Visual Studio Community con la carga de trabajo "Desarrollo de escritorio de .NET"
- .NET 10 SDK
- Acceso a la base en TiDB Cloud (o XAMPP para trabajar en local)

## Cómo ejecutarlo

1. En la carpeta del proyecto, copiar `conexion.ejemplo.txt` como `conexion.local.txt`.
2. Completar en `conexion.local.txt` el host, usuario y contraseña de TiDB (botón **Connect** del cluster).
3. Abrir `2doISFT225_SantiagoVazquez_ProyectoTorneoFutbol5.slnx` en Visual Studio y ejecutar.

`conexion.local.txt` está en el `.gitignore` porque contiene la contraseña: no se sube al repositorio.

### Trabajar en local con XAMPP

1. Iniciar MySQL desde el panel de XAMPP.
2. En phpMyAdmin: **Importar** → `BaseDeDatos/torneo_futbol5.sql` (crea la base con sus tablas y datos de ejemplo).
3. En `conexion.local.txt` usar la línea de XAMPP en lugar de la de TiDB.

## Base de datos

| Tabla | Contenido |
|---|---|
| `participantes` | Datos personales de cada inscripto |
| `categorias` | Categorías del torneo con rango de edad y sexo |
| `inscripciones` | Une cada participante con su categoría; guarda fecha y si abonó |
