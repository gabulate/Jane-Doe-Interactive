using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryInformacion
    {
        IEnumerable<Informacion> GetInformacion();
        Informacion GetInformacionById(int id);
        void DeleteInformacion(int id);
        Informacion Save(Informacion informacion);
    }
}
