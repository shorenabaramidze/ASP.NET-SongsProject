using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;
using WebAppMVC.Filters;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    [Log] //logattribute filteris gamoyeneba. logireba consolshi
    public class SongsController : Controller
    {

        //// GET: songs1
        public ActionResult Index()
        {
            IEnumerable<Song> songs = null; //mvc modelis wamogeba. SongsModel rogorc song

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44310/api"); //api
                //HTTP GET
                var responseTask = client.GetAsync("songs1"); //api controlleridan monacemebis wamogeba
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Song>>();//modeli
                    readTask.Wait();

                    songs = readTask.Result;
                }
                else 
                {
                    

                    songs = Enumerable.Empty<Song>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(songs);
        }


        ////create metodi - 
        public ActionResult Create()
        {
            return View();
        }
        //post metodi
        [HttpPost]
        public ActionResult Create(Song song)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44310/api/songs1");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Song>("songs1", song); 
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(song);
        }

        [HttpGet]
        ////edit/update method 
        public ActionResult Edit(int ID)
        {
            Song song = null; //mvc მოდელის წამოღება

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44310/api");//Api
                
                //HTTP GET
                //var responseTask = client.GetAsync("song?id=" + ID.ToString());
                var result = client.GetAsync("songs1/" + ID.ToString()).Result;
                //responseTask.Wait();

                //var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    song= result.Content.ReadAsAsync<Song>().Result;
                    //var readTask = result.Content.ReadAsAsync<Song>();
                    //readTask.Wait();

                    //song = readTask.Result;
                }
            }

            return View(song);
        }

        //save button
        [HttpPost]
        public ActionResult Edit(Song song)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44310/api/"); //api/

                //HTTP POST 
                var putTask = client.PutAsJsonAsync<Song>("songs1", song); //song?
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(song);
        }

        //delete 
        public ActionResult Delete(int ID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44310/api");//api

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("songs1/" + ID.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            
            return RedirectToAction("Index");
        }





    }




}
