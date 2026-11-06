using ApiRoblox.Models;
using System.Linq;
using System.Web.Http;

namespace ApiRoblox.Controllers
{
    public class ExperienciasController : ApiController
    {
        private RobloxContext db = new RobloxContext();

        // GET: api/experiencias
        public IHttpActionResult Get()
            => Ok(db.Experiencias.ToList());

        // GET: api/experiencias/5
        public IHttpActionResult Get(int id)
        {
            var m = db.Experiencias.Find(id);
            return m == null ? (IHttpActionResult)NotFound() : Ok(m);
        }

        // POST: api/experiencias
        public IHttpActionResult Post(Experiencia mat)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            db.Experiencias.Add(mat);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = mat.ExperienciaId }, mat);
        }

        // PUT: api/experiencias/5
        public IHttpActionResult Put(int id, Experiencia mat)
        {
            var m = db.Experiencias.Find(id);
            if (m == null) return NotFound();
            m.Nombre = mat.Nombre; m.Genero = mat.Genero;
            db.SaveChanges();
            return Ok(m);
        }

        // DELETE: api/experiencias/5
        public IHttpActionResult Delete(int id)
        {
            var m = db.Experiencias.Find(id);
            if (m == null) return NotFound();
            db.Experiencias.Remove(m);
            db.SaveChanges();
            return Ok("Experiencia eliminada de la plataforma correctamente");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}