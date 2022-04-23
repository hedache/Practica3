using System.ComponentModel.DataAnnotations;

namespace Colegio.Web.Models
{
    public class Municipio
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        [Required]
        public string Name { get; set; }
    }
}
