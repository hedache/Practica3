using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;

namespace Colegio.Web.Models
{
    public class Municipio
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        [Required]
        public string Name { get; set; }

        public ICollection<Barrio> Barrios { get; set; }
        [DisplayName("Cantidad de barrios")]
        public int CantidadBarrios => Barrios == null ? 0 : Barrios.Count;
    }
}
