using ApiRoblox.Models;
using System.Linq;
using System.Web.Http;

namespace ApiRoblox.Controllers
{
    public class JugadoresController : ApiController
    {
        private RobloxContext db = new RobloxContext();

        // GET: api/jugadores
        public IHttpActionResult Get()
            => Ok(db.Jugadores.ToList());

        // GET: api/jugadores/5
        public IHttpActionResult Get(int id)
        {
            var e = db.Jugadores.Find(id);
            return e == null ? (IHttpActionResult)NotFound() : Ok(e);
        }

        // POST: api/jugadores
        public IHttpActionResult Post(Jugador est)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            db.Jugadores.Add(est);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = est.JugadorId }, est);
        }

        // PUT: api/jugadores/5
        public IHttpActionResult Put(int id, Jugador est)
        {
            var e = db.Jugadores.Find(id);
            if (e == null) return NotFound();
            e.Nombre = est.Nombre; e.Edad = est.Edad;
            db.SaveChanges();
            return Ok(e);
        }

        // DELETE: api/jugadores/5
        public IHttpActionResult Delete(int id)
        {
            var e = db.Jugadores.Find(id);
            if (e == null) return NotFound();
            db.Jugadores.Remove(e);
            db.SaveChanges();
            return Ok("Jugador eliminado correctamente");
        }

        // Libera la conexión a la base de datos
        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}