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
using NousDemoApp.Models;

namespace NousDemoApp.Controllers
{
    public class ImageUploadInfoesController : ApiController
    {
        private ImageEntities db = new ImageEntities();

        // GET: api/ImageUploadInfoes
        public IQueryable<ImageUploadInfo> GetImageUploadInfoes()
        {
            return db.ImageUploadInfoes;
        }

        // GET: api/ImageUploadInfoes/5
        [ResponseType(typeof(ImageUploadInfo))]
        public IHttpActionResult GetImageUploadInfo(int id)
        {
            ImageUploadInfo imageUploadInfo = db.ImageUploadInfoes.Find(id);
            if (imageUploadInfo == null)
            {
                return NotFound();
            }

            return Ok(imageUploadInfo);
        }

        // PUT: api/ImageUploadInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImageUploadInfo(int id, ImageUploadInfo imageUploadInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imageUploadInfo.ImageNo)
            {
                return BadRequest();
            }

            db.Entry(imageUploadInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageUploadInfoExists(id))
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

        // POST: api/ImageUploadInfoes
        [ResponseType(typeof(ImageUploadInfo))]
        public IHttpActionResult PostImageUploadInfo(ImageUploadInfo imageUploadInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ImageUploadInfoes.Add(imageUploadInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = imageUploadInfo.ImageNo }, imageUploadInfo);
        }

        // DELETE: api/ImageUploadInfoes/5
        [ResponseType(typeof(ImageUploadInfo))]
        public IHttpActionResult DeleteImageUploadInfo(int id)
        {
            ImageUploadInfo imageUploadInfo = db.ImageUploadInfoes.Find(id);
            if (imageUploadInfo == null)
            {
                return NotFound();
            }

            db.ImageUploadInfoes.Remove(imageUploadInfo);
            db.SaveChanges();

            return Ok(imageUploadInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImageUploadInfoExists(int id)
        {
            return db.ImageUploadInfoes.Count(e => e.ImageNo == id) > 0;
        }
    }
}