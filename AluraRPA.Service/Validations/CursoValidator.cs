using AluraRPA.Domain.Entities;
using FluentValidation;
using System.Linq;


namespace AluraRPA.Service.Validations
{

    public class CursoValidator : AbstractValidator<Curso>
    {
        public CursoValidator()
        {
            RuleFor(curso => curso.titulo).NotEmpty().WithMessage("O título do curso é obrigatório.");
            RuleFor(curso => curso.professores).Must(professores => professores != null && professores.Any()).WithMessage("Pelo menos um professor deve ser fornecido.");
            RuleFor(curso => curso.cargaHoraria).NotEmpty().WithMessage("A carga horária do curso é obrigatória.");
            RuleFor(curso => curso.descricao).NotEmpty().WithMessage("A descrição do curso é obrigatória.");
        }
    }


}
