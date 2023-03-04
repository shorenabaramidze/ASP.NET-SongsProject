using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Homework1.Filters;
using SongDataAccess;

namespace Homework1.Controllers
{
    [RoutePrefix("api/songs1")] 
    //[log]
    //[Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")] // cors-policy
    public class Songs1Controller : ApiController
    {

        private singersEntities db = new singersEntities();
        //[AllowAnonymous]
        // GET: api/Songs1
        //[Route]
        [Route("")]
        public IQueryable<Song> GetSongs()
        {
            return db.Songs;
        }

        // GET: api/Songs1/5
        //[Route]
        //[AllowAnonymous]
        [HttpGet]
        [Route("{ID:int}")]
        [ResponseType(typeof(Song))]

        public HttpResponseMessage GetSong(int ID)
        {
            Song song = db.Songs.Find(ID);

            if (song == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ID);
            }

            return Request.CreateResponse(HttpStatusCode.OK, song);
        }

        //GET ფუნქცია სახელის მიხედვით
        [HttpGet]
        //[Route]
        [Route("SongByName/(SongName:alpha)", Name = "ByName")]

        public IHttpActionResult GetSongByName(string SongName)
        {
            List<Song> songs = db.Songs.Where(x => x.SongName == SongName).ToList();
            if (songs == null)
            {
                return NotFound();
            }
            return Ok(songs);
        }


        //PUT: api/Songs1/5
        //[MyExceptionFilter]
        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("")]

        public IHttpActionResult PutSong(Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(song).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(song.ID))
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

        

        // POST: api/Songs1
        [MyExceptionFilter]
        [HttpPost]
        [Route("")]
        //[Route]
        [ResponseType(typeof(Song))]
        public IHttpActionResult PostSong(Song song)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (var ctx = new singersEntities())
            {
                ctx.Songs.Add(new Song()
                {
                    ID = song.ID,
                    FirstName = song.FirstName,
                    LastName = song.LastName,
                    Released = song.Released,
                    SongName = song.SongName
                });

                ctx.SaveChanges(); 
                

            }

            return Ok();
        }


   

        // DELETE: api/Songs1/5
        [HttpDelete]
        [ResponseType(typeof(Song))]
        [Route("{id:int}")]
        [Route("")]
        public IHttpActionResult DeleteSong(int id)
        {
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return NotFound();
            }

            db.Songs.Remove(song);
            db.SaveChanges();

            return Ok(song);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SongExists(int id)
        {
            return db.Songs.Count(e => e.ID == id) > 0;
        }
    }
}