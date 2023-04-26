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

        public IEnumerable<Deuda> GetDeudaPendiente(int idResidencia, int mes)
        {
            IRepositoryDeuda rep = new RepositoryDeuda();
            return rep.GetDeudaPendiente(idResidencia, mes);
        }

        public void GetIngresosCountDate(out string etiquetas1, out string valores1)
        {
            IRepositoryDeuda repository = new RepositoryDeuda();
            repository.GetIngresosCountDate(out string etiquetas, out string valores);
            etiquetas1 = etiquetas;
            valores1 = valores;
        }

        public Deuda Save(Deuda deuda)
        {
            IRepositoryDeuda rep = new RepositoryDeuda();
            return rep.Save(deuda);
        }
    }
}
