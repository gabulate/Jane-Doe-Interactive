using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceReservacion : IServiceReservacion
    {
        public void DeleteReservacion(int id)
        {
            IRepositoryReservacion repo = new RepositoryReservacion();
            repo.DeleteReservacion(id);
        }

        public IEnumerable<Reservacion> GetReservacion()
        {
            IRepositoryReservacion repo = new RepositoryReservacion();
            IEnumerable<Reservacion> lista = repo.GetReservacion();

            //Ordena la lista poniendo las últimas fechas primero
            lista = lista.OrderByDescending(x => x.HoraInicio).ToList();

            return lista;
        }

        public Reservacion GetReservacionById(int id)
        {
            IRepositoryReservacion repo = new RepositoryReservacion();
            return repo.GetReservacionById(id);
        }

        public IEnumerable<Reservacion> GetReservacionByUsuario(int idUsuario)
        {
            IRepositoryReservacion repo = new RepositoryReservacion();
            IEnumerable<Reservacion> lista = repo.GetReservacionByUsuario(idUsuario);

            //Ordena la lista poniendo las últimas fechas primero
            lista = lista.OrderByDescending(x => x.HoraInicio).ToList();

            return lista;
        }

        public Reservacion Save(Reservacion reservacion, int idUsuario)
        {
            IRepositoryReservacion repo = new RepositoryReservacion();

            IEnumerable<Reservacion> listaOtras = repo.GetReservacionByFecha(reservacion);

            foreach(var otra in listaOtras)
            {
                //Verifica si las horas chocan
                if(reservacion.HoraInicio < otra.HoraFinal
                    && otra.HoraInicio < reservacion.HoraFinal)
                {
                    throw new Exception("Las horas indicadas chocan con otra reservación.");
                }
            }

            //Obtiene las horas de apertura y cierre del área común
            TimeSpan horaApertura = reservacion.AreaComun.HoraAbierto;
            TimeSpan horaCierre = reservacion.AreaComun.HoraCierre;

            //Obtiene las horas reservadas para hacer comparaciones
            TimeSpan horaInicio = reservacion.HoraInicio.TimeOfDay;
            TimeSpan horaFinal = reservacion.HoraFinal.TimeOfDay;

            if(horaFinal < horaInicio)
            {
                throw new Exception("La hora de inicio debe ser antes de la hora final.");
            }

            //Verifica que el área esté abierta durante las horas seleccionadas
            if (horaInicio < horaApertura)
            {
                throw new Exception("El área seleccionada se abre hasta las: " + horaApertura + ".");
            }
            if (horaFinal > horaCierre)
            {
                throw new Exception("El área seleccionada cierra a las: " + horaCierre + ".");
            }

            //Guarda la reservación después de verificar que
            //no choque con ninguna otra reservación,
            //la hora de inicio sea antes que la hora final,
            //el área esté abierta durante horas seleccionadas
            return repo.Save(reservacion, idUsuario);
        }
    }
}
