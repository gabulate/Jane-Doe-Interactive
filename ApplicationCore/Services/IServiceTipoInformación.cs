using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceTipoInformación
    {
        IEnumerable<TipoInformacion> GetTipoInformacion();
        TipoInformacion GetTipoById(int id);
        void DeleteTipo(int id);
        TipoInformacion Save(TipoInformacion tipo);
    }
}
