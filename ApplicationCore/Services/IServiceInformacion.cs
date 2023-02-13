using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceInformacion
    {
        IEnumerable<Informacion> GetInformacion();
        Informacion GetInformacionById(int id);
        void DeleteInformacion(int id);
        Informacion Save(Informacion informacion);
    }
}
