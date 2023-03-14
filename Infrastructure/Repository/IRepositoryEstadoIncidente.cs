using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryEstadoIncidente
    {
        IEnumerable<EstadoIncidente> GetEstadoIncidente();
        EstadoIncidente GetEstadoById(int id);
        void DeleteEstado(int id);
        EstadoIncidente Save(EstadoIncidente estado);
    }
}
