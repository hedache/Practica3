using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Colegio.Web.Data;
using Colegio.Web.Models;


public class SeedDb
{
    private readonly ApplicationDbContext _context;
    public SeedDb(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckCountriesAsync();
    }
    private async Task CheckCountriesAsync()
    {
        if (!_context.Municipios.Any())
        {
            _context.Municipios.Add(new Municipio
            {
                Name = "Medellín",
                Barrios = new List<Barrio>
 {
 new Barrio
 {
 Name = "Poblado",
 Alumnos = new List<Alumno>
 {
 new Alumno { Name = "Pedro", LastName = "Lopez", DNI = "12345", Direecion = "Av. Siempre viva", Telefono = "12345", Correo = "pedro@itm.com", Grado = "9", Edad = "30" },
 new Alumno { Name = "Ana", LastName = "Prueba", DNI = "12345", Direecion = "Av. Siempre viva", Telefono = "12345", Correo = "Ana@itm.com", Grado = "5", Edad = "32" },
 new Alumno { Name = "Juan", LastName = "Don", DNI = "12345", Direecion = "Av. Siempre viva", Telefono = "12345", Correo = "Juan@itm.com", Grado = "7", Edad = "22" },
 }
 },
 new Barrio
 {
 Name = "Buenos Aires",
Alumnos = new List<Alumno>


 {
 new Alumno { Name = "Prueba", LastName = "Prueba", DNI = "12345", Direecion = "Av. Siempre viva", Telefono = "12345", Correo = "prueba@itm.com", Grado = "9", Edad = "4" },

}
 },
 new Barrio

{
 Name = "Caribe",
 Alumnos = new List<Alumno>

{
 new Alumno { Name = "Sara", LastName = "Lopez", DNI = "12345", Direecion = "Av. Siempre viva", Telefono = "12345", Correo = "pedro@itm.com", Grado = "9", Edad = "30" },
 new Alumno { Name = "Juana", LastName = "Prueba", DNI = "12345", Direecion = "Av. Siempre viva", Telefono = "12345", Correo = "Ana@itm.com", Grado = "5", Edad = "32" },
 new Alumno { Name = "Juanes", LastName = "Don", DNI = "12345", Direecion = "Av. Siempre viva", Telefono = "12345", Correo = "Juan@itm.com", Grado = "7", Edad = "22" },

}

}

}
            });
            _context.Municipios.Add(new Municipio

            {
                Name = "Bello",
                Barrios = new List<Barrio>

{
 new Barrio

{
 Name = "Estacíon",
 Alumnos = new List<Alumno>

{
 new Alumno { Name = "Oscar", LastName = "Lopez", DNI = "12345", Direecion = "Av. Siempre viva", Telefono = "12345", Correo = "pedro@itm.com", Grado = "9", Edad = "30" },
 new Alumno { Name = "Miguel", LastName = "Prueba", DNI = "12345", Direecion = "Av. Siempre viva", Telefono = "12345", Correo = "Ana@itm.com", Grado = "5", Edad = "32" },
 new Alumno { Name = "Name", LastName = "Don", DNI = "12345", Direecion = "Av. Siempre viva", Telefono = "12345", Correo = "Juan@itm.com", Grado = "7", Edad = "22" },

}
 },
 new Barrio

{
 Name = "Montaña",
 Alumnos = new List<Alumno>

{
 new Alumno { Name = "NoName", LastName = "Lopez", DNI = "12345", Direecion = "Av. Siempre viva", Telefono = "12345", Correo = "pedro@itm.com", Grado = "9", Edad = "30" },
 new Alumno { Name = "Maria", LastName = "Prueba", DNI = "12345", Direecion = "Av. Siempre viva", Telefono = "12345", Correo = "Ana@itm.com", Grado = "5", Edad = "32" },
 new Alumno { Name = "Rosa", LastName = "Don", DNI = "12345", Direecion = "Av. Siempre viva", Telefono = "12345", Correo = "Juan@itm.com", Grado = "7", Edad = "22" },

}

}

}
            });
            await _context.SaveChangesAsync();

        }

    }
}