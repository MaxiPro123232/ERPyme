# ERPyME – Sistema Integral de Gestión Empresarial para PyMEs

ERP de escritorio en **C# / Windows Forms (.NET 9)** con **Entity Framework Core** y arquitectura
**MVC (Modelo – Vista – Controladora)**, desarrollado como Trabajo Práctico de Ingeniería de Software.
Se abre con **Visual Studio 2026** mediante la solución `ERPyME.sln` de la raíz del repositorio
(contiene el proyecto `ERPyME.WinForms`).

Requisitos: .NET 9 SDK y SQL Server Express local (`localhost\SQLEXPRESS`, autenticación de Windows).

## Base de datos

El acceso a datos usa **Entity Framework Core** con entidades mapeadas **exactamente al esquema de `Base de datos.sql`**
(base `ERPyME`, tablas `usuarios`, `grupos`, `permisos`, `usuario_grupo`, `grupo_permiso`, `clientes`, `proveedores`,
`rubros`, `productos`, `compras`, `detalle_compra`, `ventas`, `detalle_venta`, `cuentas_corrientes`, `pagos`, `auditorias`).

Funciona de dos maneras:
- Si ejecutaste `Base de datos.sql` en SSMS, la aplicación usa esa base y solo agrega la configuración inicial si está vacía.
- Si la base no existe, la aplicación la **crea automáticamente** con el mismo esquema al iniciar.

La configuración inicial incluye únicamente lo necesario para operar: los usuarios con sus grupos
y permisos (sin un usuario no se puede iniciar sesión) y los 4 rubros base (el alta de producto
exige un rubro). **No se cargan datos de ejemplo** — productos, clientes y proveedores empiezan vacíos.

## Usuarios de prueba

| Usuario    | Contraseña | Grupo           |
|------------|------------|-----------------|
| `admin`    | `admin`    | Administradores |
| `vendedor` | `vendedor` | Ventas          |

Las contraseñas se almacenan hasheadas con SHA-256 (`clave_hash`), nunca en texto plano (RNF15).
