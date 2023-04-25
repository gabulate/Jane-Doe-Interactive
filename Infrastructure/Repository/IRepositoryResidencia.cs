using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryResidencia
    {
        IEnumerable<Residencia> GetResidencia();
        Residencia GetResidenciaById(int id);
        void DeleteResidencia(int id);
        Residencia Save(Residencia residencia);
        IEnumerable<Residencia> GetResidenciaByUsuario(int id);
    }
}
