using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EliasIT.API.Models;

namespace EliasIT.API.Controllers
{
    public class ArchiveController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Archive
        public IQueryable<ArchiveModel> GetArchiveModel()
        {
            return db.ArchiveModel;
        }

        // GET: api/Archive/5
        [ResponseType(typeof(ArchiveModel))]
        public IHttpActionResult GetArchiveModel(int id)
        {
            ArchiveModel archiveModel = db.ArchiveModel.Find(id);
            if (archiveModel == null)
            {
                return NotFound();
            }

            return Ok(archiveModel);
        }

        // PUT: api/Archive/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArchiveModel(int id, ArchiveModel archiveModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != archiveModel.pId)
            {
                return BadRequest();
            }

            db.Entry(archiveModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Archive
        [ResponseType(typeof(ArchiveModel))]
        public IHttpActionResult PostArchiveModel(ArchiveModel archiveModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ArchiveModel.Add(archiveModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = archiveModel.pId }, archiveModel);
        }

        // DELETE: api/Archive/5
        [ResponseType(typeof(ArchiveModel))]
        public IHttpActionResult DeleteArchiveModel(int id)
        {
            ArchiveModel archiveModel = db.ArchiveModel.Find(id);
            if (archiveModel == null)
            {
                return NotFound();
            }

            db.ArchiveModel.Remove(archiveModel);
            db.SaveChanges();

            return Ok(archiveModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArchiveModelExists(int id)
        {
            return db.ArchiveModel.Count(e => e.pId == id) > 0;
        }
    }
}