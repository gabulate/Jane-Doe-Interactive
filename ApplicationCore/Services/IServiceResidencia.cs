using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceResidencia
    {
        IEnumerable<Residencia> GetResidencia();
        IEnumerable<Residencia> GetResidenciaByUsuario(int id);
        Residencia GetResidenciaById(int id);
        void DeleteResidencia(int id);
        Residencia Save(Residencia residencia);
    }
}
