USE [CapacitacionEmergenciasDB]
GO

INSERT INTO Usuarios
(
    NombreUsuario,
    PasswordHash,
    Rol
)
VALUES
(
    'admin',
    'admin123',
    'Administrador'
);


INSERT INTO Usuarios
(
    NombreUsuario,
    PasswordHash,
    Rol
)
VALUES
(
    'jperez',
    'jperez123',
    'Instructor'
);

INSERT INTO Cursoes (sNombreCurso, bCursoActivo)
VALUES
('Soporte Vital Básico', 1),
('Trauma Avanzado', 1),
('Rescate Vehicular', 1)

INSERT INTO Destrezas (NombreDestreza, CursoId)
VALUES ('RCP Adulto', 1);

INSERT INTO Destrezas (NombreDestreza, CursoId)
VALUES ('Manejo DEA', 1);

INSERT INTO Destrezas (NombreDestreza, CursoId)
VALUES ('Intubación Endotraqueal', 2);

INSERT INTO Destrezas (NombreDestreza, CursoId)
VALUES ('Control de Hemorragia', 2);

INSERT INTO Destrezas (NombreDestreza, CursoId)
VALUES ('Extricación de Víctima', 3);

INSERT INTO Destrezas (NombreDestreza, CursoId)
VALUES ('Estabilización Vehicular', 3);