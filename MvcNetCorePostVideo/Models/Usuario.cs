using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcNetCorePostVideo.Models
{
    [Table("USUARIOS")]
    public class Usuario
    {
        [Key]
        [Column("ID")]
        public int IdUsuario { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("APELLIDO")]
        public string Apellido { get; set; }
        [Column("CORREO")]
        public string Correo { get; set; }
    }
}
