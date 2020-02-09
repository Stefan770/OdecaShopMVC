using OdecaShopMVC.Repository;
using OdecaShopMVC.ViewModels;
using OdecaShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdecaShopMVC.Controllers
{
    public class ArtikalController : Controller
    {
        IArtikalRepo artikalRepo = new ArtikalRepo();
        IKategorijaRepo kategorijaRepo = new KategorijaRepo();
        ITipRepo tipRepo = new TipRepo();

        // GET: Artikal
        public ActionResult Index()
        {
            ArtikliTkaViewModel vm = new ArtikliTkaViewModel
            {
                Artikli = artikalRepo.GetAll(),
                Tkavm = new TipoviKategorijeArtikalViewModel
                {
                    Artikal = new Artikal(),
                    Kategorije = kategorijaRepo.GetAll(),
                    Tipovi = tipRepo.GetAll()
                }
            };

            return View(vm);
        }

        public ActionResult AkcijaFilter()
        {
            List<Artikal> artikli = artikalRepo.GetAll();
            artikli = artikli.Where(x => x.Akcija == true).ToList();

            return View(artikli);
        }


        // POST: Artikal/Create
        [HttpPost]
        public ActionResult Create(Artikal artikal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    artikalRepo.Create(artikal);

                    return RedirectToAction("Index");
                }

                ArtikliTkaViewModel vm = new ArtikliTkaViewModel
                {
                    Artikli = artikalRepo.GetAll(),
                    Tkavm = new TipoviKategorijeArtikalViewModel
                    {
                        Artikal = artikal,
                        Kategorije = kategorijaRepo.GetAll(),
                        Tipovi = tipRepo.GetAll()
                    }
                };

                return View("Index", vm);
            }
            catch
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        // GET: Artikal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Artikal/Edit/5
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

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                artikalRepo.DeleteLogical(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
