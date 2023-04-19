using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceAreaComun
    {
        IEnumerable<AreaComun> GetAreaComun();
        AreaComun GetAreaComunByID(int id);
        AreaComun Save(AreaComun area);
    }
}
