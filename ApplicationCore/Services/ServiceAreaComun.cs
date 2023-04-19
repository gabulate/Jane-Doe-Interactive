using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceAreaComun : IServiceAreaComun
    {
        public IEnumerable<AreaComun> GetAreaComun()
        {
            IRepositoryAreaComun repo = new RepositoryAreaComun();
            return repo.GetAreaComun();
        }

        public AreaComun GetAreaComunByID(int id)
        {
            IRepositoryAreaComun repo = new RepositoryAreaComun();
            return repo.GetAreaComunByID(id);
        }

        public AreaComun Save(AreaComun area)
        {
            IRepositoryAreaComun repo = new RepositoryAreaComun();
            return repo.Save(area);
        }
    }
}
