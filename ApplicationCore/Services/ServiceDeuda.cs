using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceDeuda : IServiceDeuda
    {
        public void DeleteDeuda(int id)
        {
            IRepositoryDeuda rep = new RepositoryDeuda();
            rep.DeleteDeuda(id);
        }

        public IEnumerable<Deuda> GetDeuda()
        {
            IRepositoryDeuda rep = new RepositoryDeuda();
            return rep.GetDeuda();
        }

        public Deuda GetDeudaById(int id)
        {
            IRepositoryDeuda rep = new RepositoryDeuda();
            return rep.GetDeudaById(id);
        }

        public IEnumerable<Deuda> GetDeudaByUsuario(int id)
        {
            IRepositoryDeuda rep = new RepositoryDeuda();
            return rep.GetDeudaByUsuario(id);
        }

        public IEnumerable<Deuda> GetDeudaPendiente()
        {
            IRepositoryDeuda rep = new RepositoryDeuda();
            return rep.GetDeudaPendiente();
        }

        public Deuda Save(Deuda deuda)
        {
            IRepositoryDeuda rep = new RepositoryDeuda();
            //IServicePlanCobro _ServicePlanCobro = new ServicePlanCobro();
            //PlanCobro plan = _ServicePlanCobro.GetPlanCobroByID(deuda.IdPlanCobro);
            //if(deuda.PendientePago==false)
            //{
            //    deuda.MontoPagado = plan.MontoTotal;
            //}
            
            return rep.Save(deuda);
        }
    }
}
