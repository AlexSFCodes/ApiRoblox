using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiRoblox.Models
{
    public class RobloxContext : DbContext
    {
        public RobloxContext() : base("name=RobloxConnection") { }

        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Experiencia> Experiencias { get; set; }
    }
}