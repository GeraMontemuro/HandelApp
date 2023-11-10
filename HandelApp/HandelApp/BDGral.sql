use master
go
create database HandelApp
go
use HandelApp
go
Create table Cliente(
    IDCliente bigint not null PRIMARY key IDENTITY (1,1),
    NombreFantasia varchar (50) not null,
    Cuil varchar (20) not null,
    Telefono varchar (20) not null,
    Mail varchar (50) not null
)
go
Create table Proveedor(
    IDProveedor bigint not null PRIMARY key IDENTITY (1,1),
    NombreFantasia varchar (50) not null, 
    Cuil varchar (20) not null,
    Telefono varchar (20) not null,
    Mail varchar (50) not null
)
go
Create table Marcas(
    IDMarca int Primary key IDENTITY(1, 1),
    Descripcion varchar(50)
)
go 
Create Table Categorias(
    IDCategoria int Primary Key IDENTITY(1, 1),
    Descripcion varchar(50)
)
go
Create table Producto(
    Codigo bigint not null PRIMARY key IDENTITY (1,1),
    Marcas int not null FOREIGN key references Marcas (IDMarca),
    Categorias int not null FOREIGN key references Categorias (IDCategoria),
    StockTotal bigint not null,
    StockMinimo tinyint not null,
    PrecioVenta decimal (12,2) check (Precioventa > 0), 
    PrecioCompra decimal (12,2) check (PrecioCompra > 0)
)
