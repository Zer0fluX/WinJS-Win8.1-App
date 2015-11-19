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
using AWDemo.Web.API.Models;

namespace AWDemo.Web.API.Controllers
{
    public class vGetAllCategoriesController : ApiController
    {
        private AWDemoContext db = new AWDemoContext();

        // GET: api/vGetAllCategories
        public IQueryable<vGetAllCategory> GetvGetAllCategories()
        {
            return db.vGetAllCategories;
        }

        // GET: api/vGetAllCategories/5
        [ResponseType(typeof(vGetAllCategory))]
        public IHttpActionResult GetvGetAllCategory(string id)
        {
            vGetAllCategory vGetAllCategory = db.vGetAllCategories.Find(id);
            if (vGetAllCategory == null)
            {
                return NotFound();
            }

            return Ok(vGetAllCategory);
        }

        // PUT: api/vGetAllCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutvGetAllCategory(string id, vGetAllCategory vGetAllCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vGetAllCategory.ParentProductCategoryName)
            {
                return BadRequest();
            }

            db.Entry(vGetAllCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vGetAllCategoryExists(id))
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

        // POST: api/vGetAllCategories
        [ResponseType(typeof(vGetAllCategory))]
        public IHttpActionResult PostvGetAllCategory(vGetAllCategory vGetAllCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vGetAllCategories.Add(vGetAllCategory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (vGetAllCategoryExists(vGetAllCategory.ParentProductCategoryName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vGetAllCategory.ParentProductCategoryName }, vGetAllCategory);
        }

        // DELETE: api/vGetAllCategories/5
        [ResponseType(typeof(vGetAllCategory))]
        public IHttpActionResult DeletevGetAllCategory(string id)
        {
            vGetAllCategory vGetAllCategory = db.vGetAllCategories.Find(id);
            if (vGetAllCategory == null)
            {
                return NotFound();
            }

            db.vGetAllCategories.Remove(vGetAllCategory);
            db.SaveChanges();

            return Ok(vGetAllCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vGetAllCategoryExists(string id)
        {
            return db.vGetAllCategories.Count(e => e.ParentProductCategoryName == id) > 0;
        }
    }
}