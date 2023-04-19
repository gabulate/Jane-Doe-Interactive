using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceReservacion
    {
        IEnumerable<Reservacion> GetReservacionByUsuario(int idUsuario);
        IEnumerable<Reservacion> GetReservacion();
        Reservacion GetReservacionById(int id);
        void DeleteReservacion(int id);
        Reservacion Save(Reservacion reservacion, int idUsuario);
    }
}
