using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryReservacion
    {
        IEnumerable<Reservacion> GetReservacionByUsuario(int idUsuario);
        IEnumerable<Reservacion> GetReservacionByFecha(Reservacion reservacion);
        IEnumerable<Reservacion> GetReservacion();
        Reservacion GetReservacionById(int id);
        void DeleteReservacion(int id);
        Reservacion Save(Reservacion reservacion, int idUsuario);
    }
}
