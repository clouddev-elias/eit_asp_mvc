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
    public class CategoriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Categories
        public IQueryable<CategoriesModel> GetCategories()
        {
            
            return db.Categories.AsNoTracking();
        }

        // GET: api/Categories/5
        [ResponseType(typeof(CategoriesModel))]
        public IHttpActionResult GetCategoriesModel(int id)
        {
            CategoriesModel categoriesModel = db.Categories.Find(id);
            if (categoriesModel == null)
            {
                return NotFound();
            }

            return Ok(categoriesModel);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategoriesModel(int id, CategoriesModel categoriesModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoriesModel.Id)
            {
                return BadRequest();
            }

            db.Entry(categoriesModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriesModelExists(id))
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

        // POST: api/Categories
        [ResponseType(typeof(CategoriesModel))]
        public IHttpActionResult PostCategoriesModel(CategoriesModel categoriesModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(categoriesModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categoriesModel.Id }, categoriesModel);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(CategoriesModel))]
        public IHttpActionResult DeleteCategoriesModel(int id)
        {
            CategoriesModel categoriesModel = db.Categories.Find(id);
            if (categoriesModel == null)
            {
                return NotFound();
            }

            db.Categories.Remove(categoriesModel);
            db.SaveChanges();

            return Ok(categoriesModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriesModelExists(int id)
        {
            return db.Categories.Count(e => e.Id == id) > 0;
        }
    }
}