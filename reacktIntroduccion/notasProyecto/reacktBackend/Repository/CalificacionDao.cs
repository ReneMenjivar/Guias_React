using reactBackend.Context;
using Microsoft.Identity.Client;
using reactBackend.Context;
using reactBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactBackend.Repository
{
    public class CalificacionDao
    {
        private RegistroAlumnosContext _contexto = new RegistroAlumnosContext();

        public List<Calificacion> seleccion(int matriculaId)
        {
            var matricula = _contexto.Matriculas.Where(x => x.Id == matriculaId);
            Console.WriteLine("Matricula encontrada");

            try
            {
                if (matricula != null)
                {
                    var calificacion = _contexto.Calificacions.Where(x => x.Id == matriculaId).ToList();
                    return calificacion;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool insertar(Calificacion calificacion)
        {
            try
            {
                if (calificacion == null)
                {
                    return false;
                }

                var addCalificacion = _contexto.Calificacions.Add(calificacion);
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool eliminarCalificacion(int id)
        {
            var calificacion = _contexto.Calificacions.Where(x => x.Id == id).FirstOrDefault();

            try
            {
                if (calificacion == null)
                {
                    return false;
                }

                var addCalificacion = _contexto.Calificacions.Remove(calificacion);
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}