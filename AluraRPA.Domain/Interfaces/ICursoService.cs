using AluraRPA.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraRPA.Domain.Interfaces
{
    public interface ICursoService
    {
        Curso BuscarCurso();
    }
}
