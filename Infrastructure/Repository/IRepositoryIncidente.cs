using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryIncidente
    {
        IEnumerable<Incidente> GetIncidenteByUsuario(int idUsuario);
        IEnumerable<Incidente> GetIncidente();
        Incidente GetIncidenteById(int id);
        void DeleteIncidente(int id);
        Incidente Save(Incidente incidente, int idUsuario);
    }
}
