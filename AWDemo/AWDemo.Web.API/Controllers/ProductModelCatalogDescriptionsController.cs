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
    public class ProductModelCatalogDescriptionsController : ApiController
    {
        private AWDemoContext db = new AWDemoContext();

        // GET: api/ProductModelCatalogDescriptions
        public IQueryable<vProductModelCatalogDescription> GetvProductModelCatalogDescriptions()
        {
            return db.vProductModelCatalogDescriptions;
        }

        // GET: api/ProductModelCatalogDescriptions/5
        [ResponseType(typeof(vProductModelCatalogDescription))]
        public IHttpActionResult GetvProductModelCatalogDescription(int id)
        {
            vProductModelCatalogDescription vProductModelCatalogDescription = db.vProductModelCatalogDescriptions.Find(id);
            if (vProductModelCatalogDescription == null)
            {
                return NotFound();
            }

            return Ok(vProductModelCatalogDescription);
        }

        // PUT: api/ProductModelCatalogDescriptions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutvProductModelCatalogDescription(int id, vProductModelCatalogDescription vProductModelCatalogDescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vProductModelCatalogDescription.ProductModelID)
            {
                return BadRequest();
            }

            db.Entry(vProductModelCatalogDescription).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vProductModelCatalogDescriptionExists(id))
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

        // POST: api/ProductModelCatalogDescriptions
        [ResponseType(typeof(vProductModelCatalogDescription))]
        public IHttpActionResult PostvProductModelCatalogDescription(vProductModelCatalogDescription vProductModelCatalogDescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vProductModelCatalogDescriptions.Add(vProductModelCatalogDescription);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (vProductModelCatalogDescriptionExists(vProductModelCatalogDescription.ProductModelID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vProductModelCatalogDescription.ProductModelID }, vProductModelCatalogDescription);
        }

        // DELETE: api/ProductModelCatalogDescriptions/5
        [ResponseType(typeof(vProductModelCatalogDescription))]
        public IHttpActionResult DeletevProductModelCatalogDescription(int id)
        {
            vProductModelCatalogDescription vProductModelCatalogDescription = db.vProductModelCatalogDescriptions.Find(id);
            if (vProductModelCatalogDescription == null)
            {
                return NotFound();
            }

            db.vProductModelCatalogDescriptions.Remove(vProductModelCatalogDescription);
            db.SaveChanges();

            return Ok(vProductModelCatalogDescription);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vProductModelCatalogDescriptionExists(int id)
        {
            return db.vProductModelCatalogDescriptions.Count(e => e.ProductModelID == id) > 0;
        }
    }
}