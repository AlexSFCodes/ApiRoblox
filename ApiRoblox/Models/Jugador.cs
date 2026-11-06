using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiRoblox.Models
{
    public class Jugador
    {
        [Key]
        public int JugadorId { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
}