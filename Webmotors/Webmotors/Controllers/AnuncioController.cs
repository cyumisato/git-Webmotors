using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webmotors.Classes;
using Webmotors.DAL;
using Webmotors.Models;
using Webmotors.ViewModels;

namespace Webmotors.Controllers
{
    public class AnuncioController : Controller
    {
        private ConsultaHttp _consultar;
        private AnuncioDAL _dal;

        public AnuncioController()
        {
            _consultar = new ConsultaHttp();
            _dal = new AnuncioDAL();
        }

        // GET: Anuncio
        public ActionResult Index()
        {
            var data = new List<Anuncio>();

            data = _dal.List();

            return View(data);
        }

        [HttpGet]
        public ActionResult AddEdit(int? id)
        {
            var data = new Anuncio();

            if (id != null)
            {
                data = _dal.Get(id);
            }

            return View(data);
        }

        [HttpPost]
        public ActionResult AddEdit(Anuncio model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                bool result;

                if (model == null || model.ID == 0)
                {
                    result = _dal.Add(model);
                }
                else
                {
                    result = _dal.Edit(model);
                }

                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
        }

        public ActionResult Delete(int id)
        {
            _dal.Delete(id);

            return RedirectToAction("Index");
        }

        public JsonResult ObterMarcas()
        {
            var url = ConfigurationManager.AppSettings["UrlMarcas"];
            var dados = _consultar.Consultar(url);

            var result = JsonConvert.DeserializeObject<List<ListaPadraoViewModel>>(dados);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObterModelos(int id)
        {
            var url = $"{ConfigurationManager.AppSettings["UrlModelos"]}{id}";
            var dados = _consultar.Consultar(url);

            var result = JsonConvert.DeserializeObject<List<ListaPadraoViewModel>>(dados);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObterVersoes(int id)
        {
            var url = $"{ConfigurationManager.AppSettings["UrlVersoes"]}{id}";
            var dados = _consultar.Consultar(url);

            var result = JsonConvert.DeserializeObject<List<ListaPadraoViewModel>>(dados);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObterVeiculos(int id)
        {
            var url = $"{ConfigurationManager.AppSettings["UrlVeiculos"]}{id}";
            var dados = _consultar.Consultar(url);

            var result = JsonConvert.DeserializeObject<List<ListaPadraoViewModel>>(dados);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}