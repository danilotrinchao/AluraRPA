CREATE TABLE Cursos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    titulo NVARCHAR(255) NOT NULL,
    professores NVARCHAR(MAX) NOT NULL,
    cargaHoraria NVARCHAR(50) NOT NULL,
    descricao NVARCHAR(MAX) NOT NULL
);

