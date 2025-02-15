using reacktBackend.Models;
using reacktBackend.Repository;

AlumnoDAO alumnoDao = new AlumnoDAO();

var alumno = alumnoDao.SelectAll();

foreach (var item in alumno)
{
    Console.WriteLine(item.Nombre);
}

#region SelectByID

var selectById = alumnoDao.GetById(1000);
Console.WriteLine(selectById?.Nombre);

#endregion