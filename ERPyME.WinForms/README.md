# ERPyME – Windows Forms (.NET 9) + Entity Framework Core

Versión de escritorio en **C# / Windows Forms** del ERP para PyMEs comerciales del TP de Ingeniería de Software.
Pensada para abrirse con **Visual Studio 2026** mediante la solución `ERPyME.sln` de la carpeta padre
(contiene únicamente este proyecto).

## Cómo ejecutar

**Opción A – Visual Studio:** abrir `ERPyME.sln`, establecer `ERPyME.WinForms` como proyecto de inicio y presionar F5.

**Opción B – consola:**
```
cd ERPyME.WinForms
dotnet run
```

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

## Funcionalidad implementada

| Módulo | Requerimientos | Estado |
|---|---|---|
| Inicio / cierre de sesión | RF01, RF03, RNF01, RNF15 | ✅ Funcional |
| Dashboard con indicadores y gráfico | RF27 | ✅ Funcional |
| Gestión de Productos (ABM + búsqueda + baja lógica) | RF14, RF15, RF17, RN05 | ✅ Funcional |
| Gestión de Clientes (ABM + saldo cta. cte.) | RF10, RF11 | ✅ Funcional |
| **Registrar Venta (core RC01)** | RF20, RF21, RF22, RN01, RN03, RN06, RN08 | ✅ Funcional |
| Auditoría / historial | RF28, RNF07 | ✅ Funcional |
| Proveedores, Compras, Cuentas Corrientes, Reportes, Usuarios y Grupos | RF06–RF09, RF12/13, RF18/19, RF23–RF26 | 🚧 En desarrollo (visibles en el menú) |

### Flujo de la venta (RC01)

1. Se selecciona cliente y forma de pago, y se agregan productos con cantidades.
2. El sistema valida stock **al agregar y otra vez al confirmar** contra la base (RN01).
3. Al confirmar, dentro de una transacción: se genera el número de venta, se graba `ventas` + `detalle_venta`,
   se descuenta `stock_actual` (RN03), se actualiza `cuentas_corrientes` si es a crédito (RN06)
   y se registra en `auditorias` con referencia a la venta (RN08).

## Arquitectura: Modelo – Vista – Controladora (MVC)

El proyecto está organizado en tres capas con responsabilidades separadas (RNF10 - Mantenibilidad):

- **Modelo (`Modelos/`)**: las entidades del dominio, el acceso a datos con Entity Framework Core
  y los servicios de soporte (hash de claves, sesión, auditoría). Es la única capa que conoce la base de datos.
- **Vista (`Vistas/`)**: los formularios y pantallas. No contienen lógica de negocio ni acceso a datos:
  solo dibujan, capturan lo que ingresa el usuario y llaman a la controladora correspondiente.
- **Controladora (`Controladoras/`)**: recibe las acciones de la vista, aplica las reglas de negocio
  (validación de stock, baja lógica, cuentas corrientes, auditoría) y opera sobre el modelo.

```
ERPyME.WinForms/
├── Program.cs                          # Arranque: inicializa la BD y cicla login ↔ sistema
├── Modelos/                            # ── MODELO ──
│   ├── Entidades.cs                    # Entidades mapeadas al esquema SQL
│   ├── AppDbContext.cs                 # DbContext EF Core (mapeo tabla por tabla) + seed
│   └── Servicios.cs                    # Hash de claves (RNF15), sesión y auditoría
├── Controladoras/                      # ── CONTROLADORA ──
│   ├── ControladoraLogin.cs            # RF01/RF03 - autenticación y cierre de sesión
│   ├── ControladoraProductos.cs        # RF14-RF17 - ABM de productos, RN05
│   ├── ControladoraClientes.cs         # RF10/RF11 - ABM de clientes
│   ├── ControladoraVentas.cs           # RC01 - registro de venta (RN01, RN03, RN06, RN08)
│   ├── ControladoraDashboard.cs        # RF27 - indicadores
│   └── ControladoraAuditoria.cs        # RF28 - historial
├── Vistas/                             # ── VISTA ── (formularios con archivo .Designer.cs,
│   │                                   #   editables con el diseñador visual de Visual Studio)
│   ├── LoginForm.cs / .Designer.cs     # Pantalla de inicio de sesión
│   ├── MainForm.cs / .Designer.cs      # Shell principal con menú lateral
│   ├── DashboardView.cs / .Designer.cs # Indicadores + gráfico GDI+
│   ├── ProductosView.cs / .Designer.cs # Listado de productos
│   ├── ProductoForm.cs / .Designer.cs  # Alta / modificación de producto
│   ├── ClientesView.cs / .Designer.cs  # Listado de clientes
│   ├── ClienteForm.cs / .Designer.cs   # Alta / modificación de cliente
│   ├── VentaView.cs / .Designer.cs     # Registro de venta
│   ├── AuditoriaView.cs / .Designer.cs # Historial
│   └── PlaceholderView.cs / .Designer.cs # Módulos previstos aún no desarrollados
└── Ui/Estilos.cs                       # Paleta y estilizadores compartidos (RNF12)

Cada vista sigue el patrón estándar de Windows Forms: el archivo `.Designer.cs` contiene
`InitializeComponent()` con la declaración y disposición de los controles (lo que edita el
diseñador visual de Visual Studio), y el `.cs` contiene los manejadores de eventos que
delegan en las controladoras. Los estilos que el diseñador no serializa (hover de botones,
bordes de tarjetas, formato de grillas) se aplican en el constructor mediante `Ui/Estilos.cs`.
```

Ejemplo del flujo MVC en el caso core (RC01): `VentaView` arma la lista de ítems y llama a
`ControladoraVentas.Registrar(clienteId, formaPago, items)`; la controladora revalida el stock (RN01),
graba `ventas` + `detalle_venta`, descuenta `stock_actual` (RN03), actualiza `cuentas_corrientes` (RN06)
y audita (RN08) dentro de una transacción; la vista solo muestra el `ResultadoVenta` que recibe.
