CREATE TABLE areas (
    id_area INT PRIMARY KEY identity,
    nombre VARCHAR(50) NOT NULL
);

CREATE TABLE usuarios (
    id INT PRIMARY KEY identity,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    correo VARCHAR(50) NOT NULL unique,
    fecha_nacimiento DATE NOT NULL,
	genero CHAR(1),
    edad INT,
    telefono VARCHAR(20),
    direccion VARCHAR(200),
    id_area INT NOT NULL,
    fecha_creacion DATETIME2 NOT NULL DEFAULT GETDATE(),
    fecha_actualizacion DATETIME2 NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (id_area) REFERENCES areas(id_area)
);


INSERT INTO areas ( nombre) VALUES 
( 'Nómina'),
( 'Facturación'),
( 'Servicio al Cliente'),
( 'IT');


INSERT INTO usuarios (nombre, apellido, correo, fecha_nacimiento, genero, edad, telefono, direccion, id_area)
VALUES 
('Juan', 'Pérez', 'juan.perez@mail.com', '1990-03-15', 'M', 31, '555-1234', 'Calle 123', 1),
('María', 'González', 'maria.gonzalez@mail.com', '1985-05-20', 'F', 36, '555-5678', 'Av. 456', 2),
('Pedro', 'López', 'pedro.lopez@mail.com', '1995-02-10', 'M', 26, '555-4321', 'Calle 789', 1),
('Ana', 'Martínez', 'ana.martinez@mail.com', '1982-11-22', 'F', 39, '555-8765', 'Av. 012', 3),
('Luis', 'Ramírez', 'luis.ramirez@mail.com', '1998-07-03', 'M', 23, '555-2109', 'Calle 345', 2),
('Laura', 'Fernández', 'laura.fernandez@mail.com', '1989-09-08', 'F', 32, '555-6543', 'Av. 678', 4),
('Carlos', 'Hernández', 'carlos.hernandez@mail.com', '1993-01-12', 'M', 28, '555-9876', 'Calle 901', 1),
('Jorge', 'García', 'jorge.garcia@mail.com', '1980-04-05', 'M', 41, '555-3210', 'Av. 234', 3),
('Mónica', 'Sánchez', 'monica.sanchez@mail.com', '1987-06-30', 'F', 34, '555-7654', 'Calle 567', 4),
('Sara', 'Pérez', 'sara.perez@mail.com', '1992-12-25', 'F', 29, '555-0987', 'Av. 890', 2);

