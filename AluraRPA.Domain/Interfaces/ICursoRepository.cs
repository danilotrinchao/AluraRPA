using AluraRPA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraRPA.Domain.Interfaces
{
    public interface ICursoRepository
    {
        void InserirAsync(Curso curso);
    }
}
