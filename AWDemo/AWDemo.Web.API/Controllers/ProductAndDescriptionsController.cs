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
    public class ProductAndDescriptionsController : ApiController
    {
        private AWDemoContext db = new AWDemoContext();

        // GET: api/ProductAndDescriptions
        public IQueryable<vProductAndDescription> GetvProductAndDescriptions()
        {
            return db.vProductAndDescriptions;
        }

        // GET: api/ProductAndDescriptions/5
        [ResponseType(typeof(vProductAndDescription))]
        public IHttpActionResult GetvProductAndDescription(int id)
        {
            vProductAndDescription vProductAndDescription = db.vProductAndDescriptions.Find(id);
            if (vProductAndDescription == null)
            {
                return NotFound();
            }

            return Ok(vProductAndDescription);
        }

        // PUT: api/ProductAndDescriptions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutvProductAndDescription(int id, vProductAndDescription vProductAndDescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vProductAndDescription.ProductID)
            {
                return BadRequest();
            }

            db.Entry(vProductAndDescription).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vProductAndDescriptionExists(id))
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

        // POST: api/ProductAndDescriptions
        [ResponseType(typeof(vProductAndDescription))]
        public IHttpActionResult PostvProductAndDescription(vProductAndDescription vProductAndDescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vProductAndDescriptions.Add(vProductAndDescription);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (vProductAndDescriptionExists(vProductAndDescription.ProductID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vProductAndDescription.ProductID }, vProductAndDescription);
        }

        // DELETE: api/ProductAndDescriptions/5
        [ResponseType(typeof(vProductAndDescription))]
        public IHttpActionResult DeletevProductAndDescription(int id)
        {
            vProductAndDescription vProductAndDescription = db.vProductAndDescriptions.Find(id);
            if (vProductAndDescription == null)
            {
                return NotFound();
            }

            db.vProductAndDescriptions.Remove(vProductAndDescription);
            db.SaveChanges();

            return Ok(vProductAndDescription);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vProductAndDescriptionExists(int id)
        {
            return db.vProductAndDescriptions.Count(e => e.ProductID == id) > 0;
        }
    }
}