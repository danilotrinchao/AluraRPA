using AluraRPA.Domain.Entities;
using AluraRPA.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AluraRPA.Application.Api.Controllers
{

    [Route("api/cursos")]

    public class AutomatizacaoController
    {
        private readonly ICursoService _cursoService;

        public AutomatizacaoController(ICursoService cursoService)
        {
            _cursoService= cursoService;
        }

        [HttpPost]
        public Curso ObterCurso()
         {
            var curso = _cursoService.BuscarCurso();
            return curso;
        }

    }
}
