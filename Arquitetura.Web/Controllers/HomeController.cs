using Arquitetura.Aplicacao.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Arquitetura.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Membros

        readonly IMunicipioAppService _municipioService;

        public HomeController(IMunicipioAppService municipioService)
        {
            _municipioService = municipioService;
        }

        #endregion

        public ActionResult Index()
        {
            var municipios = _municipioService.FindMunicipios(null, c => c.Descricao);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}