using reactBackend.Context;
using reactBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactBackend.Repository
{
    public class ProfesorDao
    {
        public RegistroAlumnosContext context = new RegistroAlumnosContext();

        // Creamos un metodo que recibe 2 parametros, usuario y pass
        // Creamos una expresión lambda que recibe
        // usuario -> usuario ingresado en el body
        // pass -> contraseña descrita en el body

        public Profesor login(string usuario, string pass)
        {
            var prof = context.Profesors.Where(
                p => p.Usuario == usuario
                && p.Pass == pass).FirstOrDefault();

            return prof;
        }
    }
}