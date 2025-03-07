using reacktBackend.Models;
using reactBackend.Repository;

// Abstracción de un objeto Dao
AlumnoDao alumnoDao = new AlumnoDao();

// Llamamos al metodo que ceramos en Dao
var alumno = alumnoDao.SelectAll();

// Recorremos la lista
foreach (var item in alumno)
{
    Console.WriteLine(item.Nombre);
}

Console.WriteLine(" ");

// Probamos el select por Id
var selectById = alumnoDao.GetById(10);
Console.WriteLine(selectById?.Nombre);

Console.WriteLine(" ");

// Agregamos un registro
//var nuevoAlumno = new Alumno
//{
//    Direccion = "Chalatenango",
//    Dni = "12345",
//    Edad = 30,
//    Email = "12345@email.com",
//    Nombre = "Alondra"
//};
//var resultado = alumnoDao.insertarAlumno(nuevoAlumno);
//Console.WriteLine(resultado);

Console.WriteLine(" ");

// Actualizar un registro
//var nuevoAlumno2 = new Alumno
//{

//    Direccion = "Ojos de Agua",
//    Dni = "12345",
//    Edad = 23,
//    Email = "12345@email.com",
//    Nombre = "Alondra Lopez"

//};
//var resultado2 = alumnoDao.actualizarAlumno(2, nuevoAlumno2);
//Console.WriteLine(resultado2);

Console.WriteLine(" ");

// Borrar un registro
//var resultado = alumnoDao.borrarAlumno(23);
//Console.WriteLine("Se elimino el usuario " + resultado);

//Console.WriteLine(" ");

// Asignatura desde JOIN
var alumAsig = alumnoDao.SelectAlumAsig();
foreach (AlumnoAsignatura alumAsig2 in alumAsig)
{
    Console.WriteLine(alumAsig2.nombreAlumno + " Asignatura que cursa " + alumAsig2.nombreAsignatura);
}
