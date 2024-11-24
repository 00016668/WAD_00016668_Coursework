using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WAD.CODEBASE._00016668.MVC.Models;

namespace WAD.CODEBASE._00016668.MVC.Controllers
{
    public class ContactsController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5175/api");
        private readonly HttpClient _client;



        public ContactsController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }




        // GET: ContactsController
        public ActionResult Index()
        {
            List<ContactsModelMVC> contactLIst = new List<ContactsModelMVC>();
            HttpResponseMessage message = _client.GetAsync(_client.BaseAddress + "/").Result;
            return View();
        }

        // GET: ContactsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContactsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
