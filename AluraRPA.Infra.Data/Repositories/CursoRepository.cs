using AluraRPA.Domain.Entities;
using AluraRPA.Domain.Interfaces;
using Dapper;
using System.Data;

namespace AluraRPA.Infra.Data.Repositories
{
    public class CursoRepository: ICursoRepository
    {
        private readonly IDbConnection _dbConnection;

        public CursoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void InserirAsync(Curso curso)
        {
            try
            {
                _dbConnection.Execute("INSERT INTO [AluraRPA].[dbo].[Cursos] (titulo, professores, cargaHoraria, descricao) VALUES (@Titulo, @Professores, @CargaHoraria, @Descricao)",
               new {curso.titulo, curso.professores, curso.cargaHoraria, curso.descricao });
           
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
               
        }

    }
}
