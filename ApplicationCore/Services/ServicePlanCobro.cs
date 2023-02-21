using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicePlanCobro : IServicePlanCobro
    {
        public void DeletePlanCobro(int id)
        {
            throw new NotImplementedException();
        }

        public PlanCobro GetPlanCobroByID(int id)
        {
            IRepositoryPlanCobro repository = new RepositoryPlanCobro();
            return repository.GetPlanCobroByID(id);
        }

        public IEnumerable<PlanCobro> GetPlanCobro()
        {
            IRepositoryPlanCobro repository = new RepositoryPlanCobro();
            return repository.GetPlanCobro();
        }

        public PlanCobro Save(PlanCobro planCobro, string[] selectedRubrosCobros)
        {
            IRepositoryPlanCobro repository = new RepositoryPlanCobro();
            return repository.Save(planCobro, selectedRubrosCobros);
        }
    }
}
