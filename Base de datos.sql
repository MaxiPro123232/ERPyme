-- =========================================
-- CREAR BASE DE DATOS
-- =========================================
USE master;
GO

IF DB_ID('ERPyME') IS NOT NULL
    DROP DATABASE ERPyME;
GO

CREATE DATABASE ERPyME;
GO

USE ERPyME;
GO

-- =========================================
-- TABLAS DE SEGURIDAD
-- =========================================

CREATE TABLE grupos (
    id_grupo INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(100) NOT NULL,
    descripcion VARCHAR(255),
    estado BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE permisos (
    id_permiso INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(50) NOT NULL UNIQUE,
    descripcion VARCHAR(255) NOT NULL
);
GO

CREATE TABLE usuarios (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    usuario VARCHAR(50) NOT NULL UNIQUE,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    email VARCHAR(150) NOT NULL UNIQUE,
    clave_hash VARCHAR(255) NOT NULL,
    estado BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE usuario_grupo (
    id_usuario INT NOT NULL,
    id_grupo INT NOT NULL,
    PRIMARY KEY (id_usuario, id_grupo),
    CONSTRAINT fk_usuario_grupo_usuario
        FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario),
    CONSTRAINT fk_usuario_grupo_grupo
        FOREIGN KEY (id_grupo) REFERENCES grupos(id_grupo)
);
GO

CREATE TABLE grupo_permiso (
    id_grupo INT NOT NULL,
    id_permiso INT NOT NULL,
    PRIMARY KEY (id_grupo, id_permiso),
    CONSTRAINT fk_grupo_permiso_grupo
        FOREIGN KEY (id_grupo) REFERENCES grupos(id_grupo),
    CONSTRAINT fk_grupo_permiso_permiso
        FOREIGN KEY (id_permiso) REFERENCES permisos(id_permiso)
);
GO

-- =========================================
-- TABLAS MAESTRAS
-- =========================================

CREATE TABLE clientes (
    id_cliente INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(150) NOT NULL,
    cuit VARCHAR(20),
    telefono VARCHAR(30),
    email VARCHAR(150),
    direccion VARCHAR(200),
    estado BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE proveedores (
    id_proveedor INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(150) NOT NULL,
    cuit VARCHAR(20),
    telefono VARCHAR(30),
    email VARCHAR(150),
    direccion VARCHAR(200),
    estado BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE rubros (
    id_rubro INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(100) NOT NULL,
    descripcion VARCHAR(255),
    estado BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE productos (
    id_producto INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(150) NOT NULL,
    descripcion VARCHAR(255),
    precio DECIMAL(12,2) NOT NULL CHECK (precio >= 0),
    stock_actual INT NOT NULL DEFAULT 0 CHECK (stock_actual >= 0),
    stock_minimo INT NOT NULL DEFAULT 0 CHECK (stock_minimo >= 0),
    estado BIT NOT NULL DEFAULT 1,
    id_rubro INT NOT NULL,
    CONSTRAINT fk_producto_rubro
        FOREIGN KEY (id_rubro) REFERENCES rubros(id_rubro)
);
GO

-- =========================================
-- COMPRAS
-- =========================================

CREATE TABLE compras (
    id_compra INT IDENTITY(1,1) PRIMARY KEY,
    numero VARCHAR(30) NOT NULL UNIQUE,
    fecha DATE NOT NULL,
    total DECIMAL(12,2) NOT NULL CHECK (total >= 0),
    id_proveedor INT NOT NULL,
    id_usuario INT NOT NULL,
    CONSTRAINT fk_compra_proveedor
        FOREIGN KEY (id_proveedor) REFERENCES proveedores(id_proveedor),
    CONSTRAINT fk_compra_usuario
        FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario)
);
GO

CREATE TABLE detalle_compra (
    id_detalle_compra INT IDENTITY(1,1) PRIMARY KEY,
    cantidad INT NOT NULL CHECK (cantidad > 0),
    precio_unitario DECIMAL(12,2) NOT NULL CHECK (precio_unitario >= 0),
    subtotal DECIMAL(12,2) NOT NULL CHECK (subtotal >= 0),
    id_compra INT NOT NULL,
    id_producto INT NOT NULL,
    CONSTRAINT fk_detalle_compra_compra
        FOREIGN KEY (id_compra) REFERENCES compras(id_compra),
    CONSTRAINT fk_detalle_compra_producto
        FOREIGN KEY (id_producto) REFERENCES productos(id_producto)
);
GO

-- =========================================
-- VENTAS
-- =========================================

CREATE TABLE ventas (
    id_venta INT IDENTITY(1,1) PRIMARY KEY,
    numero VARCHAR(30) NOT NULL UNIQUE,
    fecha DATE NOT NULL,
    total DECIMAL(12,2) NOT NULL CHECK (total >= 0),
    estado VARCHAR(30) NOT NULL,
    forma_pago VARCHAR(50) NOT NULL,
    importe_pagado DECIMAL(12,2) NOT NULL DEFAULT 0 CHECK (importe_pagado >= 0),
    id_cliente INT NOT NULL,
    id_usuario INT NOT NULL,
    CONSTRAINT fk_venta_cliente
        FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente),
    CONSTRAINT fk_venta_usuario
        FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario)
);
GO

CREATE TABLE detalle_venta (
    id_detalle_venta INT IDENTITY(1,1) PRIMARY KEY,
    cantidad INT NOT NULL CHECK (cantidad > 0),
    precio_unitario DECIMAL(12,2) NOT NULL CHECK (precio_unitario >= 0),
    subtotal DECIMAL(12,2) NOT NULL CHECK (subtotal >= 0),
    id_venta INT NOT NULL,
    id_producto INT NOT NULL,
    CONSTRAINT fk_detalle_venta_venta
        FOREIGN KEY (id_venta) REFERENCES ventas(id_venta),
    CONSTRAINT fk_detalle_venta_producto
        FOREIGN KEY (id_producto) REFERENCES productos(id_producto)
);
GO

-- =========================================
-- CUENTAS CORRIENTES
-- =========================================

CREATE TABLE cuentas_corrientes (
    id_cuenta_corriente INT IDENTITY(1,1) PRIMARY KEY,
    saldo_anterior DECIMAL(12,2) NOT NULL DEFAULT 0,
    debitos DECIMAL(12,2) NOT NULL DEFAULT 0,
    creditos DECIMAL(12,2) NOT NULL DEFAULT 0,
    saldo_actual DECIMAL(12,2) NOT NULL DEFAULT 0,
    estado VARCHAR(30) NOT NULL,
    id_cliente INT NOT NULL UNIQUE,
    CONSTRAINT fk_cuenta_corriente_cliente
        FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente)
);
GO

CREATE TABLE pagos (
    id_pago INT IDENTITY(1,1) PRIMARY KEY,
    fecha DATE NOT NULL,
    importe DECIMAL(12,2) NOT NULL CHECK (importe > 0),
    forma_pago VARCHAR(50) NOT NULL,
    observaciones VARCHAR(255),
    id_cuenta_corriente INT NOT NULL,
    CONSTRAINT fk_pago_cuenta_corriente
        FOREIGN KEY (id_cuenta_corriente) REFERENCES cuentas_corrientes(id_cuenta_corriente)
);
GO

-- =========================================
-- AUDITORÍA
-- =========================================

CREATE TABLE auditorias (
    id_auditoria INT IDENTITY(1,1) PRIMARY KEY,
    fecha_hora DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    accion VARCHAR(100) NOT NULL,
    detalle VARCHAR(255) NOT NULL,
    id_usuario INT NOT NULL,
    id_venta INT NULL,
    id_compra INT NULL,
    CONSTRAINT fk_auditoria_usuario
        FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario),
    CONSTRAINT fk_auditoria_venta
        FOREIGN KEY (id_venta) REFERENCES ventas(id_venta),
    CONSTRAINT fk_auditoria_compra
        FOREIGN KEY (id_compra) REFERENCES compras(id_compra)
);
GO

USE master;
GO
ALTER AUTHORIZATION ON DATABASE::ERPyME TO sa;
GO