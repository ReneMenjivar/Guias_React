using reacktBackend.Context;
using reacktBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reacktBackend.Repository
{
    public class AlumnoDAO
    {
        #region Context
        public RegistroAlumnoContext contexto = new RegistroAlumnoContext();

        #endregion

        #region Select All
        public List<Alumno> SelectAll()
        {
            var alumno = contexto.Alumnos.ToList<Alumno>();
            return alumno;
        }

        #endregion

        #region Seleccionar por ID
        public Alumno? GetById(int id)
        {
            var alumno = contexto.Alumnos.Where(x => x.Id == id).FirstOrDefault();
            return alumno == null ? null : alumno;
        }
        #endregion
    }
}
