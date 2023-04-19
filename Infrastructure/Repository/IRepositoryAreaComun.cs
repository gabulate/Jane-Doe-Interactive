using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryAreaComun
    {
        IEnumerable<AreaComun> GetAreaComun();
        AreaComun GetAreaComunByID(int id);
        AreaComun Save(AreaComun area);
    }
}
