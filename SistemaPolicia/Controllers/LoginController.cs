using System;
using System.Web.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SistemaPolicia.Models;

namespace SistemaPolicia.Controllers
{
    public class LoginController : Controller
    {
        MongoClient client = null;
        IMongoDatabase db = null;
        string table = "Users";


        public LoginController()
        {
            client = new MongoClient("mongodb://localhost:27017");
            db = client.GetDatabase("sistema");

            try
            {
                var collection = db.GetCollection<User>(table);
                collection.InsertOne(new User() { ID = 1, _id = 1, user = "Admin", senha = "1234" });
            }
            catch { }
        }

        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login(string nome, string senha)
        {
            if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(senha))
            {
                var mongoCollection = db.GetCollection<User>(table);
                var query = from e in mongoCollection.AsQueryable<User>() select e;
                var collection = query.ToList();
                User policial = null;

                for (int i = 0; i < collection.Count; i++)
                {
                    if (collection[i].user == nome && collection[i].senha == senha)
                    {
                        policial = collection[i];
                        break;
                    }
                }

                if (policial != null)
                {
                    return Json(new { status = "success" });
                }
                else
                {
                    return Json(new { status = "error" });
                }
            }
            else
            {
                return Json(new { status = "ErrorNUll" });
            }
        }
    }
}