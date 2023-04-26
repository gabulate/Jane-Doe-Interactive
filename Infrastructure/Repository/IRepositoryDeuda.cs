using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryDeuda
    {
        IEnumerable<Deuda> GetDeuda();
        Deuda GetDeudaById(int id);
        IEnumerable<Deuda> GetDeudaByUsuario(int id);
        void DeleteDeuda(int id);
        Deuda Save(Deuda deuda);
        IEnumerable<Deuda> GetDeudaPendiente();
        void GetIngresosCountDate(out string etiquetas, out string valores);
    }
}
