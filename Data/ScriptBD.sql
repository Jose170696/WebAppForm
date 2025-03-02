--Creacion de Tablas
create table cliente(
clienteId int identity primary key,
nombre varchar(150) not null,
email varchar(150) unique not null,
telefono varchar(150) not null,
direccion varchar(200) not null,
AdicionadoPor NVARCHAR (50) not null,
FechaAdicion DATETIME default getdate() not null,
ModificadoPor NVARCHAR (50),
FechaModificacion DATETIME default getdate()
);
 
create table producto(
productoId int identity primary key,
nombre varchar(150) not null,
descripcion varchar(150) not null,
precio decimal (10, 2) not null,
AdicionadoPor NVARCHAR (50) not null,
FechaAdicion DATETIME default getdate() not null,
ModificadoPor NVARCHAR (50),
FechaModificacion DATETIME default getdate()
);
 
 
create table pedido(
pedidoId int identity primary key,
fecha datetime default getdate() not null,
total decimal (10, 2) not null,
estado varchar(50) not null,
clienteId int not null,
productoId int not null,
AdicionadoPor NVARCHAR (50) not null,
FechaAdicion DATETIME default getdate() not null,
ModificadoPor NVARCHAR (50),
FechaModificacion DATETIME default getdate()
CONSTRAINT FK_Cliente FOREIGN KEY (clienteId) REFERENCES cliente(clienteId),
CONSTRAINT FK_Producto FOREIGN KEY (productoId) REFERENCES producto(productoId)
);

---------------------Procedimientos Almacenados----------------------------

-- Insertar Cliente
CREATE PROCEDURE spInsertarCliente
    @Nombre VARCHAR(150),
    @Email VARCHAR(150),
    @Telefono VARCHAR(150),
    @Direccion VARCHAR(200),
    @AdicionadoPor NVARCHAR(50)
AS
BEGIN
    INSERT INTO Cliente (Nombre, Email, Telefono, Direccion, AdicionadoPor, FechaAdicion)
    VALUES (@Nombre, @Email, @Telefono, @Direccion, @AdicionadoPor, GETDATE());
END;
GO
 
-- Actualizar Cliente
CREATE PROCEDURE spActualizarCliente
    @ClienteId INT,
    @Nombre VARCHAR(150),
    @Email VARCHAR(150),
    @Telefono VARCHAR(150),
    @Direccion VARCHAR(200),
    @ModificadoPor NVARCHAR(50)
AS
BEGIN
    UPDATE Cliente
    SET Nombre = @Nombre,
        Email = @Email,
        Telefono = @Telefono,
        Direccion = @Direccion,
        ModificadoPor = @ModificadoPor,
        FechaModificacion = GETDATE()
    WHERE ClienteId = @ClienteId;
END;
GO
 
-- Eliminar Cliente
CREATE PROCEDURE spEliminarCliente
    @ClienteId INT
AS
BEGIN
    DELETE FROM Cliente WHERE ClienteId = @ClienteId;
END;
GO
 
-- Consultar Clientes
CREATE PROCEDURE spConsultarClientes
AS
BEGIN
    SELECT * FROM Cliente;
END;
GO

-- Insertar Producto
CREATE PROCEDURE spInsertarProducto
    @Nombre VARCHAR(150),
    @Descripcion VARCHAR(150),
    @Precio DECIMAL(10,2),
    @AdicionadoPor NVARCHAR(50)
AS
BEGIN
    INSERT INTO Producto (Nombre, Descripcion, Precio, AdicionadoPor, FechaAdicion)
    VALUES (@Nombre, @Descripcion, @Precio, @AdicionadoPor, GETDATE());
END;
GO
 
-- Actualizar Producto
CREATE PROCEDURE spActualizarProducto
    @ProductoId INT,
    @Nombre VARCHAR(150),
    @Descripcion VARCHAR(150),
    @Precio DECIMAL(10,2),
    @ModificadoPor NVARCHAR(50)
AS
BEGIN
    UPDATE Producto
    SET Nombre = @Nombre,
        Descripcion = @Descripcion,
        Precio = @Precio,
        ModificadoPor = @ModificadoPor,
        FechaModificacion = GETDATE()
    WHERE ProductoId = @ProductoId;
END;
GO
 
-- Eliminar Producto
CREATE PROCEDURE spEliminarProducto
    @ProductoId INT
AS
BEGIN
    DELETE FROM Producto WHERE ProductoId = @ProductoId;
END;
GO
 
-- Consultar Productos
CREATE PROCEDURE spConsultarProductos
AS
BEGIN
    SELECT * FROM Producto;
END;
GO
 

-- Insertar Pedido
CREATE PROCEDURE spInsertarPedido
    @ClienteId INT,
    @ProductoId INT,
    @Total DECIMAL(10,2),
    @Estado VARCHAR(50),
    @AdicionadoPor NVARCHAR(50)
AS
BEGIN
    INSERT INTO Pedido (Fecha, Total, Estado, ClienteId, ProductoId, AdicionadoPor, FechaAdicion)
    VALUES (GETDATE(), @Total, @Estado, @ClienteId, @ProductoId, @AdicionadoPor, GETDATE());
END;
GO
 
-- Actualizar Pedido
CREATE PROCEDURE spActualizarPedido
    @PedidoId INT,
    @Total DECIMAL(10,2),
    @Estado VARCHAR(50),
    @ModificadoPor NVARCHAR(50)
AS
BEGIN
    UPDATE Pedido
    SET Total = @Total,
        Estado = @Estado,
        ModificadoPor = @ModificadoPor,
        FechaModificacion = GETDATE()
    WHERE PedidoId = @PedidoId;
END;
GO
 
-- Eliminar Pedido
CREATE PROCEDURE spEliminarPedido
    @PedidoId INT
AS
BEGIN
    DELETE FROM Pedido WHERE PedidoId = @PedidoId;
END;
GO
 
-- Consultar Pedidos
CREATE PROCEDURE spConsultarPedidos
AS
BEGIN
    SELECT P.PedidoId, P.Fecha, P.Total, P.Estado, C.Nombre AS Cliente, PR.Nombre AS Producto
    FROM Pedido P
    INNER JOIN Cliente C ON P.ClienteId = C.ClienteId
    INNER JOIN Producto PR ON P.ProductoId = PR.ProductoId;
END;
GO

---Procedimientos Almacenados para Obtener Listas de cada modelo---
CREATE PROCEDURE spObtenerClientes
AS
BEGIN
    SELECT clienteId, nombre, email, telefono, direccion, AdicionadoPor
    FROM cliente;
END;
GO

CREATE PROCEDURE spObtenerProductos
AS
BEGIN
    SELECT productoId, nombre, descripcion, precio, AdicionadoPor
    FROM producto;
END;
GO

CREATE PROCEDURE spObtenerPedidos
AS
BEGIN
    SELECT pedidoId, fecha, total, estado, clienteId, productoId, AdicionadoPor
    FROM pedido;
END;