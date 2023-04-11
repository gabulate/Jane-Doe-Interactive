using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceIncidente
    {
        IEnumerable<Incidente> GetIncidente();
        IEnumerable<Incidente> GetIncidenteByUsuario(int idUsuario);
        Incidente GetIncidenteById(int id);
        void DeleteIncidente(int id);
        Incidente Save(Incidente incidente, int idUsuario);
    }
}
