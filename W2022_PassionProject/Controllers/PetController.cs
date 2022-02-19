using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Diagnostics;
using W2022_PassionProject.Models;
using System.Web.Script.Serialization;

namespace W2022_PassionProject.Controllers
{
    public class PetController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();


        static PetController() 
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44348/api/petsdata/");
        }
        // GET: Pet/List
        public ActionResult List()
        {
            //objective: to communicate with pet api to retrive a list of pets
            //curl https://localhost:44348/api/petsdata/listpets

            string url = "listpets";
            HttpResponseMessage response = client.GetAsync(url).Result;
            
            //Debug.WriteLine("The response code is: ");
            //Debug.WriteLine(response.StatusCode);

            IEnumerable<PetDto> pets = response.Content.ReadAsAsync<IEnumerable<PetDto>>().Result;
            //Debug.WriteLine("Number of pets: ");
            //Debug.WriteLine(pets.Count());

            return View(pets);
        }

        // GET: Pet/Details/5
        public ActionResult Details(int id)
        {
            //objective: to communicate with pet data api to retrive a one of pets
            //curl https://localhost:44348/api/petsdata/FindPet/{id} 

            string url = "FindPet/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            //Debug.WriteLine("The response code is: ");
            //Debug.WriteLine(response.StatusCode);

            PetDto selectedpet = response.Content.ReadAsAsync<PetDto>().Result;
            //Debug.WriteLine("Pet recieved: ");
            //Debug.WriteLine(selectedpet.PetName);

            return View(selectedpet);
        }

        public ActionResult Error() 
        {
            return View();
        }
        // GET: Pet/New
        public ActionResult New()
        {
            return View();
        }

        // POST: Pet/Create
        [HttpPost]
        public ActionResult Create(Pet pet)
        {
            Debug.WriteLine("The input name is: ");
            //Debug.WriteLine(pet.PetName);
            //objective add a new pet into our system
            //curl -H "Content-Type:application/json" -d @pet.jason https://localhost:44348/api/petsdata/addpet

            string url = "addpet";

            string jsonpayload = jss.Serialize(pet);

            Debug.WriteLine("The json payload is: ");
            Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else 
            {
                return RedirectToAction("Error");
            }

        }

        // GET: Pet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
