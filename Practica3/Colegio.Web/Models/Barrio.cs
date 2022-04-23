using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Colegio.Web.Models
{
    public class Barrio
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        [Required]
        public string Name { get; set; }
        public ICollection<Alumno> Alumnos { get; set; }
        [DisplayName("Cantidad de alumnos")]
        public int CantidadAlumnos => Alumnos == null ? 0 : Alumnos.Count;

        [JsonIgnore] //lo ignora en la respuesta json
        [NotMapped] //no se crea en la base de datos
        public int IdMunicipio { get; set; }

    }
}
