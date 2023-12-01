using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraRPA.Domain.Entities
{
    public class Curso:BaseEntity
    {
        public string titulo { get; set; }
        public string professores { get; set; }
        public string cargaHoraria { get; set; }
        public string descricao { get; set;}
    }
}
