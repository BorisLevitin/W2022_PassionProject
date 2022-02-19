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
using W2022_PassionProject.Models;
using System.Diagnostics;

namespace W2022_PassionProject.Controllers
{
    public class PetsDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PetsData/ListPets
        [HttpGet]
        public IEnumerable<PetDto> ListPets()
        {
            List<Pet> Pets = db.Pets.ToList();
            List<PetDto> PetDtos = new List<PetDto>();

            Pets.ForEach(a => PetDtos.Add(new PetDto(){
                PetID=a.PetID,
                PetName=a.PetName,
                PetBreed=a.PetBreed,
                PetAge=a.PetAge,
                PetCharacter=a.PetCharacter,
                PetWeight=a.PetWeight,
                ParkName=a.Parks.ParkName
            }));

            return PetDtos;
        }

        // GET: api/PetsData/FindPet/5
        [ResponseType(typeof(Pet))]
        [HttpGet]
        public IHttpActionResult FindPet(int id)
        {
            Pet Pet = db.Pets.Find(id);
            PetDto PetDto = new PetDto()
            {
                PetID = Pet.PetID,
                PetName = Pet.PetName,
                PetBreed = Pet.PetBreed,
                PetAge = Pet.PetAge,
                PetCharacter = Pet.PetCharacter,
                PetWeight = Pet.PetWeight,
                ParkName = Pet.Parks.ParkName
            };
            if (Pet == null)
            {
                return NotFound();
            }

            return Ok(PetDto);
        }

        // POST: api/PetsData/FindPet/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdatePet(int id, Pet pet)
        {
            Debug.WriteLine("I've reached the update pet method!");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pet.PetID)
            {
                return BadRequest();
            }

            db.Entry(pet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
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

        // POST: api/PetsData/AddPet
        [ResponseType(typeof(Pet))]
        [HttpPost]
        public IHttpActionResult AddPet(Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pets.Add(pet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pet.PetID }, pet);
        }

        // POST: api/PetsData/DeletePet/5
        [ResponseType(typeof(Pet))]
        [HttpPost]
        public IHttpActionResult DeletePet(int id)
        {
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return NotFound();
            }

            db.Pets.Remove(pet);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetExists(int id)
        {
            return db.Pets.Count(e => e.PetID == id) > 0;
        }
    }
}