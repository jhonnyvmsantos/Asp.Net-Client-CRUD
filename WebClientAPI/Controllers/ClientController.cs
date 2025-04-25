using System.Reflection;
using System.Web.Mvc;
using NHibernate;
using WebClientAPI.Models.Entities;
using WebClientAPI.Models.Services;

namespace WebClientAPI.Controllers
{
    public class ClientController : Controller
    {
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var client = new ClientServices(session).GetAllClients();
                return View(client);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {

            if (ModelState.IsValid)
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    new ClientServices(session).AddClient(client);
                }

                return RedirectToAction("Index");
            }

            return View(client);
        }

        public ActionResult Details(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var client = new ClientServices(session).GetUniqueClient(id);
                return View(client);
            }
        }

        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var client = new ClientServices(session).GetUniqueClient(id);
                return View(client);
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Client client)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var _client = session.Get<Client>(id);
                    _client.Name = client.Name;
                    _client.Gender = client.Gender;
                    _client.Address = client.Address;
                    _client.Phone = client.Phone;

                    new ClientServices(session).EditClient(_client);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var client = new ClientServices(session).GetUniqueClient(id);
                return View(client);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, Client client)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    client = new ClientServices(session).GetUniqueClient(id);
                    new ClientServices(session).DeleteClient(client);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}