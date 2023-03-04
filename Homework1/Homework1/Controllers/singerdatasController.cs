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
using Homework1.Models;
using SongDataAccess;

namespace Homework1.Controllers
{
    public class singerdatasController : ApiController
    {    
        
        private singersEntities db = new singersEntities();

        // GET: api/singerdatas

        public IQueryable<singerdata> Getsingerdatas()
        {
            return db.singers;
        }

        // GET: api/singerdatas/5
        [ResponseType(typeof(singerdata))]
        public IHttpActionResult Getsingerdata(int ID)
        {
            singerdata singers = db.singers.Find(ID);
            if (singers == null)
            {
                return NotFound();
            }

            return Ok(singers);
        }

        // PUT: api/singerdatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsingerdata(int ID, singerdatas singerdata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (ID != singerdata.ID)
            {
                return BadRequest();
            }

            db.Entry(singerdata).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!singerdataExists(ID))
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

        // POST: api/singerdatas
        [ResponseType(typeof(singerdatas))]
        public IHttpActionResult Postsingerdata(singerdata singerdata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.singers.Add(singerdata);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = singerdata.ID }, singerdata);
        }

        // DELETE: api/singerdatas/5
        [ResponseType(typeof(singerdata))]
        public IHttpActionResult Deletesingerdata(int id)
        {
            singerdata singerdata = db.singers.Find(id);
            if (singerdata == null)
            {
                return NotFound();
            }

            db.singers.Remove(singerdata);
            db.SaveChanges();

            return Ok(singerdata);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool singerdataExists(int id)
        {
            return db.singers.Count(e => e.ID == id) > 0;
        }
    }
}