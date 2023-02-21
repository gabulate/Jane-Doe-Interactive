using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryPlanCobro
    {
        IEnumerable<PlanCobro> GetPlanCobro();
        PlanCobro GetPlanCobroByID(int id);
        void DeletePlanCobro(int id);
        PlanCobro Save(PlanCobro planCobro, string[] selectedRubrosCobro);
    }
}
