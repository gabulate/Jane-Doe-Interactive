using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryRubroCobro
    {
        IEnumerable<RubroCobro> GetRubroCobro();
        RubroCobro GetRubroCobroByID(int id);
        RubroCobro Save(RubroCobro rubro);
    }
}
