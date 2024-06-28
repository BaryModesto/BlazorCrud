using System.ComponentModel.DataAnnotations;

namespace BlazorCrud.Modelo
{
    public class Libro
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "El Titulo es obligatorio")]
        public string titulo { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        public string descripcion{ get; set; }
        [Required(ErrorMessage = "El autor es obligatorio")]
        public string autor{ get; set; }
        [Required(ErrorMessage = "La cantidad de paginas es obligatorio")]
        [Range(1,1000,ErrorMessage ="Numero de paginas invalidos")]
        public int paginas{ get; set; }
        [Required(ErrorMessage = "El precio es obligatorio")]
        public int precio { get; set; }
        public DateTime fecha_creacion { get; set; }
    }
}
