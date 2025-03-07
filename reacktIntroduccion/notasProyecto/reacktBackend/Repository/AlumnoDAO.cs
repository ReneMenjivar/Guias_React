
using reactBackend.Context;
using reactBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactBackend.Repository
{
    public class AlumnoDao
    {
        // Para hacer cualquier opracio con de datos debemos llamar al contexto
        // -> la peticion llama al contexto
        // -> contexto verifica el dataset
        // -> el data set mediante su datatable se actualiza
        // -> el contexto mediante su metodo save guarda las actualizaciones , delete o insert
        // -> devuelve el tipo de correspondiente de error o peticion.
        public RegistroAlumnosContext contexto = new RegistroAlumnosContext();

        public List<Alumno> SelectAll()
        {
            // Creamos una variable var que es generica 
            // El contexto tiene referecniada todos los modelos
            // Dentro de EF tenemos el metodo modelo.ToList<Modelo>
            var alumno = contexto.Alumnos.ToList<Alumno>();
            return alumno;
        }

        public Alumno? GetById(int id)
        {
            var alumno = contexto.Alumnos.Where(x => x.Id == id).FirstOrDefault();
            return alumno == null ? null : alumno;
        }

        public bool insertarAlumno(Alumno alumno)
        {
            try
            {
                var alum = new Alumno
                {
                    Direccion = alumno.Direccion,
                    Edad = alumno.Edad,
                    Email = alumno.Email,
                    Dni = alumno.Dni,
                    Nombre = alumno.Nombre
                };

                // Añadimos al contexto de dataset que representa la base de datos el metodo add
                contexto.Alumnos.Add(alum);
                // Este elemento en si no nos guardara los datos para ello debemos utilizar el metodo save
                contexto.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool update(int id, Alumno actualizar)
        {
            try
            {
                var alumnoUpdate = GetById(id);

                if (alumnoUpdate == null)
                {
                    Console.WriteLine("Alumno es null");
                    return false;
                }

                alumnoUpdate.Direccion = actualizar.Direccion;
                alumnoUpdate.Dni = actualizar.Dni;
                alumnoUpdate.Nombre = actualizar.Nombre;
                alumnoUpdate.Email = actualizar.Email;

                contexto.Alumnos.Update(alumnoUpdate);
                contexto.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }

        public bool borrarAlumno(int id)
        {
            var borrar = GetById(id);
            try
            {
                if (borrar == null)
                {
                    return false;
                }
                else
                {
                    contexto.Alumnos.Remove(borrar);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }

        public List<AlumnoAsignatura> SelectAlumAsig()
        {
            var consulta = from a in contexto.Alumnos
                           join m in contexto.Matriculas on a.Id equals m.AlumnoId
                           join asig in contexto.Asignaturas on m.AsignaturaId equals asig.Id
                           select new AlumnoAsignatura
                           {

                               nombreAlumno = a.Nombre,
                               nombreAsignatura = asig.Nombre

                           };

            return consulta.ToList();

        }

        public List<AlumnoProfesor> AlumnoProfesors(string nombreProfesor)
        {
            var listadoALumno = from a in contexto.Alumnos
                                join m in contexto.Matriculas on a.Id equals m.AlumnoId
                                join asig in contexto.Asignaturas on m.AsignaturaId equals asig.Id
                                where asig.Profesor == nombreProfesor
                                select new AlumnoProfesor
                                {
                                    Id = a.Id,
                                    Dni = a.Dni,
                                    Nombre = a.Nombre,
                                    Direccion = a.Direccion,
                                    Edad = a.Edad,
                                    Email = a.Email,
                                    Asignatura = asig.Nombre
                                };

            return listadoALumno.ToList();
        }

        public Alumno DNIAlumno(Alumno alumno)
        {
            var alumnos = contexto.Alumnos.Where(x => x.Dni == alumno.Dni).FirstOrDefault();
            return alumnos == null ? null : alumnos;
        }

        public bool InsertarMatricula(Alumno alumno, int idAsing)
        {
            try
            {
                var alumnoDNI = DNIAlumno(alumno);
                // Si existe solo lo añadimos pero si no lo debemos de insertar
                if (alumnoDNI == null)
                {
                    insertarAlumno(alumno);
                    // Si es null creamos el alumno pero ahora debemos de matricular el alumno con el Dni que corresponda
                    var alumnoInsertado = DNIAlumno(alumno);
                    // Ahora debemos crear un objeto matricula para poder hacer la insercion de ambas llaves
                    var unirAlumnoMatricula = matriculaAsignaturaAlumno(alumno, idAsing);
                    if (unirAlumnoMatricula == false)
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    matriculaAsignaturaAlumno(alumnoDNI, idAsing);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool matriculaAsignaturaAlumno(Alumno alumno, int idAsignatura)
        {
            try
            {
                Matricula matricula = new Matricula();
                matricula.AlumnoId = alumno.Id;
                matricula.AsignaturaId = idAsignatura;
                contexto.Matriculas.Add(matricula);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool eliminarAlumno(int id)
        {
            try
            {
                // Debemos verificar el id del alumno
                var alumno = contexto.Alumnos.Where(x => x.Id == id).FirstOrDefault();
                if (alumno != null)
                {
                    // matriculaAlumno == idALumno
                    var matriculaA = contexto.Matriculas.Where(x => x.AlumnoId == alumno.Id).ToList();
                    Console.WriteLine("Alumno encontrado");
                    // Traemos la calificaciones asociadas a esa matricula 
                    foreach (Matricula m in matriculaA)
                    {
                        var calificacion = contexto.Calificacions.Where(x => x.MatriculaId == m.Id).ToList();
                        Console.WriteLine("Matricula encontrada");
                        contexto.Calificacions.RemoveRange(calificacion);
                    }
                    contexto.Matriculas.RemoveRange(matriculaA);
                    contexto.Alumnos.Remove(alumno);
                    contexto.SaveChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine("Alumno no encontrado");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }
        }
    }
}