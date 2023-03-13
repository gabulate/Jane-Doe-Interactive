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

            //Suma de Todos los RubrosCobro del plan
            /*
            IRepositoryRubroCobro _RepositoryRubroCobro = new RepositoryRubroCobro();
            planCobro.RubroCobro = new List<RubroCobro>();
            foreach (var item in selectedRubrosCobros)
            {
                var rubroToAdd = _RepositoryRubroCobro.GetRubroCobroByID(int.Parse(item));
                planCobro.MontoTotal += rubroToAdd.Costo;
            }*/
            return repository.Save(planCobro, selectedRubrosCobros);
        }

        #region CalcularPlanSinUso
        /*public decimal CalcularPlan(string[] selectedRubrosCobros, PlanCobro plan)
        {
            decimal suma = 0;
            IRepositoryRubroCobro _RepositoryRubroCobro = new RepositoryRubroCobro();
            plan.RubroCobro = new List<RubroCobro>();
            foreach (var item in selectedRubrosCobros)
            {
                var rubroToAdd = _RepositoryRubroCobro.GetRubroCobroByID(int.Parse(item));
                suma += rubroToAdd.Costo;
            }
            return suma;
        }*/
        #endregion
    }
}
