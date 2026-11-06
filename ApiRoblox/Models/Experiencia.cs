using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiRoblox.Models
{
    public class Experiencia
    {
        [Key]
        public int ExperienciaId { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
    }
}