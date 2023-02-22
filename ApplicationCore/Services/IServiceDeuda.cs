using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceDeuda
    {
        IEnumerable<Deuda> GetDeuda();
        Deuda GetDeudaById(int id);
        void DeleteDeuda(int id);
        Deuda Save(Deuda deuda);
    }
}
