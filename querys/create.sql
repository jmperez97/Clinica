create database clinica
go
use clinica

go

create table Paciente
(Id int not null identity primary key,
Nombre varchar(60),
cedula varchar(13),
telefono varchar(16),
estado bit
)
go
create table Tipo
(IdTipo int not null identity primary key,
Descrip varchar(100)

)
go
create table Cita
(ID int NOT NULL IDENTITY PRIMARY KEY,
IdPaciente int not null,
IdTipo int not null,
fecha datetime,
estado bit
)
go
insert into Tipo values('Medicina General')
insert into Tipo values('Odontología')
insert into Tipo values('Pediatría')
insert into Tipo values('Neurología')

