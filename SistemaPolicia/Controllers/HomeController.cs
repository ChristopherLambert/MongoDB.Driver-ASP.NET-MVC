using System;
using System.Web.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SistemaPolicia.Models;

namespace SistemaPolicia.Controllers
{
    public class HomeController : Controller
    {
        MongoClient client = null;
        IMongoDatabase db = null;
        string table = "ocorrencias";

        public HomeController()
        {
            client = new MongoClient("mongodb://localhost:27017");
            db = client.GetDatabase("sistema");
        }

        public ActionResult Index()
        {
            return View();
        }

        //Ocorrencias
        public ActionResult Registro()
        {
            var mongoCollection = db.GetCollection<Ocorrencia>(table);
            var query = from e in mongoCollection.AsQueryable<Ocorrencia>() select e;
            var collection = query.ToList();

            return View(collection);
        }

        public ActionResult CreateGrid(string query = "")
        {
            var mongoCollection = db.GetCollection<Ocorrencia>(table);
            var queryMDB = from e in mongoCollection.AsQueryable<Ocorrencia>() select e;
            var collection = queryMDB.ToList();

            return PartialView("Grid", collection);
        }

        public ActionResult CreateForm(string id)
        {
            Ocorrencia ocorrencia = null;
            var mongoCollection = db.GetCollection<Ocorrencia>(table);
            var queryMDB = from e in mongoCollection.AsQueryable<Ocorrencia>() select e;
            var collection = queryMDB.ToList();

            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i].ID == Convert.ToInt32(id))
                {
                    ocorrencia = collection[i];
                    break;
                }

            }
            return PartialView("Form", ocorrencia);
        }

        public ActionResult Excluir(string param)
        {
            string[] itens = param.Split(',');
            try
            {
                var mongoCollection = db.GetCollection<Ocorrencia>(table);
                foreach (string item in itens)
                {
                    var iditem = Convert.ToInt32(item);
                    mongoCollection.DeleteOne(a => a.ID == iditem);
                }

                return Json(new { status = "success", control = "Home", msg = "Ocorrência Excluida com Sucesso" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "errorInternal" });
            }
        }

        public ActionResult Inserir(Ocorrencia model)
        {
            try
            {
                model._id = model.ID = new Random().Next(1, 1000000);
                var collection = db.GetCollection<Ocorrencia>(table);
                collection.InsertOne(model);

                return Json(new { status = "success", msg = "Ocorrência Cadastrada com Sucesso" });

            }
            catch (Exception ex)
            {
                return Json(new { status = "errorInternal" });
            }
        }

        public ActionResult Editar(Ocorrencia model)
        {
            var mongoCollection = db.GetCollection<Ocorrencia>(table);

            model._id = model.ID;
            mongoCollection.DeleteOne(a => a.ID == model.ID);
            mongoCollection.InsertOne(model);

            return Json(new { status = "success", msg = "Ocorrência Alterada com Sucesso" });

        }
    }
}