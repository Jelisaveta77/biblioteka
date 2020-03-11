﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //[Route("knjiga")]
    public class KnjigaController : Controller
    {
        // GET: Knjiga
        [HttpGet]
        public ActionResult Index()
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var knjige = bdb.Knjiga.ToList();

            return View(knjige);
        }

        // GET: Knjiga/Izmeni/5
        //[Route("{knjigaId}")]
        public ActionResult Izmeni(int id)
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var knjiga = bdb.Knjiga.FirstOrDefault(a => a.KnjigaId == id);

            return View(knjiga);
        }

        [HttpPost]
        public ActionResult Izmeni(KnjigaModel km)
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var knjiga = bdb.Knjiga.FirstOrDefault(a => a.KnjigaId == km.KnjigaId);

            knjiga.MestoIzdavanja = km.MestoIzdavanja;
            knjiga.InventarniBroj = km.InventarniBroj;
            knjiga.Naslov = km.Naslov;
            knjiga.Pisac = km.Pisac;
            knjiga.GodinaIzdavanja = km.GodinaIzdavanja;

            bdb.SaveChanges();


            return RedirectToAction("Index");
        }

        public ActionResult Delete()
        {
            return View();
        }

        // GET: Knjiga
        [HttpPost]
        public ActionResult Delete(KnjigaModel km)
        {
            BibliotekaDB bdb = new BibliotekaDB();

            bdb.Knjiga.Remove(km);
            bdb.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var knjiga = bdb.Knjiga.FirstOrDefault(a => a.KnjigaId == id);

            return View(knjiga);
        }
    }
}
