using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryCondicionResidencia
    {
        IEnumerable<CondicionResidencia> GetCondicionResidencia();
        CondicionResidencia GetCondicionResidenciaById(int id);
        CondicionResidencia Save(CondicionResidencia tipo);
    }
}
