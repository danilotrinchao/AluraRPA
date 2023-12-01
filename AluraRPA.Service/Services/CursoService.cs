using AluraRPA.Domain.Entities;
using AluraRPA.Domain.Interfaces;
using FluentValidation;

namespace AluraRPA.Service.Services
{
    public class CursoService: ICursoService
    {
        private readonly IAluraScrappingService _aluraScrappingService;
        private readonly ICursoRepository _cursoRepository;
        private readonly IValidator<Curso> _cursoValidator;

        public CursoService(IAluraScrappingService aluraScrappingService, ICursoRepository cursoRepository, IValidator<Curso> cursoValidator)
        {
            _aluraScrappingService = aluraScrappingService;
            _cursoRepository = cursoRepository;
            _cursoValidator = cursoValidator;
        }

        public Curso BuscarCurso()
        {
            try
            {
                var curso = _aluraScrappingService.ObterDadosAlura("RPA");

                var validationResult = _cursoValidator.Validate(curso);

                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }
                else
                {
                    _cursoRepository.InserirAsync(curso);
                    return curso;
                }
     

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
